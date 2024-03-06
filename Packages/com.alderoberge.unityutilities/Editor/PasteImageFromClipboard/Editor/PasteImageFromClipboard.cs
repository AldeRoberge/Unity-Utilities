using Editor.PasteImageFromClipboard.Editor.Clipboard;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Editor.PasteImageFromClipboard.Editor
{
    public class PasteImageFromClipboard : OdinEditorWindow
    {
        [MenuItem("Utilities/Paste Image From Clipboard")]
        private static void OpenWindow()
        {
            GetWindow<PasteImageFromClipboard>().Show();
        }

        [Button("Paste from clipboard")]
        public void PasteFromClipboard()
        {
            // Get the image from the clipboard

            Texture2D texture = ClipboardImage.Copy();


            // Show an error prompt if the image is not 16x16
            if (texture.width != 16 || texture.height != 16)
            {
                EditorUtility.DisplayDialog("Error", "The image must be 16x16 pixels.", "OK");
                return;
            }

            Debug.Log("Received image from clipboard: " + texture.width + "x" + texture.height);

            // Save the texture to a file in the currently opened folder
            var path = AssetDatabase.GetAssetPath(Selection.activeObject);

            if (string.IsNullOrEmpty(path))
            {
                path = "Assets";
            }
            else if (System.IO.Path.GetExtension(path) != "")
            {
                path = path.Replace(System.IO.Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New Texture.png");

            System.IO.File.WriteAllBytes(assetPathAndName, texture.EncodeToPNG());

            AssetDatabase.Refresh();
        }
    }
}