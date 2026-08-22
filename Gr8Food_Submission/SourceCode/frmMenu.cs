using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class frmMenu : Form
    {
        private UserSession _session;

        public frmMenu(UserSession session)
        {
            InitializeComponent();
            _session = session;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            MenuManager mm = new MenuManager();
            dgvMenu.DataSource = mm.LoadMenu();
            dgvMenu.Columns["MenuID"].Visible      = false;
            dgvMenu.Columns["IsAvailable"].Visible = false;
            dgvMenu.SelectionMode           = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.ReadOnly                = true;
            dgvMenu.AutoSizeColumnsMode     = DataGridViewAutoSizeColumnsMode.Fill;

            // Back button — positioned between "Menu" label (ends ~x369) and Search box (starts x587)
            System.Windows.Forms.Button btnBack = new System.Windows.Forms.Button();
            btnBack.Text      = "← Back";
            btnBack.Location  = new System.Drawing.Point(380, 32);
            btnBack.Size      = new System.Drawing.Size(90, 26);
            btnBack.BackColor = System.Drawing.Color.DarkGreen;
            btnBack.ForeColor = System.Drawing.Color.White;
            btnBack.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btnBack.Click    += (s, ev) => { new CustomerDashboard(_session).Show(); this.Hide(); };
            this.Controls.Add(btnBack);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox10_Click(object sender, EventArgs e) { }

        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnAll_Click(object sender, EventArgs e)
        {
            MenuManager mm = new MenuManager();
            dgvMenu.DataSource = mm.LoadMenu();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MenuManager mm = new MenuManager();
            dgvMenu.DataSource = mm.SearchFood(txtSearch.Text);
        }

        private void btnBurgers_Click(object sender, EventArgs e)
        {
            MenuManager mm = new MenuManager();
            dgvMenu.DataSource = mm.LoadCategory("Burgers");
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            MenuManager mm = new MenuManager();
            dgvMenu.DataSource = mm.LoadCategory("Pizza");
        }

        private void btnDrinks_Click(object sender, EventArgs e)
        {
            MenuManager mm = new MenuManager();
            dgvMenu.DataSource = mm.LoadCategory("Drinks");
        }

        private void btnDesserts_Click(object sender, EventArgs e)
        {
            MenuManager mm = new MenuManager();
            dgvMenu.DataSource = mm.LoadCategory("Desserts");
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            frmCart fc = new frmCart(_session);
            fc.Show();
            this.Hide();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(nudQuantity.Value);

            if (quantity <= 0)
            {
                MessageBox.Show("Please select quantity.");
                return;
            }

            if (dgvMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select food.");
                return;
            }

            string  foodName = dgvMenu.SelectedRows[0].Cells["Name"].Value.ToString();
            decimal price    = Convert.ToDecimal(dgvMenu.SelectedRows[0].Cells["Price"].Value);
            decimal total    = quantity * price;

            OrderManager om = new OrderManager();
            om.AddToCart(foodName, price, quantity, total);

            MessageBox.Show("Added To Cart");
        }
    }
}
