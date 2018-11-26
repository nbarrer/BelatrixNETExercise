using BelatrixExerciseSolution.Interface;
using BelatrixExerciseSolution.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixExerciseSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger fileLogger = LoggerFactory.Get(LoggerType.FILE);
            fileLogger.Log("Message from File", true, false, false);
            fileLogger.Log("Warning from File", false, true, false);
            fileLogger.Log("Error from File", false, false, true);
            fileLogger.Log("Error & Warning from File", false, true, true);

            ILogger consoleLogger = LoggerFactory.Get(LoggerType.CONSOLE);
            consoleLogger.Log("Message from File", true, false, false);
            consoleLogger.Log("Warning from File", false, true, false);
            consoleLogger.Log("Error from File", false, false, true);
            consoleLogger.Log("Error & Warning from File", false, true, true);

            ILogger DBLogger = LoggerFactory.Get(LoggerType.DATABASE);
            DBLogger.Log("Message from File", true, false, false);
            DBLogger.Log("Warning from File", false, true, false);
            DBLogger.Log("Error from File", false, false, true);
            DBLogger.Log("Error & Warning from File", false, true, true);

            Console.ReadLine();
        }
    }
}
