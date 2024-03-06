using System.Text;
using UnityEditor;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.Editor
{
    /// <summary>
    /// Quick utility to extract list of names of selected assets to console.
    /// </summary>
    public class FileListPrinter : EditorWindow
    {
        [MenuItem("Assets/Print List of Selected Files")]
        private static void PrintSelectedFiles()
        {
            var sb = new StringBuilder();

            foreach (var selectedObject in Selection.objects) 
                sb.AppendLine(selectedObject.name);

            Debug.Log(sb.ToString());
        }
    }
}