using System;
using System.Data;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class frmProfile : Form
    {
        private UserSession _session;

        public frmProfile(UserSession session)
        {
            InitializeComponent();
            _session = session;
        }

        private void frmProfile_Load_1(object sender, EventArgs e)
        {
            LoadProfile();

            bool isCustomer = (_session != null && _session.Role == "Customer");
            btnCart.Visible    = isCustomer;
            picCartIcon.Visible = isCustomer;

            if (!isCustomer)
            {
                // Fill the empty Cart slot so spacing stays consistent
                picDashboardIcon.Location = new System.Drawing.Point(25, 243);
                btnDashboard.Location      = new System.Drawing.Point(74, 243);
                picLogoutSideIcon.Location  = new System.Drawing.Point(25, 314);
                btnLogout.Location    = new System.Drawing.Point(74, 314);
            }
        }

        private void LoadProfile()
        {
            UserManager um = new UserManager();
            DataTable dt = um.GetProfile(_session.Email);

            if (dt.Rows.Count > 0)
            {
                txtName.Text     = dt.Rows[0]["Name"].ToString();
                txtPhone.Text    = dt.Rows[0]["Phone"]?.ToString() ?? "";
                txtEmail.Text    = dt.Rows[0]["Email"].ToString();
                txtPassword.Text = dt.Rows[0]["Password"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            um.UpdateProfile(txtName.Text, txtPhone.Text, txtEmail.Text, txtPassword.Text);

            _session.Email = txtEmail.Text;
            _session.Name  = txtName.Text;

            MessageBox.Show("Profile Updated");
            LoadProfile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProfile();
            MessageBox.Show("Changes Cancelled");
        }

        private void button3_Click(object sender, EventArgs e) { }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (_session == null) return;

            Form dashboard;
            switch (_session.Role)
            {
                case "Admin":
                case "System Admin":
                    dashboard = new AdminDashboardForm(_session);
                    break;
                case "Chef":
                    dashboard = new ChefDashboardForm(_session);
                    break;
                case "Manager":
                    dashboard = new ManagerDashboardForm(_session);
                    break;
                default:
                    dashboard = new CustomerDashboard(_session);
                    break;
            }
            dashboard.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Already on Profile page
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            frmCart fc = new frmCart(_session);
            fc.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmloginpage fl = new frmloginpage();
            fl.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmloginpage fl = new frmloginpage();
            fl.Show();
            this.Hide();
        }

        private void pnlSidebar_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
    }
}
