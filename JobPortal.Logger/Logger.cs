using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Logger
{
    public class Logger
    {
        public static void LogInfo(string path, string msg)
        {

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"Info logs");
                    sw.WriteLine($"{DateTime.Now.ToLocalTime().ToString()} Info: {msg}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{DateTime.Now.ToLocalTime().ToString()} Info: {msg}");
                }
            }
        }
        public static void LogError(string path, string msg)
        {

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"Error logs");
                    sw.WriteLine($"{DateTime.Now.ToLocalTime().ToString()} Error: {msg}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($" {DateTime.Now.ToLocalTime().ToString()} Error: {msg}");
                }
            }
        }
    }
}
