using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    /// <summary>
    /// The Logger Class to handle Logger's or write simpli text to a file or just read from a text file and output it into a command shell
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Write Text to a Log file
        /// </summary>
        /// <param name="useLog">The File to use</param>
        /// <param name="logMessage">Text to write</param>
        /// <param name="dt">Determine wether to use Date and Time for the Text string to be writen</param>
        public static void WriteLine(string useLog, string logMessage, [Optional] string dt)
        {
            using (StreamWriter v = File.AppendText(useLog))
            {
                using (TextWriter w = v)
                {
                    if (dt != null)
                    {
                        w.WriteLine("Log Entry: {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    }
                    w.WriteLine(logMessage);
                    w.WriteLine("-------------------------------");
                    w.Close();
                }
            }
        }

        /// <summary>
        /// Simpli Text Writer
        /// </summary>
        /// <param name="writeToFile">The File to use</param>
        /// <param name="textToWrite">Text to write</param>
        public static void WriteText(string writeToFile, string textToWrite)
        {
            using (StreamWriter v = File.AppendText(writeToFile))
            {
                using (TextWriter w = v)
                {
                    w.WriteLine(textToWrite);
                    w.Close();
                }
            }
        }

        /// <summary>
        /// Read Text from a File and Output it in a Command Prompt
        /// </summary>
        /// <param name="readFromFile"></param>
        public static void ReadLine(string readFromFile)
        {
            var v = File.ReadAllLines(readFromFile);
            Console.WriteLine(v);
        }
    }
}
