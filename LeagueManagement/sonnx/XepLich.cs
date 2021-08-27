using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace LeagueManagement.sonnx
{
    public partial class XepLich : Form
    {
        DAO_XepLich dao = new DAO_XepLich();
        public XepLich()
        {
            InitializeComponent();
        }

        private void XepLich_Load(object sender, EventArgs e)
        {
            dao.ShowMuaGiai(cbbTenGiai, cbbMuaGiai);
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                int league_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
                int season_id = int.Parse(cbbMuaGiai.SelectedValue.ToString());
                dao.ShowData(dgvXepLich, league_id, season_id);
                dao.ShowDoiBong(league_id, cbbDoiChuNha, cbbDoiKhach);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu load", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
           
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int league_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
                int season_id = int.Parse(cbbMuaGiai.SelectedValue.ToString());
                int.TryParse(cbbDoiChuNha.SelectedValue.ToString(), out var host_id);
                int.TryParse(cbbDoiKhach.SelectedValue.ToString(), out var away_id);
                long bd = ((DateTimeOffset)dtpBD.Value).ToUnixTimeMilliseconds();
                long kt = ((DateTimeOffset)dtpKT.Value).ToUnixTimeMilliseconds();
                if (cbbDoiChuNha.Text == cbbDoiKhach.Text)
                {
                    MessageBox.Show("Đội nhà không được chùng đội khách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dao.check_match(league_id, season_id, host_id, away_id))
                {
                    MessageBox.Show("Trận đấu đã tồn tại trong mùa giải này rồi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dao.check_time(league_id, season_id, bd, kt))
                {
                    MessageBox.Show("Thời gian đã tồn tại trận đấu khác", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dao.InsertMatch(league_id, season_id, dgvXepLich, cbbTenGiai, cbbMuaGiai, cbbDoiChuNha, cbbDoiKhach, dtpBD, dtpKT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int league_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
                int season_id = int.Parse(cbbMuaGiai.SelectedValue.ToString());
                int index = dgvXepLich.SelectedCells[0].RowIndex;
                int.TryParse(cbbDoiChuNha.SelectedValue.ToString(), out var host_id);
                int.TryParse(cbbDoiKhach.SelectedValue.ToString(), out var away_id);
                long bd = ((DateTimeOffset)dtpBD.Value).ToUnixTimeMilliseconds();
                long kt = ((DateTimeOffset)dtpKT.Value).ToUnixTimeMilliseconds();
                int id = int.Parse(dgvXepLich.Rows[index].Cells[0].Value.ToString());
                if (cbbDoiChuNha.Text == cbbDoiKhach.Text)
                {
                    MessageBox.Show("Đội nhà không được chùng đội khách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dao.check_match_update(league_id, season_id, host_id, away_id, id))
                {
                    MessageBox.Show("Trận đấu đã tồn tại trong mùa giải này rồi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dao.check_time_update(league_id, season_id, bd, kt, id))
                {
                    MessageBox.Show("Thời gian đã tồn tại trận đấu khác", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dao.UpdateMatch(league_id, season_id, index, dgvXepLich, cbbTenGiai, cbbMuaGiai, cbbDoiChuNha, cbbDoiKhach, dtpBD, dtpKT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int league_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
                int season_id = int.Parse(cbbMuaGiai.SelectedValue.ToString());
                int index = dgvXepLich.SelectedCells[0].RowIndex;
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    dao.DeleteMatch(league_id, season_id, index, dgvXepLich);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvXepLich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cbbTenGiai.Text = dgvXepLich.Rows[index].Cells[1].Value.ToString();
                cbbMuaGiai.Text = dgvXepLich.Rows[index].Cells[2].Value.ToString();
                cbbDoiChuNha.Text = dgvXepLich.Rows[index].Cells[3].Value.ToString();
                cbbDoiKhach.Text = dgvXepLich.Rows[index].Cells[4].Value.ToString();
                dtpBD.Text = dgvXepLich.Rows[index].Cells[5].Value.ToString();
                dtpKT.Text = dgvXepLich.Rows[index].Cells[6].Value.ToString();
                //dtpBD.Value = DateTime.ParseExact(dgvXepLich.Rows[index].Cells[5].Value.ToString(), "dd / MM / yyyy hh: mm: ss tt", CultureInfo.InvariantCulture);
                //dtpKT.Value = DateTime.ParseExact(dgvXepLich.Rows[index].Cells[6].Value.ToString(), "dd / MM / yyyy hh: mm: ss tt", CultureInfo.InvariantCulture);
            }
        }
    }
}
