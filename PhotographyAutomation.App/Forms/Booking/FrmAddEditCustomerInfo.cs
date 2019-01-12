using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Booking
{
    public partial class FrmAddEditCustomerInfo : Form
    {
        public int UserId;
        public FrmAddEditCustomerInfo()
        {
            InitializeComponent();
        }

        private void FrmAddEditCustomerInfo_Load(object sender, EventArgs e)
        {
            groupBoxCustomerInfo.Enabled = false;
            btnOk.Enabled = false;
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
            else if (!txtMobileSearch.Text.StartsWith("9", StringComparison.InvariantCulture))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobileSearch, "شماره موبایل باید با عدد 9 شروع گردد.");
                txtMobileSearch.Focus();
            }
            else
            {
                errorProvider1.Clear();

                using (UnitOfWork db = new UnitOfWork())
                {
                    //string mobile = txtMobileSearch.Text.Replace(" ", "");
                    var user = db.UserRepository.FindUserByMobile(txtMobileSearch.Text.Replace(" ", ""));

                    if (user != null)
                    {
                        UserId = user.Id;
                        txtFirstName.Text = user.FirstName;
                        txtLastName.Text = user.LastName;

                        cmbGender.SelectedIndex = user.Gender == 0 ? 0 : 1;

                        if (user.BirthDate != null) txtBirthDate.Text = user.BirthDate.Value.ToShamsiDate();
                        txtNationalId.Text = user.NationalId;
                        txtTell.Text = user.Tell;
                        txtMobile.Text = user.Mobile;

                        cmbMarriedStatus.SelectedIndex = user.IsMarried == 0 ? 0 : 1;

                        if (cmbMarriedStatus.SelectedIndex == 1)
                            if (user.WeddingDate != null)
                                txtWeddingDate.Text = user.WeddingDate.Value.ToShamsiDate();

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
                        txtMobile.Text = txtMobileSearch.Text;
                        txtFirstName.Focus();

                        cmbUserType.SelectedIndex = 0;
                        cmbActiveStatus.SelectedIndex = 1;
                        cmbCustomerType.SelectedIndex = 0;
                        cmbGender.SelectedIndex = 0;
                        cmbMarriedStatus.SelectedIndex = 0;
                    }

                    btnOk.Enabled = true;
                }
            }

        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                TblUser user = new TblUser
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Mobile = txtMobile.Text.Replace(" ","").Trim(),
                    Tell = txtTell.Text.Replace(" ","").Trim(),
                    Gender = Convert.ToByte(cmbGender.SelectedIndex == 0 ? 0 : 1),
                    BirthDate = txtBirthDate.Text.ToMiladiDate(),
                    NationalId = txtNationalId.Text.Replace("-","").Trim(),
                    IsMarried = Convert.ToByte(cmbMarriedStatus.SelectedIndex == 0 ? 0 : 1),
                    CustomerType = Convert.ToByte(cmbCustomerType.SelectedIndex == 0 ? 0 : 1),
                    UserType = Convert.ToByte(cmbUserType.SelectedIndex == 0 ? 0 : 1),
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    IsActive = Convert.ToByte(cmbActiveStatus.SelectedIndex==0?0:1),
                    CreatedDate = DateTime.Now,
                    IsDeleted = 0
                    };

                if (cmbMarriedStatus.SelectedIndex == 1)
                    user.WeddingDate = txtWeddingDate.Text.ToMiladiDate();

                if (cmbUserType.SelectedIndex == 1)
                    user.Username = txtUserName.Text;

                using (UnitOfWork db = new UnitOfWork())
                {
                    if (UserId == 0)
                    {
                        db.UserGenericRepository.Insert(user);
                    }
                    else
                    {
                        user.Id = UserId;
                        db.UserGenericRepository.Update(user);
                    }

                    bool result = db.Save();
                    if (result)
                    {
                        FrmAddEditBooking f = new FrmAddEditBooking();
                        f.ShowDialog();
                    }
                    else
                    {
                        RtlMessageBox.Show("خطا در ثبت اطلاعات کاربر", "خطا در ثبت اطلاعات", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool CheckInputs()
        {
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
