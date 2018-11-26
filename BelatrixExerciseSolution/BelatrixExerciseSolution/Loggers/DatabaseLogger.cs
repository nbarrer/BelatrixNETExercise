using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using BelatrixExerciseSolution.Interface;
using BelatrixExerciseSolution.Util;

namespace BelatrixExerciseSolution
{
    public class DatabaseLogger : ILogger
    {
        public void Log(string pMessage, bool logMessage, bool logWarning, bool logError)
        {
            if (!Common.IsValidateMessage(pMessage))
            {
                return;
            }

            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            if (logMessage)
            {
                Insert(pMessage, MessageType.MESSAGE, connectionString);
            }

            if (logWarning)
            {
                Insert(pMessage, MessageType.WARNING, connectionString);
            }

            if (logError)
            {
                Insert(pMessage, MessageType.ERROR, connectionString);
            }

        }

        public void Insert(string pMessage, MessageType pType, string pConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(pConnectionString))
            {
                try
                {
                    string command = string.Format("Insert into Log Values('{0}', '{1}')", pMessage, (int)pType);
                    SqlCommand sqlCommand = new SqlCommand(command);
                    sqlCommand.Connection = connection;

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
