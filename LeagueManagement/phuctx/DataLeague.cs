using System;
using System.Data;

namespace LeagueManagement.phuctx
{
    class DataLeague
    {
        Connection dataConn = new Connection();
        public DataTable ShowLeague()
        {
            String sql = "Select * from dh_league";
            DataTable dt = new DataTable();
            dt = dataConn.GetTable(sql);
            return dt;
        }
        public void InsertLeague(String Name, int Nation_id, int Num_matches, int Num_team)
        {
            String sql = "Insert Into dh_league Values(N'" + Name + "', '" + Nation_id + "', '" + Num_matches + "', '" + Num_team + "')";
            dataConn.ExecuteNonQuery(sql);
        }
        public void UpdateLeague(int Id, String Name, int Nation_id, int Num_matches, int Num_team)
        {
            String sql = "Update dh_league Set name=N'" + Name + "', nation_id='" + Nation_id + "', num_matches='" + Num_matches + "', num_team='" + Num_team + "' Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
        public void DeleteLeague(int Id)
        {
            String sql = "Delete dh_league Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
    }
}
