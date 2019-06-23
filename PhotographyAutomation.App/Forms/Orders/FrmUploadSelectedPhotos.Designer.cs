namespace PhotographyAutomation.App.Forms.Orders
{
    partial class FrmUploadSelectedPhotos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUploadSelectedPhotos));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnChoosePhotoPath = new DevComponents.DotNetBar.ButtonX();
            this.btnUploadPhotos = new DevComponents.DotNetBar.ButtonX();
            this.toolTipPictureBoxPreview = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.panelPreviewPictures = new DevComponents.DotNetBar.PanelEx();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.checkBoxSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelPicturePreviewName = new DevComponents.DotNetBar.LabelX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrderCode = new System.Windows.Forms.ToolStripTextBox();
            this.ناممشتریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCustomerName = new System.Windows.Forms.ToolStripMenuItem();
            this.تاریخعکسبرداریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPhotographyDate = new System.Windows.Forms.ToolStripMenuItem();
            this.تعدادعکسهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTotalPhotos = new System.Windows.Forms.ToolStripMenuItem();
            this.وضعیتسفارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrderstatus = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.panelEx1.Controls.Add(this.btnChoosePhotoPath);
            this.panelEx1.Controls.Add(this.btnUploadPhotos);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 532);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1074, 68);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnChoosePhotoPath
            // 
            this.btnChoosePhotoPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChoosePhotoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoosePhotoPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChoosePhotoPath.HoverImage = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_open_add2_59918;
            this.btnChoosePhotoPath.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_closed_add2_59904;
            this.btnChoosePhotoPath.Location = new System.Drawing.Point(921, 20);
            this.btnChoosePhotoPath.Name = "btnChoosePhotoPath";
            this.btnChoosePhotoPath.Size = new System.Drawing.Size(141, 36);
            this.btnChoosePhotoPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChoosePhotoPath.TabIndex = 6;
            this.btnChoosePhotoPath.Text = "انتخاب عکس ها";
            this.btnChoosePhotoPath.Click += new System.EventHandler(this.btnChoosePhotoPath_Click);
            // 
            // btnUploadPhotos
            // 
            this.btnUploadPhotos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUploadPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadPhotos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUploadPhotos.HoverImage = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_upload_66809__2_;
            this.btnUploadPhotos.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_closed_59915;
            this.btnUploadPhotos.Location = new System.Drawing.Point(741, 20);
            this.btnUploadPhotos.Name = "btnUploadPhotos";
            this.btnUploadPhotos.Size = new System.Drawing.Size(174, 36);
            this.btnUploadPhotos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUploadPhotos.TabIndex = 5;
            this.btnUploadPhotos.Text = "ارسال عکس ها به سرور";
            this.btnUploadPhotos.Click += new System.EventHandler(this.btnUploadPhotos_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(273, 507);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 21;
            this.pictureBoxPreview.TabStop = false;
            this.toolTipPictureBoxPreview.SetToolTip(this.pictureBoxPreview, "برای نمایش عکس در اندازه بزرگتر روی عکس دابل کلیک کنید.");
            this.pictureBoxPreview.DoubleClick += new System.EventHandler(this.pictureBoxPreview_DoubleClick);
            // 
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.collapsibleSplitContainer1.Name = "collapsibleSplitContainer1";
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.pictureBoxPreview);
            this.collapsibleSplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.panelEx5);
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.panelEx4);
            this.collapsibleSplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1074, 507);
            this.collapsibleSplitContainer1.SplitterDistance = 273;
            this.collapsibleSplitContainer1.SplitterWidth = 20;
            this.collapsibleSplitContainer1.TabIndex = 4;
            // 
            // panelEx5
            // 
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.Controls.Add(this.panelPreviewPictures);
            this.panelEx5.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx5.Location = new System.Drawing.Point(0, 0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(781, 474);
            this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx5.Style.GradientAngle = 90;
            this.panelEx5.TabIndex = 4;
            this.panelEx5.Text = "panelEx5";
            // 
            // panelPreviewPictures
            // 
            this.panelPreviewPictures.AutoScroll = true;
            this.panelPreviewPictures.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelPreviewPictures.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelPreviewPictures.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelPreviewPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreviewPictures.Location = new System.Drawing.Point(0, 0);
            this.panelPreviewPictures.Name = "panelPreviewPictures";
            this.panelPreviewPictures.Size = new System.Drawing.Size(781, 474);
            this.panelPreviewPictures.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelPreviewPictures.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelPreviewPictures.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelPreviewPictures.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelPreviewPictures.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelPreviewPictures.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelPreviewPictures.Style.GradientAngle = 90;
            this.panelPreviewPictures.TabIndex = 29;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.checkBoxSelectAll);
            this.panelEx4.Controls.Add(this.labelPicturePreviewName);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx4.Location = new System.Drawing.Point(0, 474);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(781, 33);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 0;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(658, 9);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(120, 16);
            this.checkBoxSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxSelectAll.TabIndex = 3;
            this.checkBoxSelectAll.Text = "انتخاب همه عکس ها";
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // labelPicturePreviewName
            // 
            this.labelPicturePreviewName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPicturePreviewName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPicturePreviewName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelPicturePreviewName.Location = new System.Drawing.Point(0, 0);
            this.labelPicturePreviewName.Name = "labelPicturePreviewName";
            this.labelPicturePreviewName.PaddingLeft = 10;
            this.labelPicturePreviewName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPicturePreviewName.Size = new System.Drawing.Size(298, 33);
            this.labelPicturePreviewName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.labelPicturePreviewName.TabIndex = 2;
            this.labelPicturePreviewName.WordWrap = true;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.collapsibleSplitContainer1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 25);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1074, 507);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 19;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.fileToolStripMenuItem.Text = "&عکس ها";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "انتخاب مسیر";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "ارسال به سرور";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "خروج";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItemOrderCode,
            this.ناممشتریToolStripMenuItem,
            this.toolStripMenuItemCustomerName,
            this.تاریخعکسبرداریToolStripMenuItem,
            this.toolStripMenuItemPhotographyDate,
            this.تعدادعکسهاToolStripMenuItem,
            this.toolStripMenuItemTotalPhotos,
            this.وضعیتسفارشToolStripMenuItem,
            this.toolStripMenuItemOrderstatus});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 25);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(98, 21);
            this.toolStripMenuItem2.Text = "شناسه سفارش:";
            // 
            // toolStripMenuItemOrderCode
            // 
            this.toolStripMenuItemOrderCode.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStripMenuItemOrderCode.Name = "toolStripMenuItemOrderCode";
            this.toolStripMenuItemOrderCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenuItemOrderCode.Size = new System.Drawing.Size(100, 21);
            // 
            // ناممشتریToolStripMenuItem
            // 
            this.ناممشتریToolStripMenuItem.Name = "ناممشتریToolStripMenuItem";
            this.ناممشتریToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.ناممشتریToolStripMenuItem.Text = "نام مشتری :";
            // 
            // toolStripMenuItemCustomerName
            // 
            this.toolStripMenuItemCustomerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemCustomerName.Name = "toolStripMenuItemCustomerName";
            this.toolStripMenuItemCustomerName.Size = new System.Drawing.Size(29, 21);
            this.toolStripMenuItemCustomerName.Text = "--";
            this.toolStripMenuItemCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // تاریخعکسبرداریToolStripMenuItem
            // 
            this.تاریخعکسبرداریToolStripMenuItem.Name = "تاریخعکسبرداریToolStripMenuItem";
            this.تاریخعکسبرداریToolStripMenuItem.Size = new System.Drawing.Size(103, 21);
            this.تاریخعکسبرداریToolStripMenuItem.Text = "تاریخ عکسبرداری:";
            // 
            // toolStripMenuItemPhotographyDate
            // 
            this.toolStripMenuItemPhotographyDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemPhotographyDate.Name = "toolStripMenuItemPhotographyDate";
            this.toolStripMenuItemPhotographyDate.Size = new System.Drawing.Size(29, 21);
            this.toolStripMenuItemPhotographyDate.Text = "--";
            this.toolStripMenuItemPhotographyDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // تعدادعکسهاToolStripMenuItem
            // 
            this.تعدادعکسهاToolStripMenuItem.Name = "تعدادعکسهاToolStripMenuItem";
            this.تعدادعکسهاToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.تعدادعکسهاToolStripMenuItem.Text = "تعداد عکس ها";
            // 
            // toolStripMenuItemTotalPhotos
            // 
            this.toolStripMenuItemTotalPhotos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemTotalPhotos.Name = "toolStripMenuItemTotalPhotos";
            this.toolStripMenuItemTotalPhotos.Size = new System.Drawing.Size(29, 21);
            this.toolStripMenuItemTotalPhotos.Text = "--";
            this.toolStripMenuItemTotalPhotos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // وضعیتسفارشToolStripMenuItem
            // 
            this.وضعیتسفارشToolStripMenuItem.Name = "وضعیتسفارشToolStripMenuItem";
            this.وضعیتسفارشToolStripMenuItem.Size = new System.Drawing.Size(97, 21);
            this.وضعیتسفارشToolStripMenuItem.Text = "وضعیت سفارش:";
            // 
            // toolStripMenuItemOrderstatus
            // 
            this.toolStripMenuItemOrderstatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemOrderstatus.Name = "toolStripMenuItemOrderstatus";
            this.toolStripMenuItemOrderstatus.Size = new System.Drawing.Size(29, 21);
            this.toolStripMenuItemOrderstatus.Text = "--";
            this.toolStripMenuItemOrderstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmUploadSelectedPhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 600);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUploadSelectedPhotos";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ارسال عکس های انتخاب شده مشتری به سرور";
            this.Load += new System.EventHandler(this.FrmUploadPhotos_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnUploadPhotos;
        private System.Windows.Forms.ToolTip toolTipPictureBoxPreview;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.LabelX labelPicturePreviewName;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnChoosePhotoPath;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ناممشتریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCustomerName;
        private System.Windows.Forms.ToolStripMenuItem تاریخعکسبرداریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPhotographyDate;
        private System.Windows.Forms.ToolStripMenuItem تعدادعکسهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTotalPhotos;
        private System.Windows.Forms.ToolStripMenuItem وضعیتسفارشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrderstatus;
        private System.Windows.Forms.ToolStripTextBox toolStripMenuItemOrderCode;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private DevComponents.DotNetBar.PanelEx panelPreviewPictures;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxSelectAll;
    }
}