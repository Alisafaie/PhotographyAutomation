using FreeControls;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.App.Forms.EntranceToAtelier;
using PhotographyAutomation.App.Forms.Orders;
using System;
using System.Windows.Forms;
using PhotographyAutomation.App.Forms.Admin;
using PhotographyAutomation.App.Forms.Factors;

namespace PhotographyAutomation.App.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            persianMonthCalendar.Value = PersianDate.Now;
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

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            using (var frmShowBookings = new FrmShowBookings())
            {
                frmShowBookings.ShowDialog();
            }
        }

        private void btnUploadPhotos_Click(object sender, EventArgs e)
        {
            using (var f = new FrmUploadPhotos())
            {
                f.ShowDialog();
            }
        }


        private void btnShowIncommingBookings_Click(object sender, EventArgs e)
        {
            using (var frmShowIncommingBookings = new FrmShowIncommingBookings())
            {
                frmShowIncommingBookings.ShowDialog();
            }
        }

        private void btnAddNewBooking_QuickAccess_Click(object sender, EventArgs e)
        {
            btnAddEditBooking_Click(null, null);
        }

        private void btnShowPreOrders_Click(object sender, EventArgs e)
        {
            using (var frmShowUploadedPhotos = new FrmShowUploadedPhotos())
            {
                frmShowUploadedPhotos.ShowDialog();
            }
        }

        private void btnShowFrmPreFactor_Click(object sender, EventArgs e)
        {
            using (FrmAddEditPreFactor frmPreFactors = new FrmAddEditPreFactor())
            {
                frmPreFactors.ShowDialog();
            }
        }

        private void btnShowFrmAddEditPrintServices_Click(object sender, EventArgs e)
        {
            using (FrmAddEditPrintServices frmPrintServices=new FrmAddEditPrintServices())
            {
                frmPrintServices.ShowDialog();
            }
        }
    }
}
