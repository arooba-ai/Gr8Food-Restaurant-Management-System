using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ManageUsersForm : Form
    {
        private UserSession  _session;
        private DataGridView _dgvUsers;
        private TextBox      _txtFullName;
        private TextBox      _txtPhone;
        private ComboBox     _cmbRole;
        private TextBox      _txtUsername;
        private TextBox      _txtPassword;
        private int          _selectedUserId;
        private bool         _loading;

        public ManageUsersForm(UserSession session)
        {
            _session = session;
            this.Text = "Gr8Food - Manage Users";
            this.Size = new Size(820, 532);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            BuildUI();
            LoadUsers();
        }

        private void BuildUI()
        {
            Color green = Color.FromArgb(0, 128, 0);
            Color darkGreen = Color.FromArgb(0, 100, 0);
            Font titleFont = new Font("Impact", 12);
            Font bodyFont = new Font("Microsoft Sans Serif", 8);

            Panel sidebar = new Panel();
            sidebar.BackColor = green;
            sidebar.Size = new Size(180, 532);
            sidebar.Location = new Point(0, 0);
            this.Controls.Add(sidebar);

            AddSidebarButton(sidebar, "Profile", 25, 120, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new frmProfile(_session).Show();
                this.Hide();
            });
            AddSidebarButton(sidebar, "Sales Report", 25, 165, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new SalesReportForm(_session).Show();
                this.Hide();
            });
            AddSidebarButton(sidebar, "Dashboard", 25, 210, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new AdminDashboardForm(_session).Show();
                this.Hide();
            });
            AddSidebarButton(sidebar, "Logout", 25, 255, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new frmloginpage().Show();
                this.Hide();
            });

            Label lblTitle = new Label();
            lblTitle.Text = "Manage Users";
            lblTitle.Font = titleFont;
            lblTitle.ForeColor = darkGreen;
            lblTitle.Location = new Point(210, 30);
            lblTitle.Size = new Size(180, 30);
            this.Controls.Add(lblTitle);

            // Row 1
            AddLabel("Full Name", 210, 75, bodyFont);
            _txtFullName = new TextBox();
            _txtFullName.Location = new Point(280, 72);
            _txtFullName.Size = new Size(130, 22);
            this.Controls.Add(_txtFullName);

            AddLabel("Phone", 430, 75, bodyFont);
            _txtPhone = new TextBox();
            _txtPhone.Location = new Point(480, 72);
            _txtPhone.Size = new Size(100, 22);
            this.Controls.Add(_txtPhone);

            AddLabel("Role", 600, 75, bodyFont);
            _cmbRole = new ComboBox();
            _cmbRole.Location = new Point(635, 72);
            _cmbRole.Size = new Size(110, 22);
            _cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbRole.Items.AddRange(new string[] { "System Admin", "Manager", "Chef", "Customer" });
            this.Controls.Add(_cmbRole);

            // Row 2
            AddLabel("Email", 210, 110, bodyFont);
            _txtUsername = new TextBox();
            _txtUsername.Location = new Point(280, 107);
            _txtUsername.Size = new Size(130, 22);
            this.Controls.Add(_txtUsername);

            AddLabel("Password", 430, 110, bodyFont);
            _txtPassword = new TextBox();
            _txtPassword.Location = new Point(490, 107);
            _txtPassword.Size = new Size(120, 22);
            this.Controls.Add(_txtPassword);

            // Buttons
            Button btnAdd = new Button();
            btnAdd.Text = "Add User";
            btnAdd.Location = new Point(210, 145);
            btnAdd.Size = new Size(80, 26);
            btnAdd.Font = bodyFont;
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            Button btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Location = new Point(300, 145);
            btnUpdate.Size = new Size(80, 26);
            btnUpdate.Font = bodyFont;
            btnUpdate.Click += BtnUpdate_Click;
            this.Controls.Add(btnUpdate);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(390, 145);
            btnDelete.Size = new Size(80, 26);
            btnDelete.Font = bodyFont;
            btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(btnDelete);

            Button btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Location = new Point(480, 145);
            btnClear.Size = new Size(80, 26);
            btnClear.Font = bodyFont;
            btnClear.Click += (s, e) => ClearFields();
            this.Controls.Add(btnClear);

            // DataGridView
            _dgvUsers = new DataGridView();
            _dgvUsers.Location = new Point(210, 190);
            _dgvUsers.Size = new Size(560, 255);
            _dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvUsers.ReadOnly = true;
            _dgvUsers.AllowUserToAddRows = false;
            _dgvUsers.RowHeadersVisible = false;
            _dgvUsers.MultiSelect = false;
            _dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            this.Controls.Add(_dgvUsers);
        }

        private void LoadUsers()
        {
            _loading = true;
            _dgvUsers.DataSource = new UserManager().LoadAllUsers();
            _dgvUsers.ClearSelection();
            _loading = false;
            ClearFields();
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            if (_dgvUsers.SelectedRows.Count == 0) return;
            DataGridViewRow row = _dgvUsers.SelectedRows[0];
            _selectedUserId   = Convert.ToInt32(row.Cells["UserID"].Value);
            _txtFullName.Text = row.Cells["FullName"].Value.ToString();
            _txtPhone.Text    = row.Cells["Phone"].Value?.ToString() ?? "";
            _cmbRole.Text     = row.Cells["Role"].Value.ToString();
            _txtUsername.Text = row.Cells["Username"].Value.ToString();
            _txtPassword.Text = "";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(_txtFullName.Text))
            { MessageBox.Show("Please enter the full name."); return false; }
            if (_cmbRole.SelectedIndex < 0)
            { MessageBox.Show("Please select a role."); return false; }
            if (string.IsNullOrWhiteSpace(_txtUsername.Text))
            { MessageBox.Show("Please enter an email address."); return false; }
            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            if (string.IsNullOrWhiteSpace(_txtPassword.Text))
            { MessageBox.Show("Please enter a password for the new user."); return; }

            UserManager um = new UserManager();

            if (um.EmailExists(_txtUsername.Text.Trim()))
            { MessageBox.Show("A user with this email already exists."); return; }

            if (!string.IsNullOrWhiteSpace(_txtPhone.Text) && um.PhoneExists(_txtPhone.Text.Trim()))
            { MessageBox.Show("A user with this phone number already exists."); return; }

            um.AddUser(_txtFullName.Text.Trim(), _txtPhone.Text.Trim(),
                       _cmbRole.Text, _txtUsername.Text.Trim(), _txtPassword.Text);
            MessageBox.Show("User added successfully.");
            LoadUsers();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0) { MessageBox.Show("Please select a user to update."); return; }
            if (!ValidateInputs()) return;

            UserManager um = new UserManager();

            if (um.EmailExists(_txtUsername.Text.Trim(), _selectedUserId))
            { MessageBox.Show("Another user with this email already exists."); return; }

            if (!string.IsNullOrWhiteSpace(_txtPhone.Text) && um.PhoneExists(_txtPhone.Text.Trim(), _selectedUserId))
            { MessageBox.Show("Another user with this phone number already exists."); return; }

            string pwd = string.IsNullOrWhiteSpace(_txtPassword.Text)
                ? GetCurrentPassword(_selectedUserId)
                : _txtPassword.Text;
            um.UpdateUser(_selectedUserId, _txtFullName.Text.Trim(), _txtPhone.Text.Trim(),
                          _cmbRole.Text, _txtUsername.Text.Trim(), pwd);
            MessageBox.Show("User updated successfully.");
            LoadUsers();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0) { MessageBox.Show("Please select a user to delete."); return; }
            if (_selectedUserId == _session.UserID)
            { MessageBox.Show("You cannot delete your own account."); return; }
            DialogResult confirm = MessageBox.Show(
                "Delete user '" + _txtFullName.Text + "'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            UserManager um = new UserManager();
            um.DeleteUser(_selectedUserId);
            MessageBox.Show("User deleted.");
            LoadUsers();
        }

        private void ClearFields()
        {
            _selectedUserId   = 0;
            _txtFullName.Text = "";
            _txtPhone.Text    = "";
            _cmbRole.SelectedIndex = -1;
            _txtUsername.Text = "";
            _txtPassword.Text = "";
        }

        private string GetCurrentPassword(int userId)
        {
            UserManager um = new UserManager();
            return um.GetPasswordById(userId);
        }

        private void AddSidebarButton(Panel parent, string text, int x, int y, int w, int h,
            Color back, Color fore, Font font, EventHandler click)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.BackColor = back;
            btn.ForeColor = fore;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.Font = font;
            if (click != null) btn.Click += click;
            parent.Controls.Add(btn);
        }

        private void AddLabel(string text, int x, int y, Font font)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = font;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(70, 18);
            this.Controls.Add(lbl);
        }
    }
}
