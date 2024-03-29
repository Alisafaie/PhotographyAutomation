﻿using FreeControls;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.App.Forms.EntranceToAtelier;
using PhotographyAutomation.App.Forms.Orders;
using PhotographyAutomation.App.Forms.PrintSizeAndServices;
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
            using (var frmShowUploadedPhotos = new FrmManagePreOrders())
            {
                frmShowUploadedPhotos.ShowDialog();
            }
        }

        private void btnShowFrmAddEditPrintServices_Click(object sender, EventArgs e)
        {
            using (var frmManagePrintSizeAndServices = new FrmManagePrintSizeAndServices())
            {
                frmManagePrintSizeAndServices.ShowDialog();
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            var frmTest = new Test.Form1();
            frmTest.ShowDialog();
        }
    }
}
