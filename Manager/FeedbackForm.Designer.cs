namespace Gr8Food
{
    partial class FeedbackForm
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
            this.lblFeedbackTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtFeedbackDate = new System.Windows.Forms.DateTimePicker();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvFeedbacks = new System.Windows.Forms.DataGridView();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedback = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReplyFeedback = new System.Windows.Forms.Button();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.btnWallet = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // lblFeedbackTitle
            this.lblFeedbackTitle.AutoSize = true;
            this.lblFeedbackTitle.Font = new System.Drawing.Font("Impact", 16.2F);
            this.lblFeedbackTitle.ForeColor = System.Drawing.Color.Green;
            this.lblFeedbackTitle.Location = new System.Drawing.Point(384, 9);
            this.lblFeedbackTitle.Name = "lblFeedbackTitle";
            this.lblFeedbackTitle.TabIndex = 3;
            this.lblFeedbackTitle.Text = "Customer Feedbacks";
            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(245, 65);
            this.lblDate.Name = "lblDate";
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // dtFeedbackDate
            this.dtFeedbackDate.CustomFormat = "dd - MM - yyyy";
            this.dtFeedbackDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFeedbackDate.Location = new System.Drawing.Point(288, 60);
            this.dtFeedbackDate.Name = "dtFeedbackDate";
            this.dtFeedbackDate.Size = new System.Drawing.Size(139, 22);
            this.dtFeedbackDate.TabIndex = 5;
            // cboStatus
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(499, 58);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 24);
            this.cboStatus.TabIndex = 6;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(449, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // btnFilter
            this.btnFilter.Location = new System.Drawing.Point(640, 58);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(715, 58);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // dgvFeedbacks
            this.dgvFeedbacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeedbacks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCustomerName, this.colFeedback, this.colDate, this.colReply, this.colStatus });
            this.dgvFeedbacks.Location = new System.Drawing.Point(227, 98);
            this.dgvFeedbacks.Name = "dgvFeedbacks";
            this.dgvFeedbacks.RowHeadersWidth = 51;
            this.dgvFeedbacks.RowTemplate.Height = 24;
            this.dgvFeedbacks.Size = new System.Drawing.Size(564, 338);
            this.dgvFeedbacks.TabIndex = 10;
            this.dgvFeedbacks.SelectionChanged += new System.EventHandler(this.dgvFeedbacks_SelectionChanged);
            // colCustomerName
            this.colCustomerName.DataPropertyName = "CustomerName";
            this.colCustomerName.HeaderText = "Customer Name";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 125;
            // colFeedback
            this.colFeedback.DataPropertyName = "Feedback";
            this.colFeedback.HeaderText = "Feedback";
            this.colFeedback.Name = "colFeedback";
            this.colFeedback.Width = 170;
            // colDate
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Width = 125;
            // colReply
            this.colReply.DataPropertyName = "Reply";
            this.colReply.HeaderText = "Reply";
            this.colReply.Name = "colReply";
            this.colReply.Width = 170;
            // colStatus
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 125;
            // btnReplyFeedback
            this.btnReplyFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnReplyFeedback.Location = new System.Drawing.Point(640, 442);
            this.btnReplyFeedback.Name = "btnReplyFeedback";
            this.btnReplyFeedback.Size = new System.Drawing.Size(149, 36);
            this.btnReplyFeedback.TabIndex = 11;
            this.btnReplyFeedback.Text = "Reply Feedback";
            this.btnReplyFeedback.UseVisualStyleBackColor = true;
            this.btnReplyFeedback.Click += new System.EventHandler(this.btnReplyFeedback_Click);
            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.Green;
            this.panelSidebar.Controls.Add(this.pictureBox8);
            this.panelSidebar.Controls.Add(this.pictureBox7);
            this.panelSidebar.Controls.Add(this.pictureBox6);
            this.panelSidebar.Controls.Add(this.pictureBox5);
            this.panelSidebar.Controls.Add(this.pictureBox4);
            this.panelSidebar.Controls.Add(this.picLogo);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnFeedback);
            this.panelSidebar.Controls.Add(this.btnWallet);
            this.panelSidebar.Controls.Add(this.btnProfile);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Location = new System.Drawing.Point(-7, -3);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(228, 491);
            this.panelSidebar.TabIndex = 14;
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
            // picLogo
            this.picLogo.Location = new System.Drawing.Point(27, 18);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(175, 96);
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            // btnDashboard
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.Location = new System.Drawing.Point(77, 142);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(124, 42);
            this.btnDashboard.TabIndex = 7;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click_1);
            // btnLogout
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(77, 394);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 42);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // btnFeedback
            this.btnFeedback.BackColor = System.Drawing.Color.Silver;
            this.btnFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFeedback.Location = new System.Drawing.Point(77, 332);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(124, 42);
            this.btnFeedback.TabIndex = 5;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = false;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click_1);
            // btnWallet
            this.btnWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnWallet.Location = new System.Drawing.Point(77, 270);
            this.btnWallet.Name = "btnWallet";
            this.btnWallet.Size = new System.Drawing.Size(124, 42);
            this.btnWallet.TabIndex = 4;
            this.btnWallet.Text = "Wallet";
            this.btnWallet.UseVisualStyleBackColor = true;
            this.btnWallet.Click += new System.EventHandler(this.btnWallet_Click_1);
            // btnProfile
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnProfile.Location = new System.Drawing.Point(77, 206);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(124, 42);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click_1);
            // label1
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 98);
            this.label1.Name = "label1";
            this.label1.TabIndex = 2;
            // FeedbackForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(803, 484);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.btnReplyFeedback);
            this.Controls.Add(this.dgvFeedbacks);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.dtFeedbackDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblFeedbackTitle);
            this.Name = "FeedbackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gr8Food - Feedback";
            this.Load += new System.EventHandler(this.FeedbackForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).EndInit();
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

        private System.Windows.Forms.Label lblFeedbackTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtFeedbackDate;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvFeedbacks;
        private System.Windows.Forms.Button btnReplyFeedback;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnWallet;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedback;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReply;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
