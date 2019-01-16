using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.App.Forms.Users;

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
            FrmAddEditCustomerInfo customer=new FrmAddEditCustomerInfo();
            customer.ShowDialog();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            FrmAddEditBooking f = new FrmAddEditBooking
            {
                UserId = 13
            };
            f.ShowDialog();
        }

        

        private void buttonItem17_Click_1(object sender, EventArgs e)
        {
            FrmShowUserInfo frmShowUserInfo = new FrmShowUserInfo
            {
                UserId = 13
            };
            frmShowUserInfo.ShowDialog();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            FrmSearchUser searchUser=new FrmSearchUser();
            searchUser.ShowDialog();
        }
    }
}
