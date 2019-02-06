using FreeControls;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.App.Forms.Documents;
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
            FrmAddEditCustomerInfo customer = new FrmAddEditCustomerInfo();
            customer.ShowDialog();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            FrmAddEditBooking f = new FrmAddEditBooking
            {
                CustomerId = 18
            };
            f.ShowDialog();
        }



        private void buttonItem17_Click_1(object sender, EventArgs e)
        {
            FrmShowCustomerInfo frmShowUserInfo = new FrmShowCustomerInfo
            {
                CustomerId = 13
            };
            frmShowUserInfo.ShowDialog();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            FrmSearchCustomer searchUser = new FrmSearchCustomer();
            searchUser.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            persianMonthCalendar.Value = PersianDate.Now;
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            FrmSearchCustomer searchUser = new FrmSearchCustomer();
            searchUser.ShowDialog();
        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            FrmShowBookings frmShowBookings = new FrmShowBookings();
            frmShowBookings.ShowDialog();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            ViewDocumentInfo f = new ViewDocumentInfo();
            f.ShowDialog();
        }
    }
