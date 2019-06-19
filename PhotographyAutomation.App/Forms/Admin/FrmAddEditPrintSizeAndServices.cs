﻿using PhotographyAutomation.DateLayer.Context;
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
    public partial class FrmAddEditPrintSizeAndServices : Form
    {
        #region Variables

        private bool _newSizeFlag;
        private bool _editSizeFlag;
        private bool _deleteSizeFlag;


        #endregion Variables

        public FrmAddEditPrintSizeAndServices()
        {
            InitializeComponent();
        }

        private void checkBoxEnableGroupBoxPrintServices_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxPrintServices.Enabled = checkBoxEnableGroupBoxPrintServices.Checked;
        }

        private void checkBoxNewSize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNewSize.Checked)
            {
                _newSizeFlag = true;
                doubleInputWidth.Enabled = doubleInputHeight.Enabled = true;
                integerInputOriginalPrintPrice.ResetText();
                integerInputSecondPrintPrice.ResetText();
                //integerInputOriginalPrice.LockUpdateChecked = true;
                //integerInputSecondPrintPrice.LockUpdateChecked = true;
                panelPrintSize1.Enabled = false;

                doubleInputWidth.Focus();
            }
            else
            {
                _newSizeFlag = false;
                doubleInputHeight.Enabled = doubleInputWidth.Enabled = false;
                panelPrintSize1.Enabled = true;
            }
        }




        private void FrmAddEditPrintSizeAndServices_Load(object sender, EventArgs e)
        {
            bgWorkerLoadPrintSizes1.RunWorkerAsync();
            cpLoadPrintSizes1.IsRunning = bgWorkerLoadPrintSizes1.IsBusy;
            cmbPrintSizes.Enabled = !bgWorkerLoadPrintSizes1.IsBusy;
        }


        private void bgWorkerLoadPrintSizes1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizePricesGenericRepository.Get()
                        .OrderBy(x => x.SizeWidth)
                        .ThenBy(x => x.SizeHeight)
                        .ToList();
                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        private void bgWorkerLoadPrintSizes1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbPrintSizes.DataSource = e.Result;
            cmbPrintSizes.DisplayMember = "SizeName";
            cmbPrintSizes.ValueMember = "Id";

            cpLoadPrintSizes1.IsRunning = bgWorkerLoadPrintSizes1.IsBusy;
            cmbPrintSizes.Enabled = !bgWorkerLoadPrintSizes1.IsBusy;


            if (cmbPrintSizes.Items.Count > 0 && cmbPrintSizes.SelectedValue != null && bgWorkerGetPrintSizePrice.IsBusy == false)
            {
                bgWorkerGetPrintSizePrice.RunWorkerAsync((int)cmbPrintSizes.SelectedValue);
                cpGetPrintSizePrice.IsRunning = bgWorkerGetPrintSizePrice.IsBusy;

                integerInputOriginalPrintPrice.LockUpdateChecked = false;
                integerInputSecondPrintPrice.LockUpdateChecked = false;

            }
        }



        private void bgWorkerGetPrintSizePrice_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.PrintSizePricesGenericRepository.Get(x => x.Id == (int)e.Argument).Select(x =>
                       new PrintSizePriceViewModel
                       {
                           Id = x.Id,
                           SizeName = x.SizeName,
                           SizeWidth = x.SizeWidth,
                           SizeHeight = x.SizeHeight,
                           OriginalPrintPrice = x.OriginalPrintPrice,
                           SecontPrintPrice = x.SecondPrintPrice,
                           SizeDescription = x.SizeDescription
                       }).ToList();
                    e.Result = result;

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        private void bgWorkerGetPrintSizePrice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is List<PrintSizePriceViewModel> sizePriceList)
                {
                    doubleInputWidth.Value = (double)sizePriceList[0].SizeWidth;
                    doubleInputHeight.Value = (double)sizePriceList[0].SizeHeight;
                    integerInputOriginalPrintPrice.Value = sizePriceList[0].OriginalPrintPrice;
                    integerInputSecondPrintPrice.Value = sizePriceList[0].SecontPrintPrice;
                }
            }
            cpGetPrintSizePrice.IsRunning = bgWorkerGetPrintSizePrice.IsBusy;
        }




        private void btnSavePrintSizePrice_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                string sizeDescription = null;

                if (_newSizeFlag)
                {
                    var dr = RtlMessageBox.Show(
                        "آیا توضیح خاصی برای این اندازه چاپ در نظر دارید؟",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {
                        using (var frmInput = new FrmAddEditInput())
                        {
                            frmInput.lblFormQuestion.Text =
                                @"لطفا توضیحات مورد نظر خود در رابطه با سایز چاپ مورد نظر را وارد نمایید.";
                            frmInput.ShowDialog();
                            sizeDescription = frmInput.txtContent.Text;
                        }
                    }

                    SaveNewPrintSize(doubleInputWidth.Value, doubleInputHeight.Value, integerInputOriginalPrintPrice.Value,
                        integerInputSecondPrintPrice.Value, sizeDescription);

                    doubleInputWidth.ResetText();
                    doubleInputHeight.ResetText();
                    integerInputOriginalPrintPrice.ResetText();
                    integerInputSecondPrintPrice.ResetText();
                    checkBoxNewSize.Checked = false;
                }
                else if (_editSizeFlag)
                {
                    UpdateOldPrintSize((int)cmbPrintSizes.SelectedValue);
                    btnSavePrintSizePrice.Enabled = !bgWorkerUpdatePrintSize.IsBusy;

                    ویرایشاندازهچاپToolStripMenuItem.Checked = false;
                }
                else if (_deleteSizeFlag)
                {
                    DeletePrintSize((int)cmbPrintSizes.SelectedValue);
                    btnSavePrintServicePrice.Enabled = !bgWorkerDeletePrintSize.IsBusy;

                    حذفاندازهچاپToolStripMenuItem.Checked = false;
                }
            }
        }

        private void DeletePrintSize(int printSizeId)
        {
            bgWorkerDeletePrintSize.RunWorkerAsync(printSizeId);
            cpLoadPrintSizes1.IsRunning = bgWorkerDeletePrintSize.IsBusy;
            cmbPrintSizes.Enabled = !bgWorkerDeletePrintSize.IsBusy;
        }
        private void bgWorkerDeletePrintSize_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                int printSizeId = (int)e.Argument;
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        TblPrintSizePrices printSizeInDb = db.PrintSizePricesGenericRepository.GetById(printSizeId);
                        if (printSizeInDb != null)
                        {
                            var sizePriceServiceList =
                                db.PrintServices_PrintSizePriceGenericRepository
                                    .Get(x => x.PrintSizePriceId == printSizeId)
                                    .ToList();

                            if (sizePriceServiceList.Any())
                            {
                                e.Result = sizePriceServiceList;
                            }
                            else
                            {
                                db.PrintSizePricesGenericRepository.Delete(printSizeInDb);
                                var result = db.Save();
                                e.Result = result;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        private void bgWorkerDeletePrintSize_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (int.TryParse(e.Result.ToString(), out _))
            {
                if (bgWorkerLoadPrintSizes1.IsBusy == false && bgWorkerGetPrintSizePrice.IsBusy == false)
                {
                    bgWorkerLoadPrintSizes1.RunWorkerAsync();
                    cpLoadPrintSizes1.IsRunning = bgWorkerLoadPrintSizes1.IsBusy;
                }
            }
            else
            {
                RtlMessageBox.Show(
                    "این اندازه چاپ حاوی تعدادی خدمات چاپ می باشد. " + Environment.NewLine +
                    "لطفا ابتدا آنها را حذف نموده و پس از آن اقدام به حذف این امدازه چاپ نمایید.",
                    "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // قبلش چک کن که این سایز چاپ قبلا در سیستم نباشه
        private void SaveNewPrintSize(double width, double height, int originalPrintPrice, int secondPrintPrice,
            string sizeDescription)
        {
            TblPrintSizePrices sizePrices = new TblPrintSizePrices
            {
                OriginalPrintPrice = originalPrintPrice,
                SecondPrintPrice = secondPrintPrice,
                SizeWidth = (decimal)width,
                SizeHeight = (decimal)height,
                SizeName = width.ToString("###.#") +
                           " x " +
                           height.ToString("###.#"),
                SizeDescription = sizeDescription
            };

            bgWorkerSaveNewPrintSize.RunWorkerAsync(sizePrices);
            btnSavePrintServicePrice.Enabled = !bgWorkerSaveNewPrintSize.IsBusy;
            cpBtnSave.IsRunning = bgWorkerSaveNewPrintSize.IsBusy;
        }
        private void bgWorkerSaveNewPrintSize_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var newSize = (TblPrintSizePrices)e.Argument;
                    db.PrintSizePricesGenericRepository.Insert(newSize);
                    db.Save();
                    e.Result = newSize.Id;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private void bgWorkerSaveNewPrintSize_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result > 0)
            {
                btnSavePrintServicePrice.Enabled = !bgWorkerSaveNewPrintSize.IsBusy;
                cpBtnSave.IsRunning = bgWorkerSaveNewPrintSize.IsBusy;

                bgWorkerLoadPrintSizes1.RunWorkerAsync();
                cmbPrintSizes.Enabled = !bgWorkerLoadPrintSizes1.IsBusy;
                cpLoadPrintSizes1.IsRunning = bgWorkerLoadPrintSizes1.IsBusy;

                cmbPrintSizes.SelectedValue = (int)e.Result;
            }
        }




        private void UpdateOldPrintSize(int printSizeId)
        {
            bgWorkerGetPrintSizeInfo.RunWorkerAsync(printSizeId);

            btnSavePrintServicePrice.Enabled = !bgWorkerSaveNewPrintSize.IsBusy;
            cpBtnSave.IsRunning = bgWorkerSaveNewPrintSize.IsBusy;
        }



        private void bgWorkerGetPrintSizeInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((int)e.Argument > 0)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        var sizePrintInDb = db.PrintSizePricesGenericRepository.GetById((int)e.Argument);
                        e.Result = sizePrintInDb;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
        private void bgWorkerGetPrintSizeInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                var sizePrintInDb = (TblPrintSizePrices)e.Result;
                var editedSizePrint = new TblPrintSizePrices
                {
                    Id = sizePrintInDb.Id,
                    OriginalPrintPrice = integerInputOriginalPrintPrice.Value,
                    SecondPrintPrice = integerInputSecondPrintPrice.Value,
                    SizeWidth = (decimal)doubleInputWidth.Value,
                    SizeHeight = (decimal)doubleInputHeight.Value,
                    SizeName = doubleInputWidth.Value.ToString("###.#") + " x " +
                               doubleInputHeight.Value.ToString("###.#")
                };
                using (var frmInput = new FrmAddEditInput())
                {
                    frmInput.lblFormQuestion.Text = @"آیا برای این اندازه چاپ توضیح خاصی در نظر دارید؟";
                    frmInput.txtContent.Text = sizePrintInDb.SizeDescription;
                    frmInput.ShowDialog();
                    editedSizePrint.SizeDescription = frmInput.txtContent.Text;
                }


                bgWorkerUpdatePrintSize.RunWorkerAsync(editedSizePrint);

                cmbPrintSizes.Enabled = !bgWorkerUpdatePrintSize.IsBusy;
                cpLoadPrintSizes1.IsRunning = bgWorkerUpdatePrintSize.IsBusy;
                btnSavePrintServicePrice.Enabled = !bgWorkerUpdatePrintSize.IsBusy;
                cpBtnSave.IsRunning = bgWorkerUpdatePrintSize.IsBusy;
            }
        }


        private void bgWorkerUpdatePrintSize_DoWork(object sender, DoWorkEventArgs e)
        {
            var editedSizePrice = (TblPrintSizePrices)e.Argument;
            if (editedSizePrice != null)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        db.PrintSizePricesGenericRepository.Update(editedSizePrice);
                        e.Result = db.Save();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
        private void bgWorkerUpdatePrintSize_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                RtlMessageBox.Show("اندازه چاپ مورد نظر با موفقیت ویرایش گردید.");
                if (bgWorkerLoadPrintSizes1.IsBusy == false)
                    bgWorkerLoadPrintSizes1.RunWorkerAsync();
            }

            cmbPrintSizes.Enabled = !bgWorkerUpdatePrintSize.IsBusy;
            cpLoadPrintSizes1.IsRunning = bgWorkerUpdatePrintSize.IsBusy;
            cpBtnSave.IsRunning = bgWorkerUpdatePrintSize.IsBusy;
        }




        private bool CheckInputs()
        {
            if (cmbPrintSizes.Items.Count == 0)
            {
                return false;
            }

            if (checkBoxNewSize.Checked)
            {
                if (string.IsNullOrEmpty(doubleInputWidth.Text.Trim()) ||
                    string.IsNullOrEmpty(doubleInputHeight.Text.Trim()))
                {
                    return false;
                }
            }

            if (ویرایشاندازهچاپToolStripMenuItem.Checked)
            {
                if (string.IsNullOrEmpty(doubleInputWidth.Text.Trim()) ||
                    string.IsNullOrEmpty(doubleInputHeight.Text.Trim()))
                {
                    return false;
                }
            }

            if (string.IsNullOrEmpty(integerInputOriginalPrintPrice.Text.Trim()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(integerInputSecondPrintPrice.Text.Trim()))
            {
                return false;
            }

            return true;
        }
        



        private void cmbPrintSizes_EnabledChanged(object sender, EventArgs e)
        {
            if (cmbPrintSizes.Enabled && cmbPrintSizes.SelectedValue != null)
            {
                //_selectedPrintSizeId = (int)cmbPrintSizes.SelectedValue;
                cmbPrintSizes_SelectedIndexChanged(null, null);
            }
        }
        private void cmbPrintSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrintSizes.Enabled && cmbPrintSizes.SelectedValue != null)
            {
                //var tt = cmbPrintSizes.SelectedItem as PrintSizePriceViewModel;

                // while (bgWorkerGetPrintSizePrice.IsBusy == false)
                bgWorkerGetPrintSizePrice.RunWorkerAsync((int)cmbPrintSizes.SelectedValue);
                integerInputOriginalPrintPrice.LockUpdateChecked = false;
                integerInputSecondPrintPrice.LockUpdateChecked = false;
            }
        }

        private void ویرایشاندازهچاپToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gbText = groupBoxPrintSize.Text;
            if (ویرایشاندازهچاپToolStripMenuItem.Checked == false)
            {
                _editSizeFlag = true;
                ویرایشاندازهچاپToolStripMenuItem.Checked = true;
                حذفاندازهچاپToolStripMenuItem.Checked = false;
                cmbPrintSizes.Enabled = false;
                if (cmbPrintSizes.SelectedItem is PrintSizePriceViewModel tt)
                {
                    doubleInputWidth.Value = (double) tt.SizeWidth;
                    doubleInputWidth.Enabled = true;
                    doubleInputWidth.IsInputReadOnly = false;

                    doubleInputHeight.Value = (double) tt.SizeHeight;
                    doubleInputHeight.Enabled = true;
                    doubleInputHeight.IsInputReadOnly = false;
                    integerInputOriginalPrintPrice.Value = tt.OriginalPrintPrice;
                    integerInputSecondPrintPrice.Value = tt.SecontPrintPrice;
                }

                groupBoxPrintSize.Text = @"ویرایش اندازه چاپ";
            }
            else if (ویرایشاندازهچاپToolStripMenuItem.Checked)
            {
                _editSizeFlag = false;
                ویرایشاندازهچاپToolStripMenuItem.Checked = false;
                حذفاندازهچاپToolStripMenuItem.Checked = false;
                cmbPrintSizes.Enabled = true;

                groupBoxPrintSize.Text = gbText;
            }
        }

        

        private void حذفاندازهچاپToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gbText = groupBoxPrintSize.Text;
            if (حذفاندازهچاپToolStripMenuItem.Checked == false)
            {
                _deleteSizeFlag = true;
                ویرایشاندازهچاپToolStripMenuItem.Checked = false;
                حذفاندازهچاپToolStripMenuItem.Checked = true;
                cmbPrintSizes.Enabled = false;
                if (cmbPrintSizes.SelectedItem is PrintSizePriceViewModel tt)
                {
                    doubleInputWidth.Value = (double) tt.SizeWidth;
                    doubleInputHeight.Value = (double) tt.SizeHeight;
                    integerInputOriginalPrintPrice.Value = tt.OriginalPrintPrice;
                    integerInputSecondPrintPrice.Value = tt.SecontPrintPrice;

                    integerInputOriginalPrintPrice.Enabled = false;
                    integerInputSecondPrintPrice.Enabled = false;
                    doubleInputWidth.Enabled = false;
                    doubleInputHeight.Enabled = false;
                    checkBoxNewSize.Enabled = false;
                    panelHasPrintService.Enabled = false;
                }

                groupBoxPrintSize.Text = @"حذف اندازه چاپ";
            }
            else if (حذفاندازهچاپToolStripMenuItem.Checked)
            {
                _deleteSizeFlag = false;
                ویرایشاندازهچاپToolStripMenuItem.Checked = false;
                حذفاندازهچاپToolStripMenuItem.Checked = false;
                cmbPrintSizes.Enabled = true;

                integerInputOriginalPrintPrice.Enabled = true;
                integerInputSecondPrintPrice.Enabled = true;
                doubleInputWidth.Enabled = true;
                doubleInputHeight.Enabled = true;
                checkBoxNewSize.Enabled = true;
                panelHasPrintService.Enabled = true;

                groupBoxPrintSize.Text = gbText;
            }
        }

        
    }
}
