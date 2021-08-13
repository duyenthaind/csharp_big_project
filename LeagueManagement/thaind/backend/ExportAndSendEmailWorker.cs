// @author duyenthai

using System;
using System.IO;
using System.Linq;
using System.Threading;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using LeagueManagement.thaind.entity;
using log4net;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace LeagueManagement.thaind.backend
{
    public class ExportAndSendEmailWorker : BaseWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ExportAndSendEmailWorker));

        private static bool _running = true;

        public ExportAndSendEmailWorker(string name) : base(name)
        {
        }

        protected override void RunThread()
        {
            while (_running)
            {
                lock (JOB_QUEUE)
                {
                    while (!JOB_QUEUE.IsEmpty)
                    {
                        var takeOk = JOB_QUEUE.TryTake(out var job);
                        if (takeOk)
                        {
                            ExportAndSendMail(job);
                        }
                    }
                }

                //This worker requires response immediately, do not sleep it 
            }
        }

        protected override void Stop()
        {
            _running = false;
            Log.Info($"Worker {GetWorkerName()} has stopped!!!");
        }

        private void ExportAndSendMail(BaseJob job)
        {
            try
            {
                Log.Info("Try do job: " + job);
                if (job.GetType() == typeof(ExportAndSendEmailJob))
                {
                    var workJob = (ExportAndSendEmailJob) job;
                    var databaseContext = DatabaseObject.GetDatabaseContext();
                    var dhLeagueRankingDAO = new DhLeagueRankingDAO();
                    var dhMatchDAO = new DhMatchDAO();
                    var listAllRankingByLeagueSeasonId =
                        dhLeagueRankingDAO.GetListAllRankingByLeagueSeasonId(workJob.LeagueId, workJob.SeasonId);
                    var listFinishedMatches =
                        dhMatchDAO.GetListFinishedMatchesByLeagueSeasonId(workJob.LeagueId, workJob.SeasonId);
                    var dhLeague = databaseContext.DhLeagues.First(p => p.Id == workJob.LeagueId);
                    var dhNation = new DhNation();
                    if (dhLeague != null)
                    {
                        dhNation = databaseContext.DhNations.First(p => p.Id == dhLeague.NationId);
                    }

                    if (dhLeague == null)
                    {
                        return;
                    }
                    var fileName = Config.EXPORT_FILE_DIR + "ExportFile_" + DateTime.Now.ToString("dddd-MM-yyyy") +
                                   "_" + Guid.NewGuid();
                    using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        
                        
                        var workbook = new XSSFWorkbook();
                        var sheet1 = workbook.CreateSheet("League statistic");

                        //header
                        var rowIndex = -1;
                        var rowHeader = sheet1.CreateRow(++rowIndex);
                        var cellMerge = new CellRangeAddress(0, 0, 0, 5);
                        sheet1.AddMergedRegion(cellMerge);
                        rowHeader.GetCell(0).SetCellValue("League statistic " + dhLeague.Name);
                        
                        //matches
                        var rowMatches = sheet1.CreateRow(++rowIndex);
                        var cellMatches1 = rowMatches.CreateCell(0);
                        cellMatches1.SetCellValue("Number of finished matches: ");
                        var cellMatches2 = rowMatches.CreateCell(1);
                        cellMatches2.SetCellValue(listFinishedMatches.Count);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error ", ex);
            }
        }
    }
}