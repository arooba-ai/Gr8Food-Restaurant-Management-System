using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ManageMenuForm : Form
    {
        private UserSession  _session;
        private DataGridView _dgvMenu;
        private TextBox      _txtMenuName;
        private ComboBox     _cmbCategory;
        private TextBox      _txtPrice;
        private ComboBox     _cmbAvailability;
        private int          _selectedMenuId;

        public ManageMenuForm(UserSession session)
        {
            _session = session;
            this.Text = "Gr8Food - Menu Management";
            this.Size = new Size(820, 532);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            BuildUI();
            LoadMenu();
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

            AddSidebarButton(sidebar, "Profile", 25, 70, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new frmProfile(_session).Show();
                this.Hide();
            });
            AddSidebarButton(sidebar, "Orders", 25, 115, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new ChefOrdersForm(_session).Show();
                this.Hide();
            });
            AddSidebarButton(sidebar, "Dashboard", 25, 160, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new ChefDashboardForm(_session).Show();
                this.Hide();
            });
            AddSidebarButton(sidebar, "Logout", 25, 205, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new frmloginpage().Show();
                this.Hide();
            });

            Label lblTitle = new Label();
            lblTitle.Text = "Manage Menu";
            lblTitle.Font = titleFont;
            lblTitle.ForeColor = darkGreen;
            lblTitle.Location = new Point(210, 30);
            lblTitle.Size = new Size(180, 30);
            this.Controls.Add(lblTitle);

            // Row 1 — Food Name
            Label lblMenuName = new Label();
            lblMenuName.Text = "Food Name";
            lblMenuName.Font = bodyFont;
            lblMenuName.Location = new Point(210, 75);
            this.Controls.Add(lblMenuName);

            _txtMenuName = new TextBox();
            _txtMenuName.Location = new Point(280, 72);
            _txtMenuName.Size = new Size(100, 22);
            this.Controls.Add(_txtMenuName);

            // Category
            Label lblCategory = new Label();
            lblCategory.Text = "Category";
            lblCategory.Font = bodyFont;
            lblCategory.Location = new Point(395, 75);
            this.Controls.Add(lblCategory);

            _cmbCategory = new ComboBox();
            _cmbCategory.Location = new Point(455, 72);
            _cmbCategory.Size = new Size(100, 22);
            _cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbCategory.Items.AddRange(new string[] { "Breakfast", "Lunch", "Dinner", "Snacks", "Drinks",
                                                       "Burgers", "Pizza", "Desserts" });
            this.Controls.Add(_cmbCategory);

            // Row 2 — Price
            Label lblPrice = new Label();
            lblPrice.Text = "Price";
            lblPrice.Font = bodyFont;
            lblPrice.Location = new Point(210, 108);
            this.Controls.Add(lblPrice);

            _txtPrice = new TextBox();
            _txtPrice.Location = new Point(280, 105);
            _txtPrice.Size = new Size(80, 22);
            this.Controls.Add(_txtPrice);

            // Availability
            Label lblAvailability = new Label();
            lblAvailability.Text = "Availability";
            lblAvailability.Font = bodyFont;
            lblAvailability.Location = new Point(395, 108);
            this.Controls.Add(lblAvailability);

            _cmbAvailability = new ComboBox();
            _cmbAvailability.Location = new Point(455, 105);
            _cmbAvailability.Size = new Size(100, 22);
            _cmbAvailability.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbAvailability.Items.AddRange(new string[] { "Available", "Not Available" });
            this.Controls.Add(_cmbAvailability);

            // Action buttons
            Button btnAdd = new Button();
            btnAdd.Text = "Add";
            btnAdd.Location = new Point(580, 72);
            btnAdd.Size = new Size(55, 25);
            btnAdd.Font = bodyFont;
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            Button btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Location = new Point(645, 72);
            btnUpdate.Size = new Size(60, 25);
            btnUpdate.Font = bodyFont;
            btnUpdate.Click += BtnUpdate_Click;
            this.Controls.Add(btnUpdate);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(715, 72);
            btnDelete.Size = new Size(60, 25);
            btnDelete.Font = bodyFont;
            btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(btnDelete);

            // DataGridView
            _dgvMenu = new DataGridView();
            _dgvMenu.Location = new Point(210, 148);
            _dgvMenu.Size = new Size(560, 300);
            _dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvMenu.ReadOnly = true;
            _dgvMenu.AllowUserToAddRows = false;
            _dgvMenu.RowHeadersVisible = false;
            _dgvMenu.MultiSelect = false;
            _dgvMenu.SelectionChanged += DgvMenu_SelectionChanged;
            this.Controls.Add(_dgvMenu);
        }

        private void LoadMenu()
        {
            _selectedMenuId = 0;
            MenuManager mm = new MenuManager();
            _dgvMenu.DataSource = mm.LoadAllMenu();
        }

        private void DgvMenu_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvMenu.SelectedRows.Count == 0) return;
            DataGridViewRow row = _dgvMenu.SelectedRows[0];
            _selectedMenuId       = Convert.ToInt32(row.Cells["FoodID"].Value);
            _txtMenuName.Text     = row.Cells["FoodName"].Value.ToString();
            _cmbCategory.Text     = row.Cells["Category"].Value.ToString();
            _txtPrice.Text        = row.Cells["Price"].Value.ToString();
            _cmbAvailability.Text = row.Cells["Availability"].Value.ToString();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(_txtMenuName.Text))
            { MessageBox.Show("Please enter a food name."); return false; }
            if (_cmbCategory.SelectedIndex < 0)
            { MessageBox.Show("Please select a category."); return false; }
            decimal price;
            if (!decimal.TryParse(_txtPrice.Text, out price) || price <= 0)
            { MessageBox.Show("Please enter a valid price greater than 0."); return false; }
            if (_cmbAvailability.SelectedIndex < 0)
            { MessageBox.Show("Please select availability."); return false; }
            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            decimal price = decimal.Parse(_txtPrice.Text);
            bool isAvailable = _cmbAvailability.Text == "Available";
            MenuManager mm = new MenuManager();
            mm.AddMenuItem(_txtMenuName.Text.Trim(), _cmbCategory.Text, price, isAvailable);
            MessageBox.Show("Menu item added.");
            LoadMenu();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMenuId == 0) { MessageBox.Show("Please select a menu item to update."); return; }
            if (!ValidateInputs()) return;
            decimal price = decimal.Parse(_txtPrice.Text);
            bool isAvailable = _cmbAvailability.Text == "Available";
            MenuManager mm = new MenuManager();
            mm.UpdateMenuItem(_selectedMenuId, _txtMenuName.Text.Trim(), _cmbCategory.Text, price, isAvailable);
            MessageBox.Show("Menu item updated.");
            LoadMenu();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMenuId == 0) { MessageBox.Show("Please select a menu item to delete."); return; }
            DialogResult confirm = MessageBox.Show(
                "Delete '" + _txtMenuName.Text + "'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            MenuManager mm = new MenuManager();
            mm.DeleteMenuItem(_selectedMenuId);
            MessageBox.Show("Menu item deleted.");
            LoadMenu();
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
    }
}
