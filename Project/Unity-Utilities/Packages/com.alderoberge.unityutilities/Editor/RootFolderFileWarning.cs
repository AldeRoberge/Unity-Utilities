using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.Editor
{
    /// <summary>
    /// Warns the user when certain files are in the root of the project.
    /// As an example, no scripts should be in the root folder.
    /// Every script should be in the folder "AlienGarden", to be included in the Alien Garden assembly.
    /// </summary>
    public class RootFolderFileWarning : AssetPostprocessor
    {
        private const string PathToMoveFrom = "Assets";
        private const string PathToMoveTo   = "Assets/AlienGarden";

        private static readonly Dictionary<string, string> FileFolderByExtension = new()
        {
            { ".anim", $"{PathToMoveTo}/Art/Animations/" },
            { ".mat", $"{PathToMoveTo}/Art/Materials/" },
            { ".fbx", $"{PathToMoveTo}/Art/Meshes/" },
            { ".bmp", $"{PathToMoveTo}/Images/" },
            { ".png", $"{PathToMoveTo}/Images/" },
            { ".jpg", $"{PathToMoveTo}/Images/" },
            { ".jpeg", $"{PathToMoveTo}/Images/" },
            { ".psd", $"{PathToMoveTo}/Images/" },
            { ".mixer", $"{PathToMoveTo}/Audio/Mixers/" },
            { ".wav", $"{PathToMoveTo}/Audio/" },
            { ".cs", $"{PathToMoveTo}/Scripts/" },
            { ".shader", $"{PathToMoveTo}/Shaders/" },
            { ".cginc", $"{PathToMoveTo}/Shaders/" }
        };

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach (var oldFilePath in importedAssets)
            {
                var directory = Path.GetDirectoryName(oldFilePath);

                if (!PathToMoveFrom.Equals(directory))
                    continue;

                var extension = Path.GetExtension(oldFilePath).ToLower();

                if (!FileFolderByExtension.ContainsKey(extension))
                    continue;

                var filename = Path.GetFileName(oldFilePath);
                var newFolder = FileFolderByExtension[extension];

                Debug.Log($"Reminder : You should move asset ({filename}) to path: {newFolder}");

                // AssetDatabase.MoveAsset(oldFilePath, newFolder + filename);
                // Note : You could move assets automatically, but it's not recommended.
                // Scripts will throw an error, references will be lost, etc.
            }
        }
    }
}