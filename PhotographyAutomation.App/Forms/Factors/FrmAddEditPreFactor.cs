using DevComponents.DotNetBar.Controls;
using PhotographyAutomation.Business.OrderDetails;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
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

namespace PhotographyAutomation.App.Forms.Factors
{
    public partial class FrmAddEditPreFactor : Form
    {
        #region Variables

        private int _selectedOriginalSizeId;
        private int _selectedPrintServiceId;
        private int _photoCursor = 0;

        public List<PhotoOrderDetails> _photoOrderDetailsList;



        public int OrderId = 0;
        public int CustomerId = 0;
        public int OrderPrintId = 0;
        public List<Guid> FileStreamsGuids = null;

        public bool IsNewPreFactor = true;

        #endregion


        public FrmAddEditPreFactor()
        {
            InitializeComponent();
        }

        private void FrmAddEditPreFactor_Load(object sender, EventArgs e)
        {
            if (FileStreamsGuids.Any())
            {
                LoadOriginalPrintSizes();

                //cmbOriginalPrintSize_SelectedIndexChanged(null, null);
                GetOrderPrintInfo();
                LoadPicture(FileStreamsGuids[_photoCursor]);
                if (FileStreamsGuids.Count == 1)
                {
                    btnNextPhoto.Enabled = false;
                    btnPreviousPhoto.Enabled = false;
                }

                //foreach (var streamId in FileStreamsGuids)
                //{
                //    PhotoOrderDetails photoOrder = new PhotoOrderDetails { StreamId = streamId };
                //    _photoOrderDetailsList.Add(photoOrder);
                //}
            }
            else
            {
                RtlMessageBox.Show(
                    "متاسفانه اطلاعات سفارش قابل دریافت نمی باشد. " +
                    "لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                    "خطا در دریافت اطلاعات از سرور",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            cmbOriginalPrintSize.SelectedIndex = -1;
        }


        #region GetOrderPrintInfo
        private void GetOrderPrintInfo()
        {
            bgWorkerGetOrderPrintInfo.RunWorkerAsync();
            circularProgress.IsRunning = bgWorkerLoadOriginalPringSizes.IsBusy;
        }
        private void bgWorkerGetOrderPrintInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            var orderPrintStatusInfo = new TblOrderPrintStatus();
            var customerInfo = new TblCustomer();
            var orderPrintInfo = new TblOrderPrint();
            var orderInfo = new TblOrder();
            var photographyType = new TblPhotographyType();

            try
            {
                using (var db = new UnitOfWork())
                {
                    orderInfo = db.OrderGenericRepository.GetById(OrderId);
                    orderPrintInfo = db.OrderPrintGenericRepository.GetById(OrderPrintId);
                    customerInfo = db.CustomerGenericRepository.GetById(CustomerId);
                    if (orderPrintInfo != null)
                        orderPrintStatusInfo = db.OrderPrintStatusGenericRepository.GetById(orderPrintInfo.OrderPrintStatusId);
                    else
                    {
                        RtlMessageBox.Show(
                            "اطلاعات سفارش فابل دریافت نمی باشد." +
                            " لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.", "",
                            MessageBoxButtons.OK);
                        DialogResult = DialogResult.Abort;
                    }

                    if (orderInfo != null)
                        photographyType = db.PhotographyTypesGenericRepository.GetById(orderInfo.PhotographyTypeId);
                    else
                    {
                        RtlMessageBox.Show(
                            "اطلاعات سفارش فابل دریافت نمی باشد." +
                            " لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.", "",
                            MessageBoxButtons.OK);
                        DialogResult = DialogResult.Abort;
                    }

                    if (customerInfo == null || orderPrintStatusInfo == null)
                    {
                        RtlMessageBox.Show(
                            "اطلاعات سفارش فابل دریافت نمی باشد." +
                            " لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.", "",
                            MessageBoxButtons.OK);
                        DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        if (orderPrintInfo != null)
                        {
                            if (orderInfo != null)
                            {
                                var orderPrintViewModel = new OrderPrintViewModel
                                {
                                    CustomerId = CustomerId,
                                    OrderId = OrderId,
                                    OrderCode = orderInfo?.OrderCode,
                                    OrderPrintCode = orderPrintInfo?.OrderPrintCode,
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
                                    PhotographyDate = orderInfo?.Date,
                                    PhotographyDateShamsi = orderInfo.Date?.ToShamsiDate(),
                                    RetouchDescriptions = orderPrintInfo.RetochDescriptions,
                                    PhotographyTypeId = orderInfo.PhotographyTypeId,
                                    PhotographyTypeName = photographyType.TypeName
                                };
                                e.Result = orderPrintViewModel;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }
        private void bgWorkerGetOrderPrintInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                var orderPrintInfo = (OrderPrintViewModel)e.Result;
                txtOrderCodeDate.Text = orderPrintInfo.OrderCode.Substring(0, 7);
                txtOrderCodeCustomerIdBookingId.Text = orderPrintInfo.OrderCode.Substring(8);
                txtCustomerName.Text = orderPrintInfo.CustomerFirstName + @" " + orderPrintInfo.CustomerLastName;
                if (orderPrintInfo.PhotographyDate.HasValue)
                    datePickerOrderDate.Value = orderPrintInfo.PhotographyDate.Value;
                txtPhotographyType.Text = orderPrintInfo.PhotographyTypeName;

                var ss = orderPrintInfo.OrderPrintCode.Split('-');
                txtOrderPrintCodeDate.Text = ss[0];
                txtOrderPrintCodeOrderId.Text = ss[1];
                txtOrderPrintCodeCustomerId.Text = ss[2];

                lblTotalPhotos.Text = orderPrintInfo.TotalPhotos.ToString();
            }
            circularProgress.IsRunning = bgWorkerLoadOriginalPringSizes.IsBusy;
        }
        #endregion


        #region LoadPicture

        private void LoadPicture(Guid fileStreamsGuid)
        {
            try
            {
                bgWorkerLoadPicture.RunWorkerAsync(fileStreamsGuid);
                circularProgressPictures.IsRunning = bgWorkerLoadPicture.IsBusy;
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

        #endregion





        #region LoadOriginalPrintSizes

        private void LoadOriginalPrintSizes()
        {
            try
            {
                bgWorkerLoadOriginalPringSizes.RunWorkerAsync();
                circularProgress.IsRunning = bgWorkerLoadOriginalPringSizes.IsBusy;
                cmbOriginalPrintSize.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;

                checkBoxSecondPrint1.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
                checkBoxSecondPrint2.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
                checkBoxSecondPrint3.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
                checkBoxSecondPrint4.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void bgWorkerLoadOriginalPringSizes_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizePricesGenericRepository.Get()
                        .Select(x => new PrintSizePriceViewModel
                        {
                            Id = x.Id,
                            SizeName = x.SizeWidth.ToString("####.#") +
                                       " x " +
                                       x.SizeHeight.ToString("####.#"),
                            SizeWidth = x.SizeWidth,
                            SizeHeight = x.SizeHeight
                        })
                        .OrderBy(x => x.SizeWidth)
                        .ThenBy(x => x.SizeHeight)
                        .ToList();
                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(@"exception: " + exception.Message);
                throw exception;
            }
        }

        private void bgWorkerLoadOriginalPringSizes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is List<PrintSizePriceViewModel> printSizeList)
                {
                    cmbOriginalPrintSize.DataSource = printSizeList;
                    cmbOriginalPrintSize.DisplayMember = "SizeName";
                    cmbOriginalPrintSize.ValueMember = "Id";
                }

                cmbOriginalPrintSize.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
                circularProgress.IsRunning = bgWorkerLoadOriginalPringSizes.IsBusy;

                cmbOriginalPrintService.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;

                checkBoxSecondPrint1.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
                checkBoxSecondPrint2.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
                checkBoxSecondPrint3.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
                checkBoxSecondPrint4.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;

                if (bgWorkerLoadOriginalPringSizes.IsBusy == false)
                    circularProgress.Hide();

                //cmbOriginalPrintSize.SelectedIndex = 0;
                //GetOriginalPrintSizePrice((int)cmbOriginalPrintSize.SelectedValue);
                cmbOriginalPrintSize.SelectedIndex = -1;
                txtOriginalPrintSizePrice.ResetText();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion



        #region cmbOriginalPrintSize

        private void cmbOriginalPrintSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOriginalPrintSize.Focused &&
                cmbOriginalPrintSize.SelectedIndex != -1 &&
                int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out var result))
            {
                _selectedOriginalSizeId = result;
                cmbOriginalPrintService.SelectedIndex = -1;
                checkBoxLoadPrintSizeServices.Enabled = true;
                checkBoxLoadPrintSizeServices.Checked = false;
                txtOriginalPrintServicePrice.ResetText();
                GetOriginalPrintSizePrice(_selectedOriginalSizeId);
            }
        }

        #region GetOriginalPrintSizePrice

        private void GetOriginalPrintSizePrice(int printSizeId)
        {
            try
            {
                bgWorkerGetOriginalPrintPrice.RunWorkerAsync(printSizeId);
                circularProgress.IsRunning = bgWorkerGetOriginalPrintPrice.IsBusy;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void bgWorkerGetOriginalPrintPrice_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((int)e.Argument > 0)
            {
                try
                {
                    int printSizeId = (int)e.Argument;

                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintSizePricesGenericRepository.Get(
                            x => x.Id == printSizeId).Select(x => new PrintSizePriceViewModel
                            { OriginalPrintPrice = x.OriginalPrintPrice }).ToList();

                        e.Result = result;
                    }
                }
                catch (Exception exception)
                {
                    //MessageBox.Show(@"exception: " + exception.Message);
                    throw exception;
                }
            }
        }

        private void bgWorkerGetOriginalPrintPrice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is List<PrintSizePriceViewModel> result)
                    {
                        txtOriginalPrintSizePrice.Text = result[0].OriginalPrintPrice.ToString("##,###");
                    }
                }
                else
                {
                    txtOriginalPrintSizePrice.Text = @"------";
                }

                if (bgWorkerGetOriginalPrintPrice.IsBusy == false)
                    circularProgress.Hide();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion GetOriginalPrintSizePrice

        #endregion



        #region checkBoxLoadPrintSizeServices

        private void checkBoxLoadPrintSizeServices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadPrintSizeServices.Checked)
            {
                if (cmbOriginalPrintSize.SelectedValue != null &&
                   int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out _))
                    LoadPrintSizeService(_selectedOriginalSizeId);
            }
            else
            {
                cmbOriginalPrintService.Enabled = false;
                txtOriginalPrintServicePrice.ResetText();
            }
        }

        #endregion



        #region LoadPrintSizeService

        private void LoadPrintSizeService(int printSizeId)
        {
            try
            {
                bgWorkerLoadPrintSizeServices.RunWorkerAsync(printSizeId);
                circularProgress.IsRunning = bgWorkerLoadPrintSizeServices.IsBusy;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void bgWorkerLoadPrintSizeServices_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((int)e.Argument > 0)
            {
                int printSizeId = (int)e.Argument;
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServices_PrintSizePriceGenericRepository
                            .Get(x => x.PrintSizePriceId == printSizeId)
                            .Select(x => new PrintServiceType_PrintSizePriceViewModel
                            {
                                Id = x.PrintServiceId,
                                Code = x.TblPrintServices.Code,
                                PrintServiceName = x.TblPrintServices.PrintServiceName,
                                Price = x.Price
                            })
                            .OrderBy(x => x.PrintServiceName)
                            .ToList();

                        e.Result = result;
                    }
                }
                catch (Exception exception)
                {
                    //MessageBox.Show(@"exception: " + exception.Message);
                    throw exception;
                }
            }
        }

        private void bgWorkerLoadPrintSizeServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is List<PrintServiceType_PrintSizePriceViewModel> printServiceList)
                    {
                        cmbOriginalPrintService.DataSource = printServiceList;
                        cmbOriginalPrintService.DisplayMember = "PrintServiceName";
                        cmbOriginalPrintService.ValueMember = "Id";
                    }
                }

                cmbOriginalPrintService.Enabled = !bgWorkerLoadPrintSizeServices.IsBusy;
                circularProgress.IsRunning = bgWorkerLoadPrintSizeServices.IsBusy;

                if (bgWorkerLoadPrintSizeServices.IsBusy == false)
                {
                    circularProgress.Hide();
                    if (cmbOriginalPrintService.Enabled && cmbOriginalPrintService.Items.Count > 0 &&
                        int.TryParse(cmbOriginalPrintService.SelectedValue.ToString(),
                            out int selectedPrintService))
                    {
                        GetPrintServicePrice(selectedPrintService);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion



        #region cmbOriginalPrintService

        private void cmbOriginalPrintService_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbOriginalPrintService.Enabled && cmbOriginalPrintService.Items.Count > 0)
            {
                LoadPrintSizeService((int)cmbOriginalPrintSize.SelectedValue);
                _selectedPrintServiceId = (int)cmbOriginalPrintService.SelectedValue;
                if (cmbOriginalPrintService.Items.Count > 0)
                {
                    cmbOriginalPrintService.SelectedIndex = 0;
                    cmbOriginalPrintService_SelectedIndexChanged(null, null);
                }

                //GetPrintServicePrice(_selectedPrintServiceId);
            }
        }

        private void cmbOriginalPrintService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOriginalPrintService.Enabled && cmbOriginalPrintService.Items.Count > 0 &&
                cmbOriginalPrintService.SelectedValue != null && cmbOriginalPrintService.SelectedIndex != -1)
            {
                if (int.TryParse(cmbOriginalPrintService.SelectedValue.ToString(), out _))
                {
                    _selectedPrintServiceId = (int)cmbOriginalPrintService.SelectedValue;
                    GetPrintServicePrice(_selectedPrintServiceId);
                }
            }
        }



        #endregion



        #region GetPrintServicePrice

        private void GetPrintServicePrice(int printServiceId)
        {
            try
            {
                if (bgWorkerGetPrintServicePrice.IsBusy == false)
                {
                    bgWorkerGetPrintServicePrice.RunWorkerAsync(printServiceId);
                    circularProgress.IsRunning = bgWorkerGetPrintServicePrice.IsBusy;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void bgWorkerGetPrintServicePrice_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((int)e.Argument > 0)
            {
                try
                {
                    int printServiceId = (int)e.Argument;

                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServices_PrintSizePriceGenericRepository.Get(x =>
                                x.PrintSizePriceId == _selectedOriginalSizeId &&
                                x.PrintServiceId == printServiceId)
                            .Select(x => new PrintServiceType_PrintSizePriceViewModel
                            {
                                Price = x.Price
                            }).ToList();

                        e.Result = result;
                    }
                }
                catch (Exception exception)
                {
                    //MessageBox.Show(@"exception: " + exception.Message);
                    throw exception;
                }
            }
        }

        private void bgWorkerGetPrintServicePrice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is List<PrintServiceType_PrintSizePriceViewModel> result && result.Any())
                    {
                        txtOriginalPrintServicePrice.Text = result[0].Price?.ToString("##,###");
                    }
                    else
                    {
                        txtOriginalPrintServicePrice.Text = @"------";
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion




        #region SecondPrintSize1

        private void checkBoxSecondPrint1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint1.Checked)
            {
                cmbSecondPrintSize1.Enabled = true;
                checkBoxLoadSecondPrintServices1.Enabled = true;
                integerInputSecondPrintCount1.Enabled = true;
                integerInputSecondPrintCount1.Value = 1;
            }
            else
            {
                cmbSecondPrintSize1.Enabled = false;
                txtSecondPrintSizePrice1.ResetText();
                cmbSecondPrintService1.SelectedIndex = -1;
                cmbSecondPrintService1.Enabled = false;
                txtSecondPrintServicePrice1.ResetText();
                integerInputSecondPrintCount1.Enabled = false;
                checkBoxLoadSecondPrintServices1.Checked = false;
            }
        }
        private void cmbSecondPrintSize1_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize1.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondPrintSize = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };


                    bgWorkerGetSecondPrintSize.DoWork += BgWorkerGetSecondPrintSizeOnDoWork;
                    bgWorkerGetSecondPrintSize.RunWorkerCompleted += BgWorkerGetSecondPrintSizeOnRunWorkerCompleted;

                    var data = new SecondPrintServiceListDataStructure
                    {
                        ComboBoxName = cmbSecondPrintSize1.Name
                    };

                    bgWorkerGetSecondPrintSize.RunWorkerAsync(data);



                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }
        private void cmbSecondPrintSize1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize1.Enabled && cmbSecondPrintSize1.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize1.SelectedValue.ToString(), out int selectedValue))
                {
                    var ss = new SecondPrintSizeDataStructure
                    {
                        Count = integerInputSecondPrintCount1.Value,
                        PrintSizeId = (int)cmbSecondPrintSize1.SelectedValue,
                        TextBoxName = txtSecondPrintSizePrice1.Name
                    };
                    GetSecondPrintSizePrice(ss);
                    //txtSecondPrintSizePrice1.Text = GetSecondPrintSizePrice(selectedValue);
                    if (checkBoxLoadSecondPrintServices1.Checked)
                    {
                        cmbSecondPrintService1_EnabledChanged(null, null);
                    }
                }
            }
        }


        #endregion

        #region SecondPrintSize2


        private void checkBoxSecondPrint2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint2.Checked)
            {
                cmbSecondPrintSize2.Enabled = true;
                checkBoxLoadSecondPrintServices2.Enabled = true;
                integerInputSecondPrintCount2.Enabled = true;
                integerInputSecondPrintCount2.Value = 1;
            }
            else
            {
                cmbSecondPrintSize2.Enabled = false;
                txtSecondPrintSizePrice2.ResetText();
                cmbSecondPrintService2.SelectedIndex = -1;
                cmbSecondPrintService2.Enabled = false;
                txtSecondPrintServicePrice2.ResetText();
                integerInputSecondPrintCount2.Enabled = false;
            }
        }

        private void cmbSecondPrintSize2_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize2.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondPrintSize = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };

                    bgWorkerGetSecondPrintSize.DoWork += BgWorkerGetSecondPrintSizeOnDoWork;
                    bgWorkerGetSecondPrintSize.RunWorkerCompleted += BgWorkerGetSecondPrintSizeOnRunWorkerCompleted;

                    var data = new SecondPrintServiceListDataStructure
                    {
                        ComboBoxName = cmbSecondPrintSize2.Name
                    };

                    bgWorkerGetSecondPrintSize.RunWorkerAsync(data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private void cmbSecondPrintSize2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize2.Enabled && cmbSecondPrintSize2.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize2.SelectedValue.ToString(), out int selectedValue))
                {
                    var ss = new SecondPrintSizeDataStructure
                    {
                        Count = integerInputSecondPrintCount2.Value,
                        PrintSizeId = (int)cmbSecondPrintSize2.SelectedValue,
                        TextBoxName = txtSecondPrintSizePrice2.Name
                    };
                    GetSecondPrintSizePrice(ss);
                    if (checkBoxLoadSecondPrintServices1.Checked)
                    {
                        cmbSecondPrintService1_EnabledChanged(null, null);
                    }
                }
            }
        }


        #endregion

        #region SecondPrintSize3

        private void checkBoxSecondPrint3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint3.Checked)
            {
                cmbSecondPrintSize3.Enabled = true;
                checkBoxLoadSecondPrintServices3.Enabled = true;
                integerInputSecondPrintCount3.Enabled = true;
                integerInputSecondPrintCount3.Value = 1;
            }
            else
            {
                cmbSecondPrintSize3.Enabled = false;
                txtSecondPrintSizePrice3.ResetText();
                cmbSecondPrintService3.SelectedIndex = -1;
                cmbSecondPrintService3.Enabled = false;
                txtSecondPrintServicePrice3.ResetText();
                integerInputSecondPrintCount3.Enabled = false;

            }
        }

        private void cmbSecondPrintSize3_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize3.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondPrintSize = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };

                    bgWorkerGetSecondPrintSize.DoWork += BgWorkerGetSecondPrintSizeOnDoWork;
                    bgWorkerGetSecondPrintSize.RunWorkerCompleted += BgWorkerGetSecondPrintSizeOnRunWorkerCompleted;

                    var data = new SecondPrintServiceListDataStructure
                    {
                        ComboBoxName = cmbSecondPrintSize3.Name
                    };

                    bgWorkerGetSecondPrintSize.RunWorkerAsync(data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private void cmbSecondPrintSize3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize3.Enabled && cmbSecondPrintSize3.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize3.SelectedValue.ToString(), out int selectedValue))
                {
                    var ss = new SecondPrintSizeDataStructure
                    {
                        Count = integerInputSecondPrintCount3.Value,
                        PrintSizeId = (int)cmbSecondPrintSize3.SelectedValue,
                        TextBoxName = txtSecondPrintSizePrice3.Name
                    };
                    GetSecondPrintSizePrice(ss);
                    if (checkBoxLoadSecondPrintServices3.Checked)
                    {
                        cmbSecondPrintService3_EnabledChanged(null, null);
                    }
                }
            }
        }

        #endregion

        #region SecondPrintSize4

        private void checkBoxSecondPrint4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint4.Checked)
            {
                cmbSecondPrintSize4.Enabled = true;
                checkBoxLoadSecondPrintServices4.Enabled = true;
                integerInputSecondPrintCount4.Enabled = true;
                integerInputSecondPrintCount4.Value = 1;
            }
            else
            {
                cmbSecondPrintSize4.Enabled = false;
                txtSecondPrintSizePrice4.ResetText();
                cmbSecondPrintService4.SelectedIndex = -1;
                cmbSecondPrintService4.Enabled = false;
                txtSecondPrintServicePrice4.ResetText();
                integerInputSecondPrintCount4.Enabled = false;
            }
        }

        private void cmbSecondPrintSize4_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize4.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondPrintSize = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };

                    bgWorkerGetSecondPrintSize.DoWork += BgWorkerGetSecondPrintSizeOnDoWork;
                    bgWorkerGetSecondPrintSize.RunWorkerCompleted += BgWorkerGetSecondPrintSizeOnRunWorkerCompleted;

                    var data = new SecondPrintServiceListDataStructure
                    {
                        ComboBoxName = cmbSecondPrintSize4.Name
                    };

                    bgWorkerGetSecondPrintSize.RunWorkerAsync(data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private void cmbSecondPrintSize4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize4.Enabled && cmbSecondPrintSize4.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize4.SelectedValue.ToString(), out int selectedValue))
                {
                    var ss = new SecondPrintSizeDataStructure
                    {
                        Count = integerInputSecondPrintCount4.Value,
                        PrintSizeId = (int)cmbSecondPrintSize4.SelectedValue,
                        TextBoxName = txtSecondPrintSizePrice4.Name
                    };
                    GetSecondPrintSizePrice(ss);
                    if (checkBoxLoadSecondPrintServices4.Checked)
                    {
                        cmbSecondPrintService4_EnabledChanged(null, null);
                    }
                }
            }
        }

        #endregion

        private static void BgWorkerGetSecondPrintSizeOnDoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is SecondPrintServiceListDataStructure data)
            {
                using (var db = new UnitOfWork())
                {
                    List<PrintSizePriceViewModel> result = db.PrintSizePricesGenericRepository.Get()
                        .Select(x => new PrintSizePriceViewModel
                        {
                            Id = x.Id,
                            SizeName = x.SizeWidth.ToString("####.#") +
                                       " x " +
                                       x.SizeHeight.ToString("####.#"),
                            SizeWidth = x.SizeWidth,
                            SizeHeight = x.SizeHeight
                        })
                        .OrderBy(x => x.SizeWidth)
                        .ThenBy(x => x.SizeHeight)
                        .ToList();

                    if (result.Any())
                    {
                        data.SizeList = result;
                        data.DisplayMember = "SizeName";
                        data.ValueMember = "Id";

                        e.Result = data;
                    }
                    else
                    {
                        e.Result = null;
                    }
                }
            }
        }
        private void BgWorkerGetSecondPrintSizeOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is SecondPrintServiceListDataStructure data)
            {
                switch (data.ComboBoxName)
                {
                    case nameof(cmbSecondPrintSize1):
                        cmbSecondPrintSize1.DataSource = data.SizeList;
                        cmbSecondPrintSize1.DisplayMember = data.DisplayMember;
                        cmbSecondPrintSize1.ValueMember = data.ValueMember;

                        txtSecondPrintSizePrice1.Enabled = true;
                        checkBoxLoadSecondPrintServices1.Enabled = true;
                        integerInputSecondPrintCount1.Enabled = true;

                        cmbSecondPrintSize1_SelectedIndexChanged(null, null);
                        break;
                    case nameof(cmbSecondPrintSize2):
                        cmbSecondPrintSize2.DataSource = data.SizeList;
                        cmbSecondPrintSize2.DisplayMember = data.DisplayMember;
                        cmbSecondPrintSize2.ValueMember = data.ValueMember;

                        txtSecondPrintSizePrice2.Enabled = true;
                        checkBoxLoadSecondPrintServices2.Enabled = true;
                        integerInputSecondPrintCount2.Enabled = true;

                        cmbSecondPrintSize2_SelectedIndexChanged(null, null);
                        break;
                    case nameof(cmbSecondPrintSize3):
                        cmbSecondPrintSize3.DataSource = data.SizeList;
                        cmbSecondPrintSize3.DisplayMember = data.DisplayMember;
                        cmbSecondPrintSize3.ValueMember = data.ValueMember;

                        txtSecondPrintSizePrice3.Enabled = true;
                        checkBoxLoadSecondPrintServices3.Enabled = true;
                        integerInputSecondPrintCount3.Enabled = true;

                        cmbSecondPrintSize3_SelectedIndexChanged(null, null);
                        break;
                    case nameof(cmbSecondPrintSize4):
                        cmbSecondPrintSize4.DataSource = data.SizeList;
                        cmbSecondPrintSize4.DisplayMember = data.DisplayMember;
                        cmbSecondPrintSize4.ValueMember = data.ValueMember;

                        txtSecondPrintSizePrice4.Enabled = true;
                        checkBoxLoadSecondPrintServices4.Enabled = true;
                        integerInputSecondPrintCount4.Enabled = true;

                        cmbSecondPrintSize4_SelectedIndexChanged(null, null);
                        break;
                }
            }
        }



        #region SecondPrintService1
        private void checkBoxLoadSecondPrintServices1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintServices1.Checked)
            {
                cmbSecondPrintService1.Enabled = true;
                txtSecondPrintServicePrice1.Enabled = true;
                integerInputSecondPrintServiceCount1.Enabled = true;
                integerInputSecondPrintServiceCount1.Value = 1;
            }
            else
            {
                cmbSecondPrintService1.SelectedIndex = -1;
                cmbSecondPrintService1.Enabled = false;
                txtSecondPrintServicePrice1.Enabled = false;
                txtSecondPrintServicePrice1.ResetText();
                integerInputSecondPrintServiceCount1.Enabled = false;
            }
        }

        private void cmbSecondPrintService1_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService1.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondSizeServiceList = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };

                    var data = new SecondPrintSizeServiceListDataStructure
                    {
                        SizeId = (int)cmbSecondPrintSize1.SelectedValue,
                        ComboBoxName = cmbSecondPrintService1.Name
                    };

                    bgWorkerGetSecondSizeServiceList.DoWork += BgWorkerGetSecondSizeServiceListOnDoWork;
                    bgWorkerGetSecondSizeServiceList.RunWorkerCompleted += BgWorkerGetSecondSizeServiceListOnRunWorkerCompleted;

                    bgWorkerGetSecondSizeServiceList.RunWorkerAsync(data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService1.Enabled && cmbSecondPrintService1.Items.Count > 0 &&
                cmbSecondPrintService1.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService1.SelectedValue.ToString(), out _))
                {
                    var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
                    {
                        TextBoxName = txtSecondPrintServicePrice1.Name,
                        Count = 1,
                        PrintServiceId = (int)cmbSecondPrintService1.SelectedValue,
                        PrintSizePriceId = (int)cmbSecondPrintSize1.SelectedValue
                    };
                    GetSecondPrintServicePrice(secondPrintServiceDataStructure);
                }
            }
        }

        #endregion

        #region SecondPrintService2
        private void checkBoxLoadSecondPrintServices2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintServices2.Checked)
            {
                cmbSecondPrintService2.Enabled = true;
                txtSecondPrintServicePrice2.Enabled = true;
                integerInputSecondPrintServiceCount2.Enabled = true;
                integerInputSecondPrintServiceCount2.Value = 1;
            }
            else
            {
                cmbSecondPrintService1.SelectedIndex = -1;
                cmbSecondPrintService2.Enabled = false;
                txtSecondPrintServicePrice2.Enabled = false;
                txtSecondPrintServicePrice2.ResetText();
                integerInputSecondPrintServiceCount2.Enabled = false;
            }
        }

        private void cmbSecondPrintService2_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService2.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondSizeServiceList = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };

                    var data = new SecondPrintSizeServiceListDataStructure
                    {
                        SizeId = (int)cmbSecondPrintSize2.SelectedValue,
                        ComboBoxName = cmbSecondPrintService2.Name
                    };

                    bgWorkerGetSecondSizeServiceList.DoWork += BgWorkerGetSecondSizeServiceListOnDoWork;
                    bgWorkerGetSecondSizeServiceList.RunWorkerCompleted += BgWorkerGetSecondSizeServiceListOnRunWorkerCompleted;

                    bgWorkerGetSecondSizeServiceList.RunWorkerAsync(data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService2.Enabled && cmbSecondPrintService2.Items.Count > 0 &&
                cmbSecondPrintService2.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService2.SelectedValue.ToString(), out _))
                {
                    var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
                    {
                        TextBoxName = txtSecondPrintServicePrice2.Name,
                        Count = 1,
                        PrintServiceId = (int)cmbSecondPrintService2.SelectedValue,
                        PrintSizePriceId = (int)cmbSecondPrintSize2.SelectedValue
                    };
                    GetSecondPrintServicePrice(secondPrintServiceDataStructure);
                }
            }
        }

        #endregion

        #region SecondPrintService3
        private void checkBoxLoadSecondPrintServices3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintServices3.Checked)
            {
                cmbSecondPrintService3.Enabled = true;
                txtSecondPrintServicePrice3.Enabled = true;
                integerInputSecondPrintServiceCount3.Enabled = true;
                integerInputSecondPrintServiceCount3.Value = 1;
            }
            else
            {
                cmbSecondPrintService3.SelectedIndex = -1;
                cmbSecondPrintService3.Enabled = false;
                txtSecondPrintServicePrice3.Enabled = false;
                txtSecondPrintServicePrice3.ResetText();
                integerInputSecondPrintServiceCount3.Enabled = false;
            }
        }

        private void cmbSecondPrintService3_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService3.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondSizeServiceList = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };

                    var data = new SecondPrintSizeServiceListDataStructure
                    {
                        SizeId = (int)cmbSecondPrintSize3.SelectedValue,
                        ComboBoxName = cmbSecondPrintService3.Name
                    };

                    bgWorkerGetSecondSizeServiceList.DoWork += BgWorkerGetSecondSizeServiceListOnDoWork;
                    bgWorkerGetSecondSizeServiceList.RunWorkerCompleted += BgWorkerGetSecondSizeServiceListOnRunWorkerCompleted;

                    bgWorkerGetSecondSizeServiceList.RunWorkerAsync(data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService3.Enabled && cmbSecondPrintService3.Items.Count > 0 &&
                cmbSecondPrintService3.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService3.SelectedValue.ToString(), out _))
                {
                    var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
                    {
                        TextBoxName = txtSecondPrintServicePrice3.Name,
                        Count = 1,
                        PrintServiceId = (int)cmbSecondPrintService3.SelectedValue,
                        PrintSizePriceId = (int)cmbSecondPrintSize3.SelectedValue
                    };
                    GetSecondPrintServicePrice(secondPrintServiceDataStructure);
                }
            }
        }

        #endregion

        #region SecondPrintService4
        private void checkBoxLoadSecondPrintServices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintServices4.Checked)
            {
                cmbSecondPrintService4.Enabled = true;
                txtSecondPrintServicePrice4.Enabled = true;
                integerInputSecondPrintServiceCount4.Enabled = true;
                integerInputSecondPrintServiceCount4.Value = 1;
            }
            else
            {
                cmbSecondPrintService4.SelectedIndex = -1;
                cmbSecondPrintService4.Enabled = false;
                txtSecondPrintServicePrice4.Enabled = false;
                txtSecondPrintServicePrice4.ResetText();
                integerInputSecondPrintServiceCount4.Enabled = false;
            }
        }

        private void cmbSecondPrintService4_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService4.Enabled)
            {
                try
                {
                    var bgWorkerGetSecondSizeServiceList = new BackgroundWorker
                    {
                        WorkerSupportsCancellation = false,
                        WorkerReportsProgress = false
                    };

                    var data = new SecondPrintSizeServiceListDataStructure
                    {
                        SizeId = (int)cmbSecondPrintSize4.SelectedValue,
                        ComboBoxName = cmbSecondPrintService4.Name
                    };

                    bgWorkerGetSecondSizeServiceList.DoWork += BgWorkerGetSecondSizeServiceListOnDoWork;
                    bgWorkerGetSecondSizeServiceList.RunWorkerCompleted += BgWorkerGetSecondSizeServiceListOnRunWorkerCompleted;

                    bgWorkerGetSecondSizeServiceList.RunWorkerAsync(data);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService4.Enabled && cmbSecondPrintService4.Items.Count > 0 &&
                cmbSecondPrintService4.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService4.SelectedValue.ToString(), out _))
                {
                    //txtSecondPrintServicePrice4.Text = GetSecondPrintServicePrice(cmbSecondPrintService4, 1).ToString("##,###");

                    var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
                    {
                        TextBoxName = txtSecondPrintServicePrice4.Name,
                        Count = 1,
                        PrintServiceId = (int)cmbSecondPrintService4.SelectedValue,
                        PrintSizePriceId = (int)cmbSecondPrintSize4.SelectedValue
                    };
                    GetSecondPrintServicePrice(secondPrintServiceDataStructure);
                }
            }
        }


        #endregion

        private static void BgWorkerGetSecondSizeServiceListOnDoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is SecondPrintSizeServiceListDataStructure data)
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintServices_PrintSizePriceGenericRepository
                        .Get(x => x.PrintSizePriceId == data.SizeId)
                        .Select(x => new PrintServiceType_PrintSizePriceViewModel
                        {
                            Id = x.PrintServiceId,
                            Code = x.TblPrintServices.Code,
                            PrintServiceName = x.TblPrintServices.PrintServiceName,
                            Price = x.Price
                        })
                        .OrderBy(x => x.PrintServiceName)
                        .ToList();
                    if (result.Any())
                    {
                        data.SizeServiceList = result;
                        data.DisplayMember = "PrintServiceName";
                        data.ValueMember = "Id";
                    }
                }
                e.Result = data;
            }
        }
        private void BgWorkerGetSecondSizeServiceListOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is SecondPrintSizeServiceListDataStructure data)
            {
                switch (data.ComboBoxName)
                {
                    case nameof(cmbSecondPrintService1):
                        if (data.SizeServiceList != null && data.SizeServiceList.Any())
                        {
                            cmbSecondPrintService1.DataSource = data.SizeServiceList;
                            cmbSecondPrintService1.DisplayMember = data.DisplayMember;
                            cmbSecondPrintService1.ValueMember = data.ValueMember;

                            cmbSecondPrintService1_SelectedIndexChanged(null, null);
                        }
                        else
                        {
                            cmbSecondPrintService1.SelectedIndex = -1;
                            cmbSecondPrintService1.DataSource = null;
                            txtSecondPrintServicePrice1.ResetText();
                        }
                        break;
                    case nameof(cmbSecondPrintService2):
                        if (data.SizeServiceList != null && data.SizeServiceList.Any())
                        {
                            cmbSecondPrintService2.DataSource = data.SizeServiceList;
                            cmbSecondPrintService2.DisplayMember = data.DisplayMember;
                            cmbSecondPrintService2.ValueMember = data.ValueMember;

                            cmbSecondPrintService2_SelectedIndexChanged(null, null);
                        }
                        else
                        {
                            cmbSecondPrintService2.SelectedIndex = -1;
                            cmbSecondPrintService2.DataSource = null;
                            txtSecondPrintServicePrice2.ResetText();
                        }
                        break;
                    case nameof(cmbSecondPrintService3):
                        if (data.SizeServiceList != null && data.SizeServiceList.Any())
                        {
                            cmbSecondPrintService3.DataSource = data.SizeServiceList;
                            cmbSecondPrintService3.DisplayMember = data.DisplayMember;
                            cmbSecondPrintService3.ValueMember = data.ValueMember;

                            cmbSecondPrintService3_SelectedIndexChanged(null, null);
                        }
                        else
                        {
                            cmbSecondPrintService3.SelectedIndex = -1;
                            cmbSecondPrintService3.DataSource = null;
                            txtSecondPrintServicePrice3.ResetText();
                        }
                        break;
                    case nameof(cmbSecondPrintService4):
                        if (data.SizeServiceList != null && data.SizeServiceList.Any())
                        {
                            cmbSecondPrintService4.DataSource = data.SizeServiceList;
                            cmbSecondPrintService4.DisplayMember = data.DisplayMember;
                            cmbSecondPrintService4.ValueMember = data.ValueMember;

                            cmbSecondPrintService4_SelectedIndexChanged(null, null);
                        }
                        else
                        {
                            cmbSecondPrintService4.SelectedIndex = -1;
                            cmbSecondPrintService4.DataSource = null;
                            txtSecondPrintServicePrice4.ResetText();
                        }
                        break;
                }
            }
        }


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



        #region integerInputSecontPrintCount

        private void integerInputSecontPrintCount1_ValueChanged(object sender, EventArgs e)
        {
            if (integerInputSecondPrintCount1.Enabled && integerInputSecondPrintCount1.Value > 0)
            {
                var ss = new SecondPrintSizeDataStructure
                {
                    TextBoxName = txtSecondPrintSizePrice1.Name,
                    Count = integerInputSecondPrintCount1.Value,
                    PrintSizeId = (int)cmbSecondPrintSize1.SelectedValue
                };
                GetSecondPrintSizePrice(ss);
            }
        }
        private void integerInputSecontPrintCount2_ValueChanged(object sender, EventArgs e)
        {
            if (integerInputSecondPrintCount2.Enabled && integerInputSecondPrintCount2.Value > 0)
            {
                var ss = new SecondPrintSizeDataStructure
                {
                    TextBoxName = txtSecondPrintSizePrice2.Name,
                    Count = integerInputSecondPrintCount2.Value,
                    PrintSizeId = (int)cmbSecondPrintSize2.SelectedValue
                };
                GetSecondPrintSizePrice(ss);
            }
        }
        private void integerInputSecontPrintCount3_ValueChanged(object sender, EventArgs e)
        {
            if (integerInputSecondPrintCount3.Enabled && integerInputSecondPrintCount3.Value > 0)
            {
                var ss = new SecondPrintSizeDataStructure
                {
                    TextBoxName = txtSecondPrintSizePrice3.Name,
                    Count = integerInputSecondPrintCount3.Value,
                    PrintSizeId = (int)cmbSecondPrintSize3.SelectedValue
                };
                GetSecondPrintSizePrice(ss);
            }
        }
        private void integerInputSecontPrintCount4_ValueChanged(object sender, EventArgs e)
        {
            if (integerInputSecondPrintCount4.Enabled && integerInputSecondPrintCount4.Value > 0)
            {
                var ss = new SecondPrintSizeDataStructure
                {
                    TextBoxName = txtSecondPrintSizePrice4.Name,
                    Count = integerInputSecondPrintCount4.Value,
                    PrintSizeId = (int)cmbSecondPrintSize4.SelectedValue
                };
                GetSecondPrintSizePrice(ss);
            }
        }

        #endregion

        #region integerInputSecontPrintServiceCount1

        private void integerInputSecontPrintServiceCount1_ValueChanged(object sender, EventArgs e)
        {
            if (integerInputSecondPrintServiceCount1.Enabled && integerInputSecondPrintServiceCount1.Value > 0)
            {
                if (integerInputSecondPrintServiceCount1.Value > integerInputSecondPrintCount1.Value)
                {
                    RtlMessageBox.Show(
                        "تعداد خدمات چاپ نمی تواند از تعداد اضافه چاپ سایز مشخص شده بیشتر باشد.",
                        "خطا در تعداد خدمات چاپ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                    return;
                }

                var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
                {
                    TextBoxName = txtSecondPrintServicePrice1.Name,
                    Count = integerInputSecondPrintServiceCount1.Value,
                    PrintServiceId = (int)cmbSecondPrintService1.SelectedValue,
                    PrintSizePriceId = (int)cmbSecondPrintSize1.SelectedValue
                };
                GetSecondPrintServicePrice(secondPrintServiceDataStructure);
            }
        }
        private void integerInputSecontPrintServiceCount2_ValueChanged(object sender, EventArgs e)
        {
            if (integerInputSecondPrintServiceCount2.Enabled && integerInputSecondPrintServiceCount2.Value > 0)
            {
                if (integerInputSecondPrintServiceCount2.Value > integerInputSecondPrintCount2.Value)
                {
                    RtlMessageBox.Show(
                        "تعداد خدمات چاپ نمی تواند از تعداد اضافه چاپ سایز مشخص شده بیشتر باشد.",
                        "خطا در تعداد خدمات چاپ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                    return;
                }
                var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
                {
                    TextBoxName = txtSecondPrintServicePrice2.Name,
                    Count = integerInputSecondPrintServiceCount2.Value,
                    PrintServiceId = (int)cmbSecondPrintService2.SelectedValue,
                    PrintSizePriceId = (int)cmbSecondPrintSize2.SelectedValue
                };
                GetSecondPrintServicePrice(secondPrintServiceDataStructure);
            }
        }
        private void integerInputSecontPrintServiceCount3_ValueChanged(object sender, EventArgs e)
        {
            if (!integerInputSecondPrintServiceCount3.Enabled ||
                integerInputSecondPrintServiceCount3.Value <= 0) return;
            if (integerInputSecondPrintServiceCount3.Value > integerInputSecondPrintCount3.Value)
            {
                RtlMessageBox.Show(
                    "تعداد خدمات چاپ نمی تواند از تعداد اضافه چاپ سایز مشخص شده بیشتر باشد.",
                    "خطا در تعداد خدمات چاپ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
            {
                TextBoxName = txtSecondPrintServicePrice3.Name,
                Count = integerInputSecondPrintServiceCount3.Value,
                PrintServiceId = (int)cmbSecondPrintService3.SelectedValue,
                PrintSizePriceId = (int)cmbSecondPrintSize3.SelectedValue
            };
            GetSecondPrintServicePrice(secondPrintServiceDataStructure);
        }
        private void integerInputSecontPrintServiceCount4_ValueChanged(object sender, EventArgs e)
        {
            if (!integerInputSecondPrintServiceCount4.Enabled ||
                integerInputSecondPrintServiceCount4.Value <= 0) return;
            if (integerInputSecondPrintServiceCount4.Value > integerInputSecondPrintCount4.Value)
            {
                RtlMessageBox.Show(
                    "تعداد خدمات چاپ نمی تواند از تعداد اضافه چاپ سایز مشخص شده بیشتر باشد.",
                    "خطا در تعداد خدمات چاپ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            var secondPrintServiceDataStructure = new SecondPrintServiceDataStructure
            {
                TextBoxName = txtSecondPrintServicePrice4.Name,
                Count = integerInputSecondPrintServiceCount4.Value,
                PrintServiceId = (int)cmbSecondPrintService4.SelectedValue,
                PrintSizePriceId = (int)cmbSecondPrintSize4.SelectedValue
            };
            GetSecondPrintServicePrice(secondPrintServiceDataStructure);
        }

        #endregion

        #region GetSecondPrintSizePrice

        private void GetSecondPrintSizePrice(SecondPrintSizeDataStructure secondPrintSizeDataStructure)
        {
            var bgWorkerGetSecondPrintSizePrice = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = false
            };
            bgWorkerGetSecondPrintSizePrice.DoWork += bgWorkerGetSecondPrintSizePriceOnDoWork;
            bgWorkerGetSecondPrintSizePrice.RunWorkerCompleted += bgWorkerGetSecondPrintSizePriceOnRunWorkerCompleted;
            bgWorkerGetSecondPrintSizePrice.RunWorkerAsync(secondPrintSizeDataStructure);
        }
        private void bgWorkerGetSecondPrintSizePriceOnDoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is SecondPrintSizeDataStructure myData)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        List<PrintSizePriceViewModel> result = db.PrintSizePricesGenericRepository
                            .Get(x => x.Id == myData.PrintSizeId)
                            .Select(x => new PrintSizePriceViewModel
                            {
                                SecontPrintPrice = x.SecondPrintPrice
                            }).ToList();

                        if (result.Any())
                            myData.Price = (result[0].SecontPrintPrice * myData.Count).ToString("##,###");
                        e.Result = myData;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                    e.Result = null;
                }
            }
        }
        private void bgWorkerGetSecondPrintSizePriceOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is SecondPrintSizeDataStructure myData)
            {
                switch (myData.TextBoxName)
                {
                    case "txtSecondPrintSizePrice1":
                        txtSecondPrintSizePrice1.Text = myData.Price;
                        break;
                    case "txtSecondPrintSizePrice2":
                        txtSecondPrintSizePrice2.Text = myData.Price;
                        break;
                    case "txtSecondPrintSizePrice3":
                        txtSecondPrintSizePrice3.Text = myData.Price;
                        break;
                    case "txtSecondPrintSizePrice4":
                        txtSecondPrintSizePrice4.Text = myData.Price;
                        break;
                }
            }
        }

        #endregion

        #region GetSecondPrintServicePrice
        private void GetSecondPrintServicePrice(SecondPrintServiceDataStructure secondPrintServiceData)

        {
            var bgWorkerGetSecondPrintServicePrice = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = false
            };

            bgWorkerGetSecondPrintServicePrice.DoWork += BgWorkerGetSecondPrintServicePrice_DoWork;
            bgWorkerGetSecondPrintServicePrice.RunWorkerCompleted += BgWorkerGetSecondPrintServicePriceOnRunWorkerCompleted;
            bgWorkerGetSecondPrintServicePrice.RunWorkerAsync(secondPrintServiceData);
        }
        private static void BgWorkerGetSecondPrintServicePrice_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is SecondPrintServiceDataStructure myData)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServices_PrintSizePriceGenericRepository.Get(x =>
                                x.PrintSizePriceId == myData.PrintSizePriceId &&
                                x.PrintServiceId == myData.PrintServiceId)
                            .Select(x => new PrintServiceType_PrintSizePriceViewModel
                            {
                                Price = x.Price
                            }).ToList();

                        if (result.Any())
                        {
                            if (result[0].Price.HasValue)
                            {
                                myData.Price = (result[0].Price.Value * myData.Count).ToString("##,###");
                                e.Result = myData;
                            }
                            else
                                e.Result = null;
                        }
                        else
                            e.Result = null;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                    e.Result = null;
                }
            }
        }
        private void BgWorkerGetSecondPrintServicePriceOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is SecondPrintServiceDataStructure myData)
            {
                switch (myData.TextBoxName)
                {
                    case "txtSecondPrintServicePrice1":
                        txtSecondPrintServicePrice1.Text = myData.Price;
                        break;
                    case "txtSecondPrintServicePrice2":
                        txtSecondPrintServicePrice2.Text = myData.Price;
                        break;
                    case "txtSecondPrintServicePrice3":
                        txtSecondPrintServicePrice3.Text = myData.Price;
                        break;
                    case "txtSecondPrintServicePrice4":
                        txtSecondPrintServicePrice4.Text = myData.Price;
                        break;
                }
            }
        }
        #endregion


        #region Buttons
        private void btnOkPhotoOrderPrint_Click(object sender, EventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnNextPhoto_Click(object sender, EventArgs e)
        {
            if (_photoCursor >= 0)
                btnPreviousPhoto.Enabled = true;
            try
            {
                int totalItems = _photoOrderDetailsList.Count;
                if (_photoCursor >= 0 && _photoCursor < totalItems)
                {
                    //Save Photo Order Details to Class
                    //...
                    var currentGuid = _photoOrderDetailsList[_photoCursor].StreamId;
                    var currentOrderDetails = _photoOrderDetailsList.FirstOrDefault(x => x.StreamId == currentGuid);
                    if (currentOrderDetails != null)
                    {
                        ///////
                        // Original Print
                        //
                        //currentOrderDetails.PhotoCursor = _photoCursor;

                        if (cmbOriginalPrintSize.SelectedValue != null &&
                            int.TryParse(cmbOriginalPrintSize.SelectedValue.ToString(), out var ttt))
                            currentOrderDetails.OriginalSizeId = ttt;

                        if (int.TryParse(txtOriginalPrintSizePrice.Text.Replace(",", ""), out var tt))
                            currentOrderDetails.OriginalPrintSizePrice = tt;

                        if (checkBoxLoadPrintSizeServices.Checked)
                        {
                            if (cmbOriginalPrintService.Items.Count > 0)
                            {
                                currentOrderDetails.OriginalServiceId = (int)cmbOriginalPrintService.SelectedValue;
                                currentOrderDetails.HasOriginalPrintService = true;
                                if (int.TryParse(txtOriginalPrintServicePrice.Text.Replace(",", ""), out var result))
                                    currentOrderDetails.OriginalPrintServicePrice = result;
                            }
                        }

                        if (!string.IsNullOrEmpty(textPhotoRetouchDescription.Text.Trim()))
                            currentOrderDetails.RetouchDescriptions = textPhotoRetouchDescription.Text;

                        ///////
                        // Second Print 1
                        //
                        if (checkBoxSecondPrint1.Checked)
                        {
                            if (cmbSecondPrintSize1.Items.Count > 0)
                            {
                                if (cmbSecondPrintSize1.SelectedValue != null &&
                                    int.TryParse(cmbSecondPrintSize1.SelectedValue.ToString(), out var result1))
                                {
                                    currentOrderDetails.SecondPrint1SizeId = result1;
                                    currentOrderDetails.HasSecondPrint1 = true;

                                    if (integerInputSecondPrintCount1.Value > 0)
                                        currentOrderDetails.SecondPrint1Count = integerInputSecondPrintCount1.Value;

                                    if (int.TryParse(txtSecondPrintSizePrice1.Text.Replace(",", ""), out var resultPrice))
                                        currentOrderDetails.SecondPrint1SizePrice = resultPrice;


                                    if (checkBoxLoadSecondPrintServices1.Checked)
                                    {
                                        if (cmbSecondPrintService1.Items.Count > 0)
                                        {
                                            if (cmbSecondPrintService1.SelectedValue != null &&
                                                int.TryParse(cmbSecondPrintService1.SelectedValue.ToString(),
                                                    out var result11))
                                            {
                                                currentOrderDetails.SecondPrint1ServiceId = result11;
                                                currentOrderDetails.HasSecondPrint1Service = true;
                                            }

                                            if (integerInputSecondPrintServiceCount1.Value > 0)
                                                currentOrderDetails.SecondPrint1ServiceCount = 
                                                    integerInputSecondPrintServiceCount1.Value;
                                            if (int.TryParse(txtSecondPrintServicePrice1.Text.Replace(",", ""), out var result))
                                                currentOrderDetails.SecondPrint1ServicePrice = result;
                                        }
                                    }
                                }
                            }
                        }

                        ///////
                        // Second Print 2
                        //
                        if (checkBoxSecondPrint2.Checked)
                        {
                            if (cmbSecondPrintSize2.Items.Count > 0)
                            {
                                if (cmbSecondPrintSize2.SelectedValue != null &&
                                    int.TryParse(cmbSecondPrintSize2.SelectedValue.ToString(), out var result2))
                                {
                                    currentOrderDetails.SecondPrint2SizeId = result2;
                                    currentOrderDetails.HasSecondPrint2 = true;

                                    if (integerInputSecondPrintCount2.Value > 0)
                                        currentOrderDetails.SecondPrint2Count = integerInputSecondPrintCount2.Value;

                                    if (int.TryParse(txtSecondPrintSizePrice2.Text.Replace(",", ""), out var resultPrice))
                                        currentOrderDetails.SecondPrint2SizePrice = resultPrice;


                                    if (checkBoxLoadSecondPrintServices2.Checked)
                                    {
                                        if (cmbSecondPrintService2.Items.Count > 0)
                                        {
                                            if (cmbSecondPrintService2.SelectedValue != null &&
                                                int.TryParse(cmbSecondPrintService2.SelectedValue.ToString(),
                                                    out var result22))
                                            {
                                                currentOrderDetails.SecondPrint2ServiceId = result22;
                                                currentOrderDetails.HasSecondPrint2Service = true;
                                            }

                                            if (integerInputSecondPrintServiceCount2.Value > 0)
                                                currentOrderDetails.SecondPrint2ServiceCount = 
                                                    integerInputSecondPrintServiceCount2.Value;
                                            if (int.TryParse(txtSecondPrintServicePrice2.Text.Replace(",", ""), out var result))
                                                currentOrderDetails.SecondPrint2ServicePrice = result;
                                        }
                                    }
                                }
                            }
                        }

                        ///////
                        // Second Print 3
                        //
                        if (checkBoxSecondPrint3.Checked)
                        {
                            if (cmbSecondPrintSize3.Items.Count > 0)
                            {
                                if (cmbSecondPrintSize3.SelectedValue != null &&
                                    int.TryParse(cmbSecondPrintSize3.SelectedValue.ToString(), out var result3))
                                {
                                    currentOrderDetails.SecondPrint3SizeId = result3;
                                    currentOrderDetails.HasSecondPrint3 = true;

                                    if (integerInputSecondPrintCount3.Value > 0)
                                        currentOrderDetails.SecondPrint3Count = integerInputSecondPrintCount3.Value;

                                    if (int.TryParse(txtSecondPrintSizePrice3.Text.Replace(",", ""), out var resultPrice))
                                        currentOrderDetails.SecondPrint3SizePrice = resultPrice;


                                    if (checkBoxLoadSecondPrintServices3.Checked)
                                    {
                                        if (cmbSecondPrintService3.Items.Count > 0)
                                        {
                                            if (cmbSecondPrintService3.SelectedValue != null &&
                                                int.TryParse(cmbSecondPrintService3.SelectedValue.ToString(),
                                                    out var result33))
                                            {
                                                currentOrderDetails.SecondPrint3ServiceId = result33;
                                                currentOrderDetails.HasSecondPrint3Service = true;
                                            }

                                            if (integerInputSecondPrintServiceCount3.Value > 0)
                                                currentOrderDetails.SecondPrint3ServiceCount = 
                                                    integerInputSecondPrintServiceCount3.Value;
                                            if (int.TryParse(txtSecondPrintServicePrice3.Text.Replace(",", ""), out var result))
                                                currentOrderDetails.SecondPrint3ServicePrice = result;
                                        }
                                    }
                                }
                            }
                        }

                        ///////
                        // Second Print 4
                        //
                        if (checkBoxSecondPrint4.Checked)
                        {
                            if (cmbSecondPrintSize4.Items.Count > 0)
                            {
                                if (cmbSecondPrintSize4.SelectedValue != null &&
                                    int.TryParse(cmbSecondPrintSize4.SelectedValue.ToString(), out var result4))
                                {
                                    currentOrderDetails.SecondPrint4SizeId = result4;
                                    currentOrderDetails.HasSecondPrint4 = true;

                                    if (integerInputSecondPrintCount4.Value > 0)
                                        currentOrderDetails.SecondPrint4Count = integerInputSecondPrintCount4.Value;

                                    if (int.TryParse(txtSecondPrintSizePrice4.Text.Replace(",", ""), out var resultPrice))
                                        currentOrderDetails.SecondPrint4SizePrice = resultPrice;


                                    if (checkBoxLoadSecondPrintServices4.Checked)
                                    {
                                        if (cmbSecondPrintService4.Items.Count > 0)
                                        {
                                            if (cmbSecondPrintService4.SelectedValue != null &&
                                                int.TryParse(cmbSecondPrintService4.SelectedValue.ToString(),
                                                    out var result44))
                                            {
                                                currentOrderDetails.SecondPrint4ServiceId = result44;
                                                currentOrderDetails.HasSecondPrint4Service = true;
                                            }

                                            if (integerInputSecondPrintServiceCount4.Value > 0)
                                                currentOrderDetails.SecondPrint4ServiceCount = 
                                                    integerInputSecondPrintServiceCount4.Value;
                                            if (int.TryParse(txtSecondPrintServicePrice4.Text.Replace(",", ""), out var result))
                                                currentOrderDetails.SecondPrint4ServicePrice = result;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    txtOriginalPrintSizePrice.Clear();
                    txtOriginalPrintServicePrice.Clear();

                    // Load Next Picture
                    _photoCursor++;
                    //int lblCounter = _photoCursor + 1;
                    int lblCounter = _photoCursor + 1;
                    lblCurrentPhoto.Text = (lblCounter).ToString();
                    if (_photoCursor == totalItems - 1)
                    {
                        btnNextPhoto.Enabled = false;
                        //return;
                    }

                    var nextGuid = _photoOrderDetailsList[_photoCursor].StreamId;
                    var nextOrderDetails = _photoOrderDetailsList.FirstOrDefault(x => x.StreamId == nextGuid);
                    if (nextOrderDetails != null)
                    {
                        LoadPicture(nextGuid);

                        ////Original Photo
                        //
                        if (nextOrderDetails.OriginalSizeId == 0)
                            cmbOriginalPrintSize.SelectedIndex = -1;
                        else
                            cmbOriginalPrintSize.SelectedIndex = nextOrderDetails.OriginalSizeId;

                        if (nextOrderDetails.HasOriginalPrintService)
                        {
                            checkBoxLoadPrintSizeServices.Checked = true;
                            if (nextOrderDetails.OriginalServiceId != 0)
                                cmbOriginalPrintService.SelectedValue = nextOrderDetails.OriginalServiceId;
                            else
                                cmbOriginalPrintService.SelectedIndex = -1;
                        }

                        if (nextOrderDetails.RetouchDescriptions != null)
                            textPhotoRetouchDescription.Text = nextOrderDetails.RetouchDescriptions;

                        ////Second Photo
                        //
                        ////SecondPrint1
                        //
                        if (nextOrderDetails.HasSecondPrint1)
                        {
                            if (nextOrderDetails.SecondPrint1SizeId != 0)
                            {
                                cmbSecondPrintSize1.SelectedValue = nextOrderDetails.SecondPrint1SizeId;
                                if (nextOrderDetails.HasSecondPrint1Service)
                                {
                                    if (nextOrderDetails.SecondPrint1SizeId != 0)
                                    {
                                        checkBoxSecondPrint1.Checked = true;
                                        cmbSecondPrintSize1.SelectedValue = nextOrderDetails.SecondPrint1SizeId;
                                        if (nextOrderDetails.HasSecondPrint1Service)
                                        {
                                            if (nextOrderDetails.SecondPrint1ServiceId != 0)
                                            {
                                                checkBoxLoadSecondPrintServices1.Checked = true;
                                                cmbSecondPrintService1.SelectedValue =
                                                    nextOrderDetails.SecondPrint1ServiceId;
                                                integerInputSecondPrintServiceCount1.Value =
                                                    nextOrderDetails.SecondPrint1ServiceCount;
                                            }
                                        }
                                    }
                                    else
                                        cmbSecondPrintSize1.SelectedIndex = -1;
                                }
                            }
                            else
                                cmbSecondPrintSize1.SelectedIndex = -1;
                        }


                        ////Second Photo
                        //
                        ////SecondPrint2
                        //
                        if (nextOrderDetails.HasSecondPrint2)
                        {
                            if (nextOrderDetails.SecondPrint2SizeId != 0)
                            {
                                cmbSecondPrintSize2.SelectedValue = nextOrderDetails.SecondPrint2SizeId;
                                if (nextOrderDetails.HasSecondPrint2Service)
                                {
                                    if (nextOrderDetails.SecondPrint2SizeId != 0)
                                    {
                                        checkBoxSecondPrint2.Checked = true;
                                        cmbSecondPrintSize2.SelectedValue = nextOrderDetails.SecondPrint2SizeId;
                                        if (nextOrderDetails.HasSecondPrint2Service)
                                        {
                                            if (nextOrderDetails.SecondPrint2ServiceId != 0)
                                            {
                                                checkBoxLoadSecondPrintServices2.Checked = true;
                                                cmbSecondPrintService2.SelectedValue =
                                                    nextOrderDetails.SecondPrint2ServiceId;
                                                integerInputSecondPrintServiceCount2.Value =
                                                    nextOrderDetails.SecondPrint2ServiceCount;
                                            }
                                        }
                                    }
                                    else
                                        cmbSecondPrintSize2.SelectedIndex = -1;
                                }
                            }
                            else
                                cmbSecondPrintSize2.SelectedIndex = -1;
                        }

                        ////Second Photo
                        //
                        ////SecondPrint3
                        //
                        if (nextOrderDetails.HasSecondPrint3)
                        {
                            if (nextOrderDetails.SecondPrint3SizeId != 0)
                            {
                                cmbSecondPrintSize3.SelectedValue = nextOrderDetails.SecondPrint3SizeId;
                                if (nextOrderDetails.HasSecondPrint3Service)
                                {
                                    if (nextOrderDetails.SecondPrint3SizeId != 0)
                                    {
                                        checkBoxSecondPrint3.Checked = true;
                                        cmbSecondPrintSize3.SelectedValue = nextOrderDetails.SecondPrint3SizeId;
                                        if (nextOrderDetails.HasSecondPrint3Service)
                                        {
                                            if (nextOrderDetails.SecondPrint3ServiceId != 0)
                                            {
                                                checkBoxLoadSecondPrintServices3.Checked = true;
                                                cmbSecondPrintService3.SelectedValue =
                                                    nextOrderDetails.SecondPrint3ServiceId;
                                                integerInputSecondPrintServiceCount3.Value =
                                                    nextOrderDetails.SecondPrint3ServiceCount;
                                            }
                                        }
                                    }
                                    else
                                        cmbSecondPrintSize3.SelectedIndex = -1;
                                }
                            }
                            else
                                cmbSecondPrintSize3.SelectedIndex = -1;
                        }


                        ////Second Photo
                        //
                        ////SecondPrint4
                        //
                        if (nextOrderDetails.HasSecondPrint4)
                        {
                            if (nextOrderDetails.SecondPrint4SizeId != 0)
                            {
                                cmbSecondPrintSize4.SelectedValue = nextOrderDetails.SecondPrint4SizeId;
                                if (nextOrderDetails.HasSecondPrint4Service)
                                {
                                    if (nextOrderDetails.SecondPrint4SizeId != 0)
                                    {
                                        checkBoxSecondPrint4.Checked = true;
                                        cmbSecondPrintSize4.SelectedValue = nextOrderDetails.SecondPrint4SizeId;
                                        if (nextOrderDetails.HasSecondPrint4Service)
                                        {
                                            if (nextOrderDetails.SecondPrint4ServiceId != 0)
                                            {
                                                checkBoxLoadSecondPrintServices4.Checked = true;
                                                cmbSecondPrintService4.SelectedValue =
                                                    nextOrderDetails.SecondPrint4ServiceId;
                                                integerInputSecondPrintServiceCount4.Value =
                                                    nextOrderDetails.SecondPrint4ServiceCount;
                                            }
                                        }
                                    }
                                    else
                                        cmbSecondPrintSize4.SelectedIndex = -1;
                                }
                            }
                            else
                                cmbSecondPrintSize4.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

            ResetTextBoxesAndComboxes();
        }

        private void ResetTextBoxesAndComboxes()
        {
            txtSecondPrintServicePrice4.ResetText();
            txtSecondPrintServicePrice4.Enabled = false;

            integerInputSecondPrintServiceCount4.Value = 1;
            integerInputSecondPrintServiceCount4.Enabled = false;

            cmbSecondPrintService4.SelectedIndex = -1;
            cmbSecondPrintService4.Enabled = false;

            checkBoxLoadSecondPrintServices4.Checked = false;
            checkBoxLoadSecondPrintServices4.Enabled = false;

            txtSecondPrintSizePrice4.ResetText();
            txtSecondPrintSizePrice4.Enabled = false;

            integerInputSecondPrintCount4.Value = 1;
            integerInputSecondPrintCount4.Enabled = false;

            cmbSecondPrintSize4.SelectedIndex = -1;
            cmbSecondPrintSize4.Enabled = false;

            checkBoxSecondPrint4.Checked = false;




            txtSecondPrintServicePrice3.ResetText();
            txtSecondPrintServicePrice3.Enabled = false;

            integerInputSecondPrintServiceCount3.Value = 1;
            integerInputSecondPrintServiceCount3.Enabled = false;

            cmbSecondPrintService3.SelectedIndex = -1;
            cmbSecondPrintService3.Enabled = false;

            checkBoxLoadSecondPrintServices3.Checked = false;
            checkBoxLoadSecondPrintServices3.Enabled = false;

            txtSecondPrintSizePrice3.ResetText();
            txtSecondPrintSizePrice3.Enabled = false;

            integerInputSecondPrintCount3.Value = 1;
            integerInputSecondPrintCount3.Enabled = false;

            cmbSecondPrintSize3.SelectedIndex = -1;
            cmbSecondPrintSize3.Enabled = false;

            checkBoxSecondPrint3.Checked = false;




            txtSecondPrintServicePrice2.ResetText();
            txtSecondPrintServicePrice2.Enabled = false;

            integerInputSecondPrintServiceCount2.Value = 1;
            integerInputSecondPrintServiceCount2.Enabled = false;

            cmbSecondPrintService2.SelectedIndex = -1;
            cmbSecondPrintService2.Enabled = false;

            checkBoxLoadSecondPrintServices2.Checked = false;
            checkBoxLoadSecondPrintServices2.Enabled = false;

            txtSecondPrintSizePrice2.ResetText();
            txtSecondPrintSizePrice2.Enabled = false;

            integerInputSecondPrintCount2.Value = 1;
            integerInputSecondPrintCount2.Enabled = false;

            cmbSecondPrintSize2.SelectedIndex = -1;
            cmbSecondPrintSize2.Enabled = false;

            checkBoxSecondPrint2.Checked = false;




            txtSecondPrintServicePrice1.ResetText();
            txtSecondPrintServicePrice1.Enabled = false;

            integerInputSecondPrintServiceCount1.Value = 1;
            integerInputSecondPrintServiceCount1.Enabled = false;

            cmbSecondPrintService1.SelectedIndex = -1;
            cmbSecondPrintService1.Enabled = false;

            checkBoxLoadSecondPrintServices1.Checked = false;
            checkBoxLoadSecondPrintServices1.Enabled = false;

            txtSecondPrintSizePrice1.ResetText();
            txtSecondPrintSizePrice1.Enabled = false;

            integerInputSecondPrintCount1.Value = 1;
            integerInputSecondPrintCount1.Enabled = false;

            cmbSecondPrintSize1.SelectedIndex = -1;
            cmbSecondPrintSize1.Enabled = false;

            checkBoxSecondPrint1.Checked = false;


            textPhotoRetouchDescription.ResetText();
            txtOriginalPrintServicePrice.ResetText();
            cmbOriginalPrintService.SelectedIndex = -1;
            cmbOriginalPrintService.Enabled = false;
            checkBoxLoadPrintSizeServices.Checked = false;
            checkBoxLoadPrintSizeServices.Enabled = false;
            txtOriginalPrintSizePrice.ResetText();
            cmbOriginalPrintSize.SelectedIndex = -1;
        }

        private void btnPreviousPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                _photoCursor--;
                int totalItems = FileStreamsGuids.Count;

                int lblCounter = _photoCursor;
                lblCurrentPhoto.Text = (lblCounter).ToString();

                if (_photoCursor > 0)
                {
                    //Save Photo Order Details to Internal Class
                    //... To Do
                    //...


                    // Load Picture
                    LoadPicture(FileStreamsGuids[_photoCursor - 1]);
                }

                if (_photoCursor < totalItems)
                    btnNextPhoto.Enabled = true;
                if (_photoCursor == 1)
                    btnPreviousPhoto.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        #endregion
    }

    internal class SecondPrintSizeServiceListDataStructure
    {
        public int SizeId { get; set; }
        public string ComboBoxName { get; set; }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public List<PrintServiceType_PrintSizePriceViewModel> SizeServiceList { get; set; }

    }
    internal class SecondPrintServiceListDataStructure
    {
        public string ComboBoxName { get; set; }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public List<PrintSizePriceViewModel> SizeList { get; set; }
    }
    internal class SecondPrintSizeDataStructure
    {
        public TextBoxX MyTextBoxX { get; set; }

        public string Price { get; set; }
        public int Count { get; set; }
        public string TextBoxName { get; set; }

        public int PrintSizeId { get; set; }

        public SecondPrintSizeDataStructure()
        {
            MyTextBoxX = new TextBoxX();
            Count = 1;
        }
    }
    internal class SecondPrintServiceDataStructure
    {
        public TextBoxX MyTextBoxX { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
        public string TextBoxName { get; set; }
        public int PrintSizePriceId { get; set; }
        public int PrintServiceId { get; set; }


        public SecondPrintServiceDataStructure()
        {
            MyTextBoxX = new TextBoxX();
            Count = 1;
        }
    }
}
