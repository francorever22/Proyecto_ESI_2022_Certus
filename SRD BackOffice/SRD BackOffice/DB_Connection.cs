using MySql.Data.MySqlClient;

public class DB_Connection
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public DB_Connection()
    {
        Connection();
    }

    private void Connection()
    {
        try
        {
            server = "localhost";
            database = "srd";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private bool Connection_Open()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("La aplicación no puede conectarse al servidor, vuelva a intentar nuevamente o contacte a un administrador");
                    break;
                case 1045:
                    MessageBox.Show("usuario y/o contraseña no validos");
                    break;
            }
            return false;
        }
    }

    private bool Connection_Close()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    public int CheckIfExist(string query)
    {
        int result = 1;
        try
        {
            if (Connection_Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                result = Convert.ToInt32((Int64)cmd.ExecuteScalar());

                Connection_Close();
                return result;
            }
            else
            {
                Connection_Close();
                return result;
            }
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message);
            Connection_Close();
            return 1;
        }
    }

    public List<DeportesCategorizados> SelectDeportes(string query)
    {
        List<DeportesCategorizados> deportes = new List<DeportesCategorizados>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                DeportesCategorizados deporte = new DeportesCategorizados();
                try {
                    deporte.IdDeporte = Convert.ToInt32($"{dataReader.GetString("IdDeporte")}");
                } catch { }
                try {
                    deporte.NombreDeporte = $"{dataReader.GetString("NombreDeporte")}";
                } catch { }
                try {
                    deporte.NombreCategoria = $"{dataReader.GetString("NombreCategoria")}";
                } catch { }
                try {
                    deporte.ImagenDeporte = $"{dataReader.GetString("ImagenDeporte")}";
                } catch { }
                try {
                    deporte.Destacado = Convert.ToBoolean($"{dataReader.GetString("Destacado")}");
                } catch { }
                try {
                    deporte.IdCategoria = Convert.ToInt32($"{dataReader.GetString("IdCategoria")}");
                } catch { }

                deportes.Add(deporte);
            }

            dataReader.Close();
            Connection_Close();

            return deportes;
        }
        else
        {
            Connection_Close();
            return deportes;
        }
    }

    public List<Deporte> SelectDeporte(string query)
    {
        List<Deporte> deportes = new List<Deporte>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Deporte deporte = new Deporte();
                try
                {
                    deporte.idDeporte = Convert.ToInt32($"{dataReader.GetString("IdDeporte")}");
                }
                catch { }
                try
                {
                    deporte.nombreDeporte = $"{dataReader.GetString("NombreDeporte")}";
                }
                catch { }
                try
                {
                    deporte.imagenDeporte = $"{dataReader.GetString("ImagenDeporte")}";
                }
                catch { }
                try
                {
                    deporte.deportePopular = Convert.ToBoolean($"{dataReader.GetString("Destacado")}");
                }
                catch { }

                deportes.Add(deporte);
            }

            dataReader.Close();
            Connection_Close();

            return deportes;
        }
        else
        {
            Connection_Close();
            return deportes;
        }
    }

    public List<Categoria> SelectCategorias(string query)
    {
        List<Categoria> categorias = new List<Categoria>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Categoria categoria = new Categoria();
                try {
                    categoria.idCategoria = Convert.ToInt32($"{dataReader.GetString("IdCategoria")}");
                } catch { }
                try {
                    categoria.nombreCategoria = $"{dataReader.GetString("NombreCategoria")}";
                } catch { }

                categorias.Add(categoria);
            }

            dataReader.Close();
            Connection_Close();

            return categorias;
        }
        else
        {
            return categorias;
        }
    }

    public List<Banner> SelectBanners(string query)
    {
        List<Banner> banners = new List<Banner>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Banner banner = new Banner();
                banner.IdBanner = Convert.ToInt32($"{dataReader.GetString("IdPublicidad")}");
                try {
                    banner.BannerImage = $"{dataReader.GetString("Banner")}";
                } catch { }
                try {
                    banner.Link = $"{dataReader.GetString("Link")}";
                } catch { }
                try {
                    banner.TitleBanner = $"{dataReader.GetString("TituloPublicidad")}";
                } catch { }

                banners.Add(banner);
            }

            dataReader.Close();
            Connection_Close();

            return banners;
        }
        else
        {
            return banners;
        }
    }

    public List<Usuario> SelectUsuarios(string query)
    {
        List<Usuario> usuarios = new List<Usuario>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Usuario usuario = new Usuario();
                try
                {
                    usuario.email = $"{dataReader.GetString("Email")}";
                } catch { }
                try
                {
                    usuario.nombreUsuario = $"{dataReader.GetString("NombreUsuario")}";
                } catch { }
                try
                {
                    usuario.contrasena = $"{dataReader.GetString("Contrasena")}";
                } catch { }
                try
                {
                    usuario.nivelPermisos = Convert.ToInt16($"{dataReader.GetString("NivelPermisos")}");
                } catch { }
                try{
                    usuario.numeroTelefono = $"{dataReader.GetString("NumeroTelefono")}";
                } catch { }

                usuarios.Add(usuario);
            }

            dataReader.Close();
            Connection_Close();

            return usuarios;
        }
        else
        {
            Connection_Close();
            return usuarios;
        }
    }

    public List<Persona> SelectPersonas(string query)
    {
        List<Persona> personas = new List<Persona>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Persona persona = new Persona();
                try {
                    persona.IdPersona = Convert.ToInt16($"{dataReader.GetString("IdPersona")}");
                } catch { }
                try {
                    persona.Nombre = $"{dataReader.GetString("Nombre")}";
                } catch { }
                try {
                    persona.Apellido = $"{dataReader.GetString("Apellido")}";
                } catch { }
                try {
                    persona.Nacionalidad = $"{dataReader.GetString("Nacionalidad")}";
                } catch { }

                personas.Add(persona);
            }

            dataReader.Close();
            Connection_Close();

            return personas;
        }
        else
        {
            Connection_Close();
            return personas;
        }
    }

    public List<Deportista> SelectDeportistas(string query)
    {
        List<Deportista> deportistas = new List<Deportista>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Deportista deportista = new Deportista();

                try
                {
                    deportista.IdPersona = Convert.ToInt16($"{dataReader.GetString("IdPersona")}");
                } catch { }
                try
                {
                    deportista.Nombre = $"{dataReader.GetString("Nombre")}";
                } catch { }
                try
                {
                    deportista.Apellido = $"{dataReader.GetString("Apellido")}";
                } catch { }
                try
                {
                    deportista.Nacionalidad = $"{dataReader.GetString("Nacionalidad")}";
                } catch { }
                try {
                    deportista.EstadoJugador = $"{dataReader.GetString("EstadoJugador")}";
                } catch { }
                try {
                    deportista.Descripcion = $"{dataReader.GetString("Descripcion")}";
                } catch { }

                deportistas.Add(deportista);
            }

            dataReader.Close();
            Connection_Close();

            return deportistas;
        }
        else
        {
            Connection_Close();
            return deportistas;
        }
    }

    public List<Arbitro> SelectArbitros(string query)
    {
        List<Arbitro> arbitros = new List<Arbitro>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Arbitro arbitro = new Arbitro();
                try
                {
                    arbitro.IdPersona = Convert.ToInt16($"{dataReader.GetString("IdPersona")}");
                }
                catch { }
                try
                {
                    arbitro.Nombre = $"{dataReader.GetString("Nombre")}";
                }
                catch { }
                try
                {
                    arbitro.Apellido = $"{dataReader.GetString("Apellido")}";
                }
                catch { }
                try
                {
                    arbitro.Nacionalidad = $"{dataReader.GetString("Nacionalidad")}";
                }
                catch { }
                try
                {
                    arbitro.Rol = $"{dataReader.GetString("Rol")}";
                } catch { }

                arbitros.Add(arbitro);
            }

            dataReader.Close();
            Connection_Close();

            return arbitros;
        }
        else
        {
            Connection_Close();
            return arbitros;
        }
    }

    public List<Encuentro> SelectEncuentros(string query)
    {
        List<Encuentro> encuentros = new List<Encuentro>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Encuentro encuentro = new Encuentro();
                try {
                    encuentro.IdEncuentro = Convert.ToInt16($"{dataReader.GetString("IdEncuentro")}");
                } catch { }
                try {
                    encuentro.IdDeporte = Convert.ToInt16($"{dataReader.GetString("IdDeporte")}");
                } catch { }
                try {
                    encuentro.IdCategoria = Convert.ToInt16($"{dataReader.GetString("IdCategoria")}");
                } catch { }
                try {
                    encuentro.IdPersona = Convert.ToInt16($"{dataReader.GetString("IdPersona")}");
                } catch { }
                try {
                    encuentro.Hora = $"{dataReader.GetString("Hora")}";
                } catch { }
                try {
                    encuentro.Estado = $"{dataReader.GetString("EstadoEncuentro")}";
                } catch { }
                try {
                    encuentro.Fecha = $"{dataReader.GetString("FechaEncuentro")}";
                } catch { }
                try {
                    encuentro.TipoEncuentro = Convert.ToInt16($"{dataReader.GetString("TipoEncuentro")}");
                } catch { }
                try {
                    encuentro.Lugar = $"{dataReader.GetString("Lugar")}";
                } catch { }
                try {
                    encuentro.Clima = $"{dataReader.GetString("Clima")}";
                } catch { }
                try {
                    encuentro.Nombre = $"{dataReader.GetString("NombreEncuentro")}";
                } catch { }

                encuentros.Add(encuentro);
            }

            dataReader.Close();
            Connection_Close();

            return encuentros;
        }
        else
        {
            Connection_Close();
            return encuentros;
        }
    }

    public List<Round> SelectRounds(string query)
    {
        List<Round> rounds = new List<Round>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Round round = new Round();
                try
                {
                    round.IdEncuentro = Convert.ToInt16($"{dataReader.GetString("IdEncuentro")}");
                }
                catch { }
                try
                {
                    round.NumeroRound = Convert.ToInt16($"{dataReader.GetString("NumeroRound")}");
                }
                catch { }
                try
                {
                    round.TiempoTranscurridoRound = $"{dataReader.GetString("TiempoTranscurridoRound")}";
                }
                catch { }
                try
                {
                    round.IdPutnuacionRound = Convert.ToInt16($"{dataReader.GetString("IdPutnuacionRound")}");
                }
                catch { }
                try
                {
                    round.IdHito = Convert.ToInt16($"{dataReader.GetString("IdHito")}");
                }
                catch { }

                rounds.Add(round);
            }

            dataReader.Close();
            Connection_Close();

            return rounds;
        }
        else
        {
            Connection_Close();
            return rounds;
        }
    }

    public List<Hito> SelectHitos(string query)
    {
        List<Hito> hitos = new List<Hito>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Hito hito = new Hito();
                try {
                    hito.IdHito = Convert.ToInt32($"{dataReader.GetString("IdHito")}");
                } catch { }
                try {
                    hito.IdEncuentro = Convert.ToInt32($"{dataReader.GetString("IdEncuentro")}");
                } catch { }
                try {
                    hito.NumeroRound = Convert.ToInt32($"{dataReader.GetString("NumeroRound")}");
                } catch { }
                try {
                    hito.TituloHito = $"{dataReader.GetString("TituloHito")}";
                } catch { }
                try {
                    hito.TiempoHito = $"{dataReader.GetString("TiempoHito")}";
                } catch { }

                hitos.Add(hito);
            }

            dataReader.Close();
            Connection_Close();

            return hitos;
        }
        else
        {
            Connection_Close();
            return hitos;
        }
    }

    public List<PuntuacionRound> SelectPuntuacionRound(string query)
    {
        List<PuntuacionRound> puntuacionRounds = new List<PuntuacionRound>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                PuntuacionRound puntuacionRound = new PuntuacionRound();
                try
                {
                    puntuacionRound.IdPuntuacionRound = Convert.ToInt32($"{dataReader.GetString("IdPuntuacionRound")}");
                }
                catch { }
                try
                {
                    puntuacionRound.IdEncuentro = Convert.ToInt32($"{dataReader.GetString("IdEncuentro")}");
                }
                catch { }
                try
                {
                    puntuacionRound.NumeroRound = Convert.ToInt32($"{dataReader.GetString("NumeroRound")}");
                }
                catch { }
                try
                {
                    puntuacionRound.Puntos = Convert.ToInt32($"{dataReader.GetString("Puntos")}");
                }
                catch { }
                try
                {
                    puntuacionRound.IdEquipos = Convert.ToInt32($"{dataReader.GetString("IdEquipo")}");
                }
                catch { }

                puntuacionRounds.Add(puntuacionRound);
            }

            dataReader.Close();
            Connection_Close();

            return puntuacionRounds;
        }
        else
        {
            Connection_Close();
            return puntuacionRounds;
        }
    }

    public List<Evento> SelectEventos(string query)
    {
        List<Evento> eventos = new List<Evento>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Evento evento = new Evento();
                try
                {
                    evento.IdEvento = Convert.ToInt16($"{dataReader.GetString("IdEvento")}");
                } catch { }
                try
                {
                    evento.FechaEvento = $"{dataReader.GetString("FechaEvento")}";
                } catch { }
                try
                {
                    evento.NombreEvento = $"{dataReader.GetString("NombreEvento")}";
                } catch { }
                try
                {
                    evento.HoraEvento = $"{dataReader.GetString("HoraEvento")}";
                } catch { }
                try
                {
                    evento.EstadoEvento = $"{dataReader.GetString("EstadoEvento")}";
                } catch { }
                try
                {
                    evento.Lugar = $"{dataReader.GetString("LugarEvento")}";
                } catch { }
                try {
                    evento.LogoEvento = $"{dataReader.GetString("FechaEncuentro")}";
                } catch { }

                eventos.Add(evento);
            }

            dataReader.Close();
            Connection_Close();

            return eventos;
        }
        else
        {
            Connection_Close();
            return eventos;
        }
    }

    public List<Fase> SelectFases(string query)
    {
        List<Fase> fases = new List<Fase>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Fase fase = new Fase();
                try
                {
                    fase.NumeroFase = Convert.ToInt16($"{dataReader.GetString("NumeroFase")}");
                } catch { }
                try
                {
                    fase.TipoFase = Convert.ToInt16($"{dataReader.GetString("TipoFase")}");
                } catch { }
                try {
                    fase.FechaFase = $"{dataReader.GetString("Fecha")}";
                } catch { }
                try {
                    fase.NombreFase = $"{dataReader.GetString("NombreFase")}";
                } catch { }
                try {
                    fase.EstadoFase = $"{dataReader.GetString("EstadoFase")}";
                } catch { }
                try
                {
                    fase.TamañoGrupos = Convert.ToInt16($"{dataReader.GetString("TamanoGrupos")}");
                } catch { }
                try
                {
                    fase.CantidadGrupos = Convert.ToInt16($"{dataReader.GetString("CantidadGrupos")}");
                } catch { }

                fases.Add(fase);
            }

            dataReader.Close();
            Connection_Close();

            return fases;
        }
        else
        {
            Connection_Close();
            return fases;
        }
    }

    public List<EquiposFases> SelectEquiposFases(string query)
    {
        List<EquiposFases> eqFases = new List<EquiposFases>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                EquiposFases eqFase = new EquiposFases();
                try
                {
                    eqFase.IdEvento = Convert.ToInt16($"{dataReader.GetString("IdEvento")}");
                } catch { }
                try
                {
                    eqFase.NumeroFase = Convert.ToInt16($"{dataReader.GetString("NumeroFase")}");
                } catch { }
                try
                {
                    eqFase.TipoFase = Convert.ToInt16($"{dataReader.GetString("TipoFase")}");
                } catch { }
                try
                {
                    eqFase.Fecha = $"{dataReader.GetString("Fecha")}";
                }
                catch { }
                try
                {
                    eqFase.NombreFase = $"{dataReader.GetString("NombreFase")}";
                }
                catch { }
                try
                {
                    eqFase.EstadoFase = $"{dataReader.GetString("EstadoFase")}";
                }
                catch { }
                try
                {
                    eqFase.EstadoEquipo = $"{dataReader.GetString("EstadoEquipo")}";
                }
                catch { }
                try
                {
                    eqFase.IdEquipo = Convert.ToInt16($"{dataReader.GetString("IdEquipo")}");
                }
                catch { }
                try
                {
                    eqFase.PosicionEquipo = Convert.ToInt16($"{dataReader.GetString("PosicionEquipo")}");
                }
                catch { }
                try
                {
                    eqFase.NombreEquipo = $"{dataReader.GetString("NombreEquipo")}";
                }
                catch { }
                try
                {
                    eqFase.TipoEquipo = Convert.ToInt32($"{dataReader.GetString("TipoEquipo")}");
                }
                catch { }
                try
                {
                    eqFase.PaisOrigen = $"{dataReader.GetString("PaisOrigen")}";
                }
                catch { }
                try
                {
                    eqFase.ImagenRepresentativa = $"{dataReader.GetString("ImagenRepresentativa")}";
                }
                catch { }
                try
                {
                    eqFase.TamañoGrupos = Convert.ToInt16($"{dataReader.GetString("TamanoGrupos")}");
                }
                catch { }
                try
                {
                    eqFase.CantidadGrupos = Convert.ToInt16($"{dataReader.GetString("CantidadGrupos")}");
                }
                catch { }
                try
                {
                    eqFase.Puntaje = Convert.ToInt16($"{dataReader.GetString("Puntaje")}");
                }
                catch { }

                eqFases.Add(eqFase);
            }

            dataReader.Close();
            Connection_Close();

            return eqFases;
        }
        else
        {
            Connection_Close();
            return eqFases;
        }
    }

    public List<EncuentrosFases> SelectEncuentrosFases(string query)
    {
        List<EncuentrosFases> eFases = new List<EncuentrosFases>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                EncuentrosFases eFase = new EncuentrosFases();
                try
                {
                    eFase.NumeroFase = Convert.ToInt16($"{dataReader.GetString("NumeroFase")}");
                } catch { }
                try
                {
                    eFase.TipoFase = Convert.ToInt16($"{dataReader.GetString("TipoFase")}");
                } catch { }
                try
                {
                    eFase.FechaFase = $"{dataReader.GetString("Fecha")}";
                }
                catch { }
                try
                {
                    eFase.NombreFase = $"{dataReader.GetString("NombreFase")}";
                }
                catch { }
                try
                {
                    eFase.EstadoFase = $"{dataReader.GetString("EstadoFase")}";
                }
                catch { }
                try
                {
                    eFase.IdEncuentro = Convert.ToInt16($"{dataReader.GetString("IdEncuentro")}");
                }
                catch { }
                try
                {
                    eFase.IdDeporte = Convert.ToInt16($"{dataReader.GetString("IdDeporte")}");
                }
                catch { }
                try
                {
                    eFase.IdCategoria = Convert.ToInt16($"{dataReader.GetString("IdCategoria")}");
                }
                catch { }
                try
                {
                    eFase.IdPersona = Convert.ToInt16($"{dataReader.GetString("IdPersona")}");
                }
                catch { }
                try
                {
                    eFase.Hora = $"{dataReader.GetString("Hora")}";
                }
                catch { }
                try
                {
                    eFase.Estado = $"{dataReader.GetString("EstadoEncuentro")}";
                }
                catch { }
                try
                {
                    eFase.Fecha = $"{dataReader.GetString("FechaEncuentro")}";
                }
                catch { }
                try
                {
                    eFase.TipoEncuentro = Convert.ToInt16($"{dataReader.GetString("TipoEncuentro")}");
                }
                catch { }
                try
                {
                    eFase.Lugar = $"{dataReader.GetString("Lugar")}";
                }
                catch { }
                try
                {
                    eFase.Clima = $"{dataReader.GetString("Clima")}";
                }
                catch { }
                try
                {
                    eFase.Nombre = $"{dataReader.GetString("NombreEncuentro")}";
                } catch { }
                try
                {
                    eFase.PosicionEquipo = Convert.ToInt16($"{dataReader.GetString("Posicion")}");
                }
                catch { }
                try
                {
                    eFase.TamañoGrupos = Convert.ToInt16($"{dataReader.GetString("TamanoGrupos")}");
                }
                catch { }
                try
                {
                    eFase.CantidadGrupos = Convert.ToInt16($"{dataReader.GetString("CantidadGrupos")}");
                }
                catch { }

                eFases.Add(eFase);
            }

            dataReader.Close();
            Connection_Close();

            return eFases;
        }
        else
        {
            Connection_Close();
            return eFases;
        }
    }

    public List<Equipo> SelectEquipos(string query)
    {
        List<Equipo> equipos = new List<Equipo>();
        try
        {
            if (Connection_Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Equipo equipo = new Equipo();
                    try {
                        equipo.IdEquipo = Convert.ToInt16($"{dataReader.GetString("IdEquipo")}");
                    } catch { }
                    try
                    {
                        equipo.NombreEquipo = $"{dataReader.GetString("NombreEquipo")}";
                    } catch { }
                    try
                    {
                        equipo.TipoEquipo = $"{dataReader.GetString("TipoEquipo")}";
                    } catch { }
                    try
                    {
                        equipo.PaisOrigen = $"{dataReader.GetString("PaisOrigen")}";
                    } catch { }
                    try
                    {
                        equipo.ImagenRepresentativa = $"{dataReader.GetString("ImagenRepresentativa")}";
                    }
                    catch { }

                    equipos.Add(equipo);
                }

                dataReader.Close();
                Connection_Close();

                return equipos;
            }
            else
            {
                Connection_Close();
                return equipos;
            }
        } catch { return equipos; }
    }

    public List<EquiposDeportistas> SelectEquiposDeportistas(string query)
    {
        List<EquiposDeportistas> equiposDeportistas = new List<EquiposDeportistas>();
        try
        {
            if (Connection_Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    EquiposDeportistas equipoDeportista = new EquiposDeportistas();
                    try
                    {
                        equipoDeportista.IdEquipo = Convert.ToInt16($"{dataReader.GetString("IdEquipo")}");
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.NombreEquipo = $"{dataReader.GetString("NombreEquipo")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.TipoEquipo = $"{dataReader.GetString("TipoEquipo")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.PaisOrigen = $"{dataReader.GetString("PaisOrigen")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.ImagenRepresentativa = $"{dataReader.GetString("ImagenRepresentativa")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.IdPersona = Convert.ToInt16($"{dataReader.GetString("IdPersona")}");
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.Nombre = $"{dataReader.GetString("Nombre")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.Apellido = $"{dataReader.GetString("Apellido")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.Nacionalidad = $"{dataReader.GetString("Nacionalidad")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.EstadoJugador = $"{dataReader.GetString("EstadoJugador")}";
                    }
                    catch { }
                    try
                    {
                        equipoDeportista.Descripcion = $"{dataReader.GetString("Descripcion")}";
                    }
                    catch { }

                    equiposDeportistas.Add(equipoDeportista);
                }

                dataReader.Close();
                Connection_Close();

                return equiposDeportistas;
            }
            else
            {
                Connection_Close();
                return equiposDeportistas;
            }
        }
        catch { return equiposDeportistas; }
    }

    public List<EquiposEncuentros> SelectEquiposEncuentros(string query)
    {
        List<EquiposEncuentros> equiposEncuentros = new List<EquiposEncuentros>();

        if (Connection_Open() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                EquiposEncuentros equipoEncuentro = new EquiposEncuentros();
                try
                {
                    equipoEncuentro.IdEncuentro = Convert.ToInt16($"{dataReader.GetString("IdEncuentro")}");
                }
                catch { }
                try
                {
                    equipoEncuentro.IdEquipo = Convert.ToInt16($"{dataReader.GetString("IdEquipo")}");
                }
                catch { }
                try
                {
                    equipoEncuentro.IdDeporte = Convert.ToInt16($"{dataReader.GetString("IdDeporte")}");
                }
                catch { }
                try
                {
                    equipoEncuentro.IdCategoria = Convert.ToInt16($"{dataReader.GetString("IdCategoria")}");
                }
                catch { }
                try
                {
                    equipoEncuentro.IdPersona = Convert.ToInt16($"{dataReader.GetString("IdPersona")}");
                }
                catch { }
                try
                {
                    equipoEncuentro.Hora = $"{dataReader.GetString("Hora")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.Estado = $"{dataReader.GetString("EstadoEncuentro")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.Fecha = $"{dataReader.GetString("FechaEncuentro")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.TipoEncuentro = Convert.ToInt16($"{dataReader.GetString("TipoEncuentro")}");
                }
                catch { }
                try
                {
                    equipoEncuentro.Lugar = $"{dataReader.GetString("Lugar")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.Clima = $"{dataReader.GetString("Clima")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.Nombre = $"{dataReader.GetString("NombreEncuentro")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.NombreEquipo = $"{dataReader.GetString("NombreEquipo")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.TipoEquipo = $"{dataReader.GetString("TipoEquipo")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.PaisOrigen = $"{dataReader.GetString("PaisOrigen")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.ImagenRepresentativa = $"{dataReader.GetString("ImagenRepresentativa")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.Alineacion = $"{dataReader.GetString("Alineacion")}";
                }
                catch { }
                try
                {
                    equipoEncuentro.Posicion = Convert.ToInt32($"{dataReader.GetString("Posicion")}");
                }
                catch { }
                try
                {
                    equipoEncuentro.Puntuacion = Convert.ToInt32($"{dataReader.GetString("Puntuacion")}");
                }
                catch { }

                equiposEncuentros.Add(equipoEncuentro);
            }

            dataReader.Close();
            Connection_Close();

            return equiposEncuentros;
        }
        else
        {
            Connection_Close();
            return equiposEncuentros;
        }
    }

    public void ExecuteSql(string query)
    {
        try
        {
            if (Connection_Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                Connection_Close();
                return;
            }
            else
            {
                Connection_Close();
                return;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Error mysql: "+ex.Message);
            Connection_Close();
        }
    }
}