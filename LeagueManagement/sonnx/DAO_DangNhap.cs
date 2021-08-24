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
    class DAO_DangNhap
    {
        DBConnection_sonnx dataConn = new DBConnection_sonnx();
        public void checkDangNhap(TextBox txtTaiKhoan, TextBox txtMatKhau)
        {
            using(SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sql = "SELECT * FROM dh_account WHERE username=@tk and password=@mk";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tk", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text);
                    SqlDataReader dt = cmd.ExecuteReader();
                    if (dt.Read() == true)
                    {
                        DangNhap.GetMainForm().Hide();
                        MainForm main = new MainForm();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
