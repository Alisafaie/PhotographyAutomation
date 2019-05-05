using System;
using System.Text;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Booking
{
    public partial class FrmSelectBookingTime : Form
    {
        public string SelectedTimeString;
        public TimeSpan SelectedTimeSpan { get; private set; }

    
        public FrmSelectBookingTime()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedTimeSpan = timeSelector1.SelectedTime;

            var sb = new StringBuilder();
            sb.Append(timeSelector1.SelectedTime.Hours.ToString("00"));
            sb.Append(":");
            sb.Append(timeSelector1.SelectedTime.Minutes.ToString("00"));
            sb.Append(SelectedTimeSpan.Hours >= 12 ? " PM" : " AM");
            SelectedTimeString = sb.ToString();

            this.DialogResult = DialogResult.OK;
        }
    }
}
