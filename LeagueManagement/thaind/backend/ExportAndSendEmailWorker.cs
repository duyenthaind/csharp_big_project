// @author duyenthai

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using LeagueManagement.thaind.entity;
using log4net;
using NPOI.SS.UserModel;
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
                    listAllRankingByLeagueSeasonId = listAllRankingByLeagueSeasonId.OrderByDescending(p => p.Point)
                        .ThenBy(p => p.Difference).ThenBy(p => p.NumWin)
                        .ThenBy(p => p.TeamId).ToList();
                    var listFinishedMatches =
                        dhMatchDAO.GetListFinishedMatchesByLeagueSeasonId(workJob.LeagueId, workJob.SeasonId);
                    var dhLeague = databaseContext.DhLeagues.FirstOrDefault(p => p.Id == workJob.LeagueId);
                    var dhNation = new DhNation();
                    var dhSeason = new DhSeason();
                    var listTeamInLeague = new List<DhTeam>();
                    if (dhLeague != null)
                    {
                        dhNation = databaseContext.DhNations.FirstOrDefault(p => p.Id == dhLeague.NationId);
                        dhSeason = databaseContext.DhSeasons.FirstOrDefault(p => p.Id == workJob.SeasonId);
                        listTeamInLeague = databaseContext.DhTeams.Where(p => p.NationId == dhLeague.NationId).ToList();
                    }

                    if (dhLeague == null || dhNation == null || dhSeason == null)
                    {
                        return;
                    }

                    var fileName = Config.EXPORT_FILE_DIR + "ExportFile_" + DateTime.Now.ToString("dd-MM-yyyy") +
                                   "_" + Guid.NewGuid() + ".xlsx";
                    using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        var workbook = new XSSFWorkbook();
                        var sheet1 = workbook.CreateSheet("League statistic");

                        //header
                        var rowIndex = -1;
                        var rowHeader = sheet1.CreateRow(++rowIndex);
                        rowHeader.CreateCell(0);
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
                        rowMatches.CreateCell(0);
                        sheet1.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 3));
                        rowMatches.GetCell(0).SetCellValue("Number of finished matches: ");
                        rowMatches.CreateCell(4);
                        // cellMatches2.SetCellValue(listFinishedMatches.Count);\
                        rowMatches.GetCell(4).SetCellValue(listFinishedMatches.Count);
                        ++rowIndex;

                        //all goals
                        var rowGoalMatches = sheet1.CreateRow(++rowIndex);
                        rowGoalMatches.CreateCell(0);
                        sheet1.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 3));
                        rowGoalMatches.GetCell(0).SetCellValue("Number of goals: ");
                        rowGoalMatches.CreateCell(4);

                        var numGoals = 0;
                        listAllRankingByLeagueSeasonId.ForEach(ranking => numGoals += ranking.NumGoalScored);
                        rowGoalMatches.GetCell(4).SetCellValue(numGoals);
                        ++rowIndex;

                        //all goals
                        var rowGoalPerMatches = sheet1.CreateRow(++rowIndex);
                        rowGoalPerMatches.CreateCell(0);
                        sheet1.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 3));
                        rowGoalPerMatches.GetCell(0).SetCellValue("Goals per match: ");
                        rowGoalPerMatches.CreateCell(4);
                        float goalPerMatchValue = 0;
                        if (listFinishedMatches.Count > 0)
                        {
                            goalPerMatchValue = (float) numGoals / listFinishedMatches.Count;
                        }

                        rowGoalPerMatches.GetCell(4).SetCellValue($"{goalPerMatchValue:F2}");
                        ++rowIndex;

                        //team statistic
                        const int endColumnHeaderTeamStat = 3;
                        var mostWin = 0;
                        var mostLost = 0;
                        if (listAllRankingByLeagueSeasonId.Any())
                        {
                            mostWin = listAllRankingByLeagueSeasonId.Max(p => p.NumWin);
                            mostLost = listAllRankingByLeagueSeasonId.Max(p => p.NumLost);
                        }
                        var dhTeamMostWin = listAllRankingByLeagueSeasonId.Where(p => p.NumWin == mostWin).ToList();
                        var dhTeamMostLost = listAllRankingByLeagueSeasonId.Where(p => p.NumLost == mostLost).ToList();

                        var rowMostWinTeam = sheet1.CreateRow(++rowIndex);
                        rowMostWinTeam.CreateCell(0);
                        sheet1.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, endColumnHeaderTeamStat));
                        rowMostWinTeam.GetCell(0).SetCellValue("Teams have won the most matches");

                        sheet1.CreateRow(++rowIndex);
                        CreateHeaderRankingRow(sheet1, rowIndex);
                        dhTeamMostWin.ForEach(ranking =>
                        {
                            /*header row*/
                            //position, name, point, numWin, numDraw, numLost, playedMatches, goalScored, goalReceived, difference
                            var columnIndex = -1;
                            sheet1.CreateRow(++rowIndex);
                            var position = listAllRankingByLeagueSeasonId.IndexOf(ranking);
                            var dhTeamCurrent = listTeamInLeague.FirstOrDefault(p => p.Id == ranking.TeamId);
                            var teamName = dhTeamCurrent == null ? "" : dhTeamCurrent.Name;
                            /*localRow.CreateCell(++columnIndex).SetCellValue(listAllRankingByLeagueSeasonId.IndexOf(ranking));
                            localRow.CreateCell(++columnIndex).SetCellValue(listTeamInLeague.FirstOrDefault(p => p.Id == ranking.TeamId).Name);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.Point);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumWin);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumDraw);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.PlayedMatches);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumGoalScored);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumGoalReceived);
                            localRow.CreateCell(++columnIndex).SetCellValue(ranking.Difference);*/
                            CreateDataRow(sheet1, rowIndex, columnIndex, teamName, position, ranking);
                        });

                        ++rowIndex;
                        var rowMostLostTeam = sheet1.CreateRow(++rowIndex);
                        rowMostLostTeam.CreateCell(0);
                        sheet1.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, endColumnHeaderTeamStat));
                        rowMostLostTeam.GetCell(0).SetCellValue("Teams have won the fewest matches");

                        sheet1.CreateRow(++rowIndex);
                        CreateHeaderRankingRow(sheet1, rowIndex);
                        dhTeamMostLost.ForEach(ranking =>
                        {
                            /*header row*/
                            //position, name, point, numWin, numDraw, numLost, playedMatches, goalScored, goalReceived ,difference
                            var columnIndex = -1;
                            sheet1.CreateRow(++rowIndex);
                            var position = listAllRankingByLeagueSeasonId.IndexOf(ranking);
                            var dhTeamCurrent = listTeamInLeague.FirstOrDefault(p => p.Id == ranking.TeamId); 
                            var teamName = dhTeamCurrent == null ? "" : dhTeamCurrent.Name;
                            CreateDataRow(sheet1, rowIndex, columnIndex, teamName, position, ranking);
                        });


                        //ranking statistic
                        ++rowIndex;
                        /*header row*/
                        var rowAllRanking = sheet1.CreateRow(++rowIndex);
                        rowAllRanking.CreateCell(0);
                        sheet1.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, endColumnHeaderTeamStat));
                        rowAllRanking.GetCell(0).SetCellValue("All ranking");

                        sheet1.CreateRow(++rowIndex);
                        CreateHeaderRankingRow(sheet1, rowIndex);
                        listAllRankingByLeagueSeasonId.ForEach(ranking =>
                        {
                            /*header row*/
                            //position, name, point, numWin, numDraw, numLost, playedMatches, goalScored, goalReceived, difference
                            var columnIndex = -1;
                            sheet1.CreateRow(++rowIndex);
                            var position = listAllRankingByLeagueSeasonId.IndexOf(ranking);
                            var dhTeamCurrent = listTeamInLeague.FirstOrDefault(p => p.Id == ranking.TeamId); 
                            var teamName = dhTeamCurrent == null ? "" : dhTeamCurrent.Name;
                            CreateDataRow(sheet1, rowIndex, columnIndex, teamName, position, ranking);
                        });

                        workbook.Write(fileStream);

                        if (!string.IsNullOrEmpty(workJob.Email))
                        {
                            try
                            {
                                var dhActiveSmtpMail =
                                    databaseContext.DhSmtpMails.FirstOrDefault(p => p.Active && (p.Host != null));
                                if (dhActiveSmtpMail == null)
                                {
                                    MessageBox.Show("No mail configured for system, cannot send mail", "Warning",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    var mailWorker = new MailWorker("MailWorker", workJob.Email, @fileStream.Name);
                                    mailWorker.Credential = dhActiveSmtpMail;
                                    mailWorker.Start();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Log.Error("Error, ", ex);
                            }
                        }

                        var options = MessageBox.Show(
                            $"Your file has been exported to file: {fileStream.Name}, would you like to open it? ",
                            "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (options == DialogResult.Yes)
                        {
                            try
                            {
                                var fileInfo = new FileInfo(fileStream.Name);
                                if (fileInfo.Exists)
                                {
                                    System.Diagnostics.Process.Start(fileStream.Name);
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error("Error, ", ex);
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error ", ex);
            }
        }

        private IRow CreateHeaderRankingRow(ISheet sheet, int rowIndex)
        {
            var result = sheet.CreateRow(rowIndex);
            var columnIndex = -1;
            string[] columnHeaders = new[]
            {
                "Position", "Name", "Point", "Win", "Draw", "Lost", "Played matches", "Goal scored", "Goal received",
                "Differences"
            };
            columnHeaders.ToList().ForEach(header => { result.CreateCell(++columnIndex).SetCellValue(header); });
            return result;
        }

        private IRow CreateDataRow(ISheet sheet, int rowIndex, int columnIndex, string teamName, int position,
            DhLeagueRanking ranking)
        {
            var localRow = sheet.CreateRow(rowIndex);
            localRow.CreateCell(++columnIndex).SetCellValue(position + 1);
            localRow.CreateCell(++columnIndex).SetCellValue(teamName);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.Point);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumWin);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumDraw);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumLost);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.PlayedMatches);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumGoalScored);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.NumGoalReceived);
            localRow.CreateCell(++columnIndex).SetCellValue(ranking.Difference);
            return localRow;
        }

        private void SendMail(string email, FileStream fileStream, string fileName)
        {
            try
            {
                var smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("thaindtest@gmail.com", ">3waifu@@@@@3333");
                smtpClient.EnableSsl = true;

                var mail = new MailMessage();
                mail.From = new MailAddress("noreply@xmail.com");
                mail.To.Add(email);
                mail.Attachments.Add(new Attachment(fileStream, fileName, "text/excel"));
                mail.Body = "Export excel file";
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Log.Error("Error send mail, ", ex);
                MessageBox.Show(ex.Message, "Error send mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}