namespace LeagueManagement.thaind.backend
{
    public class UpdateRankingJob : BaseJob
    {
        //This param stands for a "match_id" + _ + match_id 
        private int id;
        private long timeStart;

        public UpdateRankingJob(int id, long timeStart)
        {
            this.id = id;
            this.timeStart = timeStart;
        }

        public int Id
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