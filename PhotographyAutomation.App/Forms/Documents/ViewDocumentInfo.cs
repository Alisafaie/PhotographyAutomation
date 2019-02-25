﻿using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Documents
{
    public partial class ViewDocumentInfo : Form
    {
        private readonly List<string> _fileNamesList = new List<string>();
        private readonly List<string> _fileNamesAndPathsList = new List<string>();

        private int _locX = 20;
        private int _locY = 10;
        private int _sizeWidth = 128;
        private int _sizeHeight = 128;

        public ViewDocumentInfo()
        {
            InitializeComponent();
        }

        private void ViewDocumentInfo_Load(object sender, EventArgs e)
        {
            _locX = 20;
            _locY = 10;
            _sizeWidth = 128;
            _sizeHeight = 128;
        }

        private void btnGetDocumentInfo_Click(object sender, EventArgs e)
        {
            //using (var db = new UnitOfWork())
            //{
            //    //Guid guid=new Guid("1E305159-242A-E911-AACE-742F68C6E6E6");

            //    var guid = Guid.Parse("1E305159-242A-E911-AACE-742F68C6E6E6");

            //    var document = db.DocumentRepository.GetDocumentByGuid(guid);
            //}
        }





        //نمایش لیست فایل ها در لیست باکس
        //تبدیل کردن محتوای فایل به باینری
        //ارسال به سرو
        //تایید ثبت در سرو
        //ثبت مشخصات فایل ثبت شده در جدول مخصوص

        private void btnBrowsePictureFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogBrowsePictures = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "*.jpg",
                Filter = @"JPEG Files|*.jpg|PSD Files|*.psd",
                Multiselect = true,
                RestoreDirectory = true,
                SupportMultiDottedExtensions = true,
                Title = @"دریافت عکس ها",
                //ReadOnlyChecked = true,
                //ShowReadOnly = true
            };

            if (openFileDialogBrowsePictures.ShowDialog() == DialogResult.OK)
            {
                listBoxPictures.Items.Clear();
                panelPreviewPictures.Controls.Clear();

                int locnewX = _locX;
                // ReSharper disable once UnusedVariable
                int locnewY = _locY;


                for (int i = 0; i < openFileDialogBrowsePictures.SafeFileNames.Length; i++)
                {
                    try
                    {
                        listBoxPictures.Items.Add(openFileDialogBrowsePictures.FileNames[i]);
                        _fileNamesAndPathsList.Add(openFileDialogBrowsePictures.FileNames[i]);
                        _fileNamesList.Add(openFileDialogBrowsePictures.SafeFileNames[i]);


                        locnewX = ShowImagePreview(locnewX, openFileDialogBrowsePictures, i);
                    }
                    catch (Exception exception)
                    {
                        RtlMessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private int ShowImagePreview(int locnewX, OpenFileDialog openFileDialogBrowsePictures, int i)
        {
            int locnewY;
            if (locnewX >= panelPreviewPictures.Width - _sizeWidth - 10)
            {
                locnewX = _locX;
                _locY = _locY + _sizeHeight + 30;
                locnewY = _locY;
            }
            else
            {
                locnewY = _locY;
            }

            LoadImagestoPanel(openFileDialogBrowsePictures.SafeFileNames[i],
                openFileDialogBrowsePictures.FileNames[i], locnewX, locnewY);

            // ReSharper disable once RedundantAssignment
            locnewY = _locY + _sizeHeight + 10;
            locnewX = locnewX + _sizeWidth + 10;
            return locnewX;
        }

        private void LoadImagestoPanel(string imageName, string imageFullName, int newLocX, int newLocY)
        {

            PictureBox pictureBoxControl = new PictureBox
            {
                BackColor = SystemColors.Control,
                Location = new Point(newLocX, newLocY + 10),
                Size = new Size(_sizeWidth, _sizeHeight),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = imageName,
                AccessibleDescription = imageFullName
            };

            byte[] originalPhotoBytes = imageFullName.FileToByteArray();
            pictureBoxControl.Image = originalPhotoBytes.GetPhotoAndRotateIt();





            Label picturBoxLabel = new Label
            {
                BackColor = SystemColors.Control,
                ForeColor = SystemColors.ControlText,
                Font = SystemFonts.DefaultFont,
                Location = new Point(newLocX + 5, newLocY + 140),
                Text = imageName,
                AutoSize = true,
                MaximumSize = new Size(_sizeWidth, 30),
                ClientSize = new Size(_sizeWidth, 30)
            };

            var pictureBoxCheckBox = new DevComponents.DotNetBar.Controls.CheckBoxX
            {
                BackColor = Color.Transparent,
                Font = SystemFonts.DefaultFont,
                Location = new Point(newLocX + 3, newLocY + 13),
                CheckState = CheckState.Unchecked,
                Checked = false,
                Tag = imageName,
                Text = "",
                AutoSize = false,
                Size = new Size(17, 17),
                MaximumSize = new Size(13, 13),
                Parent = pictureBoxControl
            };


            pictureBoxControl.MouseClick += control_MouseClick;
            pictureBoxControl.DoubleClick += pictureBox_DoubleClick;

            panelPreviewPictures.Controls.Add(picturBoxLabel);
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
            Control control = (Control)sender;

            foreach (var checkBox in panelPreviewPictures.Controls.OfType<DevComponents.DotNetBar.Controls.CheckBoxX>())
            {
                if (control.Tag == checkBox.Tag)
                {
                    checkBox.CheckState = CheckState.Checked;
                }
            }
        }



        private void btnSendPhotos_Click(object sender, EventArgs e)
        {
            //string uploadPath = string.Empty;
            int customerFinancialNumber = int.Parse(txtFinancialNumber.Text);

            if (listBoxPictures.Items.Count == 0)
            {
                RtlMessageBox.Show("عکسی برای ارسال انتخاب نشده است.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnBrowsePictureFolder.Focus();
                return;
            }
            if (customerFinancialNumber <= 0)
            {
                RtlMessageBox.Show("مقدار فاکترو مشتری صحیح نمی باشد.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtFinancialNumber.Focus();
                return;
            }

            try
            {
                using (var db = new UnitOfWork())
                {
                    PersianCalendar pc = new PersianCalendar();
                    int year = pc.GetYear(DateTime.Now);
                    int month = pc.GetMonth(DateTime.Now);

                    var resultCheckPhotoYearFolder =
                        db.DocumentRepository.CheckPhotoYearFolderIsCreatedReturnsPath(year);

                    if (resultCheckPhotoYearFolder == null)
                    {
                        var resultCreateYearFolder = db.DocumentRepository.CreateYearFolderOfPhotos(year);
                        if (resultCreateYearFolder != null)
                        {
                            RtlMessageBox.Show("فولدر سال جاری ایجاد شد.");
                        }
                    }


                    var resultCheckPhotoMonthFolder =
                        db.DocumentRepository.CheckPhotoMonthFolderIsCreatedReturnsPath(month);

                    if (resultCheckPhotoMonthFolder == null)
                    {
                        var resultCreateYearFolder = db.DocumentRepository.CreateMonthFolderOfPhotos(month, year);
                        if (resultCreateYearFolder != null)
                        {
                            RtlMessageBox.Show("فولدر ماه عکس برداری ایجاد شد.");
                        }
                    }




                    var resultCheckCustomerFinancialFolder =
                        db.DocumentRepository.CheckCustomerFinancialFolderIsCreatedReturnsPath(
                            (int)txtFinancialNumber.Value);
                    if (resultCheckCustomerFinancialFolder != null)
                    {
                        MessageBox.Show(@"فولدر فاکتور مشتری در سیستم وجود دارد.");
                    }
                    if (resultCheckCustomerFinancialFolder == null)
                    {
                        var resultCreateYearFolder =
                            db.DocumentRepository.CreateCustomerFinancialFolder((int) txtFinancialNumber.Value, month);
                        if (resultCreateYearFolder != null)
                        {
                            RtlMessageBox.Show("فولدر فاکتور مشتری ایجاد شد.");
                            //uploadPath = resultCreateYearFolder;
                        }
                    }

                    string parentPathName = txtFinancialNumber.Text;


                    int resultUploads = 0;
                    List<string> errorInUpload = new List<string>();
                    
                    for (int i = 0; i < listBoxPictures.Items.Count; i++)
                    {
                        var fileUploadResult = db.DocumentRepository.CreateFileTableFile(
                            _fileNamesList[i], parentPathName, 4, _fileNamesAndPathsList[i]);

                        if (fileUploadResult)
                            resultUploads++;
                        else
                        {
                            RtlMessageBox.Show("ارسال فایل " + _fileNamesList[i] + " با خطا مواجه شد.",
                                "خطا در ارسال فایل", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            errorInUpload.Add(_fileNamesList[i]);
                        }
                    }

                    if (resultUploads == listBoxPictures.Items.Count)
                    {
                        RtlMessageBox.Show("تمامی فایل ها با موفقیت ارسال گردید.", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("ارسال فایل (های) زیر با مشکل مواجه شد.");
                        sb.Append("---------------------------------------\n");
                        sb.Append("\n");

                        foreach (var item in errorInUpload)
                        {
                            sb.Append(item);
                            sb.Append("\n");
                        }

                        RtlMessageBox.Show(sb.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DialogResult dr = RtlMessageBox.Show("آیا بازهم عکسی برای ارسال دارید؟", "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        listBoxPictures.Items.Clear();
                        txtFinancialNumber.Value = 0;
                        _fileNamesAndPathsList.Clear();
                        _fileNamesList.Clear();
                    }
                    else
                    {
                        Close();
                    }
                }

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
            }

        }

        private void pictureBoxPreview_DoubleClick(object sender, EventArgs e)
        {
            PhotoViewer pv = new PhotoViewer
            {
                MyImageList = _fileNamesAndPathsList,
                SelectedImageFilePath = pictureBoxPreview.Tag.ToString()
            };

            pv.ShowDialog();
        }










        //private void LoadControls()
        //{
        //    int locnewX = _locX;
        //    int locnewY = _locY;

        //    foreach (Control p in panelPreviewPictures.Controls)
        //    {
        //        if (locnewX >= panelPreviewPictures.Width - _sizeWidth - 10)
        //        {
        //            locnewX = _locX;
        //            _locY = _locY + _sizeHeight + 30;
        //            locnewY = _locY;
        //        }
        //        else
        //        {

        //            locnewY = _locY;
        //        }
        //        p.Location = new Point(locnewX, locnewY);
        //        p.Size = new System.Drawing.Size(_sizeWidth, _sizeHeight);

        //        locnewY = _locY + _sizeHeight + 10;
        //        locnewX = locnewX + _sizeWidth + 10;
        //    }
        //}


    }
}
