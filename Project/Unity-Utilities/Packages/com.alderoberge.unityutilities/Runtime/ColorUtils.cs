using UnityEngine;

namespace AldeRoberge.UnityUtilities
{
    public class ColorUtils
    {
        /// <summary>
        /// Converts a hex string (e.g. "FF00FF") to a Color object.
        /// </summary>
        public static Color FromHex(string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out var color))
                return color;

            // Remove the "#" symbol if present
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            // Ensure the hex string has a valid length
            if (hex.Length != 6)
            {
                Debug.LogError("Invalid hex color format. Hex string must be in the format RRGGBB.");
                return Color.black;
            }

            // Parse the individual color components
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            // Create and return the Color object
            return new Color32(r, g, b, 255);
        }

        public static Color GetVariation(Color color, float p1)
        {
            return new Color(color.r * p1, color.g * p1, color.b * p1, color.a);
        }
    }
}