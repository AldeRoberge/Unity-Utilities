using UnityEngine;

namespace AldeRoberge.UnityUtilities.ComponentUtils
{
    public class DisableOnAwake : MonoBehaviour
    {
        void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}
