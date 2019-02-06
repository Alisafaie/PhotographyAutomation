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
            // ViewDocumentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetDocumentInfo);
            this.Name = "ViewDocumentInfo";
            this.Text = "ViewDocumentInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetDocumentInfo;
    }
}