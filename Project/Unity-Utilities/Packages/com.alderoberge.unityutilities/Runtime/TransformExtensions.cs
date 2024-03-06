using UnityEngine;

namespace AldeRoberge.UnityUtilities
{
    public static class TransformExtensions
    {
        public static void DestroyAllChildrenImmediate(this Transform transform, Transform ignore = null)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);

                if (child == ignore)
                    continue;

                Object.DestroyImmediate(child.gameObject);
            }
        }

        public static void DestroyAllChildren(this Transform transform, Transform ignore = null)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);

                if (child == ignore)
                    continue;

                Object.Destroy(child.gameObject);
            }
        }
    }
}