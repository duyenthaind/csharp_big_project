
namespace LeagueManagement.sonnx
{
    partial class BangXepHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTieuDe = new System.Windows.Forms.Panel();
            this.cbbMuaGiai = new System.Windows.Forms.ComboBox();
            this.cbbTenGiai = new System.Windows.Forms.ComboBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBXH = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_win = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_draw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_lost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.played_matches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_goal_scored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_goal_received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBXH)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTieuDe, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvBXH, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTieuDe
            // 
            this.panelTieuDe.Controls.Add(this.cbbMuaGiai);
            this.panelTieuDe.Controls.Add(this.cbbTenGiai);
            this.panelTieuDe.Controls.Add(this.btnDong);
            this.panelTieuDe.Controls.Add(this.btnLoad);
            this.panelTieuDe.Controls.Add(this.label3);
            this.panelTieuDe.Controls.Add(this.label2);
            this.panelTieuDe.Controls.Add(this.label1);
            this.panelTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTieuDe.Location = new System.Drawing.Point(3, 3);
            this.panelTieuDe.Name = "panelTieuDe";
            this.panelTieuDe.Size = new System.Drawing.Size(794, 129);
            this.panelTieuDe.TabIndex = 0;
            // 
            // cbbMuaGiai
            // 
            this.cbbMuaGiai.FormattingEnabled = true;
            this.cbbMuaGiai.Location = new System.Drawing.Point(467, 56);
            this.cbbMuaGiai.Name = "cbbMuaGiai";
            this.cbbMuaGiai.Size = new System.Drawing.Size(121, 21);
            this.cbbMuaGiai.TabIndex = 8;
            // 
            // cbbTenGiai
            // 
            this.cbbTenGiai.FormattingEnabled = true;
            this.cbbTenGiai.Location = new System.Drawing.Point(174, 56);
            this.cbbTenGiai.Name = "cbbTenGiai";
            this.cbbTenGiai.Size = new System.Drawing.Size(121, 21);
            this.cbbTenGiai.TabIndex = 7;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(655, 88);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(655, 52);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mùa giải:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên giải:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BẢNG XẾP HẠNG";
            // 
            // dgvBXH
            // 
            this.dgvBXH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBXH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.point,
            this.num_win,
            this.num_draw,
            this.num_lost,
            this.played_matches,
            this.difference,
            this.num_goal_scored,
            this.num_goal_received});
            this.dgvBXH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBXH.Location = new System.Drawing.Point(3, 138);
            this.dgvBXH.Name = "dgvBXH";
            this.dgvBXH.Size = new System.Drawing.Size(794, 309);
            this.dgvBXH.TabIndex = 1;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Tên đội";
            this.name.Name = "name";
            // 
            // point
            // 
            this.point.DataPropertyName = "point";
            this.point.HeaderText = "Điểm";
            this.point.Name = "point";
            this.point.Width = 50;
            // 
            // num_win
            // 
            this.num_win.DataPropertyName = "num_win";
            this.num_win.HeaderText = "Số trận thắng";
            this.num_win.Name = "num_win";
            this.num_win.Width = 80;
            // 
            // num_draw
            // 
            this.num_draw.DataPropertyName = "num_draw";
            this.num_draw.HeaderText = "Số trận hòa";
            this.num_draw.Name = "num_draw";
            this.num_draw.Width = 80;
            // 
            // num_lost
            // 
            this.num_lost.DataPropertyName = "num_lost";
            this.num_lost.HeaderText = "Số trận thua";
            this.num_lost.Name = "num_lost";
            this.num_lost.Width = 80;
            // 
            // played_matches
            // 
            this.played_matches.DataPropertyName = "played_matches";
            this.played_matches.HeaderText = "Số trận đã chơi";
            this.played_matches.Name = "played_matches";
            this.played_matches.Width = 90;
            // 
            // difference
            // 
            this.difference.DataPropertyName = "difference";
            this.difference.HeaderText = "Hiệu số bàn thắng";
            this.difference.Name = "difference";
            this.difference.Width = 90;
            // 
            // num_goal_scored
            // 
            this.num_goal_scored.DataPropertyName = "num_goal_scored";
            this.num_goal_scored.HeaderText = "Tổng số bàn thắng";
            this.num_goal_scored.Name = "num_goal_scored";
            this.num_goal_scored.Width = 90;
            // 
            // num_goal_received
            // 
            this.num_goal_received.DataPropertyName = "num_goal_received";
            this.num_goal_received.HeaderText = "Tổng số bàn thua";
            this.num_goal_received.Name = "num_goal_received";
            this.num_goal_received.Width = 90;
            // 
            // BangXepHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BangXepHang";
            this.Text = "BangXepHang";
            this.Load += new System.EventHandler(this.BangXepHang_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTieuDe.ResumeLayout(false);
            this.panelTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBXH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTieuDe;
        private System.Windows.Forms.DataGridView dgvBXH;
        private System.Windows.Forms.ComboBox cbbMuaGiai;
        private System.Windows.Forms.ComboBox cbbTenGiai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn point;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_win;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_draw;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_lost;
        private System.Windows.Forms.DataGridViewTextBoxColumn played_matches;
        private System.Windows.Forms.DataGridViewTextBoxColumn difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_goal_scored;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_goal_received;
    }
}