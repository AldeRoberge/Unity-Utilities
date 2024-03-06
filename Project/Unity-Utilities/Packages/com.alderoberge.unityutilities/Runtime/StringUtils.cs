using System;
using System.Collections.Generic;
using System.Linq;

namespace AldeRoberge.UnityUtilities
{
    public static class StringUtils
    {
        public static bool EqualsIgnoreCase(this string str, string other)
        {
            return str.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this IEnumerable<string> str, string other)
        {
            return str.Any(s => s.EqualsIgnoreCase(other));
        }

        public static int CountOccurrences(this string str, char c)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    count++;
                }
            }

            return count;
        }

        public static string RemoveLineContaining(this string str, string contains)
        {
            string[] lines = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string result = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].Contains(contains))
                {
                    result += lines[i] + Environment.NewLine;
                }
            }

            return result;
        }


        // IsNumeric
        // https://stackoverflow.com/a/894877/112731
        public static bool IsNumeric(this string str)
        {
            return str.All(char.IsNumber);
        }
    }
}