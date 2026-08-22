namespace Gr8Food
{
    partial class frmFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeedback));
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.picDashboardIcon = new System.Windows.Forms.PictureBox();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.picProfileIcon = new System.Windows.Forms.PictureBox();
            this.picLogoutIcon = new System.Windows.Forms.PictureBox();
            this.picCartIcon = new System.Windows.Forms.PictureBox();
            this.lblRatePrompt = new System.Windows.Forms.Label();
            this.cmbRating = new System.Windows.Forms.ComboBox();
            this.lblFeedbackPrompt = new System.Windows.Forms.Label();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblThankYou = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDashboardIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPageTitle.Location = new System.Drawing.Point(399, 29);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(206, 29);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Customer Feedback";
            this.lblPageTitle.Click += new System.EventHandler(this.label2_Click);
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
            this.pnlSidebar.Location = new System.Drawing.Point(-3, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(226, 479);
            this.pnlSidebar.TabIndex = 27;
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
            // label1
            // 
            this.lblRatePrompt.AutoSize = true;
            this.lblRatePrompt.Location = new System.Drawing.Point(282, 110);
            this.lblRatePrompt.Name = "lblRatePrompt";
            this.lblRatePrompt.Size = new System.Drawing.Size(134, 20);
            this.lblRatePrompt.TabIndex = 28;
            this.lblRatePrompt.Text = "Rate Our Service:";
            // 
            // cmbRating
            //
            this.cmbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRating.FormattingEnabled = true;
            this.cmbRating.Items.AddRange(new object[] {
            "Select Rating",
            "1 Star",
            "2 Stars",
            "3 Stars",
            "4 Stars",
            "5 Stars"});
            this.cmbRating.Location = new System.Drawing.Point(434, 107);
            this.cmbRating.Name = "cmbRating";
            this.cmbRating.Size = new System.Drawing.Size(140, 28);
            this.cmbRating.TabIndex = 29;
            this.cmbRating.SelectedIndex = 0;
            // 
            // label3
            // 
            this.lblFeedbackPrompt.AutoSize = true;
            this.lblFeedbackPrompt.Location = new System.Drawing.Point(282, 216);
            this.lblFeedbackPrompt.Name = "lblFeedbackPrompt";
            this.lblFeedbackPrompt.Size = new System.Drawing.Size(122, 20);
            this.lblFeedbackPrompt.TabIndex = 30;
            this.lblFeedbackPrompt.Text = "Your Feedback:";
            this.lblFeedbackPrompt.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Location = new System.Drawing.Point(410, 216);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(219, 108);
            this.txtFeedback.TabIndex = 31;
            this.txtFeedback.TextChanged += new System.EventHandler(this.txtFeedback_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(542, 330);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 36);
            this.btnSubmit.TabIndex = 32;
            this.btnSubmit.Text = "SUBMIT ";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.lblThankYou.AutoSize = true;
            this.lblThankYou.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblThankYou.Location = new System.Drawing.Point(351, 385);
            this.lblThankYou.Name = "lblThankYou";
            this.lblThankYou.Size = new System.Drawing.Size(320, 20);
            this.lblThankYou.TabIndex = 33;
            this.lblThankYou.Text = "Thank you! Your feedback helps us improve.";
            this.lblThankYou.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmFeedback
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(798, 475);
            this.Controls.Add(this.lblThankYou);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.lblFeedbackPrompt);
            this.Controls.Add(this.cmbRating);
            this.Controls.Add(this.lblRatePrompt);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.lblPageTitle);
            this.Name = "frmFeedback";
            this.Text = "Gr8Food -Feedback";
            this.Load += new System.EventHandler(this.frmFeedback_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDashboardIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox picDashboardIcon;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.PictureBox picProfileIcon;
        private System.Windows.Forms.PictureBox picLogoutIcon;
        private System.Windows.Forms.PictureBox picCartIcon;
        private System.Windows.Forms.Label lblRatePrompt;
        private System.Windows.Forms.ComboBox cmbRating;
        private System.Windows.Forms.Label lblFeedbackPrompt;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblThankYou;
    }
}