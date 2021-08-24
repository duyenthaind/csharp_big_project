namespace LeagueManagement
{
    partial class MainForm
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
            this.panelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLeague = new System.Windows.Forms.Button();
            this.btnTeam = new System.Windows.Forms.Button();
            this.btnAltheletes = new System.Windows.Forms.Button();
            this.btnMatches = new System.Windows.Forms.Button();
            this.btnMatchUpdate = new System.Windows.Forms.Button();
            this.btnLeagueResult = new System.Windows.Forms.Button();
            this.btnRankingStatistic = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (51)))), ((int) (((byte) (76)))));
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Controls.Add(this.btnLeague);
            this.panelMenu.Controls.Add(this.btnTeam);
            this.panelMenu.Controls.Add(this.btnAltheletes);
            this.panelMenu.Controls.Add(this.btnMatches);
            this.panelMenu.Controls.Add(this.btnMatchUpdate);
            this.panelMenu.Controls.Add(this.btnLeagueResult);
            this.panelMenu.Controls.Add(this.btnRankingStatistic);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(208, 659);
            this.panelMenu.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (40)))), ((int) (((byte) (40)))), ((int) (((byte) (74)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(208, 81);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            // 
            // btnLeague
            // 
            this.btnLeague.FlatAppearance.BorderSize = 0;
            this.btnLeague.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeague.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnLeague.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLeague.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeague.Location = new System.Drawing.Point(0, 81);
            this.btnLeague.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeague.Name = "btnLeague";
            this.btnLeague.Size = new System.Drawing.Size(208, 81);
            this.btnLeague.TabIndex = 1;
            this.btnLeague.Text = "Quản lý giải đấu";
            this.btnLeague.UseVisualStyleBackColor = true;
            this.btnLeague.Click += new System.EventHandler(this.btnLeague_Click);
            // 
            // btnTeam
            // 
            this.btnTeam.FlatAppearance.BorderSize = 0;
            this.btnTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnTeam.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeam.Location = new System.Drawing.Point(0, 162);
            this.btnTeam.Margin = new System.Windows.Forms.Padding(0);
            this.btnTeam.Name = "btnTeam";
            this.btnTeam.Size = new System.Drawing.Size(208, 81);
            this.btnTeam.TabIndex = 2;
            this.btnTeam.Text = "Quản lý đội bóng";
            this.btnTeam.UseVisualStyleBackColor = true;
            this.btnTeam.Click += new System.EventHandler(this.btnTeam_Click);
            // 
            // btnAltheletes
            // 
            this.btnAltheletes.FlatAppearance.BorderSize = 0;
            this.btnAltheletes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltheletes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnAltheletes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAltheletes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltheletes.Location = new System.Drawing.Point(0, 243);
            this.btnAltheletes.Margin = new System.Windows.Forms.Padding(0);
            this.btnAltheletes.Name = "btnAltheletes";
            this.btnAltheletes.Size = new System.Drawing.Size(208, 81);
            this.btnAltheletes.TabIndex = 3;
            this.btnAltheletes.Text = "Quản lý cầu thủ";
            this.btnAltheletes.UseVisualStyleBackColor = true;
            this.btnAltheletes.Click += new System.EventHandler(this.btnAltheletes_Click);
            // 
            // btnMatches
            // 
            this.btnMatches.FlatAppearance.BorderSize = 0;
            this.btnMatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnMatches.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMatches.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatches.Location = new System.Drawing.Point(0, 324);
            this.btnMatches.Margin = new System.Windows.Forms.Padding(0);
            this.btnMatches.Name = "btnMatches";
            this.btnMatches.Size = new System.Drawing.Size(208, 81);
            this.btnMatches.TabIndex = 4;
            this.btnMatches.Text = "Quản lý lịch thi đấu";
            this.btnMatches.UseVisualStyleBackColor = true;
            this.btnMatches.Click += new System.EventHandler(this.btnMatches_Click);
            // 
            // btnMatchUpdate
            // 
            this.btnMatchUpdate.FlatAppearance.BorderSize = 0;
            this.btnMatchUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatchUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnMatchUpdate.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMatchUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatchUpdate.Location = new System.Drawing.Point(0, 405);
            this.btnMatchUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnMatchUpdate.Name = "btnMatchUpdate";
            this.btnMatchUpdate.Size = new System.Drawing.Size(208, 81);
            this.btnMatchUpdate.TabIndex = 5;
            this.btnMatchUpdate.Text = "Cập nhật kết quả trận đấu";
            this.btnMatchUpdate.UseVisualStyleBackColor = true;
            this.btnMatchUpdate.Click += new System.EventHandler(this.btnMatchUpdate_Click);
            // 
            // btnLeagueResult
            // 
            this.btnLeagueResult.FlatAppearance.BorderSize = 0;
            this.btnLeagueResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeagueResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnLeagueResult.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLeagueResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeagueResult.Location = new System.Drawing.Point(0, 486);
            this.btnLeagueResult.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeagueResult.Name = "btnLeagueResult";
            this.btnLeagueResult.Size = new System.Drawing.Size(208, 81);
            this.btnLeagueResult.TabIndex = 6;
            this.btnLeagueResult.Text = "Bảng xếp hạng giải đấu";
            this.btnLeagueResult.UseVisualStyleBackColor = true;
            this.btnLeagueResult.Click += new System.EventHandler(this.btnLeagueResult_Click);
            // 
            // btnRankingStatistic
            // 
            this.btnRankingStatistic.FlatAppearance.BorderSize = 0;
            this.btnRankingStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRankingStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnRankingStatistic.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRankingStatistic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRankingStatistic.Location = new System.Drawing.Point(0, 567);
            this.btnRankingStatistic.Margin = new System.Windows.Forms.Padding(0);
            this.btnRankingStatistic.Name = "btnRankingStatistic";
            this.btnRankingStatistic.Size = new System.Drawing.Size(208, 81);
            this.btnRankingStatistic.TabIndex = 7;
            this.btnRankingStatistic.Text = "Thống kê giải đấu";
            this.btnRankingStatistic.UseVisualStyleBackColor = true;
            this.btnRankingStatistic.Click += new System.EventHandler(this.btnRankingStatistic_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(208, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(728, 81);
            this.panelTitle.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(187, 24);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(372, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "League Mangement Tool";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelView
            // 
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(208, 0);
            this.panelView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelView.Name = "panelView";
            this.panelView.Padding = new System.Windows.Forms.Padding(15, 41, 0, 0);
            this.panelView.Size = new System.Drawing.Size(728, 659);
            this.panelView.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 659);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leage management Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnTeam;
        private System.Windows.Forms.Button btnAltheletes;
        private System.Windows.Forms.Button btnMatches;
        private System.Windows.Forms.Button btnMatchUpdate;
        private System.Windows.Forms.Button btnLeagueResult;
        private System.Windows.Forms.Button btnRankingStatistic;
        private System.Windows.Forms.Button btnLeague;

        private System.Windows.Forms.Panel panelTitle;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel panelView;

        private System.Windows.Forms.FlowLayoutPanel panelMenu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}