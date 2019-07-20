using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using PhotographyAutomation.App.Forms.Photos;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Orders
{
    public partial class FrmUploadSelectedPhotos_Refactored : Form
    {
        #region Variables

        private readonly List<string> _fileNamesList = new List<string>();
        private readonly List<string> _fileNamesAndPathsList = new List<string>();
        private readonly List<string> _filesStreamId = new List<string>();

        private int _locX = 20;
        private int _locY = 10;
        private int _sizeWidth = 128;
        private int _sizeHeight = 128;

        public string OrderCode = string.Empty;
        public int BookingId = 0;
        public int CustomerId = 0;
        public int OrderId = 0;


        public string CustomerName;
        public string PhotographyDate;
        public int TotalPhotos;
        public string OrderStatus;

        #endregion
        public FrmUploadSelectedPhotos_Refactored()
        {
            InitializeComponent();
        }

        private void FrmUploadSelectedPhotos_Refactored_Load(object sender, EventArgs e)
        {
            btnUploadPhotos.Enabled = !bgWorkerGetListOfFileStreams.IsBusy;

            SetToolStripMenuItem();

            ShowImages();

            FocusOnFirstImage();

        }
        private void FrmUploadSelectedPhotos_Refactored_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void bgWorkerGetListOfFileStreams_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void bgWorkerGetListOfFileStreams_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnUploadPhotos.Enabled = !bgWorkerGetListOfFileStreams.IsBusy;
        }


        private void SetToolStripMenuItem()
        {
            toolStripMenuItemOrderCode.Text = OrderCode;
            toolStripMenuItemOrderCode.Text = OrderCode;
            toolStripMenuItemCustomerName.Text = CustomerName;
            toolStripMenuItemOrderstatus.Text = OrderStatus;
            toolStripMenuItemPhotographyDate.Text = PhotographyDate;
        }


        private void ShowImages()
        {
            panelPreviewPictures.Controls.Clear();
            var locnewX = _locX;
            //var locnewY = _locY;

            for (var i = 0; i < ListOfPhotos.Count; i++)
            {
                try
                {
                    locnewX = ShowImagePreview(locnewX, ListOfPhotos, i);
                }
                catch (Exception exception)
                {
                    RtlMessageBox.Show(exception.Message);
                }
            }
        }

        private int ShowImagePreview(int locnewX, IReadOnlyList<PhotoViewModel> photoList, int i)
        {
            int locnewY;
            if (locnewX >= panelPreviewPictures.Width - _sizeWidth - 10)
            {
                locnewX = _locX;
                _locY = _locY + _sizeHeight + 40;
                locnewY = _locY;
            }
            else
            {
                locnewY = _locY;
            }

            LoadImagestoPanel(photoList[i].Name, photoList[i].FileStream, locnewX, locnewY, i);

            // ReSharper disable once RedundantAssignment
            locnewY = _locY + _sizeHeight + 10;
            locnewX = locnewX + _sizeWidth + 10;
            return locnewX;
        }
        private void LoadImagestoPanel(string imageName, byte[] imageBytes, int newLocX, int newLocY, int i)
        {
            var pictureBoxControl = new PictureBox
            {
                BackColor = SystemColors.Control,
                Location = new Point(newLocX, newLocY + 10),
                Size = new Size(_sizeWidth, _sizeHeight),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = imageName,
                AccessibleDescription = imageName,
                Image = imageBytes.GetPhotoAndRotateIt(),
                Name = "pb_" + imageName,
                Anchor = AnchorStyles.Left
            };

            var pictureBoxCheckBox = new CheckBoxX
            {
                BackColor = Color.Transparent,
                Font = SystemFonts.DefaultFont,
                Location = new Point(newLocX, newLocY + 138),
                CheckState = CheckState.Unchecked,
                Checked = false,
                Tag = imageName,
                Text = imageName,
                AutoSize = false,
                CheckBoxPosition = eCheckBoxPosition.Right,
                MaximumSize = new Size(128, 32),
                ClientSize = new Size(128, 32),
                Parent = pictureBoxControl,
                AccessibleDescription = ListOfPhotos[i].FullUncPath,
                AccessibleName = imageName,
                Name = "chk_" + imageName,
                Style = eDotNetBarStyle.StyleManagerControlled,
                Anchor = AnchorStyles.Left
            };
            
            pictureBoxControl.MouseClick += control_MouseClick;
            pictureBoxControl.DoubleClick += pictureBox_DoubleClick;
            
            panelPreviewPictures.Controls.Add(pictureBoxCheckBox);
            panelPreviewPictures.Controls.Add(pictureBoxControl);
        }
        private void control_MouseClick(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            PictureBox pic = (PictureBox)control;
            pictureBoxPreview.Image = pic.Image;


            // File Location
            pictureBoxPreview.Tag = pic.AccessibleDescription;

            //File Name
            labelPicturePreviewName.Text = pic.Tag.ToString();
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            var control = (Control)sender;

            foreach (var checkBox in panelPreviewPictures.Controls.OfType<CheckBoxX>())
            {
                if (control.Tag == checkBox.Tag)
                {
                    checkBox.CheckState = CheckState.Unchecked;
                }
            }

            checkBoxSelectAll.Checked = false;
            checkBoxSelectAll.CheckState = CheckState.Unchecked;
        }
        private void pictureBoxPreview_DoubleClick(object sender, EventArgs e)
        {
            FrmPhotoViewer pv = new FrmPhotoViewer
            {
                MyImageList = _fileNamesAndPathsList,
                SelectedImageFilePath = pictureBoxPreview.Tag.ToString()
            };

            pv.ShowDialog();
        }


        private void FocusOnFirstImage()
        {
            panelPreviewPictures.Focus();

            if (panelPreviewPictures.Controls.Count <= 0) return;

            var control = panelPreviewPictures
                .Controls
                .Find("chk_" + ListOfPhotos[0].Name, true);

            if (control[0].GetType() != typeof(CheckBoxX)) return;

            var x = (CheckBoxX)control[0];
            panelPreviewPictures.Focus();

            var loc = x.PointToScreen(Point.Empty);

            MouseSilulator.MoveCursorToPoint(loc.X + 6, loc.Y + 6);
            MouseSilulator.DoMouseClick();
            MouseSilulator.DoMouseClick();
        }


        

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked && checkBoxSelectAll.CheckState == CheckState.Checked)
            {
                foreach (Control control in panelPreviewPictures.Controls)
                {
                    if (control is CheckBoxX checkBox)
                    {
                        checkBox.Checked = true;
                        checkBox.CheckState = CheckState.Checked;
                    }
                }
            }
        }

        private void checkBoxSelectNone_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in panelPreviewPictures.Controls)
            {
                if (control is CheckBoxX checkBox)
                {
                    checkBox.Checked = false;
                    checkBox.CheckState = CheckState.Unchecked;
                }
            }
        }
    }
}
