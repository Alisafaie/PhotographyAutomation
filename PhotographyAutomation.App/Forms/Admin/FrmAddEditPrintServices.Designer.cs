namespace PhotographyAutomation.App.Forms.Admin
{
    partial class FrmAddEditPrintServices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrintSizes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHasPrintService = new System.Windows.Forms.Panel();
            this.rbHasNotPrintService = new System.Windows.Forms.RadioButton();
            this.rbHasPrintService = new System.Windows.Forms.RadioButton();
            this.cmbPrintServiceType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.integerInputPrintServicePrice = new DevComponents.Editors.IntegerInput();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.integerInputOriginalPrintPrice = new DevComponents.Editors.IntegerInput();
            this.label5 = new System.Windows.Forms.Label();
            this.integerInputSecondPrintPrice = new DevComponents.Editors.IntegerInput();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgWorkerLoadTable = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerLoadPrintSizes = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerLoadPrintServices = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerGetPrintSizePrices = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrintServiceCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.integerInputHeight = new DevComponents.Editors.IntegerInput();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxEnablePrintSizeItems = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.integerInputWidth = new DevComponents.Editors.IntegerInput();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelHasPrintService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputPrintServicePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputOriginalPrintPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputSecondPrintPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(928, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "اندازه چاپ";
            // 
            // cmbPrintSizes
            // 
            this.cmbPrintSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintSizes.FormattingEnabled = true;
            this.cmbPrintSizes.Location = new System.Drawing.Point(783, 63);
            this.cmbPrintSizes.Name = "cmbPrintSizes";
            this.cmbPrintSizes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPrintSizes.Size = new System.Drawing.Size(100, 21);
            this.cmbPrintSizes.TabIndex = 0;
            this.cmbPrintSizes.SelectedIndexChanged += new System.EventHandler(this.cmbPrintSizes_SelectedIndexChanged);
            this.cmbPrintSizes.EnabledChanged += new System.EventHandler(this.cmbPrintSizes_EnabledChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(889, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "سرویس چاپ دارد؟";
            // 
            // panelHasPrintService
            // 
            this.panelHasPrintService.Controls.Add(this.rbHasNotPrintService);
            this.panelHasPrintService.Controls.Add(this.rbHasPrintService);
            this.panelHasPrintService.Location = new System.Drawing.Point(783, 102);
            this.panelHasPrintService.Name = "panelHasPrintService";
            this.panelHasPrintService.Size = new System.Drawing.Size(100, 41);
            this.panelHasPrintService.TabIndex = 6;
            // 
            // rbHasNotPrintService
            // 
            this.rbHasNotPrintService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbHasNotPrintService.AutoSize = true;
            this.rbHasNotPrintService.Location = new System.Drawing.Point(3, 12);
            this.rbHasNotPrintService.Name = "rbHasNotPrintService";
            this.rbHasNotPrintService.Size = new System.Drawing.Size(46, 17);
            this.rbHasNotPrintService.TabIndex = 1;
            this.rbHasNotPrintService.Text = "ندارد";
            this.rbHasNotPrintService.UseVisualStyleBackColor = true;
            this.rbHasNotPrintService.CheckedChanged += new System.EventHandler(this.rbHasNotPrintService_CheckedChanged);
            // 
            // rbHasPrintService
            // 
            this.rbHasPrintService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbHasPrintService.AutoSize = true;
            this.rbHasPrintService.Location = new System.Drawing.Point(54, 12);
            this.rbHasPrintService.Name = "rbHasPrintService";
            this.rbHasPrintService.Size = new System.Drawing.Size(42, 17);
            this.rbHasPrintService.TabIndex = 0;
            this.rbHasPrintService.TabStop = true;
            this.rbHasPrintService.Text = "دارد";
            this.rbHasPrintService.UseVisualStyleBackColor = true;
            this.rbHasPrintService.CheckedChanged += new System.EventHandler(this.rbHasPrintService_CheckedChanged);
            // 
            // cmbPrintServiceType
            // 
            this.cmbPrintServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintServiceType.DropDownWidth = 130;
            this.cmbPrintServiceType.FormattingEnabled = true;
            this.cmbPrintServiceType.Location = new System.Drawing.Point(377, 112);
            this.cmbPrintServiceType.Name = "cmbPrintServiceType";
            this.cmbPrintServiceType.Size = new System.Drawing.Size(126, 21);
            this.cmbPrintServiceType.TabIndex = 8;
            this.cmbPrintServiceType.SelectedIndexChanged += new System.EventHandler(this.cmbPrintServiceType_SelectedIndexChanged);
            this.cmbPrintServiceType.EnabledChanged += new System.EventHandler(this.cmbPrintServiceType_EnabledChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "نوع سرویس";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "هزینه سرویس";
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // integerInputPrintServicePrice
            // 
            // 
            // 
            // 
            this.integerInputPrintServicePrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputPrintServicePrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputPrintServicePrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputPrintServicePrice.DisplayFormat = "N0";
            this.integerInputPrintServicePrice.FocusHighlightEnabled = true;
            this.integerInputPrintServicePrice.Increment = 10000;
            this.integerInputPrintServicePrice.Location = new System.Drawing.Point(179, 112);
            this.integerInputPrintServicePrice.Name = "integerInputPrintServicePrice";
            this.integerInputPrintServicePrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.integerInputPrintServicePrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputPrintServicePrice.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(12, 111);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // integerInputOriginalPrintPrice
            // 
            // 
            // 
            // 
            this.integerInputOriginalPrintPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputOriginalPrintPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputOriginalPrintPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputOriginalPrintPrice.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInputOriginalPrintPrice.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.integerInputOriginalPrintPrice.DisplayFormat = "N0";
            this.integerInputOriginalPrintPrice.Enabled = false;
            this.integerInputOriginalPrintPrice.FocusHighlightEnabled = true;
            this.integerInputOriginalPrintPrice.Increment = 10000;
            this.integerInputOriginalPrintPrice.IsInputReadOnly = true;
            this.integerInputOriginalPrintPrice.Location = new System.Drawing.Point(377, 63);
            this.integerInputOriginalPrintPrice.MinValue = 0;
            this.integerInputOriginalPrintPrice.Name = "integerInputOriginalPrintPrice";
            this.integerInputOriginalPrintPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.integerInputOriginalPrintPrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputOriginalPrintPrice.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "قیمت اصل چاپ";
            // 
            // integerInputSecondPrintPrice
            // 
            // 
            // 
            // 
            this.integerInputSecondPrintPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputSecondPrintPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputSecondPrintPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputSecondPrintPrice.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInputSecondPrintPrice.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.integerInputSecondPrintPrice.DisplayFormat = "N0";
            this.integerInputSecondPrintPrice.Enabled = false;
            this.integerInputSecondPrintPrice.FocusHighlightEnabled = true;
            this.integerInputSecondPrintPrice.Increment = 10000;
            this.integerInputSecondPrintPrice.IsInputReadOnly = true;
            this.integerInputSecondPrintPrice.Location = new System.Drawing.Point(179, 63);
            this.integerInputSecondPrintPrice.MinValue = 0;
            this.integerInputSecondPrintPrice.Name = "integerInputSecondPrintPrice";
            this.integerInputSecondPrintPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.integerInputSecondPrintPrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputSecondPrintPrice.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "قیمت اضافه چاپ";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column6});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 171);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewX1.Size = new System.Drawing.Size(966, 224);
            this.dataGridViewX1.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "اندازه چاپ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "قیمت اصل چاپ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "قیمت اضافه چاپ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "سرویس چاپ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "هزینه سرویس";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "PrintSizeId";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "PrintServicePrintSizeId";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "PrintServiceId";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // bgWorkerLoadTable
            // 
            this.bgWorkerLoadTable.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadTable_DoWork);
            this.bgWorkerLoadTable.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadTable_RunWorkerCompleted);
            // 
            // bgWorkerLoadPrintSizes
            // 
            this.bgWorkerLoadPrintSizes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadPrintSizes_DoWork);
            this.bgWorkerLoadPrintSizes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadPrintSizes_RunWorkerCompleted);
            // 
            // bgWorkerLoadPrintServices
            // 
            this.bgWorkerLoadPrintServices.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadPrintServices_DoWork);
            this.bgWorkerLoadPrintServices.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadPrintServices_RunWorkerCompleted);
            // 
            // bgWorkerGetPrintSizePrices
            // 
            this.bgWorkerGetPrintSizePrices.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGetPrintSizePrices_DoWork);
            this.bgWorkerGetPrintSizePrices.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGetPrintSizePrices_RunWorkerCompleted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(703, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "کد سرویس";
            // 
            // txtPrintServiceCode
            // 
            // 
            // 
            // 
            this.txtPrintServiceCode.Border.Class = "TextBoxBorder";
            this.txtPrintServiceCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrintServiceCode.Location = new System.Drawing.Point(589, 112);
            this.txtPrintServiceCode.Name = "txtPrintServiceCode";
            this.txtPrintServiceCode.PreventEnterBeep = true;
            this.txtPrintServiceCode.Size = new System.Drawing.Size(100, 21);
            this.txtPrintServiceCode.TabIndex = 7;
            // 
            // integerInputHeight
            // 
            // 
            // 
            // 
            this.integerInputHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputHeight.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInputHeight.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.integerInputHeight.Enabled = false;
            this.integerInputHeight.FocusHighlightEnabled = true;
            this.integerInputHeight.Increment = 10;
            this.integerInputHeight.IsInputReadOnly = true;
            this.integerInputHeight.Location = new System.Drawing.Point(651, 63);
            this.integerInputHeight.MaxValue = 99999;
            this.integerInputHeight.MinValue = 0;
            this.integerInputHeight.Name = "integerInputHeight";
            this.integerInputHeight.Size = new System.Drawing.Size(38, 21);
            this.integerInputHeight.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(633, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(695, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "سایز چاپ";
            // 
            // checkBoxEnablePrintSizeItems
            // 
            // 
            // 
            // 
            this.checkBoxEnablePrintSizeItems.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxEnablePrintSizeItems.Location = new System.Drawing.Point(748, 67);
            this.checkBoxEnablePrintSizeItems.Name = "checkBoxEnablePrintSizeItems";
            this.checkBoxEnablePrintSizeItems.Size = new System.Drawing.Size(14, 14);
            this.checkBoxEnablePrintSizeItems.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxEnablePrintSizeItems.TabIndex = 1;
            this.toolTip1.SetToolTip(this.checkBoxEnablePrintSizeItems, "ویرایش اندازه و قیمت چاپ");
            this.checkBoxEnablePrintSizeItems.CheckedChanged += new System.EventHandler(this.checkBoxEnablePrintSizeItems_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(611, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "cm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(674, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "cm";
            // 
            // integerInputWidth
            // 
            // 
            // 
            // 
            this.integerInputWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputWidth.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInputWidth.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.integerInputWidth.Enabled = false;
            this.integerInputWidth.FocusHighlightEnabled = true;
            this.integerInputWidth.Increment = 10;
            this.integerInputWidth.IsInputReadOnly = true;
            this.integerInputWidth.Location = new System.Drawing.Point(589, 63);
            this.integerInputWidth.MaxValue = 99999;
            this.integerInputWidth.MinValue = 0;
            this.integerInputWidth.Name = "integerInputWidth";
            this.integerInputWidth.Size = new System.Drawing.Size(38, 21);
            this.integerInputWidth.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(588, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "W";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label13.Location = new System.Drawing.Point(651, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "H";
            // 
            // FrmAddEditPrintServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 436);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.integerInputWidth);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBoxEnablePrintSizeItems);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.integerInputHeight);
            this.Controls.Add(this.txtPrintServiceCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.integerInputSecondPrintPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.integerInputOriginalPrintPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.integerInputPrintServicePrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPrintServiceType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelHasPrintService);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPrintSizes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.KeyPreview = true;
            this.Name = "FrmAddEditPrintServices";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده / ویرایش خدمات چاپ عکس";
            this.Load += new System.EventHandler(this.FrmAddEditPrintServices_Load);
            this.panelHasPrintService.ResumeLayout(false);
            this.panelHasPrintService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputPrintServicePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputOriginalPrintPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputSecondPrintPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPrintSizes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHasPrintService;
        private System.Windows.Forms.RadioButton rbHasNotPrintService;
        private System.Windows.Forms.RadioButton rbHasPrintService;
        private System.Windows.Forms.ComboBox cmbPrintServiceType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.Editors.IntegerInput integerInputPrintServicePrice;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.Editors.IntegerInput integerInputSecondPrintPrice;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.IntegerInput integerInputOriginalPrintPrice;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadTable;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintSizes;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintServices;
        private System.ComponentModel.BackgroundWorker bgWorkerGetPrintSizePrices;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrintServiceCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevComponents.Editors.IntegerInput integerInputHeight;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxEnablePrintSizeItems;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.IntegerInput integerInputWidth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}