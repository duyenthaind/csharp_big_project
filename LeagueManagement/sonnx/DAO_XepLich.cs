using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace LeagueManagement.sonnx
{
    class DAO_XepLich
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ShowDoiBong(int id_league, ComboBox cbbDoiChuNha, ComboBox cbbDoiKhach)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sqlDoiBong = "SELECT dh_team.id, dh_team.name FROM dh_team WHERE nation_id in (SELECT nation_id FROM dh_league WHERE id=@league_id)";
                    SqlCommand cmd = new SqlCommand(sqlDoiBong, conn);
                    cmd.Parameters.AddWithValue("@league_id", id_league);
                    cbbDoiChuNha.DisplayMember = "name";
                    cbbDoiChuNha.ValueMember = "id";
                    cbbDoiChuNha.SelectedItem = null;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    cbbDoiChuNha.DataSource = table;
                    //================================
                    String sqlDoiBongK = "SELECT dh_team.id, dh_team.name FROM dh_team WHERE nation_id in (SELECT nation_id FROM dh_league WHERE id=@league_id)";
                    SqlCommand cmdK = new SqlCommand(sqlDoiBongK, conn);
                    cmdK.Parameters.AddWithValue("@league_id", id_league);
                    cbbDoiKhach.DisplayMember = "name";
                    cbbDoiKhach.ValueMember = "id";
                    cbbDoiKhach.SelectedItem = null;
                    DataTable tableK = new DataTable();
                    reader.Close();
                    SqlDataReader readerK = cmd.ExecuteReader();
                    tableK.Load(readerK);
                    cbbDoiKhach.DataSource = tableK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ShowData(DataGridView dgvXepLich, int league_id, int season_id)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sqlXepLich = " SELECT m.id as STT, l.name as TenGiai, s.name as MuaGiai,  t1.name as host_name, t2.name as away_name,"+
                                        " dateadd(SECOND, CONVERT(bigint, m.start_time / 1000), '1970-01-01') AT TIME ZONE 'UTC' as startTime," +
                                        " dateadd(SECOND, CONVERT(bigint, m.end_time / 1000), '1970-01-01') AT TIME ZONE 'UTC' as endTime" +
                                        " FROM dh_match m JOIN dh_team t1 on m.team_host_id = t1.id JOIN dh_team t2 on m.team_away_id = t2.id"+
                                        " JOIN dh_league l on m.league_id = l.id join dh_season s on m.season_id = s.id"+
                                        " WHERE m.league_id = @league_id and m.season_id = @season_id";
                    SqlCommand cmd = new SqlCommand(sqlXepLich, conn);
                    cmd.Parameters.AddWithValue("@league_id", league_id);
                    cmd.Parameters.AddWithValue("@season_id", season_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    dgvXepLich.DataSource = table;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public void time_season(int season_id, out long bd_MuaGiai, out long kt_MuaGiai)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                String sql = "SELECT start_time, end_time FROM dh_season WHERE id=@season_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@season_id", season_id);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> lst = new List<string>();
                while (reader.Read())
                {
                    lst.Add(reader["start_time"].ToString());
                    lst.Add(reader["end_time"].ToString());
                }
                bd_MuaGiai = long.Parse(lst[0]);
                kt_MuaGiai = long.Parse(lst[1]);
            }
        }

        public bool check_match(int league_id, int season_id, int host_id, int away_id)
        {
            bool isOk = false;
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sql = "SELECT *FROM dh_match WHERE league_id=@league_id and season_id=@season_id and team_host_id=@host_id and team_away_id=@away_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@league_id", league_id);
                    cmd.Parameters.AddWithValue("@season_id", season_id);
                    cmd.Parameters.AddWithValue("@host_id", host_id);
                    cmd.Parameters.AddWithValue("@away_id", away_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    if (table.Rows != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            isOk = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return isOk;

            }
        }
        public bool check_time(int league_id, int season_id, long start_time , long end_time)
        {
            bool isOk = false;
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sql = "SELECT *FROM dh_match WHERE league_id=@league_id and season_id=@season_id and start_time=@start_time and end_time=@end_time";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@league_id", league_id);
                    cmd.Parameters.AddWithValue("@season_id", season_id);
                    cmd.Parameters.AddWithValue("@start_time", start_time);
                    cmd.Parameters.AddWithValue("@end_time", end_time);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    if (table.Rows != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            isOk = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return isOk;

            }
        }


        public void InsertMatch(int league_id, int season_id, DataGridView dgvXepLich, ComboBox cbbTenGiai, ComboBox cbbMuaGiai, ComboBox cbbDoiChuNha, ComboBox cbbDoiKhach, DateTimePicker dtpBD, DateTimePicker dtpKT)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    long bd_MuaGiai, kt_MuaGiai, bd, kt;
                    bd = ((DateTimeOffset)dtpBD.Value).ToUnixTimeMilliseconds();
                    kt = ((DateTimeOffset)dtpKT.Value).ToUnixTimeMilliseconds();
                    time_season(season_id, out bd_MuaGiai, out kt_MuaGiai);
                    String sql = "INSERT INTO dh_match(league_id,season_id,team_host_id,team_away_id,team_host_goal,team_away_goal,start_time,end_time, is_final_result)"
                        + " VALUES(@gd, @mg, @hid, @aid, @hgoal, @agoal, @bd, @kt, @fn)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@gd", int.Parse(cbbTenGiai.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@mg", cbbMuaGiai.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@hid", cbbDoiChuNha.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@aid", cbbDoiKhach.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@hgoal", 0);
                    cmd.Parameters.AddWithValue("@agoal", 0);
                    cmd.Parameters.AddWithValue("@bd", bd);
                    cmd.Parameters.AddWithValue("@kt", kt);
                    cmd.Parameters.AddWithValue("@fn", 0);

                    if (bd_MuaGiai > bd)
                    {
                        MessageBox.Show("Thời gian bắt đầu trận đấu sớm hơn thời gian bắt đầu giải", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (bd > kt)
                    {
                        MessageBox.Show("Thời gian bắt đầu và kết thúc trận đấu không hợp lệ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if ((kt - bd) < 5400000)
                    {
                        MessageBox.Show("Thời gian bắt đầu và kết thúc trận đấu không hợp lệ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (kt > kt_MuaGiai)
                    {
                        MessageBox.Show("Thời gian kết thúc trận đấu muộn hơn thời gian kết thúc giải", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cmd.ExecuteNonQuery();
                    ShowData(dgvXepLich, league_id, season_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi Thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void UpdateMatch(int league_id, int season_id, int index, DataGridView dgvXepLich, ComboBox cbbTenGiai, ComboBox cbbMuaGiai, ComboBox cbbDoiChuNha, ComboBox cbbDoiKhach, DateTimePicker dtpBD, DateTimePicker dtpKT)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    long bd_MuaGiai, kt_MuaGiai, bd, kt;
                    bd = ((DateTimeOffset)dtpBD.Value).ToUnixTimeMilliseconds();
                    kt = ((DateTimeOffset)dtpKT.Value).ToUnixTimeMilliseconds();
                    time_season(season_id, out bd_MuaGiai, out kt_MuaGiai);
                    String sql = "UPDATE dh_match SET  league_id=@gd, season_id=@mg, team_host_id=@hid, team_away_id=@aid,"
                        + " team_host_goal=@hgoal, team_away_goal=@agoal, start_time=@bd, end_time=@kt, is_final_result=@fn WHERE id=@mt";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mt", int.Parse(dgvXepLich.Rows[index].Cells[0].Value.ToString()));
                    cmd.Parameters.AddWithValue("@gd", cbbTenGiai.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@mg", cbbMuaGiai.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@hid", cbbDoiChuNha.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@aid", cbbDoiKhach.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@hgoal", 0);
                    cmd.Parameters.AddWithValue("@agoal", 0);
                    cmd.Parameters.AddWithValue("@bd", bd);
                    cmd.Parameters.AddWithValue("@kt", kt);
                    cmd.Parameters.AddWithValue("@fn", 0);

                    if (bd_MuaGiai > bd)
                    {
                        MessageBox.Show("Thời gian bắt đầu trận đấu sớm hơn thời gian bắt đầu giải", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (bd > kt)
                    {
                        MessageBox.Show("Thời gian bắt đầu và kết thúc trận đấu không hợp lệ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if ((kt - bd) < 5400000)
                    {
                        MessageBox.Show("Thời gian bắt đầu và kết thúc trận đấu không hợp lệ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (kt > kt_MuaGiai)
                    {
                        MessageBox.Show("Thời gian kết thúc trận đấu muộn hơn thời gian kết thúc giải", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cmd.ExecuteNonQuery();
                    ShowData(dgvXepLich, league_id, season_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteMatch(int league_id, int season_id, int index, DataGridView dgvXepLich)
        {
            using (SqlConnection conn = dataConn.getConnect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String sql = "DELETE FROM dh_match WHERE id=@mt";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mt", int.Parse(dgvXepLich.Rows[index].Cells[0].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    ShowData(dgvXepLich, league_id, season_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
