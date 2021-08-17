using System.ComponentModel;

namespace LeagueManagement.thaind.frontend
{
    partial class LeagueRankingViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numWin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDraw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playedMatches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numGoalScored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numGoalReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblSeasonName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNationName = new System.Windows.Forms.Label();
            this.lblLeagueName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReCalculate = new System.Windows.Forms.Button();
            this.btnViewTemp = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSeason = new System.Windows.Forms.ComboBox();
            this.cbLeague = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvRanking)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvRanking, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 583);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvRanking
            // 
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.position, this.teamName, this.point, this.numWin, this.numDraw, this.numLost, this.playedMatches, this.numGoalScored, this.numGoalReceived, this.difference});
            this.dgvRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRanking.Location = new System.Drawing.Point(3, 264);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.Size = new System.Drawing.Size(870, 316);
            this.dgvRanking.TabIndex = 2;
            // 
            // position
            // 
            this.position.DataPropertyName = "rowNum";
            this.position.HeaderText = "Xếp hạng";
            this.position.Name = "position";
            // 
            // teamName
            // 
            this.teamName.DataPropertyName = "name";
            this.teamName.HeaderText = "Tên đội";
            this.teamName.Name = "teamName";
            // 
            // point
            // 
            this.point.DataPropertyName = "point";
            this.point.HeaderText = "Số điểm";
            this.point.Name = "point";
            // 
            // numWin
            // 
            this.numWin.DataPropertyName = "num_win";
            this.numWin.HeaderText = "Số trận thắng";
            this.numWin.Name = "numWin";
            // 
            // numDraw
            // 
            this.numDraw.DataPropertyName = "num_draw";
            this.numDraw.HeaderText = "Số trận hòa";
            this.numDraw.Name = "numDraw";
            // 
            // numLost
            // 
            this.numLost.DataPropertyName = "num_lost";
            this.numLost.HeaderText = "Số trận thua";
            this.numLost.Name = "numLost";
            // 
            // playedMatches
            // 
            this.playedMatches.DataPropertyName = "played_matches";
            this.playedMatches.HeaderText = "Số trận đã chơi";
            this.playedMatches.Name = "playedMatches";
            // 
            // numGoalScored
            // 
            this.numGoalScored.DataPropertyName = "num_goal_scored";
            this.numGoalScored.HeaderText = "Số bàn thắng";
            this.numGoalScored.Name = "numGoalScored";
            // 
            // numGoalReceived
            // 
            this.numGoalReceived.DataPropertyName = "num_goal_received";
            this.numGoalReceived.HeaderText = "Số bàn thua";
            this.numGoalReceived.Name = "numGoalReceived";
            // 
            // difference
            // 
            this.difference.DataPropertyName = "difference";
            this.difference.HeaderText = "Hiệu số";
            this.difference.Name = "difference";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.lblSeasonName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblNationName);
            this.panel1.Controls.Add(this.lblLeagueName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 139);
            this.panel1.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(538, 11);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(329, 23);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "label6";
            // 
            // lblSeasonName
            // 
            this.lblSeasonName.Location = new System.Drawing.Point(128, 99);
            this.lblSeasonName.Name = "lblSeasonName";
            this.lblSeasonName.Size = new System.Drawing.Size(202, 28);
            this.lblSeasonName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mùa giải";
            // 
            // lblNationName
            // 
            this.lblNationName.Location = new System.Drawing.Point(128, 53);
            this.lblNationName.Name = "lblNationName";
            this.lblNationName.Size = new System.Drawing.Size(202, 28);
            this.lblNationName.TabIndex = 1;
            // 
            // lblLeagueName
            // 
            this.lblLeagueName.Location = new System.Drawing.Point(128, 11);
            this.lblLeagueName.Name = "lblLeagueName";
            this.lblLeagueName.Size = new System.Drawing.Size(202, 28);
            this.lblLeagueName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quốc gia";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên giải đấu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReCalculate);
            this.panel2.Controls.Add(this.btnViewTemp);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbSeason);
            this.panel2.Controls.Add(this.cbLeague);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 110);
            this.panel2.TabIndex = 1;
            // 
            // btnReCalculate
            // 
            this.btnReCalculate.Location = new System.Drawing.Point(526, 9);
            this.btnReCalculate.Name = "btnReCalculate";
            this.btnReCalculate.Size = new System.Drawing.Size(75, 72);
            this.btnReCalculate.TabIndex = 2;
            this.btnReCalculate.Text = "Tính toán lại kết quả giải đấu";
            this.btnReCalculate.UseVisualStyleBackColor = true;
            this.btnReCalculate.Click += new System.EventHandler(this.btnReCalculate_Click);
            // 
            // btnViewTemp
            // 
            this.btnViewTemp.Location = new System.Drawing.Point(607, 8);
            this.btnViewTemp.Name = "btnViewTemp";
            this.btnViewTemp.Size = new System.Drawing.Size(75, 72);
            this.btnViewTemp.TabIndex = 2;
            this.btnViewTemp.Text = "Xem kết quả tạm thời";
            this.btnViewTemp.UseVisualStyleBackColor = true;
            this.btnViewTemp.Click += new System.EventHandler(this.btnViewTemp_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(688, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 72);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Tải lại";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(445, 9);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 72);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "Xem kết quả";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(58, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mùa giải";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Giải đấu";
            // 
            // cbSeason
            // 
            this.cbSeason.FormattingEnabled = true;
            this.cbSeason.Location = new System.Drawing.Point(157, 60);
            this.cbSeason.Name = "cbSeason";
            this.cbSeason.Size = new System.Drawing.Size(173, 21);
            this.cbSeason.TabIndex = 0;
            // 
            // cbLeague
            // 
            this.cbLeague.FormattingEnabled = true;
            this.cbLeague.Location = new System.Drawing.Point(157, 9);
            this.cbLeague.Name = "cbLeague";
            this.cbLeague.Size = new System.Drawing.Size(173, 21);
            this.cbLeague.TabIndex = 0;
            // 
            // LeagueRankingViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 583);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LeagueRankingViewForm";
            this.Text = "LeagueRankingViewForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LeagueRankingViewForm_FormClosed);
            this.Load += new System.EventHandler(this.LeagueRankingViewForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvRanking)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnViewTemp;

        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Label lblMessage;

        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn point;
        private System.Windows.Forms.DataGridViewTextBoxColumn numWin;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDraw;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn playedMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn numGoalScored;
        private System.Windows.Forms.DataGridViewTextBoxColumn numGoalReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn difference;

        private System.Windows.Forms.ComboBox cbLeague;
        private System.Windows.Forms.ComboBox cbSeason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLeagueName;
        private System.Windows.Forms.Label lblNationName;
        private System.Windows.Forms.Label lblSeasonName;
        
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnReCalculate;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}