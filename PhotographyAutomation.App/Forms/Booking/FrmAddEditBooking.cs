using FreeControls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Booking
{
    public partial class FrmAddEditBooking : Form
    {
        public int CustomerId = 0;
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
                UserInfoBookingViewModel userInfo = new UserInfoBookingViewModel();
                if (CustomerId > 0)
                    userInfo = db.UserRepository.GetCustomerInfoBooking(CustomerId);
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

                dgvBookingHistory.AutoGenerateColumns = false;

                var bookingHistory = db.BookingRepository.GetCustomerBookingHistory(CustomerId);

                if (bookingHistory.Count > 0)
                {
                    dgvBookingHistory.RowCount = bookingHistory.Count;
                    dgvBookingHistory.DataSource = bookingHistory;

                    for (int i = 0; i < bookingHistory.Count; i++)
                    {
                        dgvBookingHistory.Rows[i].Cells["clmId"].Value = bookingHistory[i].Id;
                        dgvBookingHistory.Rows[i].Cells["clmUserId"].Value = bookingHistory[i].UserId;

                        if (bookingHistory[i].CustomerGender == 0)
                        {
                            dgvBookingHistory.Rows[i].Cells["clmCustomerFullName"].Value =
                                "خانم " + bookingHistory[i].CustomerFullName;

                        }
                        else if (bookingHistory[i].CustomerGender == 1)
                        {
                            dgvBookingHistory.Rows[i].Cells["clmCustomerFullName"].Value =
                                "آقای " + bookingHistory[i].CustomerFullName;
                        }
                        else
                        {
                            dgvBookingHistory.Rows[i].Cells["clmCustomerFullName"].Value =
                                bookingHistory[i].CustomerFullName;
                        }

                        dgvBookingHistory.Rows[i].Cells["clmDate"].Value = bookingHistory[i].Date.ToShamsiDate();
                        dgvBookingHistory.Rows[i].Cells["clmDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvBookingHistory.Rows[i].Cells["clmTime"].Value = bookingHistory[i].Time;

                        dgvBookingHistory.Rows[i].Cells["clmTime"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvBookingHistory.Rows[i].Cells["clmPhotographerGender"].Value =
                            bookingHistory[i].PhotographerGender;

                        switch (bookingHistory[i].PhotographerGender)
                        {
                            case 0:
                                dgvBookingHistory.Rows[i].Cells["clmPhotographerGenderName"].Value = "خانم";
                                break;
                            case 1:
                                dgvBookingHistory.Rows[i].Cells["clmPhotographerGenderName"].Value = "آقا";
                                break;
                            default:
                                dgvBookingHistory.Rows[i].Cells["clmPhotographerGenderName"].Value = "فرقی ندارد";
                                break;
                        }

                        dgvBookingHistory.Rows[i].Cells["clmPhotographyTypeId"].Value =
                            bookingHistory[i].PhotographyTypeId;
                        dgvBookingHistory.Rows[i].Cells["clmPhotographyTypeName"].Value =
                            bookingHistory[i].PhotographyTypeName;
                        dgvBookingHistory.Rows[i].Cells["clmAtelierTypeId"].Value = bookingHistory[i].AtelierTypeId;
                        dgvBookingHistory.Rows[i].Cells["clmAtelierTypeName"].Value = bookingHistory[i].AtelierTypeName;
                        dgvBookingHistory.Rows[i].Cells["clmPersonCount"].Value = bookingHistory[i].PersonCount;
                        dgvBookingHistory.Rows[i].Cells["clmPaymentIsOK"].Value = bookingHistory[i].PaymentIsOk;
                        dgvBookingHistory.Rows[i].Cells["clmSubmitter"].Value = bookingHistory[i].Submitter;
                        dgvBookingHistory.Rows[i].Cells["clmSubmitterName"].Value = bookingHistory[i].SubmitterName;
                        dgvBookingHistory.Rows[i].Cells["clmStatusId"].Value = bookingHistory[i].StatusId;
                        dgvBookingHistory.Rows[i].Cells["clmStatusName"].Value = bookingHistory[i].StatusName;
                        dgvBookingHistory.Rows[i].Cells["clmCreatedDateTime"].Value = bookingHistory[i].CreatedDateTime;
                        dgvBookingHistory.Rows[i].Cells["clmModifiedDateTime"].Value =
                            bookingHistory[i].ModifiedDateTime;
                    }
                }

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
                        CustomerId = CustomerId,
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
                            db.BookingGenericRepository.Insert(booking);
                        else
                        {
                            booking.Id = BookingId;
                            db.BookingGenericRepository.Update(booking);
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
                timePickerBookingTime.Value.Value.Hour < 9)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(timePickerBookingTime, "زمان نوبت انتخابی قبل از شروع به کار مجموعه است.");
                timePickerBookingTime.Focus();
                return false;
            }

            if (timePickerBookingTime.Value != null &&
                timePickerBookingTime.Value.Value.Hour >= 20)
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
