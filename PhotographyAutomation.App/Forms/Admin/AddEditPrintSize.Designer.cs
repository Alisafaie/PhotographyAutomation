namespace PhotographyAutomation.App.Forms.Admin
{
    partial class AddEditPrintSize
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
            this.doubleInputHeight = new DevComponents.Editors.DoubleInput();
            this.doubleInputWidth = new DevComponents.Editors.DoubleInput();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // doubleInputHeight
            // 
            this.doubleInputHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.doubleInputHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInputHeight.Enabled = false;
            this.doubleInputHeight.Increment = 1D;
            this.doubleInputHeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.doubleInputHeight.Location = new System.Drawing.Point(534, 139);
            this.doubleInputHeight.MinValue = 0D;
            this.doubleInputHeight.Name = "doubleInputHeight";
            this.doubleInputHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputHeight.Size = new System.Drawing.Size(49, 21);
            this.doubleInputHeight.TabIndex = 2;
            this.doubleInputHeight.WatermarkText = "(cm)طول";
            // 
            // doubleInputWidth
            // 
            this.doubleInputWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.doubleInputWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInputWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInputWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInputWidth.Enabled = false;
            this.doubleInputWidth.Increment = 1D;
            this.doubleInputWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.doubleInputWidth.Location = new System.Drawing.Point(458, 139);
            this.doubleInputWidth.MinValue = 0D;
            this.doubleInputWidth.Name = "doubleInputWidth";
            this.doubleInputWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doubleInputWidth.Size = new System.Drawing.Size(54, 21);
            this.doubleInputWidth.TabIndex = 1;
            this.doubleInputWidth.WatermarkText = "(cm)عرض";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(515, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "x";
            // 
            // AddEditPrintSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.doubleInputHeight);
            this.Controls.Add(this.doubleInputWidth);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "AddEditPrintSize";
            this.Text = "AddEditPrintSize";
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInputWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.Editors.DoubleInput doubleInputHeight;
        private DevComponents.Editors.DoubleInput doubleInputWidth;
        private System.Windows.Forms.Label label8;
    }
}