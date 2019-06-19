namespace PhotographyAutomation.App.Forms.Admin
{
    partial class FrmAddEditPrintSizeAndServices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBoxPrintSize = new System.Windows.Forms.GroupBox();
            this.cpBtnSave = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.panelHasPrintService = new System.Windows.Forms.Panel();
            this.checkBoxEnableGroupBoxPrintServices = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label20 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panelOriginalPrintPrice = new System.Windows.Forms.Panel();
            this.cpGetPrintSizePrice = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.label4 = new System.Windows.Forms.Label();
            this.integerInputOriginalPrintPrice = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.panelSecondPrintPrice = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.integerInputSecondPrintPrice = new DevComponents.Editors.IntegerInput();
            this.label15 = new System.Windows.Forms.Label();
            this.panelNewEditPrintSize = new System.Windows.Forms.Panel();
            this.doubleInputHeight = new DevComponents.Editors.DoubleInput();
            this.doubleInputWidth = new DevComponents.Editors.DoubleInput();
            this.checkBoxNewSize = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.panelPrintSize1 = new System.Windows.Forms.Panel();
            this.cpLoadPrintSizes1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.cmbPrintSizes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavePrintSizePrice = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBoxPrintServices = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.integerInputPrintServicePrice = new DevComponents.Editors.IntegerInput();
            this.label19 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cpPrintServices = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.cmbPrintServices = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPrintSize2 = new System.Windows.Forms.Panel();
            this.cpLoadPrintSizes2 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.cmbPrintSizes2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSavePrintServicePrice = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.cpLoadDataGridView = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.dgvPrintServices = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintSizePriceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOriginalPrintPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSecondPrintPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintSizeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.bgWorkerLoadPrintSizes1 = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerLoadPrintSizes2 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.تنظیماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorkerSaveNewPrintSize = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerDeletePrintSize = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerUpdatePrintSize = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerGetPrintSizeInfo = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerGetPrintSizePrice = new System.ComponentModel.BackgroundWorker();
            this.تعریفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذف_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذف_اندازه_چاپ_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            this.groupBoxPrintSize.SuspendLayout();
            this.panelHasPrintService.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panelOriginalPrintPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputOriginalPrintPrice)).BeginInit();
            this.panelSecondPrintPrice.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputSecondPrintPrice)).BeginInit();
            this.panelNewEditPrintSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputWidth)).BeginInit();
            this.panelPrintSize1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupBoxPrintServices.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputPrintServicePrice)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelPrintSize2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintServices)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupBoxPrintSize);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 24);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1172, 81);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // groupBoxPrintSize
            // 
            this.groupBoxPrintSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPrintSize.Controls.Add(this.cpBtnSave);
            this.groupBoxPrintSize.Controls.Add(this.panelHasPrintService);
            this.groupBoxPrintSize.Controls.Add(this.panelOriginalPrintPrice);
            this.groupBoxPrintSize.Controls.Add(this.panelSecondPrintPrice);
            this.groupBoxPrintSize.Controls.Add(this.panelNewEditPrintSize);
            this.groupBoxPrintSize.Controls.Add(this.panelPrintSize1);
            this.groupBoxPrintSize.Controls.Add(this.btnSavePrintSizePrice);
            this.groupBoxPrintSize.Location = new System.Drawing.Point(12, 3);
            this.groupBoxPrintSize.Name = "groupBoxPrintSize";
            this.groupBoxPrintSize.Size = new System.Drawing.Size(1148, 72);
            this.groupBoxPrintSize.TabIndex = 0;
            this.groupBoxPrintSize.TabStop = false;
            this.groupBoxPrintSize.Text = "اندازه و قیمت چاپ عکس";
            // 
            // cpBtnSave
            // 
            // 
            // 
            // 
            this.cpBtnSave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpBtnSave.Location = new System.Drawing.Point(83, 32);
            this.cpBtnSave.Name = "cpBtnSave";
            this.cpBtnSave.ProgressColor = System.Drawing.Color.Blue;
            this.cpBtnSave.Size = new System.Drawing.Size(14, 21);
            this.cpBtnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpBtnSave.TabIndex = 44;
            this.cpBtnSave.TabStop = false;
            this.cpBtnSave.UseWaitCursor = true;
            // 
            // panelHasPrintService
            // 
            this.panelHasPrintService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHasPrintService.Controls.Add(this.checkBoxEnableGroupBoxPrintServices);
            this.panelHasPrintService.Controls.Add(this.label20);
            this.panelHasPrintService.Controls.Add(this.panel12);
            this.panelHasPrintService.Location = new System.Drawing.Point(150, 23);
            this.panelHasPrintService.Name = "panelHasPrintService";
            this.panelHasPrintService.Size = new System.Drawing.Size(117, 37);
            this.panelHasPrintService.TabIndex = 4;
            // 
            // checkBoxEnableGroupBoxPrintServices
            // 
            this.checkBoxEnableGroupBoxPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnableGroupBoxPrintServices.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxEnableGroupBoxPrintServices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.checkBoxEnableGroupBoxPrintServices, true);
            this.checkBoxEnableGroupBoxPrintServices.Location = new System.Drawing.Point(9, 13);
            this.checkBoxEnableGroupBoxPrintServices.Name = "checkBoxEnableGroupBoxPrintServices";
            this.checkBoxEnableGroupBoxPrintServices.Size = new System.Drawing.Size(39, 16);
            this.checkBoxEnableGroupBoxPrintServices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxEnableGroupBoxPrintServices.TabIndex = 0;
            this.checkBoxEnableGroupBoxPrintServices.Text = "دارد";
            this.checkBoxEnableGroupBoxPrintServices.CheckedChanged += new System.EventHandler(this.checkBoxEnableGroupBoxPrintServices_CheckedChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(54, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "خدمات چاپ";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label21);
            this.panel12.Controls.Add(this.label22);
            this.panel12.Location = new System.Drawing.Point(225, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(211, 46);
            this.panel12.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label21.Location = new System.Drawing.Point(3, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "ريال";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(130, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 13);
            this.label22.TabIndex = 42;
            this.label22.Text = "قیمت اصل چاپ";
            // 
            // panelOriginalPrintPrice
            // 
            this.panelOriginalPrintPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOriginalPrintPrice.Controls.Add(this.cpGetPrintSizePrice);
            this.panelOriginalPrintPrice.Controls.Add(this.label4);
            this.panelOriginalPrintPrice.Controls.Add(this.integerInputOriginalPrintPrice);
            this.panelOriginalPrintPrice.Controls.Add(this.label7);
            this.panelOriginalPrintPrice.Location = new System.Drawing.Point(501, 23);
            this.panelOriginalPrintPrice.Name = "panelOriginalPrintPrice";
            this.panelOriginalPrintPrice.Size = new System.Drawing.Size(211, 37);
            this.panelOriginalPrintPrice.TabIndex = 2;
            // 
            // cpGetPrintSizePrice
            // 
            // 
            // 
            // 
            this.cpGetPrintSizePrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpGetPrintSizePrice.Location = new System.Drawing.Point(7, 9);
            this.cpGetPrintSizePrice.Name = "cpGetPrintSizePrice";
            this.cpGetPrintSizePrice.ProgressColor = System.Drawing.Color.Blue;
            this.cpGetPrintSizePrice.Size = new System.Drawing.Size(14, 21);
            this.cpGetPrintSizePrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpGetPrintSizePrice.TabIndex = 33;
            this.cpGetPrintSizePrice.TabStop = false;
            this.cpGetPrintSizePrice.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "ريال";
            // 
            // integerInputOriginalPrintPrice
            // 
            this.integerInputOriginalPrintPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.integerInputOriginalPrintPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputOriginalPrintPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputOriginalPrintPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputOriginalPrintPrice.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInputOriginalPrintPrice.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.integerInputOriginalPrintPrice.DisplayFormat = "N0";
            this.highlighter1.SetHighlightOnFocus(this.integerInputOriginalPrintPrice, true);
            this.integerInputOriginalPrintPrice.Increment = 10000;
            this.integerInputOriginalPrintPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.integerInputOriginalPrintPrice.Location = new System.Drawing.Point(27, 9);
            this.integerInputOriginalPrintPrice.MinValue = 0;
            this.integerInputOriginalPrintPrice.Name = "integerInputOriginalPrintPrice";
            this.integerInputOriginalPrintPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.integerInputOriginalPrintPrice.ShowCheckBox = true;
            this.integerInputOriginalPrintPrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputOriginalPrintPrice.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "قیمت اصل چاپ";
            // 
            // panelSecondPrintPrice
            // 
            this.panelSecondPrintPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSecondPrintPrice.Controls.Add(this.label6);
            this.panelSecondPrintPrice.Controls.Add(this.panel3);
            this.panelSecondPrintPrice.Controls.Add(this.integerInputSecondPrintPrice);
            this.panelSecondPrintPrice.Controls.Add(this.label15);
            this.panelSecondPrintPrice.Location = new System.Drawing.Point(273, 23);
            this.panelSecondPrintPrice.Name = "panelSecondPrintPrice";
            this.panelSecondPrintPrice.Size = new System.Drawing.Size(222, 37);
            this.panelSecondPrintPrice.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "قیمت اضافه چاپ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(225, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 46);
            this.panel3.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label14.Location = new System.Drawing.Point(3, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "ريال";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "قیمت اصل چاپ";
            // 
            // integerInputSecondPrintPrice
            // 
            this.integerInputSecondPrintPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.integerInputSecondPrintPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInputSecondPrintPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInputSecondPrintPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInputSecondPrintPrice.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.integerInputSecondPrintPrice.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.integerInputSecondPrintPrice.DisplayFormat = "N0";
            this.highlighter1.SetHighlightOnFocus(this.integerInputSecondPrintPrice, true);
            this.integerInputSecondPrintPrice.Increment = 10000;
            this.integerInputSecondPrintPrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.integerInputSecondPrintPrice.Location = new System.Drawing.Point(29, 9);
            this.integerInputSecondPrintPrice.MinValue = 0;
            this.integerInputSecondPrintPrice.Name = "integerInputSecondPrintPrice";
            this.integerInputSecondPrintPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.integerInputSecondPrintPrice.ShowCheckBox = true;
            this.integerInputSecondPrintPrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputSecondPrintPrice.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label15.Location = new System.Drawing.Point(5, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "ريال";
            // 
            // panelNewEditPrintSize
            // 
            this.panelNewEditPrintSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNewEditPrintSize.Controls.Add(this.doubleInputHeight);
            this.panelNewEditPrintSize.Controls.Add(this.doubleInputWidth);
            this.panelNewEditPrintSize.Controls.Add(this.checkBoxNewSize);
            this.panelNewEditPrintSize.Controls.Add(this.label8);
            this.panelNewEditPrintSize.Location = new System.Drawing.Point(718, 23);
            this.panelNewEditPrintSize.Name = "panelNewEditPrintSize";
            this.panelNewEditPrintSize.Size = new System.Drawing.Size(218, 37);
            this.panelNewEditPrintSize.TabIndex = 1;
            // 
            // doubleInputHeight
            // 
            this.doubleInputHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.doubleInputHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInputHeight.Enabled = false;
            this.highlighter1.SetHighlightOnFocus(this.doubleInputHeight, true);
            this.doubleInputHeight.Increment = 1D;
            this.doubleInputHeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.doubleInputHeight.Location = new System.Drawing.Point(92, 9);
            this.doubleInputHeight.MinValue = 0D;
            this.doubleInputHeight.Name = "doubleInputHeight";
            this.doubleInputHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputHeight.Size = new System.Drawing.Size(50, 21);
            this.doubleInputHeight.TabIndex = 2;
            this.doubleInputHeight.WatermarkText = "طول(cm)";
            // 
            // doubleInputWidth
            // 
            this.doubleInputWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.doubleInputWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInputWidth.Enabled = false;
            this.highlighter1.SetHighlightOnFocus(this.doubleInputWidth, true);
            this.doubleInputWidth.Increment = 1D;
            this.doubleInputWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.doubleInputWidth.Location = new System.Drawing.Point(21, 9);
            this.doubleInputWidth.MinValue = 0D;
            this.doubleInputWidth.Name = "doubleInputWidth";
            this.doubleInputWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputWidth.Size = new System.Drawing.Size(54, 21);
            this.doubleInputWidth.TabIndex = 1;
            this.doubleInputWidth.WatermarkText = "عرض(cm)";
            // 
            // checkBoxNewSize
            // 
            this.checkBoxNewSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNewSize.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxNewSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.checkBoxNewSize, true);
            this.checkBoxNewSize.Location = new System.Drawing.Point(146, 11);
            this.checkBoxNewSize.Name = "checkBoxNewSize";
            this.checkBoxNewSize.Size = new System.Drawing.Size(70, 16);
            this.checkBoxNewSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxNewSize.TabIndex = 0;
            this.checkBoxNewSize.Text = "سایز جدید";
            this.checkBoxNewSize.CheckedChanged += new System.EventHandler(this.checkBoxNewSize_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "x";
            // 
            // panelPrintSize1
            // 
            this.panelPrintSize1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrintSize1.Controls.Add(this.cpLoadPrintSizes1);
            this.panelPrintSize1.Controls.Add(this.cmbPrintSizes);
            this.panelPrintSize1.Controls.Add(this.label1);
            this.panelPrintSize1.Location = new System.Drawing.Point(942, 23);
            this.panelPrintSize1.Name = "panelPrintSize1";
            this.panelPrintSize1.Size = new System.Drawing.Size(200, 37);
            this.panelPrintSize1.TabIndex = 0;
            // 
            // cpLoadPrintSizes1
            // 
            // 
            // 
            // 
            this.cpLoadPrintSizes1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpLoadPrintSizes1.Location = new System.Drawing.Point(3, 9);
            this.cpLoadPrintSizes1.Name = "cpLoadPrintSizes1";
            this.cpLoadPrintSizes1.ProgressColor = System.Drawing.Color.Blue;
            this.cpLoadPrintSizes1.Size = new System.Drawing.Size(14, 21);
            this.cpLoadPrintSizes1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpLoadPrintSizes1.TabIndex = 32;
            this.cpLoadPrintSizes1.TabStop = false;
            this.cpLoadPrintSizes1.UseWaitCursor = true;
            // 
            // cmbPrintSizes
            // 
            this.cmbPrintSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintSizes.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintSizes, true);
            this.cmbPrintSizes.Location = new System.Drawing.Point(23, 9);
            this.cmbPrintSizes.Name = "cmbPrintSizes";
            this.cmbPrintSizes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPrintSizes.Size = new System.Drawing.Size(112, 21);
            this.cmbPrintSizes.TabIndex = 0;
            this.cmbPrintSizes.SelectedIndexChanged += new System.EventHandler(this.cmbPrintSizes_SelectedIndexChanged);
            this.cmbPrintSizes.EnabledChanged += new System.EventHandler(this.cmbPrintSizes_EnabledChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "اندازه چاپ";
            // 
            // btnSavePrintSizePrice
            // 
            this.btnSavePrintSizePrice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSavePrintSizePrice.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.highlighter1.SetHighlightOnFocus(this.btnSavePrintSizePrice, true);
            this.btnSavePrintSizePrice.Location = new System.Drawing.Point(6, 30);
            this.btnSavePrintSizePrice.Name = "btnSavePrintSizePrice";
            this.btnSavePrintSizePrice.Size = new System.Drawing.Size(75, 23);
            this.btnSavePrintSizePrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnSavePrintSizePrice.TabIndex = 5;
            this.btnSavePrintSizePrice.Text = "ثبت";
            this.btnSavePrintSizePrice.Click += new System.EventHandler(this.btnSavePrintSizePrice_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.groupBoxPrintServices);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 105);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1172, 79);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // groupBoxPrintServices
            // 
            this.groupBoxPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPrintServices.Controls.Add(this.panel9);
            this.groupBoxPrintServices.Controls.Add(this.panel8);
            this.groupBoxPrintServices.Controls.Add(this.panel6);
            this.groupBoxPrintServices.Controls.Add(this.panelPrintSize2);
            this.groupBoxPrintServices.Controls.Add(this.btnSavePrintServicePrice);
            this.groupBoxPrintServices.Enabled = false;
            this.groupBoxPrintServices.Location = new System.Drawing.Point(12, 6);
            this.groupBoxPrintServices.Name = "groupBoxPrintServices";
            this.groupBoxPrintServices.Size = new System.Drawing.Size(1148, 67);
            this.groupBoxPrintServices.TabIndex = 0;
            this.groupBoxPrintServices.TabStop = false;
            this.groupBoxPrintServices.Text = "خدمات چاپ";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.label16);
            this.panel9.Controls.Add(this.integerInputPrintServicePrice);
            this.panel9.Controls.Add(this.label19);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(273, 20);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(222, 34);
            this.panel9.TabIndex = 49;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Location = new System.Drawing.Point(5, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "ريال";
            // 
            // integerInputPrintServicePrice
            // 
            this.integerInputPrintServicePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.integerInputPrintServicePrice.Location = new System.Drawing.Point(29, 6);
            this.integerInputPrintServicePrice.MinValue = 0;
            this.integerInputPrintServicePrice.Name = "integerInputPrintServicePrice";
            this.integerInputPrintServicePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.integerInputPrintServicePrice.ShowCheckBox = true;
            this.integerInputPrintServicePrice.Size = new System.Drawing.Size(100, 21);
            this.integerInputPrintServicePrice.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(145, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "هزینه سرویس";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label17);
            this.panel10.Controls.Add(this.label18);
            this.panel10.Location = new System.Drawing.Point(225, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(211, 46);
            this.panel10.TabIndex = 47;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label17.Location = new System.Drawing.Point(3, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "ريال";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(130, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "قیمت اصل چاپ";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.label9);
            this.panel8.Location = new System.Drawing.Point(501, 20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(211, 34);
            this.panel8.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "کد سرویس";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.cpPrintServices);
            this.panel6.Controls.Add(this.cmbPrintServices);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(715, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(221, 34);
            this.panel6.TabIndex = 46;
            // 
            // cpPrintServices
            // 
            // 
            // 
            // 
            this.cpPrintServices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpPrintServices.Location = new System.Drawing.Point(3, 6);
            this.cpPrintServices.Name = "cpPrintServices";
            this.cpPrintServices.ProgressColor = System.Drawing.Color.Blue;
            this.cpPrintServices.Size = new System.Drawing.Size(14, 21);
            this.cpPrintServices.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpPrintServices.TabIndex = 33;
            this.cpPrintServices.TabStop = false;
            this.cpPrintServices.UseWaitCursor = true;
            // 
            // cmbPrintServices
            // 
            this.cmbPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintServices.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintServices, true);
            this.cmbPrintServices.Location = new System.Drawing.Point(24, 6);
            this.cmbPrintServices.Name = "cmbPrintServices";
            this.cmbPrintServices.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPrintServices.Size = new System.Drawing.Size(124, 21);
            this.cmbPrintServices.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "خدمات چاپ";
            // 
            // panelPrintSize2
            // 
            this.panelPrintSize2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrintSize2.Controls.Add(this.cpLoadPrintSizes2);
            this.panelPrintSize2.Controls.Add(this.cmbPrintSizes2);
            this.panelPrintSize2.Controls.Add(this.label2);
            this.panelPrintSize2.Location = new System.Drawing.Point(942, 20);
            this.panelPrintSize2.Name = "panelPrintSize2";
            this.panelPrintSize2.Size = new System.Drawing.Size(200, 34);
            this.panelPrintSize2.TabIndex = 46;
            // 
            // cpLoadPrintSizes2
            // 
            // 
            // 
            // 
            this.cpLoadPrintSizes2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpLoadPrintSizes2.Location = new System.Drawing.Point(3, 6);
            this.cpLoadPrintSizes2.Name = "cpLoadPrintSizes2";
            this.cpLoadPrintSizes2.ProgressColor = System.Drawing.Color.Blue;
            this.cpLoadPrintSizes2.Size = new System.Drawing.Size(14, 21);
            this.cpLoadPrintSizes2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpLoadPrintSizes2.TabIndex = 33;
            this.cpLoadPrintSizes2.TabStop = false;
            this.cpLoadPrintSizes2.UseWaitCursor = true;
            // 
            // cmbPrintSizes2
            // 
            this.cmbPrintSizes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintSizes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintSizes2.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintSizes2, true);
            this.cmbPrintSizes2.Location = new System.Drawing.Point(23, 6);
            this.cmbPrintSizes2.Name = "cmbPrintSizes2";
            this.cmbPrintSizes2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPrintSizes2.Size = new System.Drawing.Size(112, 21);
            this.cmbPrintSizes2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "اندازه چاپ";
            // 
            // btnSavePrintServicePrice
            // 
            this.btnSavePrintServicePrice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSavePrintServicePrice.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.highlighter1.SetHighlightOnFocus(this.btnSavePrintServicePrice, true);
            this.btnSavePrintServicePrice.Location = new System.Drawing.Point(6, 24);
            this.btnSavePrintServicePrice.Name = "btnSavePrintServicePrice";
            this.btnSavePrintServicePrice.Size = new System.Drawing.Size(75, 23);
            this.btnSavePrintServicePrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnSavePrintServicePrice.TabIndex = 0;
            this.btnSavePrintServicePrice.Text = "ثبت";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.cpLoadDataGridView);
            this.panelEx3.Controls.Add(this.dgvPrintServices);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 184);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1172, 362);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 8;
            this.panelEx3.Text = "panelEx3";
            // 
            // cpLoadDataGridView
            // 
            this.cpLoadDataGridView.BackColor = System.Drawing.Color.DarkGray;
            // 
            // 
            // 
            this.cpLoadDataGridView.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpLoadDataGridView.Location = new System.Drawing.Point(541, 161);
            this.cpLoadDataGridView.Name = "cpLoadDataGridView";
            this.cpLoadDataGridView.ProgressColor = System.Drawing.Color.Blue;
            this.cpLoadDataGridView.Size = new System.Drawing.Size(57, 63);
            this.cpLoadDataGridView.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpLoadDataGridView.TabIndex = 34;
            // 
            // dgvPrintServices
            // 
            this.dgvPrintServices.AllowUserToAddRows = false;
            this.dgvPrintServices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPrintServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvPrintServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrintServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.dgvPrintServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrintServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmPrintServiceId,
            this.clmPrintSizePriceId,
            this.clmSizeName,
            this.clmOriginalPrintPrice,
            this.clmSecondPrintPrice,
            this.clmCode,
            this.clmPrintSizeDescription,
            this.clmPrintServiceName,
            this.clmPrice,
            this.clmDescription});
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrintServices.DefaultCellStyle = dataGridViewCellStyle39;
            this.dgvPrintServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrintServices.EnableHeadersVisualStyles = false;
            this.dgvPrintServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvPrintServices.Location = new System.Drawing.Point(0, 0);
            this.dgvPrintServices.Name = "dgvPrintServices";
            this.dgvPrintServices.ReadOnly = true;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrintServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.dgvPrintServices.RowHeadersVisible = false;
            this.dgvPrintServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrintServices.Size = new System.Drawing.Size(1172, 362);
            this.dgvPrintServices.TabIndex = 0;
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
            // clmPrintSizeDescription
            // 
            this.clmPrintSizeDescription.DataPropertyName = "PrintSizeDescription";
            this.clmPrintSizeDescription.HeaderText = "توضیحات سایز چاپ";
            this.clmPrintSizeDescription.Name = "clmPrintSizeDescription";
            this.clmPrintSizeDescription.ReadOnly = true;
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
            this.clmDescription.HeaderText = "توضیحات سرویس";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // bgWorkerLoadPrintSizes1
            // 
            this.bgWorkerLoadPrintSizes1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadPrintSizes1_DoWork);
            this.bgWorkerLoadPrintSizes1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadPrintSizes1_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تنظیماتToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1172, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // تنظیماتToolStripMenuItem
            // 
            this.تنظیماتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تعریفToolStripMenuItem,
            this.ویرایشToolStripMenuItem,
            this.حذف_ToolStripMenuItem});
            this.تنظیماتToolStripMenuItem.Name = "تنظیماتToolStripMenuItem";
            this.تنظیماتToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.تنظیماتToolStripMenuItem.Text = "تنظیمات";
            // 
            // bgWorkerSaveNewPrintSize
            // 
            this.bgWorkerSaveNewPrintSize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerSaveNewPrintSize_DoWork);
            this.bgWorkerSaveNewPrintSize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerSaveNewPrintSize_RunWorkerCompleted);
            // 
            // bgWorkerDeletePrintSize
            // 
            this.bgWorkerDeletePrintSize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDeletePrintSize_DoWork);
            this.bgWorkerDeletePrintSize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerDeletePrintSize_RunWorkerCompleted);
            // 
            // bgWorkerUpdatePrintSize
            // 
            this.bgWorkerUpdatePrintSize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerUpdatePrintSize_DoWork);
            this.bgWorkerUpdatePrintSize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerUpdatePrintSize_RunWorkerCompleted);
            // 
            // bgWorkerGetPrintSizeInfo
            // 
            this.bgWorkerGetPrintSizeInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGetPrintSizeInfo_DoWork);
            this.bgWorkerGetPrintSizeInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGetPrintSizeInfo_RunWorkerCompleted);
            // 
            // bgWorkerGetPrintSizePrice
            // 
            this.bgWorkerGetPrintSizePrice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGetPrintSizePrice_DoWork);
            this.bgWorkerGetPrintSizePrice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGetPrintSizePrice_RunWorkerCompleted);
            // 
            // تعریفToolStripMenuItem
            // 
            this.تعریفToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem});
            this.تعریفToolStripMenuItem.Name = "تعریفToolStripMenuItem";
            this.تعریفToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.تعریفToolStripMenuItem.Text = "تعریف";
            // 
            // تعریف_خدمات_چاپ_جدید_ToolStripMenuItem
            // 
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Name = "تعریف_خدمات_چاپ_جدید_ToolStripMenuItem";
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Text = "تعریف خدمات چاپ";
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Click += new System.EventHandler(this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem_Click);
            // 
            // ویرایشToolStripMenuItem
            // 
            this.ویرایشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem});
            this.ویرایشToolStripMenuItem.Name = "ویرایشToolStripMenuItem";
            this.ویرایشToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ویرایشToolStripMenuItem.Text = "ویرایش";
            // 
            // حذف_ToolStripMenuItem
            // 
            this.حذف_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem,
            this.حذف_اندازه_چاپ_ToolStripMenuItem});
            this.حذف_ToolStripMenuItem.Name = "حذف_ToolStripMenuItem";
            this.حذف_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.حذف_ToolStripMenuItem.Text = "حذف";
            // 
            // حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem
            // 
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem.Name = "حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem";
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem.Text = "حذف خدمات چاپ مربوط به اندازه چاپ";
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem.Click += new System.EventHandler(this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem_Click);
            // 
            // حذف_اندازه_چاپ_ToolStripMenuItem
            // 
            this.حذف_اندازه_چاپ_ToolStripMenuItem.Name = "حذف_اندازه_چاپ_ToolStripMenuItem";
            this.حذف_اندازه_چاپ_ToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.حذف_اندازه_چاپ_ToolStripMenuItem.Text = "حذف اندازه چاپ";
            this.حذف_اندازه_چاپ_ToolStripMenuItem.Click += new System.EventHandler(this.حذف_اندازه_چاپ_ToolStripMenuItem_Click);
            // 
            // ویرایش_اندازه_چاپ_ToolStripMenuItem
            // 
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Name = "ویرایش_اندازه_چاپ_ToolStripMenuItem";
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Text = "ویرایش اندازه چاپ";
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Click += new System.EventHandler(this.ویرایش_اندازه_چاپ_ToolStripMenuItem_Click);
            // 
            // FrmAddEditPrintSizeAndServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 546);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditPrintSizeAndServices";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت و ویرایش خدمات چاپ";
            this.Load += new System.EventHandler(this.FrmAddEditPrintSizeAndServices_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupBoxPrintSize.ResumeLayout(false);
            this.panelHasPrintService.ResumeLayout(false);
            this.panelHasPrintService.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panelOriginalPrintPrice.ResumeLayout(false);
            this.panelOriginalPrintPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputOriginalPrintPrice)).EndInit();
            this.panelSecondPrintPrice.ResumeLayout(false);
            this.panelSecondPrintPrice.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputSecondPrintPrice)).EndInit();
            this.panelNewEditPrintSize.ResumeLayout(false);
            this.panelNewEditPrintSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputWidth)).EndInit();
            this.panelPrintSize1.ResumeLayout(false);
            this.panelPrintSize1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.groupBoxPrintServices.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputPrintServicePrice)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelPrintSize2.ResumeLayout(false);
            this.panelPrintSize2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintServices)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPrintServices;
        private System.Windows.Forms.GroupBox groupBoxPrintSize;
        private System.Windows.Forms.GroupBox groupBoxPrintServices;
        private System.Windows.Forms.Label label15;
        private DevComponents.Editors.IntegerInput integerInputSecondPrintPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelSecondPrintPrice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        //private DevComponents.Editors.IntegerInput integerInputOriginalPrintPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelNewEditPrintSize;
        private DevComponents.Editors.DoubleInput doubleInputHeight;
        private DevComponents.Editors.DoubleInput doubleInputWidth;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxNewSize;
        private System.Windows.Forms.Panel panelPrintSize1;
        private System.Windows.Forms.ComboBox cmbPrintSizes;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnSavePrintSizePrice;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbPrintServices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelPrintSize2;
        private System.Windows.Forms.ComboBox cmbPrintSizes2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelOriginalPrintPrice;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.IntegerInput integerInputOriginalPrintPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label17;
        //private DevComponents.Editors.IntegerInput integerInput2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private DevComponents.Editors.IntegerInput integerInputPrintServicePrice;
        private System.Windows.Forms.Label label19;
        private DevComponents.DotNetBar.ButtonX btnSavePrintServicePrice;
        private DevComponents.DotNetBar.Controls.CircularProgress cpLoadPrintSizes1;
        private System.Windows.Forms.Panel panelHasPrintService;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label21;
        //private DevComponents.Editors.IntegerInput integerInput3;
        private System.Windows.Forms.Label label22;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxEnableGroupBoxPrintServices;
        private System.Windows.Forms.Label label20;
        private DevComponents.DotNetBar.Controls.CircularProgress cpLoadDataGridView;
        private DevComponents.DotNetBar.Controls.CircularProgress cpPrintServices;
        private DevComponents.DotNetBar.Controls.CircularProgress cpLoadPrintSizes2;
        private DevComponents.DotNetBar.Controls.CircularProgress cpGetPrintSizePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrintServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrintSizePriceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOriginalPrintPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSecondPrintPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrintSizeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrintServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintSizes1;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintSizes2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem تنظیماتToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgWorkerSaveNewPrintSize;
        private DevComponents.DotNetBar.Controls.CircularProgress cpBtnSave;
        private System.ComponentModel.BackgroundWorker bgWorkerDeletePrintSize;
        private System.ComponentModel.BackgroundWorker bgWorkerUpdatePrintSize;
        private System.ComponentModel.BackgroundWorker bgWorkerGetPrintSizeInfo;
        private System.ComponentModel.BackgroundWorker bgWorkerGetPrintSizePrice;
        private System.Windows.Forms.ToolStripMenuItem تعریفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعریف_خدمات_چاپ_جدید_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ویرایشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ویرایش_اندازه_چاپ_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذف_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذف_اندازه_چاپ_ToolStripMenuItem;
    }
}