using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ChefDashboardForm : Form
    {
        private UserSession _session;

        public ChefDashboardForm(UserSession session)
        {
            _session = session;
            this.Text = "Gr8Food - Chef Dashboard";
            this.Size = new Size(820, 532);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            BuildUI();
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

            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome, " + (_session != null ? _session.Name : "Chef");
            lblWelcome.Font = bodyFont;
            lblWelcome.ForeColor = Color.White;
            lblWelcome.AutoSize = false;
            lblWelcome.Size = new Size(160, 20);
            lblWelcome.Location = new Point(10, 30);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            sidebar.Controls.Add(lblWelcome);

            AddSidebarButton(sidebar, "Dashboard", 25, 70, 130, 30, Color.White, Color.Black, bodyFont, null);
            AddSidebarButton(sidebar, "Profile", 25, 115, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new frmProfile(_session).Show();
                this.Hide();
            });
            AddSidebarButton(sidebar, "Logout", 25, 160, 130, 30, Color.White, Color.Black, bodyFont, (s, e) =>
            {
                new frmloginpage().Show();
                this.Hide();
            });

            Label lblTitle = new Label();
            lblTitle.Text = "Chef Dashboard";
            lblTitle.Font = titleFont;
            lblTitle.ForeColor = darkGreen;
            lblTitle.Size = new Size(550, 30);
            lblTitle.Location = new Point(210, 70);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitle);

            Label lblSub = new Label();
            lblSub.Text = "What would you like to do?";
            lblSub.Font = bodyFont;
            lblSub.ForeColor = Color.DimGray;
            lblSub.Size = new Size(550, 20);
            lblSub.Location = new Point(210, 100);
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblSub);

            AddDashboardCard("Manage Menu", 250, 150, (s, e) =>
            {
                new ManageMenuForm(_session).Show();
                this.Hide();
            });

            AddDashboardCard("View Orders", 430, 150, (s, e) =>
            {
                new ChefOrdersForm(_session).Show();
                this.Hide();
            });

            AddDashboardCard("My Profile", 610, 150, (s, e) =>
            {
                new frmProfile(_session).Show();
                this.Hide();
            });
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

        private void AddDashboardCard(string text, int x, int y, EventHandler click)
        {
            Panel card = new Panel();
            card.Size = new Size(140, 110);
            card.Location = new Point(x, y);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Cursor = Cursors.Hand;
            card.Click += click;

            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            lbl.Size = new Size(130, 40);
            lbl.Location = new Point(5, 65);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Cursor = Cursors.Hand;
            lbl.Click += click;

            card.Controls.Add(lbl);
            this.Controls.Add(card);
        }
    }
}
