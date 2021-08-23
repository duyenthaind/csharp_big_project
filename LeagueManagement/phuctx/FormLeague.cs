using System;
using System.Data;
using System.Windows.Forms;

namespace LeagueManagement.phuctx
{
    public partial class FormLeague : Form
    {
        public FormLeague()
        {
            InitializeComponent();
        }

        private void FormLeague_Load(object sender, EventArgs e)
        {
            DataLeague data = new DataLeague();
            DataTable dt = new DataTable();
            dt = data.ShowLeague();
            dgvLeague.DataSource = dt;
        }

        private void dgvLeague_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtID.Text = dgvLeague.Rows[row].Cells[0].Value.ToString();
                txtName.Text = dgvLeague.Rows[row].Cells[1].Value.ToString();
                txtNationID.Text = dgvLeague.Rows[row].Cells[2].Value.ToString();
                txtNum_matches.Text = dgvLeague.Rows[row].Cells[3].Value.ToString();
                txtNum_team.Text = dgvLeague.Rows[row].Cells[4].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataLeague data = new DataLeague();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên giải đấu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNum_matches.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số trận đấu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNationID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã quốc gia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNum_team.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số đội", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtNum_matches.Text, out UInt32 o))
                {
                    MessageBox.Show("Số trận đấu không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtNum_team.Text, out UInt32 p))
                {
                    MessageBox.Show("Số đội không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                data.InsertLeague(txtName.Text, int.Parse(txtNationID.Text), int.Parse(txtNum_matches.Text), int.Parse(txtNum_team.Text));
                FormLeague_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataLeague data = new DataLeague();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên giải đấu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNum_matches.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số trận đấu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNationID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã quốc gia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNum_team.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số đội", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtNum_matches.Text, out UInt32 o))
                {
                    MessageBox.Show("Số trận đấu không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtNum_team.Text, out UInt32 p))
                {
                    MessageBox.Show("Số đội không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                data.UpdateLeague(int.Parse(txtID.Text), txtName.Text, int.Parse(txtNationID.Text), int.Parse(txtNum_matches.Text), int.Parse(txtNum_team.Text));
                FormLeague_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataLeague data = new DataLeague();
            data.DeleteLeague(int.Parse(txtID.Text));
            FormLeague_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
