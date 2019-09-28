using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Linq;
using System.Windows.Forms;
using Exception = System.Exception;

// ReSharper disable BadControlBracesIndent

namespace PhotographyAutomation.App.Forms.PrintSizeAndServices
{
    public partial class FrmAddEditPrintSize : Form
    {
        #region Variables

        public bool IsNewPrintSize = false;
        public int PrintSizeId = 0;
        public bool HasSizePriceBefore = false;

        #endregion


        #region Form Events

        public FrmAddEditPrintSize()
        {
            InitializeComponent();
        }

        private void FrmAddEditPrintSize_Load(object sender, EventArgs e)
        {
            if (IsNewPrintSize) return;

            try
            {
                using (var db = new UnitOfWork())
                {
                RetryGetPrintSizeInfo:
                    var printSizeInDb = db.PrintSizesGenericRepository.GetById(PrintSizeId);

                    if (printSizeInDb != null) GetPrintSizeInfoAndPlaceThem(printSizeInDb);
                    else
                    {
                        var dr = MessageBox.Show(
                            @"متاسفانه اطلاعات اندازه چاپ فایل دریافت نمی باشد." + Environment.NewLine +
                            @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                            @"خطا در دریافت اطلاعات اندازه چاپ",
                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        if (dr == DialogResult.Retry)
                        {
                            goto RetryGetPrintSizeInfo;
                        }

                        Close();
                    }

                    var printSizePriceInDb = db.PrintSizePriceGenericRepository
                                                .Get(x => x.PrintSizeId == PrintSizeId)
                                                .FirstOrDefault();

                    if (printSizeInDb != null && printSizePriceInDb == null)
                    {
                        var dr = MessageBox.Show(
                            @"ظاهرا اطلاعات قیمتی برای این اندازه چاپ ثبت نشده است. " +
                            @"آیا مایل به ثبت قیمت برای این اندازه چاپ هستید؟",
                            @"ثبت قیمت برای اندازه چاپ",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        if (dr != DialogResult.Yes) Close();

                        //GetPrintSizeInfoAndPlaceThem(printSizeInDb);
                    }
                    else if (printSizeInDb != null && printSizeInDb.TblPrintSizePrices.Count != 0)
                    {
                        if (printSizePriceInDb.FirstPrintPrice != null)
                            iiFirstPrintPrice.Value = printSizePriceInDb.FirstPrintPrice.Value;
                        if (printSizePriceInDb.RePrintPrice != null)
                            iiRePrintPrice.Value = printSizePriceInDb.RePrintPrice.Value;

                        if (chkHasItalianAlbum.Checked)
                        {
                            if (printSizePriceInDb.ItalianAlbumPagePrice != null)
                                iiItalianAlbumPagePrice.Value = printSizePriceInDb.ItalianAlbumPagePrice.Value;
                            if (printSizePriceInDb.ItalianAlbumBoundingPrice != null)
                                iiItalianAlbumBoundingPrice.Value =
                                    printSizePriceInDb.ItalianAlbumBoundingPrice.Value;
                        }
                        else
                        {
                            iiItalianAlbumPagePrice.ResetText();
                            iiItalianAlbumBoundingPrice.ResetText();
                        }

                        if (chkHasLitPrint.Checked)
                        {
                            if (printSizePriceInDb.LitPrintPrice != null)
                                iiLitPrintFirstPrint.Value = printSizePriceInDb.LitPrintPrice.Value;
                            if (printSizePriceInDb.LitPrintRePrintPrice != null)
                                iiLitPrintRePrint.Value = printSizePriceInDb.LitPrintRePrintPrice.Value;
                        }
                        else
                        {
                            iiLitPrintFirstPrint.ResetText();
                            iiLitPrintRePrint.ResetText();
                        }

                        if (chkHasMedialPhoto.Checked)
                        {
                            if (printSizePriceInDb.MedicalPrice != null)
                                iiMedicalFirstPrint.Value = printSizePriceInDb.MedicalPrice.Value;
                            if (printSizePriceInDb.MedicalRePrintPrice != null)
                                iiMedicalRePrint.Value = printSizePriceInDb.MedicalRePrintPrice.Value;
                        }
                        else
                        {
                            iiMedicalFirstPrint.ResetText();
                            iiMedicalRePrint.ResetText();
                        }

                        if (chkHasScanAndProcess.Checked)
                        {
                            if (printSizePriceInDb.ScanAndPrintPrice != null)
                                iiScanAndPrint.Value = printSizePriceInDb.ScanAndPrintPrice.Value;
                            if (printSizePriceInDb.ScanAndProcessingPrice != null)
                                iiScanAndProcess.Value = printSizePriceInDb.ScanAndProcessingPrice.Value;
                        }
                        else
                        {
                            iiScanAndPrint.ResetText();
                            iiScanAndProcess.ResetText();
                        }
                    }
                    else
                    {
                        var dr = MessageBox.Show(
                            @"متاسفانه اطلاعات اندازه چاپ فایل دریافت نمی باشد." + Environment.NewLine +
                            @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                            @"خطا در دریافت اطلاعات اندازه چاپ",
                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        if (dr == DialogResult.Retry)
                        {
                            goto RetryGetPrintSizeInfo;
                        }

                        Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"خطا در دریافت اطلاعات اندازه چاپ از سیستم", exception.HResult.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);

                MessageBox.Show(exception.Message, exception.HResult.ToString());
                Close();
            }
        }

        #endregion


        #region Buttons

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        StartOver:
            if (IsNewPrintSize)
            {
                var newPrintSizesViewModel = new PrintSizesViewModel
                {
                    Width = doubleInputWidth.Value,
                    Height = doubleInputHeight.Value,
                    IsActive = chkIsActive.Checked,
                    IsDeleted = chkIsDeleted.Checked,
                    FirstPrintPrice = iiFirstPrintPrice.Value,
                    RePrintPrice = iiRePrintPrice.Value,
                    HasScanAndProcessing = chkHasScanAndProcess.Checked,
                    HasLitPrint = chkHasLitPrint.Checked,
                    HasItalianAlbum = chkHasItalianAlbum.Checked,
                    HasMedicalPhoto = chkHasMedialPhoto.Checked,
                    MinimumOrder = iiMinimumOrder.Value,
                    Descriptions = txtDescription.Text.Trim()
                };

                if (chkHasScanAndProcess.Checked)
                {
                    newPrintSizesViewModel.ScanAndPrintPrice = iiScanAndPrint.Value;
                    newPrintSizesViewModel.ScanAndProcessingPrice = iiScanAndProcess.Value;
                }

                if (chkHasLitPrint.Checked)
                {
                    newPrintSizesViewModel.LitPrintPrice = iiLitPrintFirstPrint.Value;
                    newPrintSizesViewModel.LitPrintRePrintPrice = iiLitPrintRePrint.Value;
                }

                if (chkHasMedialPhoto.Checked)
                {
                    newPrintSizesViewModel.MedicalPrice = iiMedicalFirstPrint.Value;
                    newPrintSizesViewModel.MedicalRePrintPrice = iiMedicalRePrint.Value;
                }

                if (chkHasItalianAlbum.Checked)
                {
                    newPrintSizesViewModel.ItalianAlbumPagePrice = iiItalianAlbumPagePrice.Value;
                    newPrintSizesViewModel.ItalianAlbumBoundingPrice = iiItalianAlbumBoundingPrice.Value;
                }

                var newPrintSize = new TblPrintSizes
                {
                    Width = newPrintSizesViewModel.Width,
                    Height = newPrintSizesViewModel.Height,
                    HasItalianAlbum = newPrintSizesViewModel.HasItalianAlbum,
                    HasLitPrint = newPrintSizesViewModel.HasLitPrint,
                    HasMedicalPhoto = newPrintSizesViewModel.HasMedicalPhoto,
                    HasScanAndProcessing = newPrintSizesViewModel.HasScanAndProcessing,
                    IsActive = newPrintSizesViewModel.IsActive,
                    IsDeleted = newPrintSizesViewModel.IsDeleted,
                    MinimumOrder = (byte)newPrintSizesViewModel.MinimumOrder,
                    Name = newPrintSizesViewModel.Width.ToString("##.#") + " x " +
                           newPrintSizesViewModel.Height.ToString("##.#"),
                    Descriptions = newPrintSizesViewModel.Descriptions
                };

            RetrySaveSizePrint:
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        int heightTolerance = 0;
                        int widthTolerance = 0;
                        var check2 = db.PrintSizesGenericRepository
                            .Get(x => Math.Abs(x.Width - newPrintSize.Width) < widthTolerance && Math.Abs(x.Height - newPrintSize.Height) < heightTolerance).ToList();
                        var check = db.PrintSizesGenericRepository
                            .Get(x => x.Width == newPrintSize.Width && x.Height == newPrintSize.Height).ToList();

                        if (check.Any())
                        {
                            var dr = MessageBox.Show(
                                @"این اندازه چاپ قبلا در سیستم ثبت شده است." +
                                Environment.NewLine +
                                @"آیا می خواهید آن را به روز رسانی کنید؟", "",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                            if (dr == DialogResult.Yes)
                            {
                                PrintSizeId = check.First().Id;
                                IsNewPrintSize = false;
                                goto StartOver;
                            }
                            return;
                        }

                        db.PrintSizesGenericRepository.Insert(newPrintSize);
                        var resultSaveSize = db.Save();
                        if (resultSaveSize > 0 && newPrintSize.Id > 0)
                        {
                            var newSizePrice = new TblPrintSizePrices
                            {
                                PrintSizeId = newPrintSize.Id,
                                FirstPrintPrice = newPrintSizesViewModel.FirstPrintPrice,
                                RePrintPrice = newPrintSizesViewModel.RePrintPrice
                            };

                            if (newPrintSizesViewModel.HasScanAndProcessing)
                            {
                                newSizePrice.ScanAndPrintPrice = newPrintSizesViewModel.ScanAndPrintPrice;
                                newSizePrice.ScanAndProcessingPrice = newPrintSizesViewModel.ScanAndProcessingPrice;
                            }

                            if (newPrintSizesViewModel.HasItalianAlbum)
                            {
                                newSizePrice.ItalianAlbumPagePrice = newPrintSizesViewModel.ItalianAlbumPagePrice;
                                newSizePrice.ItalianAlbumBoundingPrice = newPrintSizesViewModel.ItalianAlbumBoundingPrice;
                            }

                            if (newPrintSizesViewModel.HasLitPrint)
                            {
                                newSizePrice.LitPrintPrice = newPrintSizesViewModel.LitPrintPrice;
                                newSizePrice.LitPrintRePrintPrice = newPrintSizesViewModel.LitPrintRePrintPrice;
                            }

                            if (newPrintSizesViewModel.HasMedicalPhoto)
                            {
                                newSizePrice.MedicalPrice = newPrintSizesViewModel.MedicalPrice;
                                newSizePrice.MedicalRePrintPrice = newPrintSizesViewModel.MedicalRePrintPrice;
                            }

                            db.PrintSizePriceGenericRepository.Insert(newSizePrice);

                        RetrySaveSizePrice:
                            var resultSaveSizePrice = db.Save();
                            if (resultSaveSizePrice > 0 && newSizePrice.Id > 0)
                            {
                                MessageBox.Show(
                                    @"اندازه چاپ جدید همراه با اطلاعات قیمت داده شده با موفقیت در سیستم ثبت گردید.",
                                    @"ثبت اطلاعات در سیستم",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                var dr = MessageBox.Show(
                                    @"سیستم قادر به ثبت اطلاعات قیمت عکس نمی باشد." + Environment.NewLine +
                                    @"لطفا دوباره تلاش کنید و در صورت تکرار مشکل، با مدیر سیستم تماس بگیرید.",
                                    @"خطا در ثبت اطلاعات قیمت اندازه چاپ ",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                                if (dr == DialogResult.Retry)
                                    goto RetrySaveSizePrice;
                            }
                        }
                        else
                        {
                            var dr = MessageBox.Show(
                                @"سیستم قادر به ثبت اطلاعات اندازه چاپ نمی باشد." + Environment.NewLine +
                                @"لطفا دوباره تلاش کنید و در صورت تکرار مشکل، با مدیر سیستم تماس بگیرید.",
                                @"خطا در ثبت اطلاعات اندازه چاپ",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            if (dr == DialogResult.Retry)
                                goto RetrySaveSizePrint;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"خطا در دریافت اطلاعات اندازه چاپ از سیستم", exception.HResult.ToString(),
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading);

                    MessageBox.Show(exception.Message, exception.HResult.ToString());
                    Close();
                }
            }
            else
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        RetryGetPrintSizeInfo:
                        var printSizeInDb = db.PrintSizesGenericRepository.GetById(PrintSizeId);
                        if (printSizeInDb != null)
                        {
                            printSizeInDb.Width = doubleInputWidth.Value;
                            printSizeInDb.Height = doubleInputHeight.Value;
                            printSizeInDb.Descriptions = txtDescription.Text.Trim();
                            printSizeInDb.HasItalianAlbum = chkHasItalianAlbum.Checked;
                            printSizeInDb.HasLitPrint = chkHasLitPrint.Checked;
                            printSizeInDb.HasMedicalPhoto = chkHasMedialPhoto.Checked;
                            printSizeInDb.HasScanAndProcessing = chkHasScanAndProcess.Checked;
                            printSizeInDb.IsActive = chkIsActive.Checked;
                            printSizeInDb.IsDeleted = chkIsDeleted.Checked;
                            printSizeInDb.MinimumOrder = (byte)iiMinimumOrder.Value;

                            db.PrintSizesGenericRepository.Update(printSizeInDb);

                            var sizePrices = db.PrintSizePriceGenericRepository
                                .Get(x => x.PrintSizeId == PrintSizeId)
                                .FirstOrDefault();
                            HasSizePriceBefore = sizePrices != null;

                            if (sizePrices == null) sizePrices = new TblPrintSizePrices();

                            sizePrices.FirstPrintPrice = iiFirstPrintPrice.Value;
                            sizePrices.RePrintPrice = iiRePrintPrice.Value;


                            if (chkHasItalianAlbum.Checked)
                            {
                                sizePrices.ItalianAlbumPagePrice = iiItalianAlbumPagePrice.Value;
                                sizePrices.ItalianAlbumBoundingPrice = iiItalianAlbumBoundingPrice.Value;
                            }
                            else
                            {
                                sizePrices.ItalianAlbumPagePrice = null;
                                sizePrices.ItalianAlbumBoundingPrice = null;
                            }

                            if (chkHasLitPrint.Checked)
                            {
                                sizePrices.LitPrintPrice = iiLitPrintFirstPrint.Value;
                                sizePrices.LitPrintRePrintPrice = iiLitPrintRePrint.Value;
                            }
                            else
                            {
                                sizePrices.LitPrintPrice = null;
                                sizePrices.LitPrintRePrintPrice = null;
                            }

                            if (chkHasMedialPhoto.Checked)
                            {
                                sizePrices.MedicalPrice = iiMedicalFirstPrint.Value;
                                sizePrices.MedicalRePrintPrice = iiMedicalRePrint.Value;
                            }
                            else
                            {
                                sizePrices.MedicalPrice = null;
                                sizePrices.MedicalRePrintPrice = null;
                            }

                            if (chkHasScanAndProcess.Checked)
                            {
                                sizePrices.ScanAndPrintPrice = iiScanAndPrint.Value;
                                sizePrices.ScanAndProcessingPrice = iiScanAndProcess.Value;
                            }
                            else
                            {
                                sizePrices.ScanAndPrintPrice = null;
                                sizePrices.ScanAndProcessingPrice = null;
                            }

                            if (HasSizePriceBefore == false)
                            {
                                sizePrices.PrintSizeId = PrintSizeId;
                                db.PrintSizePriceGenericRepository.Insert(sizePrices);
                            }
                            else
                            {
                                sizePrices.PrintSizeId = PrintSizeId;
                                db.PrintSizePriceGenericRepository.Update(sizePrices);
                            }


                        RetryUpdatePrintSizeAndPrice:
                            var resultInsertOrUpdatePrintSizePrice = db.Save();

                            if (resultInsertOrUpdatePrintSizePrice > 0)
                            {
                                MessageBox.Show(
                                    @"اطلاعات اندازه چاپ و قیمت آن با موفقیت در سیستم به روز گردید.",
                                    @"ثبت اطلاعات در سیستم",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                var dr = MessageBox.Show(
                                    @"متاسفانه اطلاعات اندازه عکس و قیمت با موفقیت در سیستم ثبت نگردید." +
                                    Environment.NewLine +
                                    @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                                    @"خطا در به روز رسانی اطلاعات ",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading);
                                if (dr == DialogResult.Retry)
                                    goto RetryUpdatePrintSizeAndPrice;
                            }
                        }
                        else
                        {
                            var dr = MessageBox.Show(
                                @"متاسفانه اطلاعات اندازه چاپ از سیستم قابل دریافت نمی باشد. " +
                                Environment.NewLine +
                                @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                                @"خطا در دریافت اطلاعات اندازه چاپ",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                            if (dr == DialogResult.Retry)
                            {
                                goto RetryGetPrintSizeInfo;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"خطا در دریافت اطلاعات اندازه چاپ از سیستم", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk,
                                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    MessageBox.Show(exception.Message, exception.HResult.ToString());
                    Close();
                }
            }
        }

        #endregion


        #region CheckBoxes CheckedChanged Events

        private void chkHasScanAndProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasScanAndProcess.Checked)
            {
                iiScanAndPrint.Enabled = true;
                iiScanAndProcess.Enabled = true;
            }
            else
            {
                iiScanAndPrint.Enabled = false;
                iiScanAndProcess.Enabled = false;
            }
        }

        private void chkHasLitPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasLitPrint.Checked)
            {
                iiLitPrintFirstPrint.Enabled = true;
                iiLitPrintRePrint.Enabled = true;
            }
            else
            {
                iiLitPrintFirstPrint.Enabled = false;
                iiLitPrintRePrint.Enabled = false;
            }
        }

        private void chkHasMedialPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasMedialPhoto.Checked)
            {
                iiMedicalFirstPrint.Enabled = true;
                iiMedicalRePrint.Enabled = true;
            }
            else
            {
                iiMedicalFirstPrint.Enabled = false;
                iiMedicalRePrint.Enabled = false;
            }
        }

        private void chkHasItalianAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasItalianAlbum.Checked)
            {
                iiItalianAlbumPagePrice.Enabled = true;
                iiItalianAlbumBoundingPrice.Enabled = true;
            }
            else
            {
                iiItalianAlbumPagePrice.Enabled = false;
                iiItalianAlbumBoundingPrice.Enabled = false;
            }
        }

        #endregion


        #region Methods

        private void GetPrintSizeInfoAndPlaceThem(TblPrintSizes printSizeInDb)
        {
            doubleInputWidth.Value = printSizeInDb.Width;
            doubleInputHeight.Value = printSizeInDb.Height;
            txtDescription.Text = printSizeInDb.Descriptions;

            chkHasItalianAlbum.Checked = printSizeInDb.HasItalianAlbum;
            chkHasLitPrint.Checked = printSizeInDb.HasLitPrint;
            chkHasMedialPhoto.Checked = printSizeInDb.HasMedicalPhoto;
            chkHasScanAndProcess.Checked = printSizeInDb.HasScanAndProcessing;
            chkIsActive.Checked = printSizeInDb.IsActive;
            chkIsDeleted.Checked = printSizeInDb.IsDeleted;
            iiMinimumOrder.Value = printSizeInDb.MinimumOrder;

            iiScanAndPrint.Enabled = iiScanAndProcess.Enabled = chkHasScanAndProcess.Checked;
            iiLitPrintFirstPrint.Enabled = iiLitPrintRePrint.Enabled = chkHasLitPrint.Checked;
            iiMedicalFirstPrint.Enabled = iiMedicalRePrint.Enabled = chkHasMedialPhoto.Checked;
            iiItalianAlbumPagePrice.Enabled = iiItalianAlbumBoundingPrice.Enabled = chkHasItalianAlbum.Checked;
        }

        #endregion
    }
}
