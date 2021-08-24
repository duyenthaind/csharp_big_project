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
    class DAO_BangXepHang
    {
        DBConnection_sonnx dataConn = new DBConnection_sonnx();


        public void ShowMuaGiai(ComboBox cbbTenGiai, ComboBox cbbMuaGiai)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sqlTenGiai = "SELECT dh_league.id, name FROM dh_league";
                    String sqlMuaGiai = "SELECT dh_season.id, name FROM dh_season";

                    //ComboboxTenGiai
                    cbbTenGiai.DataSource = dataConn.GetTable(sqlTenGiai);
                    cbbTenGiai.DisplayMember = "name";
                    cbbTenGiai.ValueMember = "id";
                    cbbTenGiai.SelectedItem = null;
                    //ComboboxMuaGiai
                    cbbMuaGiai.DataSource = dataConn.GetTable(sqlMuaGiai);
                    cbbMuaGiai.DisplayMember = "name";
                    cbbMuaGiai.ValueMember = "id";
                    cbbMuaGiai.SelectedItem = null;

                }
                catch (Exception )
                {
                    MessageBox.Show("Lỗi tải combobox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void ShowData(int league_id, int season_id, DataGridView dgvBXH)
        {
            using( SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sql = "SELECT t.name, point, num_win, num_draw, num_lost, played_matches, difference, num_goal_scored, num_goal_received " +
                        "  FROM dh_league_ranking r inner join dh_team t on r.team_id=t.id " +
                        " WHERE league_id=@league_id and season_id=@season_id "+
                        " ORDER BY point DESC, difference DESC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@league_id", league_id);
                    cmd.Parameters.AddWithValue("@season_id", season_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    dgvBXH.DataSource = table;
                }
                catch (Exception )
                {
                    MessageBox.Show("Lỗi tải dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
