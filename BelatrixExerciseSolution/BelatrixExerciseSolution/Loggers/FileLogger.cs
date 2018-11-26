using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using BelatrixExerciseSolution.Interface;
using BelatrixExerciseSolution.Util;

namespace BelatrixExerciseSolution
{
    public class FileLogger : ILogger
    {
        public void Log (string pMessage, bool logMessage, bool logWarning, bool logError)
        {
            if (!Common.IsValidateMessage(pMessage))
            {
                return;
            }

            if (logMessage)
            {
                Log(pMessage, MessageType.MESSAGE);
            }

            if(logWarning)
            {
                Log(pMessage, MessageType. WARNING);
            }

            if (logError)
            {
                Log(pMessage, MessageType.ERROR);
            }
        }

        public void Log(string pMessage, MessageType pType)
        {
            string fileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            string fileName = "LogFile_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(fileDirectory, fileName);
            string fileContent = string.Empty;
            string formatMessage = string.Format("{0} {1} {2}", "[" + pType + "]", DateTime.Now.ToShortDateString(), pMessage);

            if (File.Exists(filePath))
            {
                fileContent = File.ReadAllText(filePath) + formatMessage;
            }
            else
            {
                fileContent = formatMessage;
            }

            File.WriteAllText(filePath, fileContent);
        }

    }
}
