using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.PrintSizeAndServices
{
    public partial class FrmManagePrintSizeAndServices : Form
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

        private int _selectedRowIndex = -1;

        #endregion Variables


        #region Form Events

        public FrmManagePrintSizeAndServices()
        {
            InitializeComponent();

            _bgWorkerGetAllPhotoSizePrices.DoWork += _bgWorkerGetAllPhotoSizePrices_DoWork;
            _bgWorkerGetAllPhotoSizePrices.RunWorkerCompleted += _bgWorkerGetAllPhotoSizePrices_RunWorkerCompleted;

            _bgWorkerGetAllPhotoSizes.DoWork += BgWorkerGetAllPhotoSizes_DoWork;
            _bgWorkerGetAllPhotoSizes.RunWorkerCompleted += BgWorkerGetAllPhotoSizes_RunWorkerCompleted;

            _bgWorkerGetAllPrintSizeServices.DoWork += _bgWorkerGetAllPrintSizeServices_DoWork;
            _bgWorkerGetAllPrintSizeServices.RunWorkerCompleted += _bgWorkerGetAllPrintSizeServices_RunWorkerCompleted;
        }

        private void FrmManagePrintSizeAndServices_Load(object sender, EventArgs e)
        {
            try
            {
                GetAllPhotoSizes();
                GetAllPhotoSizePrices();
                GetAllPrintSizeAndServicesInfo();
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
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

        //تنظیمات
        private void تعریف_اندازه_چاپ_جدید_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frmAddEditPrintSize = new FrmAddEditPrintSize())
                {
                    frmAddEditPrintSize.IsNewPrintSize = true;
                    if (frmAddEditPrintSize.ShowDialog() == DialogResult.OK)
                    {
                        FrmManagePrintSizeAndServices_Load(null, null);
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }
        private void تعریف_خدمات_چاپ_جدید_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addEditPrintServiceName = new FrmAddEditPrintServiceName())
                {
                    addEditPrintServiceName.IsNewPrintService = true;
                    if (addEditPrintServiceName.ShowDialog() == DialogResult.OK)
                    {
                        FrmManagePrintSizeAndServices_Load(null, null);
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
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
                        FrmManagePrintSizeAndServices_Load(null, null);
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }
        private void ویرایش_خدمات_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addEditPrintServiceName = new FrmAddEditPrintServiceName())
                {
                    addEditPrintServiceName.IsNewPrintService = false;
                    addEditPrintServiceName.PrintServiceId = 14;

                    if (addEditPrintServiceName.ShowDialog() == DialogResult.OK)
                    {
                        FrmManagePrintSizeAndServices_Load(null, null);
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }


        private void حذف_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //خدمات چاپ
        private void تعریف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbPrintSizes.DataSource == null ||
                cmbPrintSizes.SelectedIndex == -1 ||
                cmbPrintSizes.Items.Count <= 0)
                return;

            if (!int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var selectedPrintSizeId))
                return;

            try
            {
                using (var frmAddEditPrintSizeServices = new FrmManagePrintSizeServices())
                {
                    frmAddEditPrintSizeServices.PrintSizeId = selectedPrintSizeId;
                    frmAddEditPrintSizeServices.ShowDialog();
                    //FrmManagePrintSizeAndServices_Load(null, null);
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }
        private void ویرایش_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPrintServices.SelectedRows.Count == 1)
            {
                if (int.TryParse(dgvPrintServices.SelectedRows[0].Cells["clmPrintSizeId"].Value.ToString(),
                        out var selectedPrintSizeId) &&
                    int.TryParse(dgvPrintServices.SelectedRows[0].Cells["clmPrintServiceId"].Value.ToString(),
                        out var selectedPrintServiceId) &&
                    int.TryParse(dgvPrintServices.SelectedRows[0].Cells["clmPrintServicePriceId"].Value.ToString(),
                        out var selectePrintServicePriceId))
                {
                    using (var frm = new FrmManagePrintSizeServices())
                    {
                        frm.EditPrintSizeServiceMode = true;
                        frm.PrintServiceId = selectedPrintServiceId;
                        frm.PrintSizeId = selectedPrintSizeId;
                        frm.PrintServicePriceId = selectePrintServicePriceId;

                        _selectedRowIndex = dgvPrintServices.SelectedRows[0].Index;

                        frm.ShowDialog();
                        GetAllPrintSizeAndServicesInfo();
                    }
                }
            }
        }
        private void حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrintServices.SelectedRows.Count == 1)
                {
                    if (int.TryParse(dgvPrintServices.SelectedRows[0].Cells["clmPrintServicePriceId"].Value.ToString(),
                        out var selectedPrintServicePriceId))
                    {
                        var dr = MessageBox.Show(
                            @"آیا از حذف این خدمت چاپ اطمینان دارید؟",
                            @"تائید حذف",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);

                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                using (var db = new UnitOfWork())
                                {
                                    db.PrintServicePricesGenericRepository.Delete(selectedPrintServicePriceId);
                                    var result = db.Save();
                                    if (result > 0)
                                    {
                                        MessageBox.Show(
                                            @"خدمت چاپ مورد نظر با موفقت از سیستم حذف گردید.",
                                            "",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                                            MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                                        GetAllPrintSizeAndServicesInfo();

                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                WriteDebugInfo(exception);
                                throw;
                            }
                        }
                    }

                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2147467261 &&
                    exception.Message == "Object reference not set to an instance of an object.")
                {
                    MessageBox.Show("برای اندازه چاپ مورد نظر، خدمات چاپ تعریف نشده است.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                }
            }

        }

        #endregion

        #region GetAllPrintSizeAndServicesInfo

        private void GetAllPrintSizeAndServicesInfo()
        {
            try
            {
                if (_bgWorkerGetAllPrintSizeServices.IsBusy == false)
                {
                    _bgWorkerGetAllPrintSizeServices.RunWorkerAsync();
                    cpLoadDataGridView.Visible = _bgWorkerGetAllPrintSizeServices.IsBusy;
                    cpLoadDataGridView.IsRunning = _bgWorkerGetAllPrintSizeServices.IsBusy;
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
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
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }
        private void _bgWorkerGetAllPrintSizeServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null && e.Result is IReadOnlyList<View_GetAllPrintSizeAndServicesInfo> viewInfo)
                {
                    PopulateDataGridView(viewInfo);

                    cpLoadDataGridView.IsRunning = _bgWorkerGetAllPrintSizeServices.IsBusy;
                    cpLoadDataGridView.Visible = _bgWorkerGetAllPrintSizeServices.IsBusy;
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
                        MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);

                WriteDebugInfo(exception);
                throw;
            }
        }
        private void PopulateDataGridView(IReadOnlyList<View_GetAllPrintSizeAndServicesInfo> viewInfo)
        {
            dgvPrintServices.Rows.Clear();
            dgvPrintServices.RowCount = viewInfo.Count;
            dgvPrintServices.AutoGenerateColumns = false;

            for (var i = 0; i < viewInfo.Count; i++)
            {
                dgvPrintServices.Rows[i].Cells["clmPrintSizeId"].Value = viewInfo[i].PrintSizeId;
                dgvPrintServices.Rows[i].Cells["clmPrintServiceId"].Value = viewInfo[i].PrintServiceId;
                dgvPrintServices.Rows[i].Cells["clmPrintSizePriceId"].Value = viewInfo[i].PrintSizePriceId;
                dgvPrintServices.Rows[i].Cells["clmPrintServicePriceId"].Value = viewInfo[i].PrintServicePriceId;

                dgvPrintServices.Rows[i].Cells["clmPrintSizeName"].Value = viewInfo[i].Width + "x" + viewInfo[i].Height;
                dgvPrintServices.Rows[i].Cells["clmPrintSizeName"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmMinimumOrder"].Value = viewInfo[i].MinimumOrder;
                dgvPrintServices.Rows[i].Cells["clmMinimumOrder"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvPrintServices.Rows[i].Cells["clmPrintServiceName"].Value = viewInfo[i].PrintServiceName;

                dgvPrintServices.Rows[i].Cells["clmPrintServicePrice"].Value = viewInfo[i].PrintServicePrice;
                dgvPrintServices.Rows[i].Cells["clmPrintServicePrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmFirstPrintPrice"].Value = viewInfo[i].FirstPrintPrice;
                dgvPrintServices.Rows[i].Cells["clmFirstPrintPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmRePrintPrice"].Value = viewInfo[i].RePrintPrice;
                dgvPrintServices.Rows[i].Cells["clmRePrintPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmHasMedicalPhoto"].Value = viewInfo[i].HasMedicalPhoto;

                dgvPrintServices.Rows[i].Cells["clmMedicalPrice"].Value = viewInfo[i].MedicalPrice;
                dgvPrintServices.Rows[i].Cells["clmMedicalPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmMedicalRePrintPrice"].Value = viewInfo[i].MedicalRePrintPrice;
                dgvPrintServices.Rows[i].Cells["clmMedicalRePrintPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmHasLitPrint"].Value = viewInfo[i].HasLitPrint;

                dgvPrintServices.Rows[i].Cells["clmLitPrintPrice"].Value = viewInfo[i].LitPrintPrice;
                dgvPrintServices.Rows[i].Cells["clmLitPrintPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmLitPrintRePrintPrice"].Value = viewInfo[i].LitPrintRePrintPrice;
                dgvPrintServices.Rows[i].Cells["clmLitPrintRePrintPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvPrintServices.Rows[i].Cells["clmHasScanAndProcessing"].Value = viewInfo[i].HasScanAndProcessing;

                dgvPrintServices.Rows[i].Cells["clmScanAndPrintPrice"].Value = viewInfo[i].ScanAndPrintPrice;
                dgvPrintServices.Rows[i].Cells["clmScanAndPrintPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmScanAndProcessingPrice"].Value = viewInfo[i].ScanAndProcessingPrice;
                dgvPrintServices.Rows[i].Cells["clmScanAndProcessingPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvPrintServices.Rows[i].Cells["clmHasItalianAlbum"].Value = viewInfo[i].HasItalianAlbum;

                dgvPrintServices.Rows[i].Cells["clmItalianAlbumPagePrice"].Value = viewInfo[i].ItalianAlbumPagePrice;
                dgvPrintServices.Rows[i].Cells["clmItalianAlbumPagePrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmItalianAlbumBoundingPrice"].Value = viewInfo[i].ItalianAlbumBoundingPrice;
                dgvPrintServices.Rows[i].Cells["clmItalianAlbumBoundingPrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvPrintServices.Rows[i].Cells["clmIsActive"].Value = viewInfo[i].IsActive;
                dgvPrintServices.Rows[i].Cells["clmIsDeleted"].Value = viewInfo[i].IsDeleted;
            }

            dgvPrintServices.Rows[0].Selected = false;

            if (_selectedRowIndex > 0)
            {
                dgvPrintServices.Rows[_selectedRowIndex].Selected = true;

                dgvPrintServices.FirstDisplayedScrollingRowIndex = dgvPrintServices.Rows[_selectedRowIndex].Index;

                //dgvPrintServices.CurrentCell = dgvPrintServices.Rows[_selectedRowIndex].Cells["clmPrintSizeName"];
            }
        }

        #endregion

        #region GetAllPhotoSizes And Background Workers

        private void GetAllPhotoSizes()
        {
            try
            {
                if (_bgWorkerGetAllPhotoSizes.IsBusy == false)
                {
                    _bgWorkerGetAllPhotoSizes.RunWorkerAsync();
                    EnableOrDisableControlsToGetAllPrintSizes();
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
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
                WriteDebugInfo(exception);
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

                WriteDebugInfo(exception);
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
        }

        #endregion

        #region GetAllPhotoSizePrices And Background Workers

        private void GetAllPhotoSizePrices()
        {

            try
            {
                if (_bgWorkerGetAllPhotoSizePrices.IsBusy == false)
                    _bgWorkerGetAllPhotoSizePrices.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
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
                WriteDebugInfo(exception);
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
                WriteDebugInfo(exception);
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

        private static void WriteDebugInfo(Exception exception)
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