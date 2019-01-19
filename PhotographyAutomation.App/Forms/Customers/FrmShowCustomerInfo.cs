﻿using PhotographyAutomation.DateLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Users
{
    public partial class FrmShowUserInfo : Form
    {
        public int UserId = 0;

        public FrmShowUserInfo()
        {
            
            
            InitializeComponent();
            btnEdit.Enabled = false;
        }

        private void FrmShowUserInfo_Load(object sender, EventArgs e)
        {
            if (UserId > 0)
            {
                using (var db = new UnitOfWork())
                {
                    var user = db.UserGenericRepository.GetById(UserId);
                    if (user != null)
                    {
                        txtFirstName.Text = user.FirstName;
                        txtLastName.Text = user.LastName;
                        cmbGender.SelectedIndex = user.Gender == 0 ? 0 : 1;

                        if (user.BirthDate != null) txtBirthDate.Text = user.BirthDate.Value.ToString("yyyy/MM/dd");

                        txtNationalId.Text = user.NationalId;
                        txtTell.Text = @"0" + user.Tell;
                        txtMobile.Text = @"0" + user.Mobile;

                        if (user.IsMarried != null) cmbMarriedStatus.SelectedIndex = (int)user.IsMarried;
                        if (user.WeddingDate != null)
                            txtWeddingDate.Text = user.WeddingDate.Value.ToString("yyyy/MM/dd");

                        txtEmail.Text = user.Email;

                        cmbCustomerType.SelectedIndex = user.CustomerType == 0 ? 0 : 1;
                        

                        if (user.IsActive != null) cmbActiveStatus.SelectedIndex = user.IsActive.Value;
                        txtAddress.Text = user.Address;

                        //TO DO
                        //txtSubmitter

                        if (user.CreatedDate != null)
                            txtCreatedDate.Text = user.CreatedDate.Value.ToString("HH:mm yyyy/MM/dd ");

                        if (user.ModifiedDate != null)
                            txtModifiedDate.Text = user.ModifiedDate.Value.ToString("HH:mm yyyy/MM/dd ");
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