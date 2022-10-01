namespace Sistema_de_Resultados_Deportivos
{
    internal static class Program
    {
        public static DB_Connection DB = new DB_Connection();

        public static Usuario user = new Usuario()
        {
            nombreUsuario = "Guest",
            email = null,
            contrasena = null,
            nivelPermisos = 0,
            numeroTelefono = null,
            deportesFavoritos = null
        };

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB.DB_Manager(0);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Principal());
        }

        public static void login(Usuario u)
        {
            user = u;
            if (user.nivelPermisos > 1)
            {
                Principal.AlterPrincipal(1, 0, 0);
            } else
            {
                Principal.AlterPrincipal(0, 0, 0);
            }
        }

        public static void logout()
        {
            user = new Usuario {
                nombreUsuario = "Guest",
                email = null,
                contrasena = null,
                nivelPermisos = 0,
                numeroTelefono = null,
                deportesFavoritos = null
            };
            Principal.AlterPrincipal(0, 0, 0);
        }
    }
}