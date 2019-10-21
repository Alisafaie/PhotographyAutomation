using PhotographyAutomation.App.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //ui exceptions
            Application.ThreadException += Application_ThreadException;

            //non ui exceptions : background workers & background threads
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var message = @"Sorry, something went wrong.\r\n" + $"{((Exception)e.ExceptionObject).Message}\r\n" + "Please contact support.";
            Console.WriteLine($@"ERROR {DateTimeOffset.Now}: {e.ExceptionObject}");

            MessageBox.Show(message, @"Unexpected Error");

            var isTerminating = e.IsTerminating;
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message = @"Sorry, something went wrong.\r\n" + $"{e.Exception.Message}\r\n" + "Please contact support.";
            Console.WriteLine($@"ERROR {DateTimeOffset.Now}: {e.Exception}");

            MessageBox.Show(message, @"Unexpected Error");
        }
    }
}
