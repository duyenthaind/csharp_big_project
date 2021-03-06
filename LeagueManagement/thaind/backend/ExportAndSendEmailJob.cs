// @author duyenthai

namespace LeagueManagement.thaind.backend
{
    public class ExportAndSendEmailJob : BaseJob
    {
        private int leagueId;

        private int seasonId;

        private string email;

        public ExportAndSendEmailJob(int leagueId, int seasonId)
        {
            this.leagueId = leagueId;
            this.seasonId = seasonId;
        }

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

        public string Email
        {
            get => email;
            set => email = value;
        }
    }
}