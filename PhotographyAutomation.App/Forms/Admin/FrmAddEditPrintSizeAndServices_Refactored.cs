using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Admin
{
    public partial class FrmAddEditPrintSizeAndServices_Refactored : Form
    {
        #region Variables

        private bool _newSizeFlag;
        private bool _editSizeFlag;
        private bool _deleteSizeFlag;

        private int _selectedPrintSizeId;
        private int _selectedPrintServiceId;
        private int _selectedPrintSizeServiceId;

        private readonly BackgroundWorker _bgWorkerUpdatePrintSizeService = new BackgroundWorker();
        private readonly BackgroundWorker _bgWorkerSaveNewPrintSizeService = new BackgroundWorker();


        private List<PrintSizesViewModel> _printSizesViewModels = new List<PrintSizesViewModel>();

        #endregion Variables


        #region Form Events
        public FrmAddEditPrintSizeAndServices_Refactored()
        {
            InitializeComponent();
        }

        private void FrmAddEditPrintSizeAndServices_Refactored_Load(object sender, EventArgs e)
        {
            GetAllPhotoSizes();
        }

        private void GetAllPhotoSizes()
        {
            BackgroundWorker bgWorkerGetAllPhotoSizes = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = false
            };
            bgWorkerGetAllPhotoSizes.DoWork += BgWorkerGetAllPhotoSizes_DoWork;
            bgWorkerGetAllPhotoSizes.RunWorkerCompleted += BgWorkerGetAllPhotoSizes_RunWorkerCompleted;

            bgWorkerGetAllPhotoSizes.RunWorkerAsync();
        }



        private void BgWorkerGetAllPhotoSizes_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizesGenericRepository
                        .Get()
                        .Select(x => new PrintSizesViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Width = x.Width,
                            Height = x.Height,
                            Descriptions = x.Descriptions,
                            HasAlbum = x.HasAlbum,
                            HasFirstPrint = x.HasFirstPrint,
                            HasItalianAlbum = x.HasItalianAlbum,
                            HasLitPrint = x.HasLitPrint,
                            HasMedicalPhoto = x.HasMedicalPhoto,
                            HasRePrint = x.HasRePrint,
                            HasScanAndProcessing = x.HasScanAndProcessing,
                            IsActive = x.IsActive,
                            IsDeleted = x.IsDeleted,
                            
                        })
                        .OrderBy(x => x.Width)
                        .ThenBy(x => x.Height)
                        .ToList();
                    if (result != null && result.Count > 0)
                    {
                        e.Result = result;
                        _printSizesViewModels = result;
                    }
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
                if (e.Result is PrintSizesViewModel viewModel)
                {
                    cmbPrintSizes.DataSource = viewModel;
                    cmbPrintSizes.DisplayMember = "Name";
                    cmbPrintSizes.ValueMember = "Id";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
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


        #region Buttons
        private void btnNewPrintSize_Click(object sender, EventArgs e)
        {

        }

        private void btnEditPrintSize_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPrintService_Click(object sender, EventArgs e)
        {

        }

        private void btnEditPrintService_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePrintSizeProperties_Click(object sender, EventArgs e)
        {

        }


        private void btnSavePhotoSizePrices_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePrintServicePrice_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region ComboBoxes Selected Index Chenged

        private void cmbPrintSizes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPrintServices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}