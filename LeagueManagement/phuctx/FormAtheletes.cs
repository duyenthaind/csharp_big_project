using System;
using System.Data;
using System.Windows.Forms;

namespace LeagueManagement.phuctx
{
    public partial class FormAtheletes : Form
    {
        public FormAtheletes()
        {
            InitializeComponent();
        }

        private void FormAtheletes_Load(object sender, EventArgs e)
        {
            DataAtheletes data = new DataAtheletes();
            DataTable dt = new DataTable();
            dt = data.ShowAtheletes();
            dgvAtheletes.DataSource = dt;
        }

        private void dgvAtheletes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtID.Text = dgvAtheletes.Rows[row].Cells[0].Value.ToString();
                txtName.Text = dgvAtheletes.Rows[row].Cells[1].Value.ToString();
                txtAge.Text = dgvAtheletes.Rows[row].Cells[2].Value.ToString();
                if (dgvAtheletes.Rows[row].Cells[3].Value.Equals(true))
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtNationID.Text = dgvAtheletes.Rows[row].Cells[4].Value.ToString();
                txtTeamID.Text = dgvAtheletes.Rows[row].Cells[5].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataAtheletes data = new DataAtheletes();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên cầu thủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtTeamID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã đội", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNationID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã quốc gia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtAge.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tuổi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtAge.Text, out UInt32 o))
                {
                    MessageBox.Show("Tuổi không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Boolean t = true;
                if (rdbNam.Checked == true)
                    t = true;
                else t = false;
                data.InsertAtheletes(txtName.Text, int.Parse(txtAge.Text), t, int.Parse(txtNationID.Text), int.Parse(txtTeamID.Text));
                FormAtheletes_Load(sender, e);
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
                DataAtheletes data = new DataAtheletes();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên cầu thủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtTeamID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã đội", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNationID.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã quốc gia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtAge.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tuổi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!UInt32.TryParse(txtAge.Text, out UInt32 o))
                {
                    MessageBox.Show("Tuổi không được âm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Boolean t = true;
                if (rdbNam.Checked == true)
                    t = true;
                else t = false;
                data.UpdateAtheletes(int.Parse(txtID.Text),txtName.Text, int.Parse(txtAge.Text), t, int.Parse(txtNationID.Text), int.Parse(txtTeamID.Text));
                FormAtheletes_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataAtheletes data = new DataAtheletes();
            data.DeleteAtheletes(int.Parse(txtID.Text));
            FormAtheletes_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
