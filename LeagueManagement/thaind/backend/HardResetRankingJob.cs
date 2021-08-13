// @author duyenthai

namespace LeagueManagement.thaind.backend
{
    public class HardResetRankingJob : BaseJob
    {
        //This param stands for league_id
        private int leagueId;

        private int seasonId;

        public int LeagueId
        {
            get => leagueId;
            set => leagueId = value;
        }

        public int SeasonId
        {
            get => seasonId;
            set => seasonId = value;
        }

        public HardResetRankingJob(int leagueId, int seasonId)
        {
            this.leagueId = leagueId;
            this.seasonId = seasonId;
        }
    }
}