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
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvBookingHistory = new DevComponents.DotNetBar.Controls.DataGridViewX();
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
            this.clmCreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmModifiedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBookingStatus = new Telerik.WinControls.UI.RadTextBox();
            this.txtPersonCount = new Telerik.WinControls.UI.RadSpinEditor();
            this.cmbAtelierTypes = new Telerik.WinControls.UI.RadDropDownList();
            this.cmbPhotographyTypes = new Telerik.WinControls.UI.RadDropDownList();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelPhotographerTypes = new System.Windows.Forms.Panel();
            this.rbNoMatterPhotographer = new System.Windows.Forms.RadioButton();
            this.rbMalePhotographer = new System.Windows.Forms.RadioButton();
            this.rbFemalePhotographer = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.timePickerBookingTime = new Telerik.WinControls.UI.RadTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.datePickerBookingDate = new FreeControls.PersianDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMobile = new System.Windows.Forms.MaskedTextBox();
            this.txtTell = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstNameLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookingStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAtelierTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhotographyTypes)).BeginInit();
            this.panelPhotographerTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timePickerBookingTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.panelEx1.Location = new System.Drawing.Point(0, 530);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(954, 60);
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
            this.panelEx2.Size = new System.Drawing.Size(954, 530);
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
            this.groupBox3.Controls.Add(this.dgvBookingHistory);
            this.groupBox3.Location = new System.Drawing.Point(12, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(930, 275);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تاریخچه نوبت های قبلی";
            // 
            // dgvBookingHistory
            // 
            this.dgvBookingHistory.AllowUserToAddRows = false;
            this.dgvBookingHistory.AllowUserToDeleteRows = false;
            this.dgvBookingHistory.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBookingHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookingHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.clmCreatedDateTime,
            this.clmModifiedDateTime});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookingHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBookingHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookingHistory.EnableHeadersVisualStyles = false;
            this.dgvBookingHistory.GridColor = System.Drawing.Color.White;
            this.dgvBookingHistory.Location = new System.Drawing.Point(3, 17);
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
            this.dgvBookingHistory.Size = new System.Drawing.Size(924, 255);
            this.dgvBookingHistory.TabIndex = 0;
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
            this.clmUserId.DataPropertyName = "UserId";
            this.clmUserId.HeaderText = "clmUserId";
            this.clmUserId.Name = "clmUserId";
            this.clmUserId.ReadOnly = true;
            this.clmUserId.Visible = false;
            this.clmUserId.Width = 60;
            // 
            // clmCustomerFullName
            // 
            this.clmCustomerFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCustomerFullName.DataPropertyName = "CustomerFullName";
            this.clmCustomerFullName.HeaderText = "نام مشتری";
            this.clmCustomerFullName.Name = "clmCustomerFullName";
            this.clmCustomerFullName.ReadOnly = true;
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
            this.clmPaymentIsOK.DataPropertyName = "PaymentIsOK";
            this.clmPaymentIsOK.HeaderText = "وضعیت پرداخت";
            this.clmPaymentIsOK.Name = "clmPaymentIsOK";
            this.clmPaymentIsOK.ReadOnly = true;
            this.clmPaymentIsOK.Width = 102;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBookingStatus);
            this.groupBox2.Controls.Add(this.txtPersonCount);
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
            this.groupBox2.Controls.Add(this.datePickerBookingDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(930, 117);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات رزرواسیون";
            // 
            // txtBookingStatus
            // 
            this.txtBookingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookingStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBookingStatus.Location = new System.Drawing.Point(63, 81);
            this.txtBookingStatus.Name = "txtBookingStatus";
            this.txtBookingStatus.ReadOnly = true;
            this.txtBookingStatus.Size = new System.Drawing.Size(111, 19);
            this.txtBookingStatus.TabIndex = 6;
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPersonCount.Location = new System.Drawing.Point(295, 82);
            this.txtPersonCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPersonCount.Size = new System.Drawing.Size(111, 20);
            this.txtPersonCount.TabIndex = 5;
            this.txtPersonCount.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPersonCount.ThemeName = "Office2010Silver";
            // 
            // cmbAtelierTypes
            // 
            this.cmbAtelierTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAtelierTypes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbAtelierTypes.EnableAlternatingItemColor = true;
            this.cmbAtelierTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAtelierTypes.Location = new System.Drawing.Point(505, 82);
            this.cmbAtelierTypes.Name = "cmbAtelierTypes";
            this.cmbAtelierTypes.Size = new System.Drawing.Size(111, 20);
            this.cmbAtelierTypes.TabIndex = 4;
            this.cmbAtelierTypes.ThemeName = "Office2010Silver";
            // 
            // cmbPhotographyTypes
            // 
            this.cmbPhotographyTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPhotographyTypes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbPhotographyTypes.EnableAlternatingItemColor = true;
            this.cmbPhotographyTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPhotographyTypes.Location = new System.Drawing.Point(705, 82);
            this.cmbPhotographyTypes.Name = "cmbPhotographyTypes";
            this.cmbPhotographyTypes.Size = new System.Drawing.Size(111, 20);
            this.cmbPhotographyTypes.TabIndex = 3;
            this.cmbPhotographyTypes.ThemeName = "Office2010Silver";
            this.cmbPhotographyTypes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbPhotographyTypes_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "وضعیت نوبت";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "تعداد";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(622, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "آتلیه";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(822, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "نوع عکس";
            // 
            // panelPhotographerTypes
            // 
            this.panelPhotographerTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPhotographerTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPhotographerTypes.Controls.Add(this.rbNoMatterPhotographer);
            this.panelPhotographerTypes.Controls.Add(this.rbMalePhotographer);
            this.panelPhotographerTypes.Controls.Add(this.rbFemalePhotographer);
            this.panelPhotographerTypes.Location = new System.Drawing.Point(201, 23);
            this.panelPhotographerTypes.Name = "panelPhotographerTypes";
            this.panelPhotographerTypes.Size = new System.Drawing.Size(205, 32);
            this.panelPhotographerTypes.TabIndex = 2;
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
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "عکاس";
            // 
            // timePickerBookingTime
            // 
            this.timePickerBookingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePickerBookingTime.CloseButtonText = "بستن";
            this.timePickerBookingTime.Culture = new System.Globalization.CultureInfo("en-US");
            this.timePickerBookingTime.EnableKeyMap = true;
            this.timePickerBookingTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.timePickerBookingTime.Location = new System.Drawing.Point(505, 29);
            this.timePickerBookingTime.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.timePickerBookingTime.MinValue = new System.DateTime(((long)(0)));
            this.timePickerBookingTime.Name = "timePickerBookingTime";
            this.timePickerBookingTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            this.label5.Location = new System.Drawing.Point(622, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ساعت";
            // 
            // datePickerBookingDate
            // 
            this.datePickerBookingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerBookingDate.BackColor = System.Drawing.Color.White;
            this.datePickerBookingDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerBookingDate.Location = new System.Drawing.Point(705, 31);
            this.datePickerBookingDate.Name = "datePickerBookingDate";
            this.datePickerBookingDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerBookingDate.ShowTime = false;
            this.datePickerBookingDate.Size = new System.Drawing.Size(111, 18);
            this.datePickerBookingDate.TabIndex = 0;
            this.datePickerBookingDate.Text = "persianDateTimePicker1";
            this.datePickerBookingDate.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerBookingDate.Value")));
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(822, 33);
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
            this.groupBox1.Size = new System.Drawing.Size(930, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات مشتری";
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Location = new System.Drawing.Point(295, 40);
            this.txtMobile.Mask = "(9999) 000 0000";
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.ReadOnly = true;
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(111, 21);
            this.txtMobile.TabIndex = 2;
            // 
            // txtTell
            // 
            this.txtTell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTell.Location = new System.Drawing.Point(505, 39);
            this.txtTell.Mask = "(9999) 000 00 00";
            this.txtTell.Name = "txtTell";
            this.txtTell.ReadOnly = true;
            this.txtTell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTell.Size = new System.Drawing.Size(111, 21);
            this.txtTell.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "تلفن همراه";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "تلفن ثابت";
            // 
            // txtFirstNameLastName
            // 
            this.txtFirstNameLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFirstNameLastName.Border.Class = "TextBoxBorder";
            this.txtFirstNameLastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstNameLastName.DisabledBackColor = System.Drawing.Color.White;
            this.txtFirstNameLastName.Location = new System.Drawing.Point(705, 39);
            this.txtFirstNameLastName.Name = "txtFirstNameLastName";
            this.txtFirstNameLastName.PreventEnterBeep = true;
            this.txtFirstNameLastName.ReadOnly = true;
            this.txtFirstNameLastName.Size = new System.Drawing.Size(111, 21);
            this.txtFirstNameLastName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(822, 43);
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
            // FrmAddEditBooking
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(954, 590);
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
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookingStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAtelierTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhotographyTypes)).EndInit();
            this.panelPhotographerTypes.ResumeLayout(false);
            this.panelPhotographerTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timePickerBookingTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private FreeControls.PersianDateTimePicker datePickerBookingDate;
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
        private System.Windows.Forms.MaskedTextBox txtMobile;
        private System.Windows.Forms.MaskedTextBox txtTell;
        private Telerik.WinControls.UI.RadDropDownList cmbPhotographyTypes;
        private Telerik.WinControls.UI.RadDropDownList cmbAtelierTypes;
        private Telerik.WinControls.UI.RadSpinEditor txtPersonCount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadTextBox txtBookingStatus;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBookingHistory;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmModifiedDateTime;
    }
}