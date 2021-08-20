// @author duyenthai

using System;
using System.Data;
using System.Windows.Forms;
using LeagueManagement.thaind.backend;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using log4net;

namespace LeagueManagement.thaind.frontend
{
    public partial class LeagueRankingStatisticViewForm : Form
    {
        private static ILog Log = LogManager.GetLogger(typeof(LeagueRankingViewForm));

        public LeagueRankingStatisticViewForm()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLeague.SelectedValue == null || cbSeason.SelectedValue == null)
                {
                    MessageBox.Show("Bạn cần chọn đầy đủ thông tin về giải đấu", "Suggestion", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return;
                }

                var leagueId = Convert.ToInt32(cbLeague.SelectedValue);
                var seasonId = Convert.ToInt32(cbSeason.SelectedValue);

                var statistic = Statistic.FromLeagueSeason(leagueId, seasonId);

                LoadLeagueData(statistic);

                LoadRankingData(statistic);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("View error, trace: ", ex);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            DoLoad();
        }

        private void LeagueRankingStatisticViewForm_Load(object sender, EventArgs e)
        {
            DoLoad();
        }

        private void DoLoad()
        {
            var dbContext = DatabaseObject.GetDatabaseContext();
            cbLeague.DataSource = dbContext.DhLeagues.GetNewBindingList();
            cbLeague.DisplayMember = "name";
            cbLeague.ValueMember = "id";
            cbSeason.DataSource = dbContext.DhSeasons.GetNewBindingList();
            cbSeason.DisplayMember = "name";
            cbSeason.ValueMember = "id";

            ResetRankingData();
        }

        private void ResetRankingData()
        {
            lblLeague.Text = "";
            lblNation.Text = "";
            lblSeason.Text = "";
            lblDuration.Text = "";
            lblMatches.Text = "";
            lblGoals.Text = "";
            lblGoalPermatches.Text = "";

            try
            {
                ((DataTable) dgvRanking.DataSource)?.Rows.Clear();
                ((DataTable) dgvMostWin.DataSource)?.Rows.Clear();
                ((DataTable) dgvMostLost.DataSource)?.Rows.Clear();
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLeagueData(Statistic stat)
        {
            var dhLeague = stat.League;
            var dhSeason = stat.Season;
            var dhNation = stat.Nation;

            lblLeague.Text = dhLeague != null ? dhLeague.Name : "";
            lblNation.Text = dhNation != null ? dhNation.Name : "";
            lblSeason.Text = dhSeason != null ? dhSeason.Name : "";

            if (dhSeason != null)
            {
                var from = DateTimeOffset.FromUnixTimeMilliseconds(dhSeason.StartTime).ToString("dd/MM/yyyy");
                var to = DateTimeOffset.FromUnixTimeMilliseconds(dhSeason.EndTime).ToString("dd/MM/yyyy");
                var value = from + " tới " + to;
                lblDuration.Text = value;
            }

            lblMatches.Text = stat.PlayedMatches.ToString();
            lblGoals.Text = stat.AllGoals.ToString();
            var formattedValue = $"{stat.GoalPerMatches:F2}";
            lblGoalPermatches.Text = formattedValue;
            Log.Info(stat.GoalPerMatches);
        }

        private void LoadRankingData(Statistic stat)
        {
            dgvRanking.DataSource = stat.AllLeagueRanking;

            dgvMostWin.DataSource = stat.RankingMostWin;

            dgvMostLost.DataSource = stat.RankingMostLost;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLeague.SelectedValue == null || cbSeason.SelectedValue == null)
                {
                    MessageBox.Show("Bạn cần chọn đầy đủ thông tin về giải đấu", "Suggestion", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return;
                }

                var leagueId = Convert.ToInt32(cbLeague.SelectedValue);
                var seasonId = Convert.ToInt32(cbSeason.SelectedValue);

                var exportJob = new ExportAndSendEmailJob(leagueId, seasonId);
                BaseWorker.PubJob(typeof(ExportAndSendEmailWorker), -1, exportJob);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("View error, trace: ", ex);
            }
        }
    }
}