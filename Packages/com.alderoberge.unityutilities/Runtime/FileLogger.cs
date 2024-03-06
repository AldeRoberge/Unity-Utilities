using System.Collections.Generic;
using UnityEngine;

namespace AldeRoberge.UnityUtilities
{
    public class LogFile
    {
        public string Name;
        internal List<string> Content;
    }

    public static class FileLogger
    {
        private static readonly Dictionary<string, LogFile> Books = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Application.quitting += ShowMissingKeys;
        }

        public static void Log(string fileName, string lineContent)
        {
            if (!Books.ContainsKey(fileName))
            {
                Books.Add(fileName, new LogFile { Name = fileName, Content = new List<string>() });
            }

            if (!Books[fileName].Content.Contains(lineContent))
                Books[fileName].Content.Add(lineContent);
        }

        // Save and open the file if there is more than 1 missing key
        private static void ShowMissingKeys()
        {
            foreach (var values in Books)
            {
                string path = $"{Application.dataPath}/{values.Value.Name}.txt";
                System.IO.File.WriteAllLines(path, values.Value.Content.ToArray());

                // Open in notepad
                System.Diagnostics.Process.Start("notepad.exe", path);
            }
        }
    }
}