using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class CustomerDashboard : Form
    {
        private UserSession _session;

        public CustomerDashboard(UserSession session)
        {
            InitializeComponent();
            _session = session;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_session.Name))
                lblWelcome.Text = "Welcome,\n" + _session.Name;

            RefreshBalance();

            SubscribePanelClick(pnlMenuCard, OpenMenu);
            SubscribePanelClick(pnlFeedbackCard, OpenFeedback);
            SubscribePanelClick(pnlOrderCard, OpenOrderStatus);

            btnLogout.Click += (s, ev) => { new frmloginpage().Show(); this.Hide(); };
        }

        private void SubscribePanelClick(Panel panel, Action action)
        {
            panel.Click += (s, e) => action();
            foreach (Control c in panel.Controls)
                c.Click += (s, e) => action();
        }

        private void RefreshBalance()
        {
            if (_session.UserID == 0) return;
            WalletManager wm = new WalletManager();
            decimal balance = wm.GetWalletBalance(_session.UserID);
            lblWallet.Text = "RM " + balance.ToString("F2");
        }

        private void btnTopUp_Click_1(object sender, EventArgs e)
        {
            if (cmbPayment.SelectedIndex < 0 ||
                cmbPayment.Text == "Select Payment" ||
                string.IsNullOrWhiteSpace(cmbPayment.Text))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount greater than 0.");
                return;
            }

            try
            {
                WalletManager wm = new WalletManager();
                wm.AddToBalance(_session.UserID, amount);
                wm.AddTransaction(_session.UserID, amount, "TopUp");

                RefreshBalance();

                MessageBox.Show("Top Up Successful!\nRM " + amount.ToString("F2") +
                                " added to your wallet.");

                txtAmount.Clear();
                cmbPayment.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Top Up failed: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMenu()
        {
            frmMenu fm = new frmMenu(_session);
            fm.Show();
            this.Hide();
        }

        private void OpenFeedback()
        {
            frmFeedback fb = new frmFeedback(_session);
            fb.Show();
            this.Hide();
        }

        private void OpenOrderStatus()
        {
            frmOrderStatus os = new frmOrderStatus(_session);
            os.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void btnCart_Click(object sender, EventArgs e)
        {
            frmCart fc = new frmCart(_session);
            fc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProfile fp = new frmProfile(_session);
            fp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Already on Dashboard
        }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e) { }

        private void lblWallet_Click(object sender, EventArgs e) { }
    }
}
