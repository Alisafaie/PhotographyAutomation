namespace PhotographyAutomation.App.Forms.Factors
{
    partial class FrmAddEditPreFactor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditPreFactor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCustomerInfo = new System.Windows.Forms.RadioButton();
            this.txtCustomerInfo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rbOrderStatus = new System.Windows.Forms.RadioButton();
            this.rbOrderDate = new System.Windows.Forms.RadioButton();
            this.btnShowOrders = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.rbOrderCode = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableOrderStatusDatePicker = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.datePickerOrderDate = new FreeControls.PersianDateTimePicker();
            this.datePickerOrderStatus = new FreeControls.PersianDateTimePicker();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.txtOrderCodeDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtOrderCodeCustomerIdBookingId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.dgvCustomerSelectedPhotos = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1196, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 24);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1196, 568);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvCustomerSelectedPhotos);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 456);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbCustomerInfo);
            this.groupBox2.Controls.Add(this.txtCustomerInfo);
            this.groupBox2.Controls.Add(this.rbOrderStatus);
            this.groupBox2.Controls.Add(this.rbOrderDate);
            this.groupBox2.Controls.Add(this.btnShowOrders);
            this.groupBox2.Controls.Add(this.btnClearSearch);
            this.groupBox2.Controls.Add(this.rbOrderCode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkEnableOrderStatusDatePicker);
            this.groupBox2.Controls.Add(this.datePickerOrderDate);
            this.groupBox2.Controls.Add(this.datePickerOrderStatus);
            this.groupBox2.Controls.Add(this.cmbOrderStatus);
            this.groupBox2.Controls.Add(this.txtOrderCodeDate);
            this.groupBox2.Controls.Add(this.txtOrderCodeCustomerIdBookingId);
            this.groupBox2.Controls.Add(this.labelX4);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1172, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مشاهده سفارشات بر اساس";
            // 
            // rbCustomerInfo
            // 
            this.rbCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCustomerInfo.Location = new System.Drawing.Point(960, 65);
            this.rbCustomerInfo.Name = "rbCustomerInfo";
            this.rbCustomerInfo.Size = new System.Drawing.Size(108, 17);
            this.rbCustomerInfo.TabIndex = 1;
            this.rbCustomerInfo.Text = "اطلاعات مشتری";
            this.rbCustomerInfo.UseVisualStyleBackColor = true;
            // 
            // txtCustomerInfo
            // 
            this.txtCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCustomerInfo.Border.Class = "TextBoxBorder";
            this.txtCustomerInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerInfo.Enabled = false;
            this.txtCustomerInfo.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtCustomerInfo.FocusHighlightEnabled = true;
            this.txtCustomerInfo.Location = new System.Drawing.Point(729, 65);
            this.txtCustomerInfo.Name = "txtCustomerInfo";
            this.txtCustomerInfo.PreventEnterBeep = true;
            this.txtCustomerInfo.Size = new System.Drawing.Size(230, 21);
            this.txtCustomerInfo.TabIndex = 6;
            this.txtCustomerInfo.WatermarkText = "(نام ، نام خانوادگی ، تلفن ثابت، تلفن همراه)";
            // 
            // rbOrderStatus
            // 
            this.rbOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOrderStatus.AutoSize = true;
            this.rbOrderStatus.Location = new System.Drawing.Point(603, 67);
            this.rbOrderStatus.Name = "rbOrderStatus";
            this.rbOrderStatus.Size = new System.Drawing.Size(70, 17);
            this.rbOrderStatus.TabIndex = 3;
            this.rbOrderStatus.Text = "موارد دیگر";
            this.rbOrderStatus.UseVisualStyleBackColor = true;
            // 
            // rbOrderDate
            // 
            this.rbOrderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOrderDate.AutoSize = true;
            this.rbOrderDate.Location = new System.Drawing.Point(627, 35);
            this.rbOrderDate.Name = "rbOrderDate";
            this.rbOrderDate.Size = new System.Drawing.Size(46, 17);
            this.rbOrderDate.TabIndex = 2;
            this.rbOrderDate.Text = "تاریخ";
            this.rbOrderDate.UseVisualStyleBackColor = true;
            // 
            // btnShowOrders
            // 
            this.btnShowOrders.FlatAppearance.BorderSize = 0;
            this.btnShowOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOrders.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_Search_text_131785;
            this.btnShowOrders.Location = new System.Drawing.Point(47, 58);
            this.btnShowOrders.Name = "btnShowOrders";
            this.btnShowOrders.Size = new System.Drawing.Size(32, 32);
            this.btnShowOrders.TabIndex = 11;
            this.btnShowOrders.UseVisualStyleBackColor = true;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_Gnome_Edit_Clear_32_54970;
            this.btnClearSearch.Location = new System.Drawing.Point(9, 58);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(32, 32);
            this.btnClearSearch.TabIndex = 12;
            this.btnClearSearch.UseVisualStyleBackColor = true;
            // 
            // rbOrderCode
            // 
            this.rbOrderCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOrderCode.Location = new System.Drawing.Point(960, 35);
            this.rbOrderCode.Name = "rbOrderCode";
            this.rbOrderCode.Size = new System.Drawing.Size(108, 17);
            this.rbOrderCode.TabIndex = 0;
            this.rbOrderCode.Text = "شناسه سفارش";
            this.rbOrderCode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1074, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "جستجو بر اساس:";
            // 
            // chkEnableOrderStatusDatePicker
            // 
            this.chkEnableOrderStatusDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.chkEnableOrderStatusDatePicker.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEnableOrderStatusDatePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEnableOrderStatusDatePicker.Enabled = false;
            this.chkEnableOrderStatusDatePicker.Location = new System.Drawing.Point(427, 66);
            this.chkEnableOrderStatusDatePicker.Name = "chkEnableOrderStatusDatePicker";
            this.chkEnableOrderStatusDatePicker.Size = new System.Drawing.Size(15, 18);
            this.chkEnableOrderStatusDatePicker.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEnableOrderStatusDatePicker.TabIndex = 9;
            // 
            // datePickerOrderDate
            // 
            this.datePickerOrderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerOrderDate.BackColor = System.Drawing.Color.White;
            this.datePickerOrderDate.Enabled = false;
            this.datePickerOrderDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerOrderDate.Location = new System.Drawing.Point(486, 35);
            this.datePickerOrderDate.Name = "datePickerOrderDate";
            this.datePickerOrderDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerOrderDate.ShowTime = false;
            this.datePickerOrderDate.Size = new System.Drawing.Size(111, 18);
            this.datePickerOrderDate.TabIndex = 7;
            this.datePickerOrderDate.Text = "persianDateTimePicker1";
            this.datePickerOrderDate.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerOrderDate.Value")));
            // 
            // datePickerOrderStatus
            // 
            this.datePickerOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerOrderStatus.BackColor = System.Drawing.Color.White;
            this.datePickerOrderStatus.Enabled = false;
            this.datePickerOrderStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerOrderStatus.Location = new System.Drawing.Point(314, 66);
            this.datePickerOrderStatus.Name = "datePickerOrderStatus";
            this.datePickerOrderStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerOrderStatus.ShowTime = false;
            this.datePickerOrderStatus.Size = new System.Drawing.Size(111, 18);
            this.datePickerOrderStatus.TabIndex = 10;
            this.datePickerOrderStatus.Text = "persianDateTimePicker1";
            this.datePickerOrderStatus.Value = ((FreeControls.PersianDate)(resources.GetObject("datePickerOrderStatus.Value")));
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.Enabled = false;
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Location = new System.Drawing.Point(465, 65);
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(132, 21);
            this.cmbOrderStatus.TabIndex = 8;
            // 
            // txtOrderCodeDate
            // 
            this.txtOrderCodeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtOrderCodeDate.Border.Class = "TextBoxBorder";
            this.txtOrderCodeDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderCodeDate.Enabled = false;
            this.txtOrderCodeDate.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtOrderCodeDate.FocusHighlightEnabled = true;
            this.txtOrderCodeDate.Location = new System.Drawing.Point(808, 35);
            this.txtOrderCodeDate.MaxLength = 7;
            this.txtOrderCodeDate.Name = "txtOrderCodeDate";
            this.txtOrderCodeDate.PreventEnterBeep = true;
            this.txtOrderCodeDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOrderCodeDate.Size = new System.Drawing.Size(55, 21);
            this.txtOrderCodeDate.TabIndex = 4;
            // 
            // txtOrderCodeCustomerIdBookingId
            // 
            this.txtOrderCodeCustomerIdBookingId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtOrderCodeCustomerIdBookingId.Border.Class = "TextBoxBorder";
            this.txtOrderCodeCustomerIdBookingId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderCodeCustomerIdBookingId.Enabled = false;
            this.txtOrderCodeCustomerIdBookingId.FocusHighlightColor = System.Drawing.SystemColors.Info;
            this.txtOrderCodeCustomerIdBookingId.FocusHighlightEnabled = true;
            this.txtOrderCodeCustomerIdBookingId.Location = new System.Drawing.Point(876, 35);
            this.txtOrderCodeCustomerIdBookingId.MaxLength = 6;
            this.txtOrderCodeCustomerIdBookingId.Name = "txtOrderCodeCustomerIdBookingId";
            this.txtOrderCodeCustomerIdBookingId.PreventEnterBeep = true;
            this.txtOrderCodeCustomerIdBookingId.ReadOnly = true;
            this.txtOrderCodeCustomerIdBookingId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOrderCodeCustomerIdBookingId.Size = new System.Drawing.Size(83, 21);
            this.txtOrderCodeCustomerIdBookingId.TabIndex = 5;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(866, 37);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(6, 16);
            this.labelX4.TabIndex = 79;
            this.labelX4.Text = "-";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // dgvCustomerSelectedPhotos
            // 
            this.dgvCustomerSelectedPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerSelectedPhotos.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvCustomerSelectedPhotos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dgvCustomerSelectedPhotos.Location = new System.Drawing.Point(3, 17);
            this.dgvCustomerSelectedPhotos.Name = "dgvCustomerSelectedPhotos";
            this.dgvCustomerSelectedPhotos.Size = new System.Drawing.Size(1166, 436);
            this.dgvCustomerSelectedPhotos.TabIndex = 0;
            this.dgvCustomerSelectedPhotos.Text = "superGridControl1";
            this.dgvCustomerSelectedPhotos.TouchEnabled = false;
            // 
            // FrmAddEditPreFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 592);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditPreFactor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده / ویرایش پیش فاکتور";
            this.panelEx1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCustomerInfo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerInfo;
        private System.Windows.Forms.RadioButton rbOrderStatus;
        private System.Windows.Forms.RadioButton rbOrderDate;
        private System.Windows.Forms.Button btnShowOrders;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.RadioButton rbOrderCode;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEnableOrderStatusDatePicker;
        private FreeControls.PersianDateTimePicker datePickerOrderDate;
        private FreeControls.PersianDateTimePicker datePickerOrderStatus;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderCodeDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderCodeCustomerIdBookingId;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvCustomerSelectedPhotos;
    }
}