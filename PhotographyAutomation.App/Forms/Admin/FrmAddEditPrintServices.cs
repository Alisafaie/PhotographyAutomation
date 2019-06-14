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
    public partial class FrmAddEditPrintServices : Form
    {
        #region Variables

        private int _selectedPrintSizeId = 0;
        private int _selectedPrintServiceId = 0;

        #endregion
        public FrmAddEditPrintServices()
        {
            InitializeComponent();
            //cmbPrintSizes.Enabled = false;
            //cmbPrintServiceType.Enabled = false;
        }

        private void FrmAddEditPrintServices_Load(object sender, EventArgs e)
        {
            bgWorkerLoadPrintSizes.RunWorkerAsync();
            cmbPrintSizes.Enabled = !bgWorkerLoadPrintSizes.IsBusy;

            bgWorkerLoadPrintServices.RunWorkerAsync();
            cmbPrintServiceType.Enabled = !bgWorkerLoadPrintServices.IsBusy;
            panelHasPrintService.Enabled = !bgWorkerLoadPrintServices.IsBusy;

            rbHasNotPrintService.Checked = bgWorkerLoadPrintServices.IsBusy;

            //bgWorkerLoadTable.RunWorkerAsync();
        }

        private void bgWorkerLoadTable_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void bgWorkerLoadTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }



        private void bgWorkerLoadPrintSizes_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizePricesGenericRepository.Get()
                        .Select(x => new PrintSizePriceViewModel
                        {
                            Id = x.Id,
                            SizeName = x.SizeName
                        }).ToList();
                    int maxId = result.Last().Id;
                    PrintSizePriceViewModel psItem = new PrintSizePriceViewModel
                    {
                        Id = maxId + 1,
                        SizeName = "جدید",
                        OriginalPrintPrice = 0,
                        SecontPrintPrice = 0,
                        SizeWidth = 0,
                        SizeHeight = 0,
                        SizeDescription = null
                    };
                    result.Add(psItem);
                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }

        private void bgWorkerLoadPrintSizes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                cmbPrintSizes.DataSource = e.Result;
                cmbPrintSizes.DisplayMember = "SizeName";
                cmbPrintSizes.ValueMember = "Id";
            }
            cmbPrintSizes.Enabled = !bgWorkerLoadPrintSizes.IsBusy;

        }



        private void bgWorkerLoadPrintServices_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintServicesGenericRepository.Get()
                        .Select(x => new PrintServicesViewModel
                        {
                            Id = x.Id,
                            Code = x.Code,
                            PrintServiceName = x.PrintServiceName,
                            PrintServiceDescription = x.PrintServiceDescription
                        }).ToList();

                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }

        private void bgWorkerLoadPrintServices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                cmbPrintServiceType.DataSource = e.Result;
                cmbPrintServiceType.DisplayMember = "PrintServiceName";
                cmbPrintServiceType.ValueMember = "Id";
            }
            cmbPrintServiceType.Enabled = !bgWorkerLoadPrintServices.IsBusy;
            panelHasPrintService.Enabled = !bgWorkerLoadPrintServices.IsBusy;
            rbHasNotPrintService.Checked = !bgWorkerLoadPrintServices.IsBusy;
            rbHasNotPrintService_CheckedChanged(null, null);
        }

        private void cmbPrintSizes_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbPrintSizes.Enabled && cmbPrintSizes.SelectedValue != null)
            {
                _selectedPrintSizeId = (int)cmbPrintSizes.SelectedValue;
                cmbPrintSizes_SelectedIndexChanged(null, null);
            }
        }

        private void cmbPrintServiceType_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbPrintServiceType.Enabled && cmbPrintServiceType.SelectedValue != null)
                _selectedPrintServiceId = (int)cmbPrintServiceType.SelectedValue;
        }

        private void cmbPrintSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrintSizes.Enabled && cmbPrintSizes.SelectedValue != null)
            {
                _selectedPrintSizeId = (int)cmbPrintSizes.SelectedValue;

                //برای اینکه جدید انتخاب نشود
                if (cmbPrintSizes.SelectedIndex != cmbPrintSizes.Items.Count - 1)
                {
                    DisableInputComponents();
                    bgWorkerGetPrintSizePrices.RunWorkerAsync(_selectedPrintSizeId);
                }
                else
                {
                    EnableInputComponents();
                    integerInputOriginalPrintPrice.ResetText();
                    integerInputSecondPrintPrice.ResetText();
                    checkBoxEnablePrintSizeItems.Checked = true;
                    doubleInputWidth.Focus();
                }
            }
        }

        private void cmbPrintServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrintServiceType.Enabled && cmbPrintServiceType.SelectedValue != null)
            {
                _selectedPrintServiceId = (int)cmbPrintServiceType.SelectedValue;
                //txtPrintServiceCode.Focus();
                bgWorkerGetPrintServicePrice.RunWorkerAsync();
            }
        }

        private void bgWorkerGetPrintSizePrices_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizePricesGenericRepository.Get(x => x.Id == (int)e.Argument)
                        .Select(x => new PrintSizePriceViewModel()
                        {
                            Id = x.Id,
                            SizeName = x.SizeName,
                            SizeHeight = x.SizeHeight,
                            SizeWidth = x.SizeWidth,
                            OriginalPrintPrice = x.OriginalPrintPrice,
                            SecontPrintPrice = x.SecondPrintPrice,
                            SizeDescription = x.SizeDescription
                        }).ToList();

                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }

        private void bgWorkerGetPrintSizePrices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is List<PrintSizePriceViewModel> result)
                {
                    integerInputOriginalPrintPrice.Value = result[0].OriginalPrintPrice;
                    integerInputSecondPrintPrice.Value = result[0].SecontPrintPrice;
                    doubleInputWidth.Value = (double)result[0].SizeWidth;
                    doubleInputHeight.Value = (double)result[0].SizeHeight;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                using (var db = new UnitOfWork())
                {
                    string sizeDesc = null;
                    var dr = RtlMessageBox.Show(
                        "آیا برای این سایز چاپ توضیح خاصی مد نظر دارید؟",
                        "اضافه کردن توضیح برای سایز چاپ جدید",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.Yes)
                    {
                        var frmInput = new FrmAddEditInput
                        {
                            lblFormQuestion =
                            {
                                Text = @"لطفا توضیحات مورد نظر خود را وارد نمایید."
                            },
                            Text = @"ثبت توضیحات برای سایز چاپ"
                        };

                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            sizeDesc = frmInput.txtContent.Text;
                        }
                    }

                    if (cmbPrintSizes.SelectedItem is PrintSizePriceViewModel itemNewSize &&
                        itemNewSize.SizeName == "جدید")
                    {

                        var itemSizePrice = new TblPrintSizePrices
                        {
                            SizeName = doubleInputWidth.Text + " x " + doubleInputHeight.Text,
                            OriginalPrintPrice = integerInputOriginalPrintPrice.Value,
                            SecondPrintPrice = integerInputSecondPrintPrice.Value,
                            SizeWidth = (decimal)doubleInputWidth.Value,
                            SizeHeight = (decimal)doubleInputHeight.Value,
                            SizeDescription = sizeDesc
                        };

                        db.PrintSizePricesGenericRepository.Insert(itemSizePrice);
                        var resultNewPrintSize = db.Save();
                        _selectedPrintSizeId = itemSizePrice.Id;

                        if (rbHasPrintService.Checked)
                        {
                            var itemServiceTypePrice = new TblPrintServices_TblPrintSizePrice
                            {
                                Code = txtPrintServiceCode.Text,
                                Price = integerInputPrintServicePrice.Value,
                                PrintSizePriceId = _selectedPrintSizeId,
                                PrintServiceId = _selectedPrintServiceId
                            };
                            db.PrintServices_PrintSizePriceGenericRepository.Insert(itemServiceTypePrice);
                        }

                        var resultPrintService = db.Save();

                        if (resultNewPrintSize > 0 && resultPrintService > 0)
                        {
                            bgWorkerGetPrintSizePrices.RunWorkerAsync();
                            cmbPrintSizes.Enabled = !bgWorkerGetPrintSizePrices.IsBusy;
                        }

                    }
                    else if (cmbPrintSizes.SelectedItem is PrintSizePriceViewModel)
                    {
                        if (checkBoxEnablePrintSizeItems.Checked)
                        {
                            var itemSizePrice = new TblPrintSizePrices
                            {
                                Id = (int)cmbPrintSizes.SelectedValue,
                                SizeName = doubleInputWidth.Text + " x " + doubleInputHeight.Text,
                                OriginalPrintPrice = integerInputOriginalPrintPrice.Value,
                                SecondPrintPrice = integerInputSecondPrintPrice.Value,
                                SizeWidth = (decimal)doubleInputWidth.Value,
                                SizeHeight = (decimal)doubleInputHeight.Value,
                                SizeDescription = sizeDesc
                            };
                            db.PrintSizePricesGenericRepository.Update(itemSizePrice);
                        }

                        var itemServiceTypePrice = new TblPrintServices_TblPrintSizePrice
                        {
                            Code = txtPrintServiceCode.Text,
                            Price = integerInputPrintServicePrice.Value,
                            PrintSizePriceId = _selectedPrintSizeId,
                            PrintServiceId = _selectedPrintServiceId
                        };
                        
                        var itemPrintSizePrintService = db.PrintServices_PrintSizePriceGenericRepository.Get(x =>
                            x.PrintServiceId == _selectedPrintServiceId &&
                            x.PrintSizePriceId == _selectedPrintSizeId).SingleOrDefault();
                        if (itemPrintSizePrintService == null)
                        {
                            db.PrintServices_PrintSizePriceGenericRepository.Insert(itemServiceTypePrice);
                        }
                        else
                        {
                            itemPrintSizePrintService.PrintServiceId = _selectedPrintServiceId;
                            itemPrintSizePrintService.PrintSizePriceId = _selectedPrintSizeId;
                            itemPrintSizePrintService.Code = txtPrintServiceCode.Text;
                            itemPrintSizePrintService.Price = integerInputPrintServicePrice.Value;
                            db.PrintServices_PrintSizePriceGenericRepository.Update(itemPrintSizePrintService);
                        }

                        db.Save();
                    }
                }
            }
        }

        private bool CheckInputs()
        {
            return true;
        }


        private void checkBoxEnablePrintSizeItems_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnablePrintSizeItems.Checked)
            {
                EnableInputComponents();
            }
            else
            {
                DisableInputComponents();
            }
        }

        private void DisableInputComponents()
        {
            doubleInputHeight.Enabled = false;
            doubleInputWidth.Enabled = false;
            doubleInputHeight.IsInputReadOnly = true;
            doubleInputWidth.IsInputReadOnly = true;

            integerInputOriginalPrintPrice.IsInputReadOnly = true;
            integerInputSecondPrintPrice.IsInputReadOnly = true;
            integerInputOriginalPrintPrice.Enabled = false;
            integerInputSecondPrintPrice.Enabled = false;
        }

        private void EnableInputComponents()
        {
            doubleInputHeight.Enabled = true;
            doubleInputWidth.Enabled = true;
            doubleInputHeight.IsInputReadOnly = false;
            doubleInputWidth.IsInputReadOnly = false;

            integerInputOriginalPrintPrice.IsInputReadOnly = false;
            integerInputSecondPrintPrice.IsInputReadOnly = false;
            integerInputOriginalPrintPrice.Enabled = true;
            integerInputSecondPrintPrice.Enabled = true;
        }

        private void rbHasPrintService_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHasPrintService.Checked)
            {
                txtPrintServiceCode.Enabled = true;
                cmbPrintServiceType.Enabled = true;
                integerInputPrintServicePrice.Enabled = true;
                cmbPrintServiceType.DroppedDown = true;
            }
        }

        private void rbHasNotPrintService_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHasNotPrintService.Checked)
            {
                txtPrintServiceCode.Enabled = false;
                cmbPrintServiceType.Enabled = false;
                integerInputPrintServicePrice.Enabled = false;
            }
        }

        private void circularProgress1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bgWorkerGetPrintServicePrice_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintServices_PrintSizePriceGenericRepository.Get(
                            x =>
                                x.PrintServiceId == _selectedPrintServiceId
                                &&
                                x.PrintSizePriceId == _selectedPrintSizeId)

                        .Select(x => new PrintServiceType_PrintSizePriceViewModel
                        {
                            Id = x.Id,
                            Code = x.Code,
                            PrintServiceName = x.TblPrintServices.PrintServiceName,
                            Description = x.Description,
                            PrintSizePriceId = x.PrintSizePriceId,
                            PrintServiceId = x.PrintServiceId,
                            Price = x.Price,
                            PrintSizeName = x.TblPrintSizePrices.SizeName
                        }).ToList();

                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }

        private void bgWorkerGetPrintServicePrice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is List<PrintServiceType_PrintSizePriceViewModel> result)
                {
                    if (result.Any())
                    {
                        txtPrintServiceCode.Text = result[0].Code;
                        integerInputPrintServicePrice.Value = result[0].Price;
                    }
                    else
                    {
                        txtPrintServiceCode.ResetText();
                        integerInputPrintServicePrice.ResetText();
                    }
                }
            }
        }
    }
}