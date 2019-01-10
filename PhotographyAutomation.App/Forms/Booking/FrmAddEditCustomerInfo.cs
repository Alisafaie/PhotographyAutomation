using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Booking
{
    public partial class FrmAddEditCustomerInfo : Form
    {
        public FrmAddEditCustomerInfo()
        {
            InitializeComponent();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            FrmAddEditBooking frm=new FrmAddEditBooking();
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
