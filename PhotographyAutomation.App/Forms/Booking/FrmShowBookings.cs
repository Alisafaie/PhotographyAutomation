using FreeControls;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Booking;
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
        private int _statusCode = 10;
        public static int CustomerId = 0;


        public FrmShowBookings()
        {
            InitializeComponent();
        }

        private void FrmShowBookings_Load(object sender, EventArgs e)
        {
            dgvBookings.BackColor = Color.White;
            GetBookingStatus();

            rbCurrentDay.CheckState = CheckState.Unchecked;
            rbCurrentWeek.CheckState = CheckState.Unchecked;
            rbCurrentmonth.CheckState = CheckState.Unchecked;
        }

        private void GetBookingStatus()
        {
            using (var db = new UnitOfWork())
            {
                cmbBookinsStatus.DataSource = db.BookingStatusGenericRepository.Get()
                    .Select(x => new BookingStatusViewModel
                    {
                        Id = x.Id,
                        StatusCode = x.Code,
                        Name = x.StatusName
                    }).ToList();

                cmbBookinsStatus.DisplayMember = "Name";
                cmbBookinsStatus.ValueMember = "StatusCode";
            }
        }


        private void ShowBookings(DateTime dtFrom, DateTime dtTo, int statusCode)
        {
            dgvBookings.BackColor = Color.White;

            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, statusCode);
                if (bookingsList != null && bookingsList.Count > 0)
                {
                    PopulateDataGridView(bookingsList);
                }
                else
                {
                    RtlMessageBox.Show("برای تاریخ مورد نظر نوبتی ثبت نگردیده است.", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvBookings.Rows.Clear();
                }
            }
            dgvBookings.BackColor = Color.White;
            dgvBookings.ClearSelection();
        }

        private void ShowBookings(DateTime dtFrom, DateTime dtTo)
        {
            dgvBookings.BackColor = Color.White;

            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo);
                if (bookingsList != null && bookingsList.Count > 0)
                {
                    PopulateDataGridView(bookingsList);
                }
                else
                {
                    RtlMessageBox.Show("برای تاریخ مورد نظر نوبتی ثبت نگردیده است.", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvBookings.Rows.Clear();
                }
            }
            dgvBookings.BackColor = Color.White;
            dgvBookings.ClearSelection();
        }

        private void PopulateDataGridView(List<BookingHistoryAddEditBookingViewModel> bookingsList)
        {
            dgvBookings.Rows.Clear();
            dgvBookings.RowCount = bookingsList.Count;
            dgvBookings.AutoGenerateColumns = false;

            for (int i = 0; i < bookingsList.Count; i++)
            {
                dgvBookings.Rows[i].Cells["clmId"].Value = bookingsList[i].Id;
                dgvBookings.Rows[i].Cells["clmCustomerId"].Value = bookingsList[i].UserId;

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

                dgvBookings.Rows[i].Cells["clmTime"].Value = bookingsList[i].Time;

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
                dgvBookings.Rows[i].Cells["clmStatusName"].Value = bookingsList[i].StatusName;
                dgvBookings.Rows[i].Cells["clmCreatedDateTime"].Value = bookingsList[i].CreatedDateTime;
                dgvBookings.Rows[i].Cells["clmModifiedDateTime"].Value =
                    bookingsList[i].ModifiedDateTime;
            }
        }

        private void ShowBookingsOfCustomer(string cucstomerInfo)
        {
            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingOfCustomer(cucstomerInfo);
                {
                    dgvBookings.Rows.Clear();
                    if (bookingsList != null && bookingsList.Count > 0)
                    {
                        PopulateDataGridView(bookingsList);
                    }
                    else
                    {
                        RtlMessageBox.Show("برای مشتری مورد نظر نوبتی در سیستم ثبت نشده است.", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void rbCurrentDay_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentDay.CheckState == CheckState.Checked)
            {
                //ShowBookings(DateTime.Now, DateTime.Now, _statusCode);
                ShowBookings(DateTime.Now, DateTime.Now);
            }
        }

        private void rbCurrentWeek_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentWeek.CheckState == CheckState.Checked)
            {
                DateTime fridayDate = DateTime.Now.GetFridayDate();
                //ShowBookings(DateTime.Now.GetFirstDayOfWeek(), fridayDate, _statusCode);
                ShowBookings(DateTime.Now.GetFirstDayOfWeek(), fridayDate);
            }
        }

        private void rbCurrentmonth_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentmonth.CheckState == CheckState.Checked)
            {
                DateTime dtLastDayOfMonth = PersianDate.Now.GetLastDateOfMonth();
                DateTime dtFirstDayOfMonth = PersianDate.Now.GetFirstDayOfMonth();
                //ShowBookings(dtFirstDayOfMonth, dtLastDayOfMonth, _statusCode);
                ShowBookings(dtFirstDayOfMonth, dtLastDayOfMonth);
            }
        }



        private void chkSpecialBookings_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkSpecialBookings.Checked)
            {
                cmbBookinsStatus.Enabled = true;
                cmbBookinsStatus.ShowDropDown();
            }
        }

        private void cmbBookinsStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cmbBookinsStatus.Enabled)
                _statusCode = (int)cmbBookinsStatus.SelectedValue;
        }



        private void datePickerBookingDate_ValueChanged(object sender, PersianMonthCalendarEventArgs e)
        {
            DateTime dtSelectedDate = datePickerBookingDate.Value.GetDateFromPersianDateTimePicker();
            //ShowBookings(dtSelectedDate, dtSelectedDate, _statusCode);
            ShowBookings(dtSelectedDate, dtSelectedDate);
        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            bool currentDay = rbCurrentDay.IsChecked;
            bool currentWeek = rbCurrentWeek.IsChecked;
            bool currentMonth = rbCurrentmonth.IsChecked;
            bool searchSpecialDate = chkEnableDatePickerBookingDate.Checked;

            if (searchSpecialDate)
            {
                DateTime dtSelectedDate = datePickerBookingDate.Value.GetDateFromPersianDateTimePicker();
                ShowBookings(dtSelectedDate, dtSelectedDate, _statusCode);
            }
            else
            {
                if (currentDay)
                {
                    ShowBookings(DateTime.Now, DateTime.Now, _statusCode);
                }
                else if (currentWeek)
                {
                    ShowBookings(DateTime.Now.GetFirstDayOfWeek(), DateTime.Now.GetFridayDate(), _statusCode);
                }
                else if (currentMonth)
                {
                    ShowBookings(PersianDate.Now.GetFirstDayOfMonth(), PersianDate.Now.GetLastDateOfMonth(), _statusCode);
                }
            }
        }

        private void chkEnableDatePickerBookingDate_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkEnableDatePickerBookingDate.Checked)
            {
                datePickerBookingDate.Enabled = true;
                rbCurrentDay.CheckState = CheckState.Unchecked;
                rbCurrentWeek.CheckState = CheckState.Unchecked;
                rbCurrentmonth.CheckState = CheckState.Unchecked;
            }
            else
            {
                datePickerBookingDate.Enabled = false;
            }
        }

        private void datePickerBookingDate_EnabledChanged(object sender, EventArgs e)
        {
            BackColor = datePickerBookingDate.Enabled ? Color.White : Color.Gainsboro;
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerInfo.Text.Trim()))
            {
                ShowBookingsOfCustomer(txtCustomerInfo.Text.Trim());
            }
        }


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
                        contextMenuStripDgvBookings.Visible = false;
                    }
                }
                else
                {
                    contextMenuStripDgvBookings.Visible = false;
                }
            }
        }



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


        private void ویرایش_اطلاعات_مشتری_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count != 1) return;
            int customerId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["clmCustomerId"].Value);
            using (var frmAddEditCustomerInfo = new FrmAddEditCustomerInfo())
            {
                frmAddEditCustomerInfo.CustomerId = customerId;
                frmAddEditCustomerInfo.JustSaveCustomerInfo = true;
                frmAddEditCustomerInfo.IsEditMode = true;

                frmAddEditCustomerInfo.ShowDialog();
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
                frmAddEditBooking.ShowDialog();
            }
        }

        private void تبدیل_به_سفارش_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 1 &&
                int.TryParse(dgvBookings.SelectedRows[0].Cells["clmId"].Value.ToString(), out var bookingId))
            {
                var dialogResult = RtlMessageBox.Show("آیا وضعیت رزرو مشتری به سفارش تغییر یابد؟",
                    "تغییر وضعیت رزرو به سفارش", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;
                using (var db = new UnitOfWork())
                {
                    var booking = db.BookingGenericRepository.GetById(bookingId);
                    var bookingStatusList = db.BookingStatusGenericRepository.Get().ToList();
                    var orderStatusList = db.OrderStatusGenericRepository.Get().ToList();
                    int bookingStatusToOrderId = 0;
                    int orderStatusId = 0;
                    if (bookingStatusList.Any() && orderStatusList.Any())
                    {
                        bookingStatusToOrderId =
                            bookingStatusList.First(x => x.StatusName.Equals("تبدیل به سفارش")).Id;
                        orderStatusId = orderStatusList.First(x => x.Name.Equals("ورود به آتلیه")).Id;
                    }

                    
                    if (booking != null && bookingStatusToOrderId != 0)
                    {
                        booking.StatusId = bookingStatusToOrderId;
                        var order = new TblOrder
                        {
                            CustomerId = booking.CustomerId,
                            BookingId = bookingId,
                            CreatedDateTime = DateTime.Now,
                            IsActive = true,
                            OrderStatusId = orderStatusId,
                            PhotographyTypeId = booking.PhotographyTypeId,
                        };



                        db.BookingGenericRepository.Update(booking);
                        //int resultUpdateBooking = db.Save();

                        db.OrderGenericRepository.Insert(order);
                        //int resultInsertNewOrder = db.Save();
                        
                        if (db.Save()>0)
                        {
                            RtlMessageBox.Show(
                                "وضعیت رزرو مشتری با موفقیت به سفارش و ورود به آتلیه تغییر پیدا کرد.",
                                "تبدیل به سفارش رزرو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RtlMessageBox.Show(
                                "مشکلی در به روز رسانی وضعیت رزرو پیش آمده است. " +
                                "لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                                "خطا در ثبت اطلاعات در سیستم",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        RtlMessageBox.Show(
                            "اطلاعات رزرو مورد از نظر از بانک اطلاعاتی قابل دریافت نیست. " +
                            "لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                            "خطا در دریافت اطلاعات رزرو از سیستم",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RtlMessageBox.Show("هیچ رزروی برای تبدیل به سفارش انتخاب نشده است.",
                    "خطا - عدم  انتخاب رزرو برای تبدیل به سفارش", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvBookings.Focus();
            }
        }






        private void رزروهای_امروزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbCurrentDay.CheckState = CheckState.Checked;
            rbCurrentDay_ToggleStateChanged(null, null);
        }

        private void رزروهای_هفته_جاری_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbCurrentWeek.CheckState = CheckState.Checked;
            rbCurrentWeek_ToggleStateChanged(null, null);
        }

        private void _رزروهای_ماه_جاریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbCurrentmonth.CheckState = CheckState.Checked;
            rbCurrentmonth_ToggleStateChanged(null, null);
        }

        private void _رزروهای_تاریخ_خاصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkEnableDatePickerBookingDate.Checked = true;
            chkEnableDatePickerBookingDate_ToggleStateChanged(null, null);
        }

        private void _رزروهای_ویژهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkSpecialBookings.Checked = true;
            chkSpecialBookings_ToggleStateChanged(null, null);
        }
    }
}
