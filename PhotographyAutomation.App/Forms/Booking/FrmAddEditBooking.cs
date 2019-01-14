using FreeControls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Booking
{
    public partial class FrmAddEditBooking : Form
    {
        public int UserId = 0;
        public int BookingId = 0;

        public FrmAddEditBooking()
        {
            InitializeComponent();
        }

        private void FrmAddEditBooking_Load(object sender, EventArgs e)
        {
            datePickerBookingDate.Value = PersianDate.Now;
            datePickerPayment.Value = PersianDate.Now;

            timePickerBookingTime.Value = DateTime.Now;
            timePickerPayment.Value = DateTime.Now;

            txtPersonCount.Value = 1;

            txtBookingStatus.Text = @"در انتظار پرداخت";

            using (var db = new UnitOfWork())
            {
                UserInfoBookingViewModel userInfo = db.UserRepository.GetCustomerInfoBooking(UserId);
                if (userInfo != null)
                {
                    txtFirstNameLastName.Text = userInfo.FirstName + @" " + userInfo.LastName;
                    txtMobile.Text = @"0" + userInfo.Mobile;
                    txtTell.Text = @"0" + userInfo.Tell;
                }
                else
                {
                    RtlMessageBox.Show("اطلاعات مشتری قابل دریافت نمی باشد.", "خطا در دریافت اطلاعات مشتری",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                }

                PopulateComboBoxes();

            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PopulateComboBoxes()
        {
            using (var db = new UnitOfWork())
            {
                cmbAtelierTypes.DataSource = db.AtelierTypesGenericRepository.Get().OrderBy(x => x.Code).ToList();
                cmbAtelierTypes.DisplayMember = "AtelierName";
                cmbAtelierTypes.ValueMember = "Id";

                cmbPhotographyTypes.DataSource =
                    db.PhotographyTypesGenericRepository.Get().OrderBy(x => x.Code).ToList();
                cmbPhotographyTypes.DisplayMember = "TypeName";
                cmbPhotographyTypes.ValueMember = "Id";


                cmbPhotographyTypes.DataSource =
                    db.PhotographyTypesGenericRepository.Get().OrderBy(x => x.Code).ToList();
                cmbPhotographyTypes.DisplayMember = "TypeName";
                cmbPhotographyTypes.ValueMember = "Id";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                if (timePickerPayment.Value != null)
                {
                    var booking = new TblBooking
                    {
                        UserId = UserId,
                        AtelierTypeId = (int)cmbAtelierTypes.SelectedValue,
                        CreatedDate = DateTime.Now,
                        Date = datePickerBookingDate.Value,
                        PersonCount = (int)txtPersonCount.Value,
                        PhotographyTypeId = (int)cmbPhotographyTypes.SelectedValue,
                        Time = TimeSpan.Parse(timePickerPayment.Value.Value.ToShortTimeString()),
                        PrepaymentIsOk = 0
                    };

                    if (rbFemalePhotographer.Checked)
                    {
                        booking.PhotographerGender = 0;
                    }
                    else if (rbMalePhotographer.Checked)
                    {
                        booking.PhotographerGender = 1;
                    }
                    else
                    {
                        booking.PhotographerGender = 2;
                    }


                    using (var db = new UnitOfWork())
                    {
                        if (BookingId == 0)
                        {
                            db.BookingRepository.Insert(booking);
                        }
                        else
                        {
                            booking.Id = BookingId;
                            db.BookingRepository.Update(booking);
                        }

                        int result = db.Save();
                        if (result > 0)
                        {
                            RtlMessageBox.Show("نوبت مشتری با موفقیت در سیستم ثبت گردید.", "ثبت اطلاعات در سیستم",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
        }

        private bool CheckInputs()
        {
            if (datePickerBookingDate.Value.Year != PersianDate.Now.Year)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(datePickerBookingDate, "نوبت مورد مورد نظر می بایست در سال جاری باشد.");
                datePickerBookingDate.Focus();
                return false;
            }
            if (datePickerBookingDate.Value.Month < PersianDate.Now.Month)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(datePickerBookingDate, "تاریخ نوبت انتخابی می بایست ماه جاری و یا آینده باشد.");
                datePickerBookingDate.Focus();
                return false;
            }
            if (datePickerBookingDate.Value.Month == PersianDate.Now.Month &&
                     datePickerBookingDate.Value.Day < PersianDate.Now.Day)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(datePickerBookingDate, "روز نوبت انتخاب شده نمی تواند قبل از روز جاری باشد.");
                return false;
            }

            if (timePickerBookingTime.Value != null &&
                (timePickerBookingTime.Value.Value.Hour < 9))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(timePickerBookingTime, "زمان نوبت انتخابی قبل از شروع به کار مجموعه است.");
                timePickerBookingTime.Focus();
                return false;
            }

            if (timePickerBookingTime.Value != null &&
                (timePickerBookingTime.Value.Value.Hour >= 20))
                if (timePickerBookingTime.Value.Value.Hour >= 21)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(timePickerBookingTime, "زمان نوبت انتخابی بعد از ساعت کاری مجموعه است.");
                    timePickerBookingTime.Focus();
                    return false;
                }
                else if (timePickerBookingTime.Value != null && timePickerBookingTime.Value.Value.Minute >= 30)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(timePickerBookingTime, "امکان ثبت زمان نوبت بعد از ساعت 20:30 امکان پذیر نمی باشد.");
                    timePickerBookingTime.Focus();
                    return false;
                }


            if (txtPersonCount.Value == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPersonCount,"تعداد نفرات مربوط به نوبت، می بایست حداقل یک نفر باشد.");
                txtPersonCount.Focus();
                return false;
            }

            if (!rbFemalePhotographer.Checked && !rbMalePhotographer.Checked && !rbNoMatterPhotographer.Checked)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(panelPhotographerTypes,"نوع عکاس نوبت انتخاب نشده است.");
                panelPhotographerTypes.Focus();
                return false;
            }

            return true;
        }

        private void txtPaymentDescription_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void txtPaymentDescription_Leave(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }
    }
}
