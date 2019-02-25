namespace PhotographyAutomation.App.Forms.Documents
{
    partial class PhotoViewer
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
            this.navigationBar1 = new DevComponents.DotNetBar.NavigationBar();
            this.btnReload = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnLastPhoto = new DevComponents.DotNetBar.ButtonItem();
            this.btnNextPhoto = new DevComponents.DotNetBar.ButtonItem();
            this.btnPreviousPhoto = new DevComponents.DotNetBar.ButtonItem();
            this.btnFisrtPhoto = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.navigationBar1)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // navigationBar1
            // 
            this.navigationBar1.BackgroundStyle.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.navigationBar1.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationBar1.BackgroundStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationBar1.ItemPaddingBottom = 2;
            this.navigationBar1.ItemPaddingTop = 2;
            this.navigationBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnReload,
            this.btnAdd,
            this.btnDelete,
            this.btnLastPhoto,
            this.btnNextPhoto,
            this.btnPreviousPhoto,
            this.btnFisrtPhoto});
            this.navigationBar1.Location = new System.Drawing.Point(0, 0);
            this.navigationBar1.Name = "navigationBar1";
            this.navigationBar1.Size = new System.Drawing.Size(922, 28);
            this.navigationBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationBar1.TabIndex = 18;
            this.navigationBar1.Text = "navigationBar1";
            // 
            // btnReload
            // 
            this.btnReload.Checked = true;
            this.btnReload.Image = global::PhotographyAutomation.App.Properties.Resources._1371476394_refresh_red;
            this.btnReload.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnReload.Name = "btnReload";
            this.btnReload.OptionGroup = "navBar";
            this.btnReload.Text = "buttonItem3";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::PhotographyAutomation.App.Properties.Resources._132699___create;
            this.btnAdd.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OptionGroup = "navBar";
            this.btnAdd.Text = "buttonItem4";
            // 
            // btnDelete
            // 
            this.btnDelete.Checked = true;
            this.btnDelete.Image = global::PhotographyAutomation.App.Properties.Resources._132776___brick_cancel_closed_entry_forbid_forbidden_glossy;
            this.btnDelete.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OptionGroup = "navBar";
            this.btnDelete.Text = "buttonItem1";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLastPhoto
            // 
            this.btnLastPhoto.Checked = true;
            this.btnLastPhoto.Image = global::PhotographyAutomation.App.Properties.Resources._132760___arrow_back_first_glossy_previous_record_track;
            this.btnLastPhoto.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnLastPhoto.Name = "btnLastPhoto";
            this.btnLastPhoto.OptionGroup = "navBar";
            this.btnLastPhoto.Text = "buttonItem2";
            this.btnLastPhoto.Click += new System.EventHandler(this.btnLastPhoto_Click);
            // 
            // btnNextPhoto
            // 
            this.btnNextPhoto.Checked = true;
            this.btnNextPhoto.Image = global::PhotographyAutomation.App.Properties.Resources._132623___playback;
            this.btnNextPhoto.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnNextPhoto.Name = "btnNextPhoto";
            this.btnNextPhoto.OptionGroup = "navBar";
            this.btnNextPhoto.Text = "buttonItem5";
            this.btnNextPhoto.Click += new System.EventHandler(this.btnNextPhoto_Click);
            // 
            // btnPreviousPhoto
            // 
            this.btnPreviousPhoto.Checked = true;
            this.btnPreviousPhoto.Image = global::PhotographyAutomation.App.Properties.Resources._132594___play;
            this.btnPreviousPhoto.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnPreviousPhoto.Name = "btnPreviousPhoto";
            this.btnPreviousPhoto.OptionGroup = "navBar";
            this.btnPreviousPhoto.Text = "buttonItem6";
            this.btnPreviousPhoto.Click += new System.EventHandler(this.btnPreviousPhoto_Click);
            // 
            // btnFisrtPhoto
            // 
            this.btnFisrtPhoto.Checked = true;
            this.btnFisrtPhoto.Image = global::PhotographyAutomation.App.Properties.Resources._132658___arrow_audio_go_last_last_page_last_record_last_tra;
            this.btnFisrtPhoto.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnFisrtPhoto.Name = "btnFisrtPhoto";
            this.btnFisrtPhoto.OptionGroup = "navBar";
            this.btnFisrtPhoto.Text = "buttonItem7";
            this.btnFisrtPhoto.Click += new System.EventHandler(this.btnFisrtPhoto_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.pictureBoxPreview);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 28);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(922, 602);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 19;
            this.panelEx2.Text = "panelEx2";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(922, 602);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 1;
            this.pictureBoxPreview.TabStop = false;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 630);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(922, 70);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // PhotoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 700);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.navigationBar1);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "PhotoViewer";
            this.Text = " ";
            this.Load += new System.EventHandler(this.PhotoViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navigationBar1)).EndInit();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.NavigationBar navigationBar1;
        private DevComponents.DotNetBar.ButtonItem btnReload;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnLastPhoto;
        private DevComponents.DotNetBar.ButtonItem btnNextPhoto;
        private DevComponents.DotNetBar.ButtonItem btnPreviousPhoto;
        private DevComponents.DotNetBar.ButtonItem btnFisrtPhoto;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private DevComponents.DotNetBar.PanelEx panelEx1;
    }
}