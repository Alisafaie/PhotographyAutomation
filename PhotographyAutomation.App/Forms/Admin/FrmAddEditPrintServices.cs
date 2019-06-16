using DevComponents.DotNetBar.Validator;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
// ReSharper disable PossibleNullReferenceException

namespace PhotographyAutomation.App.Forms.Admin
{
    public partial class FrmAddEditPrintServices : Form
    {
        #region Variables

        private int _selectedPrintSizeId;
        private int _selectedPrintServiceId;

        #endregion

        #region Form Events
        public FrmAddEditPrintServices()
        {
            InitializeComponent();
        }

        private void FrmAddEditPrintServices_Load(object sender, EventArgs e)
        {
            LoadPrintSizes();
            LoadPrintServices();
            LoadTable();

            cmbPrintSizes.Focus();
        }

        #endregion Form Events

        #region Buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                //ClearHighLighters();

                SaveOrUpdate();

                bgWorkerLoadTable.RunWorkerAsync();
            }
        }



        #endregion Buttons

        #region Methods
        //private void ClearHighLighters()
        //{
        //    foreach (Control control in Controls)
        //    {
        //        if (control is DevComponents.Editors.DoubleInput ||
        //            control is DevComponents.Editors.IntegerInput)
        //        {
        //            highlighter1.SetHighlightColor(control, eHighlightColor.None);
        //            highlighter1.SetHighlightOnFocus(control, false);
        //        }
        //    }
        //}

        private void SaveOrUpdate()
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

                    if (rbHasPrintService.Checked)
                    {
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
                    }
                    else if (rbHasNotPrintService.Checked)
                    {
                        var itemPrintSizePrintService = db.PrintServices_PrintSizePriceGenericRepository.Get(x =>
                              x.PrintServiceId == _selectedPrintServiceId &&
                              x.PrintSizePriceId == _selectedPrintSizeId).SingleOrDefault();

                        if (itemPrintSizePrintService != null)
                        {
                            db.PrintServices_PrintSizePriceGenericRepository.Delete(itemPrintSizePrintService);
                        }
                    }

                    db.Save();
                }
            }
        }

        private bool CheckInputs()
        {
            if (checkBoxEnablePrintSizeItems.Checked)
            {
                if (doubleInputWidth.IsEmpty)
                {
                    highlighter1.SetHighlightColor(doubleInputWidth, eHighlightColor.Red);
                    highlighter1.SetHighlightOnFocus(doubleInputWidth, true);

                    toolTip1.SetToolTip(
                        doubleInputWidth,
                        "مقداری برای عرض چاپ وارد نشده است.");
                    toolTip1.Show(
                        "مقداری برای عرض چاپ وارد نشده است.",
                        doubleInputWidth, 5000);
                    return false;
                }

                if (doubleInputWidth.Value <= 0)
                {
                    highlighter1.SetHighlightColor(doubleInputWidth, eHighlightColor.Red);
                    highlighter1.SetHighlightOnFocus(doubleInputWidth, true);

                    doubleInputWidth.Focus();
                    toolTip1.SetToolTip(
                        doubleInputWidth,
                        "مقدار وارد شده برای عرض چاپ می بایست بیشتر از 0 باشد.");
                    toolTip1.Show(
                        "مقدار وارد شده برای عرض چاپ می بایست بیشتر از 0 باشد.",
                        doubleInputWidth, 5000);
                    return false;
                }

                if (doubleInputHeight.IsEmpty)
                {
                    highlighter1.SetHighlightColor(doubleInputHeight, eHighlightColor.Red);
                    highlighter1.SetHighlightOnFocus(doubleInputHeight, true);

                    doubleInputHeight.Focus();
                    toolTip1.SetToolTip(
                        doubleInputWidth,
                        "مقداری برای طول چاپ وارد نشده است.");
                    toolTip1.Show(
                        "مقداری برای طول چاپ وارد نشده است.",
                        doubleInputHeight, 5000);
                    return false;
                }

                if (doubleInputHeight.Value <= 0)
                {
                    highlighter1.SetHighlightColor(doubleInputHeight, eHighlightColor.Red);
                    highlighter1.SetHighlightOnFocus(doubleInputHeight, true);

                    doubleInputHeight.Focus();
                    toolTip1.SetToolTip(
                        doubleInputHeight,
                        "مقدار وارد شده برای طول چاپ می بایست بیشتر از 0 باشد.");
                    toolTip1.Show(
                        "مقدار وارد شده برای طول چاپ می بایست بیشتر از 0 باشد.",
                        doubleInputHeight, 5000);
                    return false;
                }

                if (integerInputOriginalPrintPrice.IsEmpty)
                {
                    highlighter1.SetHighlightColor(integerInputOriginalPrintPrice, eHighlightColor.Red);
                    highlighter1.SetHighlightOnFocus(integerInputOriginalPrintPrice, true);

                    integerInputOriginalPrintPrice.Focus();
                    toolTip1.SetToolTip(
                        integerInputOriginalPrintPrice,
                        "مقداری برای قیمت اصل چاپ وارد نشده است.");
                    toolTip1.Show(
                        "مقداری برای قیمت اصل چاپ وارد نشده است.",
                        integerInputOriginalPrintPrice, 5000);
                    return false;
                }

                if (integerInputSecondPrintPrice.IsEmpty)
                {
                    highlighter1.SetHighlightColor(integerInputSecondPrintPrice, eHighlightColor.Red);
                    highlighter1.SetHighlightOnFocus(integerInputSecondPrintPrice, true);

                    integerInputSecondPrintPrice.Focus();
                    toolTip1.SetToolTip(
                        integerInputSecondPrintPrice,
                        "مقداری برای قیمت اضافه چاپ وارد نشده است.");
                    toolTip1.Show(
                        "مقداری برای قیمت اضافه چاپ وارد نشده است.",
                        integerInputSecondPrintPrice, 5000);
                    return false;
                }

                if (rbHasPrintService.Checked)
                {
                    if (integerInputPrintServicePrice.IsEmpty)
                    {
                        highlighter1.SetHighlightColor(integerInputPrintServicePrice, eHighlightColor.Red);
                        highlighter1.SetHighlightOnFocus(integerInputPrintServicePrice, true);

                        integerInputPrintServicePrice.Focus();
                        toolTip1.SetToolTip(
                            integerInputPrintServicePrice,
                            "مقداری برای قیمت سرویس چاپ انتخابی وارد نشده است.");
                        toolTip1.Show(
                            "مقداری برای قیمت سرویس چاپ انتخابی وارد نشده است.",
                            integerInputPrintServicePrice, 5000);
                        return false;
                    }
                }

                if (CheckPrintSize(doubleInputWidth.Value, doubleInputHeight.Value) == false)
                {
                    highlighter1.SetHighlightColor(doubleInputWidth, eHighlightColor.Red);
                    highlighter1.SetHighlightOnFocus(doubleInputWidth, true);

                    doubleInputWidth.Focus();
                    toolTip1.SetToolTip(
                        doubleInputWidth,
                        "این مقدار اندازه چاپ قبلا وارد شده است.");
                    toolTip1.Show(
                        "این مقدار اندازه چاپ قبلا وارد شده است.",
                        doubleInputWidth, 5000);
                    return false;
                }
            }
            return true;
        }

        private static bool CheckPrintSize(double width, double height)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var printSizeList = db.PrintSizePricesGenericRepository.Get(
                        x => (x.SizeWidth == (decimal)width && x.SizeHeight == (decimal)height) ||
                                 (x.SizeWidth == (decimal)height && x.SizeHeight == (decimal)width))
                        .ToList();

                    if (printSizeList.Any())
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
                return false;
            }
        }

        private void LoadTable()
        {
            bgWorkerLoadTable.RunWorkerAsync();
            circularProgressLoadDataGridView.IsRunning = bgWorkerLoadTable.IsBusy;
        }

        private void LoadPrintServices()
        {
            bgWorkerLoadPrintServices.RunWorkerAsync();

            circularProgressLoadPrintServices.IsRunning = bgWorkerLoadPrintServices.IsBusy;
            cmbPrintServiceType.Enabled = !bgWorkerLoadPrintServices.IsBusy;
            panelHasPrintService.Enabled = !bgWorkerLoadPrintServices.IsBusy;

            rbHasNotPrintService.Checked = bgWorkerLoadPrintServices.IsBusy;
        }

        private void LoadPrintSizes()
        {
            bgWorkerLoadPrintSizes.RunWorkerAsync();

            circularProgressLoadPrintSizes.IsRunning = bgWorkerLoadPrintSizes.IsBusy;
            cmbPrintSizes.Enabled = !bgWorkerLoadPrintSizes.IsBusy;
            checkBoxEnablePrintSizeItems.Enabled = !bgWorkerLoadPrintSizes.IsBusy;
            doubleInputWidth.Enabled = doubleInputHeight.Enabled = !bgWorkerLoadPrintSizes.IsBusy;
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

        private void PopulateDatagridView(
            IReadOnlyList<PrintServiceType_PrintSizePriceViewModel> printSizeServiceList)
        {
            if (printSizeServiceList.Any())
            {
                dgvPrintServices.Rows.Clear();
                dgvPrintServices.RowCount = printSizeServiceList.Count;
                dgvPrintServices.AutoGenerateColumns = false;

                dgvPrintServices.Columns["clmSizeName"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Columns["clmOriginalPrintPrice"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Columns["clmSecondPrintPrice"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Columns["clmPrice"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvPrintServices.Columns["clmCode"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                for (int i = 0; i < printSizeServiceList.Count; i++)
                {
                    dgvPrintServices.Rows[i].Cells["clmId"].Value =
                        printSizeServiceList[i].Id;

                    dgvPrintServices.Rows[i].Cells["clmPrintServiceId"].Value =
                        printSizeServiceList[i].PrintServiceId;

                    dgvPrintServices.Rows[i].Cells["clmPrintSizePriceId"].Value =
                        printSizeServiceList[i].PrintSizePriceId;

                    dgvPrintServices.Rows[i].Cells["clmSizeName"].Value =
                        printSizeServiceList[i].PrintSizeName;

                    dgvPrintServices.Rows[i].Cells["clmOriginalPrintPrice"].Value =
                        printSizeServiceList[i].OriginalPrintPrice.ToString("N0");

                    dgvPrintServices.Rows[i].Cells["clmSecondPrintPrice"].Value =
                        printSizeServiceList[i].SecondPrintPrice.ToString("N0");

                    dgvPrintServices.Rows[i].Cells["clmCode"].Value = printSizeServiceList[i].Code ?? "-";

                    dgvPrintServices.Rows[i].Cells["clmPrintServiceName"].Value =
                        printSizeServiceList[i].PrintServiceName ?? "-";

                    dgvPrintServices.Rows[i].Cells["clmPrice"].Value =
                        printSizeServiceList[i].Price.HasValue ?
                            printSizeServiceList[i].Price?.ToString("N0") : "-";

                    dgvPrintServices.Rows[i].Cells["clmDescription"].Value = printSizeServiceList[i].Description;
                }
            }
        }


        #endregion Methods

        #region BackgroundWorkers

        private void bgWorkerLoadTable_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    //var result = db.PrintServices_PrintSizePriceGenericRepository.Get()
                    //    .Select(x => new PrintServiceType_PrintSizePriceViewModel
                    //    {
                    //        Id = x.Id,
                    //        PrintSizePriceId = x.PrintSizePriceId,
                    //        PrintServiceId = x.PrintServiceId,
                    //        PrintSizeWidth = x.TblPrintSizePrices.SizeWidth,
                    //        PrintSizeHeight = x.TblPrintSizePrices.SizeHeight,
                    //        PrintSizeName = x.TblPrintSizePrices.SizeWidth.ToString("####.#") +
                    //                        "x" +
                    //                        x.TblPrintSizePrices.SizeHeight.ToString("####.#"),
                    //        Price = x.Price,
                    //        Code = x.Code,
                    //        Description = x.Description,
                    //        OriginalPrintPrice = x.TblPrintSizePrices.OriginalPrintPrice,
                    //        SecondPrintPrice = x.TblPrintSizePrices.SecondPrintPrice,
                    //        PrintServiceName = x.TblPrintServices.PrintServiceName
                    //    })
                    //    .OrderBy(x => x.PrintSizeWidth)
                    //    .ThenBy(x => x.PrintSizeHeight)
                    //    .ToList();
                    var result = db.PrintSizePriceServiceRepository.GetAllPrintSizePriceServices();
                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }
        private void bgWorkerLoadTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                IReadOnlyList<PrintServiceType_PrintSizePriceViewModel> printSizeServiceList =
                    e.Result as List<PrintServiceType_PrintSizePriceViewModel>;

                if (printSizeServiceList != null)
                {
                    printSizeServiceList = printSizeServiceList.OrderBy(x => x.PrintSizeWidth)
                        .ThenBy(x => x.PrintSizeHeight).ToList();

                    PopulateDatagridView(printSizeServiceList);
                }

                circularProgressLoadDataGridView.IsRunning = bgWorkerLoadTable.IsBusy;
                if (bgWorkerLoadTable.IsBusy == false)
                    circularProgressLoadDataGridView.Hide();
            }
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
                            SizeName = x.SizeWidth.ToString("####.#") +
                                       " x " +
                                       x.SizeHeight.ToString("####.#"),
                            SizeWidth = x.SizeWidth,
                            SizeHeight = x.SizeHeight
                        })
                        .OrderBy(x => x.SizeWidth)
                        .ThenBy(x => x.SizeHeight)
                        .ToList();
                    int maxId = result.Last().Id;
                    var psItem = new PrintSizePriceViewModel
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
            circularProgressLoadPrintSizes.IsRunning = bgWorkerLoadPrintSizes.IsBusy;
            checkBoxEnablePrintSizeItems.Enabled = !bgWorkerLoadPrintSizes.IsBusy;
            if (bgWorkerLoadPrintSizes.IsBusy == false)
                circularProgressLoadPrintSizes.Hide();
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

            circularProgressLoadPrintServices.IsRunning = bgWorkerLoadPrintServices.IsBusy;
            if (bgWorkerLoadPrintServices.IsBusy == false)
                circularProgressLoadPrintServices.Hide();

            rbHasNotPrintService_CheckedChanged(null, null);
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
                        var price = result[0].Price;
                        if (price != null) integerInputPrintServicePrice.Value = price.Value;
                    }
                    else
                    {
                        txtPrintServiceCode.ResetText();
                        integerInputPrintServicePrice.ResetText();
                    }
                }
            }
        }

        #endregion BackgroundWorkers

        #region ComboBoxes

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
                    doubleInputWidth.ResetText();
                    doubleInputHeight.ResetText();
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

        #endregion ComboBoxes

        #region Check Boxes

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

        #endregion Check Boxes

        #region RadioButtons

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

        #endregion RadioButtons
    }
}