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

        public static string EXPORT_FILE_DIR = "./";

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

                var isExistFileExportDir = json.TryGetValue("export_file_dir", out var exportFileDir);
                if (isExistFileExportDir)
                {
                    EXPORT_FILE_DIR = @exportFileDir.ToObject<string>();
                    try
                    {
                        if (!string.IsNullOrEmpty(EXPORT_FILE_DIR))
                        {
                            if (!Directory.Exists(EXPORT_FILE_DIR))
                            {
                                Directory.CreateDirectory(EXPORT_FILE_DIR);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Create export directory error, ", ex);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error load connection configuration, trace: ", ex);
            }
        }
    }
}