namespace PhotographyAutomation.App.Forms.EntranceToAtelier
{
    partial class FrmShowIncommingBookings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowIncommingBookings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.chkSpecialBookings = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkEnableDatePickerBookingDate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbCurrentmonth = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbCurrentWeek = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbCurrentDay = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblToDate = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtCustomerInfo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnShowBookings = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.datePickerBookingDateTo = new FreeControls.PersianDateTimePicker();
            this.datePickerBookingDateFrom = new FreeControls.PersianDateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOrders = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBookingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographyTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographerGenderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPersonCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderStatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmModifiedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripDgvBookings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ویرایشاطلاعاتمشتریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ارسالعکسToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مشاهدهعکسهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفعکسهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.درخواستصدورقبضToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.contextMenuStripDgvBookings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbOrderStatus);
            this.groupBox2.Controls.Add(this.chkSpecialBookings);
            this.groupBox2.Controls.Add(this.chkEnableDatePickerBookingDate);
            this.groupBox2.Controls.Add(this.rbCurrentmonth);
            this.groupBox2.Controls.Add(this.rbCurrentWeek);
            this.groupBox2.Controls.Add(this.rbCurrentDay);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Controls.Add(this.labelX1);
            this.groupBox2.Controls.Add(this.txtCustomerInfo);
            this.groupBox2.Controls.Add(this.btnShowBookings);
            this.groupBox2.Controls.Add(this.btnClearSearch);
            this.groupBox2.Controls.Add(this.datePickerBookingDateTo);
            this.groupBox2.Controls.Add(this.datePickerBookingDateFrom);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1118, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مشاهده رزرو ها بر اساس";
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.Enabled = false;
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Location = new System.Drawing.Point(441, 64);
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(111, 21);
            this.cmbOrderStatus.TabIndex = 8;
            this.cmbOrderStatus.SelectedIndexChanged += new System.EventHandler(this.cmbOrderStatus_SelectedIndexChanged);
            // 
            // chkSpecialBookings
            // 
            this.chkSpecialBookings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpecialBookings.AutoSize = true;
            // 
            // 
            // 
            this.chkSpecialBookings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSpecialBookings.Location = new System.Drawing.Point(558, 66);
            this.chkSpecialBookings.Name = "chkSpecialBookings";
            this.chkSpecialBookings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSpecialBookings.Size = new System.Drawing.Size(71, 16);
            this.chkSpecialBookings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSpecialBookings.TabIndex = 7;
            this.chkSpecialBookings.Text = "موارد خاص";
            this.chkSpecialBookings.CheckedChanged += new System.EventHandler(this.chkSpecialBookings_CheckedChanged);
            // 
            // chkEnableDatePickerBookingDate
            // 
            this.chkEnableDatePickerBookingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnableDatePickerBookingDate.AutoSize = true;
            // 
            // 
            // 
            this.chkEnableDatePickerBookingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEnableDatePickerBookingDate.Location = new System.Drawing.Point(575, 36);
            this.chkEnableDatePickerBookingDate.Name = "chkEnableDatePickerBookingDate";
            this.chkEnableDatePickerBookingDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnableDatePickerBookingDate.Size = new System.Drawing.Size(54, 16);
            this.chkEnableDatePickerBookingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEnableDatePickerBookingDate.TabIndex = 4;
            this.chkEnableDatePickerBookingDate.Text = "از تاریخ";
            this.chkEnableDatePickerBookingDate.CheckedChanged += new System.EventHandler(this.chkEnableDatePickerBookingDate_CheckedChanged);
            // 
            // rbCurrentmonth
            // 
            this.rbCurrentmonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCurrentmonth.AutoSize = true;
            // 
            // 
            // 
            this.rbCurrentmonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbCurrentmonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbCurrentmonth.Location = new System.Drawing.Point(770, 36);
            this.rbCurrentmonth.Name = "rbCurrentmonth";
            this.rbCurrentmonth.Size = new System.Drawing.Size(64, 16);
            this.rbCurrentmonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbCurrentmonth.TabIndex = 2;
            this.rbCurrentmonth.Text = "ماه جاری";
            this.rbCurrentmonth.CheckedChanged += new System.EventHandler(this.rbCurrentmonth_CheckedChanged);
            // 
            // rbCurrentWeek
            // 
            this.rbCurrentWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCurrentWeek.AutoSize = true;
            // 
            // 
            // 
            this.rbCurrentWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbCurrentWeek.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbCurrentWeek.Location = new System.Drawing.Point(855, 36);
            this.rbCurrentWeek.Name = "rbCurrentWeek";
            this.rbCurrentWeek.Size = new System.Drawing.Size(73, 16);
            this.rbCurrentWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbCurrentWeek.TabIndex = 1;
            this.rbCurrentWeek.Text = "هفته جاری";
            this.rbCurrentWeek.CheckedChanged += new System.EventHandler(this.rbCurrentWeek_CheckedChanged);
            // 
            // rbCurrentDay
            // 
            this.rbCurrentDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCurrentDay.AutoSize = true;
            // 
            // 
            // 
            this.rbCurrentDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbCurrentDay.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbCurrentDay.Location = new System.Drawing.Point(952, 36);
            this.rbCurrentDay.Name = "rbCurrentDay";
            this.rbCurrentDay.Size = new System.Drawing.Size(63, 16);
            this.rbCurrentDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbCurrentDay.TabIndex = 0;
            this.rbCurrentDay.Text = "روز جاری";
            this.rbCurrentDay.CheckedChanged += new System.EventHandler(this.rbCurrentDay_CheckedChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            // 
            // 
            // 
            this.lblToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblToDate.Location = new System.Drawing.Point(382, 36);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(33, 16);
            this.lblToDate.TabIndex = 23;
            this.lblToDate.Text = "تا تاریخ";
            this.lblToDate.Visible = false;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(930, 66);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(85, 16);
            this.labelX1.TabIndex = 21;
            this.labelX1.Text = "اطلاعات مشتری ";
            // 
            // txtCustomerInfo
            // 
            this.txtCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCustomerInfo.Border.Class = "TextBoxBorder";
            this.txtCustomerInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerInfo.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtCustomerInfo.FocusHighlightEnabled = true;
            this.txtCustomerInfo.Location = new System.Drawing.Point(690, 64);
            this.txtCustomerInfo.Name = "txtCustomerInfo";
            this.txtCustomerInfo.PreventEnterBeep = true;
            this.txtCustomerInfo.Size = new System.Drawing.Size(238, 21);
            this.txtCustomerInfo.TabIndex = 3;
            this.txtCustomerInfo.WatermarkText = "(نام ، نام خانوادگی ، تلفن ثابت، تلفن همراه)";
            // 
            // btnShowBookings
            // 
            this.btnShowBookings.FlatAppearance.BorderSize = 0;
            this.btnShowBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBookings.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_Search_text_131785;
            this.btnShowBookings.Location = new System.Drawing.Point(47, 58);
            this.btnShowBookings.Name = "btnShowBookings";
            this.btnShowBookings.Size = new System.Drawing.Size(32, 32);
            this.btnShowBookings.TabIndex = 9;
            this.btnShowBookings.UseVisualStyleBackColor = true;
            this.btnShowBookings.Click += new System.EventHandler(this.btnShowBookings_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_Gnome_Edit_Clear_32_54970;
            this.btnClearSearch.Location = new System.Drawing.Point(9, 58);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(32, 32);
            this.btnClearSearch.TabIndex = 10;
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // datePickerBookingDateTo
            // 
            this.datePickerBookingDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerBookingDateTo.BackColor = System.Drawing.Color.White;
            this.datePickerBookingDateTo.Enabled = false;
            this.datePickerBookingDateTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerBookingDateTo.Location = new System.Drawing.Point(262, 35);
            this.datePickerBookingDateTo.Name = "datePickerBookingDateTo";
            this.datePickerBookingDateTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerBookingDateTo.ShowTime = false;
            this.datePickerBookingDateTo.Size = new System.Drawing.Size(111, 18);
            this.datePickerBookingDateTo.TabIndex = 6;
            this.datePickerBookingDateTo.Text = "persianDateTimePicker1";
            this.datePickerBookingDateTo.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerBookingDateTo.Value")));
            this.datePickerBookingDateTo.Visible = false;
            // 
            // datePickerBookingDateFrom
            // 
            this.datePickerBookingDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerBookingDateFrom.BackColor = System.Drawing.Color.White;
            this.datePickerBookingDateFrom.Enabled = false;
            this.datePickerBookingDateFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerBookingDateFrom.Location = new System.Drawing.Point(441, 35);
            this.datePickerBookingDateFrom.Name = "datePickerBookingDateFrom";
            this.datePickerBookingDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerBookingDateFrom.ShowTime = false;
            this.datePickerBookingDateFrom.Size = new System.Drawing.Size(111, 18);
            this.datePickerBookingDateFrom.TabIndex = 5;
            this.datePickerBookingDateFrom.Text = "persianDateTimePicker1";
            this.datePickerBookingDateFrom.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerBookingDateFrom.Value")));
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvOrders);
            this.groupBox1.Location = new System.Drawing.Point(12, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1123, 434);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لیست رزرو ها";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmCustomerId,
            this.clmBookingId,
            this.clmOrderCode,
            this.clmCustomerFullName,
            this.clmDate,
            this.clmTime,
            this.clmPhotographyTypeId,
            this.clmPhotographyTypeName,
            this.clmPhotographerGenderType,
            this.clmPersonCount,
            this.clmStatusId,
            this.clmTotalFiles,
            this.clmOrderStatusCode,
            this.clmStatusName,
            this.clmCreatedDateTime,
            this.clmModifiedDateTime});
            this.dgvOrders.ContextMenuStrip = this.contextMenuStripDgvBookings;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvOrders.Location = new System.Drawing.Point(3, 17);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.ShowEditingIcon = false;
            this.dgvOrders.Size = new System.Drawing.Size(1117, 414);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvBookings_MouseUp);
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
            this.clmCustomerId.HeaderText = "clmUserId";
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
            this.clmOrderCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmOrderCode.DataPropertyName = "OrderCode";
            this.clmOrderCode.HeaderText = "شناسه سفارش";
            this.clmOrderCode.MinimumWidth = 150;
            this.clmOrderCode.Name = "clmOrderCode";
            this.clmOrderCode.ReadOnly = true;
            this.clmOrderCode.Width = 150;
            // 
            // clmCustomerFullName
            // 
            this.clmCustomerFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmCustomerFullName.DataPropertyName = "CustomerFullName";
            this.clmCustomerFullName.HeaderText = "نام مشتری";
            this.clmCustomerFullName.MinimumWidth = 200;
            this.clmCustomerFullName.Name = "clmCustomerFullName";
            this.clmCustomerFullName.ReadOnly = true;
            this.clmCustomerFullName.Width = 200;
            // 
            // clmDate
            // 
            this.clmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmDate.DataPropertyName = "Date";
            this.clmDate.HeaderText = "تاریخ";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            this.clmDate.Width = 80;
            // 
            // clmTime
            // 
            this.clmTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmTime.DataPropertyName = "Time";
            this.clmTime.HeaderText = "ساعت";
            this.clmTime.Name = "clmTime";
            this.clmTime.ReadOnly = true;
            this.clmTime.Width = 80;
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
            this.clmPhotographyTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmPhotographyTypeName.DataPropertyName = "PhotographyTypeName";
            this.clmPhotographyTypeName.HeaderText = "نوع عکس";
            this.clmPhotographyTypeName.MinimumWidth = 100;
            this.clmPhotographyTypeName.Name = "clmPhotographyTypeName";
            this.clmPhotographyTypeName.ReadOnly = true;
            this.clmPhotographyTypeName.Width = 120;
            // 
            // clmPhotographerGenderType
            // 
            this.clmPhotographerGenderType.DataPropertyName = "PhotographerGenderTypeName";
            this.clmPhotographerGenderType.HeaderText = "عکاس";
            this.clmPhotographerGenderType.Name = "clmPhotographerGenderType";
            this.clmPhotographerGenderType.ReadOnly = true;
            // 
            // clmPersonCount
            // 
            this.clmPersonCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmPersonCount.DataPropertyName = "PersonCount";
            this.clmPersonCount.HeaderText = "تعداد نفرات";
            this.clmPersonCount.MinimumWidth = 100;
            this.clmPersonCount.Name = "clmPersonCount";
            this.clmPersonCount.ReadOnly = true;
            // 
            // clmStatusId
            // 
            this.clmStatusId.DataPropertyName = "StatusId";
            this.clmStatusId.HeaderText = "clmStatusId";
            this.clmStatusId.Name = "clmStatusId";
            this.clmStatusId.ReadOnly = true;
            this.clmStatusId.Visible = false;
            // 
            // clmTotalFiles
            // 
            this.clmTotalFiles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmTotalFiles.DataPropertyName = "TotalFiles";
            this.clmTotalFiles.HeaderText = "تعداد عکس ها";
            this.clmTotalFiles.MinimumWidth = 120;
            this.clmTotalFiles.Name = "clmTotalFiles";
            this.clmTotalFiles.ReadOnly = true;
            this.clmTotalFiles.Width = 120;
            // 
            // clmOrderStatusCode
            // 
            this.clmOrderStatusCode.DataPropertyName = "StatusCode";
            this.clmOrderStatusCode.HeaderText = "کد وضعیت سفارش";
            this.clmOrderStatusCode.Name = "clmOrderStatusCode";
            this.clmOrderStatusCode.ReadOnly = true;
            this.clmOrderStatusCode.Visible = false;
            // 
            // clmStatusName
            // 
            this.clmStatusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmStatusName.DataPropertyName = "StatusName";
            this.clmStatusName.HeaderText = "وضعیت";
            this.clmStatusName.Name = "clmStatusName";
            this.clmStatusName.ReadOnly = true;
            // 
            // clmCreatedDateTime
            // 
            this.clmCreatedDateTime.DataPropertyName = "CreatedDateTime";
            this.clmCreatedDateTime.HeaderText = "تاریخ ثبت";
            this.clmCreatedDateTime.Name = "clmCreatedDateTime";
            this.clmCreatedDateTime.ReadOnly = true;
            this.clmCreatedDateTime.Visible = false;
            // 
            // clmModifiedDateTime
            // 
            this.clmModifiedDateTime.DataPropertyName = "ModifiedDateTime";
            this.clmModifiedDateTime.HeaderText = "تاریخ ویرایش";
            this.clmModifiedDateTime.Name = "clmModifiedDateTime";
            this.clmModifiedDateTime.ReadOnly = true;
            this.clmModifiedDateTime.Visible = false;
            // 
            // contextMenuStripDgvBookings
            // 
            this.contextMenuStripDgvBookings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenuStripDgvBookings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایشاطلاعاتمشتریToolStripMenuItem,
            this.ارسالعکسToolStripMenuItem,
            this.مشاهدهعکسهاToolStripMenuItem,
            this.حذفعکسهاToolStripMenuItem,
            this.درخواستصدورقبضToolStripMenuItem});
            this.contextMenuStripDgvBookings.Name = "contextMenuStripDgvBookings";
            this.contextMenuStripDgvBookings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStripDgvBookings.Size = new System.Drawing.Size(197, 136);
            this.contextMenuStripDgvBookings.Paint += new System.Windows.Forms.PaintEventHandler(this.contextMenuStripDgvBookings_Paint);
            // 
            // ویرایشاطلاعاتمشتریToolStripMenuItem
            // 
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Name = "ویرایشاطلاعاتمشتریToolStripMenuItem";
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Text = "ویرایش اطلاعات مشتری";
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Click += new System.EventHandler(this.ویرایشاطلاعاتمشتریToolStripMenuItem_Click);
            // 
            // ارسالعکسToolStripMenuItem
            // 
            this.ارسالعکسToolStripMenuItem.Enabled = false;
            this.ارسالعکسToolStripMenuItem.Name = "ارسالعکسToolStripMenuItem";
            this.ارسالعکسToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ارسالعکسToolStripMenuItem.Text = "ارسال عکس";
            this.ارسالعکسToolStripMenuItem.Click += new System.EventHandler(this.ارسالعکسToolStripMenuItem_Click);
            // 
            // مشاهدهعکسهاToolStripMenuItem
            // 
            this.مشاهدهعکسهاToolStripMenuItem.Enabled = false;
            this.مشاهدهعکسهاToolStripMenuItem.Name = "مشاهدهعکسهاToolStripMenuItem";
            this.مشاهدهعکسهاToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.مشاهدهعکسهاToolStripMenuItem.Text = "مشاهده عکس ها";
            // 
            // حذفعکسهاToolStripMenuItem
            // 
            this.حذفعکسهاToolStripMenuItem.Enabled = false;
            this.حذفعکسهاToolStripMenuItem.Name = "حذفعکسهاToolStripMenuItem";
            this.حذفعکسهاToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.حذفعکسهاToolStripMenuItem.Text = "حذف عکس ها";
            // 
            // درخواستصدورقبضToolStripMenuItem
            // 
            this.درخواستصدورقبضToolStripMenuItem.Enabled = false;
            this.درخواستصدورقبضToolStripMenuItem.Name = "درخواستصدورقبضToolStripMenuItem";
            this.درخواستصدورقبضToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.درخواستصدورقبضToolStripMenuItem.Text = "درخواست صدور قبض";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1022, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "جستجو بر اساس:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1147, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FrmShowIncommingBookings
            // 
            this.AcceptButton = this.btnShowBookings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 580);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowIncommingBookings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده رزروهای رسیده";
            this.Load += new System.EventHandler(this.FrmShowIncommingBookings_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.contextMenuStripDgvBookings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSpecialBookings;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEnableDatePickerBookingDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbCurrentmonth;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbCurrentWeek;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbCurrentDay;
        private DevComponents.DotNetBar.LabelX lblToDate;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerInfo;
        private System.Windows.Forms.Button btnShowBookings;
        private System.Windows.Forms.Button btnClearSearch;
        private FreeControls.PersianDateTimePicker datePickerBookingDateTo;
        private FreeControls.PersianDateTimePicker datePickerBookingDateFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvOrders;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgvBookings;
        private System.Windows.Forms.ToolStripMenuItem ویرایشاطلاعاتمشتریToolStripMenuItem;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ToolStripMenuItem ارسالعکسToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.ToolStripMenuItem مشاهدهعکسهاToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBookingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographyTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographerGenderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderStatusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmModifiedDateTime;
        private System.Windows.Forms.ToolStripMenuItem حذفعکسهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem درخواستصدورقبضToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}