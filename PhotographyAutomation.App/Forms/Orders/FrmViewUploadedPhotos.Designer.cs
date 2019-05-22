﻿namespace PhotographyAutomation.App.Forms.Orders
{
    partial class FrmViewUploadedPhotos
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
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnChoosePhotoPath = new DevComponents.DotNetBar.ButtonX();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtOrderCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolTipPictureBoxPreview = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.panelPreviewPictures = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.checkBoxSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.labelPicturePreviewName = new DevComponents.DotNetBar.LabelX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx3.SuspendLayout();
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
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 615);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1034, 68);
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
            this.btnChoosePhotoPath.HoverImage = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_edit_85073;
            this.btnChoosePhotoPath.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_folder_edit_85073;
            this.btnChoosePhotoPath.Location = new System.Drawing.Point(934, 20);
            this.btnChoosePhotoPath.Name = "btnChoosePhotoPath";
            this.btnChoosePhotoPath.Size = new System.Drawing.Size(88, 36);
            this.btnChoosePhotoPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChoosePhotoPath.TabIndex = 6;
            this.btnChoosePhotoPath.Text = "ویرایش";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.txtOrderCode});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 25);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 21);
            this.toolStripMenuItem1.Text = "شماره فاکتور مشتری :";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.ReadOnly = true;
            this.txtOrderCode.Size = new System.Drawing.Size(100, 21);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(253, 557);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 0;
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
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.panelPreviewPictures);
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.panelEx2);
            this.collapsibleSplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.panelEx5);
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.panelEx4);
            this.collapsibleSplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1034, 590);
            this.collapsibleSplitContainer1.SplitterDistance = 761;
            this.collapsibleSplitContainer1.SplitterWidth = 20;
            this.collapsibleSplitContainer1.TabIndex = 4;
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
            this.panelPreviewPictures.Size = new System.Drawing.Size(761, 557);
            this.panelPreviewPictures.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelPreviewPictures.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelPreviewPictures.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelPreviewPictures.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelPreviewPictures.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelPreviewPictures.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelPreviewPictures.Style.GradientAngle = 90;
            this.panelPreviewPictures.TabIndex = 11;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.checkBoxSelectAll);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 557);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(761, 33);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 4;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(673, 9);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(76, 16);
            this.checkBoxSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxSelectAll.TabIndex = 0;
            this.checkBoxSelectAll.Text = "انتخاب همه";
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // panelEx5
            // 
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.Controls.Add(this.pictureBoxPreview);
            this.panelEx5.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx5.Location = new System.Drawing.Point(0, 0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(253, 557);
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
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.labelPicturePreviewName);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx4.Location = new System.Drawing.Point(0, 557);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(253, 33);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 0;
            this.panelEx4.Text = "panelEx4";
            // 
            // labelPicturePreviewName
            // 
            // 
            // 
            // 
            this.labelPicturePreviewName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPicturePreviewName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPicturePreviewName.Location = new System.Drawing.Point(0, 0);
            this.labelPicturePreviewName.Name = "labelPicturePreviewName";
            this.labelPicturePreviewName.PaddingLeft = 10;
            this.labelPicturePreviewName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPicturePreviewName.Size = new System.Drawing.Size(253, 33);
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
            this.panelEx3.Size = new System.Drawing.Size(1034, 590);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 19;
            // 
            // FrmViewUploadedPhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 683);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmViewUploadedPhotos";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده و ویرایش عکس های آپلود شده";
            this.Load += new System.EventHandler(this.FrmUploadPhotos_Load);
            this.panelEx1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx5.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox txtOrderCode;
        private System.Windows.Forms.ToolTip toolTipPictureBoxPreview;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private DevComponents.DotNetBar.PanelEx panelPreviewPictures;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxSelectAll;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.LabelX labelPicturePreviewName;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnChoosePhotoPath;
    }
}