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
            timePickerBookingTime.Value = DateTime.Now;


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
                if (timePickerBookingTime.Value != null)
                {
                    TblBooking booking = new TblBooking
                    {
                        UserId = UserId,
                        AtelierTypeId = (int)cmbAtelierTypes.SelectedValue,
                        CreatedDate = DateTime.Now,
                        Date = datePickerBookingDate.Value,
                        PersonCount = (int)txtPersonCount.Value,
                        PhotographyTypeId = (int)cmbPhotographyTypes.SelectedValue
                    };

                    if (timePickerBookingTime.Value != null)
                        booking.Time =
                            new TimeSpan(0, timePickerBookingTime.Value.Value.Hour, timePickerBookingTime.Value.Value.Minute, 0);

                    booking.PrepaymentIsOk = 0;


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
                errorProvider1.SetError(txtPersonCount, "تعداد نفرات مربوط به نوبت، می بایست حداقل یک نفر باشد.");
                txtPersonCount.Focus();
                return false;
            }

            if (rbFemalePhotographer.Checked == false && rbMalePhotographer.Checked == false && rbNoMatterPhotographer.Checked == false)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(panelPhotographerTypes, "نوع عکاس نوبت انتخاب نشده است.");
                panelPhotographerTypes.Focus();
                return false;
            }

            return true;
        }

        private void cmbPhotographyTypes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //1	10	پرسنلی
            //2	20	کودک
            //3	30	خانوادگی
            //4	40	نامزدی
            //5	50	جشن

            //1	10	آتلیه پرسنلی
            //2	20	آتلیه هنری
            //3	30	آتلیه کودک
            //4	40	فضای باز سرو

            switch (cmbPhotographyTypes.SelectedValue)
            {
                case 1:
                    cmbAtelierTypes.SelectedValue = 1;
                    break;
                case 2:
                    cmbAtelierTypes.SelectedValue = 3;
                    break;
                case 3:
                    cmbAtelierTypes.SelectedValue = 2;
                    break;
                case 4:
                    cmbAtelierTypes.SelectedValue = 2;
                    break;
                case 5:
                    cmbAtelierTypes.SelectedValue = 2;
                    break;
            }
        }
    }
}
