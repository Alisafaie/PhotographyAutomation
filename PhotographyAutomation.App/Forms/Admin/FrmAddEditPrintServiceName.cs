using DevComponents.DotNetBar.Controls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Admin
{
    public partial class FrmAddEditPrintServiceName : Form
    {
        #region Variables

        public bool IsNewPrintSize = false;
        public int PrintServiceId = 0;

        private readonly BackgroundWorker _bgWorkerGetPrintServiceInfo = new BackgroundWorker
        {
            WorkerSupportsCancellation = false,
            WorkerReportsProgress = false
        };

        #endregion


        #region Form Events

        public FrmAddEditPrintServiceName()
        {
            InitializeComponent();

            _bgWorkerGetPrintServiceInfo.DoWork += BgWorkerGetPrintServiceInfo_DoWork;
            _bgWorkerGetPrintServiceInfo.RunWorkerCompleted += BgWorkerGetPrintServiceInfo_RunWorkerCompleted;
        }
        private void FrmAddEditPrintServiceName_Load(object sender, EventArgs e)
        {
            if (IsNewPrintSize == false && PrintServiceId > 0)
            {
                try
                {
                    GetPrintServiceInfo();
                }
                catch (Exception exception)
                {
                    WriteDebugInfo(exception);
                }
            }
        }
        #endregion


        #region GetPrintServiceInfo

        void GetPrintServiceInfo()
        {
            try
            {
                _bgWorkerGetPrintServiceInfo.RunWorkerAsync(PrintServiceId);
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }

        }
        private void BgWorkerGetPrintServiceInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null && e.Argument is int printServiceId)
            {
                try
                {
                    using (var db = new UnitOfWork())
                    {
                        TblPrintServices result = db.PrintServicesGenericRepository.GetById(printServiceId);
                        e.Result = result;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
        private void BgWorkerGetPrintServiceInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is TblPrintServices printServiceInDb)
            {
                txtPrintServiceName.Text = printServiceInDb.PrintServiceName;
                txtPrintServiceCode.Text = printServiceInDb.Code;
                txtPrintServiceDescription.Text = printServiceInDb.PrintServiceDescription;
            }
        }

        #endregion


        #region Button Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInputs() == false)
                return;

            RetrySaveToDb:

            txtPrintServiceName.Text = txtPrintServiceName.Text.Trim();
            txtPrintServiceCode.Text = txtPrintServiceCode.Text.Trim();
            txtPrintServiceDescription.Text = txtPrintServiceDescription.Text.Trim();

            TblPrintServices printService = new TblPrintServices
            {
                PrintServiceName = txtPrintServiceName.Text,
                Code = txtPrintServiceCode.Text,
                PrintServiceDescription = txtPrintServiceDescription.Text
            };

            if (IsNewPrintSize == false && PrintServiceId > 0)
                printService.Id = PrintServiceId;


            try
            {
                using (var db = new UnitOfWork())
                {
                    if (IsNewPrintSize && PrintServiceId == 0)
                        db.PrintServicesGenericRepository.Insert(printService);
                    else
                        db.PrintServicesGenericRepository.Update(printService);

                    var saveResult = db.Save();
                    if (saveResult > 0)
                    {
                        MessageBox.Show(
                            @"اطلاعات نام و مشخصات خدمت چاپ با موفقت ثبت گردید.",
                            @"ثبت اطلاعات با موفقیت در سرور",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        var dr = MessageBox.Show(
                            @"ثبت اطلاعات با موفقت انجام نشد. آیا می خواهید دوباره تلاش کنید؟",
                            @"عدم ثبت اطلاعات",
                            MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
                        if (dr == DialogResult.Retry)
                        {
                            goto RetrySaveToDb;
                        }

                        DialogResult = DialogResult.Cancel;
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                throw;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion


        #region Methods

        private bool CheckInputs()
        {
            if (string.IsNullOrEmpty(txtPrintServiceName.Text.Trim()))
            {
                ShowErrorProvider(errorProvider1, txtPrintServiceName, "نام خدمت چاپ وارد نشده است.");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrintServiceCode.Text.Trim()))
            {
                ShowErrorProvider(errorProvider1, txtPrintServiceCode, "کد خدمت چاپ وارد نشده است.");
                return false;
            }

            try
            {
                using (var db = new UnitOfWork())
                {
                    var checkNameResult = db.PrintServicesGenericRepository
                        .Get(x => x.PrintServiceName == txtPrintServiceName.Text.Trim()).ToList();
                    if (checkNameResult.Any() && checkNameResult.Count > 0)
                    {
                        ShowErrorProvider(errorProvider1, txtPrintServiceName, "این نام قبلا وارد شده است.");
                        return false;
                    }

                    var checkCodeResult = db.PrintServicesGenericRepository
                        .Get(x => x.Code == txtPrintServiceCode.Text.Trim()).ToList();
                    if (checkCodeResult.Any() && checkCodeResult.Count > 0)
                    {
                        ShowErrorProvider(errorProvider1, txtPrintServiceCode, "این نام قبلا وارد شده است.");
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                WriteDebugInfo(exception);
                return false;
            }

            errorProvider1.Clear();
            return true;
        }
        private static void ShowErrorProvider(ErrorProvider errorProvider, Control control, string message)
        {
            errorProvider.Clear();
            errorProvider.SetIconPadding(control, 3
);
            errorProvider.SetError(control, message);
            if (control is TextBoxX textBox)
            {
                textBox.Select(0, textBox.TextLength);
            }
            control.Focus();
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


        #region TextBox Input Events

        private void txtPersian_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void txtEnglish_Leave(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        #endregion

    }
}