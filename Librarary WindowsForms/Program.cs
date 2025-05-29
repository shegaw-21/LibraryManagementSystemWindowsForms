// Program.cs
using System;
using System.Windows.Forms;

namespace LibraryWindowsForms // Replace with your actual project namespace
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
            Application.Run(new LoginForm()); // Set LoginForm as the startup form
        }
    }
}
