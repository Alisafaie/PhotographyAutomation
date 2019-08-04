using DevComponents.DotNetBar.Validator;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Customers
{
    public partial class FrmShowCustomer : Form
    {
        #region Variables

        public bool FromFrmAddEditBooking = false;
        public bool FromFrmShowBookings = false;
        public int CustomerId;
        public bool CustomerIdForPreFactor = false;

        private readonly BackgroundWorker _bgWorkerSerachCustomer = new BackgroundWorker();

        #endregion


        #region Form Events
        public FrmShowCustomer()
        {
            InitializeComponent();
            _bgWorkerSerachCustomer.DoWork += _bgWorkerSerachCustomer_DoWork;
            _bgWorkerSerachCustomer.RunWorkerCompleted += _bgWorkerSerachCustomer_RunWorkerCompleted;
        }
        private void FrmShowCustomer_Load(object sender, EventArgs e)
        {
            AddContextMenuToTxtTell();
        }

        #endregion


        #region Menthods
        //جهت جلوگیری از کپی پیست و دور زدن قوانین برنامه
        private void AddContextMenuToTxtTell()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("لطفا اعداد را به صورت کپی پیست وارد نکنید.");
            //txtTell.TextBoxElement.TextBoxItem.HostedControl.ContextMenuStrip = menu;
            txtTell.ContextMenuStrip = menu;
        }
        private bool CheckInputs(CustomerSearchInfo cuInfo)
        {
            if (string.IsNullOrEmpty(cuInfo.FirstName.Trim()) && string.IsNullOrEmpty(cuInfo.LastName.Trim()) &&
                string.IsNullOrEmpty(cuInfo.Tell.Trim()))
            {
                if (string.IsNullOrEmpty(cuInfo.FirstName.Trim()))
                {
                    highlighter.SetHighlightColor(txtFirstName, eHighlightColor.Red);
                    txtFirstName.Focus();
                }
                else if (string.IsNullOrEmpty(cuInfo.LastName.Trim()))
                {
                    highlighter.SetHighlightColor(txtLastName, eHighlightColor.Red);
                    txtLastName.Focus();
                }
                else
                {
                    highlighter.SetHighlightColor(txtTell, eHighlightColor.Red);
                    txtTell.Focus();
                }
                return false;
            }
            highlighter.SetHighlightColor(txtFirstName, eHighlightColor.None);
            highlighter.SetHighlightColor(txtLastName, eHighlightColor.None);
            highlighter.SetHighlightColor(txtTell, eHighlightColor.None);
            return true;
        }

        #endregion


        #region Search Customer

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var cuInfo = new CustomerSearchInfo
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Tell = txtTell.Text
            };

            if (CheckInputs(cuInfo) == false)
            {
                MessageBox.Show("مقداری برای جستجو وارد نشده است.", "خطا - عدم ورود اطلاعات برای جستجو",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bgWorkerSerachCustomer.RunWorkerAsync(cuInfo);
        }

        private static void _bgWorkerSerachCustomer_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                var cuInfo = e.Argument as CustomerSearchInfo;
                try
                {
                    List<TblCustomer> users;
                    using (var db = new UnitOfWork())
                    {
                        users = db.CustomerGenericRepository.Get(
                            x =>
                                x.FirstName.StartsWith(cuInfo.FirstName.Trim()) ||
                                x.LastName.StartsWith(cuInfo.LastName.Trim()) ||
                                x.Tell.Contains(cuInfo.Tell.Trim()) ||
                                x.Mobile.Contains(cuInfo.Tell.Trim())
                        ).ToList();
                    }

                    e.Result = users;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    e.Result = null;
                }
            }
        }
        private void _bgWorkerSerachCustomer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                try
                {
                    var users = e.Result as List<TblCustomer>;

                    dgvCustomers.Rows.Clear();
                    dgvCustomers.AutoGenerateColumns = false;

                    if ((users ?? throw new InvalidOperationException()).Any())
                    {
                        dgvCustomers.Rows.Clear();
                        dgvCustomers.RowCount = users.Count;

                        for (int i = 0; i < users.Count; i++)
                        {
                            dgvCustomers.Rows[i].Cells["Id"].Value = users[i].Id;
                            dgvCustomers.Rows[i].Cells["FirstName"].Value = users[i].FirstName;
                            dgvCustomers.Rows[i].Cells["LastName"].Value = users[i].LastName;
                            dgvCustomers.Rows[i].Cells["Tell"].Value = users[i].Tell;
                            dgvCustomers.Rows[i].Cells["Tell"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

                            dgvCustomers.Rows[i].Cells["Mobile"].Value = "0" + users[i].Mobile;
                            dgvCustomers.Rows[i].Cells["Mobile"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

                            dgvCustomers.Rows[i].Cells["Email"].Value = users[i].Email;
                            dgvCustomers.Rows[i].Cells["Email"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

                            dgvCustomers.Rows[i].Cells["NationalId"].Value = users[i].NationalId;
                            dgvCustomers.Rows[i].Cells["NationalId"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

                            var createdDate = users[i].CreatedDate;
                            if (createdDate != null)
                                dgvCustomers.Rows[i].Cells["CreatedDate"].Value =
                                    createdDate.Value.ToString("HH:mm") + "   " +
                                    createdDate.Value.Date.ToShortDateString();

                            dgvCustomers.Rows[i].Cells["CreatedDate"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

                            var modifiedDate = users[i].ModifiedDate;
                            if (modifiedDate != null)
                                dgvCustomers.Rows[i].Cells["CreatedDate"].Value =
                                    modifiedDate.Value.ToString("HH:mm") + "   " +
                                    modifiedDate.Value.Date.ToShortDateString();

                            dgvCustomers.Rows[i].Cells["CreatedDate"].Style.Alignment =
                                DataGridViewContentAlignment.MiddleRight;

                            dgvCustomers.Rows[i].Cells["MoreInfo"].Value = "...";
                        }

                        dgvCustomers.ClearSelection();
                    }
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    MessageBox.Show("متاسفانه جستجوی شما در سیستم نتیجه ای در بر نداشت.", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    MessageBox.Show($@"invalidOperationException: {invalidOperationException.Message}");
                    dgvCustomers.Rows.Clear();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($@"Exception: {exception.Message}");
                }
            }
            else
            {
                MessageBox.Show("متاسفانه جستجوی شما در سیستم نتیجه ای در بر نداشت.", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dgvCustomers.Rows.Clear();
            }
        }

        #endregion


        #region Datagridview Events

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int moreInfoCellIndex = dgvCustomers.CurrentRow.Cells["MoreInfo"].ColumnIndex;
                if (dgvCustomers.CurrentCell.ColumnIndex.Equals(moreInfoCellIndex) && e.RowIndex != -1)
                {
                    if (dgvCustomers.CurrentCell?.Value != null)
                    {
                        var customerId = (int)dgvCustomers.CurrentRow.Cells["Id"].Value;
                        if (FromFrmShowBookings)
                        {
                            FrmShowBookings.CustomerId = customerId;
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
        }

        private void dgvUsers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvCustomers.Rows.Count > 0)
                {
                    int currentMouseOverRow = dgvCustomers.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow > -1)
                        dgvCustomers.Rows[currentMouseOverRow].Selected = true;
                    else
                    {
                        menuDgvUsers.Visible = false;
                    }
                }
                else
                {
                    menuDgvUsers.Visible = false;
                }
            }
        }

        #endregion


        #region Type Farsi and English

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }
        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }
        private void txtTell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        #endregion


        #region Datagridview Menu

        private void ویرایشاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);
            var frmAddEditCustomerInfo = new FrmAddEditCustomerInfo
            {
                CustomerId = customerId,
                NewCustomer = true,
                JustSaveCustomerInfo = true
            };
            frmAddEditCustomerInfo.ShowDialog();
            btnSearch_Click(null, null);
        }

        private void ثبتنوبتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 1 &&
                int.TryParse(dgvCustomers.SelectedRows[0].Cells["Id"].Value.ToString(), out var customerId))
            {

                using (var frmAddEditBooking = new FrmAddEditBooking())
                {
                    frmAddEditBooking.CustomerId = customerId;
                    frmAddEditBooking.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("هیچ آیتمی برای ثبت رزرواسیون انتخاب نشده است.", "خطا - عدم انتخاب مشتری",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Top Menu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmAddEditCustomer = new FrmAddEditCustomerInfo())
            {
                frmAddEditCustomer.NewCustomer = false;
                frmAddEditCustomer.CustomerId = 0;
                frmAddEditCustomer.JustSaveCustomerInfo = true;


                if (frmAddEditCustomer.ShowDialog() == DialogResult.OK)
                    CustomerId = frmAddEditCustomer.CustomerId;
                if (CustomerIdForPreFactor)
                    DialogResult = DialogResult.OK;
            }
        }

        private void ویرایشاطلاعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                if (int.TryParse(dgvCustomers.SelectedRows[0].Cells["Id"].Value.ToString(), out var customerId))
                {
                    using (var frmAddEditCustomerInfo = new FrmAddEditCustomerInfo())
                    {
                        frmAddEditCustomerInfo.CustomerId = customerId;
                        frmAddEditCustomerInfo.NewCustomer = true;
                        frmAddEditCustomerInfo.JustSaveCustomerInfo = true;
                        if (frmAddEditCustomerInfo.ShowDialog() == DialogResult.OK)
                            btnSearch_Click(null, null);
                    }
                }
            }
            else
            {
                MessageBox.Show("هیچ آیتمی برای ویرایش انتخاب نشده است.", "خطا - عدم انتخاب مشتری",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirstName.Text.Trim()) || !string.IsNullOrEmpty(txtLastName.Text.Trim()) ||
                !string.IsNullOrEmpty(txtTell.Text.Trim()))
            {
                btnSearch_Click(null, null);
            }
            else
            {
                MessageBox.Show("هیچ اطلاعاتی برای جستجو وارد نشده است.", "خطا - عدم ورود اطلاعات مشتری",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ثبتنوبتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ثبتنوبتToolStripMenuItem_Click(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuDgvUsers_Paint(object sender, PaintEventArgs e)
        {
            if (dgvCustomers.CurrentRow != null &&
                int.TryParse(dgvCustomers.SelectedRows[0].Cells["Id"].Value.ToString(), out int customerId) &&
                CustomerIdForPreFactor)
            {
                CustomerId = customerId;
                ثبتپیشفاکتورToolStripMenuItem.Enabled = true;
            }
        }

        private void ثبتپیشفاکتورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null &&
               int.TryParse(dgvCustomers.SelectedRows[0].Cells["Id"].Value.ToString(), out int customerId) &&
               CustomerIdForPreFactor)
            {
                CustomerId = customerId;
                DialogResult = DialogResult.OK;
            }
        }

        #endregion

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtFirstName.ResetText();
            txtLastName.ResetText();
            txtTell.ResetText();
        }
    }

}
public class CustomerSearchInfo
{
    public string FirstName { get; internal set; }
    public string LastName { get; internal set; }
    public string Tell { get; internal set; }
}
