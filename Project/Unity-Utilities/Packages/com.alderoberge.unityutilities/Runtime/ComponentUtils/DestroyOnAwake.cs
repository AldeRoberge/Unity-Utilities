using UnityEngine;

namespace AldeRoberge.UnityUtilities.ComponentUtils
{
    public class DestroyOnAwake : MonoBehaviour
    {
        void Awake()
        {
            Destroy(gameObject);
        }
    }
}
