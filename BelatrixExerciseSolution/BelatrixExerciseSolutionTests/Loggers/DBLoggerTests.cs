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
using System.Data.SqlClient;

namespace BelatrixExerciseSolution.Tests
{
    [TestClass()]
    public class DBLoggerTests
    {
        [TestMethod()]
        public void CreateDBLoggerInstance()
        {
            var logger = LoggerFactory.Get(LoggerType.DATABASE);
            Assert.IsInstanceOfType(logger, typeof(DatabaseLogger));
        }

        [TestMethod()]
        public void LogDBMessage()
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            var logger = LoggerFactory.Get(LoggerType.DATABASE);
            logger.Log("Mensaje test", true, false, false);

            int type = GetLoggedType(connectionString);

            Assert.AreEqual((int)MessageType.MESSAGE, type);
        }

        [TestMethod]
        public void LogDBWarning()
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            var logger = LoggerFactory.Get(LoggerType.DATABASE);
            logger.Log("Mensaje test", false, true, false);

            int type = GetLoggedType(connectionString);

            Assert.AreEqual((int)MessageType.WARNING, type);

        }
        [TestMethod]
        public void LogDBError()
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            var logger = LoggerFactory.Get(LoggerType.DATABASE);
            logger.Log("Mensaje test", false, false, true);

            int type = GetLoggedType(connectionString);

            Assert.AreEqual((int)MessageType.ERROR, type);
        }

        private int GetLoggedType(string connectionString)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = "select top 1 * from Log order by id desc";
                SqlCommand sqlCommand = new SqlCommand(command);
                sqlCommand.Connection = connection;

                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        result = (int)reader[2];
                    }
                }
            }

            return result;
        }

    }
}