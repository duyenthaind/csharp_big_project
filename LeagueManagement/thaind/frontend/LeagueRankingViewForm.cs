// @author duyenthai

using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using LeagueManagement.thaind.backend;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using log4net;

namespace LeagueManagement.thaind.frontend
{
    public partial class LeagueRankingViewForm : Form
    {
        private static ILog Log = LogManager.GetLogger(typeof(LeagueRankingViewForm));

        private DhLeagueRankingDAO _leagueRankingDao = new DhLeagueRankingDAO();

        private static bool _runningAutoLoad = false;

        private static int _currentLeagueId = 0;
        private static int _currentSeasonId = 0;

        public LeagueRankingViewForm()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
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

                _currentLeagueId = leagueId;
                _currentSeasonId = seasonId;

                LoadRankingData(leagueId, seasonId);

                lblMessage.Text = "Kết quả dưới đây vẫn đang được cập nhật, reload để xem thông tin mới";
                lblMessage.ForeColor = Color.Red;
                // AutoReload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("View error, trace: ", ex);
            }
        }

        private void btnReCalculate_Click(object sender, EventArgs e)
        {
            ResetRankingData();

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

                var workJob = new HardResetRankingJob(leagueId, seasonId);
                workJob.LblMessage = lblMessage;
                BaseWorker.PubJob(typeof(HardResetRankingWorker), -1, workJob);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Reset all ranking error, trace: ", ex);
            }
        }

        private void btnViewTemp_Click(object sender, EventArgs e)
        {
            ResetRankingData();
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

                lblMessage.Text = "Đây là thông tin về kết quả hiện tại về giải đấu";

                LoadLeagueData(leagueId, seasonId);

                dgvRanking.DataSource = DbUtil.GetTemporaryRankingByLeagueSeasonId(leagueId, seasonId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("View all temp ranking error, trace: ", ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoLoad();
        }

        private void LeagueRankingViewForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine();
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
            _runningAutoLoad = false;
            lblLeagueName.Text = "";
            lblNationName.Text = "";
            lblSeasonName.Text = "";
            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Black;
            try
            {
                ((DataTable) dgvRanking.DataSource)?.Rows.Clear();
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutoReload()
        {
            _runningAutoLoad = true;
            lblMessage.Text = "Kết quả giải đấu sẽ được chúng tôi cập nhật mỗi 30 giây";
            lblMessage.ForeColor = Color.Red;
            try
            {
                var thread = new Thread(new ThreadStart(this.SleepThenLoad));
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error auto reload result: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadLeagueData(int leagueId, int seasonId)
        {
            var dhLeague = DbUtil.GetLeagueById(leagueId);
            var dhSeason = DbUtil.GetSeasonById(seasonId);
            if (dhLeague != null)
            {
                lblLeagueName.Text = dhLeague.Name;
                var dhNation = DbUtil.GetNationById(dhLeague.NationId);
                lblNationName.Text = dhNation != null ? dhNation.Name : "";
            }

            lblSeasonName.Text = dhSeason != null ? dhSeason.Name : "";
        }

        private void LoadRankingData(int leagueId, int seasonId)
        {
            LoadLeagueData(leagueId, seasonId);

            dgvRanking.DataSource = _leagueRankingDao.GetDataTableAllRankingByLeagueSeasonId(leagueId, seasonId);
        }

        private void SleepThenLoad()
        {
            while (_runningAutoLoad)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                LoadRankingData(_currentLeagueId, _currentSeasonId);
                Log.Info("Reload result at : " + DateTime.UtcNow);
            }

            Log.Info("Stopped loop autoload!!!");
        }

        private void LeagueRankingViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _runningAutoLoad = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}