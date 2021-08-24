using System;
using System.Data;
using System.Data.SqlClient;

namespace LeagueManagement.phuctx
{
    class Connection
    {
        public SqlConnection getConnect()
        {
            String connString = @"Server=172.30.0.1;Database=QLGD;User=sa;Password=thaind123!@#;MultipleActiveResultSets=true;";
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
