using PhotographyAutomation.DateLayer.Context;
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

        public int PrintSizeId = 0;

        private List<PrintSizesViewModel> _printSizesViewModels;
        private List<PrintServicesViewModel> _printServicesViewModels;

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

        #endregion

        public FrmAddEditPrintSizeServices()
        {
            InitializeComponent();

            _bgWorkerGetAllPhotoSizes.DoWork += BgWorkerGetAllPhotoSizes_DoWork;
            _bgWorkerGetAllPhotoSizes.RunWorkerCompleted += BgWorkerGetAllPhotoSizes_RunWorkerCompleted;

            _bgWorkerGetPrintSizeServices.DoWork += _bgWorkerGetPrintSizeServices_DoWork;
            _bgWorkerGetPrintSizeServices.RunWorkerCompleted += _bgWorkerGetPrintSizeServices_RunWorkerCompleted;
        }


        private void FrmAddEditPrintSizeServices_Load(object sender, EventArgs e)
        {
            GetAllPhotoSizes();
        }

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

                    //cmbPrintSizes_SelectedIndexChanged(null, null);
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
                _bgWorkerGetPrintSizeServices.RunWorkerAsync(printSizeId);
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
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
                        _printServicesViewModels = result;
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
                if (e.Result != null && e.Result is List<PrintServicesViewModel> viewModel)
                {
                    cmbPrintServices.DataSource = viewModel;
                    cmbPrintServices.DisplayMember = "PrintServiceName";
                    cmbPrintServices.ValueMember = "Id";

                    cmbPrintServices.SelectedIndex = 0;

                    iiPrintServicePrice.Value = viewModel.FirstOrDefault().PrintServicePrice;
                    txtServiceCode.Text = viewModel.FirstOrDefault()?.PrintServiceCode;
                    //cmbPrintSizes.SelectedIndex = PrintSizeId;

                    //cmbPrintServices_SelectedIndexChanged(null, null);
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
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }
        }



        private void cmbPrintServices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void EnableOrDisableControlsToGetAllPrintSizes()
        {
            cmbPrintSizes.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            groupBoxPrintSize.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
            groupBoxPrintServices.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;

            panelDataGridView.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;

            menuStrip1.Enabled = !_bgWorkerGetAllPhotoSizes.IsBusy;
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (iiPrintServicePrice.IsInputReadOnly)
            {
                iiPrintServicePrice.IsInputReadOnly = false;
                txtPrintServiceCode.ReadOnly = false;
            }
        }

        private void btnSaveEditedprintServiceValues_Click(object sender, EventArgs e)
        {
            if (iiPrintServicePrice.IsInputReadOnly == false)
            {
                iiPrintServicePrice.IsInputReadOnly = true;
                txtPrintServiceCode.ReadOnly = true;
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
    }
}
