﻿namespace PhotographyAutomation.App.Forms.Admin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBoxPrintSize = new System.Windows.Forms.GroupBox();
            this.cpBtnSave = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.panelHasPrintService = new System.Windows.Forms.Panel();
            this.checkBoxHasPrintServices = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelOriginalPrintPrice = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.integerInputOriginalPrintPrice = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.panelSecondPrintPrice = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
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
            this.cpBtnSavePrintService = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.integerInputPrintServicePrice = new DevComponents.Editors.IntegerInput();
            this.label19 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPrintServiceCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cpPrintServices = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.cmbPrintServices = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelPrintServices = new DevComponents.DotNetBar.ButtonX();
            this.btnSavePrintServicePrice = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.bgWorkerLoadPrintSizes = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerLoadPrintSizes2 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.تنظیماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعریفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشخدماتچاپToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذف_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذف_اندازه_چاپ_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorkerSaveNewPrintSize = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerDeletePrintSize = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerUpdatePrintSize = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerGetPrintSizeInfo = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerGetPrintSizePrice = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerLoadPrintServices = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerGetPrintSizeServicePrice = new System.ComponentModel.BackgroundWorker();
            this.panelEx1.SuspendLayout();
            this.groupBoxPrintSize.SuspendLayout();
            this.panelHasPrintService.SuspendLayout();
            this.panelOriginalPrintPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputOriginalPrintPrice)).BeginInit();
            this.panelSecondPrintPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputSecondPrintPrice)).BeginInit();
            this.panelNewEditPrintSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputWidth)).BeginInit();
            this.panelPrintSize1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupBoxPrintServices.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputPrintServicePrice)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panelEx1.Size = new System.Drawing.Size(1138, 86);
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
            this.groupBoxPrintSize.Location = new System.Drawing.Point(12, 10);
            this.groupBoxPrintSize.Name = "groupBoxPrintSize";
            this.groupBoxPrintSize.Size = new System.Drawing.Size(1114, 67);
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
            // 
            // panelHasPrintService
            // 
            this.panelHasPrintService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHasPrintService.Controls.Add(this.checkBoxHasPrintServices);
            this.panelHasPrintService.Location = new System.Drawing.Point(103, 23);
            this.panelHasPrintService.Name = "panelHasPrintService";
            this.panelHasPrintService.Size = new System.Drawing.Size(117, 37);
            this.panelHasPrintService.TabIndex = 4;
            // 
            // checkBoxHasPrintServices
            // 
            this.checkBoxHasPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHasPrintServices.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxHasPrintServices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.checkBoxHasPrintServices, true);
            this.checkBoxHasPrintServices.Location = new System.Drawing.Point(17, 11);
            this.checkBoxHasPrintServices.Name = "checkBoxHasPrintServices";
            this.checkBoxHasPrintServices.Size = new System.Drawing.Size(97, 16);
            this.checkBoxHasPrintServices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxHasPrintServices.TabIndex = 0;
            this.checkBoxHasPrintServices.Text = "خدمات چاپ دارد";
            // 
            // panelOriginalPrintPrice
            // 
            this.panelOriginalPrintPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOriginalPrintPrice.Controls.Add(this.label4);
            this.panelOriginalPrintPrice.Controls.Add(this.integerInputOriginalPrintPrice);
            this.panelOriginalPrintPrice.Controls.Add(this.label7);
            this.panelOriginalPrintPrice.Location = new System.Drawing.Point(454, 23);
            this.panelOriginalPrintPrice.Name = "panelOriginalPrintPrice";
            this.panelOriginalPrintPrice.Size = new System.Drawing.Size(211, 37);
            this.panelOriginalPrintPrice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(3, 13);
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
            this.panelSecondPrintPrice.Controls.Add(this.integerInputSecondPrintPrice);
            this.panelSecondPrintPrice.Controls.Add(this.label15);
            this.panelSecondPrintPrice.Location = new System.Drawing.Point(226, 23);
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
            this.panelNewEditPrintSize.Location = new System.Drawing.Point(671, 23);
            this.panelNewEditPrintSize.Name = "panelNewEditPrintSize";
            this.panelNewEditPrintSize.Size = new System.Drawing.Size(210, 37);
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
            this.doubleInputHeight.Location = new System.Drawing.Point(85, 9);
            this.doubleInputHeight.MinValue = 0D;
            this.doubleInputHeight.Name = "doubleInputHeight";
            this.doubleInputHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputHeight.Size = new System.Drawing.Size(49, 21);
            this.doubleInputHeight.TabIndex = 2;
            this.doubleInputHeight.WatermarkText = "(cm)طول";
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
            this.doubleInputWidth.Location = new System.Drawing.Point(9, 9);
            this.doubleInputWidth.MinValue = 0D;
            this.doubleInputWidth.Name = "doubleInputWidth";
            this.doubleInputWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputWidth.Size = new System.Drawing.Size(54, 21);
            this.doubleInputWidth.TabIndex = 1;
            this.doubleInputWidth.WatermarkText = "(cm)عرض";
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
            this.checkBoxNewSize.Location = new System.Drawing.Point(138, 11);
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
            this.label8.Location = new System.Drawing.Point(66, 13);
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
            this.panelPrintSize1.Location = new System.Drawing.Point(887, 23);
            this.panelPrintSize1.Name = "panelPrintSize1";
            this.panelPrintSize1.Size = new System.Drawing.Size(221, 37);
            this.panelPrintSize1.TabIndex = 0;
            // 
            // cpLoadPrintSizes1
            // 
            this.cpLoadPrintSizes1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // 
            // cmbPrintSizes
            // 
            this.cmbPrintSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintSizes.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintSizes, true);
            this.cmbPrintSizes.Location = new System.Drawing.Point(20, 9);
            this.cmbPrintSizes.Name = "cmbPrintSizes";
            this.cmbPrintSizes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPrintSizes.Size = new System.Drawing.Size(128, 21);
            this.cmbPrintSizes.TabIndex = 0;
            this.cmbPrintSizes.SelectedIndexChanged += new System.EventHandler(this.cmbPrintSizes_SelectedIndexChanged);
            this.cmbPrintSizes.EnabledChanged += new System.EventHandler(this.cmbPrintSizes_EnabledChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 13);
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
            this.btnSavePrintSizePrice.Symbol = "";
            this.btnSavePrintSizePrice.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSavePrintSizePrice.SymbolSize = 10F;
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
            this.panelEx2.Location = new System.Drawing.Point(0, 110);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1138, 86);
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
            this.groupBoxPrintServices.Controls.Add(this.cpBtnSavePrintService);
            this.groupBoxPrintServices.Controls.Add(this.panel9);
            this.groupBoxPrintServices.Controls.Add(this.panel8);
            this.groupBoxPrintServices.Controls.Add(this.panel6);
            this.groupBoxPrintServices.Controls.Add(this.btnCancelPrintServices);
            this.groupBoxPrintServices.Controls.Add(this.btnSavePrintServicePrice);
            this.groupBoxPrintServices.Enabled = false;
            this.groupBoxPrintServices.Location = new System.Drawing.Point(12, 10);
            this.groupBoxPrintServices.Name = "groupBoxPrintServices";
            this.groupBoxPrintServices.Size = new System.Drawing.Size(1114, 67);
            this.groupBoxPrintServices.TabIndex = 0;
            this.groupBoxPrintServices.TabStop = false;
            this.groupBoxPrintServices.Text = "خدمات چاپ";
            // 
            // cpBtnSavePrintService
            // 
            // 
            // 
            // 
            this.cpBtnSavePrintService.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpBtnSavePrintService.Location = new System.Drawing.Point(162, 26);
            this.cpBtnSavePrintService.Name = "cpBtnSavePrintService";
            this.cpBtnSavePrintService.ProgressColor = System.Drawing.Color.Blue;
            this.cpBtnSavePrintService.Size = new System.Drawing.Size(14, 21);
            this.cpBtnSavePrintService.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpBtnSavePrintService.TabIndex = 45;
            this.cpBtnSavePrintService.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.label16);
            this.panel9.Controls.Add(this.integerInputPrintServicePrice);
            this.panel9.Controls.Add(this.label19);
            this.panel9.Location = new System.Drawing.Point(454, 20);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(211, 34);
            this.panel9.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Location = new System.Drawing.Point(3, 10);
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
            this.integerInputPrintServicePrice.Location = new System.Drawing.Point(27, 6);
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
            this.label19.Location = new System.Drawing.Point(134, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "هزینه سرویس";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.txtPrintServiceCode);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Location = new System.Drawing.Point(671, 20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(210, 34);
            this.panel8.TabIndex = 1;
            // 
            // txtPrintServiceCode
            // 
            this.txtPrintServiceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPrintServiceCode.Border.Class = "TextBoxBorder";
            this.txtPrintServiceCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.txtPrintServiceCode, true);
            this.txtPrintServiceCode.Location = new System.Drawing.Point(9, 7);
            this.txtPrintServiceCode.Name = "txtPrintServiceCode";
            this.txtPrintServiceCode.PreventEnterBeep = true;
            this.txtPrintServiceCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrintServiceCode.Size = new System.Drawing.Size(125, 21);
            this.txtPrintServiceCode.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(145, 10);
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
            this.panel6.Location = new System.Drawing.Point(887, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(221, 34);
            this.panel6.TabIndex = 0;
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
            // 
            // cmbPrintServices
            // 
            this.cmbPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintServices.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintServices, true);
            this.cmbPrintServices.Location = new System.Drawing.Point(20, 6);
            this.cmbPrintServices.Name = "cmbPrintServices";
            this.cmbPrintServices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPrintServices.Size = new System.Drawing.Size(128, 21);
            this.cmbPrintServices.TabIndex = 0;
            this.cmbPrintServices.SelectedIndexChanged += new System.EventHandler(this.cmbPrintServices_SelectedIndexChanged);
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
            // btnCancelPrintServices
            // 
            this.btnCancelPrintServices.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelPrintServices.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelPrintServices.Location = new System.Drawing.Point(83, 24);
            this.btnCancelPrintServices.Name = "btnCancelPrintServices";
            this.btnCancelPrintServices.Size = new System.Drawing.Size(75, 23);
            this.btnCancelPrintServices.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnCancelPrintServices.Symbol = "";
            this.btnCancelPrintServices.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancelPrintServices.SymbolSize = 10F;
            this.btnCancelPrintServices.TabIndex = 1;
            this.btnCancelPrintServices.Text = "انصراف";
            this.btnCancelPrintServices.Click += new System.EventHandler(this.btnCancelPrintServices_Click);
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
            this.btnSavePrintServicePrice.Symbol = "";
            this.btnSavePrintServicePrice.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSavePrintServicePrice.SymbolSize = 10F;
            this.btnSavePrintServicePrice.TabIndex = 0;
            this.btnSavePrintServicePrice.Text = "ثبت";
            this.btnSavePrintServicePrice.Click += new System.EventHandler(this.btnSavePrintServicePrice_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.groupBox1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 196);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1138, 388);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cpLoadDataGridView);
            this.groupBox1.Controls.Add(this.dgvPrintServices);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1114, 376);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cpLoadDataGridView
            // 
            this.cpLoadDataGridView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // 
            // 
            this.cpLoadDataGridView.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpLoadDataGridView.Location = new System.Drawing.Point(545, 157);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPrintServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrintServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrintServices.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPrintServices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.clmPrintSizeDescription,
            this.clmPrintServiceName,
            this.clmPrice,
            this.clmDescription});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrintServices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPrintServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrintServices.EnableHeadersVisualStyles = false;
            this.dgvPrintServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvPrintServices.Location = new System.Drawing.Point(3, 17);
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
            this.dgvPrintServices.Size = new System.Drawing.Size(1108, 356);
            this.dgvPrintServices.TabIndex = 3;
            this.dgvPrintServices.UseCustomBackgroundColor = true;
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
            // bgWorkerLoadPrintSizes
            // 
            this.bgWorkerLoadPrintSizes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadPrintSizes1_DoWork);
            this.bgWorkerLoadPrintSizes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadPrintSizes1_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تنظیماتToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1138, 24);
            this.menuStrip1.TabIndex = 1;
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
            // تعریفToolStripMenuItem
            // 
            this.تعریفToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem});
            this.تعریفToolStripMenuItem.Name = "تعریفToolStripMenuItem";
            this.تعریفToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.تعریفToolStripMenuItem.Text = "تعریف";
            // 
            // تعریف_خدمات_چاپ_جدید_ToolStripMenuItem
            // 
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Name = "تعریف_خدمات_چاپ_جدید_ToolStripMenuItem";
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Text = "تعریف خدمات چاپ";
            this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem.Click += new System.EventHandler(this.تعریف_خدمات_چاپ_جدید_ToolStripMenuItem_Click);
            // 
            // ویرایشToolStripMenuItem
            // 
            this.ویرایشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem,
            this.ویرایشخدماتچاپToolStripMenuItem});
            this.ویرایشToolStripMenuItem.Name = "ویرایشToolStripMenuItem";
            this.ویرایشToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ویرایشToolStripMenuItem.Text = "ویرایش";
            // 
            // ویرایش_اندازه_چاپ_ToolStripMenuItem
            // 
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Name = "ویرایش_اندازه_چاپ_ToolStripMenuItem";
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Text = "ویرایش اندازه چاپ";
            this.ویرایش_اندازه_چاپ_ToolStripMenuItem.Click += new System.EventHandler(this.ویرایش_اندازه_چاپ_ToolStripMenuItem_Click);
            // 
            // ویرایشخدماتچاپToolStripMenuItem
            // 
            this.ویرایشخدماتچاپToolStripMenuItem.Name = "ویرایشخدماتچاپToolStripMenuItem";
            this.ویرایشخدماتچاپToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ویرایشخدماتچاپToolStripMenuItem.Text = "ویرایش خدمات چاپ";
            // 
            // حذف_ToolStripMenuItem
            // 
            this.حذف_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem,
            this.حذف_اندازه_چاپ_ToolStripMenuItem});
            this.حذف_ToolStripMenuItem.Name = "حذف_ToolStripMenuItem";
            this.حذف_ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
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
            // bgWorkerLoadPrintServices
            // 
            this.bgWorkerLoadPrintServices.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadPrintServices_DoWork);
            this.bgWorkerLoadPrintServices.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadPrintServices_RunWorkerCompleted);
            // 
            // bgWorkerGetPrintSizeServicePrice
            // 
            this.bgWorkerGetPrintSizeServicePrice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGetPrintSizeServicePrice_DoWork);
            this.bgWorkerGetPrintSizeServicePrice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGetPrintSizeServicePrice_RunWorkerCompleted);
            // 
            // FrmAddEditPrintSizeAndServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 584);
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
            this.Load += new System.EventHandler(this.FrmAddEditPrintSizeAndServices_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupBoxPrintSize.ResumeLayout(false);
            this.panelHasPrintService.ResumeLayout(false);
            this.panelHasPrintService.PerformLayout();
            this.panelOriginalPrintPrice.ResumeLayout(false);
            this.panelOriginalPrintPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInputOriginalPrintPrice)).EndInit();
            this.panelSecondPrintPrice.ResumeLayout(false);
            this.panelSecondPrintPrice.PerformLayout();
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
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBoxPrintSize;
        private System.Windows.Forms.GroupBox groupBoxPrintServices;
        private System.Windows.Forms.Label label15;
        private DevComponents.Editors.IntegerInput integerInputSecondPrintPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelSecondPrintPrice;
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
        private System.Windows.Forms.Panel panelOriginalPrintPrice;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.IntegerInput integerInputOriginalPrintPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label16;
        private DevComponents.Editors.IntegerInput integerInputPrintServicePrice;
        private System.Windows.Forms.Label label19;
        private DevComponents.DotNetBar.ButtonX btnSavePrintServicePrice;
        private DevComponents.DotNetBar.Controls.CircularProgress cpLoadPrintSizes1;
        private System.Windows.Forms.Panel panelHasPrintService;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxHasPrintServices;
        private DevComponents.DotNetBar.Controls.CircularProgress cpLoadDataGridView;
        private DevComponents.DotNetBar.Controls.CircularProgress cpPrintServices;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintSizes;
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrintServiceCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPrintServices;
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
        private System.ComponentModel.BackgroundWorker bgWorkerLoadPrintServices;
        private System.Windows.Forms.ToolStripMenuItem ویرایشخدماتچاپToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnCancelPrintServices;
        private System.ComponentModel.BackgroundWorker bgWorkerGetPrintSizeServicePrice;
        private DevComponents.DotNetBar.Controls.CircularProgress cpBtnSavePrintService;
    }
}