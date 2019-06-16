using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Factors
{
    public partial class FrmAddEditPreFactor : Form
    {
        public FrmAddEditPreFactor()
        {
            InitializeComponent();
        }

        private void FrmAddEditPreFactor_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
