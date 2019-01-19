using FreeControls;
using PhotographyAutomation.DateLayer.Context;
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
        public int StatusCode = 10;
        public FrmShowBookings()
        {
            InitializeComponent();
        }

        private void FrmShowBookings_Load(object sender, EventArgs e)
        {
            dgvBookings.BackColor = Color.White;
            rbCurrentWeek.CheckState = CheckState.Checked;
            DateTime dtTo = GetFridayDate(DateTime.Now);
            ShowBookings(DateTime.Today, dtTo,statusCode:10);
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

        private static DateTime GetFirstDayOfWeek(DateTime dt)
        {
            while (true)
            {
                if (dt.DayOfWeek == DayOfWeek.Saturday) return dt;
                dt = dt.AddDays(-1);
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

        private static DateTime GetLastDateOfMonth(PersianDate date)
        {
            PersianCalendar pc = new PersianCalendar();

            int totalDayInCurrentMonth = pc.GetDaysInMonth(date.Year, date.Month);
            int currentDayOfMonth = pc.GetDayOfMonth(date);
            int delta = totalDayInCurrentMonth - currentDayOfMonth;
            DateTime dtTo = DateTime.Now.AddDays(delta);
            return dtTo;
        }

        private static DateTime GetFirstDayOfMonth(PersianDate date)
        {
            PersianCalendar pc=new PersianCalendar();
            int currentDayOfMonth = pc.GetDayOfMonth(date);
            return date.AddDays(-currentDayOfMonth+1);
        }

       
        
        private void ShowBookings(DateTime dtFrom, DateTime dtTo,int statusCode)
        {
            dgvBookings.BackColor = Color.White;
            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo,statusCode);
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
            }
            dgvBookings.BackColor = Color.White;
        }

        
        
        private void rbCurrentDay_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentDay.CheckState == CheckState.Checked)
            {
                ShowBookings(DateTime.Now, DateTime.Now,StatusCode);
            }
        }

        private void rbCurrentWeek_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentWeek.CheckState == CheckState.Checked)
            {
                DateTime dtTo = GetFridayDate(DateTime.Now);
                ShowBookings(GetFirstDayOfWeek(DateTime.Now), dtTo,StatusCode);
            }
        }

        private void rbCurrentmonth_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbCurrentmonth.CheckState == CheckState.Checked)
            {
                DateTime dtLastDayOfMonth = GetLastDateOfMonth(PersianDate.Now);
                ShowBookings(GetFirstDayOfMonth(PersianDate.Now), dtLastDayOfMonth,StatusCode);
            }
        }

        
        
        private void chkSpecialBookings_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            cmbBookinsStatus.Enabled = chkSpecialBookings.Checked;
        }

        private void cmbBookinsStatus_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cmbBookinsStatus.Enabled)
                StatusCode = (int)cmbBookinsStatus.SelectedValue;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
