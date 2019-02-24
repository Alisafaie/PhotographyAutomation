using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Documents
{
    public partial class PhotoViewer : Form
    {
        public Image MyImage = null;
        public List<string> ImagesList = new List<string>();
        public string SelectedImageFilePath;
        public PhotoViewer()
        {
            InitializeComponent();
        }

        private void PhotoViewer_Load(object sender, EventArgs e)
        {

            if (ImagesList.Count > 0 && !string.IsNullOrEmpty(SelectedImageFilePath.Trim()))
            {
                byte[] originalPhotoBytes = SelectedImageFilePath.FileToByteArray();

                pictureBoxPreview.Image = originalPhotoBytes.GetPhotoAndRotateIt();
            }
        }
    }
}
