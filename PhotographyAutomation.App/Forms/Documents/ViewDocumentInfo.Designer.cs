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
            this.btnCheckYear = new System.Windows.Forms.Button();
            this.btnCheckMonth = new System.Windows.Forms.Button();
            this.btnCheckFinancialFolder = new System.Windows.Forms.Button();
            this.txtFinancialNumber = new System.Windows.Forms.NumericUpDown();
            this.btnSendPhotos = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnBrowsePictureFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialogBrowsePictures = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinancialNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetDocumentInfo
            // 
            this.btnGetDocumentInfo.Enabled = false;
            this.btnGetDocumentInfo.Location = new System.Drawing.Point(76, 99);
            this.btnGetDocumentInfo.Name = "btnGetDocumentInfo";
            this.btnGetDocumentInfo.Size = new System.Drawing.Size(137, 23);
            this.btnGetDocumentInfo.TabIndex = 7;
            this.btnGetDocumentInfo.Text = "Get Document Info";
            this.btnGetDocumentInfo.UseVisualStyleBackColor = true;
            this.btnGetDocumentInfo.Click += new System.EventHandler(this.btnGetDocumentInfo_Click);
            // 
            // btnCheckYear
            // 
            this.btnCheckYear.Enabled = false;
            this.btnCheckYear.Location = new System.Drawing.Point(12, 12);
            this.btnCheckYear.Name = "btnCheckYear";
            this.btnCheckYear.Size = new System.Drawing.Size(201, 23);
            this.btnCheckYear.TabIndex = 4;
            this.btnCheckYear.Text = "بررسی وجود فولدر سال عکس برداری";
            this.btnCheckYear.UseVisualStyleBackColor = true;
            this.btnCheckYear.Click += new System.EventHandler(this.btnCheckYear_Click);
            // 
            // btnCheckMonth
            // 
            this.btnCheckMonth.Enabled = false;
            this.btnCheckMonth.Location = new System.Drawing.Point(12, 41);
            this.btnCheckMonth.Name = "btnCheckMonth";
            this.btnCheckMonth.Size = new System.Drawing.Size(201, 23);
            this.btnCheckMonth.TabIndex = 5;
            this.btnCheckMonth.Text = "بررسی وجود فولدر ماه عکس برداری";
            this.btnCheckMonth.UseVisualStyleBackColor = true;
            this.btnCheckMonth.Click += new System.EventHandler(this.btnCheckMonth_Click);
            // 
            // btnCheckFinancialFolder
            // 
            this.btnCheckFinancialFolder.Enabled = false;
            this.btnCheckFinancialFolder.Location = new System.Drawing.Point(12, 70);
            this.btnCheckFinancialFolder.Name = "btnCheckFinancialFolder";
            this.btnCheckFinancialFolder.Size = new System.Drawing.Size(201, 23);
            this.btnCheckFinancialFolder.TabIndex = 6;
            this.btnCheckFinancialFolder.Text = "بررسی وجود فولدر فاکتور مشتری";
            this.btnCheckFinancialFolder.UseVisualStyleBackColor = true;
            this.btnCheckFinancialFolder.Click += new System.EventHandler(this.btnCheckFinancialFolder_Click);
            // 
            // txtFinancialNumber
            // 
            this.txtFinancialNumber.Location = new System.Drawing.Point(569, 337);
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
            this.btnSendPhotos.Location = new System.Drawing.Point(569, 364);
            this.btnSendPhotos.Name = "btnSendPhotos";
            this.btnSendPhotos.Size = new System.Drawing.Size(219, 23);
            this.btnSendPhotos.TabIndex = 3;
            this.btnSendPhotos.Text = "ارسال فایل ها";
            this.btnSendPhotos.UseVisualStyleBackColor = true;
            this.btnSendPhotos.Click += new System.EventHandler(this.btnSendPhotos_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(569, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(219, 290);
            this.listBox1.TabIndex = 1;
            // 
            // btnBrowsePictureFolder
            // 
            this.btnBrowsePictureFolder.Location = new System.Drawing.Point(644, 12);
            this.btnBrowsePictureFolder.Name = "btnBrowsePictureFolder";
            this.btnBrowsePictureFolder.Size = new System.Drawing.Size(144, 23);
            this.btnBrowsePictureFolder.TabIndex = 0;
            this.btnBrowsePictureFolder.Text = "مسیر عکس ها";
            this.btnBrowsePictureFolder.UseVisualStyleBackColor = true;
            this.btnBrowsePictureFolder.Click += new System.EventHandler(this.btnBrowsePictureFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(682, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "شماره فاکتور مشتری";
            // 
            // openFileDialogBrowsePictures
            // 
            this.openFileDialogBrowsePictures.FileName = "openFileDialog1";
            // 
            // ViewDocumentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowsePictureFolder);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSendPhotos);
            this.Controls.Add(this.txtFinancialNumber);
            this.Controls.Add(this.btnCheckFinancialFolder);
            this.Controls.Add(this.btnCheckMonth);
            this.Controls.Add(this.btnCheckYear);
            this.Controls.Add(this.btnGetDocumentInfo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "ViewDocumentInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ViewDocumentInfo";
            ((System.ComponentModel.ISupportInitialize)(this.txtFinancialNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetDocumentInfo;
        private System.Windows.Forms.Button btnCheckYear;
        private System.Windows.Forms.Button btnCheckMonth;
        private System.Windows.Forms.Button btnCheckFinancialFolder;
        private System.Windows.Forms.NumericUpDown txtFinancialNumber;
        private System.Windows.Forms.Button btnSendPhotos;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnBrowsePictureFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialogBrowsePictures;
    }
}