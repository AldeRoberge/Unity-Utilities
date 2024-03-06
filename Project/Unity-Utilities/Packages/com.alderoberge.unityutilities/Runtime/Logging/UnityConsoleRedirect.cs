using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.Logging
{
    /// <summary>
    /// Redirects console output (Console.WriteLine) to Unity (Debug.Log)
    /// </summary>
    public class UnityConsoleRedirect : MonoBehaviour
    {
        public void Start()
        {
            Console.SetOut(new UnityTextWriter());
        }

        private class UnityTextWriter : TextWriter
        {
            private StringBuilder buffer = new();

            public override void Flush()
            {
                Debug.Log(buffer.ToString());
                buffer.Length = 0;
            }

            public override void Write(string value)
            {
                buffer.Append(value);
                if (value != null)
                {
                    var len = value.Length;
                    if (len > 0)
                    {
                        var lastChar = value[len - 1];
                        if (lastChar == '\n')
                        {
                            Flush();
                        }
                    }
                }
            }

            public override void Write(char value)
            {
                buffer.Append(value);
                if (value == '\n')
                {
                    Flush();
                }
            }

            public override void Write(char[] value, int index, int count)
            {
                Write(new string(value, index, count));
            }

            public override Encoding Encoding => Encoding.Default;
        }
    }
}