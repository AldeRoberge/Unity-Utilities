using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace AldeRoberge.UnityUtilities.Editor.InputSystem
{
    public class FindItemUnderMouse : MonoBehaviour
    {
        [ListDrawerSettings(HideAddButton = true, ShowFoldout = true, DraggableItems = false, IsReadOnly = true)]
        public List<GameObject> ComponentsUnderMouse = new();

        public List<GameObject> ComponentsUnderMouseNonUI = new();

        void Update()
        {
            UpdateComponentsUnderMouse();
            UpdateComponentsUnderMouseNonUI();
        }

        private void UpdateComponentsUnderMouse()
        {
            var mousePosition = Mouse.current.position.ReadValue();
            var pointerEventData = new PointerEventData(EventSystem.current) { position = mousePosition };
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);
            ComponentsUnderMouse = raycastResults.ConvertAll(result => result.gameObject);
        }

        private void UpdateComponentsUnderMouseNonUI()
        {
            var mousePosition = Mouse.current.position.ReadValue();
            var ray = Camera.main.ScreenPointToRay(mousePosition);
            var hits = Physics.RaycastAll(ray);
            ComponentsUnderMouseNonUI = new List<GameObject>(hits.Length);
            hits.ForEach(hit => ComponentsUnderMouseNonUI.Add(hit.collider.gameObject));
        }
    }
}