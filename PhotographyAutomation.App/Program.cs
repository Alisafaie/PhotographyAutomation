using PhotographyAutomation.App.Forms.Factors;
using System;
using System.Windows.Forms;
using PhotographyAutomation.App.Forms;
using PhotographyAutomation.App.Forms.Admin;

namespace PhotographyAutomation.App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmManagePrintSizeAndServices());
            //Application.Run(new FrmAddEditMultiPicture());
        }
    }
}
