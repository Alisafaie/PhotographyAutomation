﻿using FreeControls;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Booking
{
    public partial class FrmShowBookings : Form
    {
        #region Variables

        private int _statusCode = 10;
        public static int CustomerId;
        public int OrderId;

        #endregion

        #region Form Events

        public FrmShowBookings()
        {
            InitializeComponent();

            rbCurrentDay.CheckState = CheckState.Unchecked;
            rbCurrentWeek.CheckState = CheckState.Unchecked;
            rbCurrentmonth.CheckState = CheckState.Unchecked;

            GetBookingStatus();
        }

        private void FrmShowBookings_Load(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;

            btnShowBookings.Enabled = !backgroundWorker.IsBusy;
            btnClearSearch.Enabled = !backgroundWorker.IsBusy;
        }

        #endregion

        #region Controls Events

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            bool searchTodayIsChecked = rbCurrentDay.Checked;
            bool searchCurrentWeekIsChecked = rbCurrentWeek.Checked;
            bool searchCurrentMonthIsChecked = rbCurrentmonth.Checked;
            bool searchSpecialDateIsChecked = chkEnableDatePickerBookingDate.Checked;

            if (searchSpecialDateIsChecked)
            {
                var dtFrom = datePickerBookingDateFrom.Value.GetDateFromPersianDateTimePicker();
                var dtTo = datePickerBookingDateTo.Value.GetDateFromPersianDateTimePicker();

                if (chkSpecialBookings.Checked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowBookings(dtFrom, dtTo, _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowBookings(dtFrom, dtTo, txtCustomerInfo.Text.Trim());
                }
                else
                    ShowBookings(dtFrom, dtTo, txtCustomerInfo.Text.Trim());
            }
            else
            {
                if (searchTodayIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowBookings(DateTime.Now.GetBeggingOfTheDateTime(), DateTime.Now.GetEndOfTheDateTime(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowBookings(DateTime.Now.GetBeggingOfTheDateTime(), DateTime.Now.GetEndOfTheDateTime(), txtCustomerInfo.Text.Trim());
                }
                else if (searchCurrentWeekIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowBookings(DateTime.Now.GetFirstDayOfWeek(), DateTime.Now.GetFridayDate(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowBookings(DateTime.Now.GetFirstDayOfWeek(), DateTime.Now.GetFridayDate(), txtCustomerInfo.Text.Trim());
                }
                else if (searchCurrentMonthIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowBookings(PersianDate.Now.GetFirstDayOfMonth(), PersianDate.Now.GetLastDateOfMonth(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowBookings(PersianDate.Now.GetFirstDayOfMonth(), PersianDate.Now.GetLastDateOfMonth(), txtCustomerInfo.Text.Trim());
                }
                else
                {
                    if (txtCustomerInfo.Text == @"***")
                        ShowBookings(string.Empty);
                    else
                    {
                        if (string.IsNullOrEmpty(txtCustomerInfo.Text.Trim()))
                        {
                            MessageBox.Show(@"اطلاعاتی از مشتری برای جستجو وارد نشده است.", @"خطا در ورود اطلاعات",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        ShowBookings(txtCustomerInfo.Text);
                    }
                }
            }

            if (dgvBookings.Rows.Count > 0)
            {
                menuStrip1.Enabled = true;
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            rbCurrentDay.Checked = false;
            rbCurrentWeek.Checked = false;
            rbCurrentmonth.Checked = false;
            chkEnableDatePickerBookingDate.Checked = false;
            chkSpecialBookings.Checked = false;
            cmbBookinsStatus1.SelectedIndex = 0;
            cmbBookinsStatus1.Enabled = false;
            txtCustomerInfo.ResetText();
        }

        private void chkSpecialBookings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecialBookings.Checked)
            {
                cmbBookinsStatus1.Enabled = true;
                cmbBookinsStatus1.DroppedDown = true;
            }
            else
            {
                cmbBookinsStatus1.Enabled = false;
                cmbBookinsStatus1.DroppedDown = false;
            }
        }

        private void cmbBookinsStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBookinsStatus1.Enabled)
                int.TryParse(cmbBookinsStatus1.SelectedValue.ToString(), out _statusCode);
        }

        private void chkEnableDatePickerBookingDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDatePickerBookingDate.Checked)
            {
                datePickerBookingDateFrom.Enabled = true;
                datePickerBookingDateTo.Enabled = true;
                rbCurrentDay.CheckState = CheckState.Unchecked;
                rbCurrentWeek.CheckState = CheckState.Unchecked;
                rbCurrentmonth.CheckState = CheckState.Unchecked;
                lblToDate.Visible = true;
                datePickerBookingDateTo.Visible = true;
                var pd = datePickerBookingDateFrom.Value;
                pd = pd.AddDays(10);
                datePickerBookingDateTo.Value = pd;
            }
            else
            {
                datePickerBookingDateFrom.Enabled = false;
                datePickerBookingDateTo.Enabled = false;
                rbCurrentDay.CheckState = CheckState.Unchecked;
                rbCurrentWeek.CheckState = CheckState.Unchecked;
                rbCurrentmonth.CheckState = CheckState.Unchecked;
                lblToDate.Visible = false;
                datePickerBookingDateTo.Visible = false;
            }
        }

        private void rbCurrentDay_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbCurrentDay.Checked) return;
            if (chkEnableDatePickerBookingDate.Checked)
                chkEnableDatePickerBookingDate.Checked = false;
        }

        private void rbCurrentWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbCurrentWeek.Checked) return;
            if (chkEnableDatePickerBookingDate.Checked)
                chkEnableDatePickerBookingDate.Checked = false;
        }

        private void rbCurrentmonth_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbCurrentmonth.Checked) return;
            if (chkEnableDatePickerBookingDate.Checked)
                chkEnableDatePickerBookingDate.Checked = false;
        }

        #endregion

        #region TextBox Events

        private void txtCustomerInfo_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void txtCustomerInfo_Leave(object sender, EventArgs e)
        {

            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        #endregion

        #region Top Menu

        private void رزروهای_امروزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbCurrentDay.Checked = true;
            btnShowBookings_Click(null, null);
        }

        private void رزروهای_هفته_جاری_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbCurrentWeek.Checked = true;
            btnShowBookings_Click(null, null);
        }

        private void _رزروهای_ماه_جاریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbCurrentmonth.Checked = true;
            btnShowBookings_Click(null, null);
        }

        private void _رزروهای_تاریخ_خاصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkEnableDatePickerBookingDate.Checked = true;
            chkEnableDatePickerBookingDate_CheckedChanged(null, null);
        }

        private void _رزروهای_ویژهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkSpecialBookings.Checked = true;
            chkSpecialBookings_CheckedChanged(null, null);
        }

        private void لغورزروToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            لغورزروToolStripMenuItem_Click(null, null);
        }

        #endregion

        #region DataGridView Menu
        //پیاده سازی نمایش کانتکست منو روی قسمت هایی که مقدار دارند و انتخاب آن ردیف
        private void dgvBookings_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvBookings.Rows.Count > 0)
                {
                    int currentMouseOverRow = dgvBookings.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow > -1)
                    {
                        dgvBookings.Rows[currentMouseOverRow].Selected = true;
                        //DataGridViewRow row = dgvBookings.Rows[currentMouseOverRow];
                    }
                    else
                    {
                        contextMenuDgvBookings.Visible = false;
                    }
                }
                else
                {
                    contextMenuDgvBookings.Visible = false;
                }
            }
        }

        private void ویرایش_اطلاعات_مشتری_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count != 1) return;
            int customerId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["clmCustomerId"].Value);
            using (var frmAddEditCustomerInfo = new FrmAddEditCustomerInfo())
            {
                frmAddEditCustomerInfo.CustomerId = customerId;
                frmAddEditCustomerInfo.JustSaveCustomerInfo = true;
                frmAddEditCustomerInfo.NewCustomer = true;

                if (frmAddEditCustomerInfo.ShowDialog() == DialogResult.OK)
                {
                    if (dgvBookings.CurrentRow != null)
                    {
                        int rowIndex = dgvBookings.CurrentRow.Index;

                        btnShowBookings_Click(null, null);
                        dgvBookings.Rows[rowIndex].Selected = true;
                    }
                }
            }
        }

        private void ویرایش_اطلاعات_رزرو_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 1)
            {
                int bookingId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["clmId"].Value);
                int customerId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["clmCustomerId"].Value);
                var frmAddEditBooking = new FrmAddEditBooking()
                {
                    BookingId = bookingId,
                    CustomerId = customerId
                };
                if (frmAddEditBooking.ShowDialog() == DialogResult.OK)
                {
                    if (dgvBookings.CurrentRow != null)
                    {
                        int rowIndex = dgvBookings.CurrentRow.Index;

                        btnShowBookings_Click(null, null);
                        dgvBookings.Rows[rowIndex].Selected = true;
                    }
                }
            }
        }

        private void ورودبهآتلیهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 1 &&
                int.TryParse(dgvBookings.SelectedRows[0].Cells["clmId"].Value.ToString(), out var bookingId))
            {
                var dialogResult = MessageBox.Show(
                    @"آیا وضعیت رزرو مشتری به 'ورود به آتلیه' تغییر یابد؟" + Environment.NewLine +
                    @"پس از تغییر وضعیت رزرو شناسه سفارش ایجاد می گردد" + Environment.NewLine +
                    @" و وضعیت آن قابل تغییر نمی باشد.",
                    @"تغییر وضعیت رزرو", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;
                using (var db = new UnitOfWork())
                {
                    var booking = db.BookingGenericRepository.GetById(bookingId);
                    var bookingStatusList = db.BookingStatusGenericRepository.Get().ToList();
                    var orderStatusList = db.OrderStatusGenericRepository.Get().ToList();
                    var bookingStatusToOrderId = 0;
                    var orderStatusId = 0;
                    if (bookingStatusList.Any() && orderStatusList.Any())
                    {
                        #region کدهای وضعیت های رزرو
                        /*
                         * 10	فعال
                           20	غیر فعال
                           30	حذف
                           40	ورود به آتلیه
                           50	در انتظار بیعانه
                           60	لغو مشتری
                         */
                        #endregion
                        bookingStatusToOrderId =
                            bookingStatusList.First(x => x.Code == 40).Id;

                        #region کد وضعیت ورود به آتلیه
                        /*
                         * 10	ورود به آتلیه
                           20	بارگزاری عکس
                           30	انتخاب عکس و سایز
                           40	انتخاب آلبوم و خدمات 
                           50	تعیین اولویت
                           60	در حال پردازش
                           70	بازبینی عکس
                           80	در حال چاپ
                           90	خدمات اضافه
                           100	ساخت آلبوم
                           110	تائید مالی
                           120	تحویل به مشتری
                           130	راکد
                         */
                        #endregion
                        orderStatusId = orderStatusList.First(x => x.Code == 10).Id;
                    }


                    if (booking != null && bookingStatusToOrderId != 0)
                    {
                        booking.StatusId = bookingStatusToOrderId;
                        CustomerId = booking.CustomerId;
                        var order = new TblOrder
                        {
                            CustomerId = booking.CustomerId,
                            BookingId = bookingId,
                            OrderCode = OrderUtilities.GenerateOrderCode(DateTime.Now, booking.CustomerId, bookingId),
                            CreatedDateTime = DateTime.Now,
                            Date = DateTime.Now,
                            Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                            IsActive = true,
                            OrderStatusId = orderStatusId,
                            PhotographyTypeId = booking.PhotographyTypeId
                        };

                        db.BookingGenericRepository.Update(booking);
                        //int resultUpdateBooking = db.Save();

                        db.OrderGenericRepository.Insert(order);
                        //int resultInsertNewOrder = db.Save();


                        if (db.Save() > 0)
                        {
                            OrderId = order.Id;
                            MessageBox.Show(
                                @"وضعیت رزرو مشتری با موفقیت به 'ورود به آتلیه' تغییر پیدا کرد.",
                                @"تغییر وضعیت رزرو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dgvBookings.CurrentRow != null)
                            {
                                int rowIndex = dgvBookings.CurrentRow.Index;

                                btnShowBookings_Click(null, null);
                                dgvBookings.Rows[rowIndex].Selected = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                @"مشکلی در به روز رسانی وضعیت رزرو پیش آمده است. " +
                                @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                                @"خطا در ثبت اطلاعات در سیستم",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            @"اطلاعات رزرو مورد از نظر از بانک اطلاعاتی قابل دریافت نیست. " +
                            @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                            @"خطا در دریافت اطلاعات رزرو از سیستم",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    @"هیچ رزروی برای تبدیل به سفارش انتخاب نشده است.",
                    @"خطا - عدم  انتخاب رزرو برای تبدیل به سفارش",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvBookings.Focus();
            }
        }

        private void لغورزروToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count != 1 ||
                !int.TryParse(dgvBookings.SelectedRows[0].Cells["clmId"].Value.ToString(), out var bookingId))
                return;

            var customerName = dgvBookings.SelectedRows[0].Cells["clmCustomerFullName"].Value.ToString();
            bookingId = int.Parse(dgvBookings.SelectedRows[0].Cells["clmId"].Value.ToString());
            var dr = MessageBox.Show(@"آیا از لغو رزرو مشتری " + customerName + @" اطمینان دارید؟",
                @"لغو رزرو مشتری",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            using (var db = new UnitOfWork())
            {
                var booking = db.BookingGenericRepository.GetById(bookingId);
                var bookingStatusList = db.BookingStatusGenericRepository.Get().ToList();
                if (booking != null)
                {
                    var bookingStatusId =
                        bookingStatusList.First(x => x.Code == 60).Id;
                    booking.StatusId = bookingStatusId;
                    #region کدهای وضعیت های رزرو
                    /*
                             * 10	فعال
                               20	غیر فعال
                               30	حذف
                               40	ورود به آتلیه
                               50	در انتظار بیعانه
                               60	لغو مشتری
                             */
                    #endregion

                    db.BookingGenericRepository.Update(booking);
                    if (db.Save() > 0)
                    {
                        MessageBox.Show(
                            @"رزرو مشتری " + customerName + @" با موفقیت لغو گردید.",
                            @"لغو رزرو مشتری",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dgvBookings.SelectedRows[0] != null)
                        {
                            var rowIndex = dgvBookings.SelectedRows[0].Index;

                            btnShowBookings_Click(null, null);
                            dgvBookings.Rows[rowIndex].Selected = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            @"مشکلی در به روز رسانی وضعیت رزرو پیش آمده است. " +
                            @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                            @"خطا در ثبت اطلاعات در سیستم",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(
                        @"اطلاعات رزرو مورد از نظر از بانک اطلاعاتی قابل دریافت نیست. " +
                        @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                        @"خطا در دریافت اطلاعات رزرو از سیستم",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Methods

        private void GetBookingStatus()
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void ShowBookings(string customerInfo)
        {
            dgvBookings.BackColor = Color.White;

            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingOfCustomer(customerInfo);

                if (bookingsList.Count > 0)
                {
                    PopulateDataGridView(bookingsList);
                }
                else
                {
                    MessageBox.Show(@"برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.", @"",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvBookings.Rows.Clear();
                }
            }
            dgvBookings.BackColor = Color.White;
            dgvBookings.ClearSelection();
        }

        private void ShowBookings(DateTime dtFrom, DateTime dtTo, string customerInfo)
        {
            dgvBookings.BackColor = Color.White;

            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, customerInfo);

                if (bookingsList.Count > 0)
                {
                    PopulateDataGridView(bookingsList);
                }
                else
                {
                    MessageBox.Show(@"برای تاریخ مورد نظر نوبتی ثبت نگردیده است.", @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvBookings.Rows.Clear();
                }
            }
            dgvBookings.BackColor = Color.White;
            dgvBookings.ClearSelection();
        }

        private void ShowBookings(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo)
        {
            //dgvBookings.BackColor = Color.White;

            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, statusCode, customerInfo);

                if (bookingsList.Count > 0)
                {
                    PopulateDataGridView(bookingsList);
                }
                else
                {
                    MessageBox.Show(@"برای تاریخ مورد نظر نوبتی ثبت نگردیده است.", @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvBookings.Rows.Clear();
                }
            }
            //dgvBookings.BackColor = Color.White;
            dgvBookings.ClearSelection();
        }

        private void PopulateDataGridView(IReadOnlyList<BookingHistoryAddEditBookingViewModel> bookingsList)
        {
            dgvBookings.Rows.Clear();
            dgvBookings.RowCount = bookingsList.Count;
            dgvBookings.AutoGenerateColumns = false;

            for (int i = 0; i < bookingsList.Count; i++)
            {
                dgvBookings.Rows[i].Cells["clmId"].Value = bookingsList[i].Id;
                dgvBookings.Rows[i].Cells["clmCustomerId"].Value = bookingsList[i].CustomerId;

                if (bookingsList[i].CustomerGender == 0)
                {
                    dgvBookings.Rows[i].Cells["clmCustomerFullName"].Value =
                        "خانم " + bookingsList[i].CustomerFullName;
                }
                else if (bookingsList[i].CustomerGender == 1)
                {
                    dgvBookings.Rows[i].Cells["clmCustomerFullName"].Value =
                        "آقای " + bookingsList[i].CustomerFullName;
                }
                else
                {
                    dgvBookings.Rows[i].Cells["clmCustomerFullName"].Value =
                        bookingsList[i].CustomerFullName;
                }

                dgvBookings.Rows[i].Cells["clmDate"].Value = bookingsList[i].Date.ToShamsiDate();
                dgvBookings.Rows[i].Cells["clmDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvBookings.Rows[i].Cells["clmTime"].Value = bookingsList[i].Time.Hours.ToString("##") + ":" +
                                                             bookingsList[i].Time.Minutes.ToString("00");

                dgvBookings.Rows[i].Cells["clmTime"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvBookings.Rows[i].Cells["clmPhotographerGender"].Value =
                    bookingsList[i].PhotographerGender;

                switch (bookingsList[i].PhotographerGender)
                {
                    case 0:
                        dgvBookings.Rows[i].Cells["clmPhotographerGenderName"].Value = "خانم";
                        break;
                    case 1:
                        dgvBookings.Rows[i].Cells["clmPhotographerGenderName"].Value = "آقا";
                        break;
                    default:
                        dgvBookings.Rows[i].Cells["clmPhotographerGenderName"].Value = "فرقی ندارد";
                        break;
                }

                dgvBookings.Rows[i].Cells["clmPhotographyTypeId"].Value =
                    bookingsList[i].PhotographyTypeId;
                dgvBookings.Rows[i].Cells["clmPhotographyTypeName"].Value =
                    bookingsList[i].PhotographyTypeName;
                dgvBookings.Rows[i].Cells["clmAtelierTypeId"].Value = bookingsList[i].AtelierTypeId;
                dgvBookings.Rows[i].Cells["clmAtelierTypeName"].Value = bookingsList[i].AtelierTypeName;
                dgvBookings.Rows[i].Cells["clmPersonCount"].Value = bookingsList[i].PersonCount;
                dgvBookings.Rows[i].Cells["clmPaymentIsOK"].Value = bookingsList[i].PaymentIsOk;
                dgvBookings.Rows[i].Cells["clmSubmitter"].Value = bookingsList[i].Submitter;
                dgvBookings.Rows[i].Cells["clmSubmitterName"].Value = bookingsList[i].SubmitterName;
                dgvBookings.Rows[i].Cells["clmStatusId"].Value = bookingsList[i].StatusId;
                dgvBookings.Rows[i].Cells["clmStatusCode"].Value = bookingsList[i].StatusCode;
                dgvBookings.Rows[i].Cells["clmStatusName"].Value = bookingsList[i].StatusName;
                dgvBookings.Rows[i].Cells["clmCreatedDateTime"].Value = bookingsList[i].CreatedDateTime;
                dgvBookings.Rows[i].Cells["clmModifiedDateTime"].Value =
                    bookingsList[i].ModifiedDateTime;
            }
        }
        #endregion

        private void contextMenuStripDgvBookings_Paint(object sender, PaintEventArgs e)
        {
            /*
             *
             * 10	فعال
             * 20	غیر فعال
             * 30	حذف
             * 40	ورود به آتلیه
             * 50	در انتظار بیعانه
             * 60	لغو مشتری
             *
             */
            int bookingStatusCode = int.Parse(dgvBookings.SelectedRows[0].Cells["clmStatusCode"].Value.ToString());

            if (bookingStatusCode == 40 || bookingStatusCode == 30 || bookingStatusCode == 20)
            {
                ورودبهآتلیهToolStripMenuItem.Enabled = false;
                لغورزروToolStripMenuItem.Enabled = false;
                ویرایشاطلاعاتنوبتToolStripMenuItem.Enabled = false;
            }

            else if (bookingStatusCode == 60)
            {
                ورودبهآتلیهToolStripMenuItem.Enabled = false;
                لغورزروToolStripMenuItem.Enabled = false;
            }
            else
            {
                ورودبهآتلیهToolStripMenuItem.Enabled = true;
                لغورزروToolStripMenuItem.Enabled = true;
                ویرایشاطلاعاتنوبتToolStripMenuItem.Enabled = true;
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.BookingStatusGenericRepository.Get();
                    e.Result = result;
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + exception.Message);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                cmbBookinsStatus1.DataSource = e.Result;
                cmbBookinsStatus1.DisplayMember = "StatusName";
                cmbBookinsStatus1.ValueMember = "Code";

                btnShowBookings.Enabled = !backgroundWorker.IsBusy;
                btnClearSearch.Enabled = !backgroundWorker.IsBusy;
            }
            else
            {
                MessageBox.Show(
                    @"اطلاعات وضعیت رزروها از سیستم قابل دریافت نمی باشد." +
                    @" لطفا فرم را بسته و مجددا باز کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید. ",
                    @"خطا در دریافت اطلاعات از سیستم",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
