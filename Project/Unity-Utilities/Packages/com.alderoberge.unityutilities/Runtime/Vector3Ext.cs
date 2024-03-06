using UnityEngine;

namespace AldeRoberge.UnityUtilities
{
    public static class Vector3Ext
    {
        // Clone a Vector3
        public static Vector3 Clone(this Vector3 v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        // Returns a Vector3 formatted to TextMeshPro colors. X is red, Y is green, Z is blue.
        public static string ToColorString(this Vector3 v)
        {
            return $"<color=#ff0000ff>{v.x}</color>, <color=#00ff00ff>{v.y}</color>, <color=#0000ffff>{v.z}</color>";
        }

        // Randomize
        public static Vector3 Randomize(this Vector3 v, float max)
        {
            return v + new Vector3(Random.Range(-max, max), 0, Random.Range(-max, max));
        }
    }
}