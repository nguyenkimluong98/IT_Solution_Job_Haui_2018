namespace Module_1
{
    partial class LoginMain
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
            this.panelMainLogin = new System.Windows.Forms.Panel();
            this.dtgvUser = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Office = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEDLogin = new System.Windows.Forms.Button();
            this.btnChangeRole = new System.Windows.Forms.Button();
            this.cbAllOffices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMainLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainLogin
            // 
            this.panelMainLogin.Controls.Add(this.dtgvUser);
            this.panelMainLogin.Controls.Add(this.btnEDLogin);
            this.panelMainLogin.Controls.Add(this.btnChangeRole);
            this.panelMainLogin.Controls.Add(this.cbAllOffices);
            this.panelMainLogin.Controls.Add(this.label1);
            this.panelMainLogin.Location = new System.Drawing.Point(12, 27);
            this.panelMainLogin.Name = "panelMainLogin";
            this.panelMainLogin.Size = new System.Drawing.Size(851, 567);
            this.panelMainLogin.TabIndex = 0;
            // 
            // dtgvUser
            // 
            this.dtgvUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.LastName,
            this.Age,
            this.UserRole,
            this.EmailAddress,
            this.Office});
            this.dtgvUser.Location = new System.Drawing.Point(3, 72);
            this.dtgvUser.Name = "dtgvUser";
            this.dtgvUser.RowHeadersVisible = false;
            this.dtgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgvUser.Size = new System.Drawing.Size(845, 443);
            this.dtgvUser.TabIndex = 3;
            this.dtgvUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtgvUser_MouseDown);
            // 
            // Name
            // 
            this.Name.DataPropertyName = "FirstName";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Birthdate";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // UserRole
            // 
            this.UserRole.DataPropertyName = "RoleID";
            this.UserRole.HeaderText = "User Role";
            this.UserRole.Name = "UserRole";
            this.UserRole.ReadOnly = true;
            this.UserRole.Width = 150;
            // 
            // EmailAddress
            // 
            this.EmailAddress.DataPropertyName = "Email";
            this.EmailAddress.HeaderText = "Email Address";
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.ReadOnly = true;
            this.EmailAddress.Width = 250;
            // 
            // Office
            // 
            this.Office.DataPropertyName = "OfficeID";
            this.Office.HeaderText = "Office";
            this.Office.Name = "Office";
            this.Office.ReadOnly = true;
            this.Office.Width = 150;
            // 
            // btnEDLogin
            // 
            this.btnEDLogin.Location = new System.Drawing.Point(246, 521);
            this.btnEDLogin.Name = "btnEDLogin";
            this.btnEDLogin.Size = new System.Drawing.Size(142, 35);
            this.btnEDLogin.TabIndex = 2;
            this.btnEDLogin.Text = "Enable/Disable Login";
            this.btnEDLogin.UseVisualStyleBackColor = true;
            this.btnEDLogin.Click += new System.EventHandler(this.btnEDLogin_Click);
            // 
            // btnChangeRole
            // 
            this.btnChangeRole.Location = new System.Drawing.Point(3, 521);
            this.btnChangeRole.Name = "btnChangeRole";
            this.btnChangeRole.Size = new System.Drawing.Size(142, 35);
            this.btnChangeRole.TabIndex = 2;
            this.btnChangeRole.Text = "Change Role";
            this.btnChangeRole.UseVisualStyleBackColor = true;
            this.btnChangeRole.Click += new System.EventHandler(this.btnChangeRole_Click);
            // 
            // cbAllOffices
            // 
            this.cbAllOffices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAllOffices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAllOffices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllOffices.FormattingEnabled = true;
            this.cbAllOffices.Location = new System.Drawing.Point(62, 24);
            this.cbAllOffices.Name = "cbAllOffices";
            this.cbAllOffices.Size = new System.Drawing.Size(247, 28);
            this.cbAllOffices.TabIndex = 1;
            this.cbAllOffices.SelectedIndexChanged += new System.EventHandler(this.cbAllOffices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Office:";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(875, 27);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.addUserToolStripMenuItem.Text = "&Add user";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(42, 23);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // LoginMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 607);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.panelMainLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //this.Name = "LoginMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANOMIC Airlines Automation System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginMain_FormClosing);
            this.Load += new System.EventHandler(this.LoginMain_Load);
            this.panelMainLogin.ResumeLayout(false);
            this.panelMainLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMainLogin;
        private System.Windows.Forms.Button btnEDLogin;
        private System.Windows.Forms.Button btnChangeRole;
        private System.Windows.Forms.ComboBox cbAllOffices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Office;
    }
}