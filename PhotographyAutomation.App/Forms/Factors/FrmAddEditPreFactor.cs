using PhotographyAutomation.App.Forms.Photos;
using PhotographyAutomation.Business.OrderDetails;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.ViewModels.Document;
using PhotographyAutomation.ViewModels.OrderPrint;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
#pragma warning disable 168

namespace PhotographyAutomation.App.Forms.Factors
{
    public partial class FrmAddEditPreFactor : Form
    {
        #region Variables

        public int OrderId = 0;
        public int CustomerId = 0;
        public int OrderPrintId = 0;

        public bool IsNewPreFactor = true;

        public List<Guid> FileStreamsGuids;
        public List<PhotoOrderDetails> PhotoOrderDetailsList;


        private int _photoCursor;
        private int _selectedOriginalSizeId;

        private OrderPrintViewModel _orderPrintViewModel;

        private static List<PrintSizesViewModel> _listOriginalPrintSizes;
        private static List<PrintSizesViewModel> _listRePrintPrintSizes;

        private static List<PrintSizePricesViewModel> _listOriginalPrintSizePrices;
        private static List<PrintSizePricesViewModel> _listRePrintPrintSizePrices;

        private static List<PrintServicesViewModel> _listOriginalPrintServicePrices;
        private static List<PrintServicesViewModel> _listRePrintPrintServicePrices;


        private static List<TblPrintSpecialServices> _listOriginalPrintSpecialServices;
        private static List<TblPrintSpecialServices> _listRePrintPrintSpecialServices;

        private List<PrintServicesViewModel> _listOriginalPrintSizePrintServices;
        private List<PrintServicesViewModel> _listRePrintPrintSizePrintServices;


        private readonly BackgroundWorker _bgWorkerLoadPrintSizeAndServicesInfo = new BackgroundWorker
        {
            WorkerSupportsCancellation = false,
            WorkerReportsProgress = false
        };

        #endregion


        #region Form Events

        public FrmAddEditPreFactor()
        {
            InitializeComponent();

            _bgWorkerLoadPrintSizeAndServicesInfo.DoWork += _bgWorkerLoadPrintSizeAndServicesInfo_DoWork;
            _bgWorkerLoadPrintSizeAndServicesInfo.RunWorkerCompleted += _bgWorkerLoadPrintSizeAndServicesInfo_RunWorkerCompleted;
        }
        private void FrmAddEditPreFactor_Load(object sender, EventArgs e)
        {
            if (FileStreamsGuids.Any())
            {
                LoadPrintSizeAndServicesInfo();
                LoadPicture(FileStreamsGuids[_photoCursor]);
                if (FileStreamsGuids.Count == 1)
                {
                    btnNextPhoto.Enabled = false;
                    btnPreviousPhoto.Enabled = false;
                }
                btnPreviousPhoto.Enabled = false;
            }
            else
            {
                MessageBox.Show(
                    @"متاسفانه اطلاعات سفارش قابل دریافت نمی باشد. " +
                    @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                    @"خطا در دریافت اطلاعات از سرور",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                DialogResult = DialogResult.Cancel;
            }
        }

        #endregion


        #region LoadPrintSizeAndServicesInfo

        private void LoadPrintSizeAndServicesInfo()
        {
            try
            {
                if (_bgWorkerLoadPrintSizeAndServicesInfo.IsBusy == false)
                {
                    _bgWorkerLoadPrintSizeAndServicesInfo.RunWorkerAsync();
                    circularProgress.IsRunning = _bgWorkerLoadPrintSizeAndServicesInfo.IsBusy;
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void _bgWorkerLoadPrintSizeAndServicesInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                _listOriginalPrintSizes = db.PrintSizeRepository.GetAllPrintSizes();;
                _listRePrintPrintSizes = db.PrintSizeRepository.GetAllPrintSizes();;

                _listOriginalPrintSizePrices = db.PrintSizePriceRepository.GetAllPrintSizePrices();
                _listRePrintPrintSizePrices = db.PrintSizePriceRepository.GetAllPrintSizePrices();

                _listOriginalPrintServicePrices = db.PrintServicePricesGenericRepository
                                            .Get().Select(x => new PrintServicesViewModel
                                            {
                                                Id = x.Id,
                                                PrintServiceId = x.PrintServiceId,
                                                PrintSizeId = x.PrintSizeId,
                                                PrintServiceName = x.TblPrintServices.PrintServiceName,
                                                PrintServiceDescription = x.TblPrintServices.PrintServiceDescription,
                                                PrintServicePrice = x.Price,
                                                PrintServiceCode = x.TblPrintServices.Code,
                                                SizeName = x.TblPrintSizes.Name,
                                                SizeWidth = x.TblPrintSizes.Width,
                                                SizeHeight = x.TblPrintSizes.Height,
                                                SizeDescription = x.TblPrintSizes.Descriptions
                                            }).ToList();
                _listRePrintPrintServicePrices = db.PrintServicePricesGenericRepository
                    .Get().Select(x => new PrintServicesViewModel
                    {
                        Id = x.Id,
                        PrintServiceId = x.PrintServiceId,
                        PrintSizeId = x.PrintSizeId,
                        PrintServiceName = x.TblPrintServices.PrintServiceName,
                        PrintServiceDescription = x.TblPrintServices.PrintServiceDescription,
                        PrintServicePrice = x.Price,
                        PrintServiceCode = x.TblPrintServices.Code,
                        SizeName = x.TblPrintSizes.Name,
                        SizeWidth = x.TblPrintSizes.Width,
                        SizeHeight = x.TblPrintSizes.Height,
                        SizeDescription = x.TblPrintSizes.Descriptions
                    }).ToList();

                _listOriginalPrintSpecialServices = db.PrintSpecialServicesGenericRepository.Get().ToList();
                _listRePrintPrintSpecialServices = db.PrintSpecialServicesGenericRepository.Get().ToList();



                TblOrder orderInfo = db.OrderGenericRepository.GetById(OrderId);
                TblOrderPrint orderPrintInfo = db.OrderPrintGenericRepository.GetById(OrderPrintId);
                TblCustomer customerInfo = db.CustomerGenericRepository.GetById(CustomerId);
                TblOrderPrintStatus orderPrintStatusInfo = new TblOrderPrintStatus();
                TblPhotographyType photographyType = new TblPhotographyType();

                if (orderPrintInfo != null)
                {
                    orderPrintStatusInfo =
                        db.OrderPrintStatusGenericRepository.GetById(orderPrintInfo.OrderPrintStatusId);
                }
                else
                {
                    MessageBox.Show(
                        @"اطلاعات سفارش فابل دریافت نمی باشد." +
                        @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.", "",
                        MessageBoxButtons.OK);
                    DialogResult = DialogResult.Abort;
                }

                if (orderInfo != null)
                {
                    photographyType = db.PhotographyTypesGenericRepository.GetById(orderInfo.PhotographyTypeId);
                }
                else
                {
                    MessageBox.Show(
                        @"اطلاعات سفارش فابل دریافت نمی باشد." +
                        @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.", "",
                        MessageBoxButtons.OK);
                    DialogResult = DialogResult.Abort;
                }

                if (customerInfo == null || orderPrintStatusInfo == null)
                {
                    MessageBox.Show(
                        @"اطلاعات سفارش فابل دریافت نمی باشد." +
                        @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.", "",
                        MessageBoxButtons.OK);
                    DialogResult = DialogResult.Abort;
                }
                else
                {
                    if (orderPrintInfo != null)
                    {
                        if (orderInfo != null)
                        {
                            _orderPrintViewModel = new OrderPrintViewModel
                            {
                                CustomerId = CustomerId,
                                OrderId = OrderId,
                                OrderCode = orderInfo.OrderCode,
                                OrderPrintCode = orderPrintInfo.OrderPrintCode,
                                OrderPrintId = orderPrintInfo.Id,
                                CreatedDateTime = orderPrintInfo.CreatedDateTime,
                                ModifiedDateTime = orderPrintInfo.ModifiedDateTime,
                                CustomerFirstName = customerInfo.FirstName,
                                CustomerLastName = customerInfo.LastName,
                                TotalPhotos = orderPrintInfo.TotalPhotos,
                                OrderPrintStatusId = orderPrintInfo.OrderPrintStatusId,
                                Deposit = orderPrintInfo.Deposit,
                                Payment = orderPrintInfo.Payment,
                                Remaining = orderPrintInfo.Remaining,
                                TotalPrice = orderPrintInfo.TotalPrice,
                                IsActiveOrderPrint = orderPrintInfo.IsActive,
                                OrderPrintStatusName = orderPrintStatusInfo.Name,
                                PhotographyDate = orderInfo.Date,
                                PhotographyDateShamsi = orderInfo.Date?.ToShamsiDate(),
                                RetouchDescriptions = orderPrintInfo.RetochDescriptions,
                                PhotographyTypeId = orderInfo.PhotographyTypeId,
                                PhotographyTypeName = photographyType.TypeName
                            };
                        }
                    }
                }

            }
        }
        private void _bgWorkerLoadPrintSizeAndServicesInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbOriginalPrintSizes.Enabled = !_bgWorkerLoadPrintSizeAndServicesInfo.IsBusy;
            circularProgress.IsRunning = _bgWorkerLoadPrintSizeAndServicesInfo.IsBusy;

            if (_orderPrintViewModel != null)
            {
                txtOrderCodeDate.Text = _orderPrintViewModel.OrderCode.Substring(0, 7);
                txtOrderCodeCustomerIdBookingId.Text = _orderPrintViewModel.OrderCode.Substring(8);
                txtCustomerName.Text =
                    _orderPrintViewModel.CustomerFirstName + @" " + _orderPrintViewModel.CustomerLastName;

                if (_orderPrintViewModel.PhotographyDate.HasValue)
                    datePickerOrderDate.Value = _orderPrintViewModel.PhotographyDate.Value;

                txtPhotographyType.Text = _orderPrintViewModel.PhotographyTypeName;

                var ss = _orderPrintViewModel.OrderPrintCode.Split('-');
                txtOrderPrintCodeDate.Text = ss[0];
                txtOrderPrintCodeOrderId.Text = ss[1];
                txtOrderPrintCodeCustomerId.Text = ss[2];

                lblTotalPhotos.Text = _orderPrintViewModel.TotalPhotos.ToString();
            }

            if (_listOriginalPrintSizes != null && _listOriginalPrintSizes.Any())
            {
                cmbOriginalPrintSizes.DataSource = _listOriginalPrintSizes;
                cmbOriginalPrintSizes.DisplayMember = "Name";
                cmbOriginalPrintSizes.ValueMember = "Id";


                cmbRePrintSize.DataSource = _listRePrintPrintSizes;
                cmbRePrintSize.DisplayMember = "Name";
                cmbRePrintSize.ValueMember = "Id";


                if (_listOriginalPrintSizes.FirstOrDefault() != null)
                {
                    txtOriginalMinimumOrder.Text = _listOriginalPrintSizes.First().MinimumOrder.ToString();
                    txtTotalPriceOriginalPrintSize.Text = _listOriginalPrintSizePrices.First().FirstPrintPrice?.ToString("N0");
                }

                cmbOriginalPrintSizes.Focus();
            }
        }

        #endregion


        #region LoadPicture

        private void LoadPicture(Guid fileStreamsGuid)
        {
            try
            {
                if (bgWorkerLoadPicture.IsBusy == false)
                {
                    bgWorkerLoadPicture.RunWorkerAsync(fileStreamsGuid);
                    circularProgressPictures.IsRunning = bgWorkerLoadPicture.IsBusy;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }
        private void bgWorkerLoadPicture_DoWork(object sender, DoWorkEventArgs e)
        {
            var streamId = new Guid(e.Argument.ToString());
            using (var db = new UnitOfWork())
            {
                FileViewModel file = db.PhotoRepository.GetPhotoByGuid(streamId);
                if (file != null)
                {
                    e.Result = file;
                }
                else
                {
                    throw new Exception("فایل مورد نظر از سرور قابل دریافت نمی باشد.");
                }
            }
        }
        private void bgWorkerLoadPicture_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    var file = (FileViewModel)e.Result;
                    pictureBoxPreview.Image = Image.FromStream(file.fileStream);
                    lblPhotoName.Text = file.name;
                    circularProgressPictures.IsRunning = bgWorkerLoadPicture.IsBusy;
                }
                else
                {
                    throw new Exception("فایل مورد نظر از سرور قابل دریافت نمی باشد.");
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }

        #endregion


        #region cmbOriginalPrintSize

        private void cmbOriginalPrintSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkHasOriginalPrintService.Checked = false;
            rbOriginalMultiPhoto.Checked = false;
            rbOriginalLitPrint.Checked = false;

            try
            {
                var resultSelectedOriginalPrintSizeId =
                    int.TryParse(cmbOriginalPrintSizes.SelectedValue.ToString(), out var selectedOriginalPrintSizeId);

                if (cmbOriginalPrintSizes.SelectedIndex != -1 && resultSelectedOriginalPrintSizeId)
                {
                    _selectedOriginalSizeId = selectedOriginalPrintSizeId;
                    //cmbOriginalPrintServices.SelectedIndex = -1;

                    PrintSizesViewModel printSize = _listOriginalPrintSizes.FirstOrDefault(x => x.Id == _selectedOriginalSizeId);
                    List<PrintServicesViewModel> printServices = _listOriginalPrintServicePrices
                                                                .Where(x => x.PrintSizeId == _selectedOriginalSizeId)
                                                                .ToList();

                    if (printSize != null)
                    {
                        txtOriginalMinimumOrder.Text = printSize.MinimumOrder.ToString();
                        if (printSize.HasLitPrint)
                        {
                            rbOriginalLitPrint.Enabled = true;
                            //btnOriginalShowFrmAddEditLitPrint.Enabled = true;
                        }
                        else
                        {
                            rbOriginalLitPrint.Enabled = false;
                            btnOriginalShowFrmAddEditLitPrint.Enabled = false;
                        }
                    }

                    GetOriginalPrintSizePrice(_selectedOriginalSizeId);

                    if (printServices.Any())
                    {
                        chkHasOriginalPrintService.Enabled = true;
                        _listOriginalPrintSizePrintServices = printServices;

                        cmbOriginalPrintServices.DataSource = _listOriginalPrintSizePrintServices;
                        cmbOriginalPrintServices.DisplayMember = "PrintServiceName";
                        cmbOriginalPrintServices.ValueMember = "Id";
                    }
                    else
                    {
                        chkHasOriginalPrintService.Checked = false;
                        chkHasOriginalPrintService.Enabled = false;

                        cmbOriginalPrintServices.DataSource = null;
                        cmbOriginalPrintServices.Enabled = false;

                        txtOriginalServicePrice.ResetText();
                    }
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void GetOriginalPrintSizePrice(int printSizeId)
        {
            try
            {
                if (_listOriginalPrintSizes != null)
                {
                    var printSizePrice = _listOriginalPrintSizePrices.FirstOrDefault(x => x.PrintSizeId == printSizeId);
                    if (printSizePrice != null)
                        txtTotalPriceOriginalPrintSize.Text = printSizePrice.FirstPrintPrice?.ToString("N0");
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }

        #endregion


        #region chkHasOriginalPrintService_CheckedChanged

        private bool CheckAndGetOriginalPrintSizeId(out int selectedPrintSizeId)
        {
            if (!cmbOriginalPrintServices.Enabled)
            {
                selectedPrintSizeId = 0;
                return true;
            }

            if (cmbOriginalPrintSizes.SelectedValue == null ||
                int.TryParse(cmbOriginalPrintSizes.SelectedValue.ToString(), out selectedPrintSizeId) == false)
            {
                selectedPrintSizeId = 0;
                return true;
            }

            if (cmbOriginalPrintServices.DataSource != null)
                return true;
            return false;
        }



        private void chkHasOriginalPrintService_CheckedChanged(object sender, EventArgs e)
        {
            cmbOriginalPrintServices.Enabled =
                txtOriginalServicePrice.Enabled =
                    chkHasOriginalPrintService.Checked;

        }
        private void cmbOriginalPrintService_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                //cmbOriginalPrintServices.DataSource = null;
                cmbOriginalPrintServices.DataSource = _listOriginalPrintSizePrintServices;
                cmbOriginalPrintServices.DisplayMember = "PrintServiceName";
                cmbOriginalPrintServices.ValueMember = "Id";
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void cmbOriginalPrintServices_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkHasOriginalPrintService.Enabled &&
                    cmbOriginalPrintServices.Items.Count > 0 &&
                    int.TryParse(cmbOriginalPrintServices.SelectedValue.ToString(), out var selectedPrintServicePriceId))
                {
                    GetPrintServicePrice(selectedPrintServicePriceId);
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void GetPrintServicePrice(int selectedPrintServicePriceId)
        {
            txtOriginalServicePrice.ResetText();
            txtOriginalServicePrice.Text =
                _listOriginalPrintServicePrices.Single(x => x.Id == selectedPrintServicePriceId).PrintServicePrice.ToString("N0");
        }



        #endregion


        #region rbOriginalMultiPhoto

        private void rbOriginalMultiPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOriginalMultiPhoto.Checked)
            {
                btnOriginalShowFrmAddEditMutiPhotos.Enabled = true;
                //lblOriginalMutiPhotosCounts.Enabled = true;
                txtOriginalMultiPhotoPrice.Enabled = true;

                //کد هزینه دورچین =10 
                txtOriginalMultiPhotoPrice.Text =
                    GetMultiPhotoPricePrePhoto(code: "10");
            }
            else
            {
                btnOriginalShowFrmAddEditMutiPhotos.Enabled = false;
                txtOriginalMutiPhotoSelectedPhotos.Text = @"---";
                txtOriginalMultiPhotoPrice.Enabled = false;
            }
        }
        private static string GetMultiPhotoPricePrePhoto(string code)
        {
            var servicePrice = string.Empty;
            if (_listOriginalPrintSpecialServices != null)
            {
                servicePrice = _listOriginalPrintSpecialServices.Find(x => x.Code == code).Price.ToString("N0");
            }

            return servicePrice;
        }
        private void btnOriginalShowFrmAddEditMutiPhotos_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region rbOriginalLitPrint

        private void rbOriginalLitPrint_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbOriginalLitPrint.Checked && int.TryParse(cmbOriginalPrintSizes.SelectedValue.ToString(), out int selectedPrintSizeId))
                {
                    GetOriginalLitPrintPrice(selectedPrintSizeId);
                    btnOriginalShowFrmAddEditLitPrint.Enabled = txtOriginalLitPrintPrice.Enabled = rbOriginalLitPrint.Checked;
                }
                else
                {
                    btnOriginalShowFrmAddEditLitPrint.Enabled = txtOriginalLitPrintPrice.Enabled = rbOriginalLitPrint.Checked;
                    txtOriginalLitPrintPrice.Text = string.Empty;
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void GetOriginalLitPrintPrice(int selectedPrintSizeId)
        {
            try
            {
                var printSize = _listOriginalPrintSizes.Find(x => x.Id == selectedPrintSizeId);
                if (printSize.HasLitPrint)
                    txtTotalPriceOriginalPrintSize.Text = printSize.LitPrintPrice?.ToString("N0");
            }
            catch (Exception exception)
            {
                //ignored
            }
        }

        #endregion


        #region TXT Enter Persian Leave English

        private void txt_TypeFarsi_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void txt_TypeFarsi_Leave(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        #endregion TXT Enter Persian Leave English


        #region Methods

        private void ResetTextBoxesAndComboxes()
        {

            #region Original Print Size Service

            //textPhotoRetouchDescription.ResetText();
            //txtOriginalPrintServicePrice.ResetText();
            ////cmbOriginalPrintService.SelectedIndex = -1;
            //cmbOriginalPrintServices.Enabled = false;
            //rbOriginalMultiPhoto.Checked = false;
            //rbOriginalLitPrint.Enabled = false;
            //txtOriginalPrintSizePrice.ResetText();
            //cmbOriginalPrintSize.SelectedIndex = -1;

            #endregion
        }

        private void CalculateTotalPhotosConfirmed()
        {
            var totalPhotosConfirmed = 0;
            foreach (var photo in PhotoOrderDetailsList)
            {
                if (photo.IsAccepted == 1)
                    totalPhotosConfirmed++;
            }

            txtTotalSelectedPhotos.Text = totalPhotosConfirmed.ToString();
        }
        private void CaculateTotalPhotoServicesConfirmed()
        {
            var totalPhotoServices = 0;
            foreach (var photo in PhotoOrderDetailsList)
            {
                if (photo.HasOriginalPrintService && photo.OriginalServiceId > 0)
                    totalPhotoServices++;
                if (photo.HasSecondPrint1Service && photo.SecondPrint1ServiceId > 0)
                    totalPhotoServices += photo.SecondPrint1ServiceCount;
                if (photo.HasSecondPrint2Service && photo.SecondPrint2ServiceId > 0)
                    totalPhotoServices += photo.SecondPrint2ServiceCount;
                if (photo.HasSecondPrint3Service && photo.SecondPrint3ServiceId > 0)
                    totalPhotoServices += photo.SecondPrint3ServiceCount;
                if (photo.HasSecondPrint4Service && photo.SecondPrint4ServiceId > 0)
                    totalPhotoServices += photo.SecondPrint4ServiceCount;
            }

            txtTotalPrintServices.Text = totalPhotoServices.ToString();
        }

        #endregion




        #region Buttons

        private void btnOkPhotoOrderPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var currentGuid = PhotoOrderDetailsList[_photoCursor].StreamId;

                var currentOrderDetails =
                    PhotoOrderDetailsList
                        .FirstOrDefault(x => x.StreamId == currentGuid);

                var itemIndex = PhotoOrderDetailsList
                    .FindIndex(x => currentOrderDetails != null &&
                                    x.StreamId == currentOrderDetails.StreamId);

                if (currentOrderDetails == null)
                    return;

                currentOrderDetails.IsAccepted = 1;
                currentOrderDetails.AcceptRejectImage = Properties.Resources.iconfinder_accept_blue_41177;

                if (cmbOriginalPrintServices.SelectedValue != null &&
                    int.TryParse(cmbOriginalPrintServices.SelectedValue.ToString(),
                        out var selectedOriginalPrintServiceId))
                {
                    currentOrderDetails.HasOriginalPrintService = true;
                    currentOrderDetails.OriginalServiceId = selectedOriginalPrintServiceId;
                }

                PhotoOrderDetailsList[itemIndex] = currentOrderDetails;

                toolTip1.SetToolTip(pictureBoxIsAccepted, "عکس برای ثبت در پیش فاکتور تائید شده است.");
                pictureBoxIsAccepted.Image = currentOrderDetails.AcceptRejectImage;

                CalculateTotalPhotosConfirmed();
                CaculateTotalPhotoServicesConfirmed();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }
        private void btnCancelPhotoOrderPrint_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                @"آیا واقعا می خواهید عکس مورد نظر را از پیش فاکتور حذف کنید؟",
                @"تایید حذف عکس از پیش فاکتور",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
                return;
            try
            {
                var currentGuid = PhotoOrderDetailsList[_photoCursor].StreamId;
                var currentOrderDetails = PhotoOrderDetailsList.FirstOrDefault(x => x.StreamId == currentGuid);
                var itemIndex = PhotoOrderDetailsList.FindIndex(x =>
                    currentOrderDetails != null && x.StreamId == currentOrderDetails.StreamId);

                if (currentOrderDetails == null)
                    return;

                currentOrderDetails.IsAccepted = -1;
                currentOrderDetails.AcceptRejectImage = Properties.Resources.iconfinder_cancel_round_41190;
                pictureBoxIsAccepted.Image = currentOrderDetails.AcceptRejectImage;
                PhotoOrderDetailsList[itemIndex].IsAccepted = currentOrderDetails.IsAccepted;
                toolTip1.SetToolTip(pictureBoxIsAccepted, "این عکس در پیش فاکتور حذف شده است.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void btnMagnifyPhoto_Click(object sender, EventArgs e)
        {
            var image = pictureBoxPreview.Image;
            var imageBytes = ImageConvertor.ImageToByteArray(image);
            //byte[] imageBytes = imageConvertor.ConvertImageToByteArray(image);
            using (var photoViewer = new FrmPhotoViewer())
            {
                photoViewer.myImage = imageBytes;
                photoViewer.ShowDialog();
            }
        }

        #endregion

        #region btnNextPhoto

        private void btnNextPhoto_Click(object sender, EventArgs e)
        {
            //try
            //{
            var totalItems = PhotoOrderDetailsList.Count;

            if (_photoCursor < 0 || _photoCursor >= totalItems)
                return;

            //Save Photo Order Details to Class
            //...
            var currentGuid = PhotoOrderDetailsList[_photoCursor].StreamId;
            var currentOrderDetails = PhotoOrderDetailsList.FirstOrDefault(x => x.StreamId == currentGuid);
            if (currentOrderDetails != null)
            {
                ///////
                // Original Print
                //
                if (cmbOriginalPrintSizes.SelectedValue != null &&
                    int.TryParse(cmbOriginalPrintSizes.SelectedValue.ToString(), out var ttt))
                    currentOrderDetails.OriginalSizeId = ttt;

                if (int.TryParse(txtTotalPriceOriginalPrintSize.Text.Replace(",", ""), out var tt))
                    currentOrderDetails.OriginalPrintSizePrice = tt;

                //if (rbOriginalNormalPrint.Checked)
                //{
                //    if (cmbOriginalPrintServices.Items.Count > 0)
                //    {
                //        currentOrderDetails.OriginalServiceId = (int)cmbOriginalPrintServices.SelectedValue;
                //        currentOrderDetails.HasOriginalPrintService = true;
                //        if (int.TryParse(txtOriginalPrintServicePrice.Text.Replace(",", ""), out var result))
                //            currentOrderDetails.OriginalPrintServicePrice = result;
                //    }
                //}

                currentOrderDetails.RetouchDescriptions = textPhotoRetouchDescription.Text;

                ///////
                // Second Print 1
                //
                //if (checkBoxSecondPrint1.Checked)
                //{
                //    if (cmbSecondPrintSize1.Items.Count > 0)
                //    {
                //        if (cmbSecondPrintSize1.SelectedValue != null &&
                //            int.TryParse(cmbSecondPrintSize1.SelectedValue.ToString(), out var result1))
                //        {
                //            currentOrderDetails.SecondPrint1SizeId = result1;
                //            currentOrderDetails.HasSecondPrint1 = true;

                //            if (integerInputSecondPrintCount1.Value > 0)
                //                currentOrderDetails.SecondPrint1Count = integerInputSecondPrintCount1.Value;

                //            if (int.TryParse(txtSecondPrintSizePrice1.Text.Replace(",", ""), out var resultPrice))
                //                currentOrderDetails.SecondPrint1SizePrice = resultPrice;


                //            if (checkBoxLoadSecondPrintServices1.Checked)
                //            {
                //                if (cmbSecondPrintService1.Items.Count > 0)
                //                {
                //                    if (cmbSecondPrintService1.SelectedValue != null &&
                //                        int.TryParse(cmbSecondPrintService1.SelectedValue.ToString(),
                //                            out var result11))
                //                    {
                //                        currentOrderDetails.SecondPrint1ServiceId = result11;
                //                        currentOrderDetails.HasSecondPrint1Service = true;
                //                    }

                //                    if (integerInputSecondPrintServiceCount1.Value > 0)
                //                        currentOrderDetails.SecondPrint1ServiceCount =
                //                            integerInputSecondPrintServiceCount1.Value;
                //                    if (int.TryParse(txtSecondPrintServicePrice1.Text.Replace(",", ""), out var result))
                //                        currentOrderDetails.SecondPrint1ServicePrice = result;
                //                }
                //            }
                //        }
                //    }
                //}

                ///////
                // Second Print 2
                //
                //if (checkBoxSecondPrint2.Checked)
                //{
                //    if (cmbSecondPrintSize2.Items.Count > 0)
                //    {
                //        if (cmbSecondPrintSize2.SelectedValue != null &&
                //            int.TryParse(cmbSecondPrintSize2.SelectedValue.ToString(), out var result2))
                //        {
                //            currentOrderDetails.SecondPrint2SizeId = result2;
                //            currentOrderDetails.HasSecondPrint2 = true;

                //            if (integerInputSecondPrintCount2.Value > 0)
                //                currentOrderDetails.SecondPrint2Count = integerInputSecondPrintCount2.Value;

                //            if (int.TryParse(txtSecondPrintSizePrice2.Text.Replace(",", ""), out var resultPrice))
                //                currentOrderDetails.SecondPrint2SizePrice = resultPrice;


                //            if (checkBoxLoadSecondPrintServices2.Checked)
                //            {
                //                if (cmbSecondPrintService2.Items.Count > 0)
                //                {
                //                    if (cmbSecondPrintService2.SelectedValue != null &&
                //                        int.TryParse(cmbSecondPrintService2.SelectedValue.ToString(),
                //                            out var result22))
                //                    {
                //                        currentOrderDetails.SecondPrint2ServiceId = result22;
                //                        currentOrderDetails.HasSecondPrint2Service = true;
                //                    }

                //                    if (integerInputSecondPrintServiceCount2.Value > 0)
                //                        currentOrderDetails.SecondPrint2ServiceCount =
                //                            integerInputSecondPrintServiceCount2.Value;
                //                    if (int.TryParse(txtSecondPrintServicePrice2.Text.Replace(",", ""), out var result))
                //                        currentOrderDetails.SecondPrint2ServicePrice = result;
                //                }
                //            }
                //        }
                //    }
                //}

                ///////
                // Second Print 3
                //
                //if (checkBoxSecondPrint3.Checked)
                //{
                //    if (cmbSecondPrintSize3.Items.Count > 0)
                //    {
                //        if (cmbSecondPrintSize3.SelectedValue != null &&
                //            int.TryParse(cmbSecondPrintSize3.SelectedValue.ToString(), out var result3))
                //        {
                //            currentOrderDetails.SecondPrint3SizeId = result3;
                //            currentOrderDetails.HasSecondPrint3 = true;

                //            if (integerInputSecondPrintCount3.Value > 0)
                //                currentOrderDetails.SecondPrint3Count = integerInputSecondPrintCount3.Value;

                //            if (int.TryParse(txtSecondPrintSizePrice3.Text.Replace(",", ""), out var resultPrice))
                //                currentOrderDetails.SecondPrint3SizePrice = resultPrice;


                //            if (checkBoxLoadSecondPrintServices3.Checked)
                //            {
                //                if (cmbSecondPrintService3.Items.Count > 0)
                //                {
                //                    if (cmbSecondPrintService3.SelectedValue != null &&
                //                        int.TryParse(cmbSecondPrintService3.SelectedValue.ToString(),
                //                            out var result33))
                //                    {
                //                        currentOrderDetails.SecondPrint3ServiceId = result33;
                //                        currentOrderDetails.HasSecondPrint3Service = true;
                //                    }

                //                    if (integerInputSecondPrintServiceCount3.Value > 0)
                //                        currentOrderDetails.SecondPrint3ServiceCount =
                //                            integerInputSecondPrintServiceCount3.Value;
                //                    if (int.TryParse(txtSecondPrintServicePrice3.Text.Replace(",", ""), out var result))
                //                        currentOrderDetails.SecondPrint3ServicePrice = result;
                //                }
                //            }
                //        }
                //    }
                //}

                ///////
                // Second Print 4
                //
                //if (checkBoxSecondPrint4.Checked)
                //{
                //    if (cmbSecondPrintSize4.Items.Count > 0)
                //    {
                //        if (cmbSecondPrintSize4.SelectedValue != null &&
                //            int.TryParse(cmbSecondPrintSize4.SelectedValue.ToString(), out var result4))
                //        {
                //            currentOrderDetails.SecondPrint4SizeId = result4;
                //            currentOrderDetails.HasSecondPrint4 = true;

                //            if (integerInputSecondPrintCount4.Value > 0)
                //                currentOrderDetails.SecondPrint4Count = integerInputSecondPrintCount4.Value;

                //            if (int.TryParse(txtSecondPrintSizePrice4.Text.Replace(",", ""), out var resultPrice))
                //                currentOrderDetails.SecondPrint4SizePrice = resultPrice;


                //            if (checkBoxLoadSecondPrintServices4.Checked)
                //            {
                //                if (cmbSecondPrintService4.Items.Count > 0)
                //                {
                //                    if (cmbSecondPrintService4.SelectedValue != null &&
                //                        int.TryParse(cmbSecondPrintService4.SelectedValue.ToString(),
                //                            out var result44))
                //                    {
                //                        currentOrderDetails.SecondPrint4ServiceId = result44;
                //                        currentOrderDetails.HasSecondPrint4Service = true;
                //                    }

                //                    if (integerInputSecondPrintServiceCount4.Value > 0)
                //                        currentOrderDetails.SecondPrint4ServiceCount =
                //                            integerInputSecondPrintServiceCount4.Value;
                //                    if (int.TryParse(txtSecondPrintServicePrice4.Text.Replace(",", ""), out var result))
                //                        currentOrderDetails.SecondPrint4ServicePrice = result;
                //                }
                //            }
                //        }
                //    }
                //}

                switch (currentOrderDetails.IsAccepted)
                {
                    case 1:
                        currentOrderDetails.AcceptRejectImage =
                            Properties.Resources.iconfinder_accept_blue_41177;
                        break;
                    case -1:
                        currentOrderDetails.AcceptRejectImage =
                            Properties.Resources.iconfinder_cancel_round_41190;
                        break;
                    default:
                        currentOrderDetails.AcceptRejectImage =
                            Properties.Resources.iconfinder_flickr_317744;
                        break;
                }

                //var itemIndex = PhotoOrderDetailsList.FindIndex(x => x.StreamId == currentOrderDetails.StreamId);
                //PhotoOrderDetailsList[itemIndex] = currentOrderDetails;
            }

            //ResetTextBoxesAndComboxes();

            // Load Next Picture
            _photoCursor++;
            if (_photoCursor >= 1)
                btnPreviousPhoto.Enabled = true;
            //int lblCounter = _photoCursor + 1;
            //lblCurrentPhoto.Text = lblCounter.ToString();
            if (_photoCursor == totalItems - 1)
            {
                btnNextPhoto.Enabled = false;
            }

            var nextGuid = PhotoOrderDetailsList[_photoCursor].StreamId;
            var nextOrderDetails = PhotoOrderDetailsList.FirstOrDefault(x => x.StreamId == nextGuid);
            if (nextOrderDetails != null)
            {
                LoadPicture(nextGuid);

                ////Original Photo
                //
                if (nextOrderDetails.OriginalSizeId == 0)
                    cmbOriginalPrintSizes.SelectedIndex = -1;
                else
                {
                    cmbOriginalPrintSizes.SelectedValue = nextOrderDetails.OriginalSizeId;
                    cmbOriginalPrintSize_SelectedIndexChanged(null, null);
                }

                if (nextOrderDetails.HasOriginalPrintService)
                {
                    //rbOriginalNormalPrint.Checked = true;
                    if (nextOrderDetails.OriginalServiceId != 0)
                    {
                        cmbOriginalPrintServices.SelectedValue = nextOrderDetails.OriginalServiceId;
                        //cmbOriginalPrintService_SelectedIndexChanged(null, null);
                    }
                    else
                        cmbOriginalPrintServices.SelectedIndex = -1;
                }

                if (nextOrderDetails.RetouchDescriptions != null)
                    textPhotoRetouchDescription.Text = nextOrderDetails.RetouchDescriptions;
                pictureBoxIsAccepted.Image = nextOrderDetails.AcceptRejectImage ??
                                             Properties.Resources.iconfinder_flickr_317744;



                ////Second Photo
                //
                ////SecondPrint1
                //
                if (nextOrderDetails.HasSecondPrint1)
                {
                    //if (nextOrderDetails.SecondPrint1SizeId != 0)
                    //{
                    //checkBoxSecondPrint1.Checked = true;
                    //checkBoxSecondPrint1.CheckState = CheckState.Checked;
                    //cmbSecondPrintSize1.SelectedValue = nextOrderDetails.SecondPrint1SizeId;

                    //checkBoxSecondPrint1.Enabled = true;
                    //cmbSecondPrintSize1.Enabled = true;

                    //txtSecondPrintSizePrice1.Text =
                    //    nextOrderDetails.SecondPrint1SizePrice.ToString("##,###");
                    //integerInputSecondPrintCount1.Value = nextOrderDetails.SecondPrint1Count;

                    //var ss = new SecondPrintSizeDataStructure
                    //{
                    //    Count = integerInputSecondPrintCount1.Value,
                    //    PrintSizeId = (int)cmbSecondPrintSize1.SelectedValue,
                    //    TextBoxName = txtSecondPrintSizePrice1.Name,
                    //    PreviousSizeId = nextOrderDetails.SecondPrint1SizeId
                    //};
                    //    cmbSecondPrintSize1_SelectedValueChanged(ss);
                    //    if (nextOrderDetails.HasSecondPrint1Service)
                    //    {
                    //        if (nextOrderDetails.SecondPrint1SizeId != 0)
                    //        {
                    //            if (nextOrderDetails.HasSecondPrint1Service)
                    //            {
                    //                if (nextOrderDetails.SecondPrint1ServiceId != 0)
                    //                {
                    //                    checkBoxLoadSecondPrintServices1.Checked = true;
                    //                    cmbSecondPrintService1.SelectedValue =
                    //                        nextOrderDetails.SecondPrint1ServiceId;
                    //                    integerInputSecondPrintServiceCount1.Value =
                    //                        nextOrderDetails.SecondPrint1ServiceCount;

                    //                    cmbSecondPrintService1_SelectedIndexChanged(null, null);
                    //                }
                    //            }
                    //        }
                    //        else
                    //            cmbSecondPrintSize1.SelectedIndex = -1;
                    //    }
                    //}
                    //else
                    //    cmbSecondPrintSize1.SelectedIndex = -1;
                }


                ////Second Photo
                //
                ////SecondPrint2
                //
                //if (nextOrderDetails.HasSecondPrint2)
                //{
                //    if (nextOrderDetails.SecondPrint2SizeId != 0)
                //    {
                //        checkBoxSecondPrint2.Checked = true;
                //        checkBoxSecondPrint2.CheckState = CheckState.Checked;
                //        cmbSecondPrintSize2.SelectedValue = nextOrderDetails.SecondPrint2SizeId;

                //        checkBoxSecondPrint2.Enabled = true;
                //        cmbSecondPrintSize2.Enabled = true;

                //        txtSecondPrintSizePrice2.Text =
                //            nextOrderDetails.SecondPrint2SizePrice.ToString("##,###");
                //        integerInputSecondPrintCount2.Value = nextOrderDetails.SecondPrint2Count;

                //        var ss = new SecondPrintSizeDataStructure
                //        {
                //            Count = integerInputSecondPrintCount2.Value,
                //            PrintSizeId = (int)cmbSecondPrintSize2.SelectedValue,
                //            TextBoxName = txtSecondPrintSizePrice2.Name,
                //            PreviousSizeId = nextOrderDetails.SecondPrint2SizeId
                //        };
                //        cmbSecondPrintSize2_SelectedValueChanged(ss);
                //        if (nextOrderDetails.HasSecondPrint2Service)
                //        {
                //            if (nextOrderDetails.SecondPrint2SizeId != 0)
                //            {
                //                if (nextOrderDetails.HasSecondPrint2Service)
                //                {
                //                    if (nextOrderDetails.SecondPrint2ServiceId != 0)
                //                    {
                //                        checkBoxLoadSecondPrintServices2.Checked = true;
                //                        cmbSecondPrintService2.SelectedValue =
                //                            nextOrderDetails.SecondPrint2ServiceId;
                //                        integerInputSecondPrintServiceCount2.Value =
                //                            nextOrderDetails.SecondPrint2ServiceCount;

                //                        cmbSecondPrintService2_SelectedIndexChanged(null, null);
                //                    }
                //                }
                //            }
                //            else
                //                cmbSecondPrintSize2.SelectedIndex = -1;
                //        }
                //    }
                //    else
                //        cmbSecondPrintSize2.SelectedIndex = -1;
                //}

                ////Second Photo
                //
                ////SecondPrint3
                //
                //if (nextOrderDetails.HasSecondPrint3)
                //{
                //    if (nextOrderDetails.SecondPrint3SizeId != 0)
                //    {
                //        checkBoxSecondPrint3.Checked = true;
                //        checkBoxSecondPrint3.CheckState = CheckState.Checked;
                //        cmbSecondPrintSize3.SelectedValue = nextOrderDetails.SecondPrint3SizeId;

                //        checkBoxSecondPrint3.Enabled = true;
                //        cmbSecondPrintSize3.Enabled = true;

                //        txtSecondPrintSizePrice3.Text =
                //            nextOrderDetails.SecondPrint3SizePrice.ToString("##,###");
                //        integerInputSecondPrintCount3.Value = nextOrderDetails.SecondPrint3Count;

                //        var ss = new SecondPrintSizeDataStructure
                //        {
                //            Count = integerInputSecondPrintCount3.Value,
                //            PrintSizeId = (int)cmbSecondPrintSize3.SelectedValue,
                //            TextBoxName = txtSecondPrintSizePrice3.Name,
                //            PreviousSizeId = nextOrderDetails.SecondPrint3SizeId
                //        };
                //        cmbSecondPrintSize3_SelectedValueChanged(ss);
                //        if (nextOrderDetails.HasSecondPrint3Service)
                //        {
                //            if (nextOrderDetails.SecondPrint3SizeId != 0)
                //            {
                //                if (nextOrderDetails.HasSecondPrint3Service)
                //                {
                //                    if (nextOrderDetails.SecondPrint3ServiceId != 0)
                //                    {
                //                        checkBoxLoadSecondPrintServices3.Checked = true;
                //                        cmbSecondPrintService3.SelectedValue =
                //                            nextOrderDetails.SecondPrint3ServiceId;
                //                        integerInputSecondPrintServiceCount3.Value =
                //                            nextOrderDetails.SecondPrint3ServiceCount;

                //                        cmbSecondPrintService3_SelectedIndexChanged(null, null);
                //                    }
                //                }
                //            }
                //            else
                //                cmbSecondPrintSize3.SelectedIndex = -1;
                //        }
                //    }
                //    else
                //        cmbSecondPrintSize3.SelectedIndex = -1;
                //}


                ////Second Photo
                //
                ////SecondPrint4
                //
                //if (nextOrderDetails.HasSecondPrint4)
                //{
                //    if (nextOrderDetails.SecondPrint4SizeId != 0)
                //    {
                //        checkBoxSecondPrint4.Checked = true;
                //        checkBoxSecondPrint4.CheckState = CheckState.Checked;
                //        cmbSecondPrintSize4.SelectedValue = nextOrderDetails.SecondPrint4SizeId;

                //        checkBoxSecondPrint4.Enabled = true;
                //        cmbSecondPrintSize4.Enabled = true;

                //        txtSecondPrintSizePrice4.Text =
                //            nextOrderDetails.SecondPrint4SizePrice.ToString("##,###");
                //        integerInputSecondPrintCount4.Value = nextOrderDetails.SecondPrint4Count;

                //        var ss = new SecondPrintSizeDataStructure
                //        {
                //            Count = integerInputSecondPrintCount4.Value,
                //            PrintSizeId = (int)cmbSecondPrintSize4.SelectedValue,
                //            TextBoxName = txtSecondPrintSizePrice4.Name,
                //            PreviousSizeId = nextOrderDetails.SecondPrint4SizeId
                //        };
                //        cmbSecondPrintSize4_SelectedValueChanged(ss);
                //        if (nextOrderDetails.HasSecondPrint4Service)
                //        {
                //            if (nextOrderDetails.SecondPrint4SizeId != 0)
                //            {
                //                if (nextOrderDetails.HasSecondPrint4Service)
                //                {
                //                    if (nextOrderDetails.SecondPrint4ServiceId != 0)
                //                    {
                //                        checkBoxLoadSecondPrintServices4.Checked = true;
                //                        cmbSecondPrintService4.SelectedValue =
                //                            nextOrderDetails.SecondPrint4ServiceId;
                //                        integerInputSecondPrintServiceCount4.Value =
                //                            nextOrderDetails.SecondPrint4ServiceCount;

                //                        cmbSecondPrintService4_SelectedIndexChanged(null, null);
                //                    }
                //                }
                //            }
                //            else
                //                cmbSecondPrintSize4.SelectedIndex = -1;
                //        }
                //    }
                //    else
                //        cmbSecondPrintSize4.SelectedIndex = -1;
                //}
                //    }
                //}
                //catch (Exception exception)
                //{
                //    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                //        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                //}
            }

            //private void btnPreviousPhoto_Click(object sender, EventArgs e)
            //{
            //    int totalItems = PhotoOrderDetailsList.Count;

            //    if (_photoCursor <= totalItems)
            //    {
            //        btnNextPhoto.Enabled = true;
            //    }

            //    try
            //    {
            //        if (_photoCursor < 0 || _photoCursor >= totalItems)
            //            return;

            //        //Save Photo Order Details to Class
            //        //...
            //        var currentGuid = PhotoOrderDetailsList[_photoCursor].StreamId;
            //        var currentOrderDetails = PhotoOrderDetailsList.FirstOrDefault(x => x.StreamId == currentGuid);
            //        if (currentOrderDetails != null)
            //        {
            //            ///////
            //            // Original Print
            //            //
            //            if (cmbOriginalPrintSize.SelectedValue != null &&
            //                int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out var ttt))
            //                currentOrderDetails.OriginalSizeId = ttt;

            //            if (int.TryParse(txtOriginalPrintSizePrice.Text.Replace(",", ""), out var tt))
            //                currentOrderDetails.OriginalPrintSizePrice = tt;

            //            if (rbOriginalPrintNormalPrint.Checked)
            //            {
            //                if (cmbOriginalPrintService.Items.Count > 0)
            //                {
            //                    currentOrderDetails.OriginalServiceId = (int)cmbOriginalPrintService.SelectedValue;
            //                    currentOrderDetails.HasOriginalPrintService = true;
            //                    if (int.TryParse(txtOriginalPrintServicePrice.Text.Replace(",", ""), out var result))
            //                        currentOrderDetails.OriginalPrintServicePrice = result;
            //                }
            //            }

            //            currentOrderDetails.RetouchDescriptions = textPhotoRetouchDescription.Text;

            //            switch (currentOrderDetails.IsAccepted)
            //            {
            //                case 1:
            //                    currentOrderDetails.AcceptRejectImage =
            //                        Properties.Resources.iconfinder_accept_blue_41177;
            //                    break;
            //                case -1:
            //                    currentOrderDetails.AcceptRejectImage =
            //                        Properties.Resources.iconfinder_cancel_round_41190;
            //                    break;
            //                default:
            //                    currentOrderDetails.AcceptRejectImage =
            //                        Properties.Resources.iconfinder_flickr_317744;
            //                    break;
            //            }

            ///////
            // Second Print 1
            //
            //if (checkBoxSecondPrint1.Checked)
            //{
            //    if (cmbSecondPrintSize1.Items.Count > 0)
            //    {
            //        if (cmbSecondPrintSize1.SelectedValue != null &&
            //            int.TryParse(cmbSecondPrintSize1.SelectedValue.ToString(), out var result1))
            //        {
            //            currentOrderDetails.SecondPrint1SizeId = result1;
            //            currentOrderDetails.HasSecondPrint1 = true;

            //            if (integerInputSecondPrintCount1.Value > 0)
            //                currentOrderDetails.SecondPrint1Count = integerInputSecondPrintCount1.Value;

            //            if (int.TryParse(txtSecondPrintSizePrice1.Text.Replace(",", ""), out var resultPrice))
            //                currentOrderDetails.SecondPrint1SizePrice = resultPrice;


            //            if (checkBoxLoadSecondPrintServices1.Checked)
            //            {
            //                if (cmbSecondPrintService1.Items.Count > 0)
            //                {
            //                    if (cmbSecondPrintService1.SelectedValue != null &&
            //                        int.TryParse(cmbSecondPrintService1.SelectedValue.ToString(),
            //                            out var result11))
            //                    {
            //                        currentOrderDetails.SecondPrint1ServiceId = result11;
            //                        currentOrderDetails.HasSecondPrint1Service = true;
            //                    }

            //                    if (integerInputSecondPrintServiceCount1.Value > 0)
            //                        currentOrderDetails.SecondPrint1ServiceCount =
            //                            integerInputSecondPrintServiceCount1.Value;
            //                    if (int.TryParse(txtSecondPrintServicePrice1.Text.Replace(",", ""), out var result))
            //                        currentOrderDetails.SecondPrint1ServicePrice = result;
            //                }
            //            }
            //        }
            //    }
            //}

            ///////
            // Second Print 2
            //
            //if (checkBoxSecondPrint2.Checked)
            //{
            //    if (cmbSecondPrintSize2.Items.Count > 0)
            //    {
            //        if (cmbSecondPrintSize2.SelectedValue != null &&
            //            int.TryParse(cmbSecondPrintSize2.SelectedValue.ToString(), out var result2))
            //        {
            //            currentOrderDetails.SecondPrint2SizeId = result2;
            //            currentOrderDetails.HasSecondPrint2 = true;

            //            if (integerInputSecondPrintCount2.Value > 0)
            //                currentOrderDetails.SecondPrint2Count = integerInputSecondPrintCount2.Value;

            //            if (int.TryParse(txtSecondPrintSizePrice2.Text.Replace(",", ""), out var resultPrice))
            //                currentOrderDetails.SecondPrint2SizePrice = resultPrice;


            //            if (checkBoxLoadSecondPrintServices2.Checked)
            //            {
            //                if (cmbSecondPrintService2.Items.Count > 0)
            //                {
            //                    if (cmbSecondPrintService2.SelectedValue != null &&
            //                        int.TryParse(cmbSecondPrintService2.SelectedValue.ToString(),
            //                            out var result22))
            //                    {
            //                        currentOrderDetails.SecondPrint2ServiceId = result22;
            //                        currentOrderDetails.HasSecondPrint2Service = true;
            //                    }

            //                    if (integerInputSecondPrintServiceCount2.Value > 0)
            //                        currentOrderDetails.SecondPrint2ServiceCount =
            //                            integerInputSecondPrintServiceCount2.Value;
            //                    if (int.TryParse(txtSecondPrintServicePrice2.Text.Replace(",", ""), out var result))
            //                        currentOrderDetails.SecondPrint2ServicePrice = result;
            //                }
            //            }
            //        }
            //    }
            //}

            ///////
            // Second Print 3
            //
            //if (checkBoxSecondPrint3.Checked)
            //{
            //    if (cmbSecondPrintSize3.Items.Count > 0)
            //    {
            //        if (cmbSecondPrintSize3.SelectedValue != null &&
            //            int.TryParse(cmbSecondPrintSize3.SelectedValue.ToString(), out var result3))
            //        {
            //            currentOrderDetails.SecondPrint3SizeId = result3;
            //            currentOrderDetails.HasSecondPrint3 = true;

            //            if (integerInputSecondPrintCount3.Value > 0)
            //                currentOrderDetails.SecondPrint3Count = integerInputSecondPrintCount3.Value;

            //            if (int.TryParse(txtSecondPrintSizePrice3.Text.Replace(",", ""), out var resultPrice))
            //                currentOrderDetails.SecondPrint3SizePrice = resultPrice;


            //            if (checkBoxLoadSecondPrintServices3.Checked)
            //            {
            //                if (cmbSecondPrintService3.Items.Count > 0)
            //                {
            //                    if (cmbSecondPrintService3.SelectedValue != null &&
            //                        int.TryParse(cmbSecondPrintService3.SelectedValue.ToString(),
            //                            out var result33))
            //                    {
            //                        currentOrderDetails.SecondPrint3ServiceId = result33;
            //                        currentOrderDetails.HasSecondPrint3Service = true;
            //                    }

            //                    if (integerInputSecondPrintServiceCount3.Value > 0)
            //                        currentOrderDetails.SecondPrint3ServiceCount =
            //                            integerInputSecondPrintServiceCount3.Value;
            //                    if (int.TryParse(txtSecondPrintServicePrice3.Text.Replace(",", ""), out var result))
            //                        currentOrderDetails.SecondPrint3ServicePrice = result;
            //                }
            //            }
            //        }
            //    }
            //}

            ///////
            // Second Print 4
            //
            //if (checkBoxSecondPrint4.Checked)
            //{
            //    if (cmbSecondPrintSize4.Items.Count > 0)
            //    {
            //        if (cmbSecondPrintSize4.SelectedValue != null &&
            //            int.TryParse(cmbSecondPrintSize4.SelectedValue.ToString(), out var result4))
            //        {
            //            currentOrderDetails.SecondPrint4SizeId = result4;
            //            currentOrderDetails.HasSecondPrint4 = true;

            //            if (integerInputSecondPrintCount4.Value > 0)
            //                currentOrderDetails.SecondPrint4Count = integerInputSecondPrintCount4.Value;

            //            if (int.TryParse(txtSecondPrintSizePrice4.Text.Replace(",", ""), out var resultPrice))
            //                currentOrderDetails.SecondPrint4SizePrice = resultPrice;


            //            if (checkBoxLoadSecondPrintServices4.Checked)
            //            {
            //                if (cmbSecondPrintService4.Items.Count > 0)
            //                {
            //                    if (cmbSecondPrintService4.SelectedValue != null &&
            //                        int.TryParse(cmbSecondPrintService4.SelectedValue.ToString(),
            //                            out var result44))
            //                    {
            //                        currentOrderDetails.SecondPrint4ServiceId = result44;
            //                        currentOrderDetails.HasSecondPrint4Service = true;
            //                    }

            //                    if (integerInputSecondPrintServiceCount4.Value > 0)
            //                        currentOrderDetails.SecondPrint4ServiceCount =
            //                            integerInputSecondPrintServiceCount4.Value;
            //                    if (int.TryParse(txtSecondPrintServicePrice4.Text.Replace(",", ""), out var result))
            //                        currentOrderDetails.SecondPrint4ServicePrice = result;
            //                }
            //            }
            //        }
            //    }
            //}


            // ReSharper disable once PossibleNullReferenceException
            var itemIndex = PhotoOrderDetailsList.FindIndex(x => x.StreamId == currentOrderDetails.StreamId);
            PhotoOrderDetailsList[itemIndex] = currentOrderDetails;

            //}

            ResetTextBoxesAndComboxes();

            // Load Previous Picture
            int lblCounter = _photoCursor;
            lblCurrentPhoto.Text = (lblCounter).ToString();
            _photoCursor--;

            if (_photoCursor == 0)
            {
                btnPreviousPhoto.Enabled = false;
            }

            var previousGuid = PhotoOrderDetailsList[_photoCursor].StreamId;
            var previousOrderDetails = PhotoOrderDetailsList.FirstOrDefault(x => x.StreamId == previousGuid);
            if (previousOrderDetails != null)
            {
                LoadPicture(previousGuid);

                ////Original Photo
                //
                if (previousOrderDetails.OriginalSizeId == 0)
                    cmbOriginalPrintSizes.SelectedIndex = -1;
                else
                {
                    cmbOriginalPrintSizes.SelectedValue = previousOrderDetails.OriginalSizeId;
                    cmbOriginalPrintSize_SelectedIndexChanged(null, null);
                }

                if (previousOrderDetails.HasOriginalPrintService)
                {
                    //rbOriginalNormalPrint.Checked = true;
                    if (previousOrderDetails.OriginalServiceId == 0)
                        cmbOriginalPrintServices.SelectedIndex = -1;
                    else
                    {
                        cmbOriginalPrintServices.SelectedValue = previousOrderDetails.OriginalServiceId;
                        //cmbOriginalPrintService_SelectedIndexChanged(null, null);
                    }
                }

                if (previousOrderDetails.RetouchDescriptions != null)
                    textPhotoRetouchDescription.Text = previousOrderDetails.RetouchDescriptions;

                pictureBoxIsAccepted.Image = previousOrderDetails.AcceptRejectImage ??
                                             Properties.Resources.iconfinder_flickr_317744;

                ////Second Photo
                ////SecondPrint1
                //if (previousOrderDetails.HasSecondPrint1)
                //{
                //    if (previousOrderDetails.SecondPrint1SizeId != 0)
                //    {
                //        checkBoxSecondPrint1.Checked = true;
                //        checkBoxSecondPrint1.CheckState = CheckState.Checked;
                //        cmbSecondPrintSize1.SelectedValue = previousOrderDetails.SecondPrint1SizeId;

                //        checkBoxSecondPrint1.Enabled = true;
                //        cmbSecondPrintSize1.Enabled = true;

                //        txtSecondPrintSizePrice1.Text =
                //            previousOrderDetails.SecondPrint1SizePrice.ToString("##,###");
                //        integerInputSecondPrintCount1.Value = previousOrderDetails.SecondPrint1Count;

                //        var ss = new SecondPrintSizeDataStructure
                //        {
                //            Count = integerInputSecondPrintCount1.Value,
                //            PrintSizeId = (int)cmbSecondPrintSize1.SelectedValue,
                //            TextBoxName = txtSecondPrintSizePrice1.Name,
                //            PreviousSizeId = previousOrderDetails.SecondPrint1SizeId
                //        };
                //        cmbSecondPrintSize1_SelectedValueChanged(ss);
                //        if (previousOrderDetails.HasSecondPrint1Service)
                //        {
                //            if (previousOrderDetails.SecondPrint1SizeId != 0)
                //            {
                //                if (previousOrderDetails.HasSecondPrint1Service)
                //                {
                //                    if (previousOrderDetails.SecondPrint1ServiceId != 0)
                //                    {
                //                        checkBoxLoadSecondPrintServices1.Checked = true;
                //                        cmbSecondPrintService1.SelectedValue =
                //                            previousOrderDetails.SecondPrint1ServiceId;
                //                        integerInputSecondPrintServiceCount1.Value =
                //                            previousOrderDetails.SecondPrint1ServiceCount;

                //                        cmbSecondPrintService1_SelectedIndexChanged(null, null);
                //                    }
                //                }
                //            }
                //            else
                //                cmbSecondPrintSize1.SelectedIndex = -1;
                //        }
                //    }
                //    else
                //        cmbSecondPrintSize1.SelectedIndex = -1;
                //}


                ////Second Photo
                ////SecondPrint2
                //if (previousOrderDetails.HasSecondPrint2)
                //{
                //    if (previousOrderDetails.SecondPrint2SizeId != 0)
                //    {
                //        checkBoxSecondPrint2.Checked = true;
                //        checkBoxSecondPrint2.CheckState = CheckState.Checked;
                //        cmbSecondPrintSize2.SelectedValue = previousOrderDetails.SecondPrint2SizeId;

                //        checkBoxSecondPrint2.Enabled = true;
                //        cmbSecondPrintSize2.Enabled = true;

                //        txtSecondPrintSizePrice2.Text =
                //            previousOrderDetails.SecondPrint2SizePrice.ToString("##,###");
                //        integerInputSecondPrintCount2.Value = previousOrderDetails.SecondPrint2Count;

                //        var ss = new SecondPrintSizeDataStructure
                //        {
                //            Count = integerInputSecondPrintCount2.Value,
                //            PrintSizeId = (int)cmbSecondPrintSize2.SelectedValue,
                //            TextBoxName = txtSecondPrintSizePrice2.Name,
                //            PreviousSizeId = previousOrderDetails.SecondPrint2SizeId
                //        };
                //        cmbSecondPrintSize2_SelectedValueChanged(ss);
                //        if (previousOrderDetails.HasSecondPrint2Service)
                //        {
                //            if (previousOrderDetails.SecondPrint2SizeId != 0)
                //            {
                //                if (previousOrderDetails.HasSecondPrint2Service)
                //                {
                //                    if (previousOrderDetails.SecondPrint2ServiceId != 0)
                //                    {
                //                        checkBoxLoadSecondPrintServices2.Checked = true;
                //                        cmbSecondPrintService2.SelectedValue =
                //                            previousOrderDetails.SecondPrint2ServiceId;
                //                        integerInputSecondPrintServiceCount2.Value =
                //                            previousOrderDetails.SecondPrint2ServiceCount;

                //                        cmbSecondPrintService2_SelectedIndexChanged(null, null);
                //                    }
                //                }
                //            }
                //            else
                //                cmbSecondPrintSize2.SelectedIndex = -1;
                //        }
                //    }
                //    else
                //        cmbSecondPrintSize2.SelectedIndex = -1;
                //}

                ////Second Photo
                ////SecondPrint3
                //if (previousOrderDetails.HasSecondPrint3)
                //{
                //    if (previousOrderDetails.SecondPrint3SizeId != 0)
                //    {
                //        checkBoxSecondPrint3.Checked = true;
                //        checkBoxSecondPrint3.CheckState = CheckState.Checked;
                //        cmbSecondPrintSize3.SelectedValue = previousOrderDetails.SecondPrint3SizeId;

                //        checkBoxSecondPrint3.Enabled = true;
                //        cmbSecondPrintSize3.Enabled = true;

                //        txtSecondPrintSizePrice3.Text =
                //            previousOrderDetails.SecondPrint3SizePrice.ToString("##,###");
                //        integerInputSecondPrintCount3.Value = previousOrderDetails.SecondPrint3Count;

                //        var ss = new SecondPrintSizeDataStructure
                //        {
                //            Count = integerInputSecondPrintCount3.Value,
                //            PrintSizeId = (int)cmbSecondPrintSize3.SelectedValue,
                //            TextBoxName = txtSecondPrintSizePrice3.Name,
                //            PreviousSizeId = previousOrderDetails.SecondPrint3SizeId
                //        };
                //        cmbSecondPrintSize3_SelectedValueChanged(ss);
                //        if (previousOrderDetails.HasSecondPrint3Service)
                //        {
                //            if (previousOrderDetails.SecondPrint3SizeId != 0)
                //            {
                //                if (previousOrderDetails.HasSecondPrint3Service)
                //                {
                //                    if (previousOrderDetails.SecondPrint3ServiceId != 0)
                //                    {
                //                        checkBoxLoadSecondPrintServices3.Checked = true;
                //                        cmbSecondPrintService3.SelectedValue =
                //                            previousOrderDetails.SecondPrint3ServiceId;
                //                        integerInputSecondPrintServiceCount3.Value =
                //                            previousOrderDetails.SecondPrint3ServiceCount;

                //                        cmbSecondPrintService3_SelectedIndexChanged(null, null);
                //                    }
                //                }
                //            }
                //            else
                //                cmbSecondPrintSize3.SelectedIndex = -1;
                //        }
                //    }
                //    else
                //        cmbSecondPrintSize3.SelectedIndex = -1;
                //}


                ////Second Photo
                ////SecondPrint4
                //    if (previousOrderDetails.HasSecondPrint4)
                //    {
                //        if (previousOrderDetails.SecondPrint4SizeId != 0)
                //        {
                //            checkBoxSecondPrint4.Checked = true;
                //            checkBoxSecondPrint4.CheckState = CheckState.Checked;
                //            cmbSecondPrintSize4.SelectedValue = previousOrderDetails.SecondPrint4SizeId;

                //            checkBoxSecondPrint4.Enabled = true;
                //            cmbSecondPrintSize4.Enabled = true;

                //            txtSecondPrintSizePrice4.Text =
                //                previousOrderDetails.SecondPrint4SizePrice.ToString("##,###");
                //            integerInputSecondPrintCount4.Value = previousOrderDetails.SecondPrint4Count;

                //            var ss = new SecondPrintSizeDataStructure
                //            {
                //                Count = integerInputSecondPrintCount4.Value,
                //                PrintSizeId = (int)cmbSecondPrintSize4.SelectedValue,
                //                TextBoxName = txtSecondPrintSizePrice4.Name,
                //                PreviousSizeId = previousOrderDetails.SecondPrint4SizeId
                //            };
                //            cmbSecondPrintSize4_SelectedValueChanged(ss);
                //            if (previousOrderDetails.HasSecondPrint4Service)
                //            {
                //                if (previousOrderDetails.SecondPrint4SizeId != 0)
                //                {
                //                    if (previousOrderDetails.HasSecondPrint4Service)
                //                    {
                //                        if (previousOrderDetails.SecondPrint4ServiceId != 0)
                //                        {
                //                            checkBoxLoadSecondPrintServices4.Checked = true;
                //                            cmbSecondPrintService4.SelectedValue =
                //                                previousOrderDetails.SecondPrint4ServiceId;
                //                            integerInputSecondPrintServiceCount4.Value =
                //                                previousOrderDetails.SecondPrint4ServiceCount;

                //                            cmbSecondPrintService4_SelectedIndexChanged(null, null);
                //                        }
                //                    }
                //                }
                //                else
                //                    cmbSecondPrintSize4.SelectedIndex = -1;
                //            }
                //        }
                //        else
                //            cmbSecondPrintSize4.SelectedIndex = -1;
                //    }
                //}
                //}
                //catch (Exception exception)
                //{
                //    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                //        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                //}
            }
        }


        #endregion

        private void chkOriginalHasChangingElements_CheckedChanged(object sender, EventArgs e)
        {
            btnOriginalChangingElements.Enabled = chkOriginalHasChangingElements.Checked;
        }

        private void chkRePrintHasChangingElements_CheckedChanged(object sender, EventArgs e)
        {
            btnRePrintChangingElements.Enabled = chkRePrintHasChangingElements.Checked;
        }
    }
}
