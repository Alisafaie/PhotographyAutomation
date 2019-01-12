using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;

namespace PhotographyAutomation.App.Forms.Booking
{
    public partial class FrmAddEditCustomerInfo : Form
    {
        public FrmAddEditCustomerInfo()
        {
            InitializeComponent();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            FrmAddEditBooking frm = new FrmAddEditBooking();
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCheckNumber_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtMobileSearch.Text.Trim()))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobileSearch, "شماره موبایل وارد نشده است.");
                txtMobileSearch.Focus();
            }

            else if (txtMobileSearch.Text.Length < 10)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobileSearch, "شماره موبایل باید به صورت 10 رقمی (7890 345 912) وارد گردد.");
                txtMobileSearch.Focus();
            }
            else if (!txtMobileSearch.Text.StartsWith("9",StringComparison.InvariantCulture))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobileSearch, "شماره موبایل باید با عدد 9 شروع گردد.");
                txtMobileSearch.Focus();
            }
            else
            {
                errorProvider1.Clear();

                using (UnitOfWork db=new UnitOfWork())
                {
                    var user = db.UserRepository.FindUserByMobile(txtMobileSearch.Text);

                    if (user != null)
                    {
                        txtFirstName.Text = user.FirstName;
                        txtLastName.Text = user.LastName;

                        cmbGender.SelectedIndex = user.Gender == 0 ? 0 : 1;

                        txtBirthDate.Text = user.BirthDate.ToShortDateString();
                        txtNationalId.Text = user.NationalId;
                        txtTell.Text = user.Tell;
                        txtMobile.Text = user.Mobile;

                        cmbMarriedStatus.SelectedIndex = user.IsMarried == 0 ? 0 : 1;

                        if (cmbMarriedStatus.SelectedIndex == 1)
                            txtWeddingDate.Text = user.WeddingDate.ToShortDateString();
                        
                        cmbCustomerType.SelectedIndex = user.CustomerType == 0 ? 0 : 1;

                        cmbUserType.SelectedIndex = user.UserType == 0 ? 0 : 1;

                        if (cmbUserType.SelectedIndex == 1)
                        {
                            txtUserName.Text = user.Username;
                            
                            // TO DO
                            //txtRole.Text

                            cmbActiveStatus.SelectedIndex = user.IsActive == 0 ? 0 : 1;
                        }
                    }
                    else
                    {
                        RtlMessageBox.Show("متاسفانه کاربری با شماره همراه داده شده یافت نگردید.", "عدم وجود کاربر",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        groupBoxCustomerInfo.Enabled = true;
                        txtFirstName.Focus();

                    }

                }
            }

        }

        private void FrmAddEditCustomerInfo_Load(object sender, EventArgs e)
        {
            groupBoxCustomerInfo.Enabled = false;
            btnOk.Enabled = false;
        }
    }
}
