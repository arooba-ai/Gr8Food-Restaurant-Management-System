namespace Gr8Food
{
    partial class frmOrderStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderStatus));
            this.picCartIcon = new System.Windows.Forms.PictureBox();
            this.picLogoutIcon = new System.Windows.Forms.PictureBox();
            this.picProfileIcon = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.picDashboardIcon = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.mycart = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.lblMyOrders = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCartIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDashboardIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox6
            // 
            this.picCartIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.picCartIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCartIcon.Location = new System.Drawing.Point(25, 243);
            this.picCartIcon.Name = "picCartIcon";
            this.picCartIcon.Size = new System.Drawing.Size(49, 42);
            this.picCartIcon.TabIndex = 6;
            this.picCartIcon.TabStop = false;
            // 
            // pictureBox8
            // 
            this.picLogoutIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.BackgroundImage")));
            this.picLogoutIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogoutIcon.Location = new System.Drawing.Point(25, 387);
            this.picLogoutIcon.Name = "picLogoutIcon";
            this.picLogoutIcon.Size = new System.Drawing.Size(49, 42);
            this.picLogoutIcon.TabIndex = 8;
            this.picLogoutIcon.TabStop = false;
            // 
            // pictureBox9
            // 
            this.picProfileIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.BackgroundImage")));
            this.picProfileIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picProfileIcon.Location = new System.Drawing.Point(25, 167);
            this.picProfileIcon.Name = "picProfileIcon";
            this.picProfileIcon.Size = new System.Drawing.Size(49, 42);
            this.picProfileIcon.TabIndex = 12;
            this.picProfileIcon.TabStop = false;
            // 
            // button4
            // 
            this.btnProfile.BackColor = System.Drawing.Color.DarkGreen;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(74, 167);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(144, 42);
            this.btnProfile.TabIndex = 11;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(75, 314);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(143, 41);
            this.btnDashboard.TabIndex = 16;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCart.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(74, 243);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(143, 42);
            this.btnCart.TabIndex = 14;
            this.btnCart.Text = "Cart";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // pictureBox11
            // 
            this.picDashboardIcon.BackgroundImage = global::Gr8Food.Properties.Resources.icons8_dashboard_24;
            this.picDashboardIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picDashboardIcon.Location = new System.Drawing.Point(20, 314);
            this.picDashboardIcon.Name = "picDashboardIcon";
            this.picDashboardIcon.Size = new System.Drawing.Size(60, 40);
            this.picDashboardIcon.TabIndex = 17;
            this.picDashboardIcon.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(73, 388);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(143, 40);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.Location = new System.Drawing.Point(36, 42);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(166, 97);
            this.picLogo.TabIndex = 19;
            this.picLogo.TabStop = false;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.DarkGreen;
            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.picDashboardIcon);
            this.pnlSidebar.Controls.Add(this.btnCart);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.picProfileIcon);
            this.pnlSidebar.Controls.Add(this.picLogoutIcon);
            this.pnlSidebar.Controls.Add(this.picCartIcon);
            this.pnlSidebar.Location = new System.Drawing.Point(0, -2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(226, 479);
            this.pnlSidebar.TabIndex = 28;
            // 
            // mycart
            // 
            this.mycart.AutoSize = true;
            this.mycart.Font = new System.Drawing.Font("Impact", 14F);
            this.mycart.ForeColor = System.Drawing.Color.DarkGreen;
            this.mycart.Location = new System.Drawing.Point(242, 40);
            this.mycart.Name = "mycart";
            this.mycart.Size = new System.Drawing.Size(158, 35);
            this.mycart.TabIndex = 29;
            this.mycart.Text = "Order Status";
            this.mycart.Click += new System.EventHandler(this.mycart_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(232, 119);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 28;
            this.dgvOrders.Size = new System.Drawing.Size(562, 296);
            this.dgvOrders.TabIndex = 30;
            // 
            // label1
            // 
            this.lblMyOrders.AutoSize = true;
            this.lblMyOrders.Location = new System.Drawing.Point(230, 92);
            this.lblMyOrders.Name = "lblMyOrders";
            this.lblMyOrders.Size = new System.Drawing.Size(81, 20);
            this.lblMyOrders.TabIndex = 31;
            this.lblMyOrders.Text = "My Orders";
            // 
            // frmOrderStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(798, 475);
            this.Controls.Add(this.lblMyOrders);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.mycart);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "frmOrderStatus";
            this.Text = "Gr8Food-frmOrderStatus";
            this.Load += new System.EventHandler(this.frmOrderStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCartIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDashboardIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCartIcon;
        private System.Windows.Forms.PictureBox picLogoutIcon;
        private System.Windows.Forms.PictureBox picProfileIcon;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.PictureBox picDashboardIcon;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label mycart;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lblMyOrders;
    }
}