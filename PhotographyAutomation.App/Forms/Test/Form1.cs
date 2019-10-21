using PhotographyAutomation.App.UserControls;
using PhotographyAutomation.App.UserControls.PreFactor;
using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1.Controls.Contains(ucSmallPhotoViewer.Instance))
            {
                splitContainer1.Panel1.Controls.Add(ucSmallPhotoViewer.Instance);
                ucSmallPhotoViewer.Instance.Dock = DockStyle.Fill;
                ucSmallPhotoViewer.Instance.BringToFront();
            }
            else
                ucSmallPhotoViewer.Instance.BringToFront();

            if (!splitContainer1.Panel2.Controls.Contains(ucPhotoOrderProperties.InstanceOrderProperties))
            {
                splitContainer1.Panel2.Controls.Add(ucPhotoOrderProperties.InstanceOrderProperties);
                ucPhotoOrderProperties.InstanceOrderProperties.Dock = DockStyle.Fill;
                ucPhotoOrderProperties.InstanceOrderProperties.BringToFront();
            }
            else
                ucPhotoOrderProperties.InstanceOrderProperties.BringToFront();
        }
    }
}
