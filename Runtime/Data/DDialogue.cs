using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProjectRuntime.Core.SheolUtils;
using UnityEditor;
using UnityEngine;

namespace ProjectRuntime.Data
{
    [CreateAssetMenu(fileName = "DDialogue", menuName = "Data/DDialogue", order = 3)]
    public class DDialogue : ScriptableObject, IDataImport
    {
        [field: SerializeField]
        public List<DialogueData> Data { get; private set; }

#if UNITY_EDITOR
        public static DDialogue GetAllData()
        {
            //I don't think you'll ever "get data" for this outside of the editor
            //So this shouldddd be okay???

            var obj = Selection.activeObject as DDialogue;
            if (obj == null)
            {
                Debug.LogWarning("No DDialogue asset selected!");
                return null;
            }

            var path = AssetDatabase.GetAssetPath(obj);
            // Load a fresh reference directly from the asset database every time
            return AssetDatabase.LoadAssetAtPath<DDialogue>(path);
        }
#endif

        public List<DialogueData> GetDialogueSequences()
        {
            if (this.Data.Count > 0)
            {
                return this.Data;
            }
            Debug.LogError($"Error! No dialogue found in Dialogue Scriptable Obj!");
            return null;
        }


#if UNITY_EDITOR

        public static void ImportData(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var loadedData = GetAllData();
            if (loadedData == null)
            {
                return;
            }

            if (loadedData.Data == null)
            {
                loadedData.Data = new List<DialogueData>();
            }
            else
            {
                loadedData.Data.Clear();
            }

            // special handling for shape parameter and percentage
            var pattern = @"[{}""]";
            text = text.Replace("\r\n", "\n");      // handle window line break
            text = text.Replace(",\n", ",");
            text = Regex.Replace(text, pattern, "");

            // Split data into lines
            var lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.None);
            for (var i = 0; i < lines.Length; i++)
            {
                // Comment and Header
                if (lines[i][0].Equals('#') || lines[i][0].Equals('$'))
                {
                    continue;
                }

                // Empty line
                var trimLine = lines[i].Trim();
                var testList = trimLine.Split('\t');
                if (testList.Length == 1 && string.IsNullOrEmpty(testList[0]))
                {
                    continue;
                }

                // Split
                var paramList = lines[i].Split('\t');
                for (var j = 0; j < paramList.Length; j++)
                {
                    paramList[j] = paramList[j].Trim();
                }

                var dialogueData = new DialogueData
                {
                    DisplayName = paramList[1],
                    DialogueAction = Enum.TryParse(paramList[2], out DialogueAction action) ? action : DialogueAction.TALK,
                    Position = Enum.TryParse(paramList[3], out Position pos) ? pos : Position.LEFT,
                    IconPath = paramList[4],
                    AudioPath = paramList[5],
                    Text = paramList[6]
                };

                loadedData.Data.Add(dialogueData);
            }

            SheolUtils.SaveScriptableObject(loadedData);
        }

#endif
    }

    [Serializable]
    public struct DialogueData
    {
        [field: SerializeField]
        public string DisplayName { get; set; }

        [field: SerializeField]
        public DialogueAction DialogueAction { get; set; }

        [field: SerializeField]
        public Position Position { get; set; }

        [field: SerializeField]
        public string IconPath { get; set; }

        [field: SerializeField]
        public string AudioPath { get; set; }

        [field: SerializeField]
        public string Text { get; set; }
    }

    [Serializable]
    public enum DialogueAction
    {
        ENTER_FROM_LEFT,
        ENTER_FROM_RIGHT,
        EXIT_TO_LEFT,
        EXIT_TO_RIGHT,
        TALK,
    }

    [Serializable]
    public enum Position
    {
        LEFT,
        RIGHT,
    }

}

