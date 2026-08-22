using System;
using System.Data;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class frmloginpage : Form
    {
        public frmloginpage()
        {
            InitializeComponent();
        }

        private void frmloginpage_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            txtEmail.Enter    += txtEmail_Enter;
            txtEmail.Leave    += txtEmail_Leave;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email:")
            {
                txtEmail.Text      = "";
                txtEmail.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text      = "Email:";
                txtEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password:")
            {
                txtPassword.Text      = "";
                txtPassword.ForeColor = System.Drawing.Color.Black;
                if (!checkBox1.Checked)
                    txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.Text         = "Password:";
                txtPassword.ForeColor    = System.Drawing.SystemColors.ControlDarkDark;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "Password:")
                txtPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email    = txtEmail.Text    == "Email:"    ? "" : txtEmail.Text.Trim();
            string password = txtPassword.Text == "Password:" ? "" : txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            UserManager um = new UserManager();
            DataTable dt = um.GetUserByCredentials(email, password);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid email or password.");
                return;
            }

            int    userId = Convert.ToInt32(dt.Rows[0]["UserID"]);
            string name   = dt.Rows[0]["Name"].ToString();
            string role   = dt.Rows[0]["Role"].ToString();

            UserSession session = new UserSession(userId, name, email, role);

            switch (role)
            {
                case "Customer":
                    MessageBox.Show("Customer Login Successful");
                    new CustomerDashboard(session).Show();
                    this.Hide();
                    break;

                case "Chef":
                    MessageBox.Show("Chef Login Successful");
                    new ChefDashboardForm(session).Show();
                    this.Hide();
                    break;

                case "Admin":
                case "System Admin":
                    MessageBox.Show("Admin Login Successful");
                    new AdminDashboardForm(session).Show();
                    this.Hide();
                    break;

                case "Manager":
                    MessageBox.Show("Manager Login Successful");
                    new ManagerDashboardForm(session).Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("Unknown role: " + role + ". Please contact support.");
                    break;
            }
        }
    }
}
