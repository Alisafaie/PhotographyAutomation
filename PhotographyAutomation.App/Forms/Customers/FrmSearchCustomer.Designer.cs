namespace PhotographyAutomation.App.Forms.Customers
{
    partial class FrmSearchCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCustomers = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoreInfo = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.menuDgvUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ویرایشاطلاعاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتنوبتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتفاکتورToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTell = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.menuDgvUsers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1039, 431);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvCustomers);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1015, 338);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "فهرست مشتریان";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FirstName,
            this.LastName,
            this.Tell,
            this.Mobile,
            this.Email,
            this.NationalId,
            this.UserType,
            this.CreatedDate,
            this.ModifiedDate,
            this.MoreInfo});
            this.dgvCustomers.ContextMenuStrip = this.menuDgvUsers;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvCustomers.Location = new System.Drawing.Point(3, 17);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1009, 318);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellDoubleClick);
            this.dgvCustomers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvUsers_MouseUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 23;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "نام";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 45;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "نام خانوادگی";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Tell
            // 
            this.Tell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tell.DataPropertyName = "Tell";
            this.Tell.HeaderText = "تلفن ثابت";
            this.Tell.Name = "Tell";
            this.Tell.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.HeaderText = "تلفن همراه";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "ایمیل";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 57;
            // 
            // NationalId
            // 
            this.NationalId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NationalId.DataPropertyName = "NationalId";
            this.NationalId.HeaderText = "کد ملی";
            this.NationalId.Name = "NationalId";
            this.NationalId.ReadOnly = true;
            // 
            // UserType
            // 
            this.UserType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserType.DataPropertyName = "UserType";
            this.UserType.HeaderText = "نوع کاربر";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.Width = 70;
            // 
            // CreatedDate
            // 
            this.CreatedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "تاریخ ثبت";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // ModifiedDate
            // 
            this.ModifiedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModifiedDate.DataPropertyName = "ModifiedDate";
            this.ModifiedDate.HeaderText = "تاریخ ویرایش";
            this.ModifiedDate.Name = "ModifiedDate";
            this.ModifiedDate.ReadOnly = true;
            // 
            // MoreInfo
            // 
            this.MoreInfo.DataPropertyName = "MoreInfo";
            this.MoreInfo.HeaderText = "اطلاعات بیشتر";
            this.MoreInfo.Name = "MoreInfo";
            this.MoreInfo.ReadOnly = true;
            this.MoreInfo.Width = 81;
            // 
            // menuDgvUsers
            // 
            this.menuDgvUsers.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuDgvUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایشاطلاعاتToolStripMenuItem,
            this.ثبتنوبتToolStripMenuItem,
            this.ثبتفاکتورToolStripMenuItem});
            this.menuDgvUsers.Name = "menuDgvUsers";
            this.menuDgvUsers.Size = new System.Drawing.Size(148, 70);
            // 
            // ویرایشاطلاعاتToolStripMenuItem
            // 
            this.ویرایشاطلاعاتToolStripMenuItem.Name = "ویرایشاطلاعاتToolStripMenuItem";
            this.ویرایشاطلاعاتToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ویرایشاطلاعاتToolStripMenuItem.Text = "ویرایش اطلاعات";
            this.ویرایشاطلاعاتToolStripMenuItem.Click += new System.EventHandler(this.ویرایشاطلاعاتToolStripMenuItem_Click);
            // 
            // ثبتنوبتToolStripMenuItem
            // 
            this.ثبتنوبتToolStripMenuItem.Name = "ثبتنوبتToolStripMenuItem";
            this.ثبتنوبتToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ثبتنوبتToolStripMenuItem.Text = "ثبت نوبت";
            this.ثبتنوبتToolStripMenuItem.Click += new System.EventHandler(this.ثبتنوبتToolStripMenuItem_Click);
            // 
            // ثبتفاکتورToolStripMenuItem
            // 
            this.ثبتفاکتورToolStripMenuItem.Name = "ثبتفاکتورToolStripMenuItem";
            this.ثبتفاکتورToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ثبتفاکتورToolStripMenuItem.Text = "ثبت فاکتور";
            this.ثبتفاکتورToolStripMenuItem.Click += new System.EventHandler(this.ثبتفاکتورToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTell);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات مشتری";
            // 
            // txtTell
            // 
            this.txtTell.Location = new System.Drawing.Point(441, 28);
            this.txtTell.MaxLength = 11;
            this.txtTell.Name = "txtTell";
            this.txtTell.Size = new System.Drawing.Size(100, 20);
            this.txtTell.TabIndex = 2;
            this.txtTell.ThemeName = "Office2010Silver";
            this.txtTell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTell_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(547, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "تلفن (ثابت یا همراه)";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLastName.Location = new System.Drawing.Point(674, 28);
            this.txtLastName.MaxLength = 200;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 19);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.ThemeName = "Office2010Silver";
            this.txtLastName.Enter += new System.EventHandler(this.txtFirstName_Enter);
            this.txtLastName.Leave += new System.EventHandler(this.txtFirstName_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(780, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "نام خانوادگی";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSearch.Location = new System.Drawing.Point(6, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.ThemeName = "Office2010Silver";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFirstName.Location = new System.Drawing.Point(873, 28);
            this.txtFirstName.MaxLength = 200;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 19);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.ThemeName = "Office2010Silver";
            this.txtFirstName.Enter += new System.EventHandler(this.txtFirstName_Enter);
            this.txtFirstName.Leave += new System.EventHandler(this.txtFirstName_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(980, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "نام";
            // 
            // FrmSearchCustomer
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 431);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmSearchCustomer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "جستجوی مشتری";
            this.Load += new System.EventHandler(this.FrmSearchCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.menuDgvUsers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadTextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadTextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCustomers;
        private System.Windows.Forms.ContextMenuStrip menuDgvUsers;
        private System.Windows.Forms.ToolStripMenuItem ثبتنوبتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ویرایشاطلاعاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتفاکتورToolStripMenuItem;
        private Telerik.WinControls.UI.RadTextBox txtTell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedDate;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn MoreInfo;
    }
}