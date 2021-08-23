
namespace LeagueManagement.sonnx
{
    partial class CapNhatTiSo
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grbGiaiDau = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbMuaGiai = new System.Windows.Forms.ComboBox();
            this.cbbTenGiai = new System.Windows.Forms.ComboBox();
            this.grbTiSo = new System.Windows.Forms.GroupBox();
            this.lblDoiKhach = new System.Windows.Forms.Label();
            this.lblDoiNha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAway_goal = new System.Windows.Forms.TextBox();
            this.txtHost_goal = new System.Windows.Forms.TextBox();
            this.groupThaoTac = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXepBXH = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_TranDau = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.host_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.away_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Host_goal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Away_goal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_final_result = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grbGiaiDau.SuspendLayout();
            this.grbTiSo.SuspendLayout();
            this.groupThaoTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TranDau)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_TranDau, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.grbGiaiDau, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grbTiSo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupThaoTac, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 241);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // grbGiaiDau
            // 
            this.grbGiaiDau.Controls.Add(this.btnLoad);
            this.grbGiaiDau.Controls.Add(this.label7);
            this.grbGiaiDau.Controls.Add(this.label6);
            this.grbGiaiDau.Controls.Add(this.cbbMuaGiai);
            this.grbGiaiDau.Controls.Add(this.cbbTenGiai);
            this.grbGiaiDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbGiaiDau.Location = new System.Drawing.Point(3, 3);
            this.grbGiaiDau.Name = "grbGiaiDau";
            this.grbGiaiDau.Size = new System.Drawing.Size(232, 235);
            this.grbGiaiDau.TabIndex = 0;
            this.grbGiaiDau.TabStop = false;
            this.grbGiaiDau.Text = "Giải đấu";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(89, 180);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mùa giải:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tên giải:";
            // 
            // cbbMuaGiai
            // 
            this.cbbMuaGiai.FormattingEnabled = true;
            this.cbbMuaGiai.Location = new System.Drawing.Point(89, 119);
            this.cbbMuaGiai.Name = "cbbMuaGiai";
            this.cbbMuaGiai.Size = new System.Drawing.Size(121, 21);
            this.cbbMuaGiai.TabIndex = 1;
            // 
            // cbbTenGiai
            // 
            this.cbbTenGiai.FormattingEnabled = true;
            this.cbbTenGiai.Location = new System.Drawing.Point(89, 35);
            this.cbbTenGiai.Name = "cbbTenGiai";
            this.cbbTenGiai.Size = new System.Drawing.Size(121, 21);
            this.cbbTenGiai.TabIndex = 0;
            // 
            // grbTiSo
            // 
            this.grbTiSo.Controls.Add(this.lblDoiKhach);
            this.grbTiSo.Controls.Add(this.lblDoiNha);
            this.grbTiSo.Controls.Add(this.label5);
            this.grbTiSo.Controls.Add(this.label4);
            this.grbTiSo.Controls.Add(this.label3);
            this.grbTiSo.Controls.Add(this.label2);
            this.grbTiSo.Controls.Add(this.txtAway_goal);
            this.grbTiSo.Controls.Add(this.txtHost_goal);
            this.grbTiSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTiSo.Location = new System.Drawing.Point(241, 3);
            this.grbTiSo.Name = "grbTiSo";
            this.grbTiSo.Size = new System.Drawing.Size(391, 235);
            this.grbTiSo.TabIndex = 1;
            this.grbTiSo.TabStop = false;
            this.grbTiSo.Text = "Tỉ số trận đấu";
            // 
            // lblDoiKhach
            // 
            this.lblDoiKhach.AutoSize = true;
            this.lblDoiKhach.Location = new System.Drawing.Point(227, 78);
            this.lblDoiKhach.Name = "lblDoiKhach";
            this.lblDoiKhach.Size = new System.Drawing.Size(13, 13);
            this.lblDoiKhach.TabIndex = 9;
            this.lblDoiKhach.Text = "--";
            // 
            // lblDoiNha
            // 
            this.lblDoiNha.AutoSize = true;
            this.lblDoiNha.Location = new System.Drawing.Point(227, 34);
            this.lblDoiNha.Name = "lblDoiNha";
            this.lblDoiNha.Size = new System.Drawing.Size(13, 13);
            this.lblDoiNha.TabIndex = 8;
            this.lblDoiNha.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số bàn thắng đôi khách:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số bàn thắng đội nhà:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Đội khách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đội nhà:";
            // 
            // txtAway_goal
            // 
            this.txtAway_goal.Location = new System.Drawing.Point(227, 163);
            this.txtAway_goal.Name = "txtAway_goal";
            this.txtAway_goal.Size = new System.Drawing.Size(100, 20);
            this.txtAway_goal.TabIndex = 1;
            // 
            // txtHost_goal
            // 
            this.txtHost_goal.Location = new System.Drawing.Point(227, 119);
            this.txtHost_goal.Name = "txtHost_goal";
            this.txtHost_goal.Size = new System.Drawing.Size(100, 20);
            this.txtHost_goal.TabIndex = 0;
            // 
            // groupThaoTac
            // 
            this.groupThaoTac.Controls.Add(this.btnDong);
            this.groupThaoTac.Controls.Add(this.btnXepBXH);
            this.groupThaoTac.Controls.Add(this.btnCapNhat);
            this.groupThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThaoTac.Location = new System.Drawing.Point(638, 3);
            this.groupThaoTac.Name = "groupThaoTac";
            this.groupThaoTac.Size = new System.Drawing.Size(153, 235);
            this.groupThaoTac.TabIndex = 2;
            this.groupThaoTac.TabStop = false;
            this.groupThaoTac.Text = "Thao tác";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(43, 161);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXepBXH
            // 
            this.btnXepBXH.Location = new System.Drawing.Point(43, 96);
            this.btnXepBXH.Name = "btnXepBXH";
            this.btnXepBXH.Size = new System.Drawing.Size(75, 39);
            this.btnXepBXH.TabIndex = 1;
            this.btnXepBXH.Text = "Xem bảng xếp hạng";
            this.btnXepBXH.UseVisualStyleBackColor = true;
            this.btnXepBXH.Click += new System.EventHandler(this.btnXepBXH_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(43, 31);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 0;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "CẬP NHẬT TỈ SỐ TRẬN ĐẤU";
            // 
            // dgv_TranDau
            // 
            this.dgv_TranDau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TranDau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.host_name,
            this.away_name,
            this.Host_goal,
            this.Away_goal,
            this.startTime,
            this.endTime,
            this.is_final_result});
            this.dgv_TranDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_TranDau.Location = new System.Drawing.Point(3, 295);
            this.dgv_TranDau.Name = "dgv_TranDau";
            this.dgv_TranDau.Size = new System.Drawing.Size(794, 152);
            this.dgv_TranDau.TabIndex = 0;
            this.dgv_TranDau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TranDau_CellClick);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "Mã trận";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // host_name
            // 
            this.host_name.DataPropertyName = "host_name";
            this.host_name.HeaderText = "Đội chủ nhà";
            this.host_name.Name = "host_name";
            // 
            // away_name
            // 
            this.away_name.DataPropertyName = "away_name";
            this.away_name.HeaderText = "Đội khách";
            this.away_name.Name = "away_name";
            // 
            // Host_goal
            // 
            this.Host_goal.DataPropertyName = "Host_goal";
            this.Host_goal.HeaderText = "Số bàn thắng đội nhà";
            this.Host_goal.Name = "Host_goal";
            this.Host_goal.Width = 80;
            // 
            // Away_goal
            // 
            this.Away_goal.DataPropertyName = "Away_goal";
            this.Away_goal.HeaderText = "Số bàn thắng đội khách";
            this.Away_goal.Name = "Away_goal";
            this.Away_goal.Width = 80;
            // 
            // startTime
            // 
            this.startTime.DataPropertyName = "startTime";
            this.startTime.HeaderText = "Thời gian bắt đầu";
            this.startTime.Name = "startTime";
            this.startTime.Width = 120;
            // 
            // endTime
            // 
            this.endTime.DataPropertyName = "endTime";
            this.endTime.HeaderText = "Thời  gian kết thúc";
            this.endTime.Name = "endTime";
            this.endTime.Width = 120;
            // 
            // is_final_result
            // 
            this.is_final_result.DataPropertyName = "is_final_result";
            this.is_final_result.HeaderText = "Đã cập nhật";
            this.is_final_result.Name = "is_final_result";
            this.is_final_result.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_final_result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CapNhatTiSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CapNhatTiSo";
            this.Text = "CapNhatTiSo";
            this.Load += new System.EventHandler(this.CapNhatTiSo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grbGiaiDau.ResumeLayout(false);
            this.grbGiaiDau.PerformLayout();
            this.grbTiSo.ResumeLayout(false);
            this.grbTiSo.PerformLayout();
            this.groupThaoTac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TranDau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_TranDau;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grbGiaiDau;
        private System.Windows.Forms.GroupBox grbTiSo;
        private System.Windows.Forms.GroupBox groupThaoTac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAway_goal;
        private System.Windows.Forms.TextBox txtHost_goal;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbMuaGiai;
        private System.Windows.Forms.ComboBox cbbTenGiai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXepBXH;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label lblDoiKhach;
        private System.Windows.Forms.Label lblDoiNha;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn host_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn away_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Host_goal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Away_goal;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_final_result;
    }
}