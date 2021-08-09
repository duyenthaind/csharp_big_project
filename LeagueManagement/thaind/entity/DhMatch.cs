// @author duyenthai

namespace LeagueManagement.thaind.entity
{
    public class DhMatch
    {
        private int id;
        private int leagueId;
        private int seasonId;
        private int teamHostId;
        private int teamAwayId;
        private int teamHostGoal;
        private int teamAwayGoal;
        private long startTime;
        private long endTime;

        public DhMatch()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
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

        public int TeamHostId
        {
            get => teamHostId;
            set => teamHostId = value;
        }

        public int TeamAwayId
        {
            get => teamAwayId;
            set => teamAwayId = value;
        }

        public int TeamHostGoal
        {
            get => teamHostGoal;
            set => teamHostGoal = value;
        }

        public int TeamAwayGoal
        {
            get => teamAwayGoal;
            set => teamAwayGoal = value;
        }

        public long StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        public long EndTime
        {
            get => endTime;
            set => endTime = value;
        }
    }
}