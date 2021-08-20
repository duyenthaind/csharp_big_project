using System;
using System.Data;

namespace LeagueManagement.phuctx
{
    class DataTeam
    {
        Connection dataConn = new Connection();
        public DataTable ShowTeam()
        {
            String sql = "Select * from dh_team";
            DataTable dt = new DataTable();
            dt = dataConn.GetTable(sql);
            return dt;
        }
        public void InsertTeam(String Name, String Host, int Nation_id, int Num_atheletes)
        {
            String sql = "Insert Into dh_team Values(N'" + Name + "', N'" + Host + "', '" + Nation_id + "', '" + Num_atheletes + "')";
            dataConn.ExecuteNonQuery(sql);
        }
        public void UpdateTeam(int Id, String Name, String Host, int Nation_id, int Num_atheletes)
        {
            String sql = "Update dh_team Set name=N'" + Name + "', host='" + Host + "', nation_id='" + Nation_id + "', num_atheletes='" + Num_atheletes + "' Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
        public void DeleteTeam(int Id)
        {
            String sql = "Delete dh_team Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
    }
}
