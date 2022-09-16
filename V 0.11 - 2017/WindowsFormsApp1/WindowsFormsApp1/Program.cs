using System;
using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    internal static class Program
    {
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }

        public static void login(Usuario u)
        {
            user = u;
            if (user.nivelPermisos > 1)
            {
                Principal.AlterPrincipal(1, 0, 0);
            }
            else
            {
                Principal.AlterPrincipal(0, 0, 0);
            }
        }

        public static void logout()
        {
            user = new Usuario
            {
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