namespace PhotographyAutomation.App.Forms.Orders
{
    partial class FrmShowUploadedPhotos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowUploadedPhotos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.عکسToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مشاهدهعکسهاToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.دریافتعکسهاToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.مشتریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.رزروToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مشاهدهاطلاعاترزروToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCustomerInfo = new System.Windows.Forms.RadioButton();
            this.txtCustomerInfo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rbOrderStatus = new System.Windows.Forms.RadioButton();
            this.rbOrderDate = new System.Windows.Forms.RadioButton();
            this.btnShowOrders = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.rbOrderCode = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableOrderStatusDatePicker = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.datePickerOrderDate = new FreeControls.PersianDateTimePicker();
            this.datePickerOrderStatus = new FreeControls.PersianDateTimePicker();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.txtOrderCodeDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtOrderCodeCustomerIdBookingId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUploads = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBookingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographyTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPersonCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUploadDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmModifiedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderStatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotosFolderLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmViewPhotos = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.contextMenuDgvUploads = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.مشاهدهعکسهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.دریافتعکسهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مشاهدهاطلاعاترزروToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploads)).BeginInit();
            this.contextMenuDgvUploads.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.عکسToolStripMenuItem,
            this.مشتریToolStripMenuItem,
            this.رزروToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1147, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // عکسToolStripMenuItem
            // 
            this.عکسToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مشاهدهعکسهاToolStripMenuItem1,
            this.دریافتعکسهاToolStripMenuItem1});
            this.عکسToolStripMenuItem.Name = "عکسToolStripMenuItem";
            this.عکسToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.عکسToolStripMenuItem.Text = "عکس";
            // 
            // مشاهدهعکسهاToolStripMenuItem1
            // 
            this.مشاهدهعکسهاToolStripMenuItem1.Name = "مشاهدهعکسهاToolStripMenuItem1";
            this.مشاهدهعکسهاToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.مشاهدهعکسهاToolStripMenuItem1.Text = "مشاهده عکس ها";
            this.مشاهدهعکسهاToolStripMenuItem1.Click += new System.EventHandler(this.مشاهدهعکسهاToolStripMenuItem1_Click);
            // 
            // دریافتعکسهاToolStripMenuItem1
            // 
            this.دریافتعکسهاToolStripMenuItem1.Name = "دریافتعکسهاToolStripMenuItem1";
            this.دریافتعکسهاToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.دریافتعکسهاToolStripMenuItem1.Text = "دریافت عکس ها";
            this.دریافتعکسهاToolStripMenuItem1.Click += new System.EventHandler(this.دریافتعکسهاToolStripMenuItem1_Click);
            // 
            // مشتریToolStripMenuItem
            // 
            this.مشتریToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem1});
            this.مشتریToolStripMenuItem.Name = "مشتریToolStripMenuItem";
            this.مشتریToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.مشتریToolStripMenuItem.Text = "مشتری";
            // 
            // مشاهدهاطلاعاتمشتریToolStripMenuItem1
            // 
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem1.Name = "مشاهدهاطلاعاتمشتریToolStripMenuItem1";
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem1.Text = "مشاهده اطلاعات مشتری";
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem1.Click += new System.EventHandler(this.مشاهدهاطلاعاتمشتریToolStripMenuItem1_Click);
            // 
            // رزروToolStripMenuItem
            // 
            this.رزروToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مشاهدهاطلاعاترزروToolStripMenuItem1});
            this.رزروToolStripMenuItem.Name = "رزروToolStripMenuItem";
            this.رزروToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.رزروToolStripMenuItem.Text = "رزرو";
            // 
            // مشاهدهاطلاعاترزروToolStripMenuItem1
            // 
            this.مشاهدهاطلاعاترزروToolStripMenuItem1.Name = "مشاهدهاطلاعاترزروToolStripMenuItem1";
            this.مشاهدهاطلاعاترزروToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.مشاهدهاطلاعاترزروToolStripMenuItem1.Text = "مشاهده اطلاعات رزرو";
            this.مشاهدهاطلاعاترزروToolStripMenuItem1.Click += new System.EventHandler(this.مشاهدهاطلاعاترزروToolStripMenuItem1_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.groupBox2);
            this.panelEx3.Controls.Add(this.groupBox1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 24);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1147, 556);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbCustomerInfo);
            this.groupBox2.Controls.Add(this.txtCustomerInfo);
            this.groupBox2.Controls.Add(this.rbOrderStatus);
            this.groupBox2.Controls.Add(this.rbOrderDate);
            this.groupBox2.Controls.Add(this.btnShowOrders);
            this.groupBox2.Controls.Add(this.btnClearSearch);
            this.groupBox2.Controls.Add(this.rbOrderCode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkEnableOrderStatusDatePicker);
            this.groupBox2.Controls.Add(this.datePickerOrderDate);
            this.groupBox2.Controls.Add(this.datePickerOrderStatus);
            this.groupBox2.Controls.Add(this.cmbOrderStatus);
            this.groupBox2.Controls.Add(this.txtOrderCodeDate);
            this.groupBox2.Controls.Add(this.txtOrderCodeCustomerIdBookingId);
            this.groupBox2.Controls.Add(this.labelX4);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1120, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مشاهده سفارشات بر اساس";
            // 
            // rbCustomerInfo
            // 
            this.rbCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCustomerInfo.Location = new System.Drawing.Point(908, 65);
            this.rbCustomerInfo.Name = "rbCustomerInfo";
            this.rbCustomerInfo.Size = new System.Drawing.Size(108, 17);
            this.rbCustomerInfo.TabIndex = 1;
            this.rbCustomerInfo.Text = "اطلاعات مشتری";
            this.rbCustomerInfo.UseVisualStyleBackColor = true;
            this.rbCustomerInfo.CheckedChanged += new System.EventHandler(this.rbCustomerInfo_CheckedChanged);
            // 
            // txtCustomerInfo
            // 
            this.txtCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCustomerInfo.Border.Class = "TextBoxBorder";
            this.txtCustomerInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerInfo.Enabled = false;
            this.txtCustomerInfo.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtCustomerInfo.FocusHighlightEnabled = true;
            this.txtCustomerInfo.Location = new System.Drawing.Point(677, 65);
            this.txtCustomerInfo.Name = "txtCustomerInfo";
            this.txtCustomerInfo.PreventEnterBeep = true;
            this.txtCustomerInfo.Size = new System.Drawing.Size(230, 21);
            this.txtCustomerInfo.TabIndex = 6;
            this.txtCustomerInfo.WatermarkText = "(نام ، نام خانوادگی ، تلفن ثابت، تلفن همراه)";
            this.txtCustomerInfo.Enter += new System.EventHandler(this.txtCustomerInfo_Enter);
            this.txtCustomerInfo.Leave += new System.EventHandler(this.txtCustomerInfo_Leave);
            // 
            // rbOrderStatus
            // 
            this.rbOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOrderStatus.AutoSize = true;
            this.rbOrderStatus.Location = new System.Drawing.Point(551, 67);
            this.rbOrderStatus.Name = "rbOrderStatus";
            this.rbOrderStatus.Size = new System.Drawing.Size(70, 17);
            this.rbOrderStatus.TabIndex = 3;
            this.rbOrderStatus.Text = "موارد دیگر";
            this.rbOrderStatus.UseVisualStyleBackColor = true;
            this.rbOrderStatus.CheckedChanged += new System.EventHandler(this.rbOrderStatus_CheckedChanged);
            // 
            // rbOrderDate
            // 
            this.rbOrderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOrderDate.AutoSize = true;
            this.rbOrderDate.Location = new System.Drawing.Point(575, 35);
            this.rbOrderDate.Name = "rbOrderDate";
            this.rbOrderDate.Size = new System.Drawing.Size(46, 17);
            this.rbOrderDate.TabIndex = 2;
            this.rbOrderDate.Text = "تاریخ";
            this.rbOrderDate.UseVisualStyleBackColor = true;
            this.rbOrderDate.CheckedChanged += new System.EventHandler(this.rbOrderDate_CheckedChanged);
            // 
            // btnShowOrders
            // 
            this.btnShowOrders.FlatAppearance.BorderSize = 0;
            this.btnShowOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOrders.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_Search_text_131785;
            this.btnShowOrders.Location = new System.Drawing.Point(47, 58);
            this.btnShowOrders.Name = "btnShowOrders";
            this.btnShowOrders.Size = new System.Drawing.Size(32, 32);
            this.btnShowOrders.TabIndex = 11;
            this.btnShowOrders.UseVisualStyleBackColor = true;
            this.btnShowOrders.Click += new System.EventHandler(this.btnShowOrders_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_Gnome_Edit_Clear_32_54970;
            this.btnClearSearch.Location = new System.Drawing.Point(9, 58);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(32, 32);
            this.btnClearSearch.TabIndex = 12;
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // rbOrderCode
            // 
            this.rbOrderCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOrderCode.Location = new System.Drawing.Point(908, 35);
            this.rbOrderCode.Name = "rbOrderCode";
            this.rbOrderCode.Size = new System.Drawing.Size(108, 17);
            this.rbOrderCode.TabIndex = 0;
            this.rbOrderCode.Text = "شناسه سفارش";
            this.rbOrderCode.UseVisualStyleBackColor = true;
            this.rbOrderCode.CheckedChanged += new System.EventHandler(this.rbOrderCode_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1022, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "جستجو بر اساس:";
            // 
            // chkEnableOrderStatusDatePicker
            // 
            this.chkEnableOrderStatusDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.chkEnableOrderStatusDatePicker.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEnableOrderStatusDatePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEnableOrderStatusDatePicker.Enabled = false;
            this.chkEnableOrderStatusDatePicker.Location = new System.Drawing.Point(375, 66);
            this.chkEnableOrderStatusDatePicker.Name = "chkEnableOrderStatusDatePicker";
            this.chkEnableOrderStatusDatePicker.Size = new System.Drawing.Size(15, 18);
            this.chkEnableOrderStatusDatePicker.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEnableOrderStatusDatePicker.TabIndex = 9;
            this.chkEnableOrderStatusDatePicker.CheckedChanged += new System.EventHandler(this.chkEnableOrderStatusDatePicker_CheckedChanged);
            // 
            // datePickerOrderDate
            // 
            this.datePickerOrderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerOrderDate.BackColor = System.Drawing.Color.White;
            this.datePickerOrderDate.Enabled = false;
            this.datePickerOrderDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerOrderDate.Location = new System.Drawing.Point(434, 35);
            this.datePickerOrderDate.Name = "datePickerOrderDate";
            this.datePickerOrderDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerOrderDate.ShowTime = false;
            this.datePickerOrderDate.Size = new System.Drawing.Size(111, 18);
            this.datePickerOrderDate.TabIndex = 7;
            this.datePickerOrderDate.Text = "persianDateTimePicker1";
            this.datePickerOrderDate.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerOrderDate.Value")));
            this.datePickerOrderDate.EnabledChanged += new System.EventHandler(this.datePickerOrderDate_EnabledChanged);
            // 
            // datePickerOrderStatus
            // 
            this.datePickerOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerOrderStatus.BackColor = System.Drawing.Color.White;
            this.datePickerOrderStatus.Enabled = false;
            this.datePickerOrderStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerOrderStatus.Location = new System.Drawing.Point(262, 66);
            this.datePickerOrderStatus.Name = "datePickerOrderStatus";
            this.datePickerOrderStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerOrderStatus.ShowTime = false;
            this.datePickerOrderStatus.Size = new System.Drawing.Size(111, 18);
            this.datePickerOrderStatus.TabIndex = 10;
            this.datePickerOrderStatus.Text = "persianDateTimePicker1";
            this.datePickerOrderStatus.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerOrderStatus.Value")));
            this.datePickerOrderStatus.EnabledChanged += new System.EventHandler(this.datePickerOrderStatus_EnabledChanged);
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.Enabled = false;
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Location = new System.Drawing.Point(413, 65);
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(132, 21);
            this.cmbOrderStatus.TabIndex = 8;
            this.cmbOrderStatus.SelectedIndexChanged += new System.EventHandler(this.cmbOrderStatus_SelectedIndexChanged);
            // 
            // txtOrderCodeDate
            // 
            this.txtOrderCodeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtOrderCodeDate.Border.Class = "TextBoxBorder";
            this.txtOrderCodeDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderCodeDate.Enabled = false;
            this.txtOrderCodeDate.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtOrderCodeDate.FocusHighlightEnabled = true;
            this.txtOrderCodeDate.Location = new System.Drawing.Point(756, 35);
            this.txtOrderCodeDate.MaxLength = 7;
            this.txtOrderCodeDate.Name = "txtOrderCodeDate";
            this.txtOrderCodeDate.PreventEnterBeep = true;
            this.txtOrderCodeDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOrderCodeDate.Size = new System.Drawing.Size(55, 21);
            this.txtOrderCodeDate.TabIndex = 4;
            this.txtOrderCodeDate.TextChanged += new System.EventHandler(this.txtOrderCodeDate_TextChanged);
            this.txtOrderCodeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderCodeDate_KeyDown);
            this.txtOrderCodeDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderCodeDate_KeyPress);
            // 
            // txtOrderCodeCustomerIdBookingId
            // 
            this.txtOrderCodeCustomerIdBookingId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtOrderCodeCustomerIdBookingId.Border.Class = "TextBoxBorder";
            this.txtOrderCodeCustomerIdBookingId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderCodeCustomerIdBookingId.Enabled = false;
            this.txtOrderCodeCustomerIdBookingId.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtOrderCodeCustomerIdBookingId.FocusHighlightEnabled = true;
            this.txtOrderCodeCustomerIdBookingId.Location = new System.Drawing.Point(824, 35);
            this.txtOrderCodeCustomerIdBookingId.MaxLength = 6;
            this.txtOrderCodeCustomerIdBookingId.Name = "txtOrderCodeCustomerIdBookingId";
            this.txtOrderCodeCustomerIdBookingId.PreventEnterBeep = true;
            this.txtOrderCodeCustomerIdBookingId.ReadOnly = true;
            this.txtOrderCodeCustomerIdBookingId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOrderCodeCustomerIdBookingId.Size = new System.Drawing.Size(83, 21);
            this.txtOrderCodeCustomerIdBookingId.TabIndex = 5;
            this.txtOrderCodeCustomerIdBookingId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderCodeDate_KeyDown);
            this.txtOrderCodeCustomerIdBookingId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderCodeCustomerId_KeyPress);
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(814, 37);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(6, 16);
            this.labelX4.TabIndex = 79;
            this.labelX4.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvUploads);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1123, 434);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dgvUploads
            // 
            this.dgvUploads.AllowUserToAddRows = false;
            this.dgvUploads.AllowUserToDeleteRows = false;
            this.dgvUploads.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUploads.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUploads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUploads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUploads.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUploads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUploads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmCustomerId,
            this.clmBookingId,
            this.clmOrderCode,
            this.clmCustomerFullName,
            this.clmDate,
            this.clmTime,
            this.clmPhotographyTypeId,
            this.clmPhotographyTypeName,
            this.clmPersonCount,
            this.clmTotalFiles,
            this.clmCreatedDateTime,
            this.clmUploadDate,
            this.clmModifiedDateTime,
            this.clmStatusId,
            this.clmOrderStatusCode,
            this.clmStatusName,
            this.clmPhotosFolderLink,
            this.clmViewPhotos});
            this.dgvUploads.ContextMenuStrip = this.contextMenuDgvUploads;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUploads.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUploads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUploads.EnableHeadersVisualStyles = false;
            this.dgvUploads.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvUploads.Location = new System.Drawing.Point(3, 17);
            this.dgvUploads.MultiSelect = false;
            this.dgvUploads.Name = "dgvUploads";
            this.dgvUploads.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUploads.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUploads.RowHeadersVisible = false;
            this.dgvUploads.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUploads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUploads.ShowEditingIcon = false;
            this.dgvUploads.Size = new System.Drawing.Size(1117, 414);
            this.dgvUploads.TabIndex = 0;
            this.dgvUploads.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUploads_CellContentClick);
            this.dgvUploads.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvUploads_MouseUp);
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "Id";
            this.clmId.HeaderText = "clmId";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // clmCustomerId
            // 
            this.clmCustomerId.DataPropertyName = "CustomerId";
            this.clmCustomerId.HeaderText = "clmCustomerId";
            this.clmCustomerId.Name = "clmCustomerId";
            this.clmCustomerId.ReadOnly = true;
            this.clmCustomerId.Visible = false;
            // 
            // clmBookingId
            // 
            this.clmBookingId.DataPropertyName = "BookingId";
            this.clmBookingId.HeaderText = "BookingId";
            this.clmBookingId.Name = "clmBookingId";
            this.clmBookingId.ReadOnly = true;
            this.clmBookingId.Visible = false;
            // 
            // clmOrderCode
            // 
            this.clmOrderCode.DataPropertyName = "OrderCode";
            this.clmOrderCode.HeaderText = "شناسه سفارش";
            this.clmOrderCode.MinimumWidth = 140;
            this.clmOrderCode.Name = "clmOrderCode";
            this.clmOrderCode.ReadOnly = true;
            // 
            // clmCustomerFullName
            // 
            this.clmCustomerFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCustomerFullName.DataPropertyName = "CustomerFullName";
            this.clmCustomerFullName.HeaderText = "نام مشتری";
            this.clmCustomerFullName.MinimumWidth = 150;
            this.clmCustomerFullName.Name = "clmCustomerFullName";
            this.clmCustomerFullName.ReadOnly = true;
            // 
            // clmDate
            // 
            this.clmDate.DataPropertyName = "Date";
            this.clmDate.HeaderText = "تاریخ عکاسی";
            this.clmDate.MinimumWidth = 100;
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            // 
            // clmTime
            // 
            this.clmTime.DataPropertyName = "Time";
            this.clmTime.HeaderText = "ساعت عکاسی";
            this.clmTime.MinimumWidth = 120;
            this.clmTime.Name = "clmTime";
            this.clmTime.ReadOnly = true;
            // 
            // clmPhotographyTypeId
            // 
            this.clmPhotographyTypeId.DataPropertyName = "PhotographyTypeId";
            this.clmPhotographyTypeId.HeaderText = "clmPhotographyTypeId";
            this.clmPhotographyTypeId.Name = "clmPhotographyTypeId";
            this.clmPhotographyTypeId.ReadOnly = true;
            this.clmPhotographyTypeId.Visible = false;
            // 
            // clmPhotographyTypeName
            // 
            this.clmPhotographyTypeName.DataPropertyName = "PhotographyTypeName";
            this.clmPhotographyTypeName.HeaderText = "نوع عکاسی";
            this.clmPhotographyTypeName.MinimumWidth = 100;
            this.clmPhotographyTypeName.Name = "clmPhotographyTypeName";
            this.clmPhotographyTypeName.ReadOnly = true;
            // 
            // clmPersonCount
            // 
            this.clmPersonCount.DataPropertyName = "PersonCount";
            this.clmPersonCount.HeaderText = "تعداد نفرات";
            this.clmPersonCount.MinimumWidth = 100;
            this.clmPersonCount.Name = "clmPersonCount";
            this.clmPersonCount.ReadOnly = true;
            // 
            // clmTotalFiles
            // 
            this.clmTotalFiles.DataPropertyName = "TotalFiles";
            this.clmTotalFiles.HeaderText = "تعداد عکس ها";
            this.clmTotalFiles.MinimumWidth = 100;
            this.clmTotalFiles.Name = "clmTotalFiles";
            this.clmTotalFiles.ReadOnly = true;
            // 
            // clmCreatedDateTime
            // 
            this.clmCreatedDateTime.DataPropertyName = "CreatedDateTime";
            this.clmCreatedDateTime.HeaderText = "تاریخ ثبت";
            this.clmCreatedDateTime.MinimumWidth = 100;
            this.clmCreatedDateTime.Name = "clmCreatedDateTime";
            this.clmCreatedDateTime.ReadOnly = true;
            this.clmCreatedDateTime.Visible = false;
            // 
            // clmUploadDate
            // 
            this.clmUploadDate.DataPropertyName = "UploadDate";
            this.clmUploadDate.HeaderText = "تاریخ آپلود";
            this.clmUploadDate.MinimumWidth = 100;
            this.clmUploadDate.Name = "clmUploadDate";
            this.clmUploadDate.ReadOnly = true;
            // 
            // clmModifiedDateTime
            // 
            this.clmModifiedDateTime.DataPropertyName = "ModifiedDateTime";
            this.clmModifiedDateTime.HeaderText = "تاریخ ویرایش";
            this.clmModifiedDateTime.Name = "clmModifiedDateTime";
            this.clmModifiedDateTime.ReadOnly = true;
            this.clmModifiedDateTime.Visible = false;
            // 
            // clmStatusId
            // 
            this.clmStatusId.DataPropertyName = "StatusId";
            this.clmStatusId.HeaderText = "clmStatusId";
            this.clmStatusId.Name = "clmStatusId";
            this.clmStatusId.ReadOnly = true;
            this.clmStatusId.Visible = false;
            // 
            // clmOrderStatusCode
            // 
            this.clmOrderStatusCode.DataPropertyName = "OrderStatusCode";
            this.clmOrderStatusCode.HeaderText = "OrderStatusCode";
            this.clmOrderStatusCode.Name = "clmOrderStatusCode";
            this.clmOrderStatusCode.ReadOnly = true;
            this.clmOrderStatusCode.Visible = false;
            // 
            // clmStatusName
            // 
            this.clmStatusName.DataPropertyName = "StatusName";
            this.clmStatusName.HeaderText = "وضعیت";
            this.clmStatusName.MinimumWidth = 100;
            this.clmStatusName.Name = "clmStatusName";
            this.clmStatusName.ReadOnly = true;
            // 
            // clmPhotosFolderLink
            // 
            this.clmPhotosFolderLink.HeaderText = "PhotosFolderLink";
            this.clmPhotosFolderLink.Name = "clmPhotosFolderLink";
            this.clmPhotosFolderLink.ReadOnly = true;
            this.clmPhotosFolderLink.Visible = false;
            // 
            // clmViewPhotos
            // 
            this.clmViewPhotos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmViewPhotos.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.clmViewPhotos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmViewPhotos.HeaderText = "مشاهده عکس ها";
            this.clmViewPhotos.Image = ((System.Drawing.Image)(resources.GetObject("clmViewPhotos.Image")));
            this.clmViewPhotos.MinimumWidth = 120;
            this.clmViewPhotos.Name = "clmViewPhotos";
            this.clmViewPhotos.ReadOnly = true;
            this.clmViewPhotos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmViewPhotos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmViewPhotos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.clmViewPhotos.Text = "مشاهده عکس ها";
            this.clmViewPhotos.Width = 120;
            // 
            // contextMenuDgvUploads
            // 
            this.contextMenuDgvUploads.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.contextMenuDgvUploads.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مشاهدهعکسهاToolStripMenuItem,
            this.دریافتعکسهاToolStripMenuItem,
            this.toolStripSeparator6,
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem,
            this.مشاهدهاطلاعاترزروToolStripMenuItem});
            this.contextMenuDgvUploads.Name = "contextMenuStrip1";
            this.contextMenuDgvUploads.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuDgvUploads.Size = new System.Drawing.Size(195, 98);
            // 
            // مشاهدهعکسهاToolStripMenuItem
            // 
            this.مشاهدهعکسهاToolStripMenuItem.Name = "مشاهدهعکسهاToolStripMenuItem";
            this.مشاهدهعکسهاToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.مشاهدهعکسهاToolStripMenuItem.Text = "مشاهده عکس ها";
            this.مشاهدهعکسهاToolStripMenuItem.Click += new System.EventHandler(this.مشاهدهعکسهاToolStripMenuItem_Click);
            // 
            // دریافتعکسهاToolStripMenuItem
            // 
            this.دریافتعکسهاToolStripMenuItem.Name = "دریافتعکسهاToolStripMenuItem";
            this.دریافتعکسهاToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.دریافتعکسهاToolStripMenuItem.Text = "دریافت عکس ها";
            this.دریافتعکسهاToolStripMenuItem.Click += new System.EventHandler(this.دریافتعکسهاToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(191, 6);
            // 
            // مشاهدهاطلاعاتمشتریToolStripMenuItem
            // 
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem.Name = "مشاهدهاطلاعاتمشتریToolStripMenuItem";
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem.Text = "مشاهده اطلاعات مشتری";
            this.مشاهدهاطلاعاتمشتریToolStripMenuItem.Click += new System.EventHandler(this.مشاهدهاطلاعاتمشتریToolStripMenuItem_Click);
            // 
            // مشاهدهاطلاعاترزروToolStripMenuItem
            // 
            this.مشاهدهاطلاعاترزروToolStripMenuItem.Name = "مشاهدهاطلاعاترزروToolStripMenuItem";
            this.مشاهدهاطلاعاترزروToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.مشاهدهاطلاعاترزروToolStripMenuItem.Text = "مشاهده اطلاعات رزرو";
            this.مشاهدهاطلاعاترزروToolStripMenuItem.Click += new System.EventHandler(this.مشاهدهاطلاعاترزروToolStripMenuItem_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // FrmShowUploadedPhotos
            // 
            this.AcceptButton = this.btnShowOrders;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 580);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowUploadedPhotos";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده رزرو ها (رزرو های عکس برداری شده)";
            this.Load += new System.EventHandler(this.FrmShowUploadedPhotos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploads)).EndInit();
            this.contextMenuDgvUploads.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ContextMenuStrip contextMenuDgvUploads;
        private System.Windows.Forms.ToolStripMenuItem مشاهدهعکسهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem دریافتعکسهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem مشاهدهاطلاعاتمشتریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مشاهدهاطلاعاترزروToolStripMenuItem;
        private System.Windows.Forms.Button btnShowOrders;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderCodeCustomerIdBookingId;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderCodeDate;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerInfo;
        private FreeControls.PersianDateTimePicker datePickerOrderDate;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvUploads;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEnableOrderStatusDatePicker;
        private FreeControls.PersianDateTimePicker datePickerOrderStatus;
        private System.Windows.Forms.RadioButton rbOrderStatus;
        private System.Windows.Forms.RadioButton rbOrderDate;
        private System.Windows.Forms.RadioButton rbOrderCode;
        private System.Windows.Forms.RadioButton rbCustomerInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBookingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographyTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUploadDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmModifiedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderStatusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotosFolderLink;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn clmViewPhotos;
        private System.Windows.Forms.ToolStripMenuItem عکسToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مشاهدهعکسهاToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem دریافتعکسهاToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem مشتریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مشاهدهاطلاعاتمشتریToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem رزروToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مشاهدهاطلاعاترزروToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}