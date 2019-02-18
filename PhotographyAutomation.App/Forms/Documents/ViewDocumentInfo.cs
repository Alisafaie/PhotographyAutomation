using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Documents
{
    public partial class ViewDocumentInfo : Form
    {
        public ViewDocumentInfo()
        {
            InitializeComponent();
        }

        private void btnGetDocumentInfo_Click(object sender, EventArgs e)
        {
            //using (var db = new UnitOfWork())
            //{
            //    //Guid guid=new Guid("1E305159-242A-E911-AACE-742F68C6E6E6");

            //    var guid = Guid.Parse("1E305159-242A-E911-AACE-742F68C6E6E6");

            //    var document = db.DocumentRepository.GetDocumentByGuid(guid);
            //}
        }

        private void btnCheckYear_Click(object sender, EventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                PersianCalendar pc = new PersianCalendar();
                int year = pc.GetYear(DateTime.Now);

                var result = db.DocumentRepository.CheckPhotoYearFolderIsCreatedReturnsPath(year);
                if (result != null)
                {
                    MessageBox.Show(@"فولدر سال جاری در سیستم وجود دارد.");
                }
                else
                {
                    DialogResult dr =
                        RtlMessageBox.Show("فولدر سال جاری وجود ندارد. آیا می خواهید آن را ایجاد کنید؟",
                        "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dr == DialogResult.Yes)
                    {
                        var resultCreateYearFolder = db.DocumentRepository.CreateYearFolderOfPhotos(year);
                        if (resultCreateYearFolder != null)
                        {
                            RtlMessageBox.Show("فولدر سال جاری ایجاد شد.");
                        }
                    }
                }
            }
        }

        private void btnCheckMonth_Click(object sender, EventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                PersianCalendar pc = new PersianCalendar();
                int month = pc.GetMonth(DateTime.Now);
                int year = pc.GetYear(DateTime.Now);

                var result = db.DocumentRepository.CheckPhotoMonthFolderIsCreatedReturnsPath(month);
                if (result != null)
                {
                    MessageBox.Show(@"فولدر ماه عکس برداری در سیستم وجود دارد.");
                }
                else
                {
                    DialogResult dr =
                        RtlMessageBox.Show("فولدر ماه عکس برداری وجود ندارد. آیا می خواهید آن را ایجاد کنید؟",
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dr == DialogResult.Yes)
                    {
                        var resultCreateYearFolder = db.DocumentRepository.CreateMonthFolderOfPhotos(month, year);
                        if (resultCreateYearFolder != null)
                        {
                            RtlMessageBox.Show("فولدر ماه عکس برداری ایجاد شد.");
                        }
                    }
                }
            }
        }

        private void btnCheckFinancialFolder_Click(object sender, EventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                var result =
                    db.DocumentRepository.CheckCustomerFinancialFolderIsCreatedReturnsPath((int)txtFinancialNumber.Value);
                if (result != null)
                {
                    MessageBox.Show(@"فولدر فاکتور مشتری در سیستم وجود دارد.");
                }
                else
                {
                    DialogResult dr =
                        RtlMessageBox.Show("فولدر فاکتور مشتری وجود ندارد. آیا می خواهید آن را ایجاد کنید؟",
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dr == DialogResult.Yes)
                    {
                        PersianCalendar pc = new PersianCalendar();
                        int month = pc.GetMonth(DateTime.Now);
                        var resultCreateYearFolder =
                            db.DocumentRepository.CreateCustomerFinancialFolder((int)txtFinancialNumber.Value, month);
                        if (resultCreateYearFolder != null)
                        {
                            RtlMessageBox.Show("فولدر فاکتور مشتری ایجاد شد.");
                        }
                    }
                }
            }
        }
    }
}
