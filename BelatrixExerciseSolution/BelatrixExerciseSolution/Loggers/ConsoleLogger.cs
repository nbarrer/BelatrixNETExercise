using BelatrixExerciseSolution.Interface;
using BelatrixExerciseSolution.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixExerciseSolution
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string pMessage, bool logMessage, bool logWarning, bool logError)
        {
            if(!Common.IsValidateMessage(pMessage))
            {
                return;
            }

            if(logMessage)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(pMessage);
            }

            if (logWarning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(pMessage);
            }

            if (logError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(pMessage);
            }
        }       
    }
}
