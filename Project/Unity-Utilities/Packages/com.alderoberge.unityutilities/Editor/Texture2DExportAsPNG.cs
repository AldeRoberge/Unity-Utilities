using System.IO;
using UnityEditor;
using UnityEngine;

namespace AGES.Utils.Editor
{
    // Creates a right click menu for Texture2D assets to export them to a PNG file
    public class Texture2DToPNG
    {
        [MenuItem("Assets/Export Texture2D to PNG")]
        private static void ExportTexture2DToPNG()
        {
            // Get the currently selected texture
            var texture2D = Selection.activeObject as Texture2D;
            if (texture2D == null)
            {
                Debug.LogError("No Texture2D selected");
                return;
            }

            // Get path of selected asset
            var path = AssetDatabase.GetAssetPath(texture2D);

            path = path.Replace(".texture2D", ".png");

            var bytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(path, bytes);

            // Refresh the AssetDatabase to show the new PNG file
            AssetDatabase.Refresh();

            var pathRelativeToProject = path.Substring(path.IndexOf("Assets"));

            AssetDatabase.ImportAsset(pathRelativeToProject);

            // Set the filter mode to point (no filtering)
            var importer = AssetImporter.GetAtPath(pathRelativeToProject) as TextureImporter;

            if (importer != null)
            {
                importer.textureType = TextureImporterType.Default;
                importer.filterMode = FilterMode.Point;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.SaveAndReimport();
            }
        }
    }
}