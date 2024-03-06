using UnityEditor;
using UnityEngine;

namespace AGES.Utils.Editor.Tools
{
    public class uGUITools : MonoBehaviour
    {
        [MenuItem("Unity Helpers/Anchors to Corners %[")]
        static void AnchorsToCorners()
        {
            var t = Selection.activeTransform as RectTransform;
            var pt = Selection.activeTransform.parent as RectTransform;

            if (t == null || pt == null) return;

            var newAnchorsMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                                                t.anchorMin.y + t.offsetMin.y / pt.rect.height);
            var newAnchorsMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                                                t.anchorMax.y + t.offsetMax.y / pt.rect.height);

            t.anchorMin = newAnchorsMin;
            t.anchorMax = newAnchorsMax;
            t.offsetMin = t.offsetMax = new Vector2(0, 0);
        }

        [MenuItem("Unity Helpers/Corners to Anchors %]")]
        static void CornersToAnchors()
        {
            var t = Selection.activeTransform as RectTransform;

            if (t == null) return;

            t.offsetMin = t.offsetMax = new Vector2(0, 0);
        }
    }
}
