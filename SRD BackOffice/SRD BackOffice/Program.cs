namespace SRD_BackOffice
{
    internal static class Program
    {
        public static string language = "EN";
        public static bool boss = false;
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}