using FreeControls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.EntranceToAtelier
{
    public partial class FrmShowIncommingBookings : Form
    {
        #region Variables

        private int _statusCode = 10;
        public static int CustomerId = 0;
        public int OrderId = 0;

        #endregion

        #region Form Events

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


        #endregion

        #region Radio Buttons Events

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

        #region CheckBoxes Events
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

        #endregion

        #region Combox Events
        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderStatus.Enabled)
                int.TryParse(cmbOrderStatus.SelectedValue.ToString(), out _statusCode);
        }

        #endregion

        #region Button Events
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            rbCurrentDay.Checked = false;
            rbCurrentWeek.Checked = false;
            rbCurrentmonth.Checked = false;
            chkEnableDatePickerBookingDate.Checked = false;
            chkSpecialBookings.Checked = false;
            if (cmbOrderStatus.Enabled) cmbOrderStatus.SelectedIndex = 0;
            cmbOrderStatus.Enabled = false;
            txtCustomerInfo.ResetText();
        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            var searchTodayIsChecked = rbCurrentDay.Checked;
            var searchCurrentWeekIsChecked = rbCurrentWeek.Checked;
            var searchCurrentMonthIsChecked = rbCurrentmonth.Checked;
            var searchSpecialDateIsChecked = chkEnableDatePickerBookingDate.Checked;

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
                        ShowOrders(
                            DateTime.Now.GetBeggingOfTheDateTime(), DateTime.Now.GetEndOfTheDateTime(),
                            _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowOrders(
                            DateTime.Now.GetBeggingOfTheDateTime(),
                            DateTime.Now.GetEndOfTheDateTime(), txtCustomerInfo.Text.Trim());
                }
                else if (searchCurrentWeekIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowOrders(
                            DateTime.Now.GetFirstDayOfWeek(),
                            DateTime.Now.GetFridayDate(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowOrders(
                            DateTime.Now.GetFirstDayOfWeek(), DateTime.Now.GetFridayDate(), txtCustomerInfo.Text.Trim());
                }
                else if (searchCurrentMonthIsChecked)
                {
                    if (chkSpecialBookings.Checked)
                        ShowOrders(
                            PersianDate.Now.GetFirstDayOfMonth(),
                            PersianDate.Now.GetLastDateOfMonth(), _statusCode, txtCustomerInfo.Text.Trim());
                    else
                        ShowOrders(
                            PersianDate.Now.GetFirstDayOfMonth(),
                            PersianDate.Now.GetLastDateOfMonth(), txtCustomerInfo.Text.Trim());
                }
                else
                {
                    if (txtCustomerInfo.Text == @"نمایش همه رزروها")
                        ShowOrders(string.Empty);
                    else
                    {
                        if (string.IsNullOrEmpty(txtCustomerInfo.Text.Trim()))
                        {
                            RtlMessageBox.Show(
                                "اطلاعاتی از مشتری برای جستجو وارد نشده است.",
                                "خطا در ورود اطلاعات",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        ShowOrders(txtCustomerInfo.Text);
                    }
                }
            }
        }

        #endregion

        #region Methods
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
                    RtlMessageBox.Show(
                        "برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvOrders.Rows.Clear();
                }
            }
            dgvOrders.ClearSelection();
        }

        private void ShowOrders(DateTime dtFrom, DateTime dtTo, string customerInfo)
        {
            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                //var orderList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, customerInfo);
                var ordersList = db.OrderRepository.GetOrdersBetweenDates(dtFrom, dtTo, customerInfo);

                if (ordersList != null)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای تاریخ مورد نظر رزرو ورود به آتلیه ثبت نگردیده است.",
                        "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvOrders.Rows.Clear();
                }
            }
            dgvOrders.ClearSelection();
        }

        private void ShowOrders(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo)
        {
            dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            using (var db = new UnitOfWork())
            {
                //var bookingsList = db.BookingRepository.GetBookingBetweenDates(dtFrom, dtTo, statusCode, customerInfo);
                var orderList = db.OrderRepository.GetOrdersBetweenDates(dtFrom, dtTo, statusCode, customerInfo);

                if (orderList.Count > 0)
                {
                    PopulateDataGridView(orderList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای تاریخ مورد نظر رزرو ورود به آتلیه ثبت نگردیده است.",
                        "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvOrders.Rows.Clear();
                }
            }
            dgvOrders.ClearSelection();
        }

        private void PopulateDataGridView(IReadOnlyList<CustomerOrderViewModel> ordersList)
        {
            dgvOrders.Rows.Clear();
            dgvOrders.RowCount = ordersList.Count;
            dgvOrders.AutoGenerateColumns = false;

            for (var i = 0; i < ordersList.Count; i++)
            {
                dgvOrders.Rows[i].Cells["clmId"].Value = ordersList[i].Id;
                dgvOrders.Rows[i].Cells["clmCustomerId"].Value = ordersList[i].CustomerId;
                switch (ordersList[i].CustomerGender)
                {
                    case 0:
                        dgvOrders.Rows[i].Cells["clmCustomerFullName"].Value =
                            "خانم " + ordersList[i].CustomerFullName;
                        break;
                    case 1:
                        dgvOrders.Rows[i].Cells["clmCustomerFullName"].Value =
                            "آقای " + ordersList[i].CustomerFullName;
                        break;
                    case 2:
                        dgvOrders.Rows[i].Cells["clmCustomerFullName"].Value =
                            ordersList[i].CustomerFullName;
                        break;

                }


                dgvOrders.Rows[i].Cells["clmDate"].Value = ordersList[i].BookingDate.ToShamsiDate();
                dgvOrders.Rows[i].Cells["clmDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvOrders.Rows[i].Cells["clmTime"].Value = ordersList[i].BookingTime.Hours.ToString("##") + ":" +
                                                           ordersList[i].BookingTime.Minutes.ToString("00");
                dgvOrders.Rows[i].Cells["clmTime"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                //dgvOrders.Rows[i].Cells["clmPhotographerGender"].Value =
                //    ordersList[i].PhotographerGender;

                switch (ordersList[i].PhotographerGender)
                {
                    case 0:
                        dgvOrders.Rows[i].Cells["clmPhotographerGenderType"].Value = "خانم";
                        break;
                    case 1:
                        dgvOrders.Rows[i].Cells["clmPhotographerGenderType"].Value = "آقا";
                        break;
                    default:
                        dgvOrders.Rows[i].Cells["clmPhotographerGenderType"].Value = "فرقی ندارد";
                        break;
                }

                dgvOrders.Rows[i].Cells["clmPhotographyTypeId"].Value = ordersList[i].PhotographyTypeId;
                dgvOrders.Rows[i].Cells["clmPhotographyTypeName"].Value = ordersList[i].PhotographyTypeName;

                //dgvOrders.Rows[i].Cells["clmAtelierTypeId"].Value = ordersList[i].AtelierTypeId;
                //dgvOrders.Rows[i].Cells["clmAtelierTypeName"].Value = ordersList[i].AtelierTypeName;

                dgvOrders.Rows[i].Cells["clmPersonCount"].Value = ordersList[i].PersonCount;
                //dgvOrders.Rows[i].Cells["clmPaymentIsOK"].Value = ordersList[i].PaymentIsOk;
                //dgvOrders.Rows[i].Cells["clmSubmitter"].Value = ordersList[i].Submitter;
                //dgvOrders.Rows[i].Cells["clmSubmitterName"].Value = ordersList[i].SubmitterName;
                dgvOrders.Rows[i].Cells["clmStatusId"].Value = ordersList[i].OrderStatusId;
                dgvOrders.Rows[i].Cells["clmStatusName"].Value = ordersList[i].OrderStatusName;
                dgvOrders.Rows[i].Cells["clmCreatedDateTime"].Value = ordersList[i].CreatedDateTime;
                dgvOrders.Rows[i].Cells["clmModifiedDateTime"].Value = ordersList[i].ModifiedDateTime;
                dgvOrders.Rows[i].Cells["clmTotalFiles"].Value = ordersList[i].TotalFiles;

            }
        }


        //پیاده سازی نمایش کانتکست منو روی قسمت هایی که مقدار دارند و انتخاب آن ردیف
        private void dgvBookings_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvOrders.Rows.Count > 0)
                {
                    int currentMouseOverRow = dgvOrders.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow > -1)
                    {
                        dgvOrders.Rows[currentMouseOverRow].Selected = true;
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

        #endregion
    }
}