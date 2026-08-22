using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class FeedbackForm : Form
    {
        private UserSession _session;
        private int feedbackID = 0;
        private FeedbackManager fm = new FeedbackManager();

        public FeedbackForm(UserSession session)
        {
            _session = session;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            if (_session != null)
                label1.Text = "Welcome, " + _session.Name + "!";

            dgvFeedbacks.AutoGenerateColumns  = false;
            dgvFeedbacks.AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFeedbacks.SelectionMode        = DataGridViewSelectionMode.FullRowSelect;
            dgvFeedbacks.ReadOnly             = true;
            dgvFeedbacks.AllowUserToAddRows   = false;
            dgvFeedbacks.RowHeadersVisible    = false;
            dgvFeedbacks.DataSource           = fm.LoadFeedbacks();

            cboStatus.Items.Add("Pending");
            cboStatus.Items.Add("Replied");
            cboStatus.SelectedIndex = 0;

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
            picLogo.BackgroundImage = (System.Drawing.Image)rm.GetObject("pictureBox1.BackgroundImage");
            picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            picLogo.BackColor = System.Drawing.Color.White;
            picLogo.Size      = new System.Drawing.Size(131, 72);
            picLogo.Location  = new System.Drawing.Point((panelSidebar.Width - 131) / 2, 10);

            // Welcome label — always below logo, never inside it
            label1.AutoSize  = true;
            label1.Location  = new System.Drawing.Point(10, picLogo.Bottom + 8);

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

        // SelectionChanged fires for both mouse clicks and keyboard navigation,
        // making it more reliable than CellContentClick for text-column grids.
        private void dgvFeedbacks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFeedbacks.SelectedRows.Count == 0)
            {
                feedbackID = 0;
                return;
            }

            DataRowView drv = dgvFeedbacks.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            feedbackID = Convert.ToInt32(drv.Row["FeedbackID"]);
        }

        private void btnWallet_Click(object sender, EventArgs e)
        {
            new WalletReportForm(_session).Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            new frmProfile(_session).Show();
            this.Hide();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on Feedback Page");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            new ManagerDashboardForm(_session).Show();
            this.Hide();
        }

        private void btnWallet_Click_1(object sender, EventArgs e)
        {
            new WalletReportForm(_session).Show();
            this.Hide();
        }

        private void btnFeedback_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Already on Feedback Page");
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            new ManagerDashboardForm(_session).Show();
            this.Hide();
        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            new frmProfile(_session).Show();
            this.Hide();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string date   = dtFeedbackDate.Value.Date.ToString("yyyy-MM-dd");
            string status = cboStatus.Text;

            DataTable dt = fm.FilterFeedbacks(date, status);
            dgvFeedbacks.DataSource = dt;

            if (dt.Rows.Count == 0)
                MessageBox.Show("No feedback found.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvFeedbacks.DataSource = fm.LoadFeedbacks();
            cboStatus.SelectedIndex = 0;
            dtFeedbackDate.Value = DateTime.Today;
        }

        private void btnReplyFeedback_Click(object sender, EventArgs e)
        {
            if (feedbackID == 0)
            {
                MessageBox.Show("Select a feedback first");
                return;
            }

            string reply = Interaction.InputBox("Enter Reply", "Reply Feedback", "");

            if (!string.IsNullOrWhiteSpace(reply))
            {
                fm.ReplyFeedback(feedbackID, reply);
                // Reset so the same record cannot be replied to again without re-selecting it
                feedbackID = 0;
                MessageBox.Show("Reply Sent");
                // Reload pulls the saved Reply text and updated Status from the database
                dgvFeedbacks.DataSource = fm.LoadFeedbacks();
            }
        }
    }
}
