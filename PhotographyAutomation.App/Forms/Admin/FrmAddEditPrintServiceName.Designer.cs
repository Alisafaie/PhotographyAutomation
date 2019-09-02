namespace PhotographyAutomation.App.Forms.Admin
{
    partial class FrmAddEditPrintServiceName
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
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.groupBoxPrintService = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrintServiceDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPrintServiceName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPrintServiceCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPrintServices = new System.Windows.Forms.ComboBox();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelEx2.SuspendLayout();
            this.groupBoxPrintService.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.groupBoxPrintService);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(588, 205);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // groupBoxPrintService
            // 
            this.groupBoxPrintService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPrintService.Controls.Add(this.panel4);
            this.groupBoxPrintService.Controls.Add(this.panel1);
            this.groupBoxPrintService.Controls.Add(this.btnCancel);
            this.groupBoxPrintService.Controls.Add(this.btnSave);
            this.groupBoxPrintService.Controls.Add(this.panel2);
            this.groupBoxPrintService.Controls.Add(this.panel3);
            this.groupBoxPrintService.Location = new System.Drawing.Point(3, 10);
            this.groupBoxPrintService.Name = "groupBoxPrintService";
            this.groupBoxPrintService.Size = new System.Drawing.Size(582, 191);
            this.groupBoxPrintService.TabIndex = 0;
            this.groupBoxPrintService.TabStop = false;
            this.groupBoxPrintService.Text = "اطلاعات خدمت چاپ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtPrintServiceDescription);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 52);
            this.panel1.TabIndex = 2;
            // 
            // txtPrintServiceDescription
            // 
            this.txtPrintServiceDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPrintServiceDescription.Border.Class = "TextBoxBorder";
            this.txtPrintServiceDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.txtPrintServiceDescription, true);
            this.txtPrintServiceDescription.Location = new System.Drawing.Point(21, 7);
            this.txtPrintServiceDescription.MaxLength = 500;
            this.txtPrintServiceDescription.Multiline = true;
            this.txtPrintServiceDescription.Name = "txtPrintServiceDescription";
            this.txtPrintServiceDescription.PreventEnterBeep = true;
            this.txtPrintServiceDescription.Size = new System.Drawing.Size(494, 41);
            this.txtPrintServiceDescription.TabIndex = 0;
            this.txtPrintServiceDescription.Enter += new System.EventHandler(this.txtPersian_Enter);
            this.txtPrintServiceDescription.Leave += new System.EventHandler(this.txtEnglish_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "توضیحات";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.highlighter1.SetHighlightOnFocus(this.btnCancel, true);
            this.btnCancel.Location = new System.Drawing.Point(420, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnCancel.Symbol = "";
            this.btnCancel.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.SymbolSize = 10F;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.highlighter1.SetHighlightOnFocus(this.btnSave, true);
            this.btnSave.Location = new System.Drawing.Point(501, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnSave.Symbol = "";
            this.btnSave.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.SymbolSize = 10F;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtPrintServiceName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(223, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 34);
            this.panel2.TabIndex = 0;
            // 
            // txtPrintServiceName
            // 
            this.txtPrintServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPrintServiceName.Border.Class = "TextBoxBorder";
            this.txtPrintServiceName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.highlighter1.SetHighlightOnFocus(this.txtPrintServiceName, true);
            this.txtPrintServiceName.Location = new System.Drawing.Point(24, 7);
            this.txtPrintServiceName.MaxLength = 50;
            this.txtPrintServiceName.Name = "txtPrintServiceName";
            this.txtPrintServiceName.PreventEnterBeep = true;
            this.txtPrintServiceName.Size = new System.Drawing.Size(268, 21);
            this.txtPrintServiceName.TabIndex = 0;
            this.txtPrintServiceName.Enter += new System.EventHandler(this.txtPersian_Enter);
            this.txtPrintServiceName.Leave += new System.EventHandler(this.txtEnglish_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "نام خدمت";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.txtPrintServiceCode);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 34);
            this.panel3.TabIndex = 1;
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
            this.txtPrintServiceCode.Location = new System.Drawing.Point(21, 7);
            this.txtPrintServiceCode.MaxLength = 50;
            this.txtPrintServiceCode.Name = "txtPrintServiceCode";
            this.txtPrintServiceCode.PreventEnterBeep = true;
            this.txtPrintServiceCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrintServiceCode.Size = new System.Drawing.Size(144, 21);
            this.txtPrintServiceCode.TabIndex = 0;
            this.txtPrintServiceCode.Enter += new System.EventHandler(this.txtEnglish_Leave);
            this.txtPrintServiceCode.Leave += new System.EventHandler(this.txtEnglish_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "کد خدمت";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Orange;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.checkBoxX1);
            this.panel4.Controls.Add(this.cmbPrintServices);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Enabled = false;
            this.panel4.Location = new System.Drawing.Point(0, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(576, 34);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "نام خدمت";
            // 
            // cmbPrintServices
            // 
            this.cmbPrintServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintServices.FormattingEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.cmbPrintServices, true);
            this.cmbPrintServices.Location = new System.Drawing.Point(247, 8);
            this.cmbPrintServices.Name = "cmbPrintServices";
            this.cmbPrintServices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPrintServices.Size = new System.Drawing.Size(268, 21);
            this.cmbPrintServices.TabIndex = 0;
            this.cmbPrintServices.SelectedIndexChanged += new System.EventHandler(this.cmbPrintServices_SelectedIndexChanged);
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Enabled = false;
            this.highlighter1.SetHighlightOnFocus(this.checkBoxX1, true);
            this.checkBoxX1.Location = new System.Drawing.Point(98, 11);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(126, 16);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 1;
            this.checkBoxX1.Text = "حذف کامل خدمت چاپ";
            // 
            // FrmAddEditPrintServiceName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(588, 205);
            this.Controls.Add(this.panelEx2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditPrintServiceName";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت / ویرایش اطلاعات خدمات چاپ";
            this.Load += new System.EventHandler(this.FrmAddEditPrintServiceName_Load);
            this.panelEx2.ResumeLayout(false);
            this.groupBoxPrintService.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.GroupBox groupBoxPrintService;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrintServiceCode;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrintServiceName;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrintServiceDescription;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPrintServices;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
    }
}