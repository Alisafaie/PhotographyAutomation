using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
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

        private void btnSendPhotos_Click(object sender, EventArgs e)
        {
            string uploadPath = string.Empty;
            int customerFinancialNumber = int.Parse(txtFinancialNumber.Text);
            if (customerFinancialNumber <= 0)
            {
                RtlMessageBox.Show("مقدار فاکترو مشتری صحیح نمی باشد.", "");
                txtFinancialNumber.Focus();
                return;
            }


            try
            {
                using (var db = new UnitOfWork())
                {
                    PersianCalendar pc = new PersianCalendar();
                    int year = pc.GetYear(DateTime.Now);
                    int month = pc.GetMonth(DateTime.Now);

                    var resultCheckPhotoYearFolder =
                        db.DocumentRepository.CheckPhotoYearFolderIsCreatedReturnsPath(year);
                    if (resultCheckPhotoYearFolder != null)
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


                    var resultCheckPhotoMonthFolder =
                        db.DocumentRepository.CheckPhotoMonthFolderIsCreatedReturnsPath(month);
                    if (resultCheckPhotoMonthFolder != null)
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




                    var resultCheckCustomerFinancialFolder =
                        db.DocumentRepository.CheckCustomerFinancialFolderIsCreatedReturnsPath(
                            (int)txtFinancialNumber.Value);
                    if (resultCheckCustomerFinancialFolder != null)
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
                            var resultCreateYearFolder =
                                db.DocumentRepository.CreateCustomerFinancialFolder((int)txtFinancialNumber.Value,
                                    month);
                            if (resultCreateYearFolder != null)
                            {
                                RtlMessageBox.Show("فولدر فاکتور مشتری ایجاد شد.");
                                uploadPath = resultCreateYearFolder;
                            }
                        }
                    }

                    string parentPathName = txtFinancialNumber.Text;

                    var list = db.DocumentRepository.CreateFileTableFile("1.jpg", parentPathName, 4);

                    MessageBox.Show("name: " + list.name + Environment.NewLine + Environment.NewLine +
                                    "stream_id: " + list.streamId + Environment.NewLine + Environment.NewLine +
                                    "path_name: " + list.path_name + Environment.NewLine + Environment.NewLine +
                                    "parent_locator: " + list.parent_locator + Environment.NewLine +
                                    Environment.NewLine +
                                    "path_locator_str: " + list.path_locator_str + Environment.NewLine +
                                    Environment.NewLine);



                }

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
            }

        }

        private void btnBrowsePictureFolder_Click(object sender, EventArgs e)
        {
            if (openFileDialogBrowsePictures.ShowDialog()==DialogResult.OK)
            {
                //نمایش لیست فایل ها در لیست باکس
                //تبدیل کردن محتوای فایل به باینری
                //ارسال به سرو
                //تایید ثبت در سرو
                //ثبت مشخصات فایل ثبت شده در جدول مخصوص

            }
        }
    }
}
