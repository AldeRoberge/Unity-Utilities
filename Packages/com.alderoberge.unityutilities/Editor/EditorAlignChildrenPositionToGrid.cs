using Sirenix.OdinInspector;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.Editor
{
    public class EditorAlignChildrenPositionToGrid : MonoBehaviour
    {
        /// Gets the children of the object and aligns their position to the grid (nearest whole number)
        [ContextMenu("Align Children Position To Grid")]
        [Button("Align Children Position To Grid")]
        public void AlignChildrensPositionToGrid()
        {
            foreach (Transform child in transform)
            {
                child.localPosition = new Vector3(Mathf.Round(child.localPosition.x), Mathf.Round(child.localPosition.y), Mathf.Round(child.localPosition.z));
            }
        }
    }
}