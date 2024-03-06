using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace AGES.Utils.Editor
{
    public class FindItemUnderMouse : MonoBehaviour
    {
        [ListDrawerSettings(HideAddButton = true, ShowFoldout = true, DraggableItems = false, IsReadOnly = true)]
        public List<GameObject> ComponentsUnderMouse = new();

        public List<GameObject> ComponentsUnderMouseNonUI = new();

        void Update()
        {
            // Get the mouse position in screen space
            
            var mousePosition = Mouse.current.position.ReadValue();

            // Find what is under the mouse
            var pointerEventData = new PointerEventData(EventSystem.current);

            pointerEventData.position = mousePosition;

            var raycastResults = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            ComponentsUnderMouse.Clear();

            foreach (var raycastResult in raycastResults)
            {
                ComponentsUnderMouse.Add(raycastResult.gameObject);
            }


            // Calculate the ray from the camera through the mouse position
            var ray = Camera.main.ScreenPointToRay(mousePosition);

            // Find what is under the mouse
            var hits = Physics.RaycastAll(ray);

            ComponentsUnderMouseNonUI.Clear();

            foreach (var hit in hits)
            {
                ComponentsUnderMouseNonUI.Add(hit.collider.gameObject);
            }
        }
    }
}