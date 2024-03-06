using UnityEngine;

namespace AldeRoberge.UnityUtilities
{
    public static class GameObjectLayerExtensions
    {
        /// <summary>
        /// Sets the layer of the game object and all its children.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="layer"></param>
        /// <param name="includeChildren"></param>
        public static void SetLayer(this GameObject parent, int layer, bool includeChildren = true)
        {
            parent.layer = layer;

            if (!includeChildren) return;

            foreach (var transform in parent.transform.GetComponentsInChildren<Transform>(true))
            {
                transform.gameObject.layer = layer;
            }
        }

        // EnsureComponent
        public static T EnsureComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }
    }
}