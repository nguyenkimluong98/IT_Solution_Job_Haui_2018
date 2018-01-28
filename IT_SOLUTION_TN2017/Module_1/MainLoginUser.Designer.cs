namespace Module_1
{
    partial class MainLoginUser
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelUser = new System.Windows.Forms.Panel();
            this.dtgvTime = new System.Windows.Forms.DataGridView();
            this.lblCrash = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblHello = new System.Windows.Forms.Label();
            this.timerSpent = new System.Windows.Forms.Timer(this.components);
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnsuccessfulLogoutReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTime)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Exit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.dtgvTime);
            this.panelUser.Controls.Add(this.lblCrash);
            this.panelUser.Controls.Add(this.lblTime);
            this.panelUser.Controls.Add(this.lblHello);
            this.panelUser.Location = new System.Drawing.Point(13, 28);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(715, 478);
            this.panelUser.TabIndex = 1;
            // 
            // dtgvTime
            // 
            this.dtgvTime.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.LoginTime,
            this.Logout,
            this.SumTime,
            this.UnsuccessfulLogoutReason});
            this.dtgvTime.GridColor = System.Drawing.SystemColors.Control;
            this.dtgvTime.Location = new System.Drawing.Point(3, 115);
            this.dtgvTime.Name = "dtgvTime";
            this.dtgvTime.RowHeadersVisible = false;
            this.dtgvTime.Size = new System.Drawing.Size(709, 360);
            this.dtgvTime.TabIndex = 1;
            // 
            // lblCrash
            // 
            this.lblCrash.AutoSize = true;
            this.lblCrash.Location = new System.Drawing.Point(504, 64);
            this.lblCrash.Name = "lblCrash";
            this.lblCrash.Size = new System.Drawing.Size(0, 13);
            this.lblCrash.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(224, 64);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 0;
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Location = new System.Drawing.Point(41, 23);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(0, 13);
            this.lblHello.TabIndex = 0;
            // 
            // timerSpent
            // 
            this.timerSpent.Interval = 1000;
            this.timerSpent.Tick += new System.EventHandler(this.timerSpent_Tick);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 150;
            // 
            // LoginTime
            // 
            this.LoginTime.DataPropertyName = "Login";
            this.LoginTime.HeaderText = "Login Time";
            this.LoginTime.Name = "LoginTime";
            this.LoginTime.ReadOnly = true;
            // 
            // Logout
            // 
            this.Logout.DataPropertyName = "Logout";
            this.Logout.HeaderText = "Logout Time";
            this.Logout.Name = "Logout";
            this.Logout.ReadOnly = true;
            // 
            // SumTime
            // 
            this.SumTime.DataPropertyName = "SumTime";
            this.SumTime.HeaderText = "Time spent on system";
            this.SumTime.Name = "SumTime";
            this.SumTime.ReadOnly = true;
            this.SumTime.Width = 150;
            // 
            // UnsuccessfulLogoutReason
            // 
            this.UnsuccessfulLogoutReason.DataPropertyName = "Reason";
            this.UnsuccessfulLogoutReason.HeaderText = "Unsuccessful logout reason";
            this.UnsuccessfulLogoutReason.Name = "UnsuccessfulLogoutReason";
            this.UnsuccessfulLogoutReason.ReadOnly = true;
            this.UnsuccessfulLogoutReason.Width = 220;
            // 
            // MainLoginUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 518);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainLoginUser";
            this.Text = "MainLoginUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainLoginUser_FormClosing);
            this.Load += new System.EventHandler(this.MainLoginUser_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.DataGridView dtgvTime;
        private System.Windows.Forms.Label lblCrash;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Timer timerSpent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Logout;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnsuccessfulLogoutReason;
    }
}