// @author duyenthai

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LeagueManagement.thaind.dao;
using LeagueManagement.thaind.entity;
using log4net;
using Newtonsoft.Json;

namespace LeagueManagement.thaind.common
{
    public class DbUtil
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DbUtil));

        public static DhLeagueRanking CreateNewRankingEntityFromMatch(DhMatch dbEntity, bool isHost)
        {
            var dhNewLeagueRanking = new DhLeagueRanking();
            dhNewLeagueRanking.LeagueId = dbEntity.LeagueId;
            dhNewLeagueRanking.SeasonId = dbEntity.SeasonId;
            if (isHost)
            {
                dhNewLeagueRanking.TeamId = dbEntity.TeamHostId;
            }
            else
            {
                dhNewLeagueRanking.TeamId = dbEntity.TeamAwayId;
            }

            return dhNewLeagueRanking;
        }

        public static DhLeagueRanking UpdateRankingEntityWithMatch(DhLeagueRanking dhLeagueRanking, DhMatch dhMatch)
        {
            var isHost = dhLeagueRanking.TeamId == dhMatch.TeamHostId;
            var positiveGoal = dhMatch.TeamHostGoal - dhMatch.TeamAwayGoal;
            var gainPoint = 0;
            var gainWin = 0;
            var gainDraw = 0;
            var gainLost = 0;
            var gainPlayedMatches = 1;
            var gainDifference = 0;
            var gainGoalScored = isHost ? dhMatch.TeamHostGoal : dhMatch.TeamAwayGoal;
            var gainGoalReceived = isHost ? dhMatch.TeamAwayGoal : dhMatch.TeamHostGoal;
            if (positiveGoal > 0)
            {
                if (isHost)
                {
                    gainPoint = 3;
                    gainWin = 1;
                    gainDifference = positiveGoal;
                }
                else
                {
                    gainLost = 1;
                    gainDifference = positiveGoal * (-1);
                }
            }
            else if (positiveGoal == 0)
            {
                gainPoint = 1;
                gainDraw = 1;
            }
            else
            {
                if (isHost)
                {
                    gainLost = 1;
                    gainDifference = positiveGoal * (-1);
                }
                else
                {
                    gainPoint = 3;
                    gainWin = 1;
                    gainDifference = positiveGoal;
                }
            }

            dhLeagueRanking.Point += gainPoint;
            dhLeagueRanking.NumWin += gainWin;
            dhLeagueRanking.NumDraw += gainDraw;
            dhLeagueRanking.NumLost += gainLost;
            dhLeagueRanking.PlayedMatches += gainPlayedMatches;
            dhLeagueRanking.Difference += gainDifference;
            dhLeagueRanking.NumGoalScored += gainGoalScored;
            dhLeagueRanking.NumGoalReceived += gainGoalReceived;
            return dhLeagueRanking;
        }

        public static DataTable GetTemporaryRankingByLeagueSeasonId(int leagueId, int seasonId)
        {
            DataTable result = null;
            try
            {
                var dhMatchDao = new DhMatchDAO();
                var dhLeagueRankingDao = new DhLeagueRankingDAO();
                var dhMatches = dhMatchDao.GetListStartedMatchesByLeagueSeasonId(leagueId, seasonId);
                var dhLeagueRankings = dhLeagueRankingDao.GetListAllRankingByLeagueSeasonId(leagueId, seasonId);
                var dhTeams = GetAllTeams();

                var unFinishedMatches = dhMatches.Where(p => p.EndTime > DateTimeOffset.Now.ToUnixTimeMilliseconds())
                    .ToList();
                unFinishedMatches.ForEach((match =>
                {
                    var dhRankingHost = dhLeagueRankings.First(p => p.TeamId == match.TeamHostId);
                    var dhRankingAway = dhLeagueRankings.First(p => p.TeamId == match.TeamAwayId);

                    dhLeagueRankings.Remove(dhRankingHost);
                    dhLeagueRankings.Remove(dhRankingAway);

                    dhRankingHost = UpdateRankingEntityWithMatch(dhRankingHost, match);
                    dhRankingAway = UpdateRankingEntityWithMatch(dhRankingAway, match);

                    dhLeagueRankings.Add(dhRankingHost);
                    dhLeagueRankings.Add(dhRankingAway);
                }));

                dhLeagueRankings = dhLeagueRankings.OrderByDescending(p => p.Point).ThenBy(p => p.Difference)
                    .ThenBy(p => p.NumWin)
                    .ThenBy(p => p.TeamId).ToList();

                result = new DataTable();

                var header = ColumnDataTableRankingHeader();
                foreach (var entry in header)
                {
                    result.Columns.Add(entry.Key, entry.Value);
                }

                var positionCount = -1;
                dhLeagueRankings.ForEach(ranking =>
                {
                    object[] values = new object[result.Columns.Count];
                    var dhTeam = dhTeams.First(p => p.Id == ranking.TeamId);
                    values[0] = ++positionCount;
                    values[1] = dhTeam != null ? dhTeam.Name : "";
                    values[2] = ranking.Point;
                    values[3] = ranking.NumWin;
                    values[4] = ranking.NumDraw;
                    values[5] = ranking.NumLost;
                    values[6] = ranking.PlayedMatches;
                    values[7] = ranking.NumGoalScored;
                    values[8] = ranking.NumGoalReceived;
                    values[9] = ranking.Difference;
                    result.Rows.Add(values);
                });
                /*var json = JsonConvert.SerializeObject(dhLeagueRankings);
                result = JsonConvert.DeserializeObject<DataTable>(json);*/
            }
            catch (Exception ex)
            {
                Log.Error("Error get temporary ranking, trace: ", ex);
            }

            return result;
        }

        private static Dictionary<string, Type> ColumnDataTableRankingHeader()
        {
            var result = new Dictionary<string, Type>();
            result.Add("rowNum", typeof(int));
            result.Add("name", typeof(string));
            result.Add("point", typeof(int));
            result.Add("num_win", typeof(int));
            result.Add("num_draw", typeof(int));
            result.Add("num_lost", typeof(int));
            result.Add("played_matches", typeof(int));
            result.Add("num_goal_scored", typeof(int));
            result.Add("num_goal_received", typeof(int));
            result.Add("difference", typeof(int));
            return result;
        }

        public static DhLeague GetLeagueById(int id)
        {
            DhLeague result = null;
            try
            {
                var databaseContext = DatabaseObject.GetDatabaseContext();
                result = databaseContext.DhLeagues.First(p => p.Id == id);
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }

            return result;
        }

        public static DhSeason GetSeasonById(int id)
        {
            DhSeason result = null;
            try
            {
                var databaseContext = DatabaseObject.GetDatabaseContext();
                result = databaseContext.DhSeasons.First(p => p.Id == id);
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }

            return result;
        }

        public static DhNation GetNationById(int id)
        {
            DhNation result = null;
            try
            {
                var databaseContext = DatabaseObject.GetDatabaseContext();
                result = databaseContext.DhNations.First(p => p.Id == id);
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }

            return result;
        }

        public static List<DhTeam> GetAllTeams()
        {
            var result = new List<DhTeam>();
            try
            {
                var databaseContext = DatabaseObject.GetDatabaseContext();
                result = databaseContext.DhTeams.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }
            return result;
        }
    }
}