namespace PhotographyAutomation.App.Forms.Orders
{
    partial class FrmUploadSelectedPhotos_Refactored
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUploadSelectedPhotos_Refactored));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrderCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ناممشتریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCustomerName = new System.Windows.Forms.ToolStripMenuItem();
            this.تاریخعکسبرداریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPhotographyDate = new System.Windows.Forms.ToolStripMenuItem();
            this.تعدادعکسهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTotalPhotos = new System.Windows.Forms.ToolStripMenuItem();
            this.وضعیتسفارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrderstatus = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnSyncFolders = new DevComponents.DotNetBar.ButtonX();
            this.btnChoosePhotoPath = new DevComponents.DotNetBar.ButtonX();
            this.btnUploadPhotos = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.checkBoxSelectNone = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.panelPreviewPictures = new DevComponents.DotNetBar.PanelEx();
            this.bgWorkerGetListOfFileStreams = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panelEx5.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1135, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
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
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "ارسال به سرور";
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(98, 20);
            this.toolStripMenuItem2.Text = "شناسه سفارش:";
            // 
            // toolStripMenuItemOrderCode
            // 
            this.toolStripMenuItemOrderCode.Name = "toolStripMenuItemOrderCode";
            this.toolStripMenuItemOrderCode.Size = new System.Drawing.Size(27, 20);
            this.toolStripMenuItemOrderCode.Text = "--";
            // 
            // ناممشتریToolStripMenuItem
            // 
            this.ناممشتریToolStripMenuItem.Name = "ناممشتریToolStripMenuItem";
            this.ناممشتریToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.ناممشتریToolStripMenuItem.Text = "نام مشتری :";
            // 
            // toolStripMenuItemCustomerName
            // 
            this.toolStripMenuItemCustomerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemCustomerName.Name = "toolStripMenuItemCustomerName";
            this.toolStripMenuItemCustomerName.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItemCustomerName.Text = "--";
            this.toolStripMenuItemCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // تاریخعکسبرداریToolStripMenuItem
            // 
            this.تاریخعکسبرداریToolStripMenuItem.Name = "تاریخعکسبرداریToolStripMenuItem";
            this.تاریخعکسبرداریToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.تاریخعکسبرداریToolStripMenuItem.Text = "تاریخ عکسبرداری:";
            // 
            // toolStripMenuItemPhotographyDate
            // 
            this.toolStripMenuItemPhotographyDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemPhotographyDate.Name = "toolStripMenuItemPhotographyDate";
            this.toolStripMenuItemPhotographyDate.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItemPhotographyDate.Text = "--";
            this.toolStripMenuItemPhotographyDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // تعدادعکسهاToolStripMenuItem
            // 
            this.تعدادعکسهاToolStripMenuItem.Name = "تعدادعکسهاToolStripMenuItem";
            this.تعدادعکسهاToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.تعدادعکسهاToolStripMenuItem.Text = "تعداد عکس ها";
            // 
            // toolStripMenuItemTotalPhotos
            // 
            this.toolStripMenuItemTotalPhotos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemTotalPhotos.Name = "toolStripMenuItemTotalPhotos";
            this.toolStripMenuItemTotalPhotos.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItemTotalPhotos.Text = "--";
            this.toolStripMenuItemTotalPhotos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // وضعیتسفارشToolStripMenuItem
            // 
            this.وضعیتسفارشToolStripMenuItem.Name = "وضعیتسفارشToolStripMenuItem";
            this.وضعیتسفارشToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.وضعیتسفارشToolStripMenuItem.Text = "وضعیت سفارش:";
            // 
            // toolStripMenuItemOrderstatus
            // 
            this.toolStripMenuItemOrderstatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemOrderstatus.Name = "toolStripMenuItemOrderstatus";
            this.toolStripMenuItemOrderstatus.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItemOrderstatus.Text = "--";
            this.toolStripMenuItemOrderstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnSyncFolders);
            this.panelEx1.Controls.Add(this.btnChoosePhotoPath);
            this.panelEx1.Controls.Add(this.btnUploadPhotos);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 687);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1135, 68);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 20;
            // 
            // btnSyncFolders
            // 
            this.btnSyncFolders.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSyncFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncFolders.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSyncFolders.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_adept_update_76851;
            this.btnSyncFolders.Location = new System.Drawing.Point(835, 20);
            this.btnSyncFolders.Name = "btnSyncFolders";
            this.btnSyncFolders.Size = new System.Drawing.Size(141, 36);
            this.btnSyncFolders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSyncFolders.TabIndex = 6;
            this.btnSyncFolders.Text = "همگام سازی";
            // 
            // btnChoosePhotoPath
            // 
            this.btnChoosePhotoPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChoosePhotoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoosePhotoPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChoosePhotoPath.HoverImage = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_open_add2_59918;
            this.btnChoosePhotoPath.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_closed_add2_59904;
            this.btnChoosePhotoPath.Location = new System.Drawing.Point(982, 20);
            this.btnChoosePhotoPath.Name = "btnChoosePhotoPath";
            this.btnChoosePhotoPath.Size = new System.Drawing.Size(141, 36);
            this.btnChoosePhotoPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChoosePhotoPath.TabIndex = 6;
            this.btnChoosePhotoPath.Text = "انتخاب عکس ها";
            // 
            // btnUploadPhotos
            // 
            this.btnUploadPhotos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUploadPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUploadPhotos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUploadPhotos.HoverImage = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_upload_66809__2_;
            this.btnUploadPhotos.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_closed_59915;
            this.btnUploadPhotos.Location = new System.Drawing.Point(12, 20);
            this.btnUploadPhotos.Name = "btnUploadPhotos";
            this.btnUploadPhotos.Size = new System.Drawing.Size(174, 36);
            this.btnUploadPhotos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUploadPhotos.TabIndex = 5;
            this.btnUploadPhotos.Text = "ارسال عکس ها به سرور";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.checkBoxSelectNone);
            this.panelEx2.Controls.Add(this.checkBoxSelectAll);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 657);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1135, 30);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 25;
            // 
            // checkBoxSelectNone
            // 
            this.checkBoxSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSelectNone.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxSelectNone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxSelectNone.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxSelectNone.Location = new System.Drawing.Point(899, 7);
            this.checkBoxSelectNone.Name = "checkBoxSelectNone";
            this.checkBoxSelectNone.Size = new System.Drawing.Size(98, 16);
            this.checkBoxSelectNone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxSelectNone.TabIndex = 6;
            this.checkBoxSelectNone.Text = "انتخاب هیچ کدام";
            this.checkBoxSelectNone.CheckedChanged += new System.EventHandler(this.checkBoxSelectNone_CheckedChanged);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSelectAll.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxSelectAll.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(1003, 7);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(120, 16);
            this.checkBoxSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxSelectAll.TabIndex = 5;
            this.checkBoxSelectAll.Text = "انتخاب همه عکس ها";
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.collapsibleSplitContainer1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 24);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1135, 633);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 29;
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
            this.collapsibleSplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1135, 633);
            this.collapsibleSplitContainer1.SplitterDistance = 343;
            this.collapsibleSplitContainer1.SplitterWidth = 20;
            this.collapsibleSplitContainer1.TabIndex = 5;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(343, 633);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 21;
            this.pictureBoxPreview.TabStop = false;
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
            this.panelEx5.Size = new System.Drawing.Size(772, 633);
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
            this.panelPreviewPictures.Size = new System.Drawing.Size(772, 633);
            this.panelPreviewPictures.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelPreviewPictures.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelPreviewPictures.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelPreviewPictures.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelPreviewPictures.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelPreviewPictures.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelPreviewPictures.Style.GradientAngle = 90;
            this.panelPreviewPictures.TabIndex = 29;
            // 
            // bgWorkerGetListOfFileStreams
            // 
            this.bgWorkerGetListOfFileStreams.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerGetListOfFileStreams_DoWork);
            this.bgWorkerGetListOfFileStreams.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerGetListOfFileStreams_RunWorkerCompleted);
            // 
            // FrmUploadSelectedPhotos_Refactored
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 755);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmUploadSelectedPhotos_Refactored";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ارسال عکس های انتخابی مشتری";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUploadSelectedPhotos_Refactored_FormClosed);
            this.Load += new System.EventHandler(this.FrmUploadSelectedPhotos_Refactored_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panelEx5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ناممشتریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCustomerName;
        private System.Windows.Forms.ToolStripMenuItem تاریخعکسبرداریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPhotographyDate;
        private System.Windows.Forms.ToolStripMenuItem تعدادعکسهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTotalPhotos;
        private System.Windows.Forms.ToolStripMenuItem وضعیتسفارشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrderstatus;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnSyncFolders;
        private DevComponents.DotNetBar.ButtonX btnChoosePhotoPath;
        private DevComponents.DotNetBar.ButtonX btnUploadPhotos;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxSelectNone;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxSelectAll;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private DevComponents.DotNetBar.PanelEx panelPreviewPictures;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrderCode;
        private System.ComponentModel.BackgroundWorker bgWorkerGetListOfFileStreams;
    }
}