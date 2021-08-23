// @author duyenthai

using System;
using System.Data;
using System.Windows.Forms;
using LeagueManagement.thaind.dao;
using LeagueManagement.thaind.entity;
using log4net;

namespace LeagueManagement.thaind.common
{
    public class Statistic
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Statistic));
        
        private DataTable allLeagueRanking;
        private DataTable rankingMostWin;
        private DataTable rankingMostLost;
        private DhLeague league;
        private DhSeason season;
        private DhNation nation;
        private int playedMatches;
        private int allGoals;
        private float goalPerMatches;

        private Statistic()
        {
        }

        public static Statistic FromLeagueSeason(int leagueId, int seasonId)
        {
            var result = new Statistic();
            try
            {
                result.League = DbUtil.GetLeagueById(leagueId);
                result.Season = DbUtil.GetSeasonById(seasonId);
                if (result.league != null)
                {
                    result.Nation = DbUtil.GetNationById(result.League.NationId);
                }

                var dhLeagueRankingDao = new DhLeagueRankingDAO();
                result.AllLeagueRanking = dhLeagueRankingDao.GetDataTableAllRankingByLeagueSeasonId(leagueId, seasonId);
                result.rankingMostWin = dhLeagueRankingDao.GetDataTableMostWin(leagueId, seasonId);
                result.rankingMostLost = dhLeagueRankingDao.GetDataTableMostLost(leagueId, seasonId);

                var dhMatchDao = new DhMatchDAO();
                var finishedMatches = dhMatchDao.GetListFinishedMatchesByLeagueSeasonId(leagueId, seasonId);
                var listAllRanking = dhLeagueRankingDao.GetListAllRankingByLeagueSeasonId(leagueId, seasonId);
                result.AllGoals = 0;
                listAllRanking.ForEach(ranking => result.AllGoals += ranking.NumGoalScored);
                result.PlayedMatches = finishedMatches.Count;
                result.GoalPerMatches = result.PlayedMatches > 0 ? (float) result.AllGoals / result.PlayedMatches : 0;
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }
            return result;
        }

        public static ILog Log1 => Log;

        public DataTable AllLeagueRanking
        {
            get => allLeagueRanking;
            set => allLeagueRanking = value;
        }

        public DataTable RankingMostWin
        {
            get => rankingMostWin;
            set => rankingMostWin = value;
        }

        public DataTable RankingMostLost
        {
            get => rankingMostLost;
            set => rankingMostLost = value;
        }

        public DhLeague League
        {
            get => league;
            set => league = value;
        }

        public DhSeason Season
        {
            get => season;
            set => season = value;
        }

        public DhNation Nation
        {
            get => nation;
            set => nation = value;
        }

        public int PlayedMatches
        {
            get => playedMatches;
            set => playedMatches = value;
        }

        public int AllGoals
        {
            get => allGoals;
            set => allGoals = value;
        }

        public float GoalPerMatches
        {
            get => goalPerMatches;
            set => goalPerMatches = value;
        }
    }
}