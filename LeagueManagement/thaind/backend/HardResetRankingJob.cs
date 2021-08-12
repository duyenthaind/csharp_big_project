// @author duyenthai

namespace LeagueManagement.thaind.backend
{
    public class HardResetRankingJob : BaseJob
    {
        //This param stands for league_id
        private int leagueId;

        public int LeagueId
        {
            get => leagueId;
            set => leagueId = value;
        }
    }
}