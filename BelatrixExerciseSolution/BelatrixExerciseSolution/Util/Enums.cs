using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixExerciseSolution
{
    public enum LoggerType
    {
        FILE,
        DATABASE,
        CONSOLE
    }

    public enum MessageType
    {
        MESSAGE = 1,
        ERROR = 2,
        WARNING = 3
    }
}
