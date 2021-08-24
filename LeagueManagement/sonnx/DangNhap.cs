using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeagueManagement.thaind.common;

namespace LeagueManagement.sonnx
{
    public partial class DangNhap : Form
    {
        private static DangNhap _showForm;
        
        DAO_DangNhap dao = new DAO_DangNhap();
        public DangNhap()
        {
            InitializeComponent();
            _showForm = this;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            dao.checkDangNhap(txtTaiKhoan, txtMatKhau);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StopProcess()
        {
            Start.StopAllWorker();
            Application.Exit();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopProcess();
        }

        public static DangNhap GetMainForm()
        {
            return _showForm;
        }
    }
}
