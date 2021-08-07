// @author duyenthai

using System;
using System.IO;
using log4net;
using Newtonsoft.Json.Linq;

namespace LeagueManagement.thaind.common
{
    public class Config
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Config));
        
        public static int RANKING_WORKER_INTERVAL = 0;

        public static void LoadConfig()
        {
            try
            {
                var json = JObject.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + @"\config\configuration.json"));
                var isExistRankingWorkerInterval = json.TryGetValue("ranking_worker_interval", out var value);
                if (isExistRankingWorkerInterval)
                {
                    RANKING_WORKER_INTERVAL = value.ToObject<int>();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error load connection configuration, trace: ", ex);
            }
        }
    }
}