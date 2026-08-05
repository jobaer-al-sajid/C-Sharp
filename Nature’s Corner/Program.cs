using System;
using System.Windows.Forms;

namespace Nature_s_Corner
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // এখানে new Form দিতে হবে
            Application.Run(new login());
        }
    }
}
