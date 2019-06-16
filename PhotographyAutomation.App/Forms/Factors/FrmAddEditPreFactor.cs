using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Factors
{
    public partial class FrmAddEditPreFactor : Form
    {
        private int _selectedOriginalSizeId;
        private int _selectedPrintServiceId;
        public FrmAddEditPreFactor()
        {
            InitializeComponent();
        }

        private void FrmAddEditPreFactor_Load(object sender, EventArgs e)
        {
            LoadOriginalPrintSizes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }





        private void LoadOriginalPrintSizes()
        {
            bgWorkerLoadOriginalPringSizes.RunWorkerAsync();
            circularOriginalPrintSize.IsRunning = bgWorkerLoadOriginalPringSizes.IsBusy;
            cmbOriginalPrintSize.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;
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
            circularOriginalPrintSize.IsRunning = bgWorkerLoadOriginalPringSizes.IsBusy;

            cmbOriginalPrintService.Enabled = !bgWorkerLoadOriginalPringSizes.IsBusy;

            if (bgWorkerLoadOriginalPringSizes.IsBusy == false)
                circularOriginalPrintSize.Hide();
        }




        private void cmbOriginalPrintSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOriginalPrintSize.Focused && (int)cmbOriginalPrintSize.SelectedValue > 0)
            {
                cmbOriginalPrintService.Enabled = true;
                _selectedOriginalSizeId = (int)cmbOriginalPrintSize.SelectedValue;
                txtOriginalPrintServicePrice.ResetText();
                GetOriginalPrintSizePrice(_selectedOriginalSizeId);
                LoadPrintSizeService(_selectedOriginalSizeId);
            }
        }

        private void GetOriginalPrintSizePrice(int printSizeId)
        {
            bgWorkerGetOriginalPrintPrice.RunWorkerAsync(printSizeId);
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
                txtOriginalPrintSizePrice.Text = @"------"; ;
            }
        }





        private void LoadPrintSizeService(int printSizeId)
        {
            bgWorkerLoadPrintSizeServices.RunWorkerAsync(printSizeId);
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
                        var result = db.PrintServices_PrintSizePriceGenericRepository.Get(x => x.PrintSizePriceId == printSizeId)
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
            circularOriginalPrintServices.IsRunning = bgWorkerLoadPrintSizeServices.IsBusy;
            if (bgWorkerLoadPrintSizeServices.IsBusy == false)
                circularOriginalPrintServices.Hide();
        }




        private void cmbOriginalPrintService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cmbOriginalPrintService.SelectedValue.ToString(), out _selectedPrintServiceId))
            {
                _selectedPrintServiceId = (int)cmbOriginalPrintService.SelectedValue;
                GetPrintServicePrice(_selectedPrintServiceId);
            }
        }

        private void GetPrintServicePrice(int printServiceId)
        {
            bgWorkerGetPrintServicePrice.RunWorkerAsync(printServiceId);
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
    }
}
