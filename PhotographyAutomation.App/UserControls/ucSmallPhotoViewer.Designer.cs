namespace PhotographyAutomation.App.UserControls
{
    partial class ucSmallPhotoViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.label5 = new System.Windows.Forms.Label();
            this.circularProgressPictures = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.pictureBoxIsAccepted = new System.Windows.Forms.PictureBox();
            this.btnMagnifyPhoto = new System.Windows.Forms.Button();
            this.lblPhotoName = new System.Windows.Forms.Label();
            this.lblTotalPhotos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentPhoto = new System.Windows.Forms.Label();
            this.btnNextPhoto = new System.Windows.Forms.Button();
            this.btnPreviousPhoto = new System.Windows.Forms.Button();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIsAccepted)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.circularProgressPictures);
            this.panelEx1.Controls.Add(this.pictureBoxIsAccepted);
            this.panelEx1.Controls.Add(this.btnMagnifyPhoto);
            this.panelEx1.Controls.Add(this.lblPhotoName);
            this.panelEx1.Controls.Add(this.lblTotalPhotos);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.lblCurrentPhoto);
            this.panelEx1.Controls.Add(this.btnNextPhoto);
            this.panelEx1.Controls.Add(this.btnPreviousPhoto);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 297);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(272, 54);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(114, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "از";
            // 
            // circularProgressPictures
            // 
            this.circularProgressPictures.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.circularProgressPictures.AntiAlias = false;
            // 
            // 
            // 
            this.circularProgressPictures.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgressPictures.Location = new System.Drawing.Point(5, 9);
            this.circularProgressPictures.Name = "circularProgressPictures";
            this.circularProgressPictures.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.circularProgressPictures.Size = new System.Drawing.Size(20, 20);
            this.circularProgressPictures.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgressPictures.TabIndex = 7;
            this.circularProgressPictures.TabStop = false;
            // 
            // pictureBoxIsAccepted
            // 
            this.pictureBoxIsAccepted.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxIsAccepted.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_flickr_317744;
            this.pictureBoxIsAccepted.Location = new System.Drawing.Point(2, 35);
            this.pictureBoxIsAccepted.Name = "pictureBoxIsAccepted";
            this.pictureBoxIsAccepted.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxIsAccepted.TabIndex = 150;
            this.pictureBoxIsAccepted.TabStop = false;
            // 
            // btnMagnifyPhoto
            // 
            this.btnMagnifyPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMagnifyPhoto.BackColor = System.Drawing.Color.Transparent;
            this.btnMagnifyPhoto.FlatAppearance.BorderSize = 0;
            this.btnMagnifyPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMagnifyPhoto.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_magnifier_1814075;
            this.btnMagnifyPhoto.Location = new System.Drawing.Point(247, 31);
            this.btnMagnifyPhoto.Name = "btnMagnifyPhoto";
            this.btnMagnifyPhoto.Size = new System.Drawing.Size(20, 20);
            this.btnMagnifyPhoto.TabIndex = 0;
            this.btnMagnifyPhoto.TabStop = false;
            this.btnMagnifyPhoto.UseVisualStyleBackColor = false;
            this.btnMagnifyPhoto.Click += new System.EventHandler(this.btnMagnifyPhoto_Click);
            // 
            // lblPhotoName
            // 
            this.lblPhotoName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhotoName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblPhotoName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPhotoName.Location = new System.Drawing.Point(41, 35);
            this.lblPhotoName.Name = "lblPhotoName";
            this.lblPhotoName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPhotoName.Size = new System.Drawing.Size(190, 16);
            this.lblPhotoName.TabIndex = 8;
            this.lblPhotoName.Text = "---";
            this.lblPhotoName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalPhotos
            // 
            this.lblTotalPhotos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPhotos.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPhotos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblTotalPhotos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotalPhotos.Location = new System.Drawing.Point(85, 13);
            this.lblTotalPhotos.Name = "lblTotalPhotos";
            this.lblTotalPhotos.Size = new System.Drawing.Size(31, 13);
            this.lblTotalPhotos.TabIndex = 5;
            this.lblTotalPhotos.Text = "---";
            this.lblTotalPhotos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(151, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "عکس";
            // 
            // lblCurrentPhoto
            // 
            this.lblCurrentPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentPhoto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblCurrentPhoto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCurrentPhoto.Location = new System.Drawing.Point(124, 13);
            this.lblCurrentPhoto.Name = "lblCurrentPhoto";
            this.lblCurrentPhoto.Size = new System.Drawing.Size(31, 13);
            this.lblCurrentPhoto.TabIndex = 3;
            this.lblCurrentPhoto.Text = "1";
            this.lblCurrentPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextPhoto
            // 
            this.btnNextPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNextPhoto.BackColor = System.Drawing.Color.Transparent;
            this.btnNextPhoto.FlatAppearance.BorderSize = 0;
            this.btnNextPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPhoto.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_previous_7769;
            this.btnNextPhoto.Location = new System.Drawing.Point(41, 4);
            this.btnNextPhoto.Name = "btnNextPhoto";
            this.btnNextPhoto.Size = new System.Drawing.Size(30, 30);
            this.btnNextPhoto.TabIndex = 6;
            this.btnNextPhoto.TabStop = false;
            this.btnNextPhoto.UseVisualStyleBackColor = false;
            this.btnNextPhoto.Click += new System.EventHandler(this.btnNextPhoto_Click);
            // 
            // btnPreviousPhoto
            // 
            this.btnPreviousPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreviousPhoto.BackColor = System.Drawing.Color.Transparent;
            this.btnPreviousPhoto.FlatAppearance.BorderSize = 0;
            this.btnPreviousPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPhoto.Image = global::PhotographyAutomation.App.Properties.Resources.iconfinder_next_7752;
            this.btnPreviousPhoto.Location = new System.Drawing.Point(201, 4);
            this.btnPreviousPhoto.Name = "btnPreviousPhoto";
            this.btnPreviousPhoto.Size = new System.Drawing.Size(30, 30);
            this.btnPreviousPhoto.TabIndex = 1;
            this.btnPreviousPhoto.TabStop = false;
            this.btnPreviousPhoto.UseVisualStyleBackColor = false;
            this.btnPreviousPhoto.Click += new System.EventHandler(this.btnPreviousPhoto_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.pictureBox1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(272, 297);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 297);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucSmallPhotoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.MinimumSize = new System.Drawing.Size(272, 351);
            this.Name = "ucSmallPhotoViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(272, 351);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIsAccepted)).EndInit();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgressPictures;
        private System.Windows.Forms.PictureBox pictureBoxIsAccepted;
        private System.Windows.Forms.Button btnMagnifyPhoto;
        private System.Windows.Forms.Label lblPhotoName;
        private System.Windows.Forms.Label lblTotalPhotos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentPhoto;
        private System.Windows.Forms.Button btnNextPhoto;
        private System.Windows.Forms.Button btnPreviousPhoto;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
