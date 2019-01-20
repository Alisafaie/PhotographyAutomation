using FreeControls;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.ViewModels.Booking;
using System;
using System.Drawing;
using System.Globalization;
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

            rbCurrentDay.CheckState = CheckState.Unchecked;
            rbCurrentWeek.CheckState = CheckState.Unchecked;
            rbCurrentmonth.CheckState = CheckState.Unchecked;
        }

        private void FrmShowBookings_Load(object sender, EventArgs e)
        {
            dgvBookings.BackColor = Color.White;
            GetBookingStatus();
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


        private static DateTime GetFridayDate(DateTime now)
        {
            while (true)
            {
                if (now.DayOfWeek == DayOfWeek.Friday) return now;

                now = now.AddDays(1);
            }
        }
        private static DateTime GetFirstDayOfWeek(DateTime dt)
        {
            while (true)
            {
                if (dt.DayOfWeek == DayOfWeek.Saturday) return dt;
                dt = dt.AddDays(-1);
            }
        }

        private static DateTime GetFirstDayOfMonth(PersianDate date)
        {
            PersianCalendar pc = new PersianCalendar();
            int currentDayOfMonth = pc.GetDayOfMonth(date);
            return date.AddDays(-currentDayOfMonth + 1);
        }
        private static DateTime GetLastDateOfMonth(PersianDate date)
        {
            PersianCalendar pc = new PersianCalendar();

            int totalDayInCurrentMonth = pc.GetDaysInMonth(date.Year, date.Month);
            int currentDayOfMonth = pc.GetDayOfMonth(date);
            int delta = totalDayInCurrentMonth - currentDayOfMonth;
            DateTime dtTo = DateTime.Now.AddDays(delta);
            return dtTo;
        }

        private DateTime GetDateFromPersianDateTimePicker(PersianDate selectedDate)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dtSelectedDate = pc.ToDateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 0, 0, 0, 0);
            return dtSelectedDate;
        }




        private void ShowBookings(DateTime dtFrom, DateTime dtTo, int statusCode)
        {
            dgvBookings.BackColor = Color.White;
            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, statusCode);
                if (bookingsList.Any())
                {
                    dgvBookings.Rows.Clear();
                    dgvBookings.RowCount = bookingsList.Count;
                    dgvBookings.AutoGenerateColumns = false;

                    for (int i = 0; i < bookingsList.Count; i++)
                    {
                        dgvBookings.Rows[i].Cells["clmId"].Value = bookingsList[i].Id;
                        dgvBookings.Rows[i].Cells["clmUserId"].Value = bookingsList[i].UserId;

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
                else
                {
                    RtlMessageBox.Show("برای تاریخ مورد نظر نوبتی ثبت نگردیده است.", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvBookings.Rows.Clear();
                }
            }
            dgvBookings.BackColor = Color.White;
        }

        private void ShowBookingsOfCustomer(int customerId)
        {
            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingOfCustomer(customerId);
                {
                    dgvBookings.Rows.Clear();
                    if (bookingsList.Any())
                    {
                        dgvBookings.Rows.Clear();
                        dgvBookings.RowCount = bookingsList.Count;
                        dgvBookings.AutoGenerateColumns = false;

                        for (int i = 0; i < bookingsList.Count; i++)
                        {
                            dgvBookings.Rows[i].Cells["clmId"].Value = bookingsList[i].Id;
                            dgvBookings.Rows[i].Cells["clmUserId"].Value = bookingsList[i].UserId;

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
                            dgvBookings.Rows[i].Cells["clmDate"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

                            dgvBookings.Rows[i].Cells["clmTime"].Value = bookingsList[i].Time;

                            dgvBookings.Rows[i].Cells["clmTime"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

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
                ShowBookings(DateTime.Now, DateTime.Now, _statusCode);
            }
        }

        private void rbCurrentWeek_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentWeek.CheckState == CheckState.Checked)
            {
                DateTime dtTo = GetFridayDate(DateTime.Now);
                ShowBookings(GetFirstDayOfWeek(DateTime.Now), dtTo, _statusCode);
            }
        }

        private void rbCurrentmonth_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentmonth.CheckState == CheckState.Checked)
            {
                DateTime dtLastDayOfMonth = GetLastDateOfMonth(PersianDate.Now);
                DateTime dtFirstDayOfMonth = GetFirstDayOfMonth(PersianDate.Now);
                ShowBookings(dtFirstDayOfMonth, dtLastDayOfMonth, _statusCode);
            }
        }



        private void chkSpecialBookings_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkSpecialBookings.Checked)
            {
                cmbBookinsStatus.Enabled = true;
            }
        }

        private void cmbBookinsStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cmbBookinsStatus.Enabled)
                _statusCode = (int)cmbBookinsStatus.SelectedValue;
        }



        private void datePickerBookingDate_ValueChanged(object sender, PersianMonthCalendarEventArgs e)
        {
            DateTime dtSelectedDate = GetDateFromPersianDateTimePicker(datePickerBookingDate.Value);
            ShowBookings(dtSelectedDate, dtSelectedDate, _statusCode);
        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            bool currentDay = rbCurrentDay.IsChecked;
            bool currentWeek = rbCurrentWeek.IsChecked;
            bool currentMonth = rbCurrentmonth.IsChecked;
            bool searchSpecialDate = chkEnableDatePickerBookingDate.Checked;

            if (searchSpecialDate)
            {
                DateTime dtSelectedDate = GetDateFromPersianDateTimePicker(datePickerBookingDate.Value);
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
                    ShowBookings(GetFirstDayOfWeek(DateTime.Now), GetFridayDate(DateTime.Now), _statusCode);
                }
                else if (currentMonth)
                {
                    ShowBookings(GetFirstDayOfMonth(DateTime.Now), GetLastDateOfMonth(PersianDate.Now), _statusCode);
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
            FrmSearchCustomer searchCustomer = new FrmSearchCustomer { FromFrmShowBookings = true };
            if (searchCustomer.ShowDialog() == DialogResult.OK)
            {
                if (CustomerId > 0)
                {
                    ShowBookingsOfCustomer(CustomerId);
                }
            }
        }
    }
}
