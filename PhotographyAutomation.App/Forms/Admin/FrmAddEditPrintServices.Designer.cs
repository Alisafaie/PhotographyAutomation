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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrintSizes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHasPrintService = new System.Windows.Forms.Panel();
            this.rbHasNotPrintService = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbHasPrintService = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmbPrintServiceType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.integerInputPrintServicePrice = new DevComponents.Editors.IntegerInput();
            this.integerInputOriginalPrintPrice = new DevComponents.Editors.IntegerInput();
            this.integerInputSecondPrintPrice = new DevComponents.Editors.IntegerInput();
            this.txtPrintServiceCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.doubleInputWidth = new DevComponents.Editors.DoubleInput();
            this.doubleInputHeight = new DevComponents.Editors.DoubleInput();
            this.checkBoxEnablePrintSizeItems = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bgWorkerLoadTable = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerLoadPrintSizes = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerLoadPrintServices = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerGetPrintSizePrices = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvPrintServices = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintSizePriceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOriginalPrintPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSecondPrintPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.circularProgressLoadPrintSizes = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.bgWorkerGetPrintServicePrice = new System.ComponentModel.BackgroundWorker();
            this.circularProgressLoadPrintServices = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.circularProgressLoadDataGridView = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelHasPrintService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputPrintServicePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputOriginalPrintPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputSecondPrintPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintServices)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(927, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "اندازه چاپ";
            // 
            // cmbPrintSizes
            // 
            this.cmbPrintSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintSizes.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintSizes, true);
            this.cmbPrintSizes.Location = new System.Drawing.Point(782, 33);
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
            this.label2.Location = new System.Drawing.Point(888, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "سرویس چاپ دارد؟";
            // 
            // panelHasPrintService
            // 
            this.panelHasPrintService.Controls.Add(this.rbHasNotPrintService);
            this.panelHasPrintService.Controls.Add(this.rbHasPrintService);
            this.panelHasPrintService.Location = new System.Drawing.Point(782, 72);
            this.panelHasPrintService.Name = "panelHasPrintService";
            this.panelHasPrintService.Size = new System.Drawing.Size(100, 41);
            this.panelHasPrintService.TabIndex = 6;
            // 
            // rbHasNotPrintService
            // 
            this.rbHasNotPrintService.AutoSize = true;
            // 
            // 
            // 
            this.rbHasNotPrintService.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbHasNotPrintService.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.highlighter1.SetHighlightOnFocus(this.rbHasNotPrintService, true);
            this.rbHasNotPrintService.Location = new System.Drawing.Point(3, 12);
            this.rbHasNotPrintService.Name = "rbHasNotPrintService";
            this.rbHasNotPrintService.Size = new System.Drawing.Size(43, 16);
            this.rbHasNotPrintService.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbHasNotPrintService.TabIndex = 35;
            this.rbHasNotPrintService.Text = "ندارد";
            this.rbHasNotPrintService.CheckedChanged += new System.EventHandler(this.rbHasNotPrintService_CheckedChanged);
            // 
            // rbHasPrintService
            // 
            this.rbHasPrintService.AutoSize = true;
            // 
            // 
            // 
            this.rbHasPrintService.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbHasPrintService.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.highlighter1.SetHighlightOnFocus(this.rbHasPrintService, true);
            this.rbHasPrintService.Location = new System.Drawing.Point(58, 12);
            this.rbHasPrintService.Name = "rbHasPrintService";
            this.rbHasPrintService.Size = new System.Drawing.Size(39, 16);
            this.rbHasPrintService.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbHasPrintService.TabIndex = 35;
            this.rbHasPrintService.Text = "دارد";
            this.rbHasPrintService.CheckedChanged += new System.EventHandler(this.rbHasPrintService_CheckedChanged);
            // 
            // cmbPrintServiceType
            // 
            this.cmbPrintServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintServiceType.DropDownWidth = 130;
            this.cmbPrintServiceType.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintServiceType, true);
            this.cmbPrintServiceType.Location = new System.Drawing.Point(561, 82);
            this.cmbPrintServiceType.Name = "cmbPrintServiceType";
            this.cmbPrintServiceType.Size = new System.Drawing.Size(115, 21);
            this.cmbPrintServiceType.TabIndex = 7;
            this.cmbPrintServiceType.SelectedIndexChanged += new System.EventHandler(this.cmbPrintServiceType_SelectedIndexChanged);
            this.cmbPrintServiceType.EnabledChanged += new System.EventHandler(this.cmbPrintServiceType_EnabledChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(693, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "نوع سرویس";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "هزینه سرویس";
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.CustomHighlightColors = new System.Drawing.Color[] {
        System.Drawing.Color.Gold};
            this.highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Orange;
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
            this.highlighter1.SetHighlightOnFocus(this.integerInputPrintServicePrice, true);
            this.integerInputPrintServicePrice.Increment = 10000;
            this.integerInputPrintServicePrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.integerInputPrintServicePrice.Location = new System.Drawing.Point(126, 82);
            this.integerInputPrintServicePrice.MinValue = 0;
            this.integerInputPrintServicePrice.Name = "integerInputPrintServicePrice";
            this.integerInputPrintServicePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.integerInputPrintServicePrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputPrintServicePrice.TabIndex = 9;
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
            this.highlighter1.SetHighlightOnFocus(this.integerInputOriginalPrintPrice, true);
            this.integerInputOriginalPrintPrice.Increment = 10000;
            this.integerInputOriginalPrintPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.integerInputOriginalPrintPrice.IsInputReadOnly = true;
            this.integerInputOriginalPrintPrice.Location = new System.Drawing.Point(354, 33);
            this.integerInputOriginalPrintPrice.MinValue = 0;
            this.integerInputOriginalPrintPrice.Name = "integerInputOriginalPrintPrice";
            this.integerInputOriginalPrintPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.integerInputOriginalPrintPrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputOriginalPrintPrice.TabIndex = 4;
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
            this.highlighter1.SetHighlightOnFocus(this.integerInputSecondPrintPrice, true);
            this.integerInputSecondPrintPrice.Increment = 10000;
            this.integerInputSecondPrintPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.integerInputSecondPrintPrice.IsInputReadOnly = true;
            this.integerInputSecondPrintPrice.Location = new System.Drawing.Point(126, 33);
            this.integerInputSecondPrintPrice.MinValue = 0;
            this.integerInputSecondPrintPrice.Name = "integerInputSecondPrintPrice";
            this.integerInputSecondPrintPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.integerInputSecondPrintPrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputSecondPrintPrice.TabIndex = 5;
            // 
            // txtPrintServiceCode
            // 
            // 
            // 
            // 
            this.txtPrintServiceCode.Border.Class = "TextBoxBorder";
            this.txtPrintServiceCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.txtPrintServiceCode, true);
            this.txtPrintServiceCode.Location = new System.Drawing.Point(354, 82);
            this.txtPrintServiceCode.Name = "txtPrintServiceCode";
            this.txtPrintServiceCode.PreventEnterBeep = true;
            this.txtPrintServiceCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrintServiceCode.Size = new System.Drawing.Size(100, 21);
            this.txtPrintServiceCode.TabIndex = 8;
            // 
            // doubleInputWidth
            // 
            // 
            // 
            // 
            this.doubleInputWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.highlighter1.SetHighlightOnFocus(this.doubleInputWidth, true);
            this.doubleInputWidth.Increment = 1D;
            this.doubleInputWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.doubleInputWidth.Location = new System.Drawing.Point(561, 33);
            this.doubleInputWidth.MinValue = 0D;
            this.doubleInputWidth.Name = "doubleInputWidth";
            this.doubleInputWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputWidth.Size = new System.Drawing.Size(45, 21);
            this.doubleInputWidth.TabIndex = 2;
            // 
            // doubleInputHeight
            // 
            // 
            // 
            // 
            this.doubleInputHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.highlighter1.SetHighlightOnFocus(this.doubleInputHeight, true);
            this.doubleInputHeight.Increment = 1D;
            this.doubleInputHeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.doubleInputHeight.Location = new System.Drawing.Point(631, 33);
            this.doubleInputHeight.MinValue = 0D;
            this.doubleInputHeight.Name = "doubleInputHeight";
            this.doubleInputHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputHeight.Size = new System.Drawing.Size(45, 21);
            this.doubleInputHeight.TabIndex = 3;
            // 
            // checkBoxEnablePrintSizeItems
            // 
            // 
            // 
            // 
            this.checkBoxEnablePrintSizeItems.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.checkBoxEnablePrintSizeItems, true);
            this.checkBoxEnablePrintSizeItems.Location = new System.Drawing.Point(743, 38);
            this.checkBoxEnablePrintSizeItems.Name = "checkBoxEnablePrintSizeItems";
            this.checkBoxEnablePrintSizeItems.Size = new System.Drawing.Size(14, 16);
            this.checkBoxEnablePrintSizeItems.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxEnablePrintSizeItems.TabIndex = 1;
            this.toolTip1.SetToolTip(this.checkBoxEnablePrintSizeItems, "ویرایش اندازه و قیمت چاپ");
            this.checkBoxEnablePrintSizeItems.CheckedChanged += new System.EventHandler(this.checkBoxEnablePrintSizeItems_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(11, 81);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "قیمت اصل چاپ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "قیمت اضافه چاپ";
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
            this.label7.Location = new System.Drawing.Point(479, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "کد سرویس";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(612, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "x";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(589, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "cm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(660, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "cm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(559, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "W";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label13.Location = new System.Drawing.Point(629, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "H";
            // 
            // dgvPrintServices
            // 
            this.dgvPrintServices.AllowUserToAddRows = false;
            this.dgvPrintServices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPrintServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrintServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrintServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrintServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrintServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmPrintServiceId,
            this.clmPrintSizePriceId,
            this.clmSizeName,
            this.clmOriginalPrintPrice,
            this.clmSecondPrintPrice,
            this.clmCode,
            this.clmPrintServiceName,
            this.clmPrice,
            this.clmDescription});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrintServices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPrintServices.EnableHeadersVisualStyles = false;
            this.dgvPrintServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvPrintServices.Location = new System.Drawing.Point(11, 182);
            this.dgvPrintServices.Name = "dgvPrintServices";
            this.dgvPrintServices.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrintServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPrintServices.RowHeadersVisible = false;
            this.dgvPrintServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrintServices.Size = new System.Drawing.Size(966, 307);
            this.dgvPrintServices.TabIndex = 11;
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "Id";
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // clmPrintServiceId
            // 
            this.clmPrintServiceId.DataPropertyName = "PrintServiceId";
            this.clmPrintServiceId.HeaderText = "PrintServiceId";
            this.clmPrintServiceId.Name = "clmPrintServiceId";
            this.clmPrintServiceId.ReadOnly = true;
            this.clmPrintServiceId.Visible = false;
            // 
            // clmPrintSizePriceId
            // 
            this.clmPrintSizePriceId.DataPropertyName = "PrintSizePriceId";
            this.clmPrintSizePriceId.HeaderText = "PrintSizePriceId";
            this.clmPrintSizePriceId.Name = "clmPrintSizePriceId";
            this.clmPrintSizePriceId.ReadOnly = true;
            this.clmPrintSizePriceId.Visible = false;
            // 
            // clmSizeName
            // 
            this.clmSizeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmSizeName.DataPropertyName = "SizeName";
            this.clmSizeName.HeaderText = "اندازه چاپ (cm)";
            this.clmSizeName.Name = "clmSizeName";
            this.clmSizeName.ReadOnly = true;
            this.clmSizeName.Width = 120;
            // 
            // clmOriginalPrintPrice
            // 
            this.clmOriginalPrintPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmOriginalPrintPrice.DataPropertyName = "OriginalPrintPrice";
            this.clmOriginalPrintPrice.HeaderText = "قیمت اصل چاپ (ريال)";
            this.clmOriginalPrintPrice.Name = "clmOriginalPrintPrice";
            this.clmOriginalPrintPrice.ReadOnly = true;
            this.clmOriginalPrintPrice.Width = 140;
            // 
            // clmSecondPrintPrice
            // 
            this.clmSecondPrintPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmSecondPrintPrice.DataPropertyName = "SecondPrintPrice";
            this.clmSecondPrintPrice.HeaderText = "قیمت اضافه چاپ (ريال)";
            this.clmSecondPrintPrice.Name = "clmSecondPrintPrice";
            this.clmSecondPrintPrice.ReadOnly = true;
            this.clmSecondPrintPrice.Width = 140;
            // 
            // clmCode
            // 
            this.clmCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmCode.DataPropertyName = "Code";
            this.clmCode.HeaderText = "کد";
            this.clmCode.Name = "clmCode";
            this.clmCode.ReadOnly = true;
            // 
            // clmPrintServiceName
            // 
            this.clmPrintServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPrintServiceName.DataPropertyName = "PrintServiceName";
            this.clmPrintServiceName.HeaderText = "سرویس چاپ";
            this.clmPrintServiceName.Name = "clmPrintServiceName";
            this.clmPrintServiceName.ReadOnly = true;
            // 
            // clmPrice
            // 
            this.clmPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmPrice.DataPropertyName = "Price";
            this.clmPrice.HeaderText = "هزینه سرویس (ريال)";
            this.clmPrice.Name = "clmPrice";
            this.clmPrice.ReadOnly = true;
            this.clmPrice.Width = 140;
            // 
            // clmDescription
            // 
            this.clmDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDescription.DataPropertyName = "Description";
            this.clmDescription.HeaderText = "توضیحات";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            // 
            // circularProgressLoadPrintSizes
            // 
            // 
            // 
            // 
            this.circularProgressLoadPrintSizes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgressLoadPrintSizes.Location = new System.Drawing.Point(884, 33);
            this.circularProgressLoadPrintSizes.Name = "circularProgressLoadPrintSizes";
            this.circularProgressLoadPrintSizes.ProgressColor = System.Drawing.Color.Green;
            this.circularProgressLoadPrintSizes.Size = new System.Drawing.Size(14, 21);
            this.circularProgressLoadPrintSizes.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgressLoadPrintSizes.TabIndex = 31;
            this.circularProgressLoadPrintSizes.TabStop = false;
            this.circularProgressLoadPrintSizes.UseWaitCursor = true;
            // 
            // bgWorkerGetPrintServicePrice
            // 
            this.bgWorkerGetPrintServicePrice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGetPrintServicePrice_DoWork);
            this.bgWorkerGetPrintServicePrice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGetPrintServicePrice_RunWorkerCompleted);
            // 
            // circularProgressLoadPrintServices
            // 
            // 
            // 
            // 
            this.circularProgressLoadPrintServices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgressLoadPrintServices.Location = new System.Drawing.Point(677, 82);
            this.circularProgressLoadPrintServices.Name = "circularProgressLoadPrintServices";
            this.circularProgressLoadPrintServices.ProgressColor = System.Drawing.Color.Green;
            this.circularProgressLoadPrintServices.Size = new System.Drawing.Size(14, 21);
            this.circularProgressLoadPrintServices.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgressLoadPrintServices.TabIndex = 31;
            this.circularProgressLoadPrintServices.TabStop = false;
            this.circularProgressLoadPrintServices.UseWaitCursor = true;
            // 
            // circularProgressLoadDataGridView
            // 
            this.circularProgressLoadDataGridView.BackColor = System.Drawing.Color.DarkGray;
            // 
            // 
            // 
            this.circularProgressLoadDataGridView.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgressLoadDataGridView.Location = new System.Drawing.Point(414, 248);
            this.circularProgressLoadDataGridView.Name = "circularProgressLoadDataGridView";
            this.circularProgressLoadDataGridView.ProgressColor = System.Drawing.Color.Green;
            this.circularProgressLoadDataGridView.Size = new System.Drawing.Size(165, 145);
            this.circularProgressLoadDataGridView.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgressLoadDataGridView.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label14.Location = new System.Drawing.Point(330, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "ريال";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label15.Location = new System.Drawing.Point(102, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "ريال";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Location = new System.Drawing.Point(102, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "ريال";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(686, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "سایز چاپ";
            // 
            // FrmAddEditPrintServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 501);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.circularProgressLoadDataGridView);
            this.Controls.Add(this.circularProgressLoadPrintServices);
            this.Controls.Add(this.doubleInputHeight);
            this.Controls.Add(this.doubleInputWidth);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBoxEnablePrintSizeItems);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrintServiceCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvPrintServices);
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
            this.Controls.Add(this.circularProgressLoadPrintSizes);
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
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPrintSizes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHasPrintService;
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
        private System.ComponentModel.BackgroundWorker bgWorkerLoadTable;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintSizes;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintServices;
        private System.ComponentModel.BackgroundWorker bgWorkerGetPrintSizePrices;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrintServiceCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxEnablePrintSizeItems;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPrintServices;
        private DevComponents.Editors.DoubleInput doubleInputHeight;
        private DevComponents.Editors.DoubleInput doubleInputWidth;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgressLoadPrintSizes;
        private System.ComponentModel.BackgroundWorker bgWorkerGetPrintServicePrice;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgressLoadPrintServices;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgressLoadDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrintServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrintSizePriceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOriginalPrintPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSecondPrintPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrintServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbHasNotPrintService;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbHasPrintService;
    }
}