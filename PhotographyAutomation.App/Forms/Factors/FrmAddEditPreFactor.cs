using PhotographyAutomation.App.Forms.Photos;
using PhotographyAutomation.App.Forms.PrintSizeAndServices;
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ookii.Dialogs.WinForms;
using Exception = System.Exception;

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


        private int _photoCursor;
        private int _selectedOriginalSizeId;
        private int _selectedRePrintSizeId;

        private OrderPrintViewModel _orderPrintViewModel;

        private static List<PrintSizesViewModel> _listOriginalPrintSizes;
        private static List<PrintSizesViewModel> _listRePrintPrintSizes;

        private List<PrintServicesViewModel> _listOriginalPrintSizePrintServices;
        private List<PrintServicesViewModel> _listRePrintPrintSizePrintServices;

        private static List<PrintSizePricesViewModel> _listOriginalPrintSizePrices;
        private static List<PrintSizePricesViewModel> _listRePrintPrintSizePrices;

        private static List<PrintServicesViewModel> _listOriginalPrintServicePrices;
        private static List<PrintServicesViewModel> _listRePrintPrintServicePrices;

        private static List<TblPrintSpecialServices> _listOriginalPrintSpecialServices;
        private static List<TblPrintSpecialServices> _listRePrintPrintSpecialServices;

        public List<OrderDetails> OrderDetailsList;

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
            try
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

                    //_listOrderPrintDetails=new List<TblOrderPrintDetails>(FileStreamsGuids.Count);
                    //OrderDetailsList = new List<OrderDetails>(FileStreamsGuids.Count);
                }
                else
                {
                    var exception = new Exception(
                        @"متاسفانه اطلاعات سفارش قابل دریافت نمی باشد. " +
                        Environment.NewLine +
                        @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.");
                    throw exception;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    exception.Message,
                    @"خطا در دریافت اطلاعات از سرور",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
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
            try
            {
                using (var db = new UnitOfWork())
                {
                    _listOriginalPrintSizes = db.PrintSizeRepository.GetAllPrintSizes();
                    _listRePrintPrintSizes = db.PrintSizeRepository.GetAllPrintSizes();

                    _listOriginalPrintSizePrices = db.PrintSizePriceRepository.GetAllPrintSizePrices();
                    _listRePrintPrintSizePrices = db.PrintSizePriceRepository.GetAllPrintSizePrices();



                    _listOriginalPrintServicePrices =
                        db.PrintServicePricesGenericRepository
                            .Get()
                            .Select(x => new PrintServicesViewModel
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
                            })
                            .ToList();
                    _listRePrintPrintServicePrices =
                        db.PrintServicePricesGenericRepository
                        .Get()
                        .Select(x => new PrintServicesViewModel
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
                        })
                        .ToList();



                    _listOriginalPrintSpecialServices = db.PrintSpecialServicesGenericRepository.Get().ToList();
                    _listRePrintPrintSpecialServices = db.PrintSpecialServicesGenericRepository.Get().ToList();



                    TblOrder orderInfo = db.OrderGenericRepository.GetById(OrderId);
                    TblOrderPrint orderPrintInfo = db.OrderPrintGenericRepository.GetById(OrderPrintId);
                    TblCustomer customerInfo = db.CustomerGenericRepository.GetById(CustomerId);
                    TblOrderPrintStatus orderPrintStatusInfo;
                    TblPhotographyType photographyType;

                    if (orderPrintInfo != null)
                    {
                        orderPrintStatusInfo =
                            db.OrderPrintStatusGenericRepository.GetById(orderPrintInfo.OrderPrintStatusId);
                    }
                    else
                    {
                        throw new Exception(
                            @"اطلاعات سفارش فایل دریافت نمی باشد." +
                            Environment.NewLine +
                            @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.");
                    }

                    if (orderInfo != null)
                    {
                        photographyType = db.PhotographyTypesGenericRepository.GetById(orderInfo.PhotographyTypeId);
                    }
                    else
                    {
                        throw new Exception(
                            @"اطلاعات سفارش فایل دریافت نمی باشد." +
                            Environment.NewLine +
                            @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.");
                    }

                    if (customerInfo == null || orderPrintStatusInfo == null)
                    {
                        throw new Exception(
                            @"اطلاعات سفارش فایل دریافت نمی باشد." +
                            Environment.NewLine +
                            @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.");
                    }
                    //if (orderPrintInfo != null && orderInfo != null)
                    //{

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

                    //}
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    exception.Message,
                    @"خطا در دریافت اطلاعات از سرور",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.Cancel;
            }
        }
        private void _bgWorkerLoadPrintSizeAndServicesInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                cmbOriginalPrintSize.Enabled = !_bgWorkerLoadPrintSizeAndServicesInfo.IsBusy;
                circularProgress.IsRunning = _bgWorkerLoadPrintSizeAndServicesInfo.IsBusy;

                if (_orderPrintViewModel != null)
                {
                    txtOrderCodeDate.Text = _orderPrintViewModel.OrderCode.Substring(0, 7);
                    txtOrderCodeCustomerIdBookingId.Text = _orderPrintViewModel.OrderCode.Substring(8);
                    txtCustomerName.Text = _orderPrintViewModel.CustomerFirstName
                                           + @" " +
                                           _orderPrintViewModel.CustomerLastName;

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
                    cmbOriginalPrintSize.DataSource = _listOriginalPrintSizes;
                    cmbOriginalPrintSize.DisplayMember = "Name";
                    cmbOriginalPrintSize.ValueMember = "Id";


                    cmbRePrintPrintSize.DataSource = _listRePrintPrintSizes;
                    cmbRePrintPrintSize.DisplayMember = "Name";
                    cmbRePrintPrintSize.ValueMember = "Id";


                    if (_listOriginalPrintSizes.FirstOrDefault() != null)
                    {
                        txtOriginalMinimumOrder.Text = _listOriginalPrintSizes.First().MinimumOrder.ToString();

                        txtTotalPriceOriginalPrintSize.Text =
                            _listOriginalPrintSizePrices.First().FirstPrintPrice?.ToString("N0");


                        txtRePrintMinimumOrder.Text = _listRePrintPrintSizes.First().MinimumOrder.ToString();
                        if (_listRePrintPrintSizes.First().MinimumOrder > 1)
                            txtRePrintTotalPrintCounts.Visible = true;
                        txtTotalPriceRePrintPrintSize.Text =
                            _listRePrintPrintSizePrices.First().FirstPrintPrice?.ToString("N0");
                    }

                    cmbOriginalPrintSize.Focus();
                }
            }
            catch (Exception exception)
            {
                //ignored
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


        #region Original Print

        private void cmbOriginalPrintSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkHasOriginalPrintService.Checked = false;
            rbOriginalMultiPhoto.Checked = false;
            rbOriginalLitPrint.Checked = false;

            if (cmbOriginalPrintSize.SelectedIndex == -1) return;

            try
            {
                var resultSelectedOriginalPrintSizeId =
                    int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(),
                                   out var selectedOriginalPrintSizeId);

                if (cmbOriginalPrintSize.SelectedIndex != -1 && resultSelectedOriginalPrintSizeId)
                {
                    _selectedOriginalSizeId = selectedOriginalPrintSizeId;

                    PrintSizesViewModel printSize = _listOriginalPrintSizes
                                                    .FirstOrDefault(x => x.Id == _selectedOriginalSizeId);
                    if (printSize != null)
                    {
                        txtOriginalMinimumOrder.Text = printSize.MinimumOrder.ToString();
                        if (printSize.HasLitPrint)
                        {
                            rbOriginalLitPrint.Enabled = true;
                        }
                        else
                        {
                            rbOriginalLitPrint.Enabled = false;
                            btnOriginalShowFrmAddEditLitPrint.Enabled = false;
                        }
                    }
                    GetOriginalPrintSizePrice(_selectedOriginalSizeId);


                    List<PrintServicesViewModel> originalPrintServices = _listOriginalPrintServicePrices
                                                                        .Where(x => x.PrintSizeId == _selectedOriginalSizeId)
                                                                        .ToList();

                    if (originalPrintServices.Any())
                    {
                        chkHasOriginalPrintService.Enabled = true;
                        _listOriginalPrintSizePrintServices = originalPrintServices;
                        cmbOriginalPrintServices.DataSource = _listOriginalPrintSizePrintServices;
                        cmbOriginalPrintServices.DisplayMember = "PrintServiceName";
                        cmbOriginalPrintServices.ValueMember = "Id";

                        int? firstPrintServicePrice = _listOriginalPrintServicePrices
                                                      .FirstOrDefault(x => x.PrintSizeId == _selectedOriginalSizeId)?
                                                      .PrintServicePrice;

                        txtOriginalServicePrice.Text = firstPrintServicePrice?.ToString("N0");
                    }
                    else
                    {
                        chkHasOriginalPrintService.Checked = false;
                        chkHasOriginalPrintService.Enabled = false;

                        cmbOriginalPrintServices.DataSource = null;
                        cmbOriginalPrintServices.Enabled = false;

                        txtOriginalServicePrice.Text = null;
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
                    var printSizePrice = _listOriginalPrintSizePrices
                                        .FirstOrDefault(x => x.PrintSizeId == printSizeId);
                    if (printSizePrice != null)
                        txtTotalPriceOriginalPrintSize.Text =
                            printSizePrice.FirstPrintPrice?.ToString("N0");
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }





        private void chkHasOriginalPrintService_CheckedChanged(object sender, EventArgs e)
        {
            //Get First Print Service Price
            bool selectedPrintSizeIdResult =
                int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out int selectedPrintSizeId);

            if (selectedPrintSizeIdResult /*&& selectedPrintServiceIdResult*/ && _listOriginalPrintServicePrices != null)
            {
                int? printServicePrice = _listOriginalPrintServicePrices
                    .FirstOrDefault(x => x.PrintSizeId == selectedPrintSizeId
                        /*&& x.PrintServiceId == selectedPrintServiceId*/)?.PrintServicePrice;
                txtOriginalServicePrice.Text = printServicePrice?.ToString("N0");
            }

            if (chkHasOriginalPrintService.Checked)
            {
                cmbOriginalPrintServices.Enabled =
                    txtOriginalServicePrice.Enabled =
                        true;

                txtTotalPriceOriginalServices.Text = txtOriginalServicePrice.Text;

                //cmbOriginalPrintServices.SelectedIndex = 0;
                //bool selectedPrintServiceIdResult =
                //    int.TryParse(cmbOriginalPrintServices.SelectedValue.ToString(), out int selectedPrintServiceId);

            }
            else
            {
                cmbOriginalPrintServices.Enabled =
                    txtOriginalServicePrice.Enabled =
                        false;

                //txtOriginalServicePrice.Text = null;
                //txtOriginalServicePrice.WatermarkEnabled = true;
                //txtOriginalServicePrice.WatermarkText = "هزینه خدمات (ريال)";

                txtTotalPriceOriginalServices.Text = null;
                txtTotalPriceOriginalServices.WatermarkText = "هزینه خدمات (ريال)";
            }
        }
        private void cmbOriginalPrintService_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                cmbOriginalPrintServices.DataSource = _listOriginalPrintSizePrintServices;
                cmbOriginalPrintServices.DisplayMember = "PrintServiceName";
                cmbOriginalPrintServices.ValueMember = "Id";
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void cmbOriginalPrintServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOriginalPrintServices.SelectedIndex == -1) return;
            try
            {
                if (chkHasOriginalPrintService.Enabled &&
                    cmbOriginalPrintServices.Enabled &&
                    cmbOriginalPrintServices.Items.Count > 0 &&
                    cmbOriginalPrintServices.SelectedIndex != -1 &&
                    int.TryParse(cmbOriginalPrintServices.SelectedValue.ToString(),
                        out var selectedPrintServicePriceId))
                {
                    txtOriginalServicePrice.Text = null;

                    txtTotalPriceOriginalServices.Text =
                        txtOriginalServicePrice.Text =
                            GetOriginalPrintServicePrice(selectedPrintServicePriceId);
                }
                else
                {
                    txtOriginalServicePrice.Text = null;
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private static string GetOriginalPrintServicePrice(int selectedPrintServicePriceId)
        {
            var price = _listOriginalPrintServicePrices
                            .Single(x => x.Id == selectedPrintServicePriceId)
                            .PrintServicePrice.ToString("N0");
            return price;
        }





        private void RbOriginalMultiPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOriginalMultiPhoto.Checked)
            {
                btnOriginalShowFrmAddEditMutiPhotos.Enabled = true;
                //lblOriginalMutiPhotosCounts.Enabled = true;
                txtOriginalMultiPhotoPrice.Enabled = true;

                //کد هزینه دورچین =10 
                txtOriginalMultiPhotoPrice.Text =
                    GetOriginalMultiPhotoPricePerPhoto(code: "10");
            }
            else
            {
                btnOriginalShowFrmAddEditMutiPhotos.Enabled = false;
                txtOriginalMutiPhotoSelectedPhotos.Text = @"---";
                txtOriginalMultiPhotoPrice.Enabled = false;
            }
        }
        private static string GetOriginalMultiPhotoPricePerPhoto(string code)
        {
            var servicePrice = string.Empty;
            if (_listOriginalPrintSpecialServices != null)
            {
                servicePrice = _listOriginalPrintSpecialServices.Find(x => x.Code == code).Price.ToString("N0");
            }

            return servicePrice;
        }





        private void RbOriginalLitPrint_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbOriginalLitPrint.Checked &&
                    int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out int selectedPrintSizeId)
                    )

                {
                    GetOriginalLitPrintPrice(selectedPrintSizeId);
                    btnOriginalShowFrmAddEditLitPrint.Enabled =
                        txtOriginalLitPrintPrice.Enabled = rbOriginalLitPrint.Checked;
                }
                else
                {
                    btnOriginalShowFrmAddEditLitPrint.Enabled =
                        txtOriginalLitPrintPrice.Enabled = rbOriginalLitPrint.Checked;
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





        private void ChkOriginalHasChangingElements_CheckedChanged(object sender, EventArgs e)
        {
            btnOriginalChangingElements.Enabled = chkOriginalHasChangingElements.Checked;
        }




        private void BtnOriginalCustomPrintSize_Click(object sender, EventArgs e)
        {
            using (var f = new FrmAddEditPrintSize())
            {
                f.IsNewPrintSize = true;
                f.HasSizePriceBefore = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadPrintSizeAndServicesInfo();
                }
            }
        }
        private void BtnOriginalShowFrmAddEditMutiPhotos_Click(object sender, EventArgs e)
        {
            tabControlPrintSizeAndServices.SelectedTab = tabPageMultiPhoto;

            rbOriginalPhotoMultiPhoto.Checked = true;
            rbOriginalPhotoMultiPhoto.CheckState = CheckState.Checked;

            rbRePrintPhotoMultiPhoto.Checked = false;
            rbRePrintPhotoMultiPhoto.CheckState = CheckState.Unchecked;

            if (int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out var selectedPrintSize))
            {
                lblPrintSizeMultiPhoto.Text =
                    _listOriginalPrintSizes.SingleOrDefault(x => x.Id == selectedPrintSize)?.Name;
            }

        }
        private void BtnOriginalShowFrmAddEditLitPrint_Click(object sender, EventArgs e)
        {
            tabControlPrintSizeAndServices.SelectedTab = tabPageLitPrint;

            rbOriginalPhotoLitPrint.Checked = true;
            rbOriginalPhotoLitPrint.CheckState = CheckState.Checked;

            rbRePrintPhotoLitPrint.Checked = false;
            rbRePrintPhotoLitPrint.CheckState = CheckState.Unchecked;

            if (int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out var selectedPrintSize))
            {
                lblPrintSizeLitPrint.Text =
                    _listOriginalPrintSizes.SingleOrDefault(x => x.Id == selectedPrintSize)?.Name;
            }
        }
        private void BtnOriginalChangingElements_Click(object sender, EventArgs e)
        {
            tabControlPrintSizeAndServices.SelectedTab = tabPageChangingElements;

            rbOriginalPhotoChangingElements.Checked = true;
            rbOriginalPhotoChangingElements.CheckState = CheckState.Checked;

            rbRePrintPhotoChangingElements.Checked = false;
            rbRePrintPhotoChangingElements.CheckState = CheckState.Unchecked;

            if (int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out var selectedPrintSize))
            {
                lblPrintSizeChangingElements.Text =
                    _listOriginalPrintSizes.SingleOrDefault(x => x.Id == selectedPrintSize)?.Name;
            }
        }


        #endregion


        #region RePrint


        private void cmbRePrintSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkHasRePrintPrintService.Checked = false;
            rbRePrintMultiPhoto.Checked = false;
            rbRePrintLitPrint.Checked = false;

            if (cmbRePrintPrintSize.SelectedIndex == -1) return;

            try
            {
                var resultSelectedRePrintPrintSizeId =
                    int.TryParse(cmbRePrintPrintSize.SelectedValue.ToString(),
                        out var selectedRePrintPrintSizeId);

                if (cmbRePrintPrintSize.SelectedIndex != -1 && resultSelectedRePrintPrintSizeId)
                {
                    _selectedRePrintSizeId = selectedRePrintPrintSizeId;

                    PrintSizesViewModel printSize = _listRePrintPrintSizes
                                                    .FirstOrDefault(x => x.Id == _selectedRePrintSizeId);

                    if (printSize != null)
                    {
                        txtRePrintMinimumOrder.Text = printSize.MinimumOrder.ToString();
                        txtRePrintTotalPrintCounts.Visible = printSize.MinimumOrder > 1;
                        if (printSize.HasLitPrint)
                        {
                            rbRePrintLitPrint.Enabled = true;
                        }
                        else
                        {
                            rbRePrintLitPrint.Enabled = false;
                            btnRePrintShowFrmAddEditLitPrint.Enabled = false;
                        }
                    }
                    GetRePrintPrintSizePrice(_selectedRePrintSizeId);


                    List<PrintServicesViewModel> rePrintPrintServices =
                        _listRePrintPrintServicePrices
                        .Where(x => x.PrintSizeId == _selectedRePrintSizeId)
                        .ToList();
                    if (rePrintPrintServices.Any())
                    {
                        chkHasRePrintPrintService.Enabled = true;
                        _listRePrintPrintSizePrintServices = rePrintPrintServices;
                        cmbRePrintPrintServices.DisplayMember = "PrintServiceName";
                        cmbRePrintPrintServices.ValueMember = "Id";
                    }
                    else
                    {
                        chkHasRePrintPrintService.Checked = false;
                        chkHasRePrintPrintService.Enabled = false;

                        cmbRePrintPrintServices.Enabled = false;
                        cmbRePrintPrintServices.DataSource = null;

                        txtRePrintServicePrice.Text = null;
                    }
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void GetRePrintPrintSizePrice(int printSizeId)
        {
            try
            {
                if (_listRePrintPrintSizes != null)
                {
                    var printSize = _listRePrintPrintSizePrices
                                        .FirstOrDefault(x => x.PrintSizeId == printSizeId);
                    if (printSize?.RePrintPrice != null)
                    {
                        int printSizePrice = printSize.RePrintPrice.Value;
                        int printCounts = iiRePrintPrintCounts.Value;
                        int totalPrice = printSizePrice * printCounts;
                        int minimumOrder = int.Parse(txtRePrintMinimumOrder.Text);
                        txtRePrintTotalPrintCounts.Text = (minimumOrder * printCounts).ToString();
                        txtTotalPriceRePrintPrintSize.Text = totalPrice.ToString("N0");
                    }
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }





        private void chkHasRePrintPrintService_CheckedChanged(object sender, EventArgs e)
        {
            cmbRePrintPrintServices.Enabled =
                txtRePrintServicePrice.Enabled =
                    iiRePrintServiceCounts.Enabled =
                        chkHasRePrintPrintService.Checked;
        }
        private void cmbRePrintPrintServices_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                cmbRePrintPrintServices.DataSource = _listRePrintPrintSizePrintServices;
                cmbRePrintPrintServices.DisplayMember = "PrintServiceName";
                cmbRePrintPrintServices.ValueMember = "Id";
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void cmbRePrintPrintServices_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkHasRePrintPrintService.Enabled &&
                    cmbRePrintPrintServices.Items.Count > 0 &&
                    int.TryParse(cmbRePrintPrintServices.SelectedValue.ToString(),
                        out var selectedPrintServicePriceId))
                {
                    GetRePrintPrintServicePrice(selectedPrintServicePriceId);
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void GetRePrintPrintServicePrice(int selectedPrintServicePriceId)
        {
            txtRePrintServicePrice.Text = null;
            txtRePrintServicePrice.Text = _listRePrintPrintServicePrices
                .Single(x => x.Id == selectedPrintServicePriceId)
                .PrintServicePrice.ToString("N0");
        }





        private void RbRePrintMultiPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRePrintMultiPhoto.Checked)
            {
                btnRePrintShowFrmAddEditMutiPhotos.Enabled = true;
                //lblRePrintMutiPhotosCounts.Enabled = true;
                txtRePrintMultiPhotoPrice.Enabled = true;

                //کد هزینه دورچین =10 
                txtRePrintMultiPhotoPrice.Text =
                    GetRePrintMultiPhotoPricePerPhoto(code: "10");
            }
            else
            {
                btnRePrintShowFrmAddEditMutiPhotos.Enabled = false;
                txtRePrintMultiPhotoSelectedPhotos.Text = @"---";
                txtRePrintMultiPhotoPrice.Enabled = false;
            }
        }
        private static string GetRePrintMultiPhotoPricePerPhoto(string code)
        {
            var servicePrice = string.Empty;
            if (_listRePrintPrintSpecialServices != null)
            {
                servicePrice = _listRePrintPrintSpecialServices.Find(x => x.Code == code).Price.ToString("N0");
            }

            return servicePrice;
        }





        private void RbRePrintLitPrint_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbRePrintLitPrint.Checked &&
                    int.TryParse(cmbRePrintPrintSize.SelectedValue.ToString(), out int selectedPrintSizeId)
                )

                {
                    GetRePrintLitPrintPrice(selectedPrintSizeId);
                    btnRePrintShowFrmAddEditLitPrint.Enabled =
                        txtRePrintLitPrintPrice.Enabled = rbRePrintLitPrint.Checked;
                }
                else
                {
                    btnRePrintShowFrmAddEditLitPrint.Enabled =
                        txtRePrintLitPrintPrice.Enabled = rbRePrintLitPrint.Checked;
                    txtRePrintLitPrintPrice.Text = string.Empty;
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }
        private void GetRePrintLitPrintPrice(int selectedPrintSizeId)
        {
            try
            {
                var printSize = _listRePrintPrintSizes.Find(x => x.Id == selectedPrintSizeId);
                if (printSize.HasLitPrint)
                    txtTotalPriceRePrintPrintSize.Text = printSize.LitPrintPrice?.ToString("N0");
            }
            catch (Exception exception)
            {
                //ignored
            }
        }





        private void chkRePrintHasChangingElements_CheckedChanged(object sender, EventArgs e)
        {
            btnRePrintChangingElements.Enabled = chkRePrintHasChangingElements.Checked;
        }




        private void btnRePrintCustomPrintSize_Click(object sender, EventArgs e)
        {

        }
        private void btnRePrintShowFrmAddEditMutiPhotos_Click(object sender, EventArgs e)
        {
            tabControlPrintSizeAndServices.SelectedTab = tabPageMultiPhoto;

            rbRePrintPhotoMultiPhoto.Checked = true;
            rbRePrintPhotoMultiPhoto.CheckState = CheckState.Checked;

            rbOriginalPhotoMultiPhoto.Checked = false;
            rbOriginalPhotoMultiPhoto.CheckState = CheckState.Unchecked;

            


            if (int.TryParse(cmbRePrintPrintSize.SelectedValue.ToString(), out var selectedPrintSize))
            {
                lblPrintSizeMultiPhoto.Text =
                    _listRePrintPrintSizes.SingleOrDefault(x => x.Id == selectedPrintSize)?.Name;
            }
        }
        private void btnRePrintShowFrmAddEditLitPrint_Click(object sender, EventArgs e)
        {
            tabControlPrintSizeAndServices.SelectedTab = tabPageLitPrint;

            rbRePrintPhotoLitPrint.Checked = true;
            rbRePrintPhotoLitPrint.CheckState = CheckState.Checked;

            rbOriginalPhotoLitPrint.Checked = false;
            rbOriginalPhotoLitPrint.CheckState = CheckState.Unchecked;

            


            if (int.TryParse(cmbRePrintPrintSize.SelectedValue.ToString(), out var selectedPrintSize))
            {
                lblPrintSizeLitPrint.Text =
                    _listRePrintPrintSizes.SingleOrDefault(x => x.Id == selectedPrintSize)?.Name;
            }
        }
        private void btnRePrintChangingElements_Click(object sender, EventArgs e)
        {
            tabControlPrintSizeAndServices.SelectedTab = tabPageChangingElements;

            rbRePrintPhotoChangingElements.Checked = true;
            rbRePrintPhotoChangingElements.CheckState = CheckState.Checked;

            rbOriginalPhotoChangingElements.Checked = false;
            rbOriginalPhotoChangingElements.CheckState = CheckState.Unchecked;

           


            if (int.TryParse(cmbRePrintPrintSize.SelectedValue.ToString(), out var selectedPrintSize))
            {
                lblPrintSizeChangingElements.Text =
                    _listRePrintPrintSizes.SingleOrDefault(x => x.Id == selectedPrintSize)?.Name;
            }
        }



        private void iiRePrintPrintCounts_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(cmbRePrintPrintSize.SelectedValue.ToString(), out int selectedPrintSizeId))
                {
                    GetRePrintPrintSizePrice(selectedPrintSizeId);
                }
            }
            catch (NullReferenceException exception)
            {
                //ignored
            }
            catch (Exception exception)
            {
                //ignored
            }
        }

        #endregion


        #region Methods

        private void ResetTextBoxesAndComboxes()
        {
            #region Original Print Size Service

            //textPhotoRetouchDescription.Text=null;
            //txtOriginalPrintServicePrice.Text=null;
            ////cmbOriginalPrintService.SelectedIndex = -1;
            //cmbOriginalPrintServices.Enabled = false;
            //rbOriginalMultiPhoto.Checked = false;
            //rbOriginalLitPrint.Enabled = false;
            //txtOriginalPrintSizePrice.Text=null;
            //cmbOriginalPrintSize.SelectedIndex = -1;

            #endregion
        }

        //private void CalculateTotalPhotosConfirmed()
        //{
        //    var totalPhotosConfirmed = 0;
        //    foreach (var photo in PhotoOrderDetailsList)
        //    {
        //        if (photo.IsAccepted == 1)
        //            totalPhotosConfirmed++;
        //    }

        //    txtTotalSelectedPhotos.Text = totalPhotosConfirmed.ToString();
        //}
        //private void CaculateTotalPhotoServicesConfirmed()
        //{
        //    var totalPhotoServices = 0;
        //    foreach (var photo in PhotoOrderDetailsList)
        //    {
        //        if (photo.HasOriginalPrintService && photo.OriginalServiceId > 0)
        //            totalPhotoServices++;
        //        if (photo.HasSecondPrint1Service && photo.SecondPrint1ServiceId > 0)
        //            totalPhotoServices += photo.SecondPrint1ServiceCount;
        //        if (photo.HasSecondPrint2Service && photo.SecondPrint2ServiceId > 0)
        //            totalPhotoServices += photo.SecondPrint2ServiceCount;
        //        if (photo.HasSecondPrint3Service && photo.SecondPrint3ServiceId > 0)
        //            totalPhotoServices += photo.SecondPrint3ServiceCount;
        //        if (photo.HasSecondPrint4Service && photo.SecondPrint4ServiceId > 0)
        //            totalPhotoServices += photo.SecondPrint4ServiceCount;
        //    }

        //    txtTotalPrintServices.Text = totalPhotoServices.ToString();
        //}

        #endregion


        #region Buttons
        //btnOkOriginalPrint
        private int CalculateOriginalPrintTotalPrice()
        {
            int.TryParse(txtTotalPriceOriginalPrintSize.Text.Replace(",", ""), out var totalPriceOriginalPrintSize);
            int.TryParse(txtTotalPriceOriginalMutiPhoto.Text.Replace(",", ""), out var totalPriceOriginalMutiPhoto);
            int.TryParse(txtTotalPriceOriginalLitPrint.Text.Replace(",", ""), out var totalPriceOriginalLitPrint);
            int.TryParse(txtTotalPriceOriginalServices.Text.Replace(",", ""), out var totalPriceOriginalServices);

            int result = totalPriceOriginalPrintSize + totalPriceOriginalMutiPhoto + totalPriceOriginalLitPrint + totalPriceOriginalServices;
            return result;
        }
        private void ResetOriginalPrintControls()
        {
            cmbOriginalPrintSize.SelectedIndex = -1;
            rbOriginalMultiPhoto.Checked = false;
            rbOriginalLitPrint.Checked = false;
            chkOriginalHasChangingElements.Checked = false;

            chkHasOriginalPrintService.Checked = false;
            cmbOriginalPrintServices.SelectedIndex = -1;
            cmbOriginalPrintServices.Enabled = false;

            txtOriginalMinimumOrder.Text = null;
            txtOriginalMultiPhotoPrice.Text = null;
            txtOriginalLitPrintPrice.Text = null;
            txtOriginalServicePrice.Text = null;

            txtTotalPriceOriginalPrintSize.Text = null;
            txtTotalPriceOriginalMutiPhoto.Text = null;
            txtTotalPriceOriginalLitPrint.Text = null;
            txtTotalPriceOriginalServices.Text = null;
            txtTotalPriceOriginal.Text = null;

            txtOriginalPhotoRetouchDescription.Text = null;
        }
        private void ResetOrderItemValues(OrderDetails orderDetailsItem)
        {
            var newOrderDetails = new OrderDetails
            {
                CreatedDateTime = orderDetailsItem.CreatedDateTime,
                CustomerId = orderDetailsItem.CustomerId,
                FileName = orderDetailsItem.FileName,
                Id = orderDetailsItem.Id,
                ModifiedDateTime = orderDetailsItem.ModifiedDateTime,
                OrderPrintId = orderDetailsItem.OrderPrintId,
                StreamId = orderDetailsItem.StreamId,
                IsFirstprint = orderDetailsItem.IsFirstprint
            };
            var itemIndex = OrderDetailsList.FindIndex(x => x.StreamId == orderDetailsItem.StreamId);
            OrderDetailsList[itemIndex] = newOrderDetails;
        }


        private void btnOkOriginalPrint_Click(object sender, EventArgs e)
        {
            var currentGuid = OrderDetailsList[_photoCursor].StreamId;
            var orderItem = new OrderDetails
            {
                OrderPrintId = OrderPrintId,
                CustomerId = CustomerId,
                StreamId = currentGuid,
                FileName = lblPhotoName.Text,
                IsAccepted = true,
                PrintSizeId = (int)cmbOriginalPrintSize.SelectedValue,
                RetouchDescription = txtOriginalPhotoRetouchDescription.Text,
                CreatedDateTime = DateTime.Now,
                IsFirstprint = true,
            };

            if (chkHasOriginalPrintService.Checked && cmbOriginalPrintServices.Enabled &&
                int.TryParse(cmbOriginalPrintServices.SelectedValue.ToString(),
                    out int selectedPrintServiceId))
            {
                orderItem.HasPrintService = true;
                orderItem.PrintServiceId = selectedPrintServiceId;

                int servicePriceId = 0;
                PrintServicesViewModel printServicesViewModel = _listOriginalPrintServicePrices?.SingleOrDefault(x => x.Id == selectedPrintServiceId);

                if (printServicesViewModel != null) servicePriceId = printServicesViewModel.PrintServicePrice;
                orderItem.PrintServicePriceId = servicePriceId;
            }

            orderItem.TotalPrice = CalculateOriginalPrintTotalPrice();


            //چک کن قبلا در لیست سفارشات وجود دارد  
            //اگر وجود دارد پیامی نشان دهد و آن را در صورت تائید آپدیت کند

            var check = OrderDetailsList
                        .SingleOrDefault(x => x.StreamId == orderItem.StreamId &&
                                              x.IsFirstprint == orderItem.IsFirstprint &&
                                              x.PrintSizeId > 0);

            var itemIndex = OrderDetailsList.FindIndex(x => x.StreamId == orderItem.StreamId);

            //create newOrderDetailsList and check on this new list

            if (check == null)
            {
                OrderDetailsList[itemIndex] = orderItem;
            }
            else
            {
                var dr = MessageBox.Show(
                    @"این سفارش اصل چاپ قبلا در لیست سفارشات ثبت شده است. " +
                    @"آیا می خواهید آن را به روز رسانی کنید؟",
                    @"به روز رسانی سفارش چاپ",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (dr != DialogResult.Yes) return;
                OrderDetailsList[itemIndex] = orderItem;

                MessageBox.Show(
                    @"سفارش چاپ مورد نظر با موفقیت به روز رسانی گردید.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }
        private void btnReloadOriginalPhotoPrintOrder_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                @"تمامی موارد انتخابی شده مجددا تنظیم خواهد شد. آیا از این کار مطمئن هستید؟",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (dr != DialogResult.Yes) return;

            ResetOriginalPrintControls();

            //،در صورتی که اطلاعاتی از این سفارش در لیست سفارشات وجود دارد
            //.باید در لیست مربوطه هم اصلاحات مربوطه صورت گیرد

            var currentGuid = OrderDetailsList[_photoCursor].StreamId;
            var itemIndex = OrderDetailsList.FindIndex(x => x.StreamId == currentGuid);
            ResetOrderItemValues(OrderDetailsList[itemIndex]);
        }



        private void BtnCancelPhotoOrderPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var currentGuid = OrderDetailsList[_photoCursor].StreamId;
                var currentOrderDetails = OrderDetailsList.FirstOrDefault(x => x.StreamId == currentGuid);
                if (currentOrderDetails == null)
                {
                    MessageBox.Show(
                        @"این آیتم قبلا تائید نشده است و قابل حذف نیز نمی باشد.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    return;
                }

                var itemIndex = OrderDetailsList.FindIndex(x => x.StreamId == currentOrderDetails.StreamId);

                var dr = MessageBox.Show(
                    @"آیا واقعا می خواهید عکس مورد نظر را از پیش فاکتور حذف کنید؟",
                    @"تایید حذف عکس از پیش فاکتور",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RtlReading);
                if (dr != DialogResult.Yes) return;

                currentOrderDetails.IsAccepted = false;
                currentOrderDetails.IsDeleted = true;
                OrderDetailsList[itemIndex] = currentOrderDetails;

                pictureBoxIsAccepted.Image = Properties.Resources.iconfinder_cancel_round_41190;

                toolTip1.SetToolTip(pictureBoxIsAccepted, "این عکس از پیش فاکتور حذف گردید.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }



        /////////////////////////////////////////////////////////////////////////////
        //btnOkRePrint
        private void ResetRePrintControls()
        {
            //cmbRePrintSequence.SelectedIndex = -1;
            chkIsActiveRePrint.Checked = false;

            cmbRePrintPrintSize.SelectedIndex = -1;
            rbRePrintMultiPhoto.Checked = false;
            rbRePrintLitPrint.Checked = false;
            chkRePrintHasChangingElements.Checked = false;

            chkHasRePrintPrintService.Checked = false;
            cmbRePrintPrintServices.SelectedIndex = -1;
            cmbRePrintPrintServices.Enabled = false;

            txtRePrintMinimumOrder.Text = null;
            txtRePrintMultiPhotoPrice.Text = null;
            txtRePrintLitPrintPrice.Text = null;
            txtRePrintServicePrice.Text = null;

            txtTotalPriceRePrintPrintSize.Text = null;
            txtTotalPriceRePrintMutiPhoto.Text = null;
            txtTotalPriceRePrintLitPrint.Text = null;
            txtTotalPriceRePrintServices.Text = null;
            txtTotalPriceRePrint.Text = null;

            txtRePrintPhotoRetouchDescription.Text = null;
        }
        private int CalculateRePrintTotalPrice()
        {
            int.TryParse(txtTotalPriceRePrintPrintSize.Text, out var totalPriceRePrintPrintSize);
            int.TryParse(txtTotalPriceRePrintMutiPhoto.Text, out var totalPriceRePrintMutiPhoto);
            int.TryParse(txtTotalPriceRePrintLitPrint.Text, out var totalPriceRePrintLitPrint);
            int.TryParse(txtTotalPriceRePrintServices.Text, out var totalPriceRePrintServices);

            int result = totalPriceRePrintPrintSize + totalPriceRePrintMutiPhoto +
                totalPriceRePrintLitPrint + totalPriceRePrintServices;
            return result;
        }


        private void BtnOKRePrint_Click(object sender, EventArgs e)
        {
            var currentGuid = OrderDetailsList[_photoCursor].StreamId;
            var orderItemReprint = new OrderDetails
            {
                OrderPrintId = OrderPrintId,
                CustomerId = CustomerId,
                StreamId = currentGuid,
                RePrintSequence = (cmbRePrintSequence.SelectedIndex) + 1,
                FileName = lblPhotoName.Text,
                IsAccepted = true,
                PrintSizeId = (int)cmbRePrintPrintSize.SelectedValue,
                RePrintTotalPrints = iiRePrintPrintCounts.Value,
                RetouchDescription = txtRePrintPhotoRetouchDescription.Text,
                CreatedDateTime = DateTime.Now,
                IsFirstprint = false,
            };

            if (chkHasRePrintPrintService.Checked && cmbRePrintPrintServices.Enabled &&
                int.TryParse(cmbRePrintPrintServices.SelectedValue.ToString(),
                    out int selectedPrintServiceId))
            {
                orderItemReprint.HasPrintService = true;
                orderItemReprint.PrintServiceId = selectedPrintServiceId;
                int printServerPrice = 0;
                if (_listRePrintPrintServicePrices?.SingleOrDefault(x => x.Id == selectedPrintServiceId) != null)
                {
                    printServerPrice = _listRePrintPrintServicePrices
                        .SingleOrDefault(x => x.Id == selectedPrintServiceId)
                        .PrintServicePrice;
                }
                orderItemReprint.PrintServicePriceId = printServerPrice;
            }

            orderItemReprint.TotalPrice = CalculateRePrintTotalPrice();

            OrderDetailsList.Add(orderItemReprint);
        }
        private void btnReloadRePrintPhotoPrintOrder_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                @"تمامی موارد انتخابی شده مجددا تنظیم خواهد شد. آیا از این کار مطمئن هستید؟",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (dr != DialogResult.Yes) return;

            ResetRePrintControls();
        }
        private void btnCancelRePrintPhotoOrderPrint_Click(object sender, EventArgs e)
        {

        }





        //[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private void BtnOkPhotoOrderPrint_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var currentGuid = PhotoOrderDetailsList[_photoCursor].StreamId;

            //    var currentOrderDetails =
            //        PhotoOrderDetailsList
            //            .FirstOrDefault(x => x.StreamId == currentGuid);

            //    var itemIndex = PhotoOrderDetailsList
            //        .FindIndex(x => currentOrderDetails != null &&
            //                        x.StreamId == currentOrderDetails.StreamId);

            //    if (currentOrderDetails == null)
            //        return;

            //    currentOrderDetails.IsAccepted = 1;
            //    currentOrderDetails.AcceptRejectImage = Properties.Resources.iconfinder_accept_blue_41177;

            //    if (cmbOriginalPrintServices.SelectedValue != null &&
            //        int.TryParse(cmbOriginalPrintServices.SelectedValue.ToString(),
            //            out var selectedOriginalPrintServiceId))
            //    {
            //        currentOrderDetails.HasOriginalPrintService = true;
            //        currentOrderDetails.OriginalServiceId = selectedOriginalPrintServiceId;
            //    }

            //    PhotoOrderDetailsList[itemIndex] = currentOrderDetails;

            //    toolTip1.SetToolTip(pictureBoxIsAccepted, "عکس برای ثبت در پیش فاکتور تائید شده است.");
            //    pictureBoxIsAccepted.Image = currentOrderDetails.AcceptRejectImage;

            //    CalculateTotalPhotosConfirmed();
            //    CaculateTotalPhotoServicesConfirmed();
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
            //        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            //}

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




        #region TXT Enter Persian Leave English

        private void Txt_TypeFarsi_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void Txt_TypeFarsi_Leave(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        #endregion TXT Enter Persian Leave English



        #region btnNextPhoto

        private void btnNextPhoto_Click(object sender, EventArgs e)
        {
            //try
            //{
            var totalItems = OrderDetailsList.Count;

            if (_photoCursor < 0 || _photoCursor >= totalItems)
                return;

            //Save Photo Order Details to Class
            //...
            var currentGuid = OrderDetailsList[_photoCursor].StreamId;
            var currentOrderDetails = OrderDetailsList.FirstOrDefault(x => x.StreamId == currentGuid);
            if (currentOrderDetails != null)
            {
                ///////
                // Original Print
                //
                if (cmbOriginalPrintSize.SelectedValue != null &&
                    int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out var ttt))
                    currentOrderDetails.PrintSizeId = ttt;

                //if (int.TryParse(txtTotalPriceOriginalPrintSize.Text.Replace(",", ""), out var tt))
                //    currentOrderDetails.OriginalPrintSizePrice = tt;

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

                currentOrderDetails.RetouchDescription = txtOriginalPhotoRetouchDescription.Text;

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

                //switch (currentOrderDetails.IsAccepted)
                //{
                //    case 1:
                //        currentOrderDetails.AcceptRejectImage =
                //            Properties.Resources.iconfinder_accept_blue_41177;
                //        break;
                //    case -1:
                //        currentOrderDetails.AcceptRejectImage =
                //            Properties.Resources.iconfinder_cancel_round_41190;
                //        break;
                //    default:
                //        currentOrderDetails.AcceptRejectImage =
                //            Properties.Resources.iconfinder_flickr_317744;
                //        break;
                //}

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

            var nextGuid = OrderDetailsList[_photoCursor].StreamId;
            var nextOrderDetails = OrderDetailsList.FirstOrDefault(x => x.StreamId == nextGuid);
            if (nextOrderDetails != null)
            {
                LoadPicture(nextGuid);

                ////Original Photo
                //
                if (nextOrderDetails.PrintSizeId == 0)
                    cmbOriginalPrintSize.SelectedIndex = -1;
                else
                {
                    cmbOriginalPrintSize.SelectedValue = nextOrderDetails.PrintSizeId;
                    cmbOriginalPrintSize_SelectedIndexChanged(null, null);
                }

                if (nextOrderDetails.HasPrintService)
                {
                    //rbOriginalNormalPrint.Checked = true;
                    if (nextOrderDetails.PrintServiceId != 0)
                    {
                        cmbOriginalPrintServices.SelectedValue = nextOrderDetails.PrintServiceId;
                        //cmbOriginalPrintService_SelectedIndexChanged(null, null);
                    }
                    else
                        cmbOriginalPrintServices.SelectedIndex = -1;
                }

                if (nextOrderDetails.RetouchDescription != null)
                    txtOriginalPhotoRetouchDescription.Text = nextOrderDetails.RetouchDescription;
                //pictureBoxIsAccepted.Image = nextOrderDetails.AcceptRejectImage ??
                //                             Properties.Resources.iconfinder_flickr_317744;



                ////Second Photo
                //
                ////SecondPrint1
                //
                //if (nextOrderDetails.HasSecondPrint1)
                //{
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
                //}


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
            var itemIndex = OrderDetailsList.FindIndex(x => x.StreamId == currentOrderDetails.StreamId);
            OrderDetailsList[itemIndex] = currentOrderDetails;

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

            var previousGuid = OrderDetailsList[_photoCursor].StreamId;
            var previousOrderDetails = OrderDetailsList.FirstOrDefault(x => x.StreamId == previousGuid);
            if (previousOrderDetails != null)
            {
                LoadPicture(previousGuid);

                ////Original Photo
                //
                if (previousOrderDetails.PrintSizeId == 0)
                    cmbOriginalPrintSize.SelectedIndex = -1;
                else
                {
                    cmbOriginalPrintSize.SelectedValue = previousOrderDetails.PrintSizeId;
                    cmbOriginalPrintSize_SelectedIndexChanged(null, null);
                }

                if (previousOrderDetails.HasPrintService)
                {
                    //rbOriginalNormalPrint.Checked = true;
                    if (previousOrderDetails.PrintServiceId == 0)
                        cmbOriginalPrintServices.SelectedIndex = -1;
                    else
                    {
                        cmbOriginalPrintServices.SelectedValue = previousOrderDetails.PrintServiceId;
                        //cmbOriginalPrintService_SelectedIndexChanged(null, null);
                    }
                }

                if (previousOrderDetails.RetouchDescription != null)
                    txtOriginalPhotoRetouchDescription.Text = previousOrderDetails.RetouchDescription;

                //pictureBoxIsAccepted.Image = previousOrderDetails.AcceptRejectImage ??
                //                             Properties.Resources.iconfinder_flickr_317744;

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




        private void txtTotalPriceOriginalPrintSize_TextChanged(object sender, EventArgs e)
        {
            txtTotalPriceOriginal.Text = CalculateOriginalPrintTotalPrice().ToString("N0");
        }
        private void txtTotalPriceOriginalMutiPhoto_TextChanged(object sender, EventArgs e)
        {
            txtTotalPriceOriginal.Text = CalculateOriginalPrintTotalPrice().ToString("N0");
        }
        private void txtTotalPriceOriginalLitPrint_TextChanged(object sender, EventArgs e)
        {
            txtTotalPriceOriginal.Text = CalculateOriginalPrintTotalPrice().ToString("N0");
        }
        private void txtTotalPriceOriginalServices_TextChanged(object sender, EventArgs e)
        {
            txtTotalPriceOriginal.Text = CalculateOriginalPrintTotalPrice().ToString("N0");
        }



        private bool DowloadOrderPhotos(string photoPath, string orderCode)
        {
            bool resultDownload = false;
            string tempPath = System.IO.Path.GetTempPath();

            if (OrderDownloadedBefore(tempPath, orderCode) == false)
            {
               resultDownload = DownloadPhotos(tempPath, photoPath, orderCode);
            }
            else
            {
                MessageBox.Show(@"قبلا این عکس ها در مسیر انتخابی دریافت شده است.", @"", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            return resultDownload;
        }
        private bool OrderDownloadedBefore(string tempPath, string orderCode)
        {
            bool result = false;

            string downloadPath = tempPath + "\\" + "Orders" + "\\" + orderCode;
            if (Directory.Exists(downloadPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(downloadPath);
                var filesOfDirectory = directoryInfo.GetFiles().ToList();
                if (filesOfDirectory.Any())
                {
                    //اگر تعداد فایل های موجود در دایرکتوری فوق با 
                    //تعداد اصلی فایل ها یکی بود نتیجه را ترو برگردون
                    //در غیر این صورت عکس های داخل دایرکتوری را پاک کن و دوباره دانلود کن
                    result = true;
                }
            }

            return result;
        }
        private static bool DownloadPhotos(string selectedPath, string photoPath, string orderCode)
        {
            bool result = false;
            try
            {
                using (var db = new UnitOfWork())
                {
                    List<Guid> fileStreamIdList = db.PhotoRepository.GetListOfOrderFilesReturnStreamIds(photoPath);
                    int counter = 0;
                    if (fileStreamIdList != null)
                    {
                        var totalFiles = fileStreamIdList.Count;
                        foreach (var guid in fileStreamIdList)
                        {
                            var file = db.PhotoRepository.DownloadOrderPhotos(guid);
                            if (file != null)
                            {
                            RetryCreateFolders:
                                var directoryPathOrders = CreateOrderDirectory(selectedPath);

                                var directoryPathOrderCode = CreateOrderCodeDirectory(orderCode, directoryPathOrders);
                                if (directoryPathOrders == null || directoryPathOrderCode == null)
                                {
                                    DialogResult drCreateOrderFolders = MessageBox.Show(
                                        @"خطا در ساخت فولدر های مربوط به سفارش." +
                                        Environment.NewLine +
                                        @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                                        @"",
                                        MessageBoxButtons.RetryCancel,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1);
                                    if (drCreateOrderFolders == DialogResult.Retry)
                                        goto RetryCreateFolders;
                                    else
                                        return false;
                                }

                                string fileNameAndPath = directoryPathOrderCode + file.name;

                                bool fileExists = File.Exists(fileNameAndPath);

                                DialogResult dr = DialogResult.None;
                                if (fileExists)
                                {
                                    long length = new FileInfo(fileNameAndPath).Length;

                                    Debug.Assert(file.fileSize != null, "file.fileSize != null");
                                    if (length == file.fileSize.Value)
                                    {
                                        dr = MessageBox.Show(
                                            $@"فایل  {file.name}  قبلا در سیستم ثبت شده است. آیا می خواهید بازنویسی شود؟  " +
                                            Environment.NewLine +
                                            @"در صورت تایید محتوای فایل قبلی از بین می رود." +
                                            Environment.NewLine +
                                            @"در صورت انصراف، کل فرایند دریافت فایل ها متوقف خواهد شد.",
                                            @"تائید بازنویسی فایل",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                    }
                                    else
                                    {
                                        dr = MessageBox.Show(
                                            @"فایلی با همین نام ولی با حجم متفاوت در مسیر دریافت عکس ها وجود دارد. " +
                                            Environment.NewLine +
                                            @"آیا می خواهید فایل روی سیستم شما بازنویسی شود؟" +
                                            @" در صورت بازنویسی محتوای قبلی فایل از بین خواهد رفت." +
                                            Environment.NewLine +
                                            @"در صورت انصراف، کل فرایند دریافت فایل ها متوقف خواهد شد.",
                                            @"وجود عکس هم نام با سایز متفاوت در مسیر دریافت عکس ها",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                    }
                                }
                                else
                                {
                                    using (var fileStream = new FileStream(fileNameAndPath, FileMode.CreateNew,
                                        FileAccess.Write))
                                    {
                                        file.fileStream.WriteTo(fileStream);
                                        if (fileStream.Length == file.fileStream.Length)
                                        {
                                            fileStream.Flush();
                                            fileStream.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show(
                                                $@"ذخیره فایل با نام {file.name} " +
                                                @" با مشکل مواجه شد. حجم فایل سرور با فایل ذخیره شده تطابق ندارد.",
                                                @"خطا در ذخیره فایل در سیستم کاربر",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }

                                if (dr == DialogResult.Yes)
                                {
                                    using (var fileStream = new FileStream(fileNameAndPath, FileMode.Create,
                                        FileAccess.Write))
                                    {
                                        file.fileStream.WriteTo(fileStream);
                                        if (fileStream.Length == file.fileStream.Length)
                                        {
                                            fileStream.Flush();
                                            fileStream.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show(
                                                $@"ذخیره فایل با نام {file.name} " +
                                                @" با مشکل مواجه شد. حجم فایل سرور با فایل ذخیره شده تطابق ندارد.",
                                                @"خطا در ذخیره فایل در سیستم کاربر",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else if (dr == DialogResult.Cancel)
                                {
                                    break;
                                }

                                counter++;
                            }
                        }

                        if (totalFiles > 0 && counter > 0 && counter == totalFiles)
                            result = true;
                    }
                }
            }

            #region catch

            catch (NotSupportedException notSupportedException)
            {
                MessageBox.Show(notSupportedException.Message);
                return false;
            }
            catch (IOException ioException)
            {
                MessageBox.Show(ioException.Message);
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }

            #endregion

            return result;
        }
        private static string CreateOrderDirectory(string selectedPath)
        {
            try
            {
                string directoryPathOrders = selectedPath + "\\" + "Orders";
                bool folderExistsOrders = Directory.Exists(directoryPathOrders);
                if (!folderExistsOrders)
                    Directory.CreateDirectory(directoryPathOrders);
                return directoryPathOrders;
            }

            #region catch

            catch (IOException ioException)
            {
                MessageBox.Show(@"ioException: " + Environment.NewLine +
                                ioException.Message);
                return null;
            }
            catch (UnauthorizedAccessException accessException)
            {
                MessageBox.Show(@"accessException: " + Environment.NewLine +
                                accessException.Message);
                return null;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(@"argumentException: " + Environment.NewLine +
                                argumentException.Message);
                return null;
            }
            catch (NotSupportedException notSupportedException)
            {
                MessageBox.Show(@"notSupportedException: " + Environment.NewLine +
                                notSupportedException.Message);
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + Environment.NewLine +
                                exception.Message);
                return null;
            }

            #endregion
        }
        private static string CreateOrderCodeDirectory(string orderCode, string directoryPathOrders)
        {
            try
            {
                string directoryPathOrderCode = directoryPathOrders + "\\" + orderCode + "\\";
                bool folderExistsOrderCode = Directory.Exists(directoryPathOrderCode);
                if (!folderExistsOrderCode)
                    Directory.CreateDirectory(directoryPathOrderCode);
                return directoryPathOrderCode;
            }

            #region catch

            catch (IOException ioException)
            {
                MessageBox.Show(@"ioException: " + Environment.NewLine +
                                ioException.Message);
                return null;
            }
            catch (UnauthorizedAccessException accessException)
            {
                MessageBox.Show(@"accessException: " + Environment.NewLine +
                                accessException.Message);
                return null;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(@"argumentException: " + Environment.NewLine +
                                argumentException.Message);
                return null;
            }
            catch (NotSupportedException notSupportedException)
            {
                MessageBox.Show(@"notSupportedException: " + Environment.NewLine +
                                notSupportedException.Message);
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + Environment.NewLine +
                                exception.Message);
                return null;
            }

            #endregion
        }


        private void btnDownloadAllPhotosChangingElements_Click(object sender, EventArgs e)
        {
            //چک کن ببین قبلا همه عکس ها دانلود شده است یا نه. در صورتی که دانلود نشده است دانلود در یک فولدر 
            //temp انجام شود و بعد از بسته شدن فرم هم این فولدر از سیستم حذف شود.


            //photoPath= مسیر ذخیره عکس ها در سرور
            bool resultDownload = DowloadOrderPhotos(photoPath, _orderPrintViewModel.OrderCode);
            if (resultDownload)
            {
                //Show all Files In The DataGridView
            }
        }
        private void btnDownloadSelectedPhotosChangingElements_Click(object sender, EventArgs e)
        {

        }



        private void btnDownloadAllPhotosMultiPhoto_Click(object sender, EventArgs e)
        {

        }
        private void btnDownloadSelectedPhotosMultiPhoto_Click(object sender, EventArgs e)
        {

        }



        private void btnDownloadAllPhotosLitPrint_Click(object sender, EventArgs e)
        {

        }
        private void btnDownloadSelectedPhotosLitPrint_Click(object sender, EventArgs e)
        {

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {

        }
    }
}
