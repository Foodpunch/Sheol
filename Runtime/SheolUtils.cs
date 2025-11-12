using System.Globalization;
using UnityEngine;

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
}
