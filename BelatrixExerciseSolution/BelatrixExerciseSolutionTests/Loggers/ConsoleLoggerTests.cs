using Microsoft.VisualStudio.TestTools.UnitTesting;
using BelatrixExerciseSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixExerciseSolution.Interface;
using BelatrixExerciseSolution.Factory;
using BelatrixExerciseSolution.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.IO;
using System.Configuration;

namespace BelatrixExerciseSolution.Tests
{
    [TestClass()]
    public class ConsoleLoggerTests
    {
        [TestMethod()]
        public void CreateConsoleLoggerInstance()
        {
            var logger = LoggerFactory.Get(LoggerType. CONSOLE);
            Assert.IsInstanceOfType(logger, typeof(ConsoleLogger));
        }

        [TestMethod()]
        public void LogConsoleMessage()
        {
            var logger = LoggerFactory.Get(LoggerType.CONSOLE);
            logger.Log("Mensaje test", true, false, false);

            Assert.AreEqual(ConsoleColor.White, Console.ForegroundColor);
        }

        [TestMethod]
        public void LogConsoleWarning()
        {          
            var logger = LoggerFactory.Get(LoggerType.CONSOLE);
            logger.Log("Mensaje test", false, true, false);

            Assert.AreEqual(ConsoleColor.Yellow, Console.ForegroundColor);

        }
        [TestMethod]
        public void LogConsoleError()
        {
            var logger = LoggerFactory.Get(LoggerType.CONSOLE);
            logger.Log("Mensaje test", false, false, true);

            Assert.AreEqual(ConsoleColor.Red, Console.ForegroundColor);
        }

    }
}