using UnityEngine;

namespace AldeRoberge.UnityUtilities.ComponentUtils
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        void Start()
        {
            // Ensure that this gameObject is a root gameObject
            if (transform.parent != null)
            {
                Debug.LogWarning($"[Singleton] Can't make this object ({gameObject.name}) dont destroy on load, only root game objects can be set to not destroy on load.");
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}