using System;
using System.Data;

namespace LeagueManagement.phuctx
{
    class DataAtheletes
    {
        Connection dataConn = new Connection();
        public DataTable ShowAtheletes()
        {
            String sql = "Select * from dh_atheletes";
            DataTable dt = new DataTable();
            dt = dataConn.GetTable(sql);
            return dt;
        }
        public void InsertAtheletes(String Name, int Age, Boolean Gender, int Nation_id, int Team_id)
        {
            String sql = "Insert Into dh_atheletes Values(N'" + Name + "', '" + Age + "', '" + Gender + "', '" + Nation_id + "', '" + Team_id + "')";
            dataConn.ExecuteNonQuery(sql);
        }
        public void UpdateAtheletes(int Id, String Name, int Age, Boolean Gender, int Nation_id, int Team_id)
        {
            String sql = "Update dh_atheletes Set name=N'" + Name + "', age='" + Age + "', gender='" + Gender + "', nation_id='" + Nation_id + "', team_id='" + Team_id + "' Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
        public void DeleteAtheletes(int Id)
        {
            String sql = "Delete dh_atheletes Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
    }
}
