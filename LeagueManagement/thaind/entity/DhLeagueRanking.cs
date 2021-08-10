// @author duyenthai

namespace LeagueManagement.thaind.entity
{
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

        public DhLeagueRanking()
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

        public int TeamId
        {
            get => teamId;
            set => teamId = value;
        }

        public int Point
        {
            get => point;
            set => point = value;
        }

        public int NumWin
        {
            get => numWin;
            set => numWin = value;
        }

        public int NumDraw
        {
            get => numDraw;
            set => numDraw = value;
        }

        public int NumLost
        {
            get => numLost;
            set => numLost = value;
        }

        public int PlayedMatches
        {
            get => playedMatches;
            set => playedMatches = value;
        }

        public int Difference
        {
            get => difference;
            set => difference = value;
        }
    }
}