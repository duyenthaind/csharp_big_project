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
        public static DhLeagueRanking CreateNewRankingEntityFromMatch(DhMatch dbEntity)
        {
            var dhNewLeagueRanking = new DhLeagueRanking();
            dhNewLeagueRanking.LeagueId = dbEntity.LeagueId;
            dhNewLeagueRanking.SeasonId = dbEntity.SeasonId;
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

        public static DataTable GetTemporaryRankingByLeagueId(int leagueId)
        {
            DataTable result = null;
            try
            {
                var dhMatchDao = new DhMatchDAO();
                var dhLeagueRankingDao = new DhLeagueRankingDAO();
                var dhMatches = dhMatchDao.GetListMatchesByLeagueId(leagueId);
                var dhLeagueRankings = dhLeagueRankingDao.GetListAllRankingByLeagueId(leagueId);

                var unFinishedMatches = dhMatches.Where(p => p.EndTime > DateTime.Now.Millisecond).ToList();
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

                dhLeagueRankings.Sort((first, second) => first.Point.CompareTo(second.Point));
                dhLeagueRankings.Reverse();

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