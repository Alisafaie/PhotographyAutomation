using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Admin
{
    public partial class FrmAddEditPrintSizeAndServices_Refactored : Form
    {
        #region Variables

        private readonly BackgroundWorker _bgWorkerGetAllPhotoSizes = new BackgroundWorker
        {
            WorkerReportsProgress = false,
            WorkerSupportsCancellation = false
        };
        private readonly BackgroundWorker _bgWorkerGetAllPhotoSizePrices = new BackgroundWorker
        {
            WorkerReportsProgress = false,
            WorkerSupportsCancellation = false
        };
        private readonly BackgroundWorker _bgWorkerGetAllPrintSizeServices = new BackgroundWorker
        {
            WorkerReportsProgress = false,
            WorkerSupportsCancellation = false
        };


        private List<PrintSizesViewModel> _printSizesViewModels;
        private List<PrintSizePricesViewModel> _printSizePricesViewModels;

        #endregion Variables


        #region Form Events
        public FrmAddEditPrintSizeAndServices_Refactored()
        {
            InitializeComponent();

            _bgWorkerGetAllPhotoSizePrices.DoWork += _bgWorkerGetAllPhotoSizePrices_DoWork;
            _bgWorkerGetAllPhotoSizePrices.RunWorkerCompleted += _bgWorkerGetAllPhotoSizePrices_RunWorkerCompleted;

            _bgWorkerGetAllPhotoSizes.DoWork += BgWorkerGetAllPhotoSizes_DoWork;
            _bgWorkerGetAllPhotoSizes.RunWorkerCompleted += BgWorkerGetAllPhotoSizes_RunWorkerCompleted;

            _bgWorkerGetAllPrintSizeServices.DoWork += _bgWorkerGetAllPrintSizeServices_DoWork;
            _bgWorkerGetAllPrintSizeServices.RunWorkerCompleted += _bgWorkerGetAllPrintSizeServices_RunWorkerCompleted;
        }

        private void FrmAddEditPrintSizeAndServices_Refactored_Load(object sender, EventArgs e)
        {
            GetAllPhotoSizes();
            GetAllPhotoSizePrices();
            //GetAllPrintSizeServices();
        }

        #region GetAllPhotoSizes

        private void GetAllPhotoSizes()
        {
            try
            {
                _bgWorkerGetAllPhotoSizes.RunWorkerAsync();
                EnableOrDisableControlsToGetAllPrintSizes();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        private static void BgWorkerGetAllPhotoSizes_DoWork(object sender, DoWorkEventArgs e)
        {
        RetryGetInfo:
            try
            {

                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizeRepository.GetAllPrintSizes();

                    if (result == null || result.Count == 0) return;
                    e.Result = result;
                }
            }
            catch (NullReferenceException)
            {
                goto RetryGetInfo;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Message: ");
                Debug.WriteLine(exception.Message);

                Debug.WriteLine("Inner Exception: ");
                Debug.WriteLine(exception.InnerException);

                Debug.WriteLine("Inner Exception Message:");
                Debug.WriteLine(exception.InnerException?.Message);

                Debug.WriteLine("Source: ");
                Debug.WriteLine(exception.Source);

                Debug.WriteLine("Data: ");
                Debug.WriteLine(exception.Data);

                Debug.WriteLine("Stack Trace: ");
                Debug.WriteLine(exception.StackTrace);
            }
        }
        private void BgWorkerGetAllPhotoSizes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null && e.Result is List<PrintSizesViewModel> viewModel)
                {
                    _printSizesViewModels = viewModel;


                    cmbPrintSizes.DataSource = viewModel;
                    cmbPrintSizes.DisplayMember = "Name";
                    cmbPrintSizes.ValueMember = "Id";
                }
                else
                {
                    ShowErrorProvider(errorProvider1, cmbPrintSizes, 4, "اطلاعات اندازه چاپ ها قابل دریافت نمی باشد.");
                }


                EnableOrDisableControlsToGetAllPrintSizes();
            }
            catch (ArgumentNullException exception)
            {
                ShowErrorProvider(errorProvider1, cmbPrintSizes, 4,
                    "خطا در دریافت اطلاعات. لطفا فرم را بسته و مجددا باز نمایید.");

                Debug.WriteLine("Message: ");
                Debug.WriteLine(exception.Message);

                Debug.WriteLine("Inner Exception: ");
                Debug.WriteLine(exception.InnerException);

                Debug.WriteLine("Inner Exception Message:");
                Debug.WriteLine(exception.InnerException?.Message);

                Debug.WriteLine("Source: ");
                Debug.WriteLine(exception.Source);

                Debug.WriteLine("Data: ");
                Debug.WriteLine(exception.Data);

                Debug.WriteLine("Stack Trace: ");
                Debug.WriteLine(exception.StackTrace);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        #endregion


        #region GetAllPhotoSizePrices

        private void GetAllPhotoSizePrices()
        {
            _bgWorkerGetAllPhotoSizePrices.RunWorkerAsync();
            EnableOrDisableControlsToGetAllPrintSizePrices();
        }
        private void _bgWorkerGetAllPhotoSizePrices_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizePriceRepository.GetAllPrintSizePrices();

                    if (result == null || result.Count == 0) return;
                    e.Result = result;
                    _printSizePricesViewModels = result;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Message: ");
                Debug.WriteLine(exception.Message);

                Debug.WriteLine("Inner Exception: ");
                Debug.WriteLine(exception.InnerException);

                Debug.WriteLine("Inner Exception Message:");
                Debug.WriteLine(exception.InnerException?.Message);

                Debug.WriteLine("Source: ");
                Debug.WriteLine(exception.Source);

                Debug.WriteLine("Data: ");
                Debug.WriteLine(exception.Data);

                Debug.WriteLine("Stack Trace: ");
                Debug.WriteLine(exception.StackTrace);
            }
        }
        private void _bgWorkerGetAllPhotoSizePrices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (cmbPrintSizes.DataSource != null && cmbPrintSizes.Items.Count > 0)
                {
                    if (int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var firstPrintSizeId))
                    {
                        if (_printSizesViewModels != null && _printSizesViewModels.Count > 0)
                        {
                            cmbPrintSizes.SelectedIndex = 1;
                            PrintSizesViewModel pSize = _printSizesViewModels.Find(x => x.Id == firstPrintSizeId);
                            if (pSize != null)
                            {
                                iiMinimumOrder.Value = pSize.MinimumOrder;
                                chkHasItalianAlbum.Checked = pSize.HasItalianAlbum;
                                chkHasLitPrint.Checked = pSize.HasLitPrint;
                                chkHasMedialPhoto.Checked = pSize.HasMedicalPhoto;
                                chkHasScanAndProcess.Checked = pSize.HasScanAndProcessing;
                                chkIsActive.Checked = pSize.IsActive;
                                chkIsDeleted.Checked = pSize.IsDeleted;
                            }
                        }

                        if (_printSizePricesViewModels != null && _printSizePricesViewModels.Count > 0)
                        {
                            PrintSizePricesViewModel pSizePrice =
                                 _printSizePricesViewModels.Find(x => x.PrintSizeId == firstPrintSizeId);
                            if (pSizePrice != null)
                            {
                                if (pSizePrice.FirstPrintPrice != null)
                                    iiFirstPrintPrice.Value = pSizePrice.FirstPrintPrice.Value;
                                if (pSizePrice.RePrintPrice != null) iiRePrintPrice.Value = pSizePrice.RePrintPrice.Value;

                                if (chkHasItalianAlbum.Checked)
                                {
                                    if (pSizePrice.ItalianAlbumPagePrice != null)
                                        iiItalianAlbumPagePrice.Value = pSizePrice.ItalianAlbumPagePrice.Value;
                                    if (pSizePrice.ItalianAlbumPageBoundingPrice != null)
                                        iiItalianAlbumBoundingPrice.Value = pSizePrice.ItalianAlbumPageBoundingPrice.Value;
                                }

                                if (chkHasLitPrint.Checked)
                                {
                                    if (pSizePrice.LitPrintPrice != null)
                                        iiLitPrintFirstPrint.Value = pSizePrice.LitPrintPrice.Value;
                                    if (pSizePrice.LitPrintReprintPrice != null)
                                        iiLitPrintRePrint.Value = pSizePrice.LitPrintReprintPrice.Value;
                                }

                                if (chkHasMedialPhoto.Checked)
                                {
                                    if (pSizePrice.MedicalPrice != null)
                                        iiMedicalFirstPrint.Value = pSizePrice.MedicalPrice.Value;
                                    if (pSizePrice.MedicalRePrintPrice != null)
                                        iiMedicalRePrint.Value = pSizePrice.MedicalRePrintPrice.Value;
                                }

                                if (chkHasScanAndProcess.Checked)
                                {
                                    if (pSizePrice.ScanAndPrintPrice != null)
                                        iiScanAndPrint.Value = pSizePrice.ScanAndPrintPrice.Value;
                                    if (pSizePrice.ScanAndProcessingPrice != null)
                                        iiScanAndProcess.Value = pSizePrice.ScanAndProcessingPrice.Value;
                                }
                            }
                        }
                    }
                }

                //else
                //{
                //    MessageBox.Show(
                //        @"اطلاعات قیمت اندازه چاپ قابل دریافت نمی باشد.",
                //        @"خطا در دریافت اطلاعات از سرور",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Error,
                //        MessageBoxDefaultButton.Button1,
                //        MessageBoxOptions.RightAlign);
                //    //Close();
                //}
                EnableOrDisableControlsToGetAllPrintSizePrices();
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Message: ");
                Debug.WriteLine(exception.Message);

                Debug.WriteLine("Inner Exception: ");
                Debug.WriteLine(exception.InnerException);

                Debug.WriteLine("Inner Exception Message:");
                Debug.WriteLine(exception.InnerException?.Message);

                Debug.WriteLine("Source: ");
                Debug.WriteLine(exception.Source);

                Debug.WriteLine("Data: ");
                Debug.WriteLine(exception.Data);

                Debug.WriteLine("Stack Trace: ");
                Debug.WriteLine(exception.StackTrace);
            }
        }

        #endregion


        #region GetAllPrintSizeServices

        private void GetAllPrintSizeServices()
        {
            _bgWorkerGetAllPrintSizeServices.RunWorkerAsync();
        }
        private void _bgWorkerGetAllPrintSizeServices_DoWork(object sender, DoWorkEventArgs e)
        {
            //using (var db=new UnitOfWork())
            //{
            //    var result=
            //}
        }
        private void _bgWorkerGetAllPrintSizeServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion


        private void GetFirstComboxPrintSizeInfo()
        {
            //int retryCount = 0;
            //RetryGetPrintSizePrice:
            if (cmbPrintSizes.DataSource != null && cmbPrintSizes.Items.Count > 0)
            {
                if (int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var firstPrintSizeId))
                {
                    if (_printSizesViewModels != null && _printSizesViewModels.Count > 0)
                    {
                        PrintSizesViewModel pSize = _printSizesViewModels.Find(x => x.Id == firstPrintSizeId);
                        if (pSize != null)
                        {
                            iiMinimumOrder.Value = pSize.MinimumOrder;
                            chkHasItalianAlbum.Checked = pSize.HasItalianAlbum;
                            chkHasLitPrint.Checked = pSize.HasLitPrint;
                            chkHasMedialPhoto.Checked = pSize.HasMedicalPhoto;
                            chkHasScanAndProcess.Checked = pSize.HasScanAndProcessing;
                            chkIsActive.Checked = pSize.IsActive;
                            chkIsDeleted.Checked = pSize.IsDeleted;
                        }
                    }

                    if (_printSizePricesViewModels != null && _printSizePricesViewModels.Count > 0)
                    {
                        PrintSizePricesViewModel pSizePrice =
                             _printSizePricesViewModels.Find(x => x.PrintSizeId == firstPrintSizeId);
                        if (pSizePrice != null)
                        {
                            if (pSizePrice.FirstPrintPrice != null)
                                iiFirstPrintPrice.Value = pSizePrice.FirstPrintPrice.Value;
                            if (pSizePrice.RePrintPrice != null) iiRePrintPrice.Value = pSizePrice.RePrintPrice.Value;

                            if (chkHasItalianAlbum.Checked)
                            {
                                if (pSizePrice.ItalianAlbumPagePrice != null)
                                    iiItalianAlbumPagePrice.Value = pSizePrice.ItalianAlbumPagePrice.Value;
                                if (pSizePrice.ItalianAlbumPageBoundingPrice != null)
                                    iiItalianAlbumBoundingPrice.Value = pSizePrice.ItalianAlbumPageBoundingPrice.Value;
                            }

                            if (chkHasLitPrint.Checked)
                            {
                                if (pSizePrice.LitPrintPrice != null)
                                    iiLitPrintFirstPrint.Value = pSizePrice.LitPrintPrice.Value;
                                if (pSizePrice.LitPrintReprintPrice != null)
                                    iiLitPrintRePrint.Value = pSizePrice.LitPrintReprintPrice.Value;
                            }

                            if (chkHasMedialPhoto.Checked)
                            {
                                if (pSizePrice.MedicalPrice != null)
                                    iiMedicalFirstPrint.Value = pSizePrice.MedicalPrice.Value;
                                if (pSizePrice.MedicalRePrintPrice != null)
                                    iiMedicalRePrint.Value = pSizePrice.MedicalRePrintPrice.Value;
                            }

                            if (chkHasScanAndProcess.Checked)
                            {
                                if (pSizePrice.ScanAndPrintPrice != null)
                                    iiScanAndPrint.Value = pSizePrice.ScanAndPrintPrice.Value;
                                if (pSizePrice.ScanAndProcessingPrice != null)
                                    iiScanAndProcess.Value = pSizePrice.ScanAndProcessingPrice.Value;
                            }
                        }
                    }
                }
            }

            //if (_bgWorkerGetAllPhotoSizes.IsBusy == false && _bgWorkerGetAllPhotoSizePrices.IsBusy == false)
            //{
            //    if (iiFirstPrintPrice.Text == null || iiRePrintPrice.Text == null)
            //    {
            //        retryCount++;
            //        if (retryCount < 5)
            //            goto RetryGetPrintSizePrice;
            //    }
            //}
        }





        private void EnableOrDisableControlsToGetAllPrintSizes()
        {
            cmbPrintSizes.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            gbMainPrices.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;

            panelMinimumOrder.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            panelMedicalPhoto.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            panelLitPrint.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            panelScanAndProcessing.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            panelHasItalianAlbum.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            panelIsActive.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            panelIsDeleted.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;

            menuStrip1.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
        }
        private void EnableOrDisableControlsToGetAllPrintSizePrices()
        {
            panelPhotoSizePrices.Enabled = !_bgWorkerGetAllPhotoSizePrices.IsBusy;
        }




        #endregion


        #region ChechBoxes
        private void chkHasMedialPhoto_CheckedChanged(object sender, EventArgs e)
        {
            gbMedicalPhotoPrices.Enabled = chkHasMedialPhoto.Checked;
        }

        private void chkHasLitPrint_CheckedChanged(object sender, EventArgs e)
        {
            gbLitPrintPrices.Enabled = chkHasLitPrint.Checked;
        }

        private void chkHasScanAndProcess_CheckedChanged(object sender, EventArgs e)
        {
            gbScanAndPrint.Enabled = chkHasScanAndProcess.Checked;
        }

        private void chkHasItalianAlbum_CheckedChanged(object sender, EventArgs e)
        {
            gbItalianAlbum.Enabled = chkHasItalianAlbum.Checked;
        }

        #endregion


        #region ComboBoxes Selected Index Chenged

        private void cmbPrintSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetInputs();

            if (!int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var printSizeId)) return;

            var sizeModel = _printSizesViewModels.Find(x => x.Id == printSizeId);
            if (sizeModel == null)
            {
                ShowErrorProvider(errorProvider1, cmbPrintSizes, 4, "اطلاعات اندازه چاپ قابل دریافت نمی باشد.");
                return;
            }

            var sizePriceModel = _printSizePricesViewModels.Find(x => x.PrintSizeId == printSizeId);
            if (sizePriceModel == null)
            {
                ShowErrorProvider(errorProvider1, cmbPrintSizes, 4, "اطلاعات قیمت برای این اندازه چاپ ثبت نشده است.");
                return;
            }

            iiMinimumOrder.Value = sizeModel.MinimumOrder;

            if (sizePriceModel.FirstPrintPrice != null) iiFirstPrintPrice.Value = sizePriceModel.FirstPrintPrice.Value;
            if (sizePriceModel.RePrintPrice != null) iiRePrintPrice.Value = sizePriceModel.RePrintPrice.Value;


            if (sizeModel.HasMedicalPhoto)
            {
                panelMedicalPhoto.Enabled = true;
                chkHasMedialPhoto.Enabled = true;
                chkHasMedialPhoto.Checked = true;

                if (sizePriceModel.MedicalPrice != null)
                    iiMedicalFirstPrint.Value = sizePriceModel.MedicalPrice.Value;
                if (sizePriceModel.MedicalRePrintPrice != null)
                    iiMedicalRePrint.Value = sizePriceModel.MedicalRePrintPrice.Value;
            }
            else
            {
                panelMedicalPhoto.Enabled = false;

                chkHasMedialPhoto.Checked = false;
                chkHasMedialPhoto.Enabled = false;
            }

            if (sizeModel.HasLitPrint)
            {
                panelLitPrint.Enabled = true;
                chkHasLitPrint.Enabled = true;
                chkHasLitPrint.Checked = true;

                if (sizePriceModel.LitPrintPrice != null)
                    iiLitPrintFirstPrint.Value = sizePriceModel.LitPrintPrice.Value;
                if (sizePriceModel.LitPrintReprintPrice != null)
                    iiLitPrintRePrint.Value = sizePriceModel.LitPrintReprintPrice.Value;
            }
            else
            {
                panelLitPrint.Enabled = false;
                chkHasLitPrint.Checked = false;
                chkHasLitPrint.Enabled = false;
            }

            if (sizeModel.HasScanAndProcessing)
            {
                panelScanAndProcessing.Enabled = true;
                chkHasScanAndProcess.Enabled = true;
                chkHasScanAndProcess.Checked = true;

                if (sizePriceModel.ScanAndPrintPrice != null)
                    iiScanAndPrint.Value = sizePriceModel.ScanAndPrintPrice.Value;
                if (sizePriceModel.ScanAndProcessingPrice != null)
                    iiScanAndProcess.Value = sizePriceModel.ScanAndProcessingPrice.Value;
            }
            else
            {
                panelScanAndProcessing.Enabled = false;
                chkHasScanAndProcess.Checked = false;
                chkHasScanAndProcess.Enabled = false;
            }

            if (sizeModel.HasItalianAlbum)
            {
                panelHasItalianAlbum.Enabled = true;
                chkHasItalianAlbum.Enabled = true;
                chkHasItalianAlbum.Checked = true;
            }
            else
            {
                panelHasItalianAlbum.Enabled = false;
                chkHasItalianAlbum.Checked = false;
                chkHasItalianAlbum.Enabled = false;
            }



            if (sizeModel.IsActive)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            if (sizeModel.IsDeleted)
            {
                chkIsDeleted.Checked = true;
            }
            else
            {
                chkIsDeleted.Checked = false;
            }
        }

        private static void ShowErrorProvider(ErrorProvider errorProvider, Control control, int padding, string message)
        {
            errorProvider.Clear();
            errorProvider.SetIconPadding(control, padding);
            errorProvider.SetError(control, message);
        }

        private void ResetInputs()
        {
            chkHasItalianAlbum.Checked = false;
            chkHasLitPrint.Checked = false;
            chkHasMedialPhoto.Checked = false;
            chkHasScanAndProcess.Checked = false;
            chkIsActive.Checked = false;
            chkIsDeleted.Checked = false;

            iiMinimumOrder.Value = 0;

            iiRePrintPrice.ResetText();
            iiFirstPrintPrice.ResetText();
            iiItalianAlbumBoundingPrice.ResetText();
            iiItalianAlbumPagePrice.ResetText();
            iiLitPrintFirstPrint.ResetText();
            iiLitPrintRePrint.ResetText();
            iiMedicalFirstPrint.ResetText();
            iiMedicalRePrint.ResetText();
            iiScanAndPrint.ResetText();
            iiScanAndProcess.ResetText();

            errorProvider1.Clear();
        }

        #endregion

        private void تعریف_اندازه_چاپ_جدید_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmAddEditPrintSize = new FrmAddEditPrintSize())
            {
                frmAddEditPrintSize.IsNewPrintSize = true;
                if (frmAddEditPrintSize.ShowDialog() == DialogResult.OK)
                {
                    GetAllPhotoSizes();
                }
            }
        }

        private void ویرایش_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out int printSizeId)) return;
            using (var frmAddEditPrintSize = new FrmAddEditPrintSize())
            {
                frmAddEditPrintSize.IsNewPrintSize = false;
                frmAddEditPrintSize.PrintSizeId = printSizeId;
                var dr = frmAddEditPrintSize.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    FrmAddEditPrintSizeAndServices_Refactored_Load(null, null);
                }
            }
        }

        private void حذف_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تعریف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbPrintSizes.DataSource == null || cmbPrintSizes.SelectedIndex == -1 || cmbPrintSizes.Items.Count <= 0)
                return;
            if (!int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var selectedPrintSizeId))
                return;

            using (var frmPrintServices = new FrmAddEditPrintSizeServices())
            {
                frmPrintServices.PrintSizeId = selectedPrintSizeId;
                if (frmPrintServices.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}