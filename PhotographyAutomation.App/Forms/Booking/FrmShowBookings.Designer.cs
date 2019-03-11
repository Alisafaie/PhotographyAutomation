namespace PhotographyAutomation.App.Forms.Booking
{
    partial class FrmShowBookings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowBookings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtCustomerInfo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnShowBookings = new System.Windows.Forms.Button();
            this.cmbBookinsStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.chkEnableDatePickerBookingDate = new Telerik.WinControls.UI.RadCheckBox();
            this.chkSpecialBookings = new Telerik.WinControls.UI.RadCheckBox();
            this.datePickerBookingDateTo = new FreeControls.PersianDateTimePicker();
            this.datePickerBookingDateFrom = new FreeControls.PersianDateTimePicker();
            this.rbCurrentmonth = new Telerik.WinControls.UI.RadRadioButton();
            this.rbCurrentWeek = new Telerik.WinControls.UI.RadRadioButton();
            this.rbCurrentDay = new Telerik.WinControls.UI.RadRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvBookings = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStripDgvBookings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ویرایشاطلاعاتمشتریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشاطلاعاتنوبتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تبدیلبهسفارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشاطلاعاتمشتریToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.رزروهای_امروزToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.رزروهای_هفته_جاری_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._رزروهای_ماه_جاریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._رزروهای_تاریخ_خاصToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._رزروهای_ویژهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._ویرایش_اطلاعات_رزروToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._تبدیل_به_سفارش_رزروToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographerGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographerGenderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographyTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhotographyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAtelierTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAtelierTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPersonCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaymentIsOK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubmitter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubmitterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmModifiedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookinsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableDatePickerBookingDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSpecialBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCurrentmonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCurrentWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCurrentDay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.contextMenuStripDgvBookings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.groupBox2);
            this.panelEx2.Controls.Add(this.groupBox1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1160, 665);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelX3);
            this.groupBox2.Controls.Add(this.labelX2);
            this.groupBox2.Controls.Add(this.labelX1);
            this.groupBox2.Controls.Add(this.txtCustomerInfo);
            this.groupBox2.Controls.Add(this.btnShowBookings);
            this.groupBox2.Controls.Add(this.cmbBookinsStatus);
            this.groupBox2.Controls.Add(this.chkEnableDatePickerBookingDate);
            this.groupBox2.Controls.Add(this.chkSpecialBookings);
            this.groupBox2.Controls.Add(this.datePickerBookingDateTo);
            this.groupBox2.Controls.Add(this.datePickerBookingDateFrom);
            this.groupBox2.Controls.Add(this.rbCurrentmonth);
            this.groupBox2.Controls.Add(this.rbCurrentWeek);
            this.groupBox2.Controls.Add(this.rbCurrentDay);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1136, 90);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مشاهده رزرو ها بر اساس";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Gray;
            this.labelX2.Location = new System.Drawing.Point(91, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(206, 16);
            this.labelX2.TabIndex = 22;
            this.labelX2.Text = "(نام ، نام خانوادگی ، تلفن ثابت، تلفن همراه)";
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(303, 38);
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
            this.txtCustomerInfo.Location = new System.Drawing.Point(91, 36);
            this.txtCustomerInfo.Name = "txtCustomerInfo";
            this.txtCustomerInfo.PreventEnterBeep = true;
            this.txtCustomerInfo.Size = new System.Drawing.Size(206, 21);
            this.txtCustomerInfo.TabIndex = 19;
            this.txtCustomerInfo.Enter += new System.EventHandler(this.txtCustomerInfo_Enter);
            this.txtCustomerInfo.Leave += new System.EventHandler(this.txtCustomerInfo_Leave);
            // 
            // btnShowBookings
            // 
            this.btnShowBookings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowBookings.FlatAppearance.BorderSize = 0;
            this.btnShowBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBookings.Image = global::PhotographyAutomation.App.Properties.Resources._27877___find_magnifying_glass_search_zoom;
            this.btnShowBookings.Location = new System.Drawing.Point(53, 30);
            this.btnShowBookings.Name = "btnShowBookings";
            this.btnShowBookings.Size = new System.Drawing.Size(32, 32);
            this.btnShowBookings.TabIndex = 7;
            this.btnShowBookings.UseVisualStyleBackColor = true;
            this.btnShowBookings.Click += new System.EventHandler(this.btnShowBookings_Click);
            // 
            // cmbBookinsStatus
            // 
            this.cmbBookinsStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBookinsStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbBookinsStatus.EnableAlternatingItemColor = true;
            this.cmbBookinsStatus.Enabled = false;
            this.cmbBookinsStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbBookinsStatus.Location = new System.Drawing.Point(422, 36);
            this.cmbBookinsStatus.Name = "cmbBookinsStatus";
            this.cmbBookinsStatus.Size = new System.Drawing.Size(125, 20);
            this.cmbBookinsStatus.TabIndex = 6;
            this.cmbBookinsStatus.ThemeName = "Office2010Silver";
            this.cmbBookinsStatus.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbBookinsStatus_SelectedIndexChanged);
            // 
            // chkEnableDatePickerBookingDate
            // 
            this.chkEnableDatePickerBookingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnableDatePickerBookingDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkEnableDatePickerBookingDate.Location = new System.Drawing.Point(768, 38);
            this.chkEnableDatePickerBookingDate.Name = "chkEnableDatePickerBookingDate";
            this.chkEnableDatePickerBookingDate.Size = new System.Drawing.Size(52, 17);
            this.chkEnableDatePickerBookingDate.TabIndex = 3;
            this.chkEnableDatePickerBookingDate.Text = "از تاریخ";
            this.chkEnableDatePickerBookingDate.ThemeName = "Office2010Silver";
            this.chkEnableDatePickerBookingDate.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkEnableDatePickerBookingDate_ToggleStateChanged);
            // 
            // chkSpecialBookings
            // 
            this.chkSpecialBookings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpecialBookings.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkSpecialBookings.Location = new System.Drawing.Point(549, 38);
            this.chkSpecialBookings.Name = "chkSpecialBookings";
            this.chkSpecialBookings.Size = new System.Drawing.Size(71, 17);
            this.chkSpecialBookings.TabIndex = 5;
            this.chkSpecialBookings.Text = "موارد خاص";
            this.chkSpecialBookings.ThemeName = "Office2010Silver";
            this.chkSpecialBookings.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkSpecialBookings_ToggleStateChanged);
            // 
            // datePickerBookingDateTo
            // 
            this.datePickerBookingDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerBookingDateTo.BackColor = System.Drawing.Color.White;
            this.datePickerBookingDateTo.Enabled = false;
            this.datePickerBookingDateTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerBookingDateTo.Location = new System.Drawing.Point(651, 61);
            this.datePickerBookingDateTo.Name = "datePickerBookingDateTo";
            this.datePickerBookingDateTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerBookingDateTo.ShowTime = false;
            this.datePickerBookingDateTo.Size = new System.Drawing.Size(111, 18);
            this.datePickerBookingDateTo.TabIndex = 4;
            this.datePickerBookingDateTo.Text = "persianDateTimePicker1";
            this.datePickerBookingDateTo.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerBookingDateTo.Value")));
            // 
            // datePickerBookingDateFrom
            // 
            this.datePickerBookingDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerBookingDateFrom.BackColor = System.Drawing.Color.White;
            this.datePickerBookingDateFrom.Enabled = false;
            this.datePickerBookingDateFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerBookingDateFrom.Location = new System.Drawing.Point(651, 37);
            this.datePickerBookingDateFrom.Name = "datePickerBookingDateFrom";
            this.datePickerBookingDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerBookingDateFrom.ShowTime = false;
            this.datePickerBookingDateFrom.Size = new System.Drawing.Size(111, 18);
            this.datePickerBookingDateFrom.TabIndex = 4;
            this.datePickerBookingDateFrom.Text = "persianDateTimePicker1";
            this.datePickerBookingDateFrom.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerBookingDateFrom.Value")));
            // 
            // rbCurrentmonth
            // 
            this.rbCurrentmonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCurrentmonth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rbCurrentmonth.Location = new System.Drawing.Point(856, 38);
            this.rbCurrentmonth.Name = "rbCurrentmonth";
            this.rbCurrentmonth.Size = new System.Drawing.Size(63, 17);
            this.rbCurrentmonth.TabIndex = 2;
            this.rbCurrentmonth.TabStop = false;
            this.rbCurrentmonth.Text = "ماه جاری";
            this.rbCurrentmonth.ThemeName = "Office2010Silver";
            // 
            // rbCurrentWeek
            // 
            this.rbCurrentWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCurrentWeek.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rbCurrentWeek.Location = new System.Drawing.Point(943, 38);
            this.rbCurrentWeek.Name = "rbCurrentWeek";
            this.rbCurrentWeek.Size = new System.Drawing.Size(72, 17);
            this.rbCurrentWeek.TabIndex = 1;
            this.rbCurrentWeek.TabStop = false;
            this.rbCurrentWeek.Text = "هفته جاری";
            this.rbCurrentWeek.ThemeName = "Office2010Silver";
            // 
            // rbCurrentDay
            // 
            this.rbCurrentDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCurrentDay.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rbCurrentDay.Location = new System.Drawing.Point(1039, 38);
            this.rbCurrentDay.Name = "rbCurrentDay";
            this.rbCurrentDay.Size = new System.Drawing.Size(61, 17);
            this.rbCurrentDay.TabIndex = 0;
            this.rbCurrentDay.TabStop = false;
            this.rbCurrentDay.Text = "روز جاری";
            this.rbCurrentDay.ThemeName = "Office2010Silver";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvBookings);
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 530);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لیست رزرو ها";
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvBookings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmCustomerId,
            this.clmCustomerFullName,
            this.clmDate,
            this.clmTime,
            this.clmPhotographerGender,
            this.clmPhotographerGenderName,
            this.clmPhotographyTypeId,
            this.clmPhotographyTypeName,
            this.clmAtelierTypeId,
            this.clmAtelierTypeName,
            this.clmPersonCount,
            this.clmPaymentIsOK,
            this.clmSubmitter,
            this.clmSubmitterName,
            this.clmStatusId,
            this.clmStatusName,
            this.clmCreatedDateTime,
            this.clmModifiedDateTime});
            this.dgvBookings.ContextMenuStrip = this.contextMenuStripDgvBookings;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookings.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookings.EnableHeadersVisualStyles = false;
            this.dgvBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvBookings.Location = new System.Drawing.Point(3, 17);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.ShowEditingIcon = false;
            this.dgvBookings.Size = new System.Drawing.Size(1130, 510);
            this.dgvBookings.TabIndex = 0;
            this.dgvBookings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvBookings_MouseUp);
            // 
            // contextMenuStripDgvBookings
            // 
            this.contextMenuStripDgvBookings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenuStripDgvBookings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایشاطلاعاتمشتریToolStripMenuItem,
            this.ویرایشاطلاعاتنوبتToolStripMenuItem,
            this.تبدیلبهسفارشToolStripMenuItem});
            this.contextMenuStripDgvBookings.Name = "contextMenuStripDgvBookings";
            this.contextMenuStripDgvBookings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStripDgvBookings.Size = new System.Drawing.Size(197, 70);
            // 
            // ویرایشاطلاعاتمشتریToolStripMenuItem
            // 
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Name = "ویرایشاطلاعاتمشتریToolStripMenuItem";
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Text = "ویرایش اطلاعات مشتری";
            this.ویرایشاطلاعاتمشتریToolStripMenuItem.Click += new System.EventHandler(this.ویرایش_اطلاعات_مشتری_ToolStripMenuItem1_Click);
            // 
            // ویرایشاطلاعاتنوبتToolStripMenuItem
            // 
            this.ویرایشاطلاعاتنوبتToolStripMenuItem.Name = "ویرایشاطلاعاتنوبتToolStripMenuItem";
            this.ویرایشاطلاعاتنوبتToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ویرایشاطلاعاتنوبتToolStripMenuItem.Text = "ویرایش اطلاعات رزرو";
            this.ویرایشاطلاعاتنوبتToolStripMenuItem.Click += new System.EventHandler(this.ویرایش_اطلاعات_رزرو_ToolStripMenuItem_Click);
            // 
            // تبدیلبهسفارشToolStripMenuItem
            // 
            this.تبدیلبهسفارشToolStripMenuItem.Name = "تبدیلبهسفارشToolStripMenuItem";
            this.تبدیلبهسفارشToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.تبدیلبهسفارشToolStripMenuItem.Text = "تبدیل به سفارش";
            this.تبدیلبهسفارشToolStripMenuItem.Click += new System.EventHandler(this.تبدیل_به_سفارش_ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.bookingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1160, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایشاطلاعاتمشتریToolStripMenuItem1});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.customerToolStripMenuItem.Text = "مشتریان";
            // 
            // ویرایشاطلاعاتمشتریToolStripMenuItem1
            // 
            this.ویرایشاطلاعاتمشتریToolStripMenuItem1.Image = global::PhotographyAutomation.App.Properties.Resources._132685___modify;
            this.ویرایشاطلاعاتمشتریToolStripMenuItem1.Name = "ویرایشاطلاعاتمشتریToolStripMenuItem1";
            this.ویرایشاطلاعاتمشتریToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.ویرایشاطلاعاتمشتریToolStripMenuItem1.Text = "ویرایش اطلاعات مشتری";
            this.ویرایشاطلاعاتمشتریToolStripMenuItem1.Click += new System.EventHandler(this.ویرایش_اطلاعات_مشتری_ToolStripMenuItem1_Click);
            // 
            // bookingToolStripMenuItem
            // 
            this.bookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.رزروهای_امروزToolStripMenuItem,
            this.رزروهای_هفته_جاری_ToolStripMenuItem,
            this._رزروهای_ماه_جاریToolStripMenuItem,
            this._رزروهای_تاریخ_خاصToolStripMenuItem,
            this._رزروهای_ویژهToolStripMenuItem,
            this.toolStripSeparator2,
            this._ویرایش_اطلاعات_رزروToolStripMenuItem1,
            this._تبدیل_به_سفارش_رزروToolStripMenuItem1});
            this.bookingToolStripMenuItem.Name = "bookingToolStripMenuItem";
            this.bookingToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.bookingToolStripMenuItem.Text = "رزرو ها";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // رزروهای_امروزToolStripMenuItem
            // 
            this.رزروهای_امروزToolStripMenuItem.Name = "رزروهای_امروزToolStripMenuItem";
            this.رزروهای_امروزToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.رزروهای_امروزToolStripMenuItem.Text = "رزرو های امروز";
            this.رزروهای_امروزToolStripMenuItem.Click += new System.EventHandler(this.رزروهای_امروزToolStripMenuItem_Click);
            // 
            // رزروهای_هفته_جاری_ToolStripMenuItem
            // 
            this.رزروهای_هفته_جاری_ToolStripMenuItem.Name = "رزروهای_هفته_جاری_ToolStripMenuItem";
            this.رزروهای_هفته_جاری_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.رزروهای_هفته_جاری_ToolStripMenuItem.Text = "رزرو های هفته جاری";
            this.رزروهای_هفته_جاری_ToolStripMenuItem.Click += new System.EventHandler(this.رزروهای_هفته_جاری_ToolStripMenuItem_Click);
            // 
            // _رزروهای_ماه_جاریToolStripMenuItem
            // 
            this._رزروهای_ماه_جاریToolStripMenuItem.Name = "_رزروهای_ماه_جاریToolStripMenuItem";
            this._رزروهای_ماه_جاریToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this._رزروهای_ماه_جاریToolStripMenuItem.Text = "رزرو های ماه جاری";
            this._رزروهای_ماه_جاریToolStripMenuItem.Click += new System.EventHandler(this._رزروهای_ماه_جاریToolStripMenuItem_Click);
            // 
            // _رزروهای_تاریخ_خاصToolStripMenuItem
            // 
            this._رزروهای_تاریخ_خاصToolStripMenuItem.Name = "_رزروهای_تاریخ_خاصToolStripMenuItem";
            this._رزروهای_تاریخ_خاصToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this._رزروهای_تاریخ_خاصToolStripMenuItem.Text = "رزروهای تاریخ خاص";
            this._رزروهای_تاریخ_خاصToolStripMenuItem.Click += new System.EventHandler(this._رزروهای_تاریخ_خاصToolStripMenuItem_Click);
            // 
            // _رزروهای_ویژهToolStripMenuItem
            // 
            this._رزروهای_ویژهToolStripMenuItem.Name = "_رزروهای_ویژهToolStripMenuItem";
            this._رزروهای_ویژهToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this._رزروهای_ویژهToolStripMenuItem.Text = "رزروهای ویژه";
            this._رزروهای_ویژهToolStripMenuItem.Click += new System.EventHandler(this._رزروهای_ویژهToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // _ویرایش_اطلاعات_رزروToolStripMenuItem1
            // 
            this._ویرایش_اطلاعات_رزروToolStripMenuItem1.Name = "_ویرایش_اطلاعات_رزروToolStripMenuItem1";
            this._ویرایش_اطلاعات_رزروToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this._ویرایش_اطلاعات_رزروToolStripMenuItem1.Text = "ویرایش اطلاعات رزرو ";
            this._ویرایش_اطلاعات_رزروToolStripMenuItem1.Click += new System.EventHandler(this.ویرایش_اطلاعات_رزرو_ToolStripMenuItem_Click);
            // 
            // _تبدیل_به_سفارش_رزروToolStripMenuItem1
            // 
            this._تبدیل_به_سفارش_رزروToolStripMenuItem1.Name = "_تبدیل_به_سفارش_رزروToolStripMenuItem1";
            this._تبدیل_به_سفارش_رزروToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this._تبدیل_به_سفارش_رزروToolStripMenuItem1.Text = "تبدیل به سفارش رزرو";
            this._تبدیل_به_سفارش_رزروToolStripMenuItem1.Click += new System.EventHandler(this.تبدیل_به_سفارش_ToolStripMenuItem_Click);
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(768, 61);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(9, 16);
            this.labelX3.TabIndex = 23;
            this.labelX3.Text = "تا";
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "Id";
            this.clmId.HeaderText = "clmId";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            this.clmId.Width = 38;
            // 
            // clmCustomerId
            // 
            this.clmCustomerId.DataPropertyName = "CustomerId";
            this.clmCustomerId.HeaderText = "clmUserId";
            this.clmCustomerId.Name = "clmCustomerId";
            this.clmCustomerId.ReadOnly = true;
            this.clmCustomerId.Visible = false;
            this.clmCustomerId.Width = 60;
            // 
            // clmCustomerFullName
            // 
            this.clmCustomerFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clmCustomerFullName.DataPropertyName = "CustomerFullName";
            this.clmCustomerFullName.HeaderText = "نام مشتری";
            this.clmCustomerFullName.Name = "clmCustomerFullName";
            this.clmCustomerFullName.ReadOnly = true;
            this.clmCustomerFullName.Width = 85;
            // 
            // clmDate
            // 
            this.clmDate.DataPropertyName = "Date";
            this.clmDate.HeaderText = "تاریخ";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            this.clmDate.Width = 53;
            // 
            // clmTime
            // 
            this.clmTime.DataPropertyName = "Time";
            this.clmTime.HeaderText = "ساعت";
            this.clmTime.Name = "clmTime";
            this.clmTime.ReadOnly = true;
            this.clmTime.Width = 63;
            // 
            // clmPhotographerGender
            // 
            this.clmPhotographerGender.DataPropertyName = "PhotographerGender";
            this.clmPhotographerGender.HeaderText = "clmPhotographerGender";
            this.clmPhotographerGender.Name = "clmPhotographerGender";
            this.clmPhotographerGender.ReadOnly = true;
            this.clmPhotographerGender.Visible = false;
            this.clmPhotographerGender.Width = 148;
            // 
            // clmPhotographerGenderName
            // 
            this.clmPhotographerGenderName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPhotographerGenderName.DataPropertyName = "PhotographerGenderName";
            this.clmPhotographerGenderName.HeaderText = "نوع عکاس";
            this.clmPhotographerGenderName.Name = "clmPhotographerGenderName";
            this.clmPhotographerGenderName.ReadOnly = true;
            // 
            // clmPhotographyTypeId
            // 
            this.clmPhotographyTypeId.DataPropertyName = "PhotographyTypeId";
            this.clmPhotographyTypeId.HeaderText = "clmPhotographyTypeId";
            this.clmPhotographyTypeId.Name = "clmPhotographyTypeId";
            this.clmPhotographyTypeId.ReadOnly = true;
            this.clmPhotographyTypeId.Visible = false;
            this.clmPhotographyTypeId.Width = 143;
            // 
            // clmPhotographyTypeName
            // 
            this.clmPhotographyTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPhotographyTypeName.DataPropertyName = "PhotographyTypeName";
            this.clmPhotographyTypeName.HeaderText = "نوع عکس";
            this.clmPhotographyTypeName.Name = "clmPhotographyTypeName";
            this.clmPhotographyTypeName.ReadOnly = true;
            // 
            // clmAtelierTypeId
            // 
            this.clmAtelierTypeId.DataPropertyName = "AtelierTypeId";
            this.clmAtelierTypeId.HeaderText = "clmAtelierTypeId";
            this.clmAtelierTypeId.Name = "clmAtelierTypeId";
            this.clmAtelierTypeId.ReadOnly = true;
            this.clmAtelierTypeId.Visible = false;
            this.clmAtelierTypeId.Width = 112;
            // 
            // clmAtelierTypeName
            // 
            this.clmAtelierTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmAtelierTypeName.DataPropertyName = "AtelierTypeName";
            this.clmAtelierTypeName.HeaderText = "نوع آتلیه";
            this.clmAtelierTypeName.Name = "clmAtelierTypeName";
            this.clmAtelierTypeName.ReadOnly = true;
            // 
            // clmPersonCount
            // 
            this.clmPersonCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPersonCount.DataPropertyName = "PersonCount";
            this.clmPersonCount.HeaderText = "تعداد نفرات";
            this.clmPersonCount.Name = "clmPersonCount";
            this.clmPersonCount.ReadOnly = true;
            // 
            // clmPaymentIsOK
            // 
            this.clmPaymentIsOK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPaymentIsOK.DataPropertyName = "PaymentIsOK";
            this.clmPaymentIsOK.HeaderText = "وضعیت پرداخت";
            this.clmPaymentIsOK.Name = "clmPaymentIsOK";
            this.clmPaymentIsOK.ReadOnly = true;
            // 
            // clmSubmitter
            // 
            this.clmSubmitter.DataPropertyName = "Submitter";
            this.clmSubmitter.HeaderText = "clmSubmitter";
            this.clmSubmitter.Name = "clmSubmitter";
            this.clmSubmitter.ReadOnly = true;
            this.clmSubmitter.Visible = false;
            this.clmSubmitter.Width = 93;
            // 
            // clmSubmitterName
            // 
            this.clmSubmitterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSubmitterName.DataPropertyName = "SubmitterName";
            this.clmSubmitterName.HeaderText = "ثبت کننده";
            this.clmSubmitterName.Name = "clmSubmitterName";
            this.clmSubmitterName.ReadOnly = true;
            // 
            // clmStatusId
            // 
            this.clmStatusId.DataPropertyName = "StatusId";
            this.clmStatusId.HeaderText = "clmStatusId";
            this.clmStatusId.Name = "clmStatusId";
            this.clmStatusId.ReadOnly = true;
            this.clmStatusId.Visible = false;
            this.clmStatusId.Width = 88;
            // 
            // clmStatusName
            // 
            this.clmStatusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmStatusName.DataPropertyName = "StatusName";
            this.clmStatusName.HeaderText = "وضعیت رزرو";
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
            this.clmCreatedDateTime.Width = 73;
            // 
            // clmModifiedDateTime
            // 
            this.clmModifiedDateTime.DataPropertyName = "ModifiedDateTime";
            this.clmModifiedDateTime.HeaderText = "تاریخ ویرایش";
            this.clmModifiedDateTime.Name = "clmModifiedDateTime";
            this.clmModifiedDateTime.ReadOnly = true;
            this.clmModifiedDateTime.Visible = false;
            this.clmModifiedDateTime.Width = 89;
            // 
            // FrmShowBookings
            // 
            this.AcceptButton = this.btnShowBookings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 665);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FrmShowBookings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده لیست نوبت ها";
            this.Load += new System.EventHandler(this.FrmShowBookings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookinsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableDatePickerBookingDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSpecialBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCurrentmonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCurrentWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCurrentDay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.contextMenuStripDgvBookings.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.GroupBox groupBox2;
        private FreeControls.PersianDateTimePicker datePickerBookingDateFrom;
        private Telerik.WinControls.UI.RadRadioButton rbCurrentmonth;
        private Telerik.WinControls.UI.RadRadioButton rbCurrentWeek;
        private Telerik.WinControls.UI.RadRadioButton rbCurrentDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBookings;
        private Telerik.WinControls.UI.RadDropDownList cmbBookinsStatus;
        private Telerik.WinControls.UI.RadCheckBox chkSpecialBookings;
        private System.Windows.Forms.Button btnShowBookings;
        private Telerik.WinControls.UI.RadCheckBox chkEnableDatePickerBookingDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgvBookings;
        private System.Windows.Forms.ToolStripMenuItem ویرایشاطلاعاتمشتریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ویرایشاطلاعاتنوبتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تبدیلبهسفارشToolStripMenuItem;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ویرایشاطلاعاتمشتریToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _ویرایش_اطلاعات_رزروToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _تبدیل_به_سفارش_رزروToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem رزروهای_امروزToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem رزروهای_هفته_جاری_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _رزروهای_ماه_جاریToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _رزروهای_ویژهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _رزروهای_تاریخ_خاصToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerInfo;
        private FreeControls.PersianDateTimePicker datePickerBookingDateTo;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographerGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographerGenderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographyTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhotographyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAtelierTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAtelierTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaymentIsOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubmitter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubmitterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmModifiedDateTime;
    }
}