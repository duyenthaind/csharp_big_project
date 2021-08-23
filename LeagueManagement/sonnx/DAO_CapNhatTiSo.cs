﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LeagueManagement.sonnx
{
    class DAO_CapNhatTiSo
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
                    String sqlTenGiai = "select dh_league.id, name from dh_league";
                    String sqlMuaGiai = "select dh_season.id, name from dh_season";

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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ShowData(DataGridView dgvTranDau, int league_id, int season_id)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sqlXepLich = "SELECT t1.name as host_name, t2.name as away_name, m.team_host_goal as Host_goal, m.team_away_goal as Away_goal, " +
                                        " dateadd(SECOND, CONVERT(bigint, m.start_time / 1000), '1970-01-01') AT TIME ZONE 'UTC' as startTime," +
                                        " dateadd(SECOND, CONVERT(bigint, m.end_time / 1000), '1970-01-01') AT TIME ZONE 'UTC' as endTime, is_final_result " +
                                        " FROM dh_match m join dh_team t1 on m.team_host_id = t1.id join dh_team t2 on m.team_away_id = t2.id" +
                                        " join dh_league l on m.league_id = l.id join dh_season s on m.season_id = s.id" +
                                        " WHERE m.league_id = @league_id and m.season_id = @season_id";
                    SqlCommand cmd = new SqlCommand(sqlXepLich, conn);
                    cmd.Parameters.AddWithValue("@league_id", league_id);
                    cmd.Parameters.AddWithValue("@season_id", season_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    dgvTranDau.DataSource = table;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Update_TiSo(int index, DataGridView dgv_TranDau, TextBox txtHost_goal, TextBox txtAway_goal, int league_id, int season_id)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    String sql = "UPDATE dh_match SET team_host_goal=@host_goal, team_away_goal=@away_goal WHERE id=@mt";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@host_goal", int.Parse(txtHost_goal.Text));
                    cmd.Parameters.AddWithValue("@away_goal", int.Parse(txtAway_goal.Text));
                    cmd.Parameters.AddWithValue("@mt", int.Parse(dgv_TranDau.Rows[index].Cells[0].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    ShowData(dgv_TranDau, league_id, season_id);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi cập nhật tỉ số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}