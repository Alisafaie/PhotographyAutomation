namespace PhotographyAutomation.App.Forms.Booking
{
    partial class FrmAddEditCustomerInfo
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBoxCustomerInfo = new System.Windows.Forms.GroupBox();
            this.cmbRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbUserType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Customer = new DevComponents.Editors.ComboItem();
            this.Employee = new DevComponents.Editors.ComboItem();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCustomerType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Green = new DevComponents.Editors.ComboItem();
            this.Red = new DevComponents.Editors.ComboItem();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMobile = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTell = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label20 = new System.Windows.Forms.Label();
            this.txtWeddingDate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtBirthDate = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.cmbActiveStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Enable = new DevComponents.Editors.ComboItem();
            this.Disable = new DevComponents.Editors.ComboItem();
            this.cmbMarriedStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Single = new DevComponents.Editors.ComboItem();
            this.Married = new DevComponents.Editors.ComboItem();
            this.Unknown = new DevComponents.Editors.ComboItem();
            this.cmbGender = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Male = new DevComponents.Editors.ComboItem();
            this.Female = new DevComponents.Editors.ComboItem();
            this.txtNationalId = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxSearchCustomer = new System.Windows.Forms.GroupBox();
            this.btnSearchCustomer = new Telerik.WinControls.UI.RadButton();
            this.btnCheckNumber = new Telerik.WinControls.UI.RadButton();
            this.txtMobileSearch = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupBoxCustomerInfo.SuspendLayout();
            this.groupBoxSearchCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(574, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 36);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "ثبت اطلاعات مشتری";
            this.btnOk.ThemeName = "Office2010Silver";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(458, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.ThemeName = "Office2010Silver";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 435);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(696, 60);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.groupBoxCustomerInfo);
            this.panelEx2.Controls.Add(this.groupBoxSearchCustomer);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(696, 435);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // groupBoxCustomerInfo
            // 
            this.groupBoxCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCustomerInfo.Controls.Add(this.txtEmail);
            this.groupBoxCustomerInfo.Controls.Add(this.label15);
            this.groupBoxCustomerInfo.Controls.Add(this.cmbRole);
            this.groupBoxCustomerInfo.Controls.Add(this.cmbUserType);
            this.groupBoxCustomerInfo.Controls.Add(this.label14);
            this.groupBoxCustomerInfo.Controls.Add(this.cmbCustomerType);
            this.groupBoxCustomerInfo.Controls.Add(this.label19);
            this.groupBoxCustomerInfo.Controls.Add(this.txtMobile);
            this.groupBoxCustomerInfo.Controls.Add(this.txtUserName);
            this.groupBoxCustomerInfo.Controls.Add(this.txtTell);
            this.groupBoxCustomerInfo.Controls.Add(this.label20);
            this.groupBoxCustomerInfo.Controls.Add(this.txtWeddingDate);
            this.groupBoxCustomerInfo.Controls.Add(this.txtBirthDate);
            this.groupBoxCustomerInfo.Controls.Add(this.cmbActiveStatus);
            this.groupBoxCustomerInfo.Controls.Add(this.cmbMarriedStatus);
            this.groupBoxCustomerInfo.Controls.Add(this.cmbGender);
            this.groupBoxCustomerInfo.Controls.Add(this.txtNationalId);
            this.groupBoxCustomerInfo.Controls.Add(this.txtAddress);
            this.groupBoxCustomerInfo.Controls.Add(this.label13);
            this.groupBoxCustomerInfo.Controls.Add(this.label12);
            this.groupBoxCustomerInfo.Controls.Add(this.label11);
            this.groupBoxCustomerInfo.Controls.Add(this.label10);
            this.groupBoxCustomerInfo.Controls.Add(this.label9);
            this.groupBoxCustomerInfo.Controls.Add(this.label8);
            this.groupBoxCustomerInfo.Controls.Add(this.txtLastName);
            this.groupBoxCustomerInfo.Controls.Add(this.label7);
            this.groupBoxCustomerInfo.Controls.Add(this.label6);
            this.groupBoxCustomerInfo.Controls.Add(this.label5);
            this.groupBoxCustomerInfo.Controls.Add(this.label4);
            this.groupBoxCustomerInfo.Controls.Add(this.label3);
            this.groupBoxCustomerInfo.Controls.Add(this.txtFirstName);
            this.groupBoxCustomerInfo.Controls.Add(this.label2);
            this.groupBoxCustomerInfo.Location = new System.Drawing.Point(12, 101);
            this.groupBoxCustomerInfo.Name = "groupBoxCustomerInfo";
            this.groupBoxCustomerInfo.Size = new System.Drawing.Size(672, 320);
            this.groupBoxCustomerInfo.TabIndex = 1;
            this.groupBoxCustomerInfo.TabStop = false;
            this.groupBoxCustomerInfo.Text = "اطلاعات مشتری";
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DisplayMember = "Text";
            this.cmbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.ItemHeight = 16;
            this.cmbRole.Location = new System.Drawing.Point(21, 154);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(107, 22);
            this.cmbRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbRole.TabIndex = 13;
            // 
            // cmbUserType
            // 
            this.cmbUserType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUserType.DisplayMember = "Text";
            this.cmbUserType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.ItemHeight = 16;
            this.cmbUserType.Items.AddRange(new object[] {
            this.Customer,
            this.Employee});
            this.cmbUserType.Location = new System.Drawing.Point(21, 66);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(107, 22);
            this.cmbUserType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbUserType.TabIndex = 11;
            // 
            // Customer
            // 
            this.Customer.Text = "مشتری";
            this.Customer.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Customer.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Employee
            // 
            this.Employee.Text = "کارمند";
            this.Employee.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Employee.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(134, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "نوع شخص";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomerType.DisplayMember = "Text";
            this.cmbCustomerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.ItemHeight = 16;
            this.cmbCustomerType.Items.AddRange(new object[] {
            this.Green,
            this.Red});
            this.cmbCustomerType.Location = new System.Drawing.Point(21, 22);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(107, 22);
            this.cmbCustomerType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerType.TabIndex = 10;
            // 
            // Green
            // 
            this.Green.Text = "سبز";
            this.Green.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Green.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Red
            // 
            this.Red.Text = "قرمز";
            this.Red.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Red.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(134, 159);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "مسئولیت";
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtMobile.BackgroundStyle.Class = "TextBoxBorder";
            this.txtMobile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMobile.ButtonClear.Visible = true;
            this.txtMobile.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtMobile.FocusHighlightEnabled = true;
            this.txtMobile.Location = new System.Drawing.Point(247, 67);
            this.txtMobile.Mask = "900 000 00 00";
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(107, 21);
            this.txtMobile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtMobile.TabIndex = 6;
            this.txtMobile.Text = "";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.DisabledBackColor = System.Drawing.Color.White;
            this.txtUserName.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(21, 111);
            this.txtUserName.MaxLength = 200;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PreventEnterBeep = true;
            this.txtUserName.Size = new System.Drawing.Size(107, 21);
            this.txtUserName.TabIndex = 12;
            this.txtUserName.WatermarkText = "نام کاربری";
            // 
            // txtTell
            // 
            this.txtTell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTell.BackgroundStyle.Class = "TextBoxBorder";
            this.txtTell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTell.ButtonClear.Visible = true;
            this.txtTell.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtTell.FocusHighlightEnabled = true;
            this.txtTell.Location = new System.Drawing.Point(247, 23);
            this.txtTell.Mask = "313 000 00 00";
            this.txtTell.Name = "txtTell";
            this.txtTell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTell.Size = new System.Drawing.Size(107, 21);
            this.txtTell.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtTell.TabIndex = 5;
            this.txtTell.Text = "";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(134, 115);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "نام کاربری";
            // 
            // txtWeddingDate
            // 
            this.txtWeddingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtWeddingDate.BackgroundStyle.Class = "TextBoxBorder";
            this.txtWeddingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWeddingDate.ButtonClear.Visible = true;
            this.txtWeddingDate.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtWeddingDate.FocusHighlightEnabled = true;
            this.txtWeddingDate.Location = new System.Drawing.Point(247, 155);
            this.txtWeddingDate.Mask = "1300/00/00";
            this.txtWeddingDate.Name = "txtWeddingDate";
            this.txtWeddingDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWeddingDate.Size = new System.Drawing.Size(107, 21);
            this.txtWeddingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtWeddingDate.TabIndex = 8;
            this.txtWeddingDate.Text = "";
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBirthDate.BackgroundStyle.Class = "TextBoxBorder";
            this.txtBirthDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBirthDate.ButtonClear.Visible = true;
            this.txtBirthDate.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtBirthDate.FocusHighlightEnabled = true;
            this.txtBirthDate.Location = new System.Drawing.Point(473, 155);
            this.txtBirthDate.Mask = "1300/00/00";
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBirthDate.Size = new System.Drawing.Size(107, 20);
            this.txtBirthDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtBirthDate.TabIndex = 3;
            this.txtBirthDate.Text = "";
            // 
            // cmbActiveStatus
            // 
            this.cmbActiveStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbActiveStatus.DisplayMember = "Text";
            this.cmbActiveStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbActiveStatus.FormattingEnabled = true;
            this.cmbActiveStatus.ItemHeight = 16;
            this.cmbActiveStatus.Items.AddRange(new object[] {
            this.Disable,
            this.Enable});
            this.cmbActiveStatus.Location = new System.Drawing.Point(21, 198);
            this.cmbActiveStatus.Name = "cmbActiveStatus";
            this.cmbActiveStatus.Size = new System.Drawing.Size(107, 22);
            this.cmbActiveStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbActiveStatus.TabIndex = 14;
            // 
            // Enable
            // 
            this.Enable.Text = "فعال";
            this.Enable.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Enable.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Disable
            // 
            this.Disable.Text = "غیر فعال";
            this.Disable.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Disable.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cmbMarriedStatus
            // 
            this.cmbMarriedStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMarriedStatus.DisplayMember = "Text";
            this.cmbMarriedStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMarriedStatus.FormattingEnabled = true;
            this.cmbMarriedStatus.ItemHeight = 16;
            this.cmbMarriedStatus.Items.AddRange(new object[] {
            this.Single,
            this.Married,
            this.Unknown});
            this.cmbMarriedStatus.Location = new System.Drawing.Point(247, 110);
            this.cmbMarriedStatus.Name = "cmbMarriedStatus";
            this.cmbMarriedStatus.Size = new System.Drawing.Size(107, 22);
            this.cmbMarriedStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMarriedStatus.TabIndex = 7;
            // 
            // Single
            // 
            this.Single.Text = "مجرد";
            this.Single.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Single.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Married
            // 
            this.Married.Text = "متاهل";
            this.Married.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Married.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Unknown
            // 
            this.Unknown.Text = "نامشخص";
            this.Unknown.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Unknown.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cmbGender
            // 
            this.cmbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGender.DisplayMember = "Text";
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.cmbGender.FocusHighlightEnabled = true;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.ItemHeight = 16;
            this.cmbGender.Items.AddRange(new object[] {
            this.Female,
            this.Male});
            this.cmbGender.Location = new System.Drawing.Point(473, 110);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(107, 22);
            this.cmbGender.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbGender.TabIndex = 2;
            // 
            // Male
            // 
            this.Male.Text = "مرد";
            this.Male.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Male.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Female
            // 
            this.Female.Text = "زن";
            this.Female.TextAlignment = System.Drawing.StringAlignment.Far;
            this.Female.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtNationalId
            // 
            this.txtNationalId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtNationalId.BackgroundStyle.Class = "TextBoxBorder";
            this.txtNationalId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNationalId.ButtonClear.Visible = true;
            this.txtNationalId.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtNationalId.FocusHighlightEnabled = true;
            this.txtNationalId.Location = new System.Drawing.Point(473, 199);
            this.txtNationalId.Mask = "000-000-00-00";
            this.txtNationalId.Name = "txtNationalId";
            this.txtNationalId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNationalId.Size = new System.Drawing.Size(107, 20);
            this.txtNationalId.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtNationalId.TabIndex = 4;
            this.txtNationalId.Text = "";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.DisabledBackColor = System.Drawing.Color.White;
            this.txtAddress.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtAddress.FocusHighlightEnabled = true;
            this.txtAddress.Location = new System.Drawing.Point(21, 245);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PreventEnterBeep = true;
            this.txtAddress.Size = new System.Drawing.Size(554, 53);
            this.txtAddress.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(134, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "وضعیت فعالیت";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(134, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "نوع مشتری";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(360, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "تاریخ ازدواج";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(360, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "وضعیت ازدواج";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(586, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "تاریخ تولد";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(586, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "کد ملی";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLastName.DisabledBackColor = System.Drawing.Color.White;
            this.txtLastName.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtLastName.FocusHighlightEnabled = true;
            this.txtLastName.Location = new System.Drawing.Point(473, 67);
            this.txtLastName.MaxLength = 200;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PreventEnterBeep = true;
            this.txtLastName.Size = new System.Drawing.Size(107, 21);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.WatermarkText = "نام خانوادگی مشتری";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(586, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "نشانی";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "تلفن همراه";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "تلفن ثابت";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(586, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "جنسیت";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "نام خانوادگی";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstName.DisabledBackColor = System.Drawing.Color.White;
            this.txtFirstName.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtFirstName.FocusHighlightEnabled = true;
            this.txtFirstName.Location = new System.Drawing.Point(473, 23);
            this.txtFirstName.MaxLength = 200;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PreventEnterBeep = true;
            this.txtFirstName.Size = new System.Drawing.Size(107, 21);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.WatermarkText = "نام مشتری";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(586, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "نام";
            // 
            // groupBoxSearchCustomer
            // 
            this.groupBoxSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearchCustomer.Controls.Add(this.btnSearchCustomer);
            this.groupBoxSearchCustomer.Controls.Add(this.btnCheckNumber);
            this.groupBoxSearchCustomer.Controls.Add(this.txtMobileSearch);
            this.groupBoxSearchCustomer.Controls.Add(this.label1);
            this.groupBoxSearchCustomer.Location = new System.Drawing.Point(80, 14);
            this.groupBoxSearchCustomer.Name = "groupBoxSearchCustomer";
            this.groupBoxSearchCustomer.Size = new System.Drawing.Size(604, 81);
            this.groupBoxSearchCustomer.TabIndex = 0;
            this.groupBoxSearchCustomer.TabStop = false;
            this.groupBoxSearchCustomer.Text = "بررسی مشتری";
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSearchCustomer.Location = new System.Drawing.Point(6, 27);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(110, 36);
            this.btnSearchCustomer.TabIndex = 2;
            this.btnSearchCustomer.Text = "جستجوی پیشرفته";
            this.btnSearchCustomer.ThemeName = "Office2010Silver";
            // 
            // btnCheckNumber
            // 
            this.btnCheckNumber.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCheckNumber.Location = new System.Drawing.Point(122, 27);
            this.btnCheckNumber.Name = "btnCheckNumber";
            this.btnCheckNumber.Size = new System.Drawing.Size(110, 36);
            this.btnCheckNumber.TabIndex = 1;
            this.btnCheckNumber.Text = "بررسی شماره همراه";
            this.btnCheckNumber.ThemeName = "Office2010Silver";
            this.btnCheckNumber.Click += new System.EventHandler(this.btnCheckNumber_Click);
            // 
            // txtMobileSearch
            // 
            this.txtMobileSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtMobileSearch.BackgroundStyle.Class = "TextBoxBorder";
            this.txtMobileSearch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMobileSearch.ButtonClear.Visible = true;
            this.txtMobileSearch.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtMobileSearch.FocusHighlightEnabled = true;
            this.txtMobileSearch.Location = new System.Drawing.Point(411, 33);
            this.txtMobileSearch.Mask = "000 000 0000";
            this.txtMobileSearch.Name = "txtMobileSearch";
            this.txtMobileSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobileSearch.Size = new System.Drawing.Size(107, 20);
            this.txtMobileSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtMobileSearch.TabIndex = 0;
            this.txtMobileSearch.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "تلفن همراه :";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(360, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "ایمیل";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.DisabledBackColor = System.Drawing.Color.White;
            this.txtEmail.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtEmail.FocusHighlightEnabled = true;
            this.txtEmail.Location = new System.Drawing.Point(247, 199);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PreventEnterBeep = true;
            this.txtEmail.Size = new System.Drawing.Size(107, 21);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEmail.WatermarkText = "test@test.coom";
            // 
            // FrmAddEditCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(696, 495);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditCustomerInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت / ویرایش رزرو";
            this.Load += new System.EventHandler(this.FrmAddEditCustomerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.groupBoxCustomerInfo.ResumeLayout(false);
            this.groupBoxCustomerInfo.PerformLayout();
            this.groupBoxSearchCustomer.ResumeLayout(false);
            this.groupBoxSearchCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.GroupBox groupBoxCustomerInfo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerType;
        private DevComponents.Editors.ComboItem Green;
        private DevComponents.Editors.ComboItem Red;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtMobile;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtTell;
        private System.Windows.Forms.Label label19;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private System.Windows.Forms.Label label20;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtWeddingDate;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtBirthDate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbActiveStatus;
        private DevComponents.Editors.ComboItem Enable;
        private DevComponents.Editors.ComboItem Disable;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMarriedStatus;
        private DevComponents.Editors.ComboItem Single;
        private DevComponents.Editors.ComboItem Married;
        private DevComponents.Editors.ComboItem Unknown;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbGender;
        private DevComponents.Editors.ComboItem Male;
        private DevComponents.Editors.ComboItem Female;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtNationalId;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxSearchCustomer;
        private Telerik.WinControls.UI.RadButton btnSearchCustomer;
        private Telerik.WinControls.UI.RadButton btnCheckNumber;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtMobileSearch;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbUserType;
        private DevComponents.Editors.ComboItem Customer;
        private DevComponents.Editors.ComboItem Employee;
        private System.Windows.Forms.Label label14;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbRole;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private System.Windows.Forms.Label label15;
    }
}