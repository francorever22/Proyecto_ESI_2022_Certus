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
            encuentrosFavoritos = null,
            eventosFavoritos = null,
            equiposFavoritos = null
        };

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Principal());
        }

        public static void login(Usuario u)
        {
            user = u;
            user.encuentrosFavoritos = Logica.GetEncuentrosFavoritos(2, u.email);
            user.eventosFavoritos = Logica.GetEventosFavoritos(2, u.email);
            user.equiposFavoritos = Logica.GetEquiposFavoritos(2, u.email);
            if (user.nivelPermisos > 1)
            {
                Principal.AlterPrincipal(1, 0, 0);
                NotificationsAsync();
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
                encuentrosFavoritos = null,
                eventosFavoritos = null,
                equiposFavoritos = null
            };
            Principal.AlterPrincipal(0, 0, 1);
            Principal.AlterPrincipal(0, 8, 0);
        }

        public static void refreshFavorites()
        {
            user.encuentrosFavoritos = Logica.GetEncuentrosFavoritos(2, user.email);
            user.eventosFavoritos = Logica.GetEventosFavoritos(2, user.email);
            user.equiposFavoritos = Logica.GetEquiposFavoritos(2, user.email);
        }

        private static async Task NotificationsAsync()
        {
            int lastHito = 0;
            while (true)
            {
                if (user.email == null || AjustesDeUsuario.notificaciones == false)
                {
                    return;
                } else
                {
                    List<Evento> eventos = new List<Evento>();
                    List<Encuentro> encuentros = new List<Encuentro>();
                    List<int> ls1 = user.encuentrosFavoritos.Select(o => o.idEncuentro).ToList();
                    List<int> ls2 = user.equiposFavoritos.Select(o => o.idEquipo).ToList();
                    List<int> eqEnc = new List<int>();
                    foreach (var eq in ls2)
                    {
                        var encs = Logica.GetEquiposEncuentros(4, eq + "");
                        if (encs.Count() > 0)
                        {
                            eqEnc.Add(encs[0].IdEncuentro);
                        }
                    }
                    List<int> lsf = ls1.Union(eqEnc).ToList();
                    foreach (var enc in lsf)
                    {
                        var encs = Logica.GetEncuentros(8, "" + enc);
                        if (encs.Count() > 0)
                        {
                            encuentros.Add(encs[0]);
                        }
                    }
                    int i = 0;
                    List<int> ls3 = user.eventosFavoritos.Select(o => o.idEvento).ToList();
                    List<int> lsff = new List<int>();
                    while (i < ls3.Count)
                    {
                        if (!lsff.Contains(ls3[i]))
                            lsff.Add(ls3[i]);
                        i++;
                    }
                    foreach (var eve in lsff)
                    {
                        var eves = Logica.GetEventos(8, "" + eve);
                        if (eves.Count() > 0)
                        {
                            eventos.Add(eves[0]);
                        }
                    }
                    foreach (var enc in encuentros)
                    {
                        if (enc.Hora.Substring(0, enc.Hora.Length - 3) == DateTime.Now.AddMinutes(+10).ToString("HH:mm"))
                        {
                            if (AjustesDeUsuario.language == "EN")
                            {
                                Toast toast = new Toast(0, enc.Nombre, "It's near to begin", enc.IdEncuentro);
                                toast.SendMail(user.email, enc.Nombre, enc.Nombre + " it's near to begin");
                            }
                            else if (AjustesDeUsuario.language == "ES")
                            {
                                Toast toast = new Toast(0, enc.Nombre, "Esta por empezar", enc.IdEncuentro);
                                toast.SendMail(user.email, enc.Nombre, enc.Nombre + " esta por empezar");
                            }
                        } else if (enc.Hora.Substring(0, enc.Hora.Length - 3) == DateTime.Now.ToString("HH:mm"))
                        {
                            if (AjustesDeUsuario.language == "EN")
                            {
                                Toast toast = new Toast(0, enc.Nombre, "Is starting", enc.IdEncuentro);
                                toast.SendMail(user.email, enc.Nombre, enc.Nombre + " starting");
                            }
                            else if (AjustesDeUsuario.language == "ES")
                            {
                                Toast toast = new Toast(0, enc.Nombre, "A comenzado", enc.IdEncuentro);
                                toast.SendMail(user.email, enc.Nombre, enc.Nombre + " a comenzado");
                            }
                        } else if (enc.Estado == "In progress")
                        {
                            var hs = Logica.GetHitos(4, enc.IdEncuentro, 0);
                            if (hs.Count() > 0)
                            {
                                if (hs[0].IdHito != lastHito)
                                {
                                    Toast toast = new Toast(0, enc.Nombre, hs[0].TituloHito, enc.IdEncuentro);
                                    toast.SendMail(user.email, enc.Nombre, hs[0].TituloHito);
                                    lastHito = hs[0].IdHito;
                                }
                            }
                        }
                    }

                    foreach (var eve in eventos)
                    {
                        if (eve.HoraEvento.Substring(0, eve.HoraEvento.Length - 3) == DateTime.Now.AddMinutes(+10).ToString("HH:mm"))
                        {
                            if (AjustesDeUsuario.language == "EN")
                            {
                                Toast toast = new Toast(0, eve.NombreEvento, "It's near to begin", eve.IdEvento);
                                toast.SendMail(user.email, eve.NombreEvento, eve.NombreEvento + " it's near to begin");
                            } else if (AjustesDeUsuario.language == "ES")
                            {
                                Toast toast = new Toast(0, eve.NombreEvento, "Esta por empezar", eve.IdEvento);
                                toast.SendMail(user.email, eve.NombreEvento, eve.NombreEvento + " esta por empezar");
                            }
                        }
                        else if (eve.HoraEvento.Substring(0, eve.HoraEvento.Length - 3) == DateTime.Now.ToString("HH:mm"))
                        {
                            if (AjustesDeUsuario.language == "EN")
                            {
                                Toast toast = new Toast(0, eve.NombreEvento, "Is starting", eve.IdEvento);
                                toast.SendMail(user.email, eve.NombreEvento, eve.NombreEvento + " starting");
                            }
                            else if (AjustesDeUsuario.language == "ES")
                            {
                                Toast toast = new Toast(0, eve.NombreEvento, "A comenzado", eve.IdEvento);
                                toast.SendMail(user.email, eve.NombreEvento, eve.NombreEvento + " a comenzado");
                            }
                        }
                    }
                }
                await Task.Delay(60000);
            }
        }
    }
}