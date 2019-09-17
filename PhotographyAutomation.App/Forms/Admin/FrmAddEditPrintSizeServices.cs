using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Admin
{
    public partial class FrmAddEditPrintSizeServices : Form
    {
        #region Variables

        public int PrintSizeId;
        public int PrintServiceId;
        public int PrintServicePriceId;
        public bool EditPrintSizeServiceMode = false;

        private List<PrintSizesViewModel> _printSizesViewModels;

        private readonly BackgroundWorker _bgWorkerGetAllPhotoSizes = new BackgroundWorker
        {
            WorkerReportsProgress = false,
            WorkerSupportsCancellation = false
        };
        private readonly BackgroundWorker _bgWorkerGetPrintSizeServices = new BackgroundWorker
        {
            WorkerReportsProgress = false,
            WorkerSupportsCancellation = false
        };
        private readonly BackgroundWorker _bgWorkerGetAllPrintServices = new BackgroundWorker
        {
            WorkerSupportsCancellation = false,
            WorkerReportsProgress = false
        };

        #endregion


        #region Form Events

        public FrmAddEditPrintSizeServices()
        {
            InitializeComponent();

            _bgWorkerGetAllPhotoSizes.DoWork += BgWorkerGetAllPhotoSizes_DoWork;
            _bgWorkerGetAllPhotoSizes.RunWorkerCompleted += BgWorkerGetAllPhotoSizes_RunWorkerCompleted;

            _bgWorkerGetPrintSizeServices.DoWork += _bgWorkerGetPrintSizeServices_DoWork;
            _bgWorkerGetPrintSizeServices.RunWorkerCompleted += _bgWorkerGetPrintSizeServices_RunWorkerCompleted;

            _bgWorkerGetAllPrintServices.DoWork += _bgWorkerGetAllPrintServices_DoWork;
            _bgWorkerGetAllPrintServices.RunWorkerCompleted += _bgWorkerGetAllPrintServices_RunWorkerCompleted;
        }
        private void FrmAddEditPrintSizeServices_Load(object sender, EventArgs e)
        {
            GetAllPhotoSizes();
            GetAllPrintServices();
        }

        #endregion


        #region GetAllPhotoSizes

        private void GetAllPhotoSizes()
        {
            try
            {
                _bgWorkerGetAllPhotoSizes.RunWorkerAsync();
                EnableOrDisableControlsToGetAllPrintSizes();
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }

        }
        private void BgWorkerGetAllPhotoSizes_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizeRepository.GetAllPrintSizes();

                    if (result == null || result.Count == 0) return;
                    e.Result = result;
                    _printSizesViewModels = result;
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
        }
        private void BgWorkerGetAllPhotoSizes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null && e.Result is List<PrintSizesViewModel> viewModel)
                {
                    cmbPrintSizes.DataSource = viewModel;
                    cmbPrintSizes.DisplayMember = "Name";
                    cmbPrintSizes.ValueMember = "Id";

                    if (PrintSizeId > 0)
                    {
                        cmbPrintSizes.SelectedValue = PrintSizeId;
                    }
                }
                else if (e.Result == null)
                {
                    MessageBox.Show(@"برای این اندازه چاپ، سرویس چاپی ثبت نشده است.", "",
                        MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);
                    return;
                }
                else
                {
                    MessageBox.Show(
                        @"اطلاعات فرم قابل دریافت نمی باشد.",
                        @"خطا در دریافت اطلاعات از سرور",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    Close();
                }


                EnableOrDisableControlsToGetAllPrintSizes();
            }
            catch (InvalidOperationException exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
        }

        #endregion


        #region GetAllPrintServices

        private void GetAllPrintServices()
        {
            try
            {
                _bgWorkerGetAllPrintServices.RunWorkerAsync();
                EnableOrDisableControlsToGetAllPrintSizes();
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }
        private static void _bgWorkerGetAllPrintServices_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintServicesGenericRepository.Get();
                    if (result == null || !result.Any()) return;
                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
        }
        private void _bgWorkerGetAllPrintServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result == null) return;

                cmbPrintServices.DataSource = e.Result;
                cmbPrintServices.DisplayMember = "PrintServiceName";
                cmbPrintServices.ValueMember = "Id";

                EnableOrDisableControlsToGetAllPrintSizes();


                if (EditPrintSizeServiceMode && PrintSizeId > 0 && PrintServiceId > 0 && PrintServicePriceId > 0)
                {
                    using (var db = new UnitOfWork())
                    {
                        var printServicePrice = db.PrintServicePricesGenericRepository.GetById(PrintServicePriceId);
                        if (printServicePrice != null)
                        {
                            txtPrintServiceCode.Text = printServicePrice.TblPrintServices.Code;
                            iiPrintServicePrice.Value = printServicePrice.Price;

                            cmbPrintSizes.SelectedValue = PrintSizeId;
                            cmbPrintServices.SelectedValue = PrintServiceId;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
        }

        #endregion

        #region GetPrintSizeServicesByPrintSizeId

        private void GetPrintSizeServicesByPrintSizeId(int printSizeId)
        {
            try
            {
                errorProvider1.Clear();
                //dgvPrintServices.Rows.Clear();
                _bgWorkerGetPrintSizeServices.RunWorkerAsync(printSizeId);
                cpLoadDataGridView.IsRunning = _bgWorkerGetPrintSizeServices.IsBusy;
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }

        }
        private void _bgWorkerGetPrintSizeServices_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null && int.TryParse(e.Argument.ToString(), out var printSizeId))
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintSizeRepository.GetAllPrintSizeServicesByPrintSizeId(printSizeId);

                        if (result == null || result.Count == 0) return;
                        e.Result = result;
                        //_printServicesViewModels = result;
                    }
                }
                catch (Exception exception)
                {
                    WriteDebugInfo(exception);
                    throw;
                }
            }
        }
        private void _bgWorkerGetPrintSizeServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null && e.Result is IReadOnlyList<PrintServicesViewModel> viewModel)
                {
                    cpLoadDataGridView.IsRunning = _bgWorkerGetPrintSizeServices.IsBusy;
                    cpLoadDataGridView.Visible = _bgWorkerGetPrintSizeServices.IsBusy;

                    PopulateDataFridView(viewModel);
                }
                else if (e.Result == null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetIconPadding(cmbPrintSizes, 3);
                    errorProvider1.SetError(cmbPrintSizes, @"برای این اندازه چاپ، خدمات چاپ ثبت نشده است.");

                    cpLoadDataGridView.IsRunning = _bgWorkerGetPrintSizeServices.IsBusy;
                    cpLoadDataGridView.Visible = _bgWorkerGetPrintSizeServices.IsBusy;

                    return;
                }
                else
                {
                    MessageBox.Show(
                        @"اطلاعات فرم قابل دریافت نمی باشد.",
                        @"خطا در دریافت اطلاعات از سرور",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    Close();
                }

                EnableOrDisableControlsToGetAllPrintSizes();
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
        }

        #endregion


        private void btnSaveEditedprintServiceValues_Click(object sender, EventArgs e)
        {
            if (cmbPrintSizes.Items.Count == 0)
                return;
            if (cmbPrintServices.Items.Count == 0)
                return;

            if (int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var selectedPrintSizeId) &&
                int.TryParse(cmbPrintServices.SelectedValue.ToString(), out var selectedPrintServiceId))
            {
                if (string.IsNullOrEmpty(txtPrintServiceCode.Text.Trim()))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetIconPadding(txtPrintServiceCode, 4);
                    errorProvider1.SetError(txtPrintServiceCode, "کد خدمت وارد نشده است.");
                    txtPrintServiceCode.Focus();
                    return;
                }

                if (iiPrintServicePrice.Value.ToString() == "" ||
                    string.IsNullOrEmpty(iiPrintServicePrice.Value.ToString().Trim()))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetIconPadding(iiPrintServicePrice, 4);
                    errorProvider1.SetError(iiPrintServicePrice, "هزینه خدمت وارد نشده است.");
                    iiPrintServicePrice.Focus();
                    return;
                }

                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var resultCheckPrintSizeHasThisPrintServiceBefore = db.PrintServicePricesGenericRepository
                            .Get(x => x.PrintServiceId == selectedPrintServiceId && x.PrintSizeId == selectedPrintSizeId)
                            .FirstOrDefault();
                        if (resultCheckPrintSizeHasThisPrintServiceBefore != null)
                        {
                            var dr = MessageBox.Show(
                                @"قبلا برای این اندازه چاپ این خدمت ثبت شده است. آیا می خواهید آن را ویرایش کنید؟",
                                @"", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                            if (dr == DialogResult.Yes)
                            {
                                TblPrintServicePrices printServicePrices = resultCheckPrintSizeHasThisPrintServiceBefore;
                                printServicePrices.Code = txtPrintServiceCode.Text;
                                printServicePrices.Price = iiPrintServicePrice.Value;

                                db.PrintServicePricesGenericRepository.Update(printServicePrices);
                                var resultUpdate = db.Save();
                                if (resultUpdate > 0)
                                {
                                    MessageBox.Show(
                                        @"خدمت مورد نظر برای اندازه چاپ مربوطه با موفقیت ویرایش گردید.",
                                        @"ویرایش اطلاعات در سیستم", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.RtlReading);

                                    GetPrintSizeServicesByPrintSizeId(selectedPrintSizeId);
                                }
                            }
                        }
                        else
                        {
                        RetrySaveToDb:
                            var printServicePrice = new TblPrintServicePrices
                            {
                                PrintServiceId = selectedPrintServiceId,
                                PrintSizeId = selectedPrintSizeId,
                                Code = txtPrintServiceCode.Text,
                                Price = iiPrintServicePrice.Value
                            };
                            db.PrintServicePricesGenericRepository.Insert(printServicePrice);
                            var result = db.Save();
                            if (result > 0)
                            {
                                MessageBox.Show(
                                    @"خدمت مورد نظر برای اندازه چاپ مربوطه با موفقیت ثبت گردید.",
                                    @"ثبت اطلاعات در سیستم", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);

                                GetPrintSizeServicesByPrintSizeId(selectedPrintSizeId);
                            }
                            else
                            {
                                var dr = MessageBox.Show(
                                    @"ثبت اطلاعات ناموفق بود. آیا می خواهید دوباره تلاش کنید؟",
                                    @"عدم ثبت اطلاعات در سیستم",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                                if (dr == DialogResult.Yes)
                                {
                                    goto RetrySaveToDb;
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    WriteDebugInfo(exception);
                }
            }
        }
        private void cmbPrintSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var printSizeId) == false)
                return;
            PrintSizeId = printSizeId;
            var printSizesViewModel = _printSizesViewModels.FirstOrDefault(x => x.Id == printSizeId);
            if (printSizesViewModel == null)
                return;

            try
            {
                GetPrintSizeServicesByPrintSizeId(printSizeId);
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }


        #region Methods

        private void EnableOrDisableControlsToGetAllPrintSizes()
        {
            cmbPrintSizes.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy == !_bgWorkerGetAllPrintServices.IsBusy;
            //groupBoxPrintSize.Enabled = (!_bgWorkerGetAllPhotoSizes.IsBusy ^ !_bgWorkerGetAllPrintServices.IsBusy);

            panelDataGridView.Enabled = (!_bgWorkerGetAllPhotoSizes.IsBusy == !_bgWorkerGetAllPrintServices.IsBusy);

            menuStrip1.Enabled = (!_bgWorkerGetAllPhotoSizes.IsBusy == !_bgWorkerGetAllPrintServices.IsBusy);
        }

        private void PopulateDataFridView(IReadOnlyList<PrintServicesViewModel> viewModel)
        {
            dgvPrintServices.Rows.Clear();
            dgvPrintServices.RowCount = viewModel.Count;
            dgvPrintServices.AutoGenerateColumns = false;

            for (int i = 0; i < viewModel.Count; i++)
            {
                dgvPrintServices.Rows[i].Cells["clmPrintServicePriceId"].Value = viewModel[i].Id;
                dgvPrintServices.Rows[i].Cells["clmPrintServiceId"].Value = viewModel[i].PrintServiceId;
                dgvPrintServices.Rows[i].Cells["clmPrintSizeId"].Value = viewModel[i].PrintSizeId;

                dgvPrintServices.Rows[i].Cells["clmPrintSizeName"].Value = viewModel[i].SizeWidth + "x" + viewModel[i].SizeHeight;
                dgvPrintServices.Rows[i].Cells["clmPrintSizeName"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvPrintServices.Rows[i].Cells["clmPrintSizeDescription"].Value = viewModel[i].SizeDescription;
                dgvPrintServices.Rows[i].Cells["clmPrintServiceName"].Value = viewModel[i].PrintServiceName;

                dgvPrintServices.Rows[i].Cells["clmPrintServiceCode"].Value = viewModel[i].PrintServiceCode;
                dgvPrintServices.Rows[i].Cells["clmPrintServiceCode"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvPrintServices.Rows[i].Cells["clmPrintServicePrice"].Value = viewModel[i].PrintServicePrice.ToString("N0");
                dgvPrintServices.Rows[i].Cells["clmPrintServicePrice"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Rows[i].Cells["clmPrintServiceDescription"].Value = viewModel[i].PrintServiceDescription;
            }

            dgvPrintServices.Rows[0].Selected = false;
            
            if (EditPrintSizeServiceMode && PrintSizeId > 0 && PrintServiceId > 0 && PrintServicePriceId > 0)
            {
                //foreach (DataGridViewRow row in dgvPrintServices.Rows)
                //{
                //    if (row.Cells["clmPrintServicePriceId"].Value.ToString() == PrintServicePriceId.ToString())
                //    {
                //        rowIndex = row.Index;
                //    }
                //}

                var row = dgvPrintServices.Rows
                                        .Cast<DataGridViewRow>()
                                        .First(r => int.Parse(r.Cells["clmPrintServicePriceId"].Value.ToString()).Equals(PrintServicePriceId));
                if (row != null)
                {
                    var rowIndex = row.Index;
                    dgvPrintServices.Rows[rowIndex].Selected = true;
                }
            }
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

        #endregion


        #region Top Menu

        private void تعریف_خدمات_چاپ_جدید_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAddEditPrintServiceName())
            {
                frm.IsNewPrintService = true;
                var dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    GetAllPrintServices();
                }
            }

        }

        private void ویرایش_خدمات_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(cmbPrintServices.SelectedValue.ToString(), out var selectedPrintServiceId))
            {
                using (var frm = new FrmAddEditPrintServiceName())
                {
                    frm.IsNewPrintService = false;
                    frm.PrintServiceId = selectedPrintServiceId;

                    var dr = frm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        GetAllPrintServices();
                        GetPrintSizeServicesByPrintSizeId((int)cmbPrintSizes.SelectedValue);
                    }
                }
            }

        }

        private void حذف_خدمات_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbPrintServices.SelectedValue.ToString(), out var selectedPrintServiceId) || !int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var selectedPrintSizeId))
                return;
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintServicePricesGenericRepository
                        .Get(x => x.PrintServiceId == selectedPrintServiceId).ToList();
                    if (result.Any())
                    {
                        MessageBox.Show(
                            @"این خدمت چاپ قبلا برای اندازه چاپ هایی تخصیص داده شده است و قابل حذف نمی باشد.",
                            @"", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                        return;
                    }

                    var dr = MessageBox.Show(
                        @"آیا از حذف این خدمت چاپ اطمینان دارید؟",
                        @"تائید حذف خدمت چاپ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    if (dr == DialogResult.Yes)
                    {
                        var printServiceInDb = db.PrintServicesGenericRepository.GetById(selectedPrintServiceId);
                        if (printServiceInDb != null)
                        {
                            db.PrintServicesGenericRepository.Delete(printServiceInDb);
                            var deleteResult = db.Save();
                            if (deleteResult > 0)
                            {
                                MessageBox.Show(
                                    @"خدمت چاپ مورد نظر با موفقت از سیستم حذف گردید.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);

                                GetAllPrintServices();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
            }
        }



        private void تعریف_خدمت_چاپ_جدید_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var selectedPrintSizeId))
            {
                cmbPrintServices.DroppedDown = true;
                cmbPrintServices.Focus();
            }
        }

        private void ویرایش_خدمت_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPrintServices.SelectedRows.Count == 1)
            {
                if (!int.TryParse(dgvPrintServices.SelectedRows[0].Cells["clmPrintServicePriceId"].Value.ToString(),
                        out var selectedPrintServicePriceId) || !int.TryParse(
                        dgvPrintServices.SelectedRows[0].Cells["clmPrintSizeId"].Value.ToString(),
                        out var selectedPrintSizeId) || !int.TryParse(
                        dgvPrintServices.SelectedRows[0].Cells["clmPrintServiceId"].Value.ToString(),
                        out var selectedPrintServiceId))
                    return;


                cmbPrintSizes.SelectedValue = selectedPrintSizeId;
                cmbPrintServices.SelectedValue = selectedPrintServiceId;
                txtPrintServiceCode.Text = dgvPrintServices.Rows[0].Cells["clmPrintServiceCode"].Value.ToString();
                string strPrice = dgvPrintServices.Rows[0].Cells["clmPrintServicePrice"].Value.ToString();
                strPrice = strPrice.Replace(",", "");
                int.TryParse(strPrice, out var price);
                iiPrintServicePrice.Value = price;
            }
            else
            {
                MessageBox.Show(
                    @"خدمت چاپی برای ویرایش انتخاب نشده است.",
                    @"", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void حذف_خدمت_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dgvPrintServices.SelectedRows[0].Cells["clmPrintServicePriceId"].Value.ToString(),
                    out var selectedPrintServicePriceId) || !int.TryParse(
                    dgvPrintServices.SelectedRows[0].Cells["clmPrintSizeId"].Value.ToString(),
                    out var selectedPrintSizeId))
                return;

            var dr = MessageBox.Show(
                @"آیا از حذف خدمت چاپ مورد نظر اطمینان دارید؟",
                @"تائید حذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RtlReading);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var result = db.PrintServicePricesGenericRepository.GetById(selectedPrintServicePriceId);
                        if (result != null)
                        {
                            db.PrintServicePricesGenericRepository.Delete(result);
                            var deleteResult = db.Save();

                            if (deleteResult > 0)
                            {
                                MessageBox.Show("خدمت چاپ مورد نظر با موفقیت از سیستم حذف گردید.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                                GetPrintSizeServicesByPrintSizeId(selectedPrintSizeId);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    WriteDebugInfo(exception);
                }
            }
        }


        #endregion
    }
}
