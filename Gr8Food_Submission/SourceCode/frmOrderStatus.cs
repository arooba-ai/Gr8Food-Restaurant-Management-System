using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class frmOrderStatus : Form
    {
        private UserSession _session;
        private Button btnCancelOrder;

        public frmOrderStatus(UserSession session)
        {
            InitializeComponent();
            _session = session;
        }

        private void frmOrderStatus_Load(object sender, EventArgs e)
        {
            dgvOrders.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.ReadOnly            = true;
            dgvOrders.RowTemplate.Height  = 36;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnCancelOrder           = new Button();
            btnCancelOrder.Text      = "Cancel Order";
            btnCancelOrder.Location  = new Point(232, 425);
            btnCancelOrder.Size      = new Size(140, 35);
            btnCancelOrder.BackColor = Color.Firebrick;
            btnCancelOrder.ForeColor = Color.White;
            btnCancelOrder.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8F,
                                           System.Drawing.FontStyle.Bold);
            btnCancelOrder.Click    += new EventHandler(BtnCancelOrder_Click);
            this.Controls.Add(btnCancelOrder);

            LoadOrders();
        }

        private void LoadOrders()
        {
            if (_session.UserID == 0) return;
            OrderManager om      = new OrderManager();
            dgvOrders.DataSource = om.LoadOrders(_session.UserID);
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel.");
                return;
            }

            string status = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status == "Cancelled")
            {
                MessageBox.Show("This order is already cancelled.");
                return;
            }

            if (status == "Completed")
            {
                MessageBox.Show("Completed orders cannot be cancelled.");
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

            OrderManager  om           = new OrderManager();
            decimal       refundAmount = om.GetOrderAmount(orderId);

            om.CancelOrder(orderId);

            WalletManager wm = new WalletManager();
            wm.AddToBalance(_session.UserID, refundAmount);
            wm.AddTransaction(_session.UserID, refundAmount, "Refund");

            MessageBox.Show("Order cancelled.\nRM " + refundAmount.ToString("F2") +
                            " has been refunded to your wallet.");

            LoadOrders();
        }

        private void mycart_Click(object sender, EventArgs e) { }

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
    }
}
