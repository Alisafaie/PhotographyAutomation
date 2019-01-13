using DevComponents.DotNetBar.Controls;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var db=new UnitOfWork())
            {
                cmbAtelierTypes.DataSource = db.AtelierTypesGenericRepository.Get().OrderBy(x => x.Code).ToList();
                cmbAtelierTypes.DisplayMember = "AtelierName";
                cmbAtelierTypes.ValueMember = "Id";

                cmbBookingStatus.DataSource = db.BookingStatusGenericRepository.Get().OrderBy(x => x.Code).ToList();
                cmbBookingStatus.DisplayMember = "StatusName";
                cmbBookingStatus.ValueMember = "Id";

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
    }
}
