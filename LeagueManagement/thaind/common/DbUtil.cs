// @author duyenthai

using System;
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
            return dhLeagueRanking;
        }

        public static DataTable GetTemporaryRankingByLeagueSeasonId(int leagueId, int seasonId)
        {
            DataTable result = null;
            try
            {
                var dhMatchDao = new DhMatchDAO();
                var dhLeagueRankingDao = new DhLeagueRankingDAO();
                var dhMatches = dhMatchDao.GetListMatchesByLeagueSeasonId(leagueId, seasonId);
                var dhLeagueRankings = dhLeagueRankingDao.GetListAllRankingByLeagueSeasonId(leagueId,seasonId);

                var unFinishedMatches = dhMatches.Where(p => p.EndTime > DateTimeOffset.Now.ToUnixTimeMilliseconds()).ToList();
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

                dhLeagueRankings = dhLeagueRankings.OrderByDescending(p => p.Point).ThenBy(p => p.Difference).ThenBy(p => p.NumWin)
                    .ThenBy(p => p.TeamId).ToList();

                var json = JsonConvert.SerializeObject(dhLeagueRankings);
                result = JsonConvert.DeserializeObject<DataTable>(json);
            }
            catch (Exception ex)
            {
                Log.Error("Error get temporary ranking, trace: ", ex);
            }

            return result;
        }
    }
}