using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
        public int BookingId;

        public bool IsViewOnly = false;

        public int BookingHour { get; private set; }
        public int BookingMinute { get; private set; }


        public FrmAddEditBooking()
        {
            InitializeComponent();
        }

        private void FrmAddEditBooking_Load(object sender, EventArgs e)
        {
            Text = BookingId == 0 ? "ثبت نوبت" : "ویرایش نوبت";
            btnOk.Text = BookingId == 0 ? "ثبت نوبت" : "ویرایش نوبت";

            datePickerBookingDate.Value = PersianDate.Now;
            //timePickerBookingTime.Value = DateTime.Now;


            txtPersonCount.Value = 1;

            txtBookingStatus.Text = "در انتظار بیعانه";

            using (var db = new UnitOfWork())
            {
                GetCustomerInfo(db);

                PopulateComboBoxes();

                GetCustomerBookingHistory(db);

                cmbPhotographerGender.SelectedIndex = 0;

                if (BookingId > 0)
                {
                    var booking = db.BookingGenericRepository.GetById(BookingId);
                    if (booking != null)
                    {
                        switch (booking.PhotographerGender)
                        {
                            case 0:
                                cmbPhotographerGender.SelectedIndex = 0;
                                break;
                            case 1:
                                cmbPhotographerGender.SelectedIndex = 1;
                                break;
                            case 2:
                                cmbPhotographerGender.SelectedIndex = 2;
                                break;
                        }


                        datePickerBookingDate.Value = booking.Date.Date;
                        //var dt = new DateTime(booking.Date.Year, booking.Date.Month, booking.Date.Day, booking.Time.Hours, booking.Time.Minutes, booking.Time.Seconds);
                        txtBookingTime.Text = booking.Time.ToShortTimeString();
                        cmbPhotographyTypes.SelectedValue = booking.PhotographyTypeId;
                        cmbAtelierTypes.SelectedValue = booking.AtelierTypeId;
                        txtPersonCount.Value = booking.PersonCount;
                        txtBookingStatus.Text = booking.TblBookingStatus.StatusName;

                        if (IsViewOnly)
                        {
                            foreach (Control control in groupBoxBookingInfo.Controls)
                            {
                                if (control is PersianDateTimePicker dateTimePicker)
                                {
                                    dateTimePicker.Enabled = false;
                                }

                                if (control is TextBoxX textBoxX)
                                {
                                    textBoxX.Enabled = false;
                                }

                                if (control is Button button)
                                {
                                    button.Enabled = false;
                                }

                                if (control is DevComponents.Editors.IntegerInput integerInput)
                                {
                                    integerInput.Enabled = false;
                                }

                                if (control is ComboBoxEx comboBoxEx)
                                {
                                    comboBoxEx.Enabled = false;
                                    comboBoxEx.DropDownStyle = ComboBoxStyle.Simple;
                                }
                            }

                            foreach (Control control in panelEx1.Controls)
                            {
                                if (control is ButtonX buttonX)
                                {
                                    buttonX.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
            dgvBookingHistory.ClearSelection();
        }

        private void GetCustomerBookingHistory(UnitOfWork db)
        {
            dgvBookingHistory.AutoGenerateColumns = false;

            var bookingHistory = db.BookingRepository.GetCustomerBookingHistory(CustomerId);

            if (bookingHistory.Count > 0)
            {
                dgvBookingHistory.Rows.Clear();
                dgvBookingHistory.RowCount = bookingHistory.Count;
                dgvBookingHistory.DataSource = bookingHistory;

                for (var i = 0; i < bookingHistory.Count; i++)
                {
                    dgvBookingHistory.Rows[i].Cells["clmId"].Value = bookingHistory[i].Id;
                    dgvBookingHistory.Rows[i].Cells["clmUserId"].Value = bookingHistory[i].CustomerId;

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

                    dgvBookingHistory.Rows[i].Cells["clmDate"].Value =
                        bookingHistory[i].Date.ToShamsiDate();
                    dgvBookingHistory.Rows[i].Cells["clmDate"].Style.Alignment =
                        DataGridViewContentAlignment.MiddleRight;

                    dgvBookingHistory.Rows[i].Cells["clmTime"].Value =
                        bookingHistory[i].Time.Hours.ToString("00") + ":" +
                        bookingHistory[i].Time.Minutes.ToString("00");

                    dgvBookingHistory.Rows[i].Cells["clmTime"].Style.Alignment =
                        DataGridViewContentAlignment.MiddleRight;

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

                    dgvBookingHistory.Rows[i].Cells["clmAtelierTypeId"].Value =
                        bookingHistory[i].AtelierTypeId;

                    dgvBookingHistory.Rows[i].Cells["clmAtelierTypeName"].Value =
                        bookingHistory[i].AtelierTypeName;

                    dgvBookingHistory.Rows[i].Cells["clmPersonCount"].Value =
                        bookingHistory[i].PersonCount;

                    dgvBookingHistory.Rows[i].Cells["clmPaymentIsOK"].Value =
                        bookingHistory[i].PaymentIsOk;

                    dgvBookingHistory.Rows[i].Cells["clmSubmitter"].Value =
                        bookingHistory[i].Submitter;

                    dgvBookingHistory.Rows[i].Cells["clmSubmitterName"].Value =
                        bookingHistory[i].SubmitterName;

                    dgvBookingHistory.Rows[i].Cells["clmStatusId"].Value =
                        bookingHistory[i].StatusId;

                    dgvBookingHistory.Rows[i].Cells["clmStatusName"].Value =
                        bookingHistory[i].StatusName;

                    dgvBookingHistory.Rows[i].Cells["clmCreatedDateTime"].Value =
                        bookingHistory[i].CreatedDateTime;

                    dgvBookingHistory.Rows[i].Cells["clmModifiedDateTime"].Value =
                        bookingHistory[i].ModifiedDateTime;
                }
            }
        }

        private void GetCustomerInfo(UnitOfWork db)
        {
            var userInfo = new UserInfoBookingViewModel();
            if (CustomerId > 0)
                userInfo = db.CustomerRepository.GetCustomerInfoBooking(CustomerId);
            if (userInfo != null)
            {
                txtFirstNameLastName.Text = userInfo.FirstName + " " + userInfo.LastName;
                txtMobile.Text = @"0" + userInfo.Mobile;
                txtTell.Text = @"0" + userInfo.Tell;
            }
            else
            {
                MessageBox.Show("اطلاعات مشتری قابل دریافت نمی باشد.", "خطا در دریافت اطلاعات مشتری",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }


        private void PopulateComboBoxes()
        {
            using (var db = new UnitOfWork())
            {
                cmbPhotographyTypes.DataSource =
                    db.PhotographyTypesGenericRepository.Get().OrderBy(x => x.Code).ToList();

                if (cmbPhotographyTypes.DataSource != null)
                {
                    cmbPhotographyTypes.DisplayMember = "TypeName";
                    cmbPhotographyTypes.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("اطلاعات انواع عکس ها از سیستم قابل دریافت نمی باشد.",
                        "خطا در دریافت اطلاعات از سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                }


                cmbAtelierTypes.DataSource = db.AtelierTypesGenericRepository.Get().OrderBy(x => x.Code).ToList();
                if (cmbAtelierTypes.DataSource != null)
                {
                    cmbAtelierTypes.DisplayMember = "AtelierName";
                    cmbAtelierTypes.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("اطلاعات انواع آتلیه ها از سیستم قابل دریافت نمی باشد.",
                        "خطا در دریافت اطلاعات از سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                }
            }
            //foreach (ComboItem item in cmbPhotographyTypes.Items)
            //{
            //    item.TextAlignment = StringAlignment.Near;
            //    //item.TextLineAlignment = StringAlignment.Center;

            //}
            //foreach (ComboItem item in cmbAtelierTypes.Items)
            //{
            //    item.TextAlignment = StringAlignment.Near;
            //    //item.TextLineAlignment = StringAlignment.Far;
            //}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                var booking = new TblBooking
                {
                    CustomerId = CustomerId,
                    AtelierTypeId = (int)cmbAtelierTypes.SelectedValue,
                    CreatedDate = DateTime.Now,
                    Date = datePickerBookingDate.Value,
                    PersonCount = txtPersonCount.Value,
                    PhotographyTypeId = (int)cmbPhotographyTypes.SelectedValue,
                    StatusId = 6
                };

                if (!string.IsNullOrEmpty(txtBookingTime.Text))
                    booking.Time = new TimeSpan(GetHour(txtBookingTime.Text), GetMinute(txtBookingTime.Text), 0);

                booking.PrepaymentIsOk = 0;


                if (cmbPhotographerGender.SelectedIndex == 0) booking.PhotographerGender = 0;
                else if (cmbPhotographerGender.SelectedIndex == 1) booking.PhotographerGender = 1;
                else booking.PhotographerGender = 2;


                using (var db = new UnitOfWork())
                {
                    if (BookingId == 0)
                        db.BookingGenericRepository.Insert(booking);
                    else
                    {
                        booking.Id = BookingId;
                        db.BookingGenericRepository.Update(booking);
                    }

                    var result = db.Save();
                    if (result > 0)
                    {
                        if (BookingId == 0)
                        {
                            MessageBox.Show("نوبت مشتری با موفقیت در سیستم ثبت گردید.", "ثبت اطلاعات در سیستم",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("نوبت مشتری با موفقیت در سیستم ویرایش گردید.", "ويرایش اطلاعات در سیستم",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("متاسفانه اطلاعات رزرو در سیستم ثبت نگردید. " +
                                           "لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                            "خطا در ثبت اطلاعات در سیستم",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrEmpty(txtBookingTime.Text.Trim()))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBookingTime, "زمان رزرو مشخص نشده است.");
                return false;
            }

            if (!string.IsNullOrEmpty(txtBookingTime.Text.Trim()))
            {
                var hour = GetHour(txtBookingTime.Text);
                var minute = GetMinute(txtBookingTime.Text);

                if (hour < 9)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtBookingTime, "زمان نوبت انتخابی قبل از شروع به کار مجموعه است.");
                    return false;
                }

                if (hour >= 20)
                {
                    if (hour >= 21)
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(txtBookingTime, "زمان نوبت انتخابی بعد از ساعت کاری مجموعه است.");
                        return false;
                    }
                    else if (minute >= 30)
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(txtBookingTime, "امکان ثبت زمان نوبت بعد از ساعت 20:30 امکان پذیر نمی باشد.");
                        return false;
                    }
                }
            }




            if (txtPersonCount.Value == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPersonCount, "تعداد نفرات مربوط به نوبت، می بایست حداقل یک نفر باشد.");
                txtPersonCount.Focus();
                return false;
            }

            if (cmbPhotographerGender.SelectedIndex < 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbPhotographerGender, "نوع عکاس نوبت انتخاب نشده است.");
                cmbPhotographerGender.DroppedDown = true;
                return false;
            }

            return true;
        }

        private static int GetHour(string bookingTime)
        {
            var returnValue = int.Parse(bookingTime.Substring(0, 2));
            return returnValue;
        }

        private static int GetMinute(string bookingTime)
        {
            var returnValue = int.Parse(bookingTime.Substring(3, 2));
            return returnValue;
        }

        private void btnShowFrmSelectBookingTime_Click(object sender, EventArgs e)
        {
            using (var f = new FrmSelectBookingTime())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtBookingTime.Text = f.SelectedTimeString;
                    BookingHour = f.SelectedTimeSpan.Hours;
                    BookingMinute = f.SelectedTimeSpan.Minutes;
                    txtPersonCount.Focus();
                }
            }
        }

        private void btnCancelCurrentBooking_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmbPhotographyTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region info
            //نوع عکس
            //1	10	پرسنلی
            //2	20	کودک
            //3	30	خانوادگی
            //4	40	نامزدی
            //5	50	جشن

            //نوع آتلیه
            //1	10	آتلیه پرسنلی
            //2	20	آتلیه هنری
            //3	30	آتلیه کودک
            //4	40	فضای باز سرو
            #endregion

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


        //پیاده سازی نمایش کانتکست منو روی قسمت هایی که مقدار دارند و انتخاب آن ردیف
        private void dgvBookingHistory_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvBookingHistory.Rows.Count > 0)
                {
                    int currentMouseOverRow = dgvBookingHistory.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow > -1)
                    {
                        dgvBookingHistory.Rows[currentMouseOverRow].Selected = true;
                        //DataGridViewRow row = dgvBookings.Rows[currentMouseOverRow];
                    }
                    else
                    {
                        contextMenu_dgvBookingHistory.Visible = false;
                    }
                }
                else
                {
                    contextMenu_dgvBookingHistory.Visible = false;
                }
            }
        }

        private void ویرایشنوبتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookingHistory.SelectedRows.Count != 1) return;
            var oldBookingId = Convert.ToInt32(dgvBookingHistory.SelectedRows[0].Cells["clmId"].Value);
            var oldBookingStatusId = Convert.ToInt32(dgvBookingHistory.SelectedRows[0].Cells["clmStatusId"].Value);




            using (var db = new UnitOfWork())
            {
                var bookingStatus = db.BookingStatusGenericRepository.GetById(oldBookingStatusId);

                if (bookingStatus.Code == 40)
                {
                    MessageBox.Show(
                        "رزروی که وضعیت آن 'ورود به آتلیه' است ، قابل ویرایش نمی باشد.",
                        "عدم امکان تغییر وضعیت رزرو",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                var booking = db.BookingGenericRepository.GetById(oldBookingId);
                if (booking != null)
                {
                    BookingId = booking.Id;
                    switch (booking.PhotographerGender)
                    {
                        case 0:
                            cmbPhotographerGender.SelectedIndex = 0;
                            break;
                        case 1:
                            cmbPhotographerGender.SelectedIndex = 1;
                            break;
                        case 2:
                            cmbPhotographerGender.SelectedIndex = 2;
                            break;
                    }


                    datePickerBookingDate.Value = booking.Date.Date;
                    //var dt = new DateTime(booking.Date.Year, booking.Date.Month, booking.Date.Day, booking.Time.Hours, booking.Time.Minutes, booking.Time.Seconds);
                    txtBookingTime.Text = booking.Time.ToShortTimeString();
                    cmbPhotographyTypes.SelectedValue = booking.PhotographyTypeId;
                    cmbAtelierTypes.SelectedValue = booking.AtelierTypeId;
                    txtPersonCount.Value = booking.PersonCount;
                    txtBookingStatus.Text = booking.TblBookingStatus.StatusName;
                }
            }
        }

        private void dgvBookingHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBookingHistory.SelectedRows.Count != 1) return;
            if (dgvBookingHistory.SelectedRows[0].Cells["clmId"].Value == null) return;

            ویرایشنوبتToolStripMenuItem_Click(null, null);
        }
    }
}
