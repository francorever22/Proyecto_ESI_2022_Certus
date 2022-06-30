namespace SRD_BackOffice
{
    internal static class Program
    {
        public static string language = "EN";
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}