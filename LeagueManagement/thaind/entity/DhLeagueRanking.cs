﻿// @author duyenthai

namespace LeagueManagement.thaind.entity
{
    public class DhLeagueRanking
    {
        private int id;
        private int leagueId;
        private int seasonId;
        private int teamId;
        private int point;
        private int numWin;
        private int numDraw;
        private int numLost;
        private int playedMatches;
        private int difference;

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