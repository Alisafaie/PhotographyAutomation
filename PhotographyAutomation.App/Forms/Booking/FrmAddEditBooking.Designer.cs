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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditBooking));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelCurrentBooking = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvBookingHistory = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenu_dgvBookingHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ویرایشنوبتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxBookingInfo = new System.Windows.Forms.GroupBox();
            this.txtPersonCount = new DevComponents.Editors.IntegerInput();
            this.cmbPhotographyTypes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbAtelierTypes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbPhotographerGender = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.datePickerBookingDate = new FreeControls.PersianDateTimePicker();
            this.btnShowFrmSelectBookingTime = new System.Windows.Forms.Button();
            this.txtBookingTime = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBookingStatus = new System.Windows.Forms.TextBox();
            this.txtFirstNameLastName = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.MaskedTextBox();
            this.txtTell = new System.Windows.Forms.MaskedTextBox();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clmBookingStatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmModifiedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).BeginInit();
            this.contextMenu_dgvBookingHistory.SuspendLayout();
            this.groupBoxBookingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.Controls.Add(this.btnCancelCurrentBooking);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 475);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1020, 60);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOk.Location = new System.Drawing.Point(898, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 36);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "ثبت نوبت";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelCurrentBooking
            // 
            this.btnCancelCurrentBooking.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelCurrentBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelCurrentBooking.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelCurrentBooking.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancelCurrentBooking.Location = new System.Drawing.Point(782, 12);
            this.btnCancelCurrentBooking.Name = "btnCancelCurrentBooking";
            this.btnCancelCurrentBooking.Size = new System.Drawing.Size(110, 36);
            this.btnCancelCurrentBooking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelCurrentBooking.TabIndex = 1;
            this.btnCancelCurrentBooking.Text = "انصراف";
            this.btnCancelCurrentBooking.Click += new System.EventHandler(this.btnCancelCurrentBooking_Click);
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
            this.panelEx2.Controls.Add(this.groupBoxBookingInfo);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1020, 475);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvBookingHistory);
            this.groupBox3.Location = new System.Drawing.Point(12, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(996, 230);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تاریخچه نوبت های مشتری";
            // 
            // dgvBookingHistory
            // 
            this.dgvBookingHistory.AllowUserToAddRows = false;
            this.dgvBookingHistory.AllowUserToDeleteRows = false;
            this.dgvBookingHistory.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBookingHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookingHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvBookingHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookingHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookingHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookingHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmUserId,
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
            this.clmBookingStatusCode,
            this.clmCreatedDateTime,
            this.clmModifiedDateTime});
            this.dgvBookingHistory.ContextMenuStrip = this.contextMenu_dgvBookingHistory;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookingHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBookingHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBookingHistory.EnableHeadersVisualStyles = false;
            this.dgvBookingHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvBookingHistory.Location = new System.Drawing.Point(3, 27);
            this.dgvBookingHistory.MultiSelect = false;
            this.dgvBookingHistory.Name = "dgvBookingHistory";
            this.dgvBookingHistory.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookingHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBookingHistory.RowHeadersVisible = false;
            this.dgvBookingHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBookingHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookingHistory.ShowEditingIcon = false;
            this.dgvBookingHistory.Size = new System.Drawing.Size(990, 200);
            this.dgvBookingHistory.TabIndex = 0;
            this.dgvBookingHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookingHistory_CellDoubleClick);
            this.dgvBookingHistory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvBookingHistory_MouseUp);
            // 
            // contextMenu_dgvBookingHistory
            // 
            this.contextMenu_dgvBookingHistory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu_dgvBookingHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایشنوبتToolStripMenuItem});
            this.contextMenu_dgvBookingHistory.Name = "contextMenu_dgvBookingHistory";
            this.contextMenu_dgvBookingHistory.Size = new System.Drawing.Size(136, 26);
            // 
            // ویرایشنوبتToolStripMenuItem
            // 
            this.ویرایشنوبتToolStripMenuItem.Image = global::PhotographyAutomation.App.Properties.Resources._132685___modify;
            this.ویرایشنوبتToolStripMenuItem.Name = "ویرایشنوبتToolStripMenuItem";
            this.ویرایشنوبتToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ویرایشنوبتToolStripMenuItem.Text = "ویرایش نوبت";
            this.ویرایشنوبتToolStripMenuItem.Click += new System.EventHandler(this.ویرایشنوبتToolStripMenuItem_Click);
            // 
            // groupBoxBookingInfo
            // 
            this.groupBoxBookingInfo.Controls.Add(this.txtPersonCount);
            this.groupBoxBookingInfo.Controls.Add(this.cmbPhotographyTypes);
            this.groupBoxBookingInfo.Controls.Add(this.cmbAtelierTypes);
            this.groupBoxBookingInfo.Controls.Add(this.cmbPhotographerGender);
            this.groupBoxBookingInfo.Controls.Add(this.datePickerBookingDate);
            this.groupBoxBookingInfo.Controls.Add(this.btnShowFrmSelectBookingTime);
            this.groupBoxBookingInfo.Controls.Add(this.txtBookingTime);
            this.groupBoxBookingInfo.Controls.Add(this.label10);
            this.groupBoxBookingInfo.Controls.Add(this.label9);
            this.groupBoxBookingInfo.Controls.Add(this.label8);
            this.groupBoxBookingInfo.Controls.Add(this.label7);
            this.groupBoxBookingInfo.Controls.Add(this.label6);
            this.groupBoxBookingInfo.Controls.Add(this.label5);
            this.groupBoxBookingInfo.Controls.Add(this.label4);
            this.groupBoxBookingInfo.Controls.Add(this.txtBookingStatus);
            this.groupBoxBookingInfo.Controls.Add(this.txtFirstNameLastName);
            this.groupBoxBookingInfo.Controls.Add(this.txtMobile);
            this.groupBoxBookingInfo.Controls.Add(this.txtTell);
            this.groupBoxBookingInfo.Controls.Add(this.line2);
            this.groupBoxBookingInfo.Controls.Add(this.line1);
            this.groupBoxBookingInfo.Controls.Add(this.label12);
            this.groupBoxBookingInfo.Controls.Add(this.label11);
            this.groupBoxBookingInfo.Controls.Add(this.label3);
            this.groupBoxBookingInfo.Controls.Add(this.label2);
            this.groupBoxBookingInfo.Controls.Add(this.label1);
            this.groupBoxBookingInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBoxBookingInfo.Location = new System.Drawing.Point(12, 3);
            this.groupBoxBookingInfo.Name = "groupBoxBookingInfo";
            this.groupBoxBookingInfo.Size = new System.Drawing.Size(996, 217);
            this.groupBoxBookingInfo.TabIndex = 0;
            this.groupBoxBookingInfo.TabStop = false;
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPersonCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPersonCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPersonCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPersonCount.DisabledBackColor = System.Drawing.Color.White;
            this.txtPersonCount.DisabledForeColor = System.Drawing.Color.Black;
            this.txtPersonCount.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtPersonCount.FocusHighlightEnabled = true;
            this.txtPersonCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPersonCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.txtPersonCount.Location = new System.Drawing.Point(361, 124);
            this.txtPersonCount.MaxValue = 100;
            this.txtPersonCount.MinValue = 1;
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.ShowUpDown = true;
            this.txtPersonCount.Size = new System.Drawing.Size(111, 21);
            this.txtPersonCount.TabIndex = 3;
            this.txtPersonCount.Value = 1;
            // 
            // cmbPhotographyTypes
            // 
            this.cmbPhotographyTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPhotographyTypes.DisplayMember = "Text";
            this.cmbPhotographyTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhotographyTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhotographyTypes.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.cmbPhotographyTypes.FocusHighlightEnabled = true;
            this.cmbPhotographyTypes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPhotographyTypes.FormattingEnabled = true;
            this.cmbPhotographyTypes.ItemHeight = 16;
            this.cmbPhotographyTypes.Location = new System.Drawing.Point(771, 174);
            this.cmbPhotographyTypes.Name = "cmbPhotographyTypes";
            this.cmbPhotographyTypes.Size = new System.Drawing.Size(111, 22);
            this.cmbPhotographyTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPhotographyTypes.TabIndex = 4;
            this.cmbPhotographyTypes.SelectedIndexChanged += new System.EventHandler(this.cmbPhotographyTypes_SelectedIndexChanged);
            // 
            // cmbAtelierTypes
            // 
            this.cmbAtelierTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAtelierTypes.DisplayMember = "Text";
            this.cmbAtelierTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAtelierTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAtelierTypes.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.cmbAtelierTypes.FocusHighlightEnabled = true;
            this.cmbAtelierTypes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAtelierTypes.FormattingEnabled = true;
            this.cmbAtelierTypes.ItemHeight = 16;
            this.cmbAtelierTypes.Location = new System.Drawing.Point(571, 175);
            this.cmbAtelierTypes.Name = "cmbAtelierTypes";
            this.cmbAtelierTypes.Size = new System.Drawing.Size(111, 22);
            this.cmbAtelierTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAtelierTypes.TabIndex = 5;
            // 
            // cmbPhotographerGender
            // 
            this.cmbPhotographerGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPhotographerGender.DisplayMember = "Text";
            this.cmbPhotographerGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhotographerGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhotographerGender.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.cmbPhotographerGender.FocusHighlightEnabled = true;
            this.cmbPhotographerGender.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPhotographerGender.FormattingEnabled = true;
            this.cmbPhotographerGender.ItemHeight = 16;
            this.cmbPhotographerGender.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cmbPhotographerGender.Location = new System.Drawing.Point(361, 174);
            this.cmbPhotographerGender.Name = "cmbPhotographerGender";
            this.cmbPhotographerGender.Size = new System.Drawing.Size(111, 22);
            this.cmbPhotographerGender.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPhotographerGender.TabIndex = 6;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "خانم";
            this.comboItem1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "آقا";
            this.comboItem2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "فرقی ندارد";
            this.comboItem3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // datePickerBookingDate
            // 
            this.datePickerBookingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerBookingDate.BackColor = System.Drawing.Color.White;
            this.datePickerBookingDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerBookingDate.Location = new System.Drawing.Point(771, 125);
            this.datePickerBookingDate.Name = "datePickerBookingDate";
            this.datePickerBookingDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerBookingDate.ShowTime = false;
            this.datePickerBookingDate.Size = new System.Drawing.Size(111, 19);
            this.datePickerBookingDate.TabIndex = 0;
            this.datePickerBookingDate.Text = "persianDateTimePicker1";
            this.datePickerBookingDate.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerBookingDate.Value")));
            // 
            // btnShowFrmSelectBookingTime
            // 
            this.btnShowFrmSelectBookingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowFrmSelectBookingTime.BackColor = System.Drawing.Color.Transparent;
            this.btnShowFrmSelectBookingTime.FlatAppearance.BorderSize = 0;
            this.btnShowFrmSelectBookingTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFrmSelectBookingTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnShowFrmSelectBookingTime.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_Clock_728924__1_;
            this.btnShowFrmSelectBookingTime.Location = new System.Drawing.Point(573, 126);
            this.btnShowFrmSelectBookingTime.Name = "btnShowFrmSelectBookingTime";
            this.btnShowFrmSelectBookingTime.Size = new System.Drawing.Size(17, 17);
            this.btnShowFrmSelectBookingTime.TabIndex = 2;
            this.btnShowFrmSelectBookingTime.UseVisualStyleBackColor = false;
            this.btnShowFrmSelectBookingTime.Click += new System.EventHandler(this.btnShowFrmSelectBookingTime_Click);
            // 
            // txtBookingTime
            // 
            this.txtBookingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBookingTime.Border.Class = "TextBoxBorder";
            this.txtBookingTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBookingTime.DisabledBackColor = System.Drawing.Color.White;
            this.txtBookingTime.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtBookingTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBookingTime.Location = new System.Drawing.Point(571, 124);
            this.txtBookingTime.Name = "txtBookingTime";
            this.txtBookingTime.PreventEnterBeep = true;
            this.txtBookingTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBookingTime.Size = new System.Drawing.Size(111, 21);
            this.txtBookingTime.TabIndex = 1;
            this.txtBookingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBookingTime.Enter += new System.EventHandler(this.btnShowFrmSelectBookingTime_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(246, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "وضعیت نوبت";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(478, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "تعداد";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(688, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "آتلیه";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(888, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "نوع عکس";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(478, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "عکاس";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(688, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ساعت";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(888, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "تاریخ";
            // 
            // txtBookingStatus
            // 
            this.txtBookingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookingStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBookingStatus.Location = new System.Drawing.Point(129, 176);
            this.txtBookingStatus.Name = "txtBookingStatus";
            this.txtBookingStatus.ReadOnly = true;
            this.txtBookingStatus.Size = new System.Drawing.Size(111, 21);
            this.txtBookingStatus.TabIndex = 30;
            this.txtBookingStatus.TabStop = false;
            // 
            // txtFirstNameLastName
            // 
            this.txtFirstNameLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstNameLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFirstNameLastName.Location = new System.Drawing.Point(771, 52);
            this.txtFirstNameLastName.Name = "txtFirstNameLastName";
            this.txtFirstNameLastName.ReadOnly = true;
            this.txtFirstNameLastName.Size = new System.Drawing.Size(111, 21);
            this.txtFirstNameLastName.TabIndex = 30;
            this.txtFirstNameLastName.TabStop = false;
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtMobile.Location = new System.Drawing.Point(361, 52);
            this.txtMobile.Mask = "(9999) 000 00 00";
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.ReadOnly = true;
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(111, 21);
            this.txtMobile.TabIndex = 29;
            this.txtMobile.TabStop = false;
            // 
            // txtTell
            // 
            this.txtTell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTell.Location = new System.Drawing.Point(571, 52);
            this.txtTell.Mask = "(9999) 000 00 00";
            this.txtTell.Name = "txtTell";
            this.txtTell.ReadOnly = true;
            this.txtTell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTell.Size = new System.Drawing.Size(111, 21);
            this.txtTell.TabIndex = 29;
            this.txtTell.TabStop = false;
            // 
            // line2
            // 
            this.line2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.line2.Location = new System.Drawing.Point(16, 94);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(866, 10);
            this.line2.TabIndex = 21;
            this.line2.Text = "=";
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.line1.Location = new System.Drawing.Point(16, 21);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(866, 10);
            this.line1.TabIndex = 21;
            this.line1.Text = "line1";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(924, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 14);
            this.label12.TabIndex = 20;
            this.label12.Text = "اطلاعات رزرو";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(903, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 14);
            this.label11.TabIndex = 20;
            this.label11.Text = "اطلاعات مشتری";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(478, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "تلفن همراه";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(688, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "تلفن ثابت";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(888, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام و نام خانوادگی";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
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
            // clmUserId
            // 
            this.clmUserId.DataPropertyName = "CustomerId";
            this.clmUserId.HeaderText = "clmUserId";
            this.clmUserId.Name = "clmUserId";
            this.clmUserId.ReadOnly = true;
            this.clmUserId.Visible = false;
            this.clmUserId.Width = 60;
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
            this.clmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDate.HeaderText = "تاریخ";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            // 
            // clmTime
            // 
            this.clmTime.DataPropertyName = "Time";
            this.clmTime.HeaderText = "ساعت";
            this.clmTime.Name = "clmTime";
            this.clmTime.ReadOnly = true;
            this.clmTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.clmPaymentIsOK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmPaymentIsOK.DataPropertyName = "PaymentIsOK";
            this.clmPaymentIsOK.HeaderText = "وضعیت پرداخت";
            this.clmPaymentIsOK.Name = "clmPaymentIsOK";
            this.clmPaymentIsOK.ReadOnly = true;
            this.clmPaymentIsOK.Width = 120;
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
            this.clmStatusName.HeaderText = "وضعیت نوبت";
            this.clmStatusName.Name = "clmStatusName";
            this.clmStatusName.ReadOnly = true;
            // 
            // clmBookingStatusCode
            // 
            this.clmBookingStatusCode.DataPropertyName = "BookingStatusCode";
            this.clmBookingStatusCode.HeaderText = "BookingStatusCode";
            this.clmBookingStatusCode.Name = "clmBookingStatusCode";
            this.clmBookingStatusCode.ReadOnly = true;
            this.clmBookingStatusCode.Visible = false;
            this.clmBookingStatusCode.Width = 125;
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
            // FrmAddEditBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 535);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditBooking";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت / ویرایش نوبت";
            this.Load += new System.EventHandler(this.FrmAddEditBooking_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).EndInit();
            this.contextMenu_dgvBookingHistory.ResumeLayout(false);
            this.groupBoxBookingInfo.ResumeLayout(false);
            this.groupBoxBookingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.GroupBox groupBoxBookingInfo;
        private System.Windows.Forms.Label label5;
        private FreeControls.PersianDateTimePicker datePickerBookingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBookingHistory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.Line line2;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBookingTime;
        private System.Windows.Forms.Button btnShowFrmSelectBookingTime;
        private System.Windows.Forms.MaskedTextBox txtMobile;
        private System.Windows.Forms.MaskedTextBox txtTell;
        private System.Windows.Forms.TextBox txtFirstNameLastName;
        private DevComponents.DotNetBar.ButtonX btnCancelCurrentBooking;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPhotographyTypes;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbAtelierTypes;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPhotographerGender;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.IntegerInput txtPersonCount;
        private System.Windows.Forms.TextBox txtBookingStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenu_dgvBookingHistory;
        private System.Windows.Forms.ToolStripMenuItem ویرایشنوبتToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUserId;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBookingStatusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmModifiedDateTime;
    }
}