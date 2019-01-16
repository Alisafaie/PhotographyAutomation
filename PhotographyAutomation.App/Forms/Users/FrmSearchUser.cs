using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Users
{
    public partial class FrmSearchUser : Form
    {
        public FrmSearchUser()
        {
            InitializeComponent();
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void txtSpecialSearch_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvUsers.Rows.Clear();

            using (var db = new UnitOfWork())
            {
                List<TblUser> users = db.UserGenericRepository.Get(x =>
                    x.FirstName.Contains(txtFirstName.Text) || x.LastName.Contains(txtLastName.Text) ||
                    x.Tell.Contains(txtTell.Text) || x.Mobile.Contains(txtTell.Text)).ToList();
                dgvUsers.AutoGenerateColumns = false;
                if (users.Any())
                {
                    dgvUsers.RowCount = users.Count;

                    for (int i = 0; i < users.Count; i++)
                    {
                        dgvUsers.Rows[i].Cells["Id"].Value = users[i].Id;
                        dgvUsers.Rows[i].Cells["FirstName"].Value = users[i].FirstName;
                        dgvUsers.Rows[i].Cells["LastName"].Value = users[i].LastName;
                        dgvUsers.Rows[i].Cells["Tell"].Value = users[i].Tell;
                        dgvUsers.Rows[i].Cells["Mobile"].Value = "0" + users[i].Mobile;
                        dgvUsers.Rows[i].Cells["Email"].Value = users[i].Email;
                        dgvUsers.Rows[i].Cells["Email"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvUsers.Rows[i].Cells["NationalId"].Value = users[i].NationalId;
                        dgvUsers.Rows[i].Cells["UserType"].Value = users[i].UserType == 0 ? "مشتری" : "کارمند";
                        dgvUsers.Rows[i].Cells["CreatedDate"].Value = users[i].CreatedDate;
                        dgvUsers.Rows[i].Cells["ModifiedDate"].Value = users[i].ModifiedDate;
                        dgvUsers.Rows[i].Cells["MoreInfo"].Value = "...";

                        

                    }

                }
            }
        }
    }
}
