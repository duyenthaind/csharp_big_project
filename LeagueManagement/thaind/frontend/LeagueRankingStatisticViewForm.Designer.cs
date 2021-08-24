using System.ComponentModel;

namespace LeagueManagement.thaind.frontend
{
    partial class LeagueRankingStatisticViewForm
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMostLost = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvMostWin = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSeason = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGoalPermatches = new System.Windows.Forms.Label();
            this.lblGoals = new System.Windows.Forms.Label();
            this.lblMatches = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblLeague = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSeason = new System.Windows.Forms.ComboBox();
            this.cbLeague = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvRanking)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvMostLost)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvMostWin)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(841, 706);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 425);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(835, 29);
            this.panel6.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xếp hạng toàn cục";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 302);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(835, 29);
            this.panel5.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thứ hạng các đội thua nhiều nhất";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRanking);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 243);
            this.panel1.TabIndex = 0;
            // 
            // dgvRanking
            // 
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.position, this.teamName, this.point, this.numWin, this.numDraw, this.numLost, this.playedMatches, this.numGoalScored, this.numGoalReceived, this.difference});
            this.dgvRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRanking.Location = new System.Drawing.Point(0, 0);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.Size = new System.Drawing.Size(835, 243);
            this.dgvRanking.TabIndex = 3;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMostLost);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 337);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(835, 82);
            this.panel2.TabIndex = 1;
            // 
            // dgvMostLost
            // 
            this.dgvMostLost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostLost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10});
            this.dgvMostLost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMostLost.Location = new System.Drawing.Point(0, 0);
            this.dgvMostLost.Name = "dgvMostLost";
            this.dgvMostLost.Size = new System.Drawing.Size(835, 82);
            this.dgvMostLost.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "rowNum";
            this.dataGridViewTextBoxColumn1.HeaderText = "Xếp hạng";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên đội";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "point";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số điểm";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "num_win";
            this.dataGridViewTextBoxColumn4.HeaderText = "Số trận thắng";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "num_draw";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số trận hòa";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "num_lost";
            this.dataGridViewTextBoxColumn6.HeaderText = "Số trận thua";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "played_matches";
            this.dataGridViewTextBoxColumn7.HeaderText = "Số trận đã chơi";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "num_goal_scored";
            this.dataGridViewTextBoxColumn8.HeaderText = "Số bàn thắng";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "num_goal_received";
            this.dataGridViewTextBoxColumn9.HeaderText = "Số bàn thua";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "difference";
            this.dataGridViewTextBoxColumn10.HeaderText = "Hiệu số";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMostWin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 214);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(835, 82);
            this.panel3.TabIndex = 2;
            // 
            // dgvMostWin
            // 
            this.dgvMostWin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostWin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.dataGridViewTextBoxColumn13, this.dataGridViewTextBoxColumn14, this.dataGridViewTextBoxColumn15, this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17, this.dataGridViewTextBoxColumn18, this.dataGridViewTextBoxColumn19, this.dataGridViewTextBoxColumn20});
            this.dgvMostWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMostWin.Location = new System.Drawing.Point(0, 0);
            this.dgvMostWin.Name = "dgvMostWin";
            this.dgvMostWin.Size = new System.Drawing.Size(835, 82);
            this.dgvMostWin.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "rowNum";
            this.dataGridViewTextBoxColumn11.HeaderText = "Xếp hạng";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn12.HeaderText = "Tên đội";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "point";
            this.dataGridViewTextBoxColumn13.HeaderText = "Số điểm";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "num_win";
            this.dataGridViewTextBoxColumn14.HeaderText = "Số trận thắng";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "num_draw";
            this.dataGridViewTextBoxColumn15.HeaderText = "Số trận hòa";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "num_lost";
            this.dataGridViewTextBoxColumn16.HeaderText = "Số trận thua";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "played_matches";
            this.dataGridViewTextBoxColumn17.HeaderText = "Số trận đã chơi";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "num_goal_scored";
            this.dataGridViewTextBoxColumn18.HeaderText = "Số bàn thắng";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "num_goal_received";
            this.dataGridViewTextBoxColumn19.HeaderText = "Số bàn thua";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "difference";
            this.dataGridViewTextBoxColumn20.HeaderText = "Hiệu số";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Controls.Add(this.lblDuration);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.lblSeason);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.lblNation);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lblGoalPermatches);
            this.panel4.Controls.Add(this.lblGoals);
            this.panel4.Controls.Add(this.lblMatches);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.lblLeague);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.btnReload);
            this.panel4.Controls.Add(this.btnFind);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cbSeason);
            this.panel4.Controls.Add(this.cbLeague);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(835, 205);
            this.panel4.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(231, 115);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 45);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(155, 115);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 45);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Xuất excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(429, 170);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(154, 23);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "duration";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(323, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 7;
            this.label12.Text = "Thời gian";
            // 
            // lblSeason
            // 
            this.lblSeason.Location = new System.Drawing.Point(429, 138);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(154, 23);
            this.lblSeason.TabIndex = 7;
            this.lblSeason.Text = "season";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(323, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 7;
            this.label10.Text = "Mùa giải";
            // 
            // lblNation
            // 
            this.lblNation.Location = new System.Drawing.Point(429, 99);
            this.lblNation.Name = "lblNation";
            this.lblNation.Size = new System.Drawing.Size(154, 23);
            this.lblNation.TabIndex = 7;
            this.lblNation.Text = "nation";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(323, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Quốc gia";
            // 
            // lblGoalPermatches
            // 
            this.lblGoalPermatches.Location = new System.Drawing.Point(739, 137);
            this.lblGoalPermatches.Name = "lblGoalPermatches";
            this.lblGoalPermatches.Size = new System.Drawing.Size(60, 23);
            this.lblGoalPermatches.TabIndex = 7;
            this.lblGoalPermatches.Text = "goal/match";
            // 
            // lblGoals
            // 
            this.lblGoals.Location = new System.Drawing.Point(739, 99);
            this.lblGoals.Name = "lblGoals";
            this.lblGoals.Size = new System.Drawing.Size(60, 23);
            this.lblGoals.TabIndex = 7;
            this.lblGoals.Text = "goals";
            // 
            // lblMatches
            // 
            this.lblMatches.Location = new System.Drawing.Point(739, 70);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(60, 23);
            this.lblMatches.TabIndex = 7;
            this.lblMatches.Text = "matches";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(619, 137);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 23);
            this.label18.TabIndex = 7;
            this.label18.Text = "Bàn thắng/trận";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(619, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.label16.TabIndex = 7;
            this.label16.Text = "Số bàn thắng";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(619, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 7;
            this.label14.Text = "Số trận đã đá";
            // 
            // lblLeague
            // 
            this.lblLeague.Location = new System.Drawing.Point(429, 66);
            this.lblLeague.Name = "lblLeague";
            this.lblLeague.Size = new System.Drawing.Size(154, 23);
            this.lblLeague.TabIndex = 7;
            this.lblLeague.Text = "league";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(323, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giải đấu";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(79, 115);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(70, 45);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(5, 115);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(68, 45);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Xem kết quả";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mùa giải";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giải đấu";
            // 
            // cbSeason
            // 
            this.cbSeason.FormattingEnabled = true;
            this.cbSeason.Location = new System.Drawing.Point(106, 88);
            this.cbSeason.Name = "cbSeason";
            this.cbSeason.Size = new System.Drawing.Size(173, 21);
            this.cbSeason.TabIndex = 2;
            // 
            // cbLeague
            // 
            this.cbLeague.FormattingEnabled = true;
            this.cbLeague.Location = new System.Drawing.Point(106, 61);
            this.cbLeague.Name = "cbLeague";
            this.cbLeague.Size = new System.Drawing.Size(173, 21);
            this.cbLeague.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(3, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thứ hạng các đội thắng nhiều nhất";
            // 
            // LeagueRankingStatisticViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(841, 706);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "LeagueRankingStatisticViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LeagueRankingStatisticViewForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvRanking)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvMostLost)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvMostWin)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.Label lblGoalPermatches;

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblLeague;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblNation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnReload;

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSeason;

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMatches;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSeason;
        private System.Windows.Forms.ComboBox cbLeague;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGoals;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.DataGridView dgvMostWin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvMostLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}