using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AldeRoberge.UnityUtilities
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Initialize()
        {
            _instance = null;
        }

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                Debug.Log($"Loading singleton scriptable object with address based on the type name {typeof(T).Name}.");

                var name = typeof(T).Name;
                var handle = Addressables.LoadAssetAsync<T>(name);
                handle.WaitForCompletion();
                _instance = handle.Result;

                if (_instance == null)
                {
                    Debug.LogError($"Failed to load singleton scriptable object with address {typeof(T)}.");
                    return null;
                }

                (_instance as SingletonScriptableObject<T>).OnInitialize();

                return _instance;
            }
        }

        // Optional overridable method for initializing the instance.
        protected virtual void OnInitialize()
        {
        }
    }
}