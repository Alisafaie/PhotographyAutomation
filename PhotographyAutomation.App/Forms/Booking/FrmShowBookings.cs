using FreeControls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Booking;
using System;
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
            dgvBookings.ClearSelection();
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



            //FrmSearchCustomer searchCustomer = new FrmSearchCustomer
            //{
            //    FromFrmShowBookings = true,

            //};
            //if (searchCustomer.ShowDialog() == DialogResult.OK)
            //{
            //    if (CustomerId > 0)
            //    {
            //        ShowBookingsOfCustomer(CustomerId);
            //    }
            //}


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
                        dgvBookings.Rows[currentMouseOverRow].Selected = true;
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
    }
}
