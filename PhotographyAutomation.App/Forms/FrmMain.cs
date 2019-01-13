using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotographyAutomation.App.Forms.Booking;

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
    }
}
