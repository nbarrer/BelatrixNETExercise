using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixExerciseSolution.Interface
{
    public interface ILogger
    {
        void Log(string pMessage, bool logMessage, bool logWarning, bool logError);
    }
}
