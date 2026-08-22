namespace Gr8Food
{
    partial class ManagerDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.panelTopup = new System.Windows.Forms.Panel();
            this.lblTopupAmount = new System.Windows.Forms.Label();
            this.lblTopupTitle = new System.Windows.Forms.Label();
            this.panelUsage = new System.Windows.Forms.Panel();
            this.lblUsageAmount = new System.Windows.Forms.Label();
            this.lblUsageTitle = new System.Windows.Forms.Label();
            this.dgvRecentFeedback = new System.Windows.Forms.DataGridView();
            this.lblRecentFeedback = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.btnWallet = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTopup.SuspendLayout();
            this.panelUsage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentFeedback)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // lblDashboardTitle
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Impact", 16.2F);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.Green;
            this.lblDashboardTitle.Location = new System.Drawing.Point(386, 29);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(265, 35);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "Manager\'s Dashboard";
            // panelTopup
            this.panelTopup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTopup.Controls.Add(this.lblTopupAmount);
            this.panelTopup.Controls.Add(this.lblTopupTitle);
            this.panelTopup.Location = new System.Drawing.Point(272, 133);
            this.panelTopup.Name = "panelTopup";
            this.panelTopup.Size = new System.Drawing.Size(221, 100);
            this.panelTopup.TabIndex = 2;
            this.panelTopup.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTopup_Paint);
            // lblTopupAmount
            this.lblTopupAmount.AutoSize = true;
            this.lblTopupAmount.Location = new System.Drawing.Point(87, 55);
            this.lblTopupAmount.Name = "lblTopupAmount";
            this.lblTopupAmount.TabIndex = 1;
            this.lblTopupAmount.Text = "RM 0";
            // lblTopupTitle
            this.lblTopupTitle.AutoSize = true;
            this.lblTopupTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTopupTitle.Location = new System.Drawing.Point(25, 4);
            this.lblTopupTitle.Name = "lblTopupTitle";
            this.lblTopupTitle.TabIndex = 0;
            this.lblTopupTitle.Text = " Total Wallet TopUps";
            this.lblTopupTitle.Click += new System.EventHandler(this.label4_Click);
            // panelUsage
            this.panelUsage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelUsage.Controls.Add(this.lblUsageAmount);
            this.panelUsage.Controls.Add(this.lblUsageTitle);
            this.panelUsage.Location = new System.Drawing.Point(515, 133);
            this.panelUsage.Name = "panelUsage";
            this.panelUsage.Size = new System.Drawing.Size(221, 100);
            this.panelUsage.TabIndex = 0;
            this.panelUsage.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUsage_Paint);
            // lblUsageAmount
            this.lblUsageAmount.AutoSize = true;
            this.lblUsageAmount.Location = new System.Drawing.Point(81, 55);
            this.lblUsageAmount.Name = "lblUsageAmount";
            this.lblUsageAmount.TabIndex = 1;
            this.lblUsageAmount.Text = "RM 0";
            // lblUsageTitle
            this.lblUsageTitle.AutoSize = true;
            this.lblUsageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsageTitle.Location = new System.Drawing.Point(35, 4);
            this.lblUsageTitle.Name = "lblUsageTitle";
            this.lblUsageTitle.TabIndex = 0;
            this.lblUsageTitle.Text = "Total Wallet Usage";
            // dgvRecentFeedback
            this.dgvRecentFeedback.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentFeedback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentFeedback.Location = new System.Drawing.Point(282, 288);
            this.dgvRecentFeedback.Name = "dgvRecentFeedback";
            this.dgvRecentFeedback.RowHeadersWidth = 51;
            this.dgvRecentFeedback.RowTemplate.Height = 24;
            this.dgvRecentFeedback.Size = new System.Drawing.Size(463, 170);
            this.dgvRecentFeedback.TabIndex = 3;
            this.dgvRecentFeedback.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // lblRecentFeedback
            this.lblRecentFeedback.AutoSize = true;
            this.lblRecentFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblRecentFeedback.Location = new System.Drawing.Point(427, 254);
            this.lblRecentFeedback.Name = "lblRecentFeedback";
            this.lblRecentFeedback.TabIndex = 4;
            this.lblRecentFeedback.Text = "Recent Feedbacks";
            // lblDateTime
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.Location = new System.Drawing.Point(269, 83);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "Date and Time";
            this.lblDateTime.Click += new System.EventHandler(this.label6_Click);
            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.Green;
            this.panelSidebar.Controls.Add(this.picProfile);
            this.panelSidebar.Controls.Add(this.lblWelcome);
            this.panelSidebar.Controls.Add(this.pictureBox8);
            this.panelSidebar.Controls.Add(this.pictureBox7);
            this.panelSidebar.Controls.Add(this.pictureBox6);
            this.panelSidebar.Controls.Add(this.pictureBox5);
            this.panelSidebar.Controls.Add(this.pictureBox4);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnFeedback);
            this.panelSidebar.Controls.Add(this.btnWallet);
            this.panelSidebar.Controls.Add(this.btnProfile);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(238, 490);
            this.panelSidebar.TabIndex = 6;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // picProfile
            this.picProfile.Location = new System.Drawing.Point(78, 19);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(88, 82);
            this.picProfile.TabIndex = 15;
            this.picProfile.TabStop = false;
            this.picProfile.Click += new System.EventHandler(this.picProfile_Click);
            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblWelcome.Location = new System.Drawing.Point(10, 104);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.TabIndex = 14;
            this.lblWelcome.Text = "Welcome, Manager!";
            // pictureBox8
            this.pictureBox8.Location = new System.Drawing.Point(27, 141);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 42);
            this.pictureBox8.TabIndex = 13;
            this.pictureBox8.TabStop = false;
            // pictureBox7
            this.pictureBox7.Location = new System.Drawing.Point(27, 205);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 42);
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            // pictureBox6
            this.pictureBox6.Location = new System.Drawing.Point(27, 269);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 42);
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // pictureBox5
            this.pictureBox5.Location = new System.Drawing.Point(27, 394);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 42);
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // pictureBox4
            this.pictureBox4.Location = new System.Drawing.Point(27, 332);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 42);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // btnDashboard
            this.btnDashboard.BackColor = System.Drawing.Color.Silver;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.Location = new System.Drawing.Point(78, 141);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(124, 42);
            this.btnDashboard.TabIndex = 7;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // btnLogout
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(78, 394);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 42);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // btnFeedback
            this.btnFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFeedback.Location = new System.Drawing.Point(78, 332);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(124, 42);
            this.btnFeedback.TabIndex = 5;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // btnWallet
            this.btnWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnWallet.Location = new System.Drawing.Point(78, 269);
            this.btnWallet.Name = "btnWallet";
            this.btnWallet.Size = new System.Drawing.Size(124, 42);
            this.btnWallet.TabIndex = 4;
            this.btnWallet.Text = "Wallet";
            this.btnWallet.UseVisualStyleBackColor = true;
            this.btnWallet.Click += new System.EventHandler(this.btnWallet_Click);
            // btnProfile
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnProfile.Location = new System.Drawing.Point(78, 205);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(124, 42);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // label1
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 98);
            this.label1.Name = "label1";
            this.label1.TabIndex = 2;
            // ManagerDashboardForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(802, 484);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblRecentFeedback);
            this.Controls.Add(this.dgvRecentFeedback);
            this.Controls.Add(this.panelUsage);
            this.Controls.Add(this.panelTopup);
            this.Controls.Add(this.lblDashboardTitle);
            this.Name = "ManagerDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gr8Food - Manager Dashboard";
            this.Load += new System.EventHandler(this.ManagerDashboard_Load);
            this.panelTopup.ResumeLayout(false);
            this.panelTopup.PerformLayout();
            this.panelUsage.ResumeLayout(false);
            this.panelUsage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentFeedback)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel panelTopup;
        private System.Windows.Forms.Label lblTopupTitle;
        private System.Windows.Forms.Panel panelUsage;
        private System.Windows.Forms.DataGridView dgvRecentFeedback;
        private System.Windows.Forms.Label lblRecentFeedback;
        private System.Windows.Forms.Label lblUsageTitle;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnWallet;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTopupAmount;
        private System.Windows.Forms.Label lblUsageAmount;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Label lblWelcome;
    }
}
