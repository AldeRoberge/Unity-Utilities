using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace AldeRoberge.UnityUtilities.ComponentUtils
{
    public class EnsureOnlyOneEventSystem : MonoBehaviour
    {

        void Start()
        {
            // Register scene load
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Awake()
        {
            EnsureSingleEventSystem();
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            EnsureSingleEventSystem();
        }

        private void EnsureSingleEventSystem()
        {
            // Find all EventSystem objects in the scene
            EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

            // If there is more than one, destroy the extra ones
            if (eventSystems.Length > 1)
            {
                foreach (var eventSystem in eventSystems)
                {
                    if (eventSystem.gameObject != gameObject)
                    {
                        Debug.LogWarning("[EnsureOnlyOneEventSystem] Destroying extra Event System : " + eventSystem.gameObject.name);
                        eventSystem.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}