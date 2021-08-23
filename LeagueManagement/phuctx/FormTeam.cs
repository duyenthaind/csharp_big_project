using System;
using System.Data;
using System.Windows.Forms;

namespace LeagueManagement.phuctx
{
    public partial class FormTeam : Form
    {
        public FormTeam()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTeam data = new DataTeam();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đội", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtHost.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập sân nhà thi đấu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNationID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã quốc gia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNum_atheletes.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số cầu thủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtNum_atheletes.Text, out UInt32 o))
                {
                    MessageBox.Show("Số trận không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                data.InsertTeam(txtName.Text, txtHost.Text, int.Parse(txtNationID.Text), int.Parse(txtNum_atheletes.Text));
                FormTeam_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormTeam_Load(object sender, EventArgs e)
        {
            DataTeam data = new DataTeam();
            DataTable dt = new DataTable();
            dt = data.ShowTeam();
            dgvTeam.DataSource = dt;
        }

        private void dgvTeam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtID.Text = dgvTeam.Rows[row].Cells[0].Value.ToString();
                txtName.Text = dgvTeam.Rows[row].Cells[1].Value.ToString();
                txtHost.Text = dgvTeam.Rows[row].Cells[2].Value.ToString();
                txtNationID.Text = dgvTeam.Rows[row].Cells[3].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTeam data = new DataTeam();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đội", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtHost.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập sân nhà thi đấu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNationID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã quốc gia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNum_atheletes.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số cầu thủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtNum_atheletes.Text, out UInt32 o))
                {
                    MessageBox.Show("Số trận không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                data.UpdateTeam(int.Parse(txtID.Text), txtName.Text, txtHost.Text, int.Parse(txtNationID.Text), int.Parse(txtNum_atheletes.Text));
                FormTeam_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTeam data = new DataTeam();
            data.DeleteTeam(int.Parse(txtID.Text));
            FormTeam_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
