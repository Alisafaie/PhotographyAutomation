using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
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
            GetAllPrintSizeAndServicesInfo();
        }

        private void GetAllPrintSizeAndServicesInfo()
        {
            try
            {
                _bgWorkerGetAllPrintSizeServices.RunWorkerAsync();
                cpLoadDataGridView.IsRunning = _bgWorkerGetAllPrintSizeServices.IsBusy;
            }
            catch (Exception)
            {
                //ignored
            }
        }

        private static void _bgWorkerGetAllPrintSizeServices_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintServiceRepository.GetAllPrintSizeAndServicesInfo();
                    e.Result = result;
                }
            }
            catch (Exception)
            {
                //ignored
            }
        }
        private void _bgWorkerGetAllPrintSizeServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null && e.Result is List<View_GetAllPrintSizeAndServicesInfo> viewInfo)
                {
                    PopulateDataGridView(viewInfo);

                    cpLoadDataGridView.IsRunning = _bgWorkerGetAllPrintSizeServices.IsBusy;
                    cpLoadDataGridView.Visible = false;
                    cpLoadDataGridView.Hide();
                }
                else
                {
                    MessageBox.Show(
                        @"اطلاعات اندازه چاپ و خدمات مربوطه در سیستم وجود ندارد.",
                        @"عدم وجود اطلاعات در سرور",
                        MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    @"خطا در دریافت اطلاعات از سرور", exception.HResult.ToString());
                MessageBox.Show(
                        @"Exception Message: " + exception.Message + Environment.NewLine +
                            @"Inner Exception: " + exception.InnerException + Environment.NewLine +
                            @"Exception Source: " + exception.Source + Environment.NewLine +
                            @"Exception Data: " + exception.Data, 
                        @"Exception",
                        MessageBoxButtons.OK,MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                throw;
            }
        }

        private void PopulateDataGridView(List<View_GetAllPrintSizeAndServicesInfo> viewInfo)
        {
            dgvPrintServices.Rows.Clear();
            dgvPrintServices.RowCount = viewInfo.Count;
            dgvPrintServices.AutoGenerateColumns = false;

            for (int i = 0; i < viewInfo.Count; i++)
            {
                dgvPrintServices.Rows[i].Cells["clmPrintSizeId"].Value = viewInfo[i].PrintSizeId;
                dgvPrintServices.Rows[i].Cells["clmPrintServiceId"].Value = viewInfo[i].PrintServiceId;
                dgvPrintServices.Rows[i].Cells["clmPrintSizePriceId"].Value = viewInfo[i].PrintSizePriceId;
                dgvPrintServices.Rows[i].Cells["clmPrintServicePriceId"].Value = viewInfo[i].PrintServicePriceId;

                dgvPrintServices.Rows[i].Cells["clmPrintSizeName"].Value = viewInfo[i].PrintSizeName;
                //dgvPrintServices.Rows[i].Cells["clmPrintSizeName"].Style.Alignment = DataGridViewContentAlignment.;


                dgvPrintServices.Rows[i].Cells["clmPrintServiceName"].Value = viewInfo[i].PrintServiceName;
                dgvPrintServices.Rows[i].Cells["clmPrintServicePrice"].Value = viewInfo[i].PrintServicePrice;

                dgvPrintServices.Rows[i].Cells["clmFirstPrintPrice"].Value = viewInfo[i].FirstPrintPrice;
                dgvPrintServices.Rows[i].Cells["clmRePrintPrice"].Value = viewInfo[i].RePrintPrice;

                dgvPrintServices.Rows[i].Cells["clmHasMedicalPhoto"].Value = viewInfo[i].HasMedicalPhoto;

                dgvPrintServices.Rows[i].Cells["clmMedicalPrice"].Value = viewInfo[i].MedicalPrice;
                dgvPrintServices.Rows[i].Cells["clmMedicalRePrintPrice"].Value = viewInfo[i].MedicalRePrintPrice;

                dgvPrintServices.Rows[i].Cells["clmHasLitPrint"].Value = viewInfo[i].HasLitPrint;

                dgvPrintServices.Rows[i].Cells["clmLitPrintPrice"].Value = viewInfo[i].LitPrintPrice;
                dgvPrintServices.Rows[i].Cells["clmLitPrintRePrintPrice"].Value = viewInfo[i].LitPrintRePrintPrice;

                dgvPrintServices.Rows[i].Cells["clmHasScanAndProcessing"].Value = viewInfo[i].HasScanAndProcessing;

                dgvPrintServices.Rows[i].Cells["clmScanAndPrintPrice"].Value = viewInfo[i].ScanAndPrintPrice;
                dgvPrintServices.Rows[i].Cells["clmScanAndProcessingPrice"].Value = viewInfo[i].ScanAndProcessingPrice;

                dgvPrintServices.Rows[i].Cells["clmHasItalianAlbum"].Value = viewInfo[i].HasItalianAlbum;

                dgvPrintServices.Rows[i].Cells["clmItalianAlbumPagePrice"].Value = viewInfo[i].ItalianAlbumPagePrice;
                dgvPrintServices.Rows[i].Cells["clmItalianAlbumBoundingPrice"].Value = viewInfo[i].ItalianAlbumBoundingPrice;
            }
        }

        #endregion


        #region CheckBoxes Events
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


        #region ComboBox Selected Index Chenged

        private void cmbPrintSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetInputs();

            if (!int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var printSizeId)) return;

            var sizeModel = _printSizesViewModels.Find(x => x.Id == printSizeId);
            if (sizeModel == null)
            {
                ShowErrorProvider(errorProvider1, cmbPrintSizes, "اطلاعات اندازه چاپ قابل دریافت نمی باشد.");
                return;
            }

            var sizePriceModel = _printSizePricesViewModels.Find(x => x.PrintSizeId == printSizeId);
            if (sizePriceModel == null)
            {
                ShowErrorProvider(errorProvider1, cmbPrintSizes, "اطلاعات قیمت برای این اندازه چاپ ثبت نشده است.");
                return;
            }

            iiMinimumOrder.Value = sizeModel.MinimumOrder;

            if (sizePriceModel.FirstPrintPrice != null) iiFirstPrintPrice.Value = sizePriceModel.FirstPrintPrice.Value;
            if (sizePriceModel.RePrintPrice != null) iiRePrintPrice.Value = sizePriceModel.RePrintPrice.Value;


            if (sizeModel.HasMedicalPhoto)
            {
                panelMedicalPhoto.Enabled = true;
                //chkHasMedialPhoto.Enabled = true;
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
                //chkHasMedialPhoto.Enabled = false;
            }

            if (sizeModel.HasLitPrint)
            {
                panelLitPrint.Enabled = true;
                //chkHasLitPrint.Enabled = true;
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
                //chkHasLitPrint.Enabled = false;
            }

            if (sizeModel.HasScanAndProcessing)
            {
                panelScanAndProcessing.Enabled = true;
                //chkHasScanAndProcess.Enabled = true;
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
                //chkHasScanAndProcess.Enabled = false;
            }

            if (sizeModel.HasItalianAlbum)
            {
                panelHasItalianAlbum.Enabled = true;
                //chkHasItalianAlbum.Enabled = true;
                chkHasItalianAlbum.Checked = true;
            }
            else
            {
                panelHasItalianAlbum.Enabled = false;
                chkHasItalianAlbum.Checked = false;
                //chkHasItalianAlbum.Enabled = false;
            }

            chkIsActive.Checked = sizeModel.IsActive;

            chkIsDeleted.Checked = sizeModel.IsDeleted;
        }

        #endregion


        #region Top Menu

        private void تعریف_اندازه_چاپ_جدید_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                // ignored
            }
        }

        private void ویرایش_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out int printSizeId)) return;
            try
            {
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
            catch (Exception)
            {
                // ignored
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

            try
            {
                using (var frmPrintServices = new FrmAddEditPrintSizeServices())
                {
                    frmPrintServices.PrintSizeId = selectedPrintSizeId;
                    if (frmPrintServices.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        #endregion


        #region GetAllPhotoSizes And Background Workers

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
                    ShowErrorProvider(errorProvider1, cmbPrintSizes, "اطلاعات اندازه چاپ ها قابل دریافت نمی باشد.");
                }


                EnableOrDisableControlsToGetAllPrintSizes();
            }
            catch (ArgumentNullException exception)
            {
                ShowErrorProvider(errorProvider1, cmbPrintSizes, "خطا در دریافت اطلاعات. لطفا فرم را بسته و مجددا باز نمایید.");

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

        #region GetAllPhotoSizePrices And Background Workers

        private void GetAllPhotoSizePrices()
        {

            try
            {
                _bgWorkerGetAllPhotoSizePrices.RunWorkerAsync();
            }
            catch (Exception)
            {
                // ignored
            }
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
                    /* b u g in ComboBox */
                    cmbPrintSizes.SelectedIndex = 1;
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

        #region Methods

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

        private static void ShowErrorProvider(ErrorProvider errorProvider, Control control, string message)
        {
            errorProvider.Clear();
            errorProvider.SetIconPadding(control, 4);
            errorProvider.SetError(control, message);
        }

        #endregion
    }
}