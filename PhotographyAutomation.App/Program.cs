using PhotographyAutomation.App.Forms.Factors;
using System;
using System.Windows.Forms;

namespace PhotographyAutomation.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmMain());
            Application.Run(new FrmAddEditMultiPicture());
        }
    }
}
