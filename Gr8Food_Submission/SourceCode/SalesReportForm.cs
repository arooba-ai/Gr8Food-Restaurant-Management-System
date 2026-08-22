using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class SalesReportForm : Form
    {
        private UserSession  _session;
        private DataGridView _dgvReport;
        private ComboBox     _cmbMonth;
        private ComboBox     _cmbYear;
        private ComboBox     _cmbCategory;

        public SalesReportForm(UserSession session)
        {
            _session = session;
            this.Text = "Gr8Food - Sales Report";
            this.Size = new Size(820, 532);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            BuildUI();
            LoadReport();
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
            AddSidebarButton(sidebar, "Users", 25, 165, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new ManageUsersForm(_session).Show();
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
            lblTitle.Text = "Sales Report";
            lblTitle.Font = titleFont;
            lblTitle.ForeColor = darkGreen;
            lblTitle.Location = new Point(210, 30);
            lblTitle.Size = new Size(180, 30);
            this.Controls.Add(lblTitle);

            // Filter row
            AddLabel("Month", 210, 75, bodyFont);
            _cmbMonth = new ComboBox();
            _cmbMonth.Location = new Point(255, 72);
            _cmbMonth.Size = new Size(80, 22);
            _cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbMonth.Items.AddRange(new string[] { "All", "1", "2", "3", "4", "5", "6",
                                                    "7", "8", "9", "10", "11", "12" });
            _cmbMonth.SelectedIndex = 0;
            this.Controls.Add(_cmbMonth);

            AddLabel("Year", 350, 75, bodyFont);
            _cmbYear = new ComboBox();
            _cmbYear.Location = new Point(385, 72);
            _cmbYear.Size = new Size(80, 22);
            _cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbYear.Items.AddRange(new string[] { "All", "2024", "2025", "2026" });
            _cmbYear.SelectedIndex = 0;
            this.Controls.Add(_cmbYear);

            AddLabel("Category", 480, 75, bodyFont);
            _cmbCategory = new ComboBox();
            _cmbCategory.Location = new Point(540, 72);
            _cmbCategory.Size = new Size(100, 22);
            _cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbCategory.Items.AddRange(new string[] { "All", "Breakfast", "Lunch", "Dinner",
                                                       "Snacks", "Drinks", "Burgers", "Pizza", "Desserts" });
            _cmbCategory.SelectedIndex = 0;
            this.Controls.Add(_cmbCategory);

            Button btnFilter = new Button();
            btnFilter.Text = "Filter";
            btnFilter.Location = new Point(655, 70);
            btnFilter.Size = new Size(55, 26);
            btnFilter.Font = bodyFont;
            btnFilter.Click += BtnFilter_Click;
            this.Controls.Add(btnFilter);

            Button btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Location = new Point(718, 70);
            btnReset.Size = new Size(52, 26);
            btnReset.Font = bodyFont;
            btnReset.Click += (s, e) =>
            {
                _cmbMonth.SelectedIndex = 0;
                _cmbYear.SelectedIndex  = 0;
                _cmbCategory.SelectedIndex = 0;
                LoadReport();
            };
            this.Controls.Add(btnReset);

            // DataGridView
            _dgvReport = new DataGridView();
            _dgvReport.Location = new Point(210, 110);
            _dgvReport.Size = new Size(560, 335);
            _dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvReport.ReadOnly = true;
            _dgvReport.AllowUserToAddRows = false;
            _dgvReport.RowHeadersVisible = false;
            this.Controls.Add(_dgvReport);
        }

        private void LoadReport()
        {
            OrderManager om = new OrderManager();
            _dgvReport.DataSource = om.LoadSalesReport();
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            string month    = _cmbMonth.SelectedItem?.ToString()    ?? "All";
            string year     = _cmbYear.SelectedItem?.ToString()     ?? "All";
            string category = _cmbCategory.SelectedItem?.ToString() ?? "All";
            OrderManager om = new OrderManager();
            _dgvReport.DataSource = om.FilterSalesReport(month, year, category);
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
            lbl.Size = new Size(60, 18);
            this.Controls.Add(lbl);
        }
    }
}
