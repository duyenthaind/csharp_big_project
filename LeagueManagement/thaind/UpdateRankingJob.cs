namespace LeagueManagement.thaind
{
    public class UpdateRankingJob : BaseJob
    {
        private string id;
        private long timeStart;

        public UpdateRankingJob(string id, long timeStart)
        {
            this.id = id;
            this.timeStart = timeStart;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public long TimeStart
        {
            get => timeStart;
            set => timeStart = value;
        }
    }
}