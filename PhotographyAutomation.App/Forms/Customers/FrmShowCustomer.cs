using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Customers
{
    public partial class FrmShowCustomer : Form
    {
        public bool FromFrmAddEditBooking = false;
        public bool FromFrmShowBookings = false;
        public int CustomerId = 0;

        public FrmShowCustomer()
        {
            InitializeComponent();
        }

        private void FrmSearchCustomer_Load(object sender, EventArgs e)
        {
            AddContextMenuToTxtTell();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtLastName.Text) &&
                string.IsNullOrEmpty(txtTell.Text))
            {
                RtlMessageBox.Show("مقداری برای جستجو وارد نشده است.", "خطا - عدم ورود اطلاعات برای جستجو",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvCustomers.Rows.Clear();

            using (var db = new UnitOfWork())
            {
                List<TblCustomer> users = db.CustomerGenericRepository.Get(
                    x =>
                        x.FirstName.StartsWith(txtFirstName.Text.Trim()) ||
                        x.LastName.StartsWith(txtLastName.Text.Trim()) ||
                        x.Tell.Contains(txtTell.Text.Trim()) ||
                        x.Mobile.Contains(txtTell.Text.Trim())
                        ).ToList();


                dgvCustomers.AutoGenerateColumns = false;

                if (users.Count > 0)
                {
                    dgvCustomers.Rows.Clear();
                    dgvCustomers.RowCount = users.Count;

                    for (int i = 0; i < users.Count; i++)
                    {
                        dgvCustomers.Rows[i].Cells["Id"].Value = users[i].Id;
                        dgvCustomers.Rows[i].Cells["FirstName"].Value = users[i].FirstName;
                        dgvCustomers.Rows[i].Cells["LastName"].Value = users[i].LastName;
                        dgvCustomers.Rows[i].Cells["Tell"].Value = users[i].Tell;
                        dgvCustomers.Rows[i].Cells["Tell"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvCustomers.Rows[i].Cells["Mobile"].Value = "0" + users[i].Mobile;
                        dgvCustomers.Rows[i].Cells["Mobile"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvCustomers.Rows[i].Cells["Email"].Value = users[i].Email;
                        dgvCustomers.Rows[i].Cells["Email"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvCustomers.Rows[i].Cells["NationalId"].Value = users[i].NationalId;
                        dgvCustomers.Rows[i].Cells["NationalId"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        var createdDate = users[i].CreatedDate;
                        if (createdDate != null)
                            dgvCustomers.Rows[i].Cells["CreatedDate"].Value =
                                createdDate.Value.ToString("HH:mm") + "   " +
                                createdDate.Value.Date.ToShortDateString();

                        dgvCustomers.Rows[i].Cells["CreatedDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        var modifiedDate = users[i].ModifiedDate;
                        if (modifiedDate != null)
                            dgvCustomers.Rows[i].Cells["CreatedDate"].Value =
                                modifiedDate.Value.ToString("HH:mm") + "   " +
                                modifiedDate.Value.Date.ToShortDateString();

                        dgvCustomers.Rows[i].Cells["CreatedDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvCustomers.Rows[i].Cells["MoreInfo"].Value = "...";
                    }

                    dgvCustomers.ClearSelection();
                }
                else
                {
                    RtlMessageBox.Show("متاسفانه جستجوی شما در سیستم نتیجه ای در بر نداشت.", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvCustomers.Rows.Clear();
                }
            }
        }




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


        //جهت جلوگیری از کپی پیست و دور زدن قوانین برنامه
        private void AddContextMenuToTxtTell()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("لطفا اعداد را به صورت کپی پیست وارد نکنید.");
            //txtTell.TextBoxElement.TextBoxItem.HostedControl.ContextMenuStrip = menu;
            txtTell.ContextMenuStrip = menu;
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
        private void ویرایشاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);
            var frmAddEditCustomerInfo = new FrmAddEditCustomerInfo
            {
                CustomerId = customerId,
                IsEditMode = true,
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
                RtlMessageBox.Show("هیچ آیتمی برای ثبت رزرواسیون انتخاب نشده است.", "خطا - عدم انتخاب مشتری",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ثبتفاکتورToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmAddEditCustomer = new FrmAddEditCustomerInfo())
            {
                frmAddEditCustomer.IsEditMode = false;
                frmAddEditCustomer.CustomerId = 0;
                frmAddEditCustomer.JustSaveCustomerInfo = true;


                frmAddEditCustomer.ShowDialog();
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
                        frmAddEditCustomerInfo.IsEditMode = true;
                        frmAddEditCustomerInfo.JustSaveCustomerInfo = true;
                        if (frmAddEditCustomerInfo.ShowDialog() == DialogResult.OK)
                            btnSearch_Click(null, null);
                    }
                }
            }
            else
            {
                RtlMessageBox.Show("هیچ آیتمی برای ویرایش انتخاب نشده است.", "خطا - عدم انتخاب مشتری",
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
                RtlMessageBox.Show("هیچ اطلاعاتی برای جستجو وارد نشده است.", "خطا - عدم ورود اطلاعات مشتری",
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
    }
}
