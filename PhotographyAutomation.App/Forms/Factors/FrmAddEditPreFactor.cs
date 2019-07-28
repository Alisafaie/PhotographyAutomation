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
        private int _photoCursor = 1;


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
                GetOrderPrintInfo();
                LoadPicture(FileStreamsGuids[_photoCursor - 1]);
                if (FileStreamsGuids.Count == 1)
                {
                    btnNextPhoto.Enabled = false;
                    btnPreviousPhoto.Enabled = false;
                }
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
        }



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



        private void LoadPicture(Guid fileStreamsGuid)
        {
            bgWorkerLoadPicture.RunWorkerAsync(fileStreamsGuid);
            circularProgressPictures.IsRunning = bgWorkerLoadPicture.IsBusy;
        }
        private void bgWorkerLoadPicture_DoWork(object sender, DoWorkEventArgs e)
        {
            var streamId = new Guid(e.Argument.ToString());
            try
            {
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
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
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }


        #region Buttons

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion


        #region LoadOriginalPrintSizes

        private void LoadOriginalPrintSizes()
        {
            bgWorkerLoadOriginalPringSizes.RunWorkerAsync();
            circularProgress.IsRunning = bgWorkerLoadOriginalPringSizes.IsBusy;
            cmbOriginalPrintSize.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;

            checkBoxSecondPrint1.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
            checkBoxSecondPrint2.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
            checkBoxSecondPrint3.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
            checkBoxSecondPrint4.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
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
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }

        private void bgWorkerLoadOriginalPringSizes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                cmbOriginalPrintSize.DataSource = e.Result;
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
        }

        #endregion



        #region cmbOriginalPrintSize

        private void cmbOriginalPrintSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOriginalPrintSize.Focused && (int)cmbOriginalPrintSize.SelectedValue > 0 &&
                cmbOriginalPrintSize.SelectedIndex != -1)
            {
                _selectedOriginalSizeId = (int)cmbOriginalPrintSize.SelectedValue;
                cmbOriginalPrintService.SelectedIndex = -1;
                checkBoxLoadPrintSizeServices.Checked = false;
                txtOriginalPrintServicePrice.ResetText();
                GetOriginalPrintSizePrice(_selectedOriginalSizeId);
            }
        }

        #region GetOriginalPrintSizePrice

        private void GetOriginalPrintSizePrice(int printSizeId)
        {
            bgWorkerGetOriginalPrintPrice.RunWorkerAsync(printSizeId);
            circularProgress.IsRunning = bgWorkerGetOriginalPrintPrice.IsBusy;
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
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void bgWorkerGetOriginalPrintPrice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        #endregion GetOriginalPrintSizePrice

        #endregion



        #region checkBoxLoadPrintSizeServices

        private void checkBoxLoadPrintSizeServices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadPrintSizeServices.Checked)
            {
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
            bgWorkerLoadPrintSizeServices.RunWorkerAsync(printSizeId);
            circularProgress.IsRunning = bgWorkerLoadPrintSizeServices.IsBusy;
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
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void bgWorkerLoadPrintSizeServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result != null)
            {
                cmbOriginalPrintService.DataSource = e.Result;
                cmbOriginalPrintService.DisplayMember = "PrintServiceName";
                cmbOriginalPrintService.ValueMember = "Id";
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
                    cmbOriginalPrintService_SelectedIndexChanged();
                }

                //GetPrintServicePrice(_selectedPrintServiceId);
            }
        }

        private void cmbOriginalPrintService_SelectedIndexChanged()
        {
            if (cmbOriginalPrintService.Enabled && cmbOriginalPrintService.Items.Count > 0 &&
                cmbOriginalPrintService.SelectedValue != null)
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
            if (bgWorkerGetPrintServicePrice.IsBusy == false)
            {
                bgWorkerGetPrintServicePrice.RunWorkerAsync(printServiceId);
                circularProgress.IsRunning = bgWorkerGetPrintServicePrice.IsBusy;
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
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void bgWorkerGetPrintServicePrice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        #endregion



        #region GetSecondPrintSizePrice

        private static string GetSecondPrintSizePrice(int printSizeId)
        {
            string returnValue = null;
            if (printSizeId <= 0) return null;
            try
            {
                using (var db = new UnitOfWork())
                {
                    List<PrintSizePriceViewModel> result = db.PrintSizePricesGenericRepository
                        .Get(x => x.Id == printSizeId)
                        .Select(x => new PrintSizePriceViewModel
                        {
                            SecontPrintPrice = x.SecondPrintPrice
                        }).ToList();

                    if (result.Any())
                        returnValue = result[0].SecontPrintPrice.ToString("##,###");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
                returnValue = null;
            }
            return returnValue;
        }

        private void checkBoxSecondPrint1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint1.Checked)
            {
                cmbSecondPrintSize1.Enabled = true;
                checkBoxLoadSecondPrintSize1.Enabled = true;
            }
            else
            {
                cmbSecondPrintSize1.Enabled = false;
                txtSecondPrintSizePrice1.ResetText();
                cmbSecondPrintService1.SelectedIndex = -1;
                cmbSecondPrintService1.Enabled = false;
                txtSecondPrintServicePrice1.ResetText();
                integerInputSecontPrintTotal1.Enabled = false;
                checkBoxLoadSecondPrintSize1.Checked = false;
            }
        }

        private void cmbSecondPrintSize1_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize1.Enabled)
            {
                try
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
                            cmbSecondPrintSize1.DataSource = result;
                            cmbSecondPrintSize1.DisplayMember = "SizeName";
                            cmbSecondPrintSize1.ValueMember = "Id";

                            txtSecondPrintSizePrice1.Enabled = true;
                            checkBoxLoadSecondPrintSize1.Enabled = true;
                            integerInputSecontPrintTotal1.Enabled = true;

                            cmbSecondPrintSize1_SelectedIndexChanged();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintSize1_SelectedIndexChanged()
        {
            if (cmbSecondPrintSize1.Enabled && cmbSecondPrintSize1.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize1.SelectedValue.ToString(), out int selectedValue))
                {
                    txtSecondPrintSizePrice1.Text = GetSecondPrintSizePrice(selectedValue);
                    if (checkBoxLoadSecondPrintSize1.Checked)
                    {
                        cmbSecondPrintService1_EnabledChanged();
                    }
                }
            }
        }

        #endregion



        #region SecondPrint2


        private void checkBoxSecondPrint2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint2.Checked)
            {
                cmbSecondPrintSize2.Enabled = true;
                checkBoxLoadSecondPrintSize2.Enabled = true;
            }
            else
            {
                cmbSecondPrintSize2.Enabled = false;
                txtSecondPrintSizePrice2.ResetText();
                cmbSecondPrintService2.SelectedIndex = -1;
                cmbSecondPrintService2.Enabled = false;
                txtSecondPrintServicePrice2.ResetText();
                integerInputSecontPrintTotal2.Enabled = false;
            }
        }

        private void cmbSecondPrintSize2_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize2.Enabled)
            {
                try
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
                            cmbSecondPrintSize2.DataSource = result;
                            cmbSecondPrintSize2.DisplayMember = "SizeName";
                            cmbSecondPrintSize2.ValueMember = "Id";

                            txtSecondPrintSizePrice2.Enabled = true;
                            checkBoxLoadSecondPrintSize2.Enabled = true;
                            integerInputSecontPrintTotal2.Enabled = true;

                            cmbSecondPrintSize2_SelectedIndexChanged();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintSize2_SelectedIndexChanged()
        {
            if (cmbSecondPrintSize2.Enabled && cmbSecondPrintSize2.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize2.SelectedValue.ToString(), out int selectedValue))
                {
                    txtSecondPrintSizePrice2.Text = GetSecondPrintSizePrice(selectedValue);
                    if (checkBoxLoadSecondPrintSize1.Checked)
                    {
                        cmbSecondPrintService1_EnabledChanged();
                    }
                }
            }
        }


        #endregion



        #region SecondPrint3

        private void checkBoxSecondPrint3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint3.Checked)
            {
                cmbSecondPrintSize3.Enabled = true;
                checkBoxLoadSecondPrintSize3.Enabled = true;
            }
            else
            {
                cmbSecondPrintSize3.Enabled = false;
                txtSecondPrintSizePrice3.ResetText();
                cmbSecondPrintService3.SelectedIndex = -1;
                cmbSecondPrintService3.Enabled = false;
                txtSecondPrintServicePrice3.ResetText();
                integerInputSecontPrintTotal3.Enabled = false;
            }
        }

        private void cmbSecondPrintSize3_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize3.Enabled)
            {
                try
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
                            cmbSecondPrintSize3.DataSource = result;
                            cmbSecondPrintSize3.DisplayMember = "SizeName";
                            cmbSecondPrintSize3.ValueMember = "Id";

                            txtSecondPrintSizePrice3.Enabled = true;
                            checkBoxLoadSecondPrintSize3.Enabled = true;
                            integerInputSecontPrintTotal3.Enabled = true;

                            cmbSecondPrintSize3_SelectedIndexChanged();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintSize3_SelectedIndexChanged()
        {
            if (cmbSecondPrintSize3.Enabled && cmbSecondPrintSize3.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize3.SelectedValue.ToString(), out int selectedValue))
                {
                    txtSecondPrintSizePrice3.Text = GetSecondPrintSizePrice(selectedValue);
                    if (checkBoxLoadSecondPrintSize3.Checked)
                    {
                        cmbSecondPrintService3_EnabledChanged();
                    }
                }
            }
        }

        #endregion



        #region SecondPrint4

        private void checkBoxSecondPrint4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSecondPrint4.Checked)
            {
                cmbSecondPrintSize4.Enabled = true;
                checkBoxLoadSecondPrintSize4.Enabled = true;
            }
            else
            {
                cmbSecondPrintSize4.Enabled = false;
                txtSecondPrintSizePrice4.ResetText();
                cmbSecondPrintService4.SelectedIndex = -1;
                cmbSecondPrintService4.Enabled = false;
                txtSecondPrintServicePrice4.ResetText();
                integerInputSecontPrintTotal4.Enabled = false;
            }
        }

        private void cmbSecondPrintSize4_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintSize4.Enabled)
            {
                try
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
                            cmbSecondPrintSize4.DataSource = result;
                            cmbSecondPrintSize4.DisplayMember = "SizeName";
                            cmbSecondPrintSize4.ValueMember = "Id";

                            txtSecondPrintSizePrice4.Enabled = true;
                            checkBoxLoadSecondPrintSize4.Enabled = true;
                            integerInputSecontPrintTotal4.Enabled = true;

                            cmbSecondPrintSize4_SelectedIndexChanged();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintSize4_SelectedIndexChanged()
        {
            if (cmbSecondPrintSize4.Enabled && cmbSecondPrintSize4.Items.Count > 0)
            {
                if (int.TryParse(cmbSecondPrintSize4.SelectedValue.ToString(), out int selectedValue))
                {
                    txtSecondPrintSizePrice4.Text = GetSecondPrintSizePrice(selectedValue);
                    if (checkBoxLoadSecondPrintSize4.Checked)
                    {
                        cmbSecondPrintService4_EnabledChanged();
                    }
                }
            }
        }

        #endregion



        #region GetSecondPrintServicePrice

        private string GetSecondPrintServicePrice()
        {
            string returnValue = "---";
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintServices_PrintSizePriceGenericRepository.Get(x =>
                            x.PrintSizePriceId == (int)cmbSecondPrintSize1.SelectedValue &&
                            x.PrintServiceId == (int)cmbSecondPrintService1.SelectedValue)
                        .Select(x => new PrintServiceType_PrintSizePriceViewModel
                        {
                            Price = x.Price
                        }).ToList();

                    if (result.Any())
                        returnValue = result[0].Price?.ToString("##,###");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }

            return returnValue;
        }

        private void checkBoxLoadSecondPrintSize1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintSize1.Checked)
            {
                cmbSecondPrintService1.Enabled = true;
                txtSecondPrintServicePrice1.Enabled = true;
            }
            else
            {
                cmbSecondPrintService1.SelectedIndex = -1;
                cmbSecondPrintService1.Enabled = false;
                txtSecondPrintServicePrice1.Enabled = false;
                txtSecondPrintServicePrice1.ResetText();
            }
        }

        private void cmbSecondPrintService1_EnabledChanged()
        {
            if (cmbSecondPrintService1.Enabled)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServices_PrintSizePriceGenericRepository
                            .Get(x => x.PrintSizePriceId == (int)cmbSecondPrintSize1.SelectedValue)
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
                            cmbSecondPrintService1.DataSource = result;
                            cmbSecondPrintService1.DisplayMember = "PrintServiceName";
                            cmbSecondPrintService1.ValueMember = "Id";

                            cmbSecondPrintService1_SelectedIndexChanged();
                        }
                        else
                        {
                            cmbSecondPrintService1.SelectedIndex = -1;
                            cmbSecondPrintService1.DataSource = null;
                            txtSecondPrintServicePrice1.ResetText();
                        }
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService1_SelectedIndexChanged()
        {
            if (cmbSecondPrintService1.Enabled && cmbSecondPrintService1.Items.Count > 0 &&
                cmbSecondPrintService1.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService1.SelectedValue.ToString(), out _))
                {
                    txtSecondPrintServicePrice1.Text = GetSecondPrintServicePrice();
                }
            }
        }


        #endregion



        #region SecondPrintService2

        private void checkBoxLoadSecondPrintSize2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintSize2.Checked)
            {
                cmbSecondPrintService2.Enabled = true;
                txtSecondPrintServicePrice2.Enabled = true;
            }
            else
            {
                cmbSecondPrintService1.SelectedIndex = -1;
                cmbSecondPrintService2.Enabled = false;
                txtSecondPrintServicePrice2.Enabled = false;
                txtSecondPrintServicePrice2.ResetText();
            }
        }

        private void cmbSecondPrintService2_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbSecondPrintService2.Enabled)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServices_PrintSizePriceGenericRepository
                            .Get(x => x.PrintSizePriceId == (int)cmbSecondPrintSize2.SelectedValue)
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
                            cmbSecondPrintService2.DataSource = result;
                            cmbSecondPrintService2.DisplayMember = "PrintServiceName";
                            cmbSecondPrintService2.ValueMember = "Id";

                            cmbSecondPrintService2_SelectedIndexChanged();
                        }
                        else
                        {
                            cmbSecondPrintService2.SelectedIndex = -1;
                            cmbSecondPrintService2.DataSource = null;
                            txtSecondPrintServicePrice2.ResetText();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService2_SelectedIndexChanged()
        {
            if (cmbSecondPrintService2.Enabled && cmbSecondPrintService2.Items.Count > 0 &&
                cmbSecondPrintService2.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService2.SelectedValue.ToString(), out _))
                {
                    txtSecondPrintServicePrice2.Text = GetSecondPrintServicePrice();
                }
            }
        }

        #endregion



        #region SecondPrintSize3

        private void checkBoxLoadSecondPrintSize3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintSize3.Checked)
            {
                cmbSecondPrintService3.Enabled = true;
                txtSecondPrintServicePrice3.Enabled = true;
            }
            else
            {
                cmbSecondPrintService3.SelectedIndex = -1;
                cmbSecondPrintService3.Enabled = false;
                txtSecondPrintServicePrice3.Enabled = false;
                txtSecondPrintServicePrice3.ResetText();
            }
        }

        private void cmbSecondPrintService3_EnabledChanged()
        {
            if (cmbSecondPrintService3.Enabled)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServices_PrintSizePriceGenericRepository
                            .Get(x => x.PrintSizePriceId == (int)cmbSecondPrintSize3.SelectedValue)
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
                            cmbSecondPrintService3.DataSource = result;
                            cmbSecondPrintService3.DisplayMember = "PrintServiceName";
                            cmbSecondPrintService3.ValueMember = "Id";

                            cmbSecondPrintService3_SelectedIndexChanged();
                        }
                        else
                        {
                            cmbSecondPrintService3.SelectedIndex = -1;
                            cmbSecondPrintService3.DataSource = null;
                            txtSecondPrintServicePrice3.ResetText();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService3_SelectedIndexChanged()
        {
            if (cmbSecondPrintService3.Enabled && cmbSecondPrintService3.Items.Count > 0 &&
                cmbSecondPrintService3.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService3.SelectedValue.ToString(), out _))
                {
                    txtSecondPrintServicePrice3.Text = GetSecondPrintServicePrice();
                }
            }
        }

        #endregion


        #region SecondPrintSize4

        private void checkBoxLoadSecondPrintSize4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadSecondPrintSize4.Checked)
            {
                cmbSecondPrintService4.Enabled = true;
                txtSecondPrintServicePrice4.Enabled = true;
            }
            else
            {
                cmbSecondPrintService4.SelectedIndex = -1;
                cmbSecondPrintService4.Enabled = false;
                txtSecondPrintServicePrice4.Enabled = false;
                txtSecondPrintServicePrice4.ResetText();
            }
        }

        private void cmbSecondPrintService4_EnabledChanged()
        {
            if (cmbSecondPrintService4.Enabled)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServices_PrintSizePriceGenericRepository
                            .Get(x => x.PrintSizePriceId == (int)cmbSecondPrintSize4.SelectedValue)
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
                            cmbSecondPrintService4.DataSource = result;
                            cmbSecondPrintService4.DisplayMember = "PrintServiceName";
                            cmbSecondPrintService4.ValueMember = "Id";

                            cmbSecondPrintService4_SelectedIndexChanged();
                        }
                        else
                        {
                            cmbSecondPrintService4.SelectedIndex = -1;
                            cmbSecondPrintService4.DataSource = null;
                            txtSecondPrintServicePrice4.ResetText();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"exception: " + exception.Message);
                }
            }
        }

        private void cmbSecondPrintService4_SelectedIndexChanged()
        {
            if (cmbSecondPrintService4.Enabled && cmbSecondPrintService4.Items.Count > 0 &&
                cmbSecondPrintService4.SelectedValue != null)
            {
                if (int.TryParse(cmbSecondPrintService4.SelectedValue.ToString(), out _))
                {
                    txtSecondPrintServicePrice4.Text = GetSecondPrintServicePrice();
                }
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

        private void btnNextPhoto_Click(object sender, EventArgs e)
        {
            _photoCursor++;
            int totalItems = FileStreamsGuids.Count;

            int lblCounter = _photoCursor;
            lblCurrentPhoto.Text = (lblCounter).ToString();

            if (_photoCursor < totalItems)
            {
                LoadPicture(FileStreamsGuids[_photoCursor - 1]);
            }

            if (_photoCursor > 0)
                btnPreviousPhoto.Enabled = true;
            if (_photoCursor == totalItems)
                btnNextPhoto.Enabled = false;
        }

        private void btnPreviousPhoto_Click(object sender, EventArgs e)
        {
            _photoCursor--;
            int totalItems = FileStreamsGuids.Count;

            int lblCounter = _photoCursor;
            lblCurrentPhoto.Text = (lblCounter).ToString();

            if (_photoCursor > 0)
            {
                LoadPicture(FileStreamsGuids[_photoCursor - 1]);
            }
            if (_photoCursor < totalItems)
                btnNextPhoto.Enabled = true;
            if (_photoCursor == 1)
                btnPreviousPhoto.Enabled = false;
        }
    }
}
