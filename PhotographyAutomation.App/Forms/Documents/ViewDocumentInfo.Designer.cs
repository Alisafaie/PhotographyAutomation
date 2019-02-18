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
            ((System.ComponentModel.ISupportInitialize)(this.txtFinancialNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetDocumentInfo
            // 
            this.btnGetDocumentInfo.Location = new System.Drawing.Point(250, 114);
            this.btnGetDocumentInfo.Name = "btnGetDocumentInfo";
            this.btnGetDocumentInfo.Size = new System.Drawing.Size(137, 23);
            this.btnGetDocumentInfo.TabIndex = 0;
            this.btnGetDocumentInfo.Text = "Get Document Info";
            this.btnGetDocumentInfo.UseVisualStyleBackColor = true;
            this.btnGetDocumentInfo.Click += new System.EventHandler(this.btnGetDocumentInfo_Click);
            // 
            // btnCheckYear
            // 
            this.btnCheckYear.Location = new System.Drawing.Point(551, 41);
            this.btnCheckYear.Name = "btnCheckYear";
            this.btnCheckYear.Size = new System.Drawing.Size(201, 23);
            this.btnCheckYear.TabIndex = 1;
            this.btnCheckYear.Text = "بررسی وجود فولدر سال عکس برداری";
            this.btnCheckYear.UseVisualStyleBackColor = true;
            this.btnCheckYear.Click += new System.EventHandler(this.btnCheckYear_Click);
            // 
            // btnCheckMonth
            // 
            this.btnCheckMonth.Location = new System.Drawing.Point(551, 70);
            this.btnCheckMonth.Name = "btnCheckMonth";
            this.btnCheckMonth.Size = new System.Drawing.Size(201, 23);
            this.btnCheckMonth.TabIndex = 2;
            this.btnCheckMonth.Text = "بررسی وجود فولدر ماه عکس برداری";
            this.btnCheckMonth.UseVisualStyleBackColor = true;
            this.btnCheckMonth.Click += new System.EventHandler(this.btnCheckMonth_Click);
            // 
            // btnCheckFinancialFolder
            // 
            this.btnCheckFinancialFolder.Location = new System.Drawing.Point(551, 99);
            this.btnCheckFinancialFolder.Name = "btnCheckFinancialFolder";
            this.btnCheckFinancialFolder.Size = new System.Drawing.Size(201, 23);
            this.btnCheckFinancialFolder.TabIndex = 3;
            this.btnCheckFinancialFolder.Text = "بررسی وجود فولدر فاکتور مشتری";
            this.btnCheckFinancialFolder.UseVisualStyleBackColor = true;
            this.btnCheckFinancialFolder.Click += new System.EventHandler(this.btnCheckFinancialFolder_Click);
            // 
            // txtFinancialNumber
            // 
            this.txtFinancialNumber.Location = new System.Drawing.Point(460, 99);
            this.txtFinancialNumber.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtFinancialNumber.Name = "txtFinancialNumber";
            this.txtFinancialNumber.Size = new System.Drawing.Size(85, 21);
            this.txtFinancialNumber.TabIndex = 4;
            // 
            // ViewDocumentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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

        }

        #endregion

        private System.Windows.Forms.Button btnGetDocumentInfo;
        private System.Windows.Forms.Button btnCheckYear;
        private System.Windows.Forms.Button btnCheckMonth;
        private System.Windows.Forms.Button btnCheckFinancialFolder;
        private System.Windows.Forms.NumericUpDown txtFinancialNumber;
    }
}