using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.Utilities.Regex;
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
            //groupBoxCustomerInfo.Enabled = false;
            btnOk.Enabled = false;
        }


        private void btnCheckNumber_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtMobileSearch.Text.Replace(" ", "")))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobileSearch, "شماره موبایل وارد نشده است.");
                txtMobileSearch.Focus();
            }
            else if (!txtMobileSearch.Text.StartsWith("9", StringComparison.InvariantCulture))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobileSearch, "شماره موبایل باید با عدد 9 شروع گردد.");
                txtMobileSearch.Focus();
            }
            else if (txtMobileSearch.Text.Replace(" ", "").Length < 10)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobileSearch, "شماره موبایل باید به صورت 10 رقمی (7890 345 912) وارد گردد.");
                txtMobileSearch.Focus();
            }
            else
            {
                errorProvider1.Clear();

                using (var db = new UnitOfWork())
                {
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
                        cmbActiveStatus.SelectedIndex = user.IsActive == 0 ? 0 : 1;


                        txtEmail.Text = user.Email;
                        txtAddress.Text = user.Address;

                        cmbActiveStatus.SelectedIndex = user.IsActive == 0 ? 0 : 1;
                    }
                    else
                    {
                        RtlMessageBox.Show("متاسفانه کاربری با شماره همراه داده شده یافت نگردید.", "عدم وجود کاربر",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtMobile.Text = txtMobileSearch.Text;

                        cmbUserType.SelectedIndex = 0;
                        cmbActiveStatus.SelectedIndex = 1;
                        cmbCustomerType.SelectedIndex = 0;
                        cmbGender.SelectedIndex = 0;
                        cmbMarriedStatus.SelectedIndex = 0;
                    }

                    //groupBoxCustomerInfo.Enabled = true;
                    //groupBoxSearchCustomer.Enabled = false;

                    AcceptButton = btnOk;

                    btnOk.Enabled = true;

                    txtFirstName.Focus();
                }
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                var user = new TblCustomer();

                user.FirstName = txtFirstName.Text.Trim();
                user.LastName = txtLastName.Text.Trim();
                user.Mobile = txtMobile.Text.Replace(" ", "").Trim();
                user.Tell = txtTell.Text.Replace(" ", "").Trim();
                user.Gender = Convert.ToByte(cmbGender.SelectedIndex == 0 ? 0 : 1);
                user.BirthDate = txtBirthDate.Text.ToMiladiDate();
                user.NationalId = txtNationalId.Text.Replace("-", "").Trim();
                user.IsMarried = Convert.ToByte(cmbMarriedStatus.SelectedIndex == 0 ? 0 : 1);
                user.CustomerType = Convert.ToByte(cmbCustomerType.SelectedIndex == 0 ? 0 : 1);
                user.Address = txtAddress.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.IsActive = Convert.ToByte(cmbActiveStatus.SelectedIndex == 0 ? 0 : 1);
                user.CreatedDate = DateTime.Now;
                user.IsDeleted = 0;


                if (cmbMarriedStatus.SelectedIndex == 1)
                    user.WeddingDate = txtWeddingDate.Text.ToMiladiDate();



                using (var db = new UnitOfWork())
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

                    int result = db.Save();
                    if (result > 0)
                    {
                        var f = new FrmAddEditBooking { CustomerId = user.Id };
                        f.ShowDialog();
                        DialogResult = DialogResult.OK;
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
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtFirstName, "نام مشتری وارد نشده است.");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLastName, "نام خانوادگی مشتری وارد نشده است.");
                txtLastName.Focus();
                return false;
            }

            if (cmbGender.SelectedIndex < 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbGender, "جنسیت مشتری مشتری مشخص نشده است.");
                cmbGender.ShowDropDown();
                cmbGender.Focus();
                return false;
            }


            if (txtBirthDate.Text != @"13  /  /  ")
            {
                if (DateTime.TryParse(txtBirthDate.Text, out _) == false)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtBirthDate, "تاریخ تولد مشتری به درستی وارد نشده است.");
                    txtBirthDate.Focus();
                    return false;
                }
            }


            if (txtTell.Text.Replace(" ", "") == @"313")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTell, "تلفن ثابت مشتری وارد نشده است.");
                txtTell.Focus();
                return false;
            }

            if (txtTell.Text.Replace(" ", "").Length > 3 && txtTell.Text.Replace(" ", "").Length < 10)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTell, "تلفن ثابت مشتری به درستی وارد نشده است.");
                txtTell.Focus();
                return false;
            }

            if (txtMobile.Text.Replace(" ", "").Length < 10 || !txtMobile.Text.StartsWith("9"))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobile, "تلفن همراه مشتری به درستی وارد نشده است.");
                txtMobile.Focus();
                return false;
            }

            if (cmbMarriedStatus.SelectedIndex == 1)
            {
                if (txtWeddingDate.Text != @"13  /  /")
                {
                    if (DateTime.TryParse(txtWeddingDate.Text, out _) == false)
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(txtWeddingDate, "تاریخ ازدواج مشتری به درستی وارد نشده است.");
                        txtWeddingDate.Focus();
                        return false;
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && !txtEmail.Text.IsValidEmail())
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmail, "ایمیل مشتری به درستی وارد نشده است.");
                txtEmail.Focus();
                return false;
            }

            try
            {
                if (!string.IsNullOrEmpty(txtNationalId.Text.Replace("-", "").Trim()) &&
                    txtNationalId.Text.Replace("-", "").Trim().Length > 1 &&
                    txtNationalId.Text.Replace("-", "").Trim().Length < 10 &&
                    !txtNationalId.Text.Replace("-", "").Trim().IsValidNationalCode())
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNationalId, "کد ملی مشتری به درستی وارد نشده است.");
                    txtNationalId.Focus();
                    return false;
                }
            }
            catch (Exception exception)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNationalId, exception.Message);
                //RtlMessageBox.Show(exception.Message, "خطا در ورود اطلاعات");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            FrmSearchCustomer searchUser = new FrmSearchCustomer();
            searchUser.ShowDialog();
        }
    }
}
