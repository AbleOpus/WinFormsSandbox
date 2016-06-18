using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinFormsSandbox.Forms;

namespace WinFormsSandbox
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
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Shows the specified message in an error dialog.
        /// </summary>
        /// <param name="message">The message to show.</param>
        public static void ShowError(string message)
        {
            Debugger.Break();

            MessageBox.Show(message, Application.ProductName,
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
