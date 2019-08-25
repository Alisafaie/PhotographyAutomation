namespace PhotographyAutomation.App.Forms.Admin
{
    partial class FrmAddEditPrintSizeServices
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.تنظیماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBoxPrintSize = new System.Windows.Forms.GroupBox();
            this.cmbPrintSizes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBoxPrintServices = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.iiPrintServicePrice = new DevComponents.Editors.IntegerInput();
            this.label19 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPrintServiceCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbPrintServices = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.gbDataGridView = new System.Windows.Forms.GroupBox();
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
            this.menuStrip1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.groupBoxPrintSize.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupBoxPrintServices.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iiPrintServicePrice)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.gbDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintServices)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تنظیماتToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1078, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // تنظیماتToolStripMenuItem
            // 
            this.تنظیماتToolStripMenuItem.Name = "تنظیماتToolStripMenuItem";
            this.تنظیماتToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.تنظیماتToolStripMenuItem.Text = "تنظیمات";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1078, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            this.panelEx1.Size = new System.Drawing.Size(1078, 86);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // groupBoxPrintSize
            // 
            this.groupBoxPrintSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPrintSize.Controls.Add(this.cmbPrintSizes);
            this.groupBoxPrintSize.Controls.Add(this.label1);
            this.groupBoxPrintSize.Location = new System.Drawing.Point(12, 5);
            this.groupBoxPrintSize.Name = "groupBoxPrintSize";
            this.groupBoxPrintSize.Size = new System.Drawing.Size(1054, 69);
            this.groupBoxPrintSize.TabIndex = 1;
            this.groupBoxPrintSize.TabStop = false;
            this.groupBoxPrintSize.Text = "اندازه و ویژگی های اندازه عکس";
            // 
            // cmbPrintSizes
            // 
            this.cmbPrintSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintSizes.Enabled = false;
            this.cmbPrintSizes.FormattingEnabled = true;
            this.cmbPrintSizes.Location = new System.Drawing.Point(855, 31);
            this.cmbPrintSizes.Name = "cmbPrintSizes";
            this.cmbPrintSizes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPrintSizes.Size = new System.Drawing.Size(124, 21);
            this.cmbPrintSizes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(992, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "اندازه چاپ";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.groupBoxPrintServices);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 110);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1078, 81);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // groupBoxPrintServices
            // 
            this.groupBoxPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPrintServices.Controls.Add(this.btnCancel);
            this.groupBoxPrintServices.Controls.Add(this.btnSave);
            this.groupBoxPrintServices.Controls.Add(this.panel9);
            this.groupBoxPrintServices.Controls.Add(this.panel8);
            this.groupBoxPrintServices.Controls.Add(this.panel6);
            this.groupBoxPrintServices.Enabled = false;
            this.groupBoxPrintServices.Location = new System.Drawing.Point(12, 6);
            this.groupBoxPrintServices.Name = "groupBoxPrintServices";
            this.groupBoxPrintServices.Size = new System.Drawing.Size(1054, 62);
            this.groupBoxPrintServices.TabIndex = 1;
            this.groupBoxPrintServices.TabStop = false;
            this.groupBoxPrintServices.Text = "خدمات چاپ";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(87, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnCancel.Symbol = "";
            this.btnCancel.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.SymbolSize = 10F;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصراف";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(6, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnSave.Symbol = "";
            this.btnSave.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.SymbolSize = 10F;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "ثبت";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.label16);
            this.panel9.Controls.Add(this.iiPrintServicePrice);
            this.panel9.Controls.Add(this.label19);
            this.panel9.Location = new System.Drawing.Point(625, 20);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(220, 34);
            this.panel9.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Location = new System.Drawing.Point(6, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "ريال";
            // 
            // iiPrintServicePrice
            // 
            this.iiPrintServicePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.iiPrintServicePrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiPrintServicePrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiPrintServicePrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiPrintServicePrice.DisplayFormat = "N0";
            this.iiPrintServicePrice.Increment = 10000;
            this.iiPrintServicePrice.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.iiPrintServicePrice.IsInputReadOnly = true;
            this.iiPrintServicePrice.Location = new System.Drawing.Point(34, 6);
            this.iiPrintServicePrice.MinValue = 0;
            this.iiPrintServicePrice.Name = "iiPrintServicePrice";
            this.iiPrintServicePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iiPrintServicePrice.Size = new System.Drawing.Size(100, 21);
            this.iiPrintServicePrice.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(140, 9);
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
            this.panel8.Location = new System.Drawing.Point(434, 20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(185, 34);
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
            this.txtPrintServiceCode.Location = new System.Drawing.Point(14, 7);
            this.txtPrintServiceCode.Name = "txtPrintServiceCode";
            this.txtPrintServiceCode.PreventEnterBeep = true;
            this.txtPrintServiceCode.ReadOnly = true;
            this.txtPrintServiceCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrintServiceCode.Size = new System.Drawing.Size(100, 21);
            this.txtPrintServiceCode.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(120, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "کد سرویس";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.cmbPrintServices);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(851, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(197, 34);
            this.panel6.TabIndex = 0;
            // 
            // cmbPrintServices
            // 
            this.cmbPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintServices.FormattingEnabled = true;
            this.cmbPrintServices.Location = new System.Drawing.Point(4, 6);
            this.cmbPrintServices.Name = "cmbPrintServices";
            this.cmbPrintServices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPrintServices.Size = new System.Drawing.Size(124, 21);
            this.cmbPrintServices.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "خدمات چاپ";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.gbDataGridView);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3.Location = new System.Drawing.Point(0, 191);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1078, 344);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 0;
            this.panelEx3.Text = "panelEx3";
            // 
            // gbDataGridView
            // 
            this.gbDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDataGridView.Controls.Add(this.cpLoadDataGridView);
            this.gbDataGridView.Controls.Add(this.dgvPrintServices);
            this.gbDataGridView.Location = new System.Drawing.Point(12, 6);
            this.gbDataGridView.Name = "gbDataGridView";
            this.gbDataGridView.Size = new System.Drawing.Size(1054, 335);
            this.gbDataGridView.TabIndex = 1;
            this.gbDataGridView.TabStop = false;
            // 
            // cpLoadDataGridView
            // 
            this.cpLoadDataGridView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // 
            // 
            this.cpLoadDataGridView.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpLoadDataGridView.Location = new System.Drawing.Point(554, 108);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrintServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPrintServices.RowHeadersVisible = false;
            this.dgvPrintServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrintServices.Size = new System.Drawing.Size(1048, 315);
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
            // FrmAddEditPrintSizeServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 557);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditPrintSizeServices";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت / ویرایش خدمات اندازه چاپ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.groupBoxPrintSize.ResumeLayout(false);
            this.groupBoxPrintSize.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.groupBoxPrintServices.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iiPrintServicePrice)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.gbDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.GroupBox groupBoxPrintSize;
        private System.Windows.Forms.ComboBox cmbPrintSizes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxPrintServices;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label16;
        private DevComponents.Editors.IntegerInput iiPrintServicePrice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrintServiceCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbPrintServices;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.GroupBox gbDataGridView;
        private DevComponents.DotNetBar.Controls.CircularProgress cpLoadDataGridView;
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
        private System.Windows.Forms.ToolStripMenuItem تنظیماتToolStripMenuItem;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}