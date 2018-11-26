using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixExerciseSolution.Util
{
    public static class Common
    {
        public static bool IsValidateMessage(string pMessage)
        {
            if (string.IsNullOrEmpty(pMessage))
            {
                return false;
            }
            return true;
        }
    }
}
