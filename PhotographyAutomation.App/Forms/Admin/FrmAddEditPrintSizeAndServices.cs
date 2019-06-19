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
    public partial class FrmAddEditPrintSizeAndServices : Form
    {
        #region Variables

        private bool _newSizeFlag;
        private bool _editSizeFlag;
        private bool _deleteSizeFlag;


        #endregion Variables


        #region Form Events

        public FrmAddEditPrintSizeAndServices()
        {
            InitializeComponent();
        }

        private void FrmAddEditPrintSizeAndServices_Load(object sender, EventArgs e)
        {
            bgWorkerLoadPrintSizes1.RunWorkerAsync();
            cpLoadPrintSizes1.IsRunning = bgWorkerLoadPrintSizes1.IsBusy;
            cmbPrintSizes.Enabled = !bgWorkerLoadPrintSizes1.IsBusy;
        }


        #endregion Form Events


        #region Load Print Size Backgroud Worker
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

                integerInputOriginalPrintPrice.LockUpdateChecked = false;
                integerInputSecondPrintPrice.LockUpdateChecked = false;

            }
        }

        #endregion Load Print Size Backgroud Worker


        #region Get Print Size Price

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
        }

        #endregion Get Print Size Price


        #region Buttons

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

                    ویرایش_اندازه_چاپ_ToolStripMenuItem_Click(null, null);
                }
                else if (_deleteSizeFlag)
                {
                    var dr = RtlMessageBox.Show(
                        "آیا از حذف اندازه چاپ اطمینان دارید؟" + Environment.NewLine +
                        "در صورتی که برای این اندازه چاپ قبلا خدمات چاپ تعریف شده باشد،" + Environment.NewLine +
                        "قادر به حذف آن نبوده و ابتدا می بایست خدمات چاپ زیر مجموعه آن را حذف نمایید.",
                        "تایید حذف اندازه چاپ",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.Yes)
                    {
                        DeletePrintSize((int)cmbPrintSizes.SelectedValue);
                        btnSavePrintServicePrice.Enabled = !bgWorkerDeletePrintSize.IsBusy;
                    }
                    حذف_اندازه_چاپ_ToolStripMenuItem_Click(null, null);
                }
            }
        }

        #endregion


        #region منو

        private void تعریف_خدمات_چاپ_جدید_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void ویرایش_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gbText = groupBoxPrintSize.Text;
            if (ویرایش_اندازه_چاپ_ToolStripMenuItem.Checked == false)
            {
                _editSizeFlag = true;
                ویرایش_اندازه_چاپ_ToolStripMenuItem.Checked = true;
                حذف_اندازه_چاپ_ToolStripMenuItem.Checked = false;
                cmbPrintSizes.Enabled = false;
                if (cmbPrintSizes.SelectedItem is TblPrintSizePrices tt)
                {
                    doubleInputWidth.Value = (double)tt.SizeWidth;
                    doubleInputWidth.Enabled = true;
                    doubleInputWidth.IsInputReadOnly = false;

                    doubleInputHeight.Value = (double)tt.SizeHeight;
                    doubleInputHeight.Enabled = true;
                    doubleInputHeight.IsInputReadOnly = false;
                    integerInputOriginalPrintPrice.Value = tt.OriginalPrintPrice;
                    integerInputSecondPrintPrice.Value = tt.SecondPrintPrice;

                    integerInputOriginalPrintPrice.LockUpdateChecked = false;
                    integerInputSecondPrintPrice.LockUpdateChecked = false;

                    //checkBoxNewSize.CheckState = CheckState.Checked;
                }

                groupBoxPrintSize.Text = @"ویرایش اندازه و قیمت چاپ";
            }
            else if (ویرایش_اندازه_چاپ_ToolStripMenuItem.Checked)
            {
                _editSizeFlag = false;
                ویرایش_اندازه_چاپ_ToolStripMenuItem.Checked = false;
                حذف_اندازه_چاپ_ToolStripMenuItem.Checked = false;
                cmbPrintSizes.Enabled = true;
                checkBoxNewSize.Checked = false;
                groupBoxPrintSize.Text = gbText;
            }
        }




        private void حذف_خدمات_چاپ_مربوط_به_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void حذف_اندازه_چاپ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gbText = groupBoxPrintSize.Text;
            if (حذف_اندازه_چاپ_ToolStripMenuItem.Checked == false)
            {
                _deleteSizeFlag = true;
                ویرایش_اندازه_چاپ_ToolStripMenuItem.Checked = false;
                حذف_اندازه_چاپ_ToolStripMenuItem.Checked = true;
                cmbPrintSizes.Enabled = false;
                if (cmbPrintSizes.SelectedItem is TblPrintSizePrices tt)
                {
                    doubleInputWidth.Value = (double)tt.SizeWidth;
                    doubleInputHeight.Value = (double)tt.SizeHeight;
                    integerInputOriginalPrintPrice.Value = tt.OriginalPrintPrice;
                    integerInputSecondPrintPrice.Value = tt.SecondPrintPrice;

                    integerInputOriginalPrintPrice.Enabled = false;
                    integerInputSecondPrintPrice.Enabled = false;
                    doubleInputWidth.Enabled = false;
                    doubleInputHeight.Enabled = false;
                    checkBoxNewSize.Enabled = false;

                    panelPrintSize1.Enabled = false;
                    panelHasPrintService.Enabled = false;
                    panelNewEditPrintSize.Enabled = false;
                    panelOriginalPrintPrice.Enabled = false;
                    panelSecondPrintPrice.Enabled = false;
                }

                groupBoxPrintSize.Text = @"حذف اندازه چاپ";
            }
            else if (حذف_اندازه_چاپ_ToolStripMenuItem.Checked)
            {
                _deleteSizeFlag = false;
                ویرایش_اندازه_چاپ_ToolStripMenuItem.Checked = false;
                حذف_اندازه_چاپ_ToolStripMenuItem.Checked = false;
                cmbPrintSizes.Enabled = true;

                integerInputOriginalPrintPrice.Enabled = true;
                integerInputSecondPrintPrice.Enabled = true;
                doubleInputWidth.Enabled = true;
                doubleInputHeight.Enabled = true;
                checkBoxNewSize.Enabled = true;

                panelPrintSize1.Enabled = true;
                panelHasPrintService.Enabled = true;
                panelNewEditPrintSize.Enabled = true;
                panelOriginalPrintPrice.Enabled = true;
                panelSecondPrintPrice.Enabled = true;

                groupBoxPrintSize.Text = gbText;
            }
        }

        #endregion منو

        
        #region Check Inputs

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

            if (ویرایش_اندازه_چاپ_ToolStripMenuItem.Checked)
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

            if (_newSizeFlag)
            {
                try
                {
                    using (var db=new UnitOfWork())
                    {
                        var result = db.PrintSizePricesGenericRepository.Get(x =>
                            (x.SizeWidth == (decimal) doubleInputWidth.Value &&
                             x.SizeHeight == (decimal) doubleInputHeight.Value) ||
                            (x.SizeWidth == (decimal) doubleInputHeight.Value &&
                             x.SizeHeight == (decimal) doubleInputWidth.Value)).ToList();
                        if (result.Any())
                        {
                            RtlMessageBox.Show(
                                "این اندازه چاپ در سیستم وجود دارد.",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            panelNewEditPrintSize.Focus();
                            return false;
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }

            return true;
        }

        #endregion Check Inputs


        #region New Print Size
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
                if(bgWorkerLoadPrintSizes1.IsBusy==false)
                    cpLoadPrintSizes1.Hide();
                //cmbPrintSizes.SelectedValue = (int)e.Result;
            }
        }

        #endregion New Print Size


        #region Update Print Size
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

        #endregion Update Print Size


        #region Delete Print Size

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

        #endregion Delete Print Size


        #region cmbPrintSizes

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

                while (bgWorkerGetPrintSizePrice.IsBusy == false)
                    bgWorkerGetPrintSizePrice.RunWorkerAsync((int)cmbPrintSizes.SelectedValue);
                integerInputOriginalPrintPrice.LockUpdateChecked = false;
                integerInputSecondPrintPrice.LockUpdateChecked = false;
            }
        }

        #endregion cmbPrintSizes

        private void checkBoxNewSize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNewSize.Checked)
            {
                _newSizeFlag = true;
                doubleInputWidth.Enabled = doubleInputHeight.Enabled = true;
                integerInputOriginalPrintPrice.LockUpdateChecked = true;
                integerInputSecondPrintPrice.LockUpdateChecked = true;
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
        private void checkBoxEnableGroupBoxPrintServices_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxPrintServices.Enabled = checkBoxEnableGroupBoxPrintServices.Checked;
        }
    }
}
