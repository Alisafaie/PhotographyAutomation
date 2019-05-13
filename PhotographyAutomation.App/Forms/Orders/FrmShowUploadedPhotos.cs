using DevComponents.DotNetBar.Controls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Orders
{
    public partial class FrmShowUploadedPhotos : Form
    {
        #region Variables
        private int _statusCode;
        #endregion

        #region Form Events
        public FrmShowUploadedPhotos()
        {
            InitializeComponent();
        }

        private void FrmShowUploadedPhotos_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }

        #endregion

        #region Button Events

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtOrderCodeDate.ResetText();
            txtOrderCodeCustomerIdBookingId.ResetText();

            txtOrderCodeDate.Focus();
        }

        private void btnShowOrders_Click(object sender, EventArgs e)
        {
            if (rbOrderCode.Checked)
            {
                string orderCode = txtOrderCodeDate.Text + "-" + txtOrderCodeCustomerIdBookingId.Text;
                ShowOrdersByOrderCode(orderCode);
            }
            else if (rbCustomerInfo.Checked)
            {
                string customerInfo = txtCustomerInfo.Text.Trim();
                ShowOrders(customerInfo);
            }
            else if (rbOrderDate.Checked)
            {
                var orderDate = datePickerOrderDate.Value.GetDateFromPersianDateTimePicker();
                ShowOrders(orderDate);
            }
            else if (rbOrderStatus.Checked)
            {
                if (chkEnableOrderStatusDatePicker.Checked == false)
                {
                    ShowOrders(_statusCode);
                }
                else
                {
                    DateTime statusDate = datePickerOrderStatus.Value.GetDateFromPersianDateTimePicker();
                    ShowOrders(_statusCode, statusDate);
                }
            }
        }

        #endregion


        #region Methods

        private void ShowOrdersByOrderCode(string orderCode)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersOfCustomerByOrderCode(orderCode);

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
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
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
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }

        private void ShowOrders(DateTime orderDate)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersByOrderDate(orderDate);

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
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }

        private void ShowOrders(int orderStatusId)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersByStatusCode(orderStatusId);

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
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }

        private void ShowOrders(int orderStatusId, DateTime statusDate)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersByStatusCode(orderStatusId, statusDate);

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
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }



        private void PopulateDataGridView(IReadOnlyList<CustomerOrderViewModel> ordersList)
        {
            dgvUploads.Rows.Clear();
            dgvUploads.RowCount = ordersList.Count;
            dgvUploads.AutoGenerateColumns = false;

            for (var i = 0; i < ordersList.Count; i++)
            {
                dgvUploads.Rows[i].Cells["clmId"].Value = ordersList[i].Id;
                dgvUploads.Rows[i].Cells["clmCustomerId"].Value = ordersList[i].CustomerId;
                dgvUploads.Rows[i].Cells["clmBookingId"].Value = ordersList[i].BookingId;

                if (ordersList[i].OrderCode != null)
                    dgvUploads.Rows[i].Cells["clmOrderCode"].Value = ordersList[i].OrderCode;

                switch (ordersList[i].CustomerGender)
                {
                    case 0:
                        dgvUploads.Rows[i].Cells["clmCustomerFullName"].Value =
                            "خانم " + ordersList[i].CustomerFullName;
                        break;
                    case 1:
                        dgvUploads.Rows[i].Cells["clmCustomerFullName"].Value =
                            "آقای " + ordersList[i].CustomerFullName;
                        break;
                    case 2:
                        dgvUploads.Rows[i].Cells["clmCustomerFullName"].Value =
                            ordersList[i].CustomerFullName;
                        break;
                }


                dgvUploads.Rows[i].Cells["clmDate"].Value = ordersList[i].OrderDate?.ToShamsiDate();
                dgvUploads.Rows[i].Cells["clmTime"].Value = ordersList[i].OrderTime?.Hours.ToString("##") + ":" +
                                                           ordersList[i].OrderTime?.Minutes.ToString("00");
                dgvUploads.Rows[i].Cells["clmPhotographyTypeId"].Value = ordersList[i].PhotographyTypeId;
                dgvUploads.Rows[i].Cells["clmPhotographyTypeName"].Value = ordersList[i].PhotographyTypeName;
                dgvUploads.Rows[i].Cells["clmPersonCount"].Value = ordersList[i].PersonCount;
                //dgvOrders.Rows[i].Cells["clmPaymentIsOK"].Value = ordersList[i].PaymentIsOk;
                //dgvOrders.Rows[i].Cells["clmSubmitter"].Value = ordersList[i].Submitter;
                //dgvOrders.Rows[i].Cells["clmSubmitterName"].Value = ordersList[i].SubmitterName;
                dgvUploads.Rows[i].Cells["clmStatusId"].Value = ordersList[i].OrderStatusId;
                dgvUploads.Rows[i].Cells["clmStatusName"].Value = ordersList[i].OrderStatusName;
                dgvUploads.Rows[i].Cells["clmCreatedDateTime"].Value = ordersList[i].CreatedDateTime;
                dgvUploads.Rows[i].Cells["clmModifiedDateTime"].Value = ordersList[i].ModifiedDateTime;
                dgvUploads.Rows[i].Cells["clmTotalFiles"].Value = ordersList[i].TotalFiles;
                dgvUploads.Rows[i].Cells["clmOrderStatusCode"].Value = ordersList[i].OrderStatusCode;
                dgvUploads.Rows[i].Cells["clmViewPhotos"].Value = ordersList[i].OrderFolderPathLocator;

                //Alignments
                dgvUploads.Rows[i].Cells["clmDate"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmTime"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmOrderCode"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmTotalFiles"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmPersonCount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void PopulateComboBox()
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
                cmbOrderStatus.ValueMember = "Id";
            }
        }

        #endregion


        #region NumberOnlyTextbox

        private void txtOrderCodeDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;

            //if (txtOrderCodeDate.TextLength == 7)
            //    txtOrderCodeCustomerId.Focus();
        }

        private void txtOrderCodeCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtOrderCodeDate_KeyDown(object sender, KeyEventArgs e)
        {
            //Allow navigation keyboard arrows
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                    e.SuppressKeyPress = false;
                    return;
            }

            //Block non-number characters
            char currentKey = (char)e.KeyCode;
            bool modifier = e.Control || e.Alt || e.Shift;
            bool nonNumber = char.IsLetter(currentKey) ||
                             char.IsSymbol(currentKey) ||
                             char.IsWhiteSpace(currentKey) ||
                             char.IsPunctuation(currentKey);

            if (!modifier && nonNumber)
                e.SuppressKeyPress = true;

            //Handle pasted Text
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Preview paste data (removing non-number characters)
                string pasteText = Clipboard.GetText();
                string strippedText = "";
                foreach (var t in pasteText)
                {
                    if (char.IsDigit(t))
                        strippedText += t.ToString();
                }

                if (strippedText != pasteText)
                {
                    //There were non-numbers in the pasted text
                    e.SuppressKeyPress = true;

                    //OPTIONAL: Manually insert text stripped of non-numbers
                    TextBoxX me = (TextBoxX)sender;
                    int start = me.SelectionStart;
                    string newTxt = me.Text;
                    newTxt = newTxt.Remove(me.SelectionStart, me.SelectionLength); //remove highlighted text
                    newTxt = newTxt.Insert(me.SelectionStart, strippedText); //paste
                    me.Text = newTxt;
                    me.SelectionStart = start + strippedText.Length;
                }
                else
                    e.SuppressKeyPress = false;
            }
        }



        #endregion


        #region ComboBox Events
        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderStatus.Enabled)
                int.TryParse(cmbOrderStatus.SelectedValue.ToString(), out _statusCode);
        }



        #endregion

        private void chkEnableOrderStatusDatePicker_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableOrderStatusDatePicker.Checked)
            {
                datePickerOrderStatus.Enabled = true;
                datePickerOrderStatus.Focus();
            }
            else
            {
                datePickerOrderStatus.Enabled = false;
            }
        }

        private void txtOrderCodeDate_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderCodeDate.TextLength == 7)
                txtOrderCodeCustomerIdBookingId.Focus();
        }

        private void rbOrderCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrderCode.Checked)
            {
                txtOrderCodeDate.Enabled = true;
                txtOrderCodeCustomerIdBookingId.Enabled = true;
                txtOrderCodeDate.Focus();
            }
            else
            {
                txtOrderCodeDate.Enabled = false;
                txtOrderCodeCustomerIdBookingId.Enabled = false;
            }
        }

        private void rbCustomerInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustomerInfo.Checked)
                txtCustomerInfo.Enabled = true;
            else
                txtCustomerInfo.Enabled = false;
        }

        private void rbOrderDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrderDate.Checked)
            {
                datePickerOrderDate.Enabled = true;
            }
            else
                datePickerOrderDate.Enabled = false;

        }

        private void rbOrderStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrderStatus.Checked)
            {
                cmbOrderStatus.Enabled = true;
                chkEnableOrderStatusDatePicker.Enabled=true;

                if (chkEnableOrderStatusDatePicker.Checked)
                    datePickerOrderStatus.Enabled = true;
                else
                    datePickerOrderStatus.Enabled = false;
            }
            else
            {
                cmbOrderStatus.Enabled = false;
                datePickerOrderDate.Enabled = false;
                chkEnableOrderStatusDatePicker.Enabled = false;
            }
        }
    }
}
