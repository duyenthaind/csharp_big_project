// @author duyenthai

namespace LeagueManagement.thaind.backend
{
    public class HardResetRankingJob : BaseJob
    {
        //This param stands for league_id
        private int id;

        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}