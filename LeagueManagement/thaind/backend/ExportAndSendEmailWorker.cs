// @author duyenthai

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
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
                    listAllRankingByLeagueSeasonId = listAllRankingByLeagueSeasonId.OrderByDescending(p => p.Point).ThenBy(p => p.Difference).ThenBy(p => p.NumWin)
                        .ThenBy(p => p.TeamId).ToList();
                    var listFinishedMatches =
                        dhMatchDAO.GetListFinishedMatchesByLeagueSeasonId(workJob.LeagueId, workJob.SeasonId);
                    var dhLeague = databaseContext.DhLeagues.First(p => p.Id == workJob.LeagueId);
                    var dhNation = new DhNation();
                    var dhSeason = new DhSeason();
                    var listTeamInLeague = new List<DhTeam>();
                    if (dhLeague != null)
                    {
                        dhNation = databaseContext.DhNations.First(p => p.Id == dhLeague.NationId);
                        dhSeason = databaseContext.DhSeasons.First(p => p.Id == workJob.SeasonId);
                        listTeamInLeague = databaseContext.DhTeams.Where(p => p.NationId == dhLeague.NationId).ToList();
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
                        ++rowIndex;
                        
                        //league
                        var rowLeagueInfo = sheet1.CreateRow(++rowIndex);
                        var cellNameLeague1 = rowLeagueInfo.CreateCell(0);
                        cellNameLeague1.SetCellValue("League: ");
                        var cellNameLeague2 = rowLeagueInfo.CreateCell(1);
                        cellNameLeague2.SetCellValue(dhLeague.Name);
                        
                        var rowNationInfo = sheet1.CreateRow(++rowIndex);
                        var cellNation1 = rowNationInfo.CreateCell(0);
                        cellNation1.SetCellValue("Nation: ");
                        var cellNation2 = rowNationInfo.CreateCell(1);
                        cellNation2.SetCellValue(dhNation.Name);
                        
                        var rowLeagueSeasonInfo = sheet1.CreateRow(++rowIndex);
                        var cellLeagueSeason1 = rowLeagueSeasonInfo.CreateCell(0);
                        cellLeagueSeason1.SetCellValue("Season: ");
                        var cellLeagueSeason2 = rowLeagueSeasonInfo.CreateCell(1);
                        cellLeagueSeason2.SetCellValue(dhSeason.Name);
                        
                        var rowLeagueTimeInfo = sheet1.CreateRow(++rowIndex);
                        var cellLeagueTime1 = rowLeagueTimeInfo.CreateCell(0);
                        cellLeagueTime1.SetCellValue("Duration: ");
                        var cellLeagueTime2 = rowLeagueTimeInfo.CreateCell(1);
                        var leagueStartTime = DateTimeOffset.FromUnixTimeMilliseconds(dhSeason.StartTime);
                        cellLeagueTime2.SetCellValue("From: " + leagueStartTime.ToString("MM/dd/yyyy"));
                        var cellLeagueTime3 = rowLeagueTimeInfo.CreateCell(2);
                        var leagueStopTime = DateTimeOffset.FromUnixTimeMilliseconds(dhSeason.EndTime);
                        cellLeagueTime3.SetCellValue("To: " + leagueStopTime.ToString("MM/dd/yyyy"));
                        ++rowIndex;
                        
                        
                        //matches
                        var rowMatches = sheet1.CreateRow(++rowIndex);
                        var cellMatches1 = rowMatches.CreateCell(0);
                        cellMatches1.SetCellValue("Number of finished matches: ");
                        var cellMatches2 = rowMatches.CreateCell(1);
                        cellMatches2.SetCellValue(listFinishedMatches.Count);
                        ++rowIndex;
                        
                        //team statistic
                        var endColumnHeaderTeamStat = 2;
                        var mostWin = listAllRankingByLeagueSeasonId.Max(p => p.NumWin);
                        var mostLost = listAllRankingByLeagueSeasonId.Max(p => p.NumLost);
                        var dhTeamMostWin = listAllRankingByLeagueSeasonId.Where(p => p.NumWin == mostWin).ToList();
                        var dhTeamMostLost = listAllRankingByLeagueSeasonId.Where(p => p.NumLost ==mostLost).ToList();
                        
                        var rowMostWinTeam = sheet1.CreateRow(++rowIndex);
                        var cellMostWinTeam =new CellRangeAddress(rowIndex, rowIndex, 0, endColumnHeaderTeamStat);
                        sheet1.AddMergedRegion(cellMostWinTeam);
                        rowMostWinTeam.GetCell(0).SetCellValue("Teams have won the most matches");
                        dhTeamMostWin.ForEach(ranking =>
                        {
                            /*header row*/
                            //position, name, point, numWin, numDraw, numLost, playedMatches, difference
                            var columnIndex = -1;
                            var rowMostWin = sheet1.CreateRow(++rowIndex);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(listAllRankingByLeagueSeasonId.IndexOf(ranking));
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(listTeamInLeague.First(p => p.Id == ranking.TeamId).Name);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.Point);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumWin);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumDraw);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.PlayedMatches);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.Difference);
                        });
                        
                        var rowMostLostTeam = sheet1.CreateRow(++rowIndex);
                        var cellMostLostTeam =new CellRangeAddress(rowIndex, rowIndex, 0, endColumnHeaderTeamStat);
                        sheet1.AddMergedRegion(cellMostLostTeam);
                        rowMostLostTeam.GetCell(0).SetCellValue("Teams have won the fewest matches");
                        dhTeamMostLost.ForEach(ranking =>
                        {
                            /*header row*/
                            //position, name, point, numWin, numDraw, numLost, playedMatches, difference
                            var columnIndex = -1;
                            var rowMostWin = sheet1.CreateRow(++rowIndex);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(listAllRankingByLeagueSeasonId.IndexOf(ranking));
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(listTeamInLeague.First(p => p.Id == ranking.TeamId).Name);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.Point);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumWin);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumDraw);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.PlayedMatches);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.Difference);
                        });
                        
                        
                        //ranking statistic
                        ++rowIndex;
                        /*header row*/
                        listAllRankingByLeagueSeasonId.ForEach(ranking =>
                        {
                            /*header row*/
                            //position, name, point, numWin, numDraw, numLost, playedMatches, difference
                            var columnIndex = -1;
                            var rowMostWin = sheet1.CreateRow(++rowIndex);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(listAllRankingByLeagueSeasonId.IndexOf(ranking));
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(listTeamInLeague.First(p => p.Id == ranking.TeamId).Name);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.Point);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumWin);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumDraw);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.PlayedMatches);
                            rowMostWin.CreateCell(++columnIndex).SetCellValue(ranking.Difference);
                        });
                        
                        workbook.Write(fileStream);
                        MessageBox.Show("Your file has been send to email and exported to file: " + fileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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