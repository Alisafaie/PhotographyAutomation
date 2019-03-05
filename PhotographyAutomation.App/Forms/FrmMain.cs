using FreeControls;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.App.Forms.Photos;
using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAddEditBooking_Click(object sender, EventArgs e)
        {
            using (var customer = new FrmAddEditCustomerInfo())
            {
                customer.ShowDialog();
            }
        }

        private void btnShowCustomers_Click(object sender, EventArgs e)
        {
            using (var showCustomers = new FrmShowCustomer())
            {
                showCustomers.ShowDialog();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            persianMonthCalendar.Value = PersianDate.Now;
        }



        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            using (var frmShowBookings = new FrmShowBookings())
            {
                frmShowBookings.ShowDialog();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var f = new FrmUploadPhotos())
            {
                f.ShowDialog();
            }
        }

        private void buttonItem15_Click_1(object sender, EventArgs e)
        {
            using (var frmShowUploadedPhotos = new FrmShowUploadedPhotos())
            {
                frmShowUploadedPhotos.ShowDialog();
            }
        }
    }
}
