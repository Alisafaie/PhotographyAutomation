using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.PrintSizeAndServices
{
    public partial class FrmAddEditInput : Form
    {
        public FrmAddEditInput()
        {
            InitializeComponent();
        }

        private void FrmAddEditInput_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
