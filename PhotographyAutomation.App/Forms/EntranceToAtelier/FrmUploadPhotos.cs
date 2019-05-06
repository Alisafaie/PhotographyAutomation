﻿using PhotographyAutomation.App.Forms.Photos;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
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

namespace PhotographyAutomation.App.Forms.EntranceToAtelier
{
    public partial class FrmUploadPhotos : Form
    {

        private readonly List<string> _fileNamesList = new List<string>();
        private readonly List<string> _fileNamesAndPathsList = new List<string>();

        private int _locX = 20;
        private int _locY = 10;
        private int _sizeWidth = 128;
        private int _sizeHeight = 128;

        public string OrderCode = string.Empty;
        public int BookingId = 0;
        public int CustomerId = 0;
        public int OrderId = 0;


        public FrmUploadPhotos()
        {
            InitializeComponent();
        }

        private void FrmUploadPhotos_Load(object sender, EventArgs e)
        {
            _locX = 20;
            _locY = 10;
            _sizeWidth = 128;
            _sizeHeight = 128;
            txtOrderCode.Text = OrderCode;
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChoosePhotoPath_Click(null, null);
        }
        private void btnChoosePhotoPath_Click(object sender, EventArgs e)
        {
            var openFileDialogBrowsePictures = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "*.jpg",
                Filter = @"Image Files(*.JPG; *.JPEG)|*.JPG; *.JPEG",
                //Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*
                Multiselect = true,
                RestoreDirectory = true,
                SupportMultiDottedExtensions = true,
                Title = @"دریافت عکس ها",
                //ReadOnlyChecked = true,
                //ShowReadOnly = true
            };

            if (openFileDialogBrowsePictures.ShowDialog() != DialogResult.OK) return;

            panelPreviewPictures.Controls.Clear();
            var locnewX = _locX;
            // ReSharper disable once UnusedVariable
            var locnewY = _locY;


            for (var i = 0; i < openFileDialogBrowsePictures.SafeFileNames.Length; i++)
            {
                try
                {
                    _fileNamesAndPathsList.Add(openFileDialogBrowsePictures.FileNames[i]);
                    _fileNamesList.Add(openFileDialogBrowsePictures.SafeFileNames[i]);
                    locnewX = ShowImagePreview(locnewX, openFileDialogBrowsePictures, i);
                }
                catch (Exception exception)
                {
                    RtlMessageBox.Show(exception.Message);
                }
            }
            txtOrderCode.Focus();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUploadPhotos_Click(null, null);
        }
        private void btnUploadPhotos_Click(object sender, EventArgs e)
        {
            //string uploadPath = string.Empty;
            var filesToUpload = new List<string>();
            var fileNamesUpload = new List<string>();

            if (!CheckInputs()) return;

            foreach (var checkbox in panelPreviewPictures.Controls.OfType<DevComponents.DotNetBar.Controls.CheckBoxX>())
            {
                if (checkbox.Checked && checkbox.CheckState == CheckState.Checked)
                {
                    filesToUpload.Add(checkbox.AccessibleDescription);
                    fileNamesUpload.Add(checkbox.AccessibleName);
                }
            }
            try
            {
                using (var db = new UnitOfWork())
                {
                    var pc = new PersianCalendar();
                    var year = pc.GetYear(DateTime.Now);
                    var month = pc.GetMonth(DateTime.Now);

                    string yearFolderPath;
                    string monthFolderPath;
                    string orderFolderPath = null;

                    var checkYearFolder = db.PhotoRepository.CheckPhotoYearFolderIsCreatedReturnsPath(year);
                    if (checkYearFolder == null)
                    {
                        yearFolderPath = db.PhotoRepository.CreateYearFolderOfPhotos(year); //1398
                        if (yearFolderPath != null)
                        {
                            RtlMessageBox.Show("فولدر سال جاری ایجاد شد.");
                        }
                    }
                    yearFolderPath = checkYearFolder;

                    var checkMonthFolder = db.PhotoRepository.CheckPhotoMonthFolderIsCreatedReturnsPath(month);
                    if (checkMonthFolder == null)
                    {
                        monthFolderPath = db.PhotoRepository.CreateMonthFolderOfPhotos(month, year);
                        if (monthFolderPath != null)
                        {
                            RtlMessageBox.Show("فولدر ماه عکس برداری ایجاد شد.");
                        }
                    }
                    monthFolderPath = checkMonthFolder;

                    var checkCustomerOrderFolder = db.PhotoRepository.CheckCustomerOrderFolderIsCreatedReturnsPath(OrderCode);
                    if (checkCustomerOrderFolder == null)
                    {
                        orderFolderPath =
                            db.PhotoRepository.CreateCustomerFinancialFolder(OrderCode, month);
                        if (orderFolderPath != null)
                        {
                            RtlMessageBox.Show("فولدر عکس های مشتری ایجاد شد.");
                        }
                    }
                    else
                    {
                        DialogResult dialogResultReplaceFiles = RtlMessageBox.Show(
                            "فولدر فاکتور مشتری در سیستم وجود دارد." +
                            Environment.NewLine +
                            "آیا می خواهید عکس های قبلی پاک شده و عکس های جدید جایگزین شود؟" +
                            Environment.NewLine +
                            "در صورت انتخاب خیر عکس های فعلی در کنار عکس های قبلی قرار می کیرند."
                            , "", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (dialogResultReplaceFiles == DialogResult.Yes)
                        {

                        }
                        else
                        {

                        }
                    }
                    var orderFolderStreamId = db.PhotoRepository.GetOrderFolderStreamId(OrderCode);

                    var parentPathName = OrderCode;


                    var totalFilesUploaded = 0;
                    var errorInUpload = new List<string>();
                    var orderFilesList = new List<TblOrderFiles>();

                    for (var i = 0; i < filesToUpload.Count; i++)
                    {
                        //var fileUploadResult = db.PhotoRepository.CreateFileTableFile(
                        //    fileNamesUpload[i], parentPathName, 4, filesToUpload[i]);
                        string fileName = OrderCode + "--" + fileNamesUpload[i];

                        var fileUploadResult2 =
                            db.PhotoRepository.CreateFileTableFileReturnCreateFileViewModel(
                            fileName, parentPathName, 4, filesToUpload[i]);

                        if (fileUploadResult2 != null)
                        {
                            var orderFile = new TblOrderFiles
                            {
                                FileName = fileUploadResult2.name,
                                OrderId = OrderId,
                                PathLocator = fileUploadResult2.path_locator_str,
                                StreamId = new Guid(fileUploadResult2.streamId)
                            };

                            orderFilesList.Add(orderFile);
                            db.OrderFilesGenericRepository.Insert(orderFile);
                            if (db.Save() > 0)
                                totalFilesUploaded++;
                        }
                        else
                        {
                            RtlMessageBox.Show(
                                "ارسال فایل " + fileNamesUpload[i] + " با خطا مواجه شد.",
                                "خطا در ارسال فایل", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            errorInUpload.Add(fileNamesUpload[i]);

                            var fileError = new TblFilesError
                            {
                                OrderId = OrderId,
                                BookingId = BookingId,
                                CustomerId = CustomerId,
                                DateTime = DateTime.Now,
                                FileName = fileNamesUpload[i],
                                OrderCode = OrderCode,
                                ErrorMessage = null,
                                ErrorInId = null,
                                Submitter = null
                            };
                            db.FilesErrorGenericRepository.Insert(fileError);
                        }
                    }

                    var orderStatusList = db.OrderStatusGenericRepository.Get();
                    var order = db.OrderGenericRepository.Get().FirstOrDefault(x => x.Id == OrderId);

                    if (totalFilesUploaded == filesToUpload.Count)
                    {
                    retry:

                        if (order != null)
                        {
                            order.OrderStatusId = orderStatusList.First(x => x.Code == 20).Id;
                            order.OrderFolderPathLocator = orderFolderPath;
                            order.OrderFolderParentPathLocator = monthFolderPath;
                            order.TotalFiles = totalFilesUploaded;
                            order.OrderFolderStreamId = orderFolderStreamId;

                            db.OrderGenericRepository.Update(order);
                            db.Save();
                        }
                        else
                        {
                            var dialogResult = RtlMessageBox.Show(
                                "اطلاعات سفارش فابل دریافت نمی باشد.",
                                "عدم امکان دریافت اطلاعات سفارش",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                            if (dialogResult == DialogResult.Retry)
                            {
                                goto retry;
                            }
                        }

                        RtlMessageBox.Show("تمامی فایل ها با موفقیت ارسال گردید.", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        var sb = new StringBuilder();
                        sb.Append("ارسال فایل (های) زیر با مشکل مواجه شد.");
                        sb.Append("---------------------------------------\n");
                        sb.Append("\n");

                        foreach (var item in errorInUpload)
                        {
                            sb.Append(item);
                            sb.Append("\n");
                        }

                        if (order != null)
                        {
                            order.OrderStatusId = orderStatusList.First(x => x.Code == 140).Id;
                            db.OrderGenericRepository.Update(order);
                        }

                        db.Save();
                        RtlMessageBox.Show(sb.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //var dr = RtlMessageBox.Show("آیا بازهم عکسی برای ارسال دارید؟", "",
                    //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if (dr == DialogResult.Yes)
                    //{

                    //    txtOrderCode.Text = string.Empty;
                    //    _fileNamesAndPathsList.Clear();
                    //    _fileNamesList.Clear();
                    //    panelPreviewPictures.Controls.Clear();
                    //}
                    //else
                    DialogResult = DialogResult.OK;
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

        private bool CheckInputs()
        {
            if (string.IsNullOrEmpty(txtOrderCode.Text.Trim()))
            {
                RtlMessageBox.Show("مقداری برای شماره فاکتور مشتری وارد نشده است.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtOrderCode.Focus();
                return false;
            }

            if (_fileNamesAndPathsList.Count == 0)
            {
                RtlMessageBox.Show("عکسی برای ارسال انتخاب نشده است.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
                    checkBox.CheckState = CheckState.Unchecked;
                }
            }

            checkBoxSelectAll.Checked = false;
            checkBoxSelectAll.CheckState = CheckState.Unchecked;
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


            Label pictureBoxLabel = new Label
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
                CheckState = CheckState.Checked,
                Checked = true,
                Tag = imageName,
                Text = "",
                AutoSize = false,
                Size = new Size(17, 17),
                MaximumSize = new Size(13, 13),
                Parent = pictureBoxControl,
                AccessibleDescription = imageFullName,
                AccessibleName = imageName
            };


            pictureBoxControl.MouseClick += control_MouseClick;
            pictureBoxControl.DoubleClick += pictureBox_DoubleClick;

            panelPreviewPictures.Controls.Add(pictureBoxLabel);
            panelPreviewPictures.Controls.Add(pictureBoxCheckBox);
            panelPreviewPictures.Controls.Add(pictureBoxControl);

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

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked && checkBoxSelectAll.CheckState == CheckState.Checked)
            {
                foreach (var checkBox in panelPreviewPictures.Controls.OfType<DevComponents.DotNetBar.Controls.CheckBoxX>())
                {
                    checkBox.CheckState = CheckState.Checked;
                }
            }
        }
    }
}