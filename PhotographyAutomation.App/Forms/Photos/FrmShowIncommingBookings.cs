using FreeControls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhotographyAutomation.ViewModels.Order;

namespace PhotographyAutomation.App.Forms.Photos
{
    public partial class FrmShowIncommingBookings : Form
    {

        #region Variables

        private int _statusCode = 10;
        public static int CustomerId = 0;
        public int OrderId = 0;

        #endregion


        public FrmShowIncommingBookings()
        {
            InitializeComponent();
        }

        private void FrmShowIncommingBookings_Load(object sender, EventArgs e)
        {
            rbCurrentDay.CheckState = CheckState.Unchecked;
            rbCurrentWeek.CheckState = CheckState.Unchecked;
            rbCurrentmonth.CheckState = CheckState.Unchecked;

            GetBookingStatus();
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

        private void chkSpecialBookings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecialBookings.Checked)
            {
                cmbOrderStatus.Enabled = true;
                cmbOrderStatus.DroppedDown = true;
            }
            else
            {
                cmbOrderStatus.Enabled = false;
                cmbOrderStatus.DroppedDown = false;
            }
        }

        private void cmbBookinsStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderStatus.Enabled)
                int.TryParse(cmbOrderStatus.SelectedValue.ToString(), out _statusCode);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            rbCurrentDay.Checked = false;
            rbCurrentWeek.Checked = false;
            rbCurrentmonth.Checked = false;
            chkEnableDatePickerBookingDate.Checked = false;
            chkSpecialBookings.Checked = false;
            cmbOrderStatus.SelectedIndex = 0;
            cmbOrderStatus.Enabled = false;
            txtCustomerInfo.ResetText();
        }

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
                        ShowOrders(dtFrom, dtTo, _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowOrders(dtFrom, dtTo, txtCustomerInfo.Text.Trim());
                }
                else
                    ShowOrders(dtFrom, dtTo, txtCustomerInfo.Text.Trim());
            }
            else
            {
                if (searchTodayIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowOrders(DateTime.Now.GetBeggingOfTheDateTime(), DateTime.Now.GetEndOfTheDateTime(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowOrders(DateTime.Now.GetBeggingOfTheDateTime(), DateTime.Now.GetEndOfTheDateTime(), txtCustomerInfo.Text.Trim());
                }
                else if (searchCurrentWeekIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowOrders(DateTime.Now.GetFirstDayOfWeek(), DateTime.Now.GetFridayDate(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowOrders(DateTime.Now.GetFirstDayOfWeek(), DateTime.Now.GetFridayDate(), txtCustomerInfo.Text.Trim());
                }
                else if (searchCurrentMonthIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowOrders(PersianDate.Now.GetFirstDayOfMonth(), PersianDate.Now.GetLastDateOfMonth(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowOrders(PersianDate.Now.GetFirstDayOfMonth(), PersianDate.Now.GetLastDateOfMonth(), txtCustomerInfo.Text.Trim());
                }
                else
                {
                    if (txtCustomerInfo.Text == @"نمایش همه رزروها")
                        ShowOrders(string.Empty);
                    else
                    {
                        if (string.IsNullOrEmpty(txtCustomerInfo.Text.Trim()))
                        {
                            RtlMessageBox.Show("اطلاعاتی از مشتری برای جستجو وارد نشده است.", "خطا در ورود اطلاعات",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        ShowOrders(txtCustomerInfo.Text);
                    }
                }
            }
        }



        private void GetBookingStatus()
        {
            using (var db = new UnitOfWork())
            {
                cmbOrderStatus.DataSource = db.OrderStatusGenericRepository.Get()
                    .Select(x => new OrderStatusViewModel
                    {
                        Id = x.Id,
                        StatusCode = x.Code,
                        Name = x.Name
                    }).ToList();

                cmbOrderStatus.DisplayMember = "Name";
                cmbOrderStatus.ValueMember = "StatusCode";
            }
        }

        private void ShowOrders(string customerInfo)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersOfCustomer(customerInfo);

                if (ordersList.Count > 0)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show("برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.", "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvBookings.Rows.Clear();
                }
            }
            dgvBookings.ClearSelection();
        }

        private void ShowOrders(DateTime dtFrom, DateTime dtTo, string customerInfo)
        {
            //dgvBookings.BackColor = Color.White;

            //dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            //dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            //using (var db = new UnitOfWork())
            //{
            //    var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, customerInfo);

            //    if (bookingsList.Count > 0)
            //    {
            //        PopulateDataGridView(bookingsList);
            //    }
            //    else
            //    {
            //        RtlMessageBox.Show("برای تاریخ مورد نظر نوبتی ثبت نگردیده است.", "", MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //        dgvBookings.Rows.Clear();
            //    }
            //}
            //dgvBookings.BackColor = Color.White;
            //dgvBookings.ClearSelection();
        }

        private void ShowOrders(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo)
        {
            //dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            //dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            //using (var db = new UnitOfWork())
            //{
            //    var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, statusCode, customerInfo);

            //    if (bookingsList.Count > 0)
            //    {
            //        PopulateDataGridView(bookingsList);
            //    }
            //    else
            //    {
            //        RtlMessageBox.Show("برای تاریخ مورد نظر نوبتی ثبت نگردیده است.", "", MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //        dgvBookings.Rows.Clear();
            //    }
            //}
            //dgvBookings.ClearSelection();
        }

        private void PopulateDataGridView(IReadOnlyList<CustomerOrderViewModel> bookingsList)
        {
            //dgvBookings.Rows.Clear();
            //dgvBookings.RowCount = bookingsList.Count;
            //dgvBookings.AutoGenerateColumns = false;

            //for (int i = 0; i < bookingsList.Count; i++)
            //{
            //    dgvBookings.Rows[i].Cells["clmId"].Value = bookingsList[i].Id;
            //    dgvBookings.Rows[i].Cells["clmCustomerId"].Value = bookingsList[i].CustomerId;

            //    if (bookingsList[i].CustomerGender == 0)
            //    {
            //        dgvBookings.Rows[i].Cells["clmCustomerFullName"].Value =
            //            "خانم " + bookingsList[i].CustomerFullName;
            //    }
            //    else if (bookingsList[i].CustomerGender == 1)
            //    {
            //        dgvBookings.Rows[i].Cells["clmCustomerFullName"].Value =
            //            "آقای " + bookingsList[i].CustomerFullName;
            //    }
            //    else
            //    {
            //        dgvBookings.Rows[i].Cells["clmCustomerFullName"].Value =
            //            bookingsList[i].CustomerFullName;
            //    }

            //    dgvBookings.Rows[i].Cells["clmDate"].Value = bookingsList[i].Date.ToShamsiDate();
            //    dgvBookings.Rows[i].Cells["clmDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    dgvBookings.Rows[i].Cells["clmTime"].Value = bookingsList[i].Time;

            //    dgvBookings.Rows[i].Cells["clmTime"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    dgvBookings.Rows[i].Cells["clmPhotographerGender"].Value =
            //        bookingsList[i].PhotographerGender;

            //    switch (bookingsList[i].PhotographerGender)
            //    {
            //        case 0:
            //            dgvBookings.Rows[i].Cells["clmPhotographerGenderName"].Value = "خانم";
            //            break;
            //        case 1:
            //            dgvBookings.Rows[i].Cells["clmPhotographerGenderName"].Value = "آقا";
            //            break;
            //        default:
            //            dgvBookings.Rows[i].Cells["clmPhotographerGenderName"].Value = "فرقی ندارد";
            //            break;
            //    }

            //    dgvBookings.Rows[i].Cells["clmPhotographyTypeId"].Value =
            //        bookingsList[i].PhotographyTypeId;
            //    dgvBookings.Rows[i].Cells["clmPhotographyTypeName"].Value =
            //        bookingsList[i].PhotographyTypeName;
            //    dgvBookings.Rows[i].Cells["clmAtelierTypeId"].Value = bookingsList[i].AtelierTypeId;
            //    dgvBookings.Rows[i].Cells["clmAtelierTypeName"].Value = bookingsList[i].AtelierTypeName;
            //    dgvBookings.Rows[i].Cells["clmPersonCount"].Value = bookingsList[i].PersonCount;
            //    dgvBookings.Rows[i].Cells["clmPaymentIsOK"].Value = bookingsList[i].PaymentIsOk;
            //    dgvBookings.Rows[i].Cells["clmSubmitter"].Value = bookingsList[i].Submitter;
            //    dgvBookings.Rows[i].Cells["clmSubmitterName"].Value = bookingsList[i].SubmitterName;
            //    dgvBookings.Rows[i].Cells["clmStatusId"].Value = bookingsList[i].StatusId;
            //    dgvBookings.Rows[i].Cells["clmStatusName"].Value = bookingsList[i].StatusName;
            //    dgvBookings.Rows[i].Cells["clmCreatedDateTime"].Value = bookingsList[i].CreatedDateTime;
            //    dgvBookings.Rows[i].Cells["clmModifiedDateTime"].Value =
            //        bookingsList[i].ModifiedDateTime;
            //}
        }
    }
}
