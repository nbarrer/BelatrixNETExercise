using BelatrixExerciseSolution.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixExerciseSolution.Factory
{
    public class LoggerFactory
    {
        public static ILogger Get(LoggerType logger)
        {
            switch(logger)
            {
                case LoggerType.CONSOLE:
                    return new ConsoleLogger();

                case LoggerType.DATABASE:
                    return new DatabaseLogger();

                case LoggerType.FILE:
                default:
                    return new FileLogger();
            }
        }
    }
}
