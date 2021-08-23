// @author duyenthai

using System.Data.Linq.Mapping;

namespace LeagueManagement.thaind.entity
{
    [Table(Name = "dh_league_ranking")]
    public class DhLeagueRanking
    {
        private int id;
        private int leagueId;
        private int seasonId;
        private int teamId;
        private int point = 0;
        private int numWin = 0;
        private int numDraw = 0;
        private int numLost = 0;
        private int playedMatches = 0;
        private int difference = 0;
        private int numGoalScored = 0;
        private int numGoalReceived = 0;

        public DhLeagueRanking()
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

        [Column(Name = "team_id")]
        public int TeamId
        {
            get => teamId;
            set => teamId = value;
        }

        [Column(Name = "point")]
        public int Point
        {
            get => point;
            set => point = value;
        }

        [Column(Name = "num_win")]
        public int NumWin
        {
            get => numWin;
            set => numWin = value;
        }

        [Column(Name = "num_draw")]
        public int NumDraw
        {
            get => numDraw;
            set => numDraw = value;
        }

        [Column(Name = "num_lost")] 
        public int NumLost
        {
            get => numLost;
            set => numLost = value;
        }

        [Column(Name = "played_matches")] 
        public int PlayedMatches
        {
            get => playedMatches;
            set => playedMatches = value;
        }

        [Column(Name = "difference")] 
        public int Difference
        {
            get => difference;
            set => difference = value;
        }

        [Column(Name = "num_goal_scored")]
        public int NumGoalScored
        {
            get => numGoalScored;
            set => numGoalScored = value;
        }

        [Column(Name = "num_goal_received")]
        public int NumGoalReceived
        {
            get => numGoalReceived;
            set => numGoalReceived = value;
        }
    }
}