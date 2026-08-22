using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class WalletReportForm : Form
    {
        private UserSession _session;

        public WalletReportForm(UserSession session)
        {
            _session = session;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dtWalletDate_ValueChanged(object sender, EventArgs e) { }

        private void Wallet_Report_Load(object sender, EventArgs e)
        {
            if (_session != null)
                label1.Text = "Welcome, " + _session.Name + "!";

            WalletManager wm = new WalletManager();

            dgvWalletReport.AutoGenerateColumns  = false;
            dgvWalletReport.SelectionMode        = DataGridViewSelectionMode.FullRowSelect;
            dgvWalletReport.ReadOnly             = true;
            dgvWalletReport.AllowUserToAddRows   = false;
            dgvWalletReport.RowHeadersVisible    = false;
            dgvWalletReport.DataSource           = wm.LoadWalletReports();
            dgvWalletReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWalletReport.ReadOnly = true;
            dgvWalletReport.AllowUserToAddRows = false;
            dgvWalletReport.RowHeadersVisible = false;

            cboCustomer.DataSource = wm.LoadCustomers();
            cboCustomer.DisplayMember = "Name";
            cboCustomer.ValueMember = "UserID";
            cboCustomer.SelectedIndex = -1;

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

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            new ManagerDashboardForm(_session).Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            new frmProfile(_session).Show();
            this.Hide();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            new FeedbackForm(_session).Show();
            this.Hide();
        }

        private void btnWallet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on Wallet Report");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex < 0 || cboCustomer.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer to filter.");
                return;
            }
            WalletManager wm = new WalletManager();
            int customerID = Convert.ToInt32(cboCustomer.SelectedValue);
            string selectedDate = dtWalletDate.Value.ToString("yyyy-MM-dd");
            dgvWalletReport.DataSource = wm.FilterWalletReports(customerID, selectedDate);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            WalletManager wm = new WalletManager();
            dgvWalletReport.DataSource = wm.LoadWalletReports();
            cboCustomer.SelectedIndex = -1;
        }
    }
}
