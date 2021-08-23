﻿using System;
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
    public partial class BangXepHang : Form
    {
        DAO_BangXepHang dao = new DAO_BangXepHang();
        public BangXepHang()
        {
            InitializeComponent();
        }

        private void BangXepHang_Load(object sender, EventArgs e)
        {
            dao.ShowMuaGiai(cbbTenGiai, cbbMuaGiai);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int league_id = int.Parse(cbbTenGiai.SelectedValue.ToString());
            int season_id = int.Parse(cbbTenGiai.SelectedValue.ToString());  
            dao.ShowData(league_id, season_id, dgvBXH);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}