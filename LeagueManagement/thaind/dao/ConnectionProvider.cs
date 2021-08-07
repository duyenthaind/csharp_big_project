// 
// @author duyenthai
// 

using System;
using System.Data.SqlClient;
using System.IO;
using log4net;
using Newtonsoft.Json.Linq;

namespace LeagueManagement.thaind.dao
{
    public class ConnectionProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConnectionProvider));
        private static string _connectionString = null;
        public static void LoadConfig(string fileConfigName)
        {
            try
            {
                var json = JObject.Parse(File.ReadAllText(fileConfigName));
                var isExistDbString = json.TryGetValue("connectionString", out var value);
                if (isExistDbString)
                {
                    _connectionString = @value.ToString();
                    Log.Info("Load connection configuration ok!!!");
                    Log.Info("ConnectionString is: " + _connectionString);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error load connection configuration, trace: ", ex);
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}