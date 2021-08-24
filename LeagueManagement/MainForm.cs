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
using LeagueManagement.phuctx;
using LeagueManagement.sonnx;
using LeagueManagement.thaind;
using LeagueManagement.thaind.frontend;
using log4net;

namespace LeagueManagement
{
    public partial class MainForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));
        private Button currentButton;
        private static readonly Dictionary<string,Form> _listForm = new Dictionary<string, Form>();
        
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button) btnSender)
                {
                    DisableButton();
                    currentButton = (Button) btnSender;
                    currentButton.BackColor = Color.Aqua;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F,
                        System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
                    panelTitle.BackColor = Color.Coral;
                    
                }
            }
        }
        
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F,
                        System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
                }
            }
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Ranking View";
            panelView.Controls.Clear();
            var testFrame = new TestForm()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            panelView.Controls.Add(testFrame);
            testFrame.FormBorderStyle = FormBorderStyle.None;
            testFrame.Show();
        }

        private void btnLeague_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Quản lý giải đấu";
            panelView.Controls.Clear();
            var leagueFrame = new FormLeague()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            ApplyForm(leagueFrame, "btnLeauge");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DangNhap.GetMainForm().Show();
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Quản lý đội bóng";
            panelView.Controls.Clear();
            var teamFrame = new FormTeam()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            ApplyForm(teamFrame, "btnTeam");
        }

        private void btnAltheletes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Quản lý cầu thủ";
            panelView.Controls.Clear();
            var atheletesFrame = new FormAtheletes()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            ApplyForm(atheletesFrame, "btnAltheletes");
        }

        private void btnMatches_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Quản lý và xếp lịch trận đấu";
            panelView.Controls.Clear();
            var matchesFrame = new XepLich()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            ApplyForm(matchesFrame, "btnMatches");
        }

        private void btnMatchUpdate_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Cập nhật kết quả trận đấu";
            panelView.Controls.Clear();
            var updateResultFrame = new CapNhatTiSo()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            ApplyForm(updateResultFrame, "btnMatchesUpdate");
        }

        private void btnLeagueResult_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Xem kết quả giải đấu";
            panelView.Controls.Clear();
            var rankingViewForm = new LeagueRankingViewForm()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            ApplyForm(rankingViewForm, "btnRankingView");
        }


        private void btnRankingStatistic_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            lblTitle.Text = "Thống kê giải đấu";
            panelView.Controls.Clear();
            var statisticViewForm = new LeagueRankingStatisticViewForm()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            ApplyForm(statisticViewForm, "btnRankingStatistic");
        }

        private void ApplyForm(Form newForm, string key)
        {
            try
            {
                Form currentForm = null;
                if (_listForm.ContainsKey(key))
                {
                    var getOk = _listForm.TryGetValue(key, out var frameFromCache);
                    if (getOk)
                    {
                        currentForm = frameFromCache;
                        Log.Info($"Reuse form from cache with key: {key}");
                        currentForm.Close();

                        if (currentForm.IsDisposed || currentForm.Disposing)
                        {
                            Thread.Sleep(100);
                            currentForm = newForm;
                        }
                    }
                }
                else
                {
                    currentForm = newForm;
                    _listForm.Add(key, currentForm);
                }

                if (currentForm != null)
                {
                    panelView.Controls.Add(currentForm);
                    currentForm.FormBorderStyle = FormBorderStyle.None;
                    currentForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}