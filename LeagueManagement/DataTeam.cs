using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LeagueManagement
{
    class DataTeam
    {
        Connection dataConn = new Connection();
        public DataTable ShowKS()
        {
            String sql = "Select * from dh_team";
            DataTable dt = new DataTable();
            dt = dataConn.GetTable(sql);
            return dt;
        }
        public void InsertTeam(int Id, String Name, String Host, int Nation_id)
        {
            String sql = "Insert Into dh_team Values('" + Id + "', N'" + Name + "', N'" + Host + "', '" + Nation_id + "')";
            dataConn.ExecuteNonQuery(sql);
        }
        public void UpdateTeam(int Id, String Name, String Host, int Nation_id)
        {
            String sql = "Update dh_team Set name=N'" + Name + "', host='" + Host + "', nation_id='" + Nation_id + "' Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
        public void DeleteTeam(int Id)
        {
            String sql = "Delete dh_team Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
    }
}
