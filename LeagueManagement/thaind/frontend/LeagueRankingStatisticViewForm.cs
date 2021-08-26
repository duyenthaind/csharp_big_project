// @author duyenthai

using System;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using LeagueManagement.thaind.backend;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using log4net;

namespace LeagueManagement.thaind.frontend
{
    public partial class LeagueRankingStatisticViewForm : Form
    {
        private static ILog Log = LogManager.GetLogger(typeof(LeagueRankingStatisticViewForm));

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
            try
            {
                var dbContext = DatabaseObject.GetDatabaseContext();
                cbLeague.DataSource = dbContext.DhLeagues.GetNewBindingList();
                cbLeague.DisplayMember = "name";
                cbLeague.ValueMember = "id";
                cbSeason.DataSource = dbContext.DhSeasons.GetNewBindingList();
                cbSeason.DisplayMember = "name";
                cbSeason.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

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

                string emailTo = EnterEmail();

                if (!string.IsNullOrEmpty(emailTo) && IsEmail(emailTo))
                {
                    exportJob.Email = emailTo;
                }
                else
                {
                    MessageBox.Show("Không có email phù hợp, bạn sẽ không nhận được mail báo cáo từ chúng tôi",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                BaseWorker.PubJob(typeof(ExportAndSendEmailWorker), -1, exportJob);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("View error, trace: ", ex);
            }
        }

        private string EnterEmail()
        {
            var prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Nhập mail nếu bạn muốn nhận báo cáo qua email",
                StartPosition = FormStartPosition.CenterScreen
            };
            var textLabel = new Label() {Left = 50, Top = 20, Text = "Gửi cho tôi"};
            var textBox = new TextBox() {Left = 50, Top = 50, Width = 400};
            var confirmation = new Button()
                {Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK};
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public bool IsEmail(string emailAddress)
        {
            try
            {
                var mail = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException ex)
            {
                Log.Error("Error", ex);
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}