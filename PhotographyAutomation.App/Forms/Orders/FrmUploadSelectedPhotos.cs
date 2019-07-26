using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using PhotographyAutomation.App.Forms.Factors;
using PhotographyAutomation.App.Forms.Photos;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Photo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Orders
{
    public partial class FrmUploadSelectedPhotos : Form
    {

        #region Variables


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


        public string CustomerName;
        public string PhotographyDate;
        public int TotalPhotos;
        public string OrderStatus;
        //public string ParentPathLocator;


        public List<PhotoViewModel> ListOfPhotos;


        #endregion Variables


        #region Form Events

        public FrmUploadSelectedPhotos()
        {
            InitializeComponent();
        }

        private void FrmUploadPhotos_Load(object sender, EventArgs e)
        {
            _locX = 20;
            _locY = 10;
            _sizeWidth = 128;
            _sizeHeight = 128;

            SetToolStripMenuItem();

            ShowImages();

            FocusOnFirstImage();
        }

        private void SetToolStripMenuItem()
        {
            toolStripMenuItemOrderCode.Text = OrderCode;
            toolStripMenuItemOrderCode.Text = OrderCode;
            toolStripMenuItemCustomerName.Text = CustomerName;
            toolStripMenuItemOrderstatus.Text = OrderStatus;
            toolStripMenuItemPhotographyDate.Text = PhotographyDate;
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

        private void FrmUploadSelectedPhotos_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        #endregion


        #region Top Menu

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChoosePhotoPath_Click(null, null);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUploadPhotos_Click(null, null);
        }

        #endregion


        #region Buttons

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

            for (var i = 0; i < openFileDialogBrowsePictures.SafeFileNames.Length; i++)
            {
                try
                {
                    _fileNamesAndPathsList.Add(openFileDialogBrowsePictures.FileNames[i]);
                    _fileNamesList.Add(openFileDialogBrowsePictures.SafeFileNames[i]);
                }
                catch (Exception exception)
                {
                    RtlMessageBox.Show(exception.Message);
                }
            }
            CheckFolderOfPictures(_fileNamesList);
        }

        private void btnSyncFolders_Click(object sender, EventArgs e)
        {
            if (!_fileNamesList.Any())
            {
                RtlMessageBox.Show("عکس های انتخابی مشتری مشخص نشده است.",
                    "خطا در مشخص کردن عکس های کاربر",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EnableOrDisableCheckBoxes(_fileNamesList);
        }



        #endregion


        #region Methods

        //private bool CheckInputs()
        //{
        //    //if (string.IsNullOrEmpty(toolStripMenuItemOrderCode.Text.Trim()))
        //    //{
        //    //    RtlMessageBox.Show("مقداری برای شماره فاکتور مشتری وارد نشده است.", "", MessageBoxButtons.OK,
        //    //        MessageBoxIcon.Error);
        //    //    toolStripMenuItemOrderCode.Focus();
        //    //    return false;
        //    //}

        //    if (_fileNamesAndPathsList.Count == 0)
        //    {
        //        RtlMessageBox.Show("عکسی برای ارسال انتخاب نشده است.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    return true;
        //}
        private static bool CheckInputs(IEnumerable<Guid> fileslList)
        {
            if (fileslList.Any()) return true;
            RtlMessageBox.Show("عکسی برای ارسال انتخاب نشده است.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;

        }

        private void CheckFolderOfPictures(IReadOnlyCollection<string> fileNamesList)
        {
            bool hasPictures = false;
            if (fileNamesList.Any())
            {
                foreach (var fileName in fileNamesList)
                {
                    foreach (Control control in panelPreviewPictures.Controls)
                    {
                        if (control is CheckBoxX checkBox)
                        {
                            if ((string)checkBox.Tag == fileName)
                            {
                                //checkBox.Checked = true;
                                //checkBox.CheckState = CheckState.Checked;
                                hasPictures = true;
                            }
                        }
                    }
                }

                if (hasPictures == false)
                {
                    RtlMessageBox.Show(
                        "فولدر انتخابی عکس های مشتری با عکس های اصلی مشتری مطابقت ندارد." + Environment.NewLine +
                        "این مورد ممکن است به خاطر تغییر نام فایل های اصلی رتوش نشده و یا انتخاب فولدر اشتباه اتفاق افتاده باشد." + Environment.NewLine +
                        "در صورت تغییر نام فایل ها، می بایست نام آنها به نام اصلی اولیه تغییر یابد.",
                        "خطا در همگام سازی",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                RtlMessageBox.Show(
                    "هیچ فایلی برای همگام سازی عکس های مشتری مشخص نشده است.",
                    "خطا در انتخاب فولدر عکس های انتخابی مشتری",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableOrDisableCheckBoxes(IReadOnlyCollection<string> fileNamesList)
        {
            bool hasPictures = false;
            if (fileNamesList.Any())
            {
                foreach (var fileName in fileNamesList)
                {
                    foreach (Control control in panelPreviewPictures.Controls)
                    {
                        if (control is CheckBoxX checkBox)
                        {
                            if ((string)checkBox.Tag == fileName)
                            {
                                checkBox.Checked = true;
                                checkBox.CheckState = CheckState.Checked;
                                hasPictures = true;
                            }
                        }
                    }
                }

                if (hasPictures == false)
                {
                    RtlMessageBox.Show(
                        "فولدر انتخابی عکس های مشتری با عکس های اصلی مشتری مطابقت ندارد." + Environment.NewLine +
                            "این مورد ممکن است به خاطر تغییر نام فایل ها و یا انتخاب فولدر اشتباه اتفاق افتاده باشد." + Environment.NewLine +
                            "در صورت تغییر نام فایل ها، می بایست نام آنها به نام اصلی اولیه تغییر یابد.",
                        "خطا در همگام سازی",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                RtlMessageBox.Show(
                    "فولدری برای همگام سازی عکس های مشتری مشخص نشده است.",
                    "خطا در انتخاب فولدر عکس های انتخابی مشتری",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        //private int ShowImagePreview(int locnewX, OpenFileDialog ofdBrowsePictures, int i)
        //{
        //    int locnewY;
        //    if (locnewX >= panelPreviewPictures.Width - _sizeWidth - 10)
        //    {
        //        locnewX = _locX;
        //        _locY = _locY + _sizeHeight + 30;
        //        locnewY = _locY;
        //    }
        //    else
        //    {
        //        locnewY = _locY;
        //    }

        //    LoadImagestoPanel(ofdBrowsePictures.SafeFileNames[i], ofdBrowsePictures.FileNames[i], locnewX, locnewY);

        //    // ReSharper disable once RedundantAssignment
        //    locnewY = _locY + _sizeHeight + 10;
        //    locnewX = locnewX + _sizeWidth + 10;
        //    return locnewX;
        //}
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

            LoadImagestoPanel(locnewX, locnewY, i, photoList[i]);

            // ReSharper disable once RedundantAssignment
            locnewY = _locY + _sizeHeight + 10;
            locnewX = locnewX + _sizeWidth + 10;
            return locnewX;
        }

        //private void LoadImagestoPanel(string imageName, string imageFullName, int newLocX, int newLocY)
        //{
        //    PictureBox pictureBoxControl = new PictureBox
        //    {
        //        BackColor = SystemColors.Control,
        //        Location = new Point(newLocX, newLocY + 10),
        //        Size = new Size(_sizeWidth, _sizeHeight),
        //        SizeMode = PictureBoxSizeMode.Zoom,
        //        BorderStyle = BorderStyle.FixedSingle,
        //        Tag = imageName,
        //        AccessibleDescription = imageFullName,
        //        Image = imageFullName.FileToByteArray().GetPhotoAndRotateIt()
        //    };

        //    Label pictureBoxLabel = new Label
        //    {
        //        BackColor = SystemColors.Control,
        //        ForeColor = SystemColors.ControlText,
        //        Font = SystemFonts.DefaultFont,
        //        Location = new Point(newLocX + 5, newLocY + 140),
        //        Text = imageName,
        //        AutoSize = true,
        //        MaximumSize = new Size(_sizeWidth, 30),
        //        ClientSize = new Size(_sizeWidth, 30)
        //    };

        //    CheckBoxX pictureBoxCheckBox = new CheckBoxX
        //    {
        //        BackColor = Color.Transparent,
        //        Font = SystemFonts.DefaultFont,
        //        Location = new Point(newLocX + 2, newLocY + 13),
        //        CheckState = CheckState.Checked,
        //        Checked = true,
        //        Tag = imageName,
        //        Text = "",
        //        AutoSize = false,
        //        Size = new Size(17, 17),
        //        MaximumSize = new Size(17, 17),
        //        Parent = pictureBoxControl,
        //        AccessibleDescription = imageFullName,
        //        AccessibleName = imageName,

        //    };


        //    pictureBoxControl.MouseClick += control_MouseClick;
        //    pictureBoxControl.DoubleClick += pictureBox_DoubleClick;

        //    panelPreviewPictures.Controls.Add(pictureBoxLabel);
        //    panelPreviewPictures.Controls.Add(pictureBoxCheckBox);
        //    panelPreviewPictures.Controls.Add(pictureBoxControl);
        //}
        private void LoadImagestoPanel(int newLocX, int newLocY, int i, PhotoViewModel photoInfo)
        {
            var pictureBoxControl = new PictureBox
            {
                BackColor = SystemColors.Control,
                Location = new Point(newLocX, newLocY + 10),
                Size = new Size(_sizeWidth, _sizeHeight),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = photoInfo.Name,
                AccessibleDescription = photoInfo.StreamId.ToString(),
                Image = photoInfo.FileStream.GetPhotoAndRotateIt(),
                Name = "pb_" + photoInfo.Name,
                Anchor = AnchorStyles.Left
            };

            var checkBox = new CheckBoxX
            {
                BackColor = Color.Transparent,
                Font = SystemFonts.DefaultFont,
                Location = new Point(newLocX, newLocY + 138),
                CheckState = CheckState.Unchecked,
                Checked = false,
                Tag = photoInfo.Name,
                Text = photoInfo.Name,
                AutoSize = false,
                CheckBoxPosition = eCheckBoxPosition.Right,
                MaximumSize = new Size(128, 32),
                ClientSize = new Size(128, 32),
                Parent = pictureBoxControl,
                AccessibleDescription = photoInfo.StreamId.ToString(),
                AccessibleName = photoInfo.Name,
                Name = "chk_" + photoInfo.Name,
                Style = eDotNetBarStyle.StyleManagerControlled,
                Anchor = AnchorStyles.Left
            };


            pictureBoxControl.MouseClick += control_MouseClick;
            pictureBoxControl.DoubleClick += pictureBox_DoubleClick;
            //pictureBoxCheckBox.CheckedChanged += pictureBoxCheckBox_CheckedChanged;

            //panelPreviewPictures.Controls.Add(pictureBoxLabel);
            panelPreviewPictures.Controls.Add(checkBox);
            panelPreviewPictures.Controls.Add(pictureBoxControl);
        }


        private void control_MouseClick(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            PictureBox pic = (PictureBox)control;
            pictureBoxPreview.Image = pic.Image;


            //Tag -> photoInfo.Name
            //AccessibleDescription --> photoInfo.StreamId

            // File StreamId
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
            var pv = new FrmPhotoViewer
            {
                MyImageList = _fileNamesAndPathsList,
                SelectedImageFilePath = pictureBoxPreview.Tag.ToString()
            };

            pv.ShowDialog();
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxSelectAll.Checked || checkBoxSelectAll.CheckState != CheckState.Checked) return;
            foreach (Control control in panelPreviewPictures.Controls)
            {
                if (!(control is CheckBoxX checkBox)) continue;
                checkBox.Checked = true;
                checkBox.CheckState = CheckState.Checked;
            }
        }

        private void checkBoxSelectNone_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in panelPreviewPictures.Controls)
            {
                if (!(control is CheckBoxX checkBox)) continue;
                checkBox.Checked = false;
                checkBox.CheckState = CheckState.Unchecked;
            }
        }
        #endregion




        private void btnUploadPhotos_Click(object sender, EventArgs e)
        {
            var fileNamesUpload = new List<string>();
            var streamIdsToUploadList = new List<Guid>();

            foreach (var checkbox in panelPreviewPictures.Controls.OfType<CheckBoxX>())
            {
                if (!checkbox.Checked || checkbox.CheckState != CheckState.Checked) continue;
                streamIdsToUploadList.Add(Guid.Parse(checkbox.AccessibleDescription));
                fileNamesUpload.Add(checkbox.Text);
            }

            if (!CheckInputs(streamIdsToUploadList)) return;

            string orderPrintCode = OrderUtilities.GenerateOrderPrintCode(DateTime.Now, CustomerId, OrderId);

            try
            {
                using (var db = new UnitOfWork())
                {
                    var orderPrintStatusList = db.OrderPrintStatusGenericRepository.Get();

                    var orderPrintInfo =
                        db.OrderPrintGenericRepository.Get(x => x.OrderId == OrderId && x.CustomerId == CustomerId).ToList();
                    if (orderPrintInfo.Any() == false)
                    {
                        int orderPrintStatusId = orderPrintStatusList.First(x => x.Code == 20).Id; // انتخاب عکس

                        var newOrderPrint = new TblOrderPrint
                        {
                            OrderId = OrderId,
                            OrderPrintCode = orderPrintCode,
                            OrderPrintStatusId = orderPrintStatusId,
                            CustomerId = CustomerId,
                            TotalPhotos = streamIdsToUploadList.Count,
                            IsActive = true,
                            CreatedDateTime = DateTime.Now
                        };

                        db.OrderPrintGenericRepository.Insert(newOrderPrint);
                        var resultSaveNewOrderPrint = db.Save();

                        if (resultSaveNewOrderPrint > 0)
                        {
                            var orderPrintId = newOrderPrint.Id;
                            for (int i = 0; i < streamIdsToUploadList.Count; i++)
                            {
                                var newOrderPrintDetails = new TblOrderPrintDetails
                                {
                                    OrderPrintId = orderPrintId,
                                    StreamId = Guid.Parse(streamIdsToUploadList[i].ToString()),
                                    CustomerId = CustomerId,
                                    FileName = fileNamesUpload[i],
                                    CreatedDateTime = DateTime.Now
                                };
                                db.OrderPrintDetailsGenericRepository.Insert(newOrderPrintDetails);
                            }
                            var resultSaveNewOrderPrintDetails = db.Save();

                            if (resultSaveNewOrderPrintDetails > 0)
                            {
                                var drShowPreFactor = RtlMessageBox.Show(
                                    "اطلاعات سفارش چاپ و جزئیات آن با موفقیت در سیستم ثبت گردید." +
                                    "آیا می خواهید فرم ثبت پیش فاکتور نمایش داده شود؟",
                                    "",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1);
                                if (drShowPreFactor == DialogResult.Yes)
                                {
                                    using (var frmPreFactor = new FrmAddEditPreFactor())
                                    {
                                        frmPreFactor.OrderId = OrderId;
                                        frmPreFactor.CustomerId = CustomerId;
                                        frmPreFactor.OrderPrintId = orderPrintId;
                                        frmPreFactor.IsNewPreFactor = true;
                                        frmPreFactor.FileStreamsGuids = streamIdsToUploadList;
                                        //Hide();
                                        if (frmPreFactor.ShowDialog() == DialogResult.OK)
                                            DialogResult = DialogResult.OK;
                                    }
                                }
                                else
                                {
                                    DialogResult = DialogResult.OK;
                                }
                            }
                        }
                        else
                        {
                            RtlMessageBox.Show(
                                "خطا در ثبت اطلاعات سفارش چاپ جدید. " + Environment.NewLine +
                                "لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        var dr = MessageBox.Show(
                            @"قبلا سفارش چاپی برای این مشتری و سفارش در سیستم ثبت شده است. " + Environment.NewLine +
                            @"آیا می خواهید عکس های انتخابی آن را ویرایش کنید؟", "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                        {
                            throw new NotImplementedException("هنوز این قسمت پیاده سازی نشده است.");
                        }
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
                MessageBox.Show(exception.Message);
            }
        }

        #region old Code

        //        var checkYearFolderPath = db.SelectedPhotoRepository.CheckSelectedPhotosYearFolderIsCreatedReturnsPath(year);
        //        if (checkYearFolderPath == null)
        //        {
        //            var yearFolderPath = db.SelectedPhotoRepository.CreateSelectedPhotosYearFolder(year);
        //            if (yearFolderPath != null)
        //            {
        //                RtlMessageBox.Show("فولدر سال جاری ایجاد شد.");
        //            }
        //        }
        //        //yearFolderPath = checkYearFolder;

        //        var checkMonthFolder = db.SelectedPhotoRepository.CheckSelectedPhotosMonthFolderIsCreatedReturnsPath(month);
        //        if (checkMonthFolder == null)
        //        {
        //            var monthFolderPath = db.SelectedPhotoRepository.CreateSelectedPhotosMonthFolder(month, year);
        //            if (monthFolderPath != null)
        //            {
        //                RtlMessageBox.Show("فولدر ماه عکس برداری ایجاد شد.");
        //            }
        //        }
        //        //monthFolderPath = checkMonthFolder;

        //        //var checkCustomerOrderFolder = db.PhotoRepository.CheckCustomerOrderFolderIsCreatedReturnsPath(OrderCode);
        //        //var checkCustomerOrderFolder = db.PhotoRepository.CheckCustomerOrderFolderIsCreatedReturnsPathStreamId(OrderCode);
        //        var orderFolderFullData = db.SelectedPhotoRepository.CheckOrderPrintFolderIsExitsReturnFullData(orderPrintCode);
        //        if (orderFolderFullData == null)
        //        {
        //            var orderPrintPath = db.SelectedPhotoRepository.CreateOrderPrintDirectory(orderPrintCode, month);
        //            if (orderPrintPath != null)
        //            {
        //                RtlMessageBox.Show("فولدر سفارش چاپ مشتری ایجاد شد.");
        //            } // فولدر سفارش قبلا وجود نداشته است.

        //            var parentPathName = orderPrintCode;
        //            var totalFilesUploaded = 0;
        //            var errorInUpload = new List<string>();

        //            for (var i = 0; i < streamIdsToUploadList.Count; i++)
        //            {
        //                //Find file with Stream Id
        //                //Copy selected File to SelectedPhotos Table
        //                //Insert New Files Info To OrderPrint Table




        //                string fileName = OrderCode + "--" + _fileNamesList[i];

        //                var fileUploadResult2 =
        //                    db.SelectedPhotoRepository
        //                      .CreateFileTableFileReturnCreateFileViewModel(fileName, parentPathName, 4, filesWithPathToUpload[i]);



        //                if (fileUploadResult2 != null)
        //                {
        //                    var orderFile = new TblOrderFiles
        //                    {
        //                        FileName = fileUploadResult2.name,
        //                        OrderId = OrderId,
        //                        PathLocator = fileUploadResult2.path_locator_str,
        //                        StreamId = new Guid(fileUploadResult2.streamId),
        //                        UploadDate = DateTime.Now
        //                    };

        //                    db.OrderFilesGenericRepository.Insert(orderFile);
        //                    if (db.Save() > 0)
        //                        totalFilesUploaded++;
        //                }
        //                else
        //                {
        //                    RtlMessageBox.Show(
        //                        $"ارسال فایل {fileNamesUpload[i]} با خطا مواجه شد.",
        //                        "خطا در ارسال فایل", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                    errorInUpload.Add(fileNamesUpload[i]);

        //                    var fileError = new TblFilesError
        //                    {
        //                        OrderId = OrderId,
        //                        BookingId = BookingId,
        //                        CustomerId = CustomerId,
        //                        DateTime = DateTime.Now,
        //                        FileName = fileNamesUpload[i],
        //                        OrderCode = OrderCode,
        //                        ErrorMessage = null,
        //                        ErrorInId = null,
        //                        Submitter = null
        //                    };
        //                    db.FilesErrorGenericRepository.Insert(fileError);
        //                }
        //            }

        //            var order = db.OrderGenericRepository.Get().FirstOrDefault(x => x.Id == OrderId);

        //            if (totalFilesUploaded == filesWithPathToUpload.Count && order != null)
        //            {
        //                orderFolderFullData = db.SelectedPhotoRepository
        //                                        .CheckOrderPrintFolderIsExitsReturnFullData(OrderCode);
        //                if (orderFolderFullData != null)
        //                {
        //                    order.OrderStatusId = orderStatusList.First(x => x.Code == 20).Id;
        //                    order.OrderFolderPathLocator = orderFolderFullData[0].PathLocator;
        //                    order.OrderFolderParentPathLocator = orderFolderFullData[0].ParentPathLocator;
        //                    order.TotalFiles = totalFilesUploaded;
        //                    order.OrderFolderStreamId = orderFolderFullData[0].StreamId;
        //                    order.UploadDate = DateTime.Now;
        //                }

        //                db.OrderGenericRepository.Update(order);
        //                db.Save();

        //                //else
        //                //{
        //                //    var dialogResult = RtlMessageBox.Show(
        //                //        "اطلاعات سفارش فابل دریافت نمی باشد.",
        //                //        "عدم امکان دریافت اطلاعات سفارش",
        //                //        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
        //                //        MessageBoxDefaultButton.Button1);
        //                //    if (dialogResult == DialogResult.Retry)
        //                //    {
        //                //        goto retry;
        //                //    }
        //                //}

        //                RtlMessageBox.Show("تمامی فایل ها با موفقیت ارسال گردید.", "",
        //                    MessageBoxButtons.OK,
        //                    MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                var sb = new StringBuilder();
        //                sb.Append("ارسال فایل (های) زیر با مشکل مواجه شد.");
        //                sb.Append("---------------------------------------\n");
        //                sb.Append("\n");

        //                foreach (var item in errorInUpload)
        //                {
        //                    sb.Append(item);
        //                    sb.Append("\n");
        //                }

        //                if (order != null)
        //                {
        //                    order.OrderStatusId = orderStatusList.First(x => x.Code == 140).Id;
        //                    db.OrderGenericRepository.Update(order);
        //                }

        //                db.Save();
        //                RtlMessageBox.Show(sb.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            var drReplaceFiles = RtlMessageBox.Show(
        //                "فولدر فاکتور مشتری در سیستم وجود دارد." +
        //                Environment.NewLine +
        //                "در صورت  تایید فایل های قبلی پاک شده و فایل های جدید جایگزین می گردند." +
        //                Environment.NewLine +
        //                "در غیر این صورت هیچ فایلی آپلود نمی شود.",
        //                "بررسی فایل های موجود در سرور",
        //                MessageBoxButtons.OKCancel,
        //                MessageBoxIcon.Warning,
        //                MessageBoxDefaultButton.Button2);


        //            if (drReplaceFiles == DialogResult.OK)
        //            {
        //                //retryUpload:
        //                string pathLocator = orderFolderFullData[0].PathLocator;

        //                db.SelectedPhotoRepository.DeleteSelectedPhotosFolderFiles(pathLocator);

        //                //if (deleteResult)
        //                //{
        //                var parentPathName = OrderCode;
        //                var totalFilesUploaded = 0;
        //                var errorInUpload = new List<string>();
        //                ////var orderFilesList = new List<TblOrderFiles>();

        //                for (var i = 0; i < filesWithPathToUpload.Count; i++)
        //                {
        //                    string fileName = OrderCode + "--" + _fileNamesList[i];

        //                    var fileUploadResult2 =
        //                        db.SelectedPhotoRepository.CreateFileTableFileReturnCreateFileViewModel(
        //                        fileName, parentPathName, 4, filesWithPathToUpload[i]);

        //                    if (fileUploadResult2 != null)
        //                    {
        //                        var orderFile = new TblOrderFiles
        //                        {
        //                            FileName = fileUploadResult2.name,
        //                            OrderId = OrderId,
        //                            PathLocator = fileUploadResult2.path_locator_str,
        //                            StreamId = new Guid(fileUploadResult2.streamId)
        //                        };

        //                        ////orderFilesList.Add(orderFile);
        //                        db.OrderFilesGenericRepository.Insert(orderFile);
        //                        if (db.Save() > 0)
        //                            totalFilesUploaded++;
        //                    }
        //                    else
        //                    {
        //                        RtlMessageBox.Show(
        //                            "ارسال فایل " + fileNamesUpload[i] + " با خطا مواجه شد.",
        //                            "خطا در ارسال فایل", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                        errorInUpload.Add(fileNamesUpload[i]);

        //                        var fileError = new TblFilesError
        //                        {
        //                            OrderId = OrderId,
        //                            BookingId = BookingId,
        //                            CustomerId = CustomerId,
        //                            DateTime = DateTime.Now,
        //                            FileName = fileNamesUpload[i],
        //                            OrderCode = OrderCode,
        //                            ErrorMessage = null,
        //                            ErrorInId = null,
        //                            Submitter = null
        //                        };
        //                        db.FilesErrorGenericRepository.Insert(fileError);
        //                    }
        //                }

        //                var order = db.OrderGenericRepository.Get().FirstOrDefault(x => x.Id == OrderId);

        //                if (totalFilesUploaded == filesWithPathToUpload.Count && order != null)
        //                {
        //                    order.OrderStatusId = orderStatusList.First(x => x.Code == 20).Id;
        //                    order.OrderFolderPathLocator = orderFolderFullData[0].PathLocator;
        //                    order.OrderFolderParentPathLocator = orderFolderFullData[0].ParentPathLocator;
        //                    order.TotalFiles = totalFilesUploaded;
        //                    order.OrderFolderStreamId = orderFolderFullData[0].StreamId;

        //                    db.OrderGenericRepository.Update(order);
        //                    db.Save();

        //                    //else
        //                    //{
        //                    //    var dialogResult = RtlMessageBox.Show(
        //                    //        "اطلاعات سفارش فابل دریافت نمی باشد.",
        //                    //        "عدم امکان دریافت اطلاعات سفارش",
        //                    //        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
        //                    //        MessageBoxDefaultButton.Button1);
        //                    //    if (dialogResult == DialogResult.Retry)
        //                    //    {
        //                    //        goto retry;
        //                    //    }
        //                    //}

        //                    RtlMessageBox.Show("تمامی فایل ها با موفقیت ارسال گردید.", "", MessageBoxButtons.OK,
        //                        MessageBoxIcon.Information);
        //                }
        //                else
        //                {
        //                    var sb = new StringBuilder();
        //                    sb.Append("ارسال فایل (های) زیر با مشکل مواجه شد.");
        //                    sb.Append("---------------------------------------\n");
        //                    sb.Append("\n");

        //                    foreach (var item in errorInUpload)
        //                    {
        //                        sb.Append(item);
        //                        sb.Append("\n");
        //                    }

        //                    if (order != null)
        //                    {
        //                        order.OrderStatusId = orderStatusList.First(x => x.Code == 140).Id;
        //                        db.OrderGenericRepository.Update(order);
        //                    }

        //                    db.Save();
        //                    RtlMessageBox.Show(sb.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            } // upload new fileas near old files
        //            else if (drReplaceFiles != DialogResult.OK)
        //            {
        //                DialogResult = DialogResult.Cancel;

        //                #region replace and match file

        //                //////List<FilesInFolderViewModel> listOfFilesInServer = null;
        //                //////var pathLocator = orderFolderFullData[0].PathLocator;
        //                ////////Get Total Files in Folder In The Server
        //                //////var totalFilesInFolder = db.PhotoRepository.GetTotalFilesOfFolder(pathLocator);
        //                //////if (totalFilesInFolder > 0)
        //                //////{
        //                //////    //Get List of Files And Names 
        //                //////    listOfFilesInServer = db.PhotoRepository.GetListOfFilesInFolder(pathLocator);
        //                //////}
        //                //////var parentPathName = OrderCode;

        //                //////var totalFilesUploaded = 0;
        //                //////var errorInUpload = new List<string>();
        //                //////////var orderFilesList = new List<TblOrderFiles>();

        //                //////for (var i = 0; i < filesToUpload.Count; i++)
        //                //////{
        //                //////    //Check if this file name is matched with whitch one on the server
        //                //////    foreach (var serverFile in listOfFilesInServer)
        //                //////    {
        //                //////        string localFileName = OrderCode + "--" + fileNamesUpload[i];
        //                //////        if (serverFile.FileName == localFileName)
        //                //////        {

        //                //////        }
        //                //////    }

        //                //////    bool resultCheckIfLocalFileExistsOnTheServer =

        //                //////    var fileName = OrderCode + "--" + fileNamesUpload[i] + "--" + i + 1;

        //                //////    var fileUploadResult2 =
        //                //////        db.PhotoRepository.CreateFileTableFileReturnCreateFileViewModel(
        //                //////        fileName, parentPathName, 4, filesToUpload[i]);

        //                //////    if (fileUploadResult2 != null)
        //                //////    {
        //                //////        var orderFile = new TblOrderFiles
        //                //////        {
        //                //////            FileName = fileUploadResult2.name,
        //                //////            OrderId = OrderId,
        //                //////            PathLocator = fileUploadResult2.path_locator_str,
        //                //////            StreamId = new Guid(fileUploadResult2.streamId)
        //                //////        };

        //                //////        ////orderFilesList.Add(orderFile);
        //                //////        db.OrderFilesGenericRepository.Insert(orderFile);
        //                //////        if (db.Save() > 0)
        //                //////            totalFilesUploaded++;
        //                //////    }
        //                //////    else
        //                //////    {
        //                //////        RtlMessageBox.Show(
        //                //////            "ارسال فایل " + fileNamesUpload[i] + " با خطا مواجه شد.",
        //                //////            "خطا در ارسال فایل", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                //////        errorInUpload.Add(fileNamesUpload[i]);

        //                //////        var fileError = new TblFilesError
        //                //////        {
        //                //////            OrderId = OrderId,
        //                //////            BookingId = BookingId,
        //                //////            CustomerId = CustomerId,
        //                //////            DateTime = DateTime.Now,
        //                //////            FileName = fileNamesUpload[i],
        //                //////            OrderCode = OrderCode,
        //                //////            ErrorMessage = null,
        //                //////            ErrorInId = null,
        //                //////            Submitter = null
        //                //////        };
        //                //////        db.FilesErrorGenericRepository.Insert(fileError);
        //                //////    }
        //                //////}

        //                //////var order = db.OrderGenericRepository.Get().FirstOrDefault(x => x.Id == OrderId);

        //                //////if (totalFilesUploaded == filesToUpload.Count && order != null)
        //                //////{
        //                //////    order.OrderStatusId = orderStatusList.First(x => x.Code == 20).Id;
        //                //////    order.OrderFolderPathLocator = orderFolderFullData[0].PathLocator;
        //                //////    order.OrderFolderParentPathLocator = orderFolderFullData[0].ParentPathLocator;
        //                //////    order.TotalFiles = totalFilesUploaded;
        //                //////    order.OrderFolderStreamId = orderFolderFullData[0].StreamId;

        //                //////    db.OrderGenericRepository.Update(order);
        //                //////    db.Save();

        //                //////    //else
        //                //////    //{
        //                //////    //    var dialogResult = RtlMessageBox.Show(
        //                //////    //        "اطلاعات سفارش فابل دریافت نمی باشد.",
        //                //////    //        "عدم امکان دریافت اطلاعات سفارش",
        //                //////    //        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
        //                //////    //        MessageBoxDefaultButton.Button1);
        //                //////    //    if (dialogResult == DialogResult.Retry)
        //                //////    //    {
        //                //////    //        goto retry;
        //                //////    //    }
        //                //////    //}

        //                //////    RtlMessageBox.Show("تمامی فایل ها با موفقیت ارسال گردید.", "", MessageBoxButtons.OK,
        //                //////        MessageBoxIcon.Information);
        //                //////}
        //                //////else
        //                //////{
        //                //////    var sb = new StringBuilder();
        //                //////    sb.Append("ارسال فایل (های) زیر با مشکل مواجه شد.");
        //                //////    sb.Append("---------------------------------------\n");
        //                //////    sb.Append("\n");

        //                //////    foreach (var item in errorInUpload)
        //                //////    {
        //                //////        sb.Append(item);
        //                //////        sb.Append("\n");
        //                //////    }

        //                //////    if (order != null)
        //                //////    {
        //                //////        order.OrderStatusId = orderStatusList.First(x => x.Code == 140).Id;
        //                //////        db.OrderGenericRepository.Update(order);
        //                //////    }

        //                //////    db.Save();
        //                //////    RtlMessageBox.Show(sb.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                //////}
        //                ////

        //                #endregion
        //            }
        //        }
        //        DialogResult = DialogResult.OK;
        //    }


        #endregion

    }
}