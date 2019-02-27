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
    public partial class FrmSearchCustomer : Form
    {
        public bool FromFrmAddEditBooking = false;
        public bool FromFrmShowBookings = false;
        public int CustomerId = 0;
        
        public FrmSearchCustomer()
        {
            InitializeComponent();
        }

        private void FrmSearchCustomer_Load(object sender, EventArgs e)
        {
            AddContextMenuToTxtTell();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvUsers.Rows.Clear();

            using (var db = new UnitOfWork())
            {
                List<TblCustomer> users = db.UserGenericRepository.Get(
                    x =>
                        x.FirstName.Contains(txtFirstName.Text.Trim()) ||
                        x.LastName.Contains(txtLastName.Text.Trim()) ||
                        x.Tell.Contains(txtTell.Text.Trim()) ||
                        x.Mobile.Contains(txtTell.Text.Trim())
                        )
                    .ToList();

                dgvUsers.AutoGenerateColumns = false;

                if (users.Any())
                {
                    dgvUsers.Rows.Clear();
                    dgvUsers.RowCount = users.Count;

                    for (int i = 0; i < users.Count; i++)
                    {
                        dgvUsers.Rows[i].Cells["Id"].Value = users[i].Id;
                        dgvUsers.Rows[i].Cells["FirstName"].Value = users[i].FirstName;
                        dgvUsers.Rows[i].Cells["LastName"].Value = users[i].LastName;
                        dgvUsers.Rows[i].Cells["Tell"].Value = users[i].Tell;
                        dgvUsers.Rows[i].Cells["Tell"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["Mobile"].Value = "0" + users[i].Mobile;
                        dgvUsers.Rows[i].Cells["Mobile"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["Email"].Value = users[i].Email;
                        dgvUsers.Rows[i].Cells["Email"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["NationalId"].Value = users[i].NationalId;
                        dgvUsers.Rows[i].Cells["NationalId"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        var createdDate = users[i].CreatedDate;
                        if (createdDate != null)
                            dgvUsers.Rows[i].Cells["CreatedDate"].Value =
                                createdDate.Value.ToString("HH:mm") + "   " +
                                createdDate.Value.Date.ToShortDateString();

                        dgvUsers.Rows[i].Cells["CreatedDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        var modifiedDate = users[i].ModifiedDate;
                        if (modifiedDate != null)
                            dgvUsers.Rows[i].Cells["CreatedDate"].Value =
                                modifiedDate.Value.ToString("HH:mm") + "   " +
                                modifiedDate.Value.Date.ToShortDateString();

                        dgvUsers.Rows[i].Cells["CreatedDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["MoreInfo"].Value = "...";
                    }

                    dgvUsers.ClearSelection();
                }
                else
                {
                    RtlMessageBox.Show("متاسفانه جستجوی شما در سیستم نتیجه ای در بر نداشت.", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUsers.Rows.Clear();
                }
            }
        }




        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int moreInfoCellIndex = dgvUsers.CurrentRow.Cells["MoreInfo"].ColumnIndex;
                if (dgvUsers.CurrentCell.ColumnIndex.Equals(moreInfoCellIndex) && e.RowIndex != -1)
                {
                    if (dgvUsers.CurrentCell != null && dgvUsers.CurrentCell.Value != null)
                    {
                        var customerId = (int)dgvUsers.CurrentRow.Cells["Id"].Value;
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
            txtTell.TextBoxElement.TextBoxItem.HostedControl.ContextMenuStrip = menu;
        }

        private void btnShowAllCustomers_Click(object sender, EventArgs e)
        {
            dgvUsers.Rows.Clear();

            using (var db = new UnitOfWork())
            {
                List<TblCustomer> users = db.UserGenericRepository.Get().ToList();

                dgvUsers.AutoGenerateColumns = false;

                if (users.Any())
                {
                    dgvUsers.Rows.Clear();
                    dgvUsers.RowCount = users.Count;

                    for (int i = 0; i < users.Count; i++)
                    {
                        dgvUsers.Rows[i].Cells["Id"].Value = users[i].Id;
                        dgvUsers.Rows[i].Cells["FirstName"].Value = users[i].FirstName;
                        dgvUsers.Rows[i].Cells["LastName"].Value = users[i].LastName;
                        dgvUsers.Rows[i].Cells["Tell"].Value = users[i].Tell;
                        dgvUsers.Rows[i].Cells["Tell"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["Mobile"].Value = "0" + users[i].Mobile;
                        dgvUsers.Rows[i].Cells["Mobile"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["Email"].Value = users[i].Email;
                        dgvUsers.Rows[i].Cells["Email"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["NationalId"].Value = users[i].NationalId;
                        dgvUsers.Rows[i].Cells["NationalId"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        var createdDate = users[i].CreatedDate;
                        if (createdDate != null)
                            dgvUsers.Rows[i].Cells["CreatedDate"].Value =
                                createdDate.Value.ToString("HH:mm") + "   " +
                                createdDate.Value.Date.ToShortDateString();

                        dgvUsers.Rows[i].Cells["CreatedDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        var modifiedDate = users[i].ModifiedDate;
                        if (modifiedDate != null)
                            dgvUsers.Rows[i].Cells["CreatedDate"].Value =
                                modifiedDate.Value.ToString("HH:mm") + "   " +
                                modifiedDate.Value.Date.ToShortDateString();

                        dgvUsers.Rows[i].Cells["CreatedDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvUsers.Rows[i].Cells["MoreInfo"].Value = "...";
                    }
                }
                else
                {
                    RtlMessageBox.Show("متاسفانه جستجوی شما در سیستم نتیجه ای در بر نداشت.", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUsers.Rows.Clear();
                }
            }
        }

        private void dgvUsers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvUsers.Rows.Count > 0)
                {
                    int currentMouseOverRow = dgvUsers.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow > -1)
                        dgvUsers.Rows[currentMouseOverRow].Selected = true;
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
    }
}
