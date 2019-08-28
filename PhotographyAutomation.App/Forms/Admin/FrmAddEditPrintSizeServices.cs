using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            if (PrintSizeId > 0)
            {
                cmbPrintSizes.SelectedValue = PrintSizeId;
            }
        }

        private void GetAllPhotoSizes()
        {
            _bgWorkerGetAllPhotoSizes.RunWorkerAsync();
            EnableOrDisableControlsToGetAllPrintSizes();
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
                Console.WriteLine(exception);
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

                    //cmbPrintSizes.SelectedValue = PrintSizeId;

                    cmbPrintSizes_SelectedIndexChanged(null, null);
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
            catch (InvalidOperationException)
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }



        private void cmbPrintSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbPrintSizes.SelectedValue.ToString(), out var printSizeId)) return;
            PrintSizeId = printSizeId;
            var printSizesViewModel = _printSizesViewModels.FirstOrDefault(x => x.Id == printSizeId);
            if (printSizesViewModel == null) return;
            _bgWorkerGetPrintSizeServices.RunWorkerAsync(printSizeId);
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
                    Console.WriteLine(exception);
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
                Console.WriteLine(exception);
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
    }
}
