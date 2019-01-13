namespace PhotographyAutomation.App.Forms.Booking
{
    partial class FrmAddEditBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditBooking));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timePickerBookingTime = new Telerik.WinControls.UI.RadTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerBookingDate = new FreeControls.PersianDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstNameLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPhotographerTypes = new System.Windows.Forms.Panel();
            this.rbFemalePhotographer = new System.Windows.Forms.RadioButton();
            this.rbMalePhotographer = new System.Windows.Forms.RadioButton();
            this.rbNoMatterPhotographer = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvBookingHistory = new Telerik.WinControls.UI.RadGridView();
            this.txtTell = new System.Windows.Forms.MaskedTextBox();
            this.txtMobile = new System.Windows.Forms.MaskedTextBox();
            this.cmbPhotographyTypes = new Telerik.WinControls.UI.RadDropDownList();
            this.cmbAtelierTypes = new Telerik.WinControls.UI.RadDropDownList();
            this.cmbBookingStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPersonCount = new Telerik.WinControls.UI.RadSpinEditor();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timePickerBookingTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelPhotographerTypes.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhotographyTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAtelierTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookingStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(797, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 36);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "ثبت نوبت";
            this.btnOk.ThemeName = "Office2010Silver";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(681, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.ThemeName = "Office2010Silver";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 507);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(919, 60);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.groupBox3);
            this.panelEx2.Controls.Add(this.groupBox2);
            this.panelEx2.Controls.Add(this.groupBox1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(919, 507);
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
            this.groupBox2.Controls.Add(this.txtPersonCount);
            this.groupBox2.Controls.Add(this.cmbBookingStatus);
            this.groupBox2.Controls.Add(this.cmbAtelierTypes);
            this.groupBox2.Controls.Add(this.cmbPhotographyTypes);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.panelPhotographerTypes);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.timePickerBookingTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dateTimePickerBookingDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(895, 147);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات رزرواسیون";
            // 
            // timePickerBookingTime
            // 
            this.timePickerBookingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePickerBookingTime.CloseButtonText = "بستن";
            this.timePickerBookingTime.Culture = new System.Globalization.CultureInfo("en-US");
            this.timePickerBookingTime.EnableKeyMap = true;
            this.timePickerBookingTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.timePickerBookingTime.Location = new System.Drawing.Point(470, 36);
            this.timePickerBookingTime.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.timePickerBookingTime.MinValue = new System.DateTime(((long)(0)));
            this.timePickerBookingTime.Name = "timePickerBookingTime";
            this.timePickerBookingTime.Size = new System.Drawing.Size(111, 21);
            this.timePickerBookingTime.TabIndex = 1;
            this.timePickerBookingTime.TabStop = false;
            this.timePickerBookingTime.ThemeName = "Office2010Silver";
            this.timePickerBookingTime.Value = new System.DateTime(2019, 1, 10, 20, 15, 58, 785);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ساعت";
            // 
            // dateTimePickerBookingDate
            // 
            this.dateTimePickerBookingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerBookingDate.BackColor = System.Drawing.Color.White;
            this.dateTimePickerBookingDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePickerBookingDate.Location = new System.Drawing.Point(670, 38);
            this.dateTimePickerBookingDate.Name = "dateTimePickerBookingDate";
            this.dateTimePickerBookingDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePickerBookingDate.ShowTime = false;
            this.dateTimePickerBookingDate.Size = new System.Drawing.Size(111, 18);
            this.dateTimePickerBookingDate.TabIndex = 0;
            this.dateTimePickerBookingDate.Text = "persianDateTimePicker1";
            this.dateTimePickerBookingDate.Value = ((FreeControls.PersianDate)(resources.GetObject("dateTimePickerBookingDate.Value")));
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(787, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "تاریخ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.txtTell);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFirstNameLastName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات مشتری";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "تلفن همراه";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(587, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "تلفن ثابت";
            // 
            // txtFirstNameLastName
            // 
            // 
            // 
            // 
            this.txtFirstNameLastName.Border.Class = "TextBoxBorder";
            this.txtFirstNameLastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstNameLastName.DisabledBackColor = System.Drawing.Color.White;
            this.txtFirstNameLastName.Location = new System.Drawing.Point(670, 39);
            this.txtFirstNameLastName.Name = "txtFirstNameLastName";
            this.txtFirstNameLastName.PreventEnterBeep = true;
            this.txtFirstNameLastName.ReadOnly = true;
            this.txtFirstNameLastName.Size = new System.Drawing.Size(111, 21);
            this.txtFirstNameLastName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(787, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام و نام خانوادگی";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "عکاس";
            // 
            // panelPhotographerTypes
            // 
            this.panelPhotographerTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPhotographerTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPhotographerTypes.Controls.Add(this.rbNoMatterPhotographer);
            this.panelPhotographerTypes.Controls.Add(this.rbMalePhotographer);
            this.panelPhotographerTypes.Controls.Add(this.rbFemalePhotographer);
            this.panelPhotographerTypes.Location = new System.Drawing.Point(168, 32);
            this.panelPhotographerTypes.Name = "panelPhotographerTypes";
            this.panelPhotographerTypes.Size = new System.Drawing.Size(205, 32);
            this.panelPhotographerTypes.TabIndex = 2;
            // 
            // rbFemalePhotographer
            // 
            this.rbFemalePhotographer.AutoSize = true;
            this.rbFemalePhotographer.Location = new System.Drawing.Point(151, 6);
            this.rbFemalePhotographer.Name = "rbFemalePhotographer";
            this.rbFemalePhotographer.Size = new System.Drawing.Size(46, 17);
            this.rbFemalePhotographer.TabIndex = 0;
            this.rbFemalePhotographer.TabStop = true;
            this.rbFemalePhotographer.Text = "خانم";
            this.rbFemalePhotographer.UseVisualStyleBackColor = true;
            // 
            // rbMalePhotographer
            // 
            this.rbMalePhotographer.AutoSize = true;
            this.rbMalePhotographer.Location = new System.Drawing.Point(98, 6);
            this.rbMalePhotographer.Name = "rbMalePhotographer";
            this.rbMalePhotographer.Size = new System.Drawing.Size(36, 17);
            this.rbMalePhotographer.TabIndex = 1;
            this.rbMalePhotographer.TabStop = true;
            this.rbMalePhotographer.Text = "آقا";
            this.rbMalePhotographer.UseVisualStyleBackColor = true;
            // 
            // rbNoMatterPhotographer
            // 
            this.rbNoMatterPhotographer.AutoSize = true;
            this.rbNoMatterPhotographer.Location = new System.Drawing.Point(3, 6);
            this.rbNoMatterPhotographer.Name = "rbNoMatterPhotographer";
            this.rbNoMatterPhotographer.Size = new System.Drawing.Size(75, 17);
            this.rbNoMatterPhotographer.TabIndex = 2;
            this.rbNoMatterPhotographer.TabStop = true;
            this.rbNoMatterPhotographer.Text = "فرقی ندارد";
            this.rbNoMatterPhotographer.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(787, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "نوع عکس";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(587, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "آتلیه";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "تعداد";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(145, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "وضعیت نوبت";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvBookingHistory);
            this.groupBox3.Location = new System.Drawing.Point(12, 271);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(895, 233);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تاریخچه نوبت های قبلی";
            // 
            // dgvBookingHistory
            // 
            this.dgvBookingHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookingHistory.Location = new System.Drawing.Point(3, 17);
            // 
            // 
            // 
            this.dgvBookingHistory.MasterTemplate.AllowAddNewRow = false;
            this.dgvBookingHistory.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvBookingHistory.Name = "dgvBookingHistory";
            this.dgvBookingHistory.ReadOnly = true;
            this.dgvBookingHistory.Size = new System.Drawing.Size(889, 213);
            this.dgvBookingHistory.TabIndex = 0;
            this.dgvBookingHistory.ThemeName = "Office2010Silver";
            // 
            // txtTell
            // 
            this.txtTell.Location = new System.Drawing.Point(470, 39);
            this.txtTell.Mask = "(9999) 000 00 00";
            this.txtTell.Name = "txtTell";
            this.txtTell.ReadOnly = true;
            this.txtTell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTell.Size = new System.Drawing.Size(111, 21);
            this.txtTell.TabIndex = 1;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(262, 39);
            this.txtMobile.Mask = "(9999) 000 0000";
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.ReadOnly = true;
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(111, 21);
            this.txtMobile.TabIndex = 2;
            // 
            // cmbPhotographyTypes
            // 
            this.cmbPhotographyTypes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbPhotographyTypes.EnableAlternatingItemColor = true;
            this.cmbPhotographyTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPhotographyTypes.Location = new System.Drawing.Point(670, 90);
            this.cmbPhotographyTypes.Name = "cmbPhotographyTypes";
            this.cmbPhotographyTypes.Size = new System.Drawing.Size(111, 20);
            this.cmbPhotographyTypes.TabIndex = 3;
            this.cmbPhotographyTypes.ThemeName = "Office2010Silver";
            // 
            // cmbAtelierTypes
            // 
            this.cmbAtelierTypes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbAtelierTypes.EnableAlternatingItemColor = true;
            this.cmbAtelierTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAtelierTypes.Location = new System.Drawing.Point(470, 90);
            this.cmbAtelierTypes.Name = "cmbAtelierTypes";
            this.cmbAtelierTypes.Size = new System.Drawing.Size(111, 20);
            this.cmbAtelierTypes.TabIndex = 4;
            this.cmbAtelierTypes.ThemeName = "Office2010Silver";
            // 
            // cmbBookingStatus
            // 
            this.cmbBookingStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbBookingStatus.EnableAlternatingItemColor = true;
            this.cmbBookingStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbBookingStatus.Location = new System.Drawing.Point(30, 90);
            this.cmbBookingStatus.Name = "cmbBookingStatus";
            this.cmbBookingStatus.Size = new System.Drawing.Size(111, 20);
            this.cmbBookingStatus.TabIndex = 6;
            this.cmbBookingStatus.ThemeName = "Office2010Silver";
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPersonCount.Location = new System.Drawing.Point(262, 90);
            this.txtPersonCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.Size = new System.Drawing.Size(111, 20);
            this.txtPersonCount.TabIndex = 5;
            this.txtPersonCount.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPersonCount.ThemeName = "Office2010Silver";
            // 
            // FrmAddEditBooking
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(919, 567);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAddEditBooking";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت / ویرایش نوبت";
            this.Load += new System.EventHandler(this.FrmAddEditBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timePickerBookingTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPhotographerTypes.ResumeLayout(false);
            this.panelPhotographerTypes.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhotographyTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAtelierTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookingStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadTimePicker timePickerBookingTime;
        private System.Windows.Forms.Label label5;
        private FreeControls.PersianDateTimePicker dateTimePickerBookingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstNameLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelPhotographerTypes;
        private System.Windows.Forms.RadioButton rbNoMatterPhotographer;
        private System.Windows.Forms.RadioButton rbMalePhotographer;
        private System.Windows.Forms.RadioButton rbFemalePhotographer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadGridView dgvBookingHistory;
        private System.Windows.Forms.MaskedTextBox txtMobile;
        private System.Windows.Forms.MaskedTextBox txtTell;
        private Telerik.WinControls.UI.RadDropDownList cmbPhotographyTypes;
        private Telerik.WinControls.UI.RadDropDownList cmbBookingStatus;
        private Telerik.WinControls.UI.RadDropDownList cmbAtelierTypes;
        private Telerik.WinControls.UI.RadSpinEditor txtPersonCount;
    }
}