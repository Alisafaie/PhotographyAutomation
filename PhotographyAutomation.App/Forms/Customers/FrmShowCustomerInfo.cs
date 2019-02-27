using PhotographyAutomation.DateLayer.Context;
using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Customers
{
    public partial class FrmShowCustomerInfo : Form
    {
        public int CustomerId = 0;

        public FrmShowCustomerInfo()
        {


            InitializeComponent();
            btnEdit.Enabled = false;
        }

        private void FrmShowUserInfo_Load(object sender, EventArgs e)
        {
            if (CustomerId > 0)
            {
                using (var db = new UnitOfWork())
                {
                    var customer = db.CustomerGenericRepository.GetById(CustomerId);
                    if (customer != null)
                    {
                        txtFirstName.Text = customer.FirstName;
                        txtLastName.Text = customer.LastName;
                        cmbGender.SelectedIndex = customer.Gender == 0 ? 0 : 1;

                        if (customer.BirthDate != null) txtBirthDate.Text = customer.BirthDate.Value.ToString("yyyy/MM/dd");

                        txtNationalId.Text = customer.NationalId;
                        txtTell.Text = @"0" + customer.Tell;
                        txtMobile.Text = @"0" + customer.Mobile;

                        if (customer.IsMarried != null) cmbMarriedStatus.SelectedIndex = (int)customer.IsMarried;
                        if (customer.WeddingDate != null)
                            txtWeddingDate.Text = customer.WeddingDate.Value.ToString("yyyy/MM/dd");

                        txtEmail.Text = customer.Email;

                        cmbCustomerType.SelectedIndex = customer.CustomerType == 0 ? 0 : 1;


                        if (customer.IsActive != null) cmbActiveStatus.SelectedIndex = customer.IsActive.Value;
                        txtAddress.Text = customer.Address;

                        //TO DO
                        //txtSubmitter

                        if (customer.CreatedDate != null)
                            txtCreatedDate.Text = customer.CreatedDate.Value.ToString("HH:mm yyyy/MM/dd ");

                        if (customer.ModifiedDate != null)
                            txtModifiedDate.Text = customer.ModifiedDate.Value.ToString("HH:mm yyyy/MM/dd ");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //To Do
            //if(user.HasEditCustomerInfoRight)



            //else
            btnEdit.Enabled = false;
        }
    }
}
