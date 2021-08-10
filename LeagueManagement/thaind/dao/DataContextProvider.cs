// @author duyenthai

using System;
using System.Data.Linq;
using System.IO;
using System.Linq;
using LeagueManagement.thaind.entity;
using log4net;
using Newtonsoft.Json.Linq;

namespace LeagueManagement.thaind.dao
{
    public class DataContextProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DataContextProvider));
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
        public static DataContext GetDataContext()
        {
            return new DataContext(_connectionString);
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }

        public static void Test()
        {
            try
            {
                DataContext dataContext = GetDataContext();
                var dhMatches = dataContext.GetTable<DhMatch>();
                foreach (var match in dhMatches)
                {
                    Log.Info($"{match.Id}");
                }

                var obj = dhMatches.Where(p => p.Id == 1);
                Log.Info(obj);

                Log.Info("Hereeeeeeeeeeeeeeeeeeee" + dhMatches.Any());
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex);
            }
            
        }
    }
}