using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class frmFeedback : Form
    {
        private UserSession _session;

        public frmFeedback(UserSession session)
        {
            InitializeComponent();
            _session = session;
        }

        private void frmFeedback_Load(object sender, EventArgs e)
        {
            if (cmbRating.Items.Count == 0)
            {
                cmbRating.Items.AddRange(new object[]
                {
                    "1 Star", "2 Stars", "3 Stars", "4 Stars", "5 Stars"
                });
            }

            lblThankYou.Visible = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                MessageBox.Show("Please enter your feedback.");
                return;
            }

            if (cmbRating.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a rating.");
                return;
            }

            if (_session.UserID == 0)
            {
                MessageBox.Show("Session expired. Please log in again.");
                return;
            }

            string rating  = cmbRating.SelectedItem.ToString();
            string message = "[" + rating + "] " + txtFeedback.Text.Trim();

            OrderManager om      = new OrderManager();
            int          orderId = om.GetLatestOrderID(_session.UserID);

            if (orderId == 0)
            {
                MessageBox.Show("You need to place an order before submitting feedback.");
                return;
            }

            FeedbackManager fm = new FeedbackManager();
            fm.AddFeedback(_session.UserID, orderId, message);

            MessageBox.Show("Feedback submitted. Thank you!");

            txtFeedback.Clear();
            cmbRating.SelectedIndex = -1;
            lblThankYou.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmProfile fp = new frmProfile(_session);
            fp.Show();
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            frmCart fc = new frmCart(_session);
            fc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerDashboard cd = new CustomerDashboard(_session);
            cd.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmloginpage fl = new frmloginpage();
            fl.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void txtFeedback_TextChanged(object sender, EventArgs e) { }
    }
}
