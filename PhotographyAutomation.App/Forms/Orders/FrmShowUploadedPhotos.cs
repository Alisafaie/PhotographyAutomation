using System;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Order;

namespace PhotographyAutomation.App.Forms.Orders
{
    public partial class FrmShowUploadedPhotos : Form
    {
        #region Variables
        private int _statusCode = 0;
        #endregion
        public FrmShowUploadedPhotos()
        {
            InitializeComponent();
        }

        private void FrmShowUploadedPhotos_Load(object sender, System.EventArgs e)
        {
            PopulateComboBox();
        }

        

        private void chkSpecialOrders_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSpecialOrders.Checked)
            {
                cmbOrderStatus.Enabled = true;
                cmbOrderStatus.Focus();
                cmbOrderStatus.DroppedDown = true;
            }
            else
            {
                cmbOrderStatus.Enabled = false;
            }
        }

        private void chkEnableDatePickerOrderDate_CheckedChanged(object sender, System.EventArgs e)
        {
            datePickerOrderDate.Enabled = chkEnableDatePickerOrderDate.Checked;
        }




        private void btnClearSearch_Click(object sender, System.EventArgs e)
        {
            txtOrderCodeDate.ResetText();
            txtOrderCodeCustomerId.ResetText();
            txtOrderCodeBookingId.ResetText();
            chkEnableDatePickerOrderDate.Checked = false;
            chkSpecialOrders.Checked = false;

            txtOrderCodeDate.Focus();
        }

        private void btnShowOrders_Click(object sender, System.EventArgs e)
        {
            string orderCode = txtOrderCodeDate.Text + txtOrderCodeCustomerId.Text + txtOrderCodeBookingId.Text;
            string customerInfo = txtCustomerInfo.Text.Trim();

            var searchSpecialDateIsChecked = chkEnableDatePickerOrderDate.Checked;

            if (searchSpecialDateIsChecked)
            {
                var dtOrder = datePickerOrderDate.Value.GetDateFromPersianDateTimePicker();
                
                if (chkSpecialOrders.Checked)
                {
                    if (chkSpecialOrders.Checked)
                        ShowOrders(dtOrder, _statusCode,orderCode, customerInfo);
                    else
                        ShowOrders(dtFrom, dtTo, txtCustomerInfo.Text.Trim());
                }
                else
                    ShowOrders(dtFrom, dtTo, txtCustomerInfo.Text.Trim());
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
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }

        private void ShowOrders(DateTime orderDate)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersOfCustomer(orderDate);

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

        private void ShowOrders(int orderStatus)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersOfCustomer(orderStatus);

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
                cmbOrderStatus.ValueMember = "StatusCode";
            }
        }




        #region NumberOnlyTextbox

        private void txtOrderCodeDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;

            if (txtOrderCodeDate.TextLength == 7)
                txtOrderCodeCustomerId.Focus();
        }

        private void txtOrderCodeCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtOrderCodeBookingId_KeyPress(object sender, KeyPressEventArgs e)
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
                default:
                    break;
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
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (char.IsDigit(pasteText[i]))
                        strippedText += pasteText[i].ToString();
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

        private void cmbOrderStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbOrderStatus.Enabled)
                int.TryParse(cmbOrderStatus.SelectedValue.ToString(), out _statusCode);
        }
    }
}
