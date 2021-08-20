using System;
using System.Data;
using System.Data.SqlClient;

namespace LeagueManagement.phuctx
{
    class Connection
    {
        public SqlConnection getConnect()
        {
            String connString = @"Data Source=DESKTOP-4H2CDN2\SQLEXPRESS01;Initial Catalog=QLGD;Integrated Security=True";
            return new SqlConnection(connString);
        }

        public DataTable GetTable(String sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = getConnect();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        public void ExecuteNonQuery(String sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
