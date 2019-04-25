using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class TextLogger : ILogger
    {
        public void Log(string logName, string message, string path = "")
        {
            try
            {
                var mainPath = AppDomain.CurrentDomain.BaseDirectory + "/Log";
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string hour = DateTime.Now.Hour.ToString();

                string fullPath = $"{mainPath}/{year}/{month}/{day}";

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }

                string filePath = $"{fullPath}/{logName}_{hour}.txt";
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("/*------------------ START " + DateTime.Now.ToString() + "------------------*/");
                sw.WriteLine(message);
                sw.WriteLine("/*------------------ END " + DateTime.Now.ToString() + "------------------*/");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch
            {

            }

        }
    }
}
