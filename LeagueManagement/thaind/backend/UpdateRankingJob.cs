namespace LeagueManagement.thaind.backend
{
    public class UpdateRankingJob : BaseJob
    {
        //This param stands for a "match_id" + _ + match_id 
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