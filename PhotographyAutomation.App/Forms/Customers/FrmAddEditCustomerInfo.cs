using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.Utilities.Regex;
using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Customers
{
    public partial class FrmAddEditCustomerInfo : Form
    {
        public int CustomerId;
        public bool JustSaveCustomerInfo = false;
        public bool IsEditMode = false;
        public FrmAddEditCustomerInfo()
        {
            InitializeComponent();
        }

        private void FrmAddEditCustomerInfo_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                GetCustomerInfo(CustomerId);
                txtMobileSearch.Enabled = false;
                btnCheckNumber.Enabled = false;

                return;
            }
            btnOk.Enabled = false;
            this.AcceptButton = btnCheckNumber;
        }

        private void GetCustomerInfo(int customerId)
        {
            if (customerId > 0)
            {
                using (var db = new UnitOfWork())
                {
                    var customer = db.CustomerGenericRepository.GetById(customerId);
                    if (customer != null)
                    {
                        txtFirstName.Text = customer.FirstName;
                        txtLastName.Text = customer.LastName;
                        txtMobile.Text = txtMobileSearch.Text = customer.Mobile;
                        txtTell.Text = customer.Tell;
                        cmbGender.SelectedIndex = customer.Gender == 0 ? 0 : 1;
                        if (customer.BirthDate != null) txtBirthDate.Text = customer.BirthDate.Value.ToShamsiDate();
                        txtNationalId.Text = customer.NationalId;
                        cmbMarriedStatus.SelectedIndex = customer.IsMarried == 0 ? 0 : 1;
                        txtAddress.Text = customer.Address;
                        txtEmail.Text = customer.Email;
                    }
                }
            }
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
                    var user = db.CustomerRepository.FindCustomersByMobile(txtMobileSearch.Text.Replace(" ", ""));

                    if (user != null)
                    {
                        CustomerId = user.Id;
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

                        txtEmail.Text = user.Email;
                        txtAddress.Text = user.Address;
                    }
                    else
                    {
                        RtlMessageBox.Show("متاسفانه کاربری با شماره همراه داده شده یافت نگردید.", "عدم وجود کاربر",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtMobile.Text = txtMobileSearch.Text;

                        cmbGender.SelectedIndex = 0;
                        cmbMarriedStatus.SelectedIndex = 0;
                    }

                    //groupBoxCustomerInfo.Enabled = true;
                    //groupBoxSearchCustomer.Enabled = false;

                    AcceptButton = btnOk;

                    btnOk.Enabled = true;

                    txtFirstName.Focus();
                    this.AcceptButton = btnOk;
                }
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckInputs()) return;
            var customer = new TblCustomer
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Mobile = txtMobile.Text.Replace(" ", "").Trim(),
                Tell = txtTell.Text.Replace(" ", "").Trim(),
                Gender = Convert.ToByte(cmbGender.SelectedIndex == 0 ? 0 : 1),
                BirthDate = txtBirthDate.Text.ToMiladiDate(),
                NationalId = txtNationalId.Text.Replace("-", "").Trim(),
                IsMarried = Convert.ToByte(cmbMarriedStatus.SelectedIndex == 0 ? 0 : 1),
                Address = txtAddress.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                IsDeleted = 0
            };


            //if (cmbMarriedStatus.SelectedIndex == 1)
            //{
            //    if (txtWeddingDate.Text == @"13  /  /" || txtWeddingDate.Text.ToMiladiDate() == null)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtWeddingDate, "تاریخ ازدواج به درستی مشخص نشده است.");
            //        return;
            //    }

            //    customer.WeddingDate = txtWeddingDate.Text.ToMiladiDate();
            //}

            using (var db = new UnitOfWork())
            {
                var checkCustomerMobileNumber = db.CustomerRepository.GetCustomerByMobile(customer.Mobile);

                if (CustomerId == 0 && IsEditMode == false)
                {
                    if (checkCustomerMobileNumber != null)
                    {
                        RtlMessageBox.Show("این شماره موبایل قبلا برای کاربر دیگری ثبت شده است.", "خطا در ورود اطلاعات",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMobile.Focus();
                    }

                    customer.CreatedDate = DateTime.Now;
                    db.CustomerGenericRepository.Insert(customer);
                }
                else
                {
                    if (checkCustomerMobileNumber != null)
                    {
                        if (checkCustomerMobileNumber.Id == CustomerId)
                        {
                            customer.Id = CustomerId;
                            customer.ModifiedDate = DateTime.Now;
                            db.CustomerGenericRepository.Update(customer);
                        }
                        else
                        {
                            RtlMessageBox.Show("این شماره موبایل قبلا برای کاربر دیگری ثبت شده است.",
                                "خطا در ورود اطلاعات",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMobile.Focus();
                        }
                    }
                    else
                    {
                        customer.Id = CustomerId;
                        customer.ModifiedDate = DateTime.Now;
                        db.CustomerGenericRepository.Update(customer);
                    }
                }

                int result = db.Save();
                if (result > 0)
                {
                    if (JustSaveCustomerInfo == false)
                    {
                        using (var f = new FrmAddEditBooking())
                        {
                            f.CustomerId = customer.Id;
                            f.ShowDialog();
                        }
                    }

                    DialogResult = DialogResult.OK;
                }
                else
                    RtlMessageBox.Show("خطا در ثبت اطلاعات کاربر", "خطا در ثبت اطلاعات", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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


            //if (txtBirthDate.Text != @"13  /  /  ")
            //{
            //    if (DateTime.TryParse(txtBirthDate.Text, out _) == false)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtBirthDate, "تاریخ تولد مشتری به درستی وارد نشده است.");
            //        txtBirthDate.Focus();
            //        return false;
            //    }
            //}


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

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            FrmShowCustomer searchUser = new FrmShowCustomer();
            searchUser.ShowDialog();
        }
    }
}
