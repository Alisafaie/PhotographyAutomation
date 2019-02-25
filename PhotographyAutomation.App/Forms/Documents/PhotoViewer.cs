using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Documents
{
    public partial class PhotoViewer : Form
    {
        public Image MyImage = null;
        public List<string> MyImageList = new List<string>();
        public List<string> OriginalPhotoList = new List<string>();
        public string SelectedImageFilePath;


        private int currentPhotoIndex = 0;
        private int lastPhotoIndex = 0;

        public PhotoViewer()
        {
            InitializeComponent();
        }

        private void PhotoViewer_Load(object sender, EventArgs e)
        {

            if (MyImageList.Count > 0 && !string.IsNullOrEmpty(SelectedImageFilePath.Trim()))
            {
                OriginalPhotoList = MyImageList;
                currentPhotoIndex = MyImageList.FindIndex(x => x.Contains(SelectedImageFilePath));
                lastPhotoIndex = (MyImageList.Count) - 1;

                byte[] originalPhotoBytes = SelectedImageFilePath.FileToByteArray();

                pictureBoxPreview.Image = originalPhotoBytes.GetPhotoAndRotateIt();
            }
        }

        private void btnFisrtPhoto_Click(object sender, EventArgs e)
        {
            string firstPhoto = MyImageList.FirstOrDefault();
            if (!string.IsNullOrEmpty(firstPhoto))
            {
                currentPhotoIndex = 0;
                byte[] firstPhotoBytes = firstPhoto.FileToByteArray();
                pictureBoxPreview.Image = firstPhotoBytes.GetPhotoAndRotateIt();
            }
        }

        private void btnLastPhoto_Click(object sender, EventArgs e)
        {
            string lastPhoto = MyImageList.LastOrDefault();
            if (!string.IsNullOrEmpty(lastPhoto))
            {
                currentPhotoIndex = MyImageList.Count - 1;
                byte[] lastPhotoBytes = lastPhoto.FileToByteArray();
                pictureBoxPreview.Image = lastPhotoBytes.GetPhotoAndRotateIt();
            }
        }

        private void btnPreviousPhoto_Click(object sender, EventArgs e)
        {
            if (currentPhotoIndex > 0)
            {
                var index = MyImageList[currentPhotoIndex - 1];
                currentPhotoIndex--;

                byte[] originalPhotoBytes = index.FileToByteArray();

                pictureBoxPreview.Image = originalPhotoBytes.GetPhotoAndRotateIt();
            }
        }

        private void btnNextPhoto_Click(object sender, EventArgs e)
        {
            if (currentPhotoIndex + 1 >= MyImageList.Count)
            {
                return;
            }
            var index = MyImageList[currentPhotoIndex + 1];
            currentPhotoIndex++;

            byte[] originalPhotoBytes = index.FileToByteArray();

            pictureBoxPreview.Image = originalPhotoBytes.GetPhotoAndRotateIt();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MyImageList.Count >= 1)
            {
                MyImageList.RemoveAt(currentPhotoIndex);
                lastPhotoIndex = MyImageList.Count - 1;
                pictureBoxPreview.Image = null;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            MyImageList = OriginalPhotoList;
            currentPhotoIndex = 0;
            lastPhotoIndex = OriginalPhotoList.Count - 1;
            var image = MyImageList.FirstOrDefault();
            if (image != null)
            {
                byte[] photo = image.FileToByteArray();
                pictureBoxPreview.Image = photo.GetPhotoAndRotateIt();
            }
        }
    }
}

