// @author duyenthai

using System.IO;
using LeagueManagement.thaind.backend;
using LeagueManagement.thaind.dao;
using log4net.Config;

namespace LeagueManagement.thaind.common
{
    public class Start
    {
        public static void Init()
        {
            LoadAllConfig();
            InitWorker();
        }

        private static void LoadAllConfig()
        {
            XmlConfigurator.Configure(new FileInfo(Directory.GetCurrentDirectory() + @"\config\log4net.xml"));
            ConnectionProvider.LoadConfig(Directory.GetCurrentDirectory() + @"\config\connection_configuration.json");
            Config.LoadConfig();
            DataContextProvider.LoadConfig(Directory.GetCurrentDirectory() + @"\config\connection_configuration.json");
        }

        private static void InitWorker()
        {
            for (var index = -1; ++index < 2;)
            {
                var updateRankingWorker =
                    new UpdateRankingWorker("UpdateRankingWorker_" + index);
                updateRankingWorker.Register();
                updateRankingWorker.Start();
            }

            var hardResetRankingWorker =
                new HardResetRankingWorker("HardResetRankingWorker_0");
            hardResetRankingWorker.Register();
            hardResetRankingWorker.Start();

            var exportAndSendEmailWorker =
                new ExportAndSendEmailWorker("ExportAndSendEmailWorker_0");
            exportAndSendEmailWorker.Register();
            exportAndSendEmailWorker.Start();

            /*ExportAndSendEmailJob job1 = new ExportAndSendEmailJob();
            job1.LeagueId = 1;
            
            BaseWorker.PubJob(typeof(ExportAndSendEmailWorker),-1,job1);*/

            HardResetRankingJob job = new HardResetRankingJob(1, 3);
            BaseWorker.PubJob(typeof(HardResetRankingWorker), -1, job);
            BaseWorker.PrintAllWorker();
        }
    }
}