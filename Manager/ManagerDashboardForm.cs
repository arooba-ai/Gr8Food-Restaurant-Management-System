using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ManagerDashboardForm : Form
    {
        private UserSession _session;

        public ManagerDashboardForm(UserSession session)
        {
            _session = session;
            InitializeComponent();
        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            lblDateTime.Text = today.ToString("dddd, dd MMMM yyyy");

            if (_session != null)
                lblWelcome.Text = "Welcome, " + _session.Name + "!";

            WalletManager wm = new WalletManager();
            lblTopupAmount.Text = "RM " + wm.GetTotalTopups(today);
            lblUsageAmount.Text = "RM " + wm.GetTotalUsage(today);

            FeedbackManager fm = new FeedbackManager();
            dgvRecentFeedback.DataSource = fm.LoadRecentFeedbacks(today);
            dgvRecentFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentFeedback.ReadOnly = true;
            dgvRecentFeedback.AllowUserToAddRows = false;
            dgvRecentFeedback.RowHeadersVisible = false;

            btnLogout.Click += (s, ev) =>
            {
                new frmloginpage().Show();
                this.Hide();
            };

            LoadSidebarIcons();
        }

        private void LoadSidebarIcons()
        {
            // Logo — 131×72 (75% of 175×96), white background, centered, clear of all other controls
            var rm = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            picProfile.BackgroundImage = (System.Drawing.Image)rm.GetObject("pictureBox1.BackgroundImage");
            picProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            picProfile.BackColor = System.Drawing.Color.White;
            picProfile.Size     = new System.Drawing.Size(131, 72);
            picProfile.Location = new System.Drawing.Point((panelSidebar.Width - 131) / 2, 10);

            // Welcome label — always below logo, never inside it
            lblWelcome.AutoSize  = true;
            lblWelcome.Location  = new System.Drawing.Point(10, picProfile.Bottom + 8);

            // label1 is a leftover designer control — clear it so nothing renders behind the logo
            label1.Text = "";

            // Sidebar nav icons
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox8.Image = LoadIcon("icons8-dashboard-24.png");
            pictureBox7.Image = LoadIcon("icons8-profile-30.png");
            pictureBox6.Image = LoadIcon("icons8-wallet-34.png");
            pictureBox4.Image = LoadIcon("icons8-request-feedback-48.png");
            pictureBox5.Image = LoadIcon("icons8-logout-50.png");
        }

        private static Image LoadIcon(string filename)
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "Manager", "Resources", filename);
                if (File.Exists(path)) return Image.FromFile(path);
            }
            catch { }
            return null;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label6_Click_1(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void panelTopup_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void panelUsage_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void picProfile_Click(object sender, EventArgs e) { }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfile fp = new frmProfile(_session);
            fp.Show();
            this.Hide();
        }

        private void btnWallet_Click(object sender, EventArgs e)
        {
            WalletReportForm wf = new WalletReportForm(_session);
            wf.Show();
            this.Hide();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            FeedbackForm ff = new FeedbackForm(_session);
            ff.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on Dashboard");
        }
    }
}
