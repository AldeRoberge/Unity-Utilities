using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace AGES.Utils.Editor
{
    public static class AddressableEditorExtension
    {
        /// <summary>
        /// Set Addressables Key/ID of an gameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to set Key/ID</param>
        /// <param name="id">Key/ID</param>
        public static void SetAddressableID(this GameObject gameObject, string id)
        {
            SetAddressableID(gameObject as Object, id);
        }
 
        /// <summary>
        /// Set Addressables Key/ID of an object.
        /// </summary>
        /// <param name="o">Object to set Key/ID</param>
        /// <param name="id">Key/ID</param>
        public static void SetAddressableID(this Object o, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogWarning($"Can not set an empty adressables ID.");
            }
            var entry = GetAddressableAssetEntry(o);
            if (entry != null)
            {
                entry.address = id;
            }
        }
 
        /// <summary>
        /// Get Addressables Key/ID of an gameObject.
        /// </summary>
        /// <param name="gameObject">gameObject to recive addressables Key/ID</param>
        /// <returns>Addressables Key/ID</returns>
        public static string GetAddressableID(this GameObject gameObject)
        {
            return GetAddressableID(gameObject as Object);
        }
 
        /// <summary>
        /// Get Addressables Key/ID of an object.
        /// </summary>
        /// <param name="o">object to recive addressables Key/ID</param>
        /// <returns>Addressables Key/ID</returns>
        private static string GetAddressableID(this Object o)
        {
            var entry = GetAddressableAssetEntry(o);
            return entry != null ? entry.address : "";
        }
 
        /// <summary>
        /// Get addressable asset entry of an object.
        /// </summary>
        /// <param name="o">>object to recive addressable asset entry</param>
        /// <returns>addressable asset entry</returns>
        public static AddressableAssetEntry GetAddressableAssetEntry(Object o)
        {
            var aaSettings = AddressableAssetSettingsDefaultObject.Settings;
 
            AddressableAssetEntry entry = null;
            var guid = string.Empty;
            long localID = 0;
            string path;
 
            var foundAsset = AssetDatabase.TryGetGUIDAndLocalFileIdentifier(o, out guid, out localID);
            path = AssetDatabase.GUIDToAssetPath(guid);
 
            if (foundAsset && (path.ToLower().Contains("assets")))
            {
                if (aaSettings != null)
                {
                    entry = aaSettings.FindAssetEntry(guid);
                }
            }

            return entry;
        }
    }
}