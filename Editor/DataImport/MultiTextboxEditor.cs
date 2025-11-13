using UnityEngine;
using UnityEditor;
using ProjectRuntime.Data;
using System.Reflection;

#if UNITY_EDITOR
namespace ProjectEditor.Data
{
    public class MultiTextBoxEditor<T> : Editor where T : IDataImport
    {
        private string _dataInput = string.Empty;

        public override void OnInspectorGUI()
        {
            // Update the serialized object
            this.serializedObject.Update();

            // Label
            EditorGUILayout.LabelField("Script Textbox", EditorStyles.boldLabel);

            // Text box
            this._dataInput = EditorGUILayout.TextArea(this._dataInput, GUILayout.Height(120));
            if (GUILayout.Button("Import Script", GUILayout.Height(20)))
            {
                typeof(T).GetMethod("ImportData", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).Invoke(null, new object[] { this._dataInput });
            }

            EditorGUILayout.Space();

            // Apply changes to the serialized object
            this.serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}
#endif