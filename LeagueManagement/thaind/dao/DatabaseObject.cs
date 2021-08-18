// @author duyenthai

using System;
using System.Data.Linq;
using System.Linq;
using LeagueManagement.thaind.entity;
using log4net;

namespace LeagueManagement.thaind.dao
{
    public partial class DatabaseObject : DataContext
    {
        // private static readonly ILog Log = LogManager.GetLogger(typeof(DatabaseObject));

        public DatabaseObject(string fileOrServerOrConnection) : base(fileOrServerOrConnection)
        {
        }

        public static DatabaseObject GetDatabaseContext()
        {
            return new DatabaseObject(DataContextProvider.GetConnectionString());
        }

        public Table<DhLeagueRanking> DhLeagueRankings;
        public Table<DhMatch> DhMatches;
        public Table<DhLeague> DhLeagues;
        public Table<DhNation> DhNations;
        public Table<DhSeason> DhSeasons;
        public Table<DhTeam> DhTeams;

        public static void Test()
        {
            try
            {
                DatabaseObject dbObj = GetDatabaseContext();
                var tbl = dbObj.DhLeagueRankings;
                /*Log.Info(tbl);
                Log.Info("IOKKKKKKKKKKK");*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                // Log.Error(ex, ex);
            }
        }
    }
}