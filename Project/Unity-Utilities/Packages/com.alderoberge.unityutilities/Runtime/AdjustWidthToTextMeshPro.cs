using UnityEngine;

namespace AldeRoberge.UnityUtilities
{
    public class AdjustWidthToTextMeshPro : MonoBehaviour
    {
        [SerializeField] private float _horizontalPadding = 20;
        [SerializeField] private float _verticalPadding;

        void Start()
        {
            // Get the child object with the TextMeshPro component
            var textMesh = GetComponentInChildren<TMPro.TextMeshProUGUI>();

            // Get the RectTransform of the parent object
            var rectTransform = GetComponent<RectTransform>();

            // Set the width of the parent object to the width of the text with padding
            rectTransform.sizeDelta = new Vector2(textMesh.preferredWidth + _horizontalPadding, rectTransform.sizeDelta.y + _verticalPadding);
        }
    }
}