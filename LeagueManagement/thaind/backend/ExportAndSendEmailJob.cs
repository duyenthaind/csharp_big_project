// @author duyenthai

namespace LeagueManagement.thaind.backend
{
    public class ExportAndSendEmailJob : BaseJob
    {
        private int leagueId;

        public int LeagueId
        {
            get => leagueId;
            set => leagueId = value;
        }
    }
}