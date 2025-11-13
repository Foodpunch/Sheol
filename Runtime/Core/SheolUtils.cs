using System.Globalization;
using UnityEngine;

namespace ProjectRuntime.Core.SheolUtils
{
    public static class SheolUtils
    {
        /// <summary>
        /// Convert string to int
        /// </summary>
        public static int ConvertToInt32(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                // Treat data not filled in as 0
                return 0;
            }

            return int.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : 0;
        }
            
        /// <summary>
        /// Convert string to float
        /// </summary>
        public static float ConvertToSingle(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                // Treat data not filled in as 0
                return 0f;
            }

            return float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : 0f;
        }

        /// <summary>
        /// Convert string to double
        /// </summary>
        /// <param name="text"></param>
        /// <returns>double</returns>
        public static double ConvertToDouble(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            if (double.TryParse(text, out double result))
            {
                return result;
            }

            return 0;
        }

        /// <summary>
        /// Convert string to decimal
        /// </summary>
        /// <param name="text"></param>
        /// <returns>decimal</returns>
        public static decimal ConvertToDecimal(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            if (decimal.TryParse(text, out decimal result))
            {
                return result;
            }

            return 0;
        }

        #if UNITY_EDITOR
        /// <summary>
        /// Save AssetDatabase
        /// </summary>
        /// <param name="obj"></param>
        public static void SaveScriptableObject(Object obj)
        {
            // Mark the ScriptableObject as dirty
            UnityEditor.EditorUtility.SetDirty(obj);

            // Save the changes to the asset file
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
            Debug.Log("ScriptableObject updated and saved!");
        }
#endif
    }
}
