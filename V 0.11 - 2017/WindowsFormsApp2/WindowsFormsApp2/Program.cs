using System;
using System.Windows.Forms;

namespace SRD_BackOffice
{
    internal static class Program
    {
        public static string language = "EN";
        public static bool boss = false;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}