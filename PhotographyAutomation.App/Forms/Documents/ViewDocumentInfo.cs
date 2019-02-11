using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.ViewModels.Booking;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Documents
{
    public partial class ViewDocumentInfo : Form
    {
        public ViewDocumentInfo()
        {
            InitializeComponent();
        }

        private void btnGetDocumentInfo_Click(object sender, System.EventArgs e)
        {
            using (var db = new UnitOfWork())
            {
                //Guid guid=new Guid("1E305159-242A-E911-AACE-742F68C6E6E6");
                
                var guid = Guid.Parse("1E305159-242A-E911-AACE-742F68C6E6E6");

                var document = db.DocumentRepository.GetDocumentByGuid(guid);
            }
        }
    }
}
