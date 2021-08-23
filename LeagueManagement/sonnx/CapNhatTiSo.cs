using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueManagement.sonnx
{
    public partial class CapNhatTiSo : Form
    {
        DAO_CapNhatTiSo dao = new DAO_CapNhatTiSo();
        public CapNhatTiSo()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int league_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
            int season_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
            dao.ShowData(dgv_TranDau, league_id, season_id);
        }

        private void CapNhatTiSo_Load(object sender, EventArgs e)
        {
            dao.ShowMuaGiai(cbbTenGiai, cbbMuaGiai);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int league_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
            int season_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
            int index = dgv_TranDau.SelectedCells[0].RowIndex;
            String check = dgv_TranDau.Rows[index].Cells[7].Value.ToString();
            
            if (check.Equals("True"))
            {
                MessageBox.Show("Trận đấu đã được cập nhật tỉ số rồi!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                dao.Update_TiSo(index, dgv_TranDau, txtHost_goal, txtAway_goal, league_id, season_id);
                Clear();
            }
        }

        private void dgv_TranDau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                lblDoiNha.Text = dgv_TranDau.Rows[index].Cells[1].Value.ToString();
                lblDoiKhach.Text = dgv_TranDau.Rows[index].Cells[2].Value.ToString();
                txtHost_goal.Text = dgv_TranDau.Rows[index].Cells[3].Value.ToString();
                txtAway_goal.Text = dgv_TranDau.Rows[index].Cells[4].Value.ToString();
                String check = dgv_TranDau.Rows[index].Cells[7].Value.ToString();
            }
        }

        private void btnXepBXH_Click(object sender, EventArgs e)
        {
            CapNhatTiSo cn = new CapNhatTiSo();
            BangXepHang bxh = new BangXepHang();
            cn.Hide();
            bxh.Show();
        }

        private void Clear()
        {
            lblDoiNha.Text = "--";
            lblDoiKhach.Text = "--";

            txtHost_goal.Clear();
            txtAway_goal.Clear();

        }
    }
}
