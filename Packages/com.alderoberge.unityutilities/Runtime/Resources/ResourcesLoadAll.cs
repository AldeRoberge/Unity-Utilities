using System.Linq;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.Resources
{
    // Can be useful when debugging broken serialization
    // Resources.LoadAll triggers a Resources.Load which triggers deserialize of assets in Resources folder
    public class ResourcesLoadAll : MonoBehaviour
    {
        void Start()
        {
            var dummyCode = UnityEngine.Resources.LoadAll<TextAsset>(string.Empty).FirstOrDefault();
            Debug.Log($"Resources.LoadAll<TextAsset>(null) returned {dummyCode}");
        }
    }
}