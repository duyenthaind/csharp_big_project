// @author duyenthai

using System.Data.Linq.Mapping;

namespace LeagueManagement.thaind.entity
{
    [Table(Name = "dh_match")]
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
        private bool isFinalResult;

        public DhMatch()
        {
        }

        [Column(IsPrimaryKey = true, Name = "id", IsDbGenerated = true)]
        public int Id
        {
            get => id;
            set => id = value;
        }
        
        [Column(Name = "league_id")]
        public int LeagueId
        {
            get => leagueId;
            set => leagueId = value;
        }

        [Column(Name = "season_id")]
        public int SeasonId
        {
            get => seasonId;
            set => seasonId = value;
        }
        
        [Column(Name = "team_host_id")]
        public int TeamHostId
        {
            get => teamHostId;
            set => teamHostId = value;
        }

        [Column(Name = "team_away_id")]
        public int TeamAwayId
        {
            get => teamAwayId;
            set => teamAwayId = value;
        }

        [Column(Name = "team_host_goal")]
        public int TeamHostGoal
        {
            get => teamHostGoal;
            set => teamHostGoal = value;
        }

        [Column(Name = "team_away_goal")]
        public int TeamAwayGoal
        {
            get => teamAwayGoal;
            set => teamAwayGoal = value;
        }

        [Column(Name = "start_time")]
        public long StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        [Column(Name = "end_time")]
        public long EndTime
        {
            get => endTime;
            set => endTime = value;
        }

        [Column(Name = "is_final_result")]
        public bool IsFinalResult
        {
            get => isFinalResult;
            set => isFinalResult = value;
        }
    }
}