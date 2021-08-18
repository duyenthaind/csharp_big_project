// @author duyenthai

using System.Windows.Forms;

namespace LeagueManagement.thaind.backend
{
    public class HardResetRankingJob : BaseJob
    {
        //This param stands for league_id
        private int leagueId;

        private int seasonId;

        private Label lblMessage;

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

        public Label LblMessage
        {
            get => lblMessage;
            set => lblMessage = value;
        }
    }
}