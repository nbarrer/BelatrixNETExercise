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
    public class FileLoggerTests
    {
        [TestMethod()]
        public void CreateFileLoggerInstance()
        {
            var logger = LoggerFactory.Get(LoggerType.FILE);
            Assert.IsInstanceOfType(logger, typeof(FileLogger));
        }

        [TestMethod()]
        public void LogFileMessage()
        {
            string fileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            string fileName = "LogFile_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(fileDirectory, fileName);

            var logger = LoggerFactory.Get(LoggerType.FILE);
            logger.Log("Mensaje test", true, false, false);

            string result = GetContent(filePath);

            if(!result.Contains("[MESSAGE]"))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LogFileWarning()
        {
            string fileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            string fileName = "LogFile_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(fileDirectory, fileName);

            var logger = LoggerFactory.Get(LoggerType.FILE);
            logger.Log("Mensaje test", false, true, false);

            string result = GetContent(filePath);

            if (!result.Contains("[WARNING]"))
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void LogFileError()
        {
            string fileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            string fileName = "LogFile_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(fileDirectory, fileName);

            var logger = LoggerFactory.Get(LoggerType.FILE);
            logger.Log("Mensaje test", false, false, true);

            string result = GetContent(filePath);

            if (!result.Contains("[ERROR]"))
            {
                Assert.Fail();
            }
        }

        private string GetContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}