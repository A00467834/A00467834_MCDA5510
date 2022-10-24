using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAssign1
{
    class Logger
    {
        public static void logToFile(string logMessage)
        {
            using (StreamWriter w = File.AppendText(@"D:\SMU\Software-dev-5510\.net assignment 1\MCDA_5510_Assignment_directory\A00467834_MCDA5510\Assignment1\ProgAssign1\logs\logger.txt"))
            {
                // w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                //w.WriteLine("  :");
                w.WriteLine($"  :{logMessage}");
                w.WriteLine("-------------------------------");
            }
        }
    }
}
