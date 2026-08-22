using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ChefOrdersForm : Form
    {
        private UserSession _session;
        private DataGridView _dgvOrders;
        private ComboBox     _cmbStatus;
        private int          _selectedOrderId;

        public ChefOrdersForm(UserSession session)
        {
            _session = session;
            this.Text = "Gr8Food - Chef Orders";
            this.Size = new Size(820, 532);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            BuildUI();
            LoadOrders();
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
            AddSidebarButton(sidebar, "Menu", 25, 115, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new ManageMenuForm(_session).Show();
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
            lblTitle.Text = "View Orders";
            lblTitle.Font = titleFont;
            lblTitle.ForeColor = darkGreen;
            lblTitle.Location = new Point(210, 30);
            lblTitle.Size = new Size(180, 30);
            this.Controls.Add(lblTitle);

            _dgvOrders = new DataGridView();
            _dgvOrders.Location = new Point(210, 75);
            _dgvOrders.Size = new Size(560, 290);
            _dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvOrders.ReadOnly = true;
            _dgvOrders.AllowUserToAddRows = false;
            _dgvOrders.RowHeadersVisible = false;
            _dgvOrders.MultiSelect = false;
            _dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
            this.Controls.Add(_dgvOrders);

            Label lblStatus = new Label();
            lblStatus.Text = "Update Status";
            lblStatus.Font = bodyFont;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(210, 390);
            this.Controls.Add(lblStatus);

            _cmbStatus = new ComboBox();
            _cmbStatus.Location = new Point(310, 387);
            _cmbStatus.Size = new Size(170, 22);
            _cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbStatus.Items.AddRange(new string[] { "Pending", "In Progress", "Completed", "Cancelled" });
            this.Controls.Add(_cmbStatus);

            Button btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Location = new Point(495, 385);
            btnUpdate.Size = new Size(80, 26);
            btnUpdate.Font = bodyFont;
            btnUpdate.Click += BtnUpdate_Click;
            this.Controls.Add(btnUpdate);

            Button btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(585, 385);
            btnRefresh.Size = new Size(80, 26);
            btnRefresh.Font = bodyFont;
            btnRefresh.Click += (s, e) => LoadOrders();
            this.Controls.Add(btnRefresh);
        }

        private void LoadOrders()
        {
            _selectedOrderId = 0;
            _cmbStatus.SelectedIndex = -1;
            OrderManager om = new OrderManager();
            _dgvOrders.DataSource = om.LoadChefOrders();
        }

        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvOrders.SelectedRows.Count == 0) return;
            DataGridViewRow row = _dgvOrders.SelectedRows[0];
            _selectedOrderId = Convert.ToInt32(row.Cells["OrderID"].Value);
            string currentStatus = row.Cells["Status"].Value.ToString();
            _cmbStatus.SelectedItem = currentStatus;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == 0)
            {
                MessageBox.Show("Please select an order from the list.");
                return;
            }
            if (_cmbStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a new status.");
                return;
            }
            string newStatus = _cmbStatus.SelectedItem.ToString();
            OrderManager om = new OrderManager();
            om.UpdateOrderStatus(_selectedOrderId, newStatus);
            MessageBox.Show("Order #" + _selectedOrderId + " updated to: " + newStatus);
            LoadOrders();
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
