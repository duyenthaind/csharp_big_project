// @author duyenthai

using LeagueManagement.thaind.entity;

namespace LeagueManagement.thaind.common
{
    public class DbUtil
    {
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
    }
}