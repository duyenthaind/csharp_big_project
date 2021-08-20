using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LeagueManagement
{
    class DataAtheletes
    {
        Connection dataConn = new Connection();
        public DataTable ShowKS()
        {
            String sql = "Select * from dh_atheletes";
            DataTable dt = new DataTable();
            dt = dataConn.GetTable(sql);
            return dt;
        }
        public void InsertAtheletes(int Id, String Name, int Age, Boolean Gender, int Nation_id, int Team_id)
        {
            String sql = "Insert Into dh_team Values('" + Id + "', N'" + Name + "', N'" + Host + "', '" + Nation_id + "')";
            dataConn.ExecuteNonQuery(sql);
        }
        public void UpdateAtheletes(String Id, String Name, String Host, String Nation_id)
        {
            String sql = "Update dh_team Set name=N'" + Name + "', host='" + Host + "', nation_id='" + Nation_id + "' Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
        public void DeleteAtheletes(String Id)
        {
            String sql = "Delete dh_team Where id='" + Id + "'";
            dataConn.ExecuteNonQuery(sql);
        }
    }
}
