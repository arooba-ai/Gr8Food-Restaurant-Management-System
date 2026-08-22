using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class frmCart : Form
    {
        private UserSession _session;
        private Button btnRemove;
        private Button btnCheckout;
        private Label  lblCartTotal;

        public frmCart(UserSession session)
        {
            InitializeComponent();
            _session = session;
        }

        private void frmCart_Load(object sender, EventArgs e)
        {
            btnRemove           = new Button();
            btnRemove.Text      = "Remove Item";
            btnRemove.Location  = new Point(237, 432);
            btnRemove.Size      = new Size(120, 32);
            btnRemove.BackColor = Color.Firebrick;
            btnRemove.ForeColor = Color.White;
            btnRemove.Click    += new EventHandler(btnRemove_Click);
            this.Controls.Add(btnRemove);

            btnCheckout           = new Button();
            btnCheckout.Text      = "Checkout";
            btnCheckout.Location  = new Point(620, 432);
            btnCheckout.Size      = new Size(130, 32);
            btnCheckout.BackColor = Color.DarkGreen;
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Click    += new EventHandler(btnCheckout_Click);
            this.Controls.Add(btnCheckout);

            lblCartTotal           = new Label();
            lblCartTotal.Font      = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblCartTotal.ForeColor = Color.DarkGreen;
            lblCartTotal.Location  = new Point(390, 436);
            lblCartTotal.Size      = new Size(220, 24);
            this.Controls.Add(lblCartTotal);

            LoadCart();
        }

        private void LoadCart()
        {
            OrderManager om = new OrderManager();
            dataGridView2.DataSource = om.LoadCart();

            dataGridView2.Columns["CartID"].Visible = false;
            dataGridView2.AutoSizeColumnsMode        = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode              = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.RowTemplate.Height         = 40;
            dataGridView2.ReadOnly                   = true;

            decimal total = om.GetTotal();
            if (lblCartTotal != null)
                lblCartTotal.Text = "Total: RM " + total.ToString("F2");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            int cartId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["CartID"].Value);

            OrderManager om = new OrderManager();
            om.RemoveItem(cartId);

            MessageBox.Show("Item removed.");
            LoadCart();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            OrderManager om = new OrderManager();
            decimal total   = om.GetTotal();

            if (total <= 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }

            if (_session.UserID == 0)
            {
                MessageBox.Show("Session expired. Please log in again.");
                return;
            }

            WalletManager wm = new WalletManager();
            decimal balance  = wm.GetWalletBalance(_session.UserID);

            if (balance < total)
            {
                MessageBox.Show("Insufficient Wallet Balance.\n" +
                    "Balance: RM " + balance.ToString("F2") + "\n" +
                    "Total:   RM " + total.ToString("F2"));
                return;
            }

            // Validate every cart item against Menu BEFORE creating the order.
            // This prevents an orphaned Orders row if a lookup fails.
            DataTable cartItems = om.LoadCart();
            var menuIds = new System.Collections.Generic.Dictionary<string, int>(
                System.StringComparer.OrdinalIgnoreCase);

            foreach (DataRow row in cartItems.Rows)
            {
                string foodName = row["FoodName"].ToString();
                if (!menuIds.ContainsKey(foodName))
                {
                    int menuId = om.GetMenuID(foodName);
                    if (menuId == 0)
                    {
                        MessageBox.Show("Menu item not found: " + foodName,
                            "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    menuIds[foodName] = menuId;
                }
            }

            // All items validated — safe to write to the database
            int orderId = om.PlaceOrder(_session.UserID, total);

            foreach (DataRow row in cartItems.Rows)
            {
                string  foodName = row["FoodName"].ToString();
                int     qty      = Convert.ToInt32(row["Quantity"]);
                decimal subtotal = Convert.ToDecimal(row["Total"]);

                om.AddOrderDetail(orderId, menuIds[foodName], qty, subtotal);
            }

            wm.DeductBalance(_session.UserID, total);
            wm.AddTransaction(_session.UserID, total, "Payment");

            om.ClearCart();
            LoadCart();

            MessageBox.Show("Order placed successfully!\nTotal: RM " + total.ToString("F2"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerDashboard cd = new CustomerDashboard(_session);
            cd.Show();
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            LoadCart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmProfile fp = new frmProfile(_session);
            fp.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            frmloginpage fl = new frmloginpage();
            fl.Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfile fp = new frmProfile(_session);
            fp.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
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
    }
}
