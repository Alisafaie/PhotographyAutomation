namespace PhotographyAutomation.App.Forms.Documents
{
    partial class ViewDocumentInfo
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
            this.btnGetDocumentInfo = new System.Windows.Forms.Button();
            this.txtFinancialNumber = new System.Windows.Forms.NumericUpDown();
            this.btnSendPhotos = new System.Windows.Forms.Button();
            this.listBoxPictures = new System.Windows.Forms.ListBox();
            this.btnBrowsePictureFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPreviewPictures = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.labelPicturePreviewName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinancialNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetDocumentInfo
            // 
            this.btnGetDocumentInfo.Enabled = false;
            this.btnGetDocumentInfo.Location = new System.Drawing.Point(12, 12);
            this.btnGetDocumentInfo.Name = "btnGetDocumentInfo";
            this.btnGetDocumentInfo.Size = new System.Drawing.Size(137, 23);
            this.btnGetDocumentInfo.TabIndex = 7;
            this.btnGetDocumentInfo.Text = "Get Document Info";
            this.btnGetDocumentInfo.UseVisualStyleBackColor = true;
            this.btnGetDocumentInfo.Click += new System.EventHandler(this.btnGetDocumentInfo_Click);
            // 
            // txtFinancialNumber
            // 
            this.txtFinancialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinancialNumber.Location = new System.Drawing.Point(1034, 337);
            this.txtFinancialNumber.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtFinancialNumber.Name = "txtFinancialNumber";
            this.txtFinancialNumber.Size = new System.Drawing.Size(85, 21);
            this.txtFinancialNumber.TabIndex = 2;
            // 
            // btnSendPhotos
            // 
            this.btnSendPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendPhotos.Location = new System.Drawing.Point(1034, 364);
            this.btnSendPhotos.Name = "btnSendPhotos";
            this.btnSendPhotos.Size = new System.Drawing.Size(219, 23);
            this.btnSendPhotos.TabIndex = 3;
            this.btnSendPhotos.Text = "ارسال فایل ها";
            this.btnSendPhotos.UseVisualStyleBackColor = true;
            this.btnSendPhotos.Click += new System.EventHandler(this.btnSendPhotos_Click);
            // 
            // listBoxPictures
            // 
            this.listBoxPictures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPictures.FormattingEnabled = true;
            this.listBoxPictures.Location = new System.Drawing.Point(1034, 41);
            this.listBoxPictures.Name = "listBoxPictures";
            this.listBoxPictures.Size = new System.Drawing.Size(219, 290);
            this.listBoxPictures.TabIndex = 1;
            // 
            // btnBrowsePictureFolder
            // 
            this.btnBrowsePictureFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePictureFolder.Location = new System.Drawing.Point(1150, 12);
            this.btnBrowsePictureFolder.Name = "btnBrowsePictureFolder";
            this.btnBrowsePictureFolder.Size = new System.Drawing.Size(103, 23);
            this.btnBrowsePictureFolder.TabIndex = 0;
            this.btnBrowsePictureFolder.Text = "مسیر عکس ها";
            this.btnBrowsePictureFolder.UseVisualStyleBackColor = true;
            this.btnBrowsePictureFolder.Click += new System.EventHandler(this.btnBrowsePictureFolder_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1147, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "شماره فاکتور مشتری";
            // 
            // panelPreviewPictures
            // 
            this.panelPreviewPictures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreviewPictures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPreviewPictures.Location = new System.Drawing.Point(12, 41);
            this.panelPreviewPictures.Name = "panelPreviewPictures";
            this.panelPreviewPictures.Size = new System.Drawing.Size(689, 504);
            this.panelPreviewPictures.TabIndex = 9;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPreview.Location = new System.Drawing.Point(707, 41);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(321, 290);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 10;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.DoubleClick += new System.EventHandler(this.pictureBoxPreview_DoubleClick);
            // 
            // labelPicturePreviewName
            // 
            this.labelPicturePreviewName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPicturePreviewName.Location = new System.Drawing.Point(707, 339);
            this.labelPicturePreviewName.Name = "labelPicturePreviewName";
            this.labelPicturePreviewName.Size = new System.Drawing.Size(321, 48);
            this.labelPicturePreviewName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(758, 22);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(270, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "برای نمایش عکس در اندازه بزرگتر روی آن دوبار کلیک کنید.";
            // 
            // ViewDocumentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 569);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPicturePreviewName);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.panelPreviewPictures);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowsePictureFolder);
            this.Controls.Add(this.listBoxPictures);
            this.Controls.Add(this.btnSendPhotos);
            this.Controls.Add(this.txtFinancialNumber);
            this.Controls.Add(this.btnGetDocumentInfo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "ViewDocumentInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ViewDocumentInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewDocumentInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFinancialNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetDocumentInfo;
        private System.Windows.Forms.NumericUpDown txtFinancialNumber;
        private System.Windows.Forms.Button btnSendPhotos;
        private System.Windows.Forms.ListBox listBoxPictures;
        private System.Windows.Forms.Button btnBrowsePictureFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPreviewPictures;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label labelPicturePreviewName;
        private System.Windows.Forms.Label label2;
    }
}