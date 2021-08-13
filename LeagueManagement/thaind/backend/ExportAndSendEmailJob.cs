// @author duyenthai

namespace LeagueManagement.thaind.backend
{
    public class ExportAndSendEmailJob : BaseJob
    {
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
    }
}