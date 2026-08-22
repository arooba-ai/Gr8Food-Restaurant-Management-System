namespace Gr8Food
{
    partial class WalletReportForm
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
            this.lblWalletReportTitle = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtWalletDate = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvWalletReport = new System.Windows.Forms.DataGridView();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTopupAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsageAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSidebar = new System.Windows.Forms.Panel();
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalletReport)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // lblWalletReportTitle
            this.lblWalletReportTitle.AutoSize = true;
            this.lblWalletReportTitle.Font = new System.Drawing.Font("Impact", 16.2F);
            this.lblWalletReportTitle.ForeColor = System.Drawing.Color.Green;
            this.lblWalletReportTitle.Location = new System.Drawing.Point(413, 11);
            this.lblWalletReportTitle.Name = "lblWalletReportTitle";
            this.lblWalletReportTitle.TabIndex = 2;
            this.lblWalletReportTitle.Text = "Wallet Report";
            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(235, 65);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Customer";
            // cboCustomer
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(301, 60);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(160, 24);
            this.cboCustomer.TabIndex = 5;
            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(483, 64);
            this.lblDate.Name = "lblDate";
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date";
            // dtWalletDate
            this.dtWalletDate.CustomFormat = "dd - MM - yyyy";
            this.dtWalletDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWalletDate.Location = new System.Drawing.Point(519, 60);
            this.dtWalletDate.Name = "dtWalletDate";
            this.dtWalletDate.Size = new System.Drawing.Size(143, 22);
            this.dtWalletDate.TabIndex = 7;
            this.dtWalletDate.ValueChanged += new System.EventHandler(this.dtWalletDate_ValueChanged);
            // btnFilter
            this.btnFilter.Location = new System.Drawing.Point(687, 57);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 28);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(687, 92);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // dgvWalletReport
            this.dgvWalletReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWalletReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWalletReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCustomer, this.colTopupAmount, this.colUsageAmount,
                this.colRemainingBalance, this.colDate });
            this.dgvWalletReport.Location = new System.Drawing.Point(232, 128);
            this.dgvWalletReport.Name = "dgvWalletReport";
            this.dgvWalletReport.RowHeadersWidth = 51;
            this.dgvWalletReport.Size = new System.Drawing.Size(567, 357);
            this.dgvWalletReport.TabIndex = 10;
            this.dgvWalletReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // colCustomer
            this.colCustomer.DataPropertyName = "CustomerName";
            this.colCustomer.HeaderText = "Customer Name";
            this.colCustomer.Name = "colCustomer";
            // colTopupAmount
            this.colTopupAmount.DataPropertyName = "TopUpAmount";
            this.colTopupAmount.HeaderText = "TopUp Amount";
            this.colTopupAmount.Name = "colTopupAmount";
            // colUsageAmount
            this.colUsageAmount.DataPropertyName = "UsageAmount";
            this.colUsageAmount.HeaderText = "Usage Amount";
            this.colUsageAmount.Name = "colUsageAmount";
            // colRemainingBalance
            this.colRemainingBalance.DataPropertyName = "RemainingBalance";
            this.colRemainingBalance.HeaderText = "Remaining Balance";
            this.colRemainingBalance.Name = "colRemainingBalance";
            // colDate
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.Green;
            this.panelSidebar.Controls.Add(this.picLogo);
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
            this.panelSidebar.Location = new System.Drawing.Point(1, -6);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(227, 491);
            this.panelSidebar.TabIndex = 13;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // pictureBox8
            this.pictureBox8.Location = new System.Drawing.Point(27, 142);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(51, 42);
            this.pictureBox8.TabIndex = 13;
            this.pictureBox8.TabStop = false;
            // pictureBox7
            this.pictureBox7.Location = new System.Drawing.Point(27, 206);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(51, 42);
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            // pictureBox6
            this.pictureBox6.Location = new System.Drawing.Point(27, 270);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(51, 42);
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // pictureBox5
            this.pictureBox5.Location = new System.Drawing.Point(27, 394);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(51, 42);
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // pictureBox4
            this.pictureBox4.Location = new System.Drawing.Point(27, 332);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 42);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // btnDashboard
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.Location = new System.Drawing.Point(77, 142);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(124, 42);
            this.btnDashboard.TabIndex = 7;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // btnLogout
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(77, 394);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 42);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // btnFeedback
            this.btnFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFeedback.Location = new System.Drawing.Point(77, 332);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(124, 42);
            this.btnFeedback.TabIndex = 5;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // btnWallet
            this.btnWallet.BackColor = System.Drawing.Color.Silver;
            this.btnWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnWallet.Location = new System.Drawing.Point(77, 270);
            this.btnWallet.Name = "btnWallet";
            this.btnWallet.Size = new System.Drawing.Size(124, 42);
            this.btnWallet.TabIndex = 4;
            this.btnWallet.Text = "Wallet";
            this.btnWallet.UseVisualStyleBackColor = false;
            this.btnWallet.Click += new System.EventHandler(this.btnWallet_Click);
            // btnProfile
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnProfile.Location = new System.Drawing.Point(77, 206);
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
            // picLogo
            this.picLogo.Location = new System.Drawing.Point(26, 24);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(175, 96);
            this.picLogo.TabIndex = 14;
            this.picLogo.TabStop = false;
            // WalletReportForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(803, 484);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.dgvWalletReport);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dtWalletDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblWalletReportTitle);
            this.Name = "WalletReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gr8Food - Wallet Report";
            this.Load += new System.EventHandler(this.Wallet_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalletReport)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblWalletReportTitle;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtWalletDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvWalletReport;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTopupAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsageAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemainingBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.PictureBox picLogo;
    }
}
