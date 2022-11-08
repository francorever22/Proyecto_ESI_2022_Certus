using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Resultados_Deportivos
{
    internal static class AjustesDeUsuario
    {
        public static string language = "EN";
        public static bool darkTheme = false;
        public static bool tray = false;
        public static bool notificaciones = false;
        public static Color panel = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
        public static Color btnBack = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        public static Color btnMouseDown = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
        public static Color btnMouseOver = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
        public static Color foreColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));

        public static void Load()
        {
            if (File.Exists("C:\\Certus\\SRD\\Ajustes.txt"))
            {
                var dic = File.ReadAllLines("C:\\Certus\\SRD\\Ajustes.txt")
                .Select(l => l.Split(new[] { '=' }))
                .ToDictionary(s => s[0].Trim(), s => s[1].Trim());

                language = dic["language"];
                darkTheme = Convert.ToBoolean(dic["darkTheme"]);
                tray = Convert.ToBoolean(dic["tray"]);
                notificaciones = Convert.ToBoolean(dic["notificaciones"]);
            }
            SetTheme();
        }

        public static void SetTheme()
        {
            switch (darkTheme)
            {
                case false:
                    panel = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    btnBack = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    btnMouseDown = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    btnMouseOver = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    foreColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    break;
                case true:
                    panel = Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    btnBack = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    btnMouseDown = Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    btnMouseOver = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    foreColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    break;
            }
        }
    }
}
