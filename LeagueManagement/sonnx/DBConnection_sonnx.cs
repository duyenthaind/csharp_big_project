using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LeagueManagement.sonnx
{
    class DBConnection_sonnx
    {
        public SqlConnection getConnect()
        {
            SqlConnection conn = null;
            try
            {
                String connString = @"Server=172.30.0.1;Database=QLGD;User=sa;Password=thaind123!@#;MultipleActiveResultSets=true;";
                conn = new SqlConnection(connString);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }
        public DataTable GetTable(String sql)
        {
            DataTable dt = null;
            try
            {
                SqlConnection conn = getConnect();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public void ExecuteNonQuery(String sql)
        {
            try
            {
                SqlConnection conn = getConnect();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
