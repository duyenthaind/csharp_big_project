using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeagueManagement.thaind;

namespace LeagueManagement
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        
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
    }
}