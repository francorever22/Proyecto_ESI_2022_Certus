using System.Security.Cryptography;
using System.Text;

namespace SRD_BackOffice
{
    internal class Logica
    {
        private static DB_Connection db = new DB_Connection();

        #region Select

        public static List<DeportesCategorizados> GetDeportes(int x, string constraint)
        {
            List<DeportesCategorizados> deportes = new List<DeportesCategorizados>();
            switch (x)
            {
                case 1:
                    deportes = db.SelectDeportes("SELECT * FROM DeportesCategorizados");
                    break;
                case 2:
                    deportes = db.SelectDeportes($"SELECT * FROM DeportesCategorizados WHERE NombreDeporte LIKE " +
                        $"'%{constraint}%' OR NombreCategoria LIKE '%{constraint}%'");
                    break;
                case 3:
                    deportes = db.SelectDeportes($"SELECT * FROM DeportesCategorizados WHERE NombreDeporte = '{constraint}'");
                    break;
                case 4:
                    deportes = db.SelectDeportes("SELECT * FROM DeportesCategorizados ORDER BY IdDeporte DESC LIMIT 1");
                    break;
                case 5:
                    deportes = db.SelectDeportes($"SELECT * FROM DeportesCategorizados WHERE IdDeporte = '{constraint}'");
                    break;
            }
            return deportes;
        }

        public static List<Categoria> GetCategorias(int x, string constraint)
        {
            List<Categoria> categorias = new List<Categoria>();
            switch (x)
            {
                case 1:
                    categorias = db.SelectCategorias("SELECT * FROM Categorias");
                    break;
                case 2:
                    categorias = db.SelectCategorias($"SELECT * FROM Categorias WHERE NombreCategoria LIKE '%{constraint}%'");
                    break;
                case 3:
                    categorias = db.SelectCategorias($"SELECT * FROM Categorias WHERE NombreCategoria = '{constraint}'");
                    break;
                case 4:
                    categorias = db.SelectCategorias($"SELECT * FROM Categorias WHERE IdCategoria = '{constraint}'");
                    break;
            }
            return categorias;
        }

        public static List<Banner> GetBanners(int x, string constraint)
        {
            List<Banner> banners = new List<Banner>();
            switch (x)
            {
                case 1:
                    banners = db.SelectBanners("SELECT * FROM Publicidades");
                    break;
                case 2:
                    banners = db.SelectBanners($"SELECT * FROM Publicidades WHERE IdPublicidad = '{constraint}' OR " +
                        $"TituloPublicidad LIKE '%{constraint}%' OR Link LIKE '%{constraint}%'");
                    break;
                case 3:
                    banners = db.SelectBanners($"SELECT * FROM Publicidades WHERE IdPublicidad = '{constraint}'");
                    break;
            }
            return banners;
        }

        public static List<Usuario> GetUsuarios(int x, string constraint)
        {
            List<Usuario> usuarios = null;
            
            switch (x)
            {
                case 1:
                    usuarios = db.SelectUsuarios("SELECT * FROM Usuarios");
                    break;
                case 2:
                    usuarios = db.SelectUsuarios("SELECT * FROM Usuarios WHERE NivelPermisos = 3");
                    break;
                case 3:
                    usuarios = db.SelectUsuarios("SELECT * FROM Usuarios WHERE NivelPermisos = 2");
                    break;
                case 4:
                    usuarios = db.SelectUsuarios($"SELECT * FROM Usuarios WHERE (NombreUsuario LIKE '%{constraint}%' OR " +
                        $"Email LIKE '%{constraint}%') AND NivelPermisos < 3");
                    break;
                case 5:
                    usuarios = db.SelectUsuarios($"SELECT * FROM Usuarios WHERE (NombreUsuario LIKE '%{constraint}%' OR " +
                        $"Email LIKE '%{constraint}%') AND NivelPermisos = 3");
                    break;
                case 6:
                    usuarios = db.SelectUsuarios($"SELECT * FROM Usuarios WHERE (NombreUsuario = '{constraint}' OR " +
                        $"Email = '{constraint}') AND NivelPermisos >= 3");
                    break;
            }

            return usuarios;
        }
        
        public static List<Persona> GetPersonas(int x, string constraint)
        {
            List<Persona> personas = null;
            switch (x)
            {
                case 1:
                    personas = db.SelectPersonas($"SELECT * FROM Personas WHERE CONCAT(Nombre, ' ', Apellido) = '{constraint}'");
                    break;
            }
            return personas;
        }

        public static List<Deportista> GetDeportistas(int x, string constraint)
        {
            List<Deportista> deportistas = null;
            switch (x)
            {
                case 1:
                    deportistas = db.SelectDeportistas("SELECT * FROM Deportistas");
                    break;
                case 2:
                    deportistas = db.SelectDeportistas($"SELECT * FROM Deportistas WHERE IdPersona = '{constraint}' OR " +
                        $"CONCAT(Nombre, ' ', Apellido) LIKE '%{constraint}%' OR Nacionalidad LIKE '%{constraint}%'");
                    break;
                case 3:
                    deportistas = db.SelectDeportistas($"SELECT * FROM Deportistas WHERE IdPersona = '{constraint}'");
                    break;
            }
            return deportistas;
        }

        public static List<Arbitro> GetArbitros(int x, string constraint)
        {
            List<Arbitro> arbitros = null;
            switch (x)
            {
                case 1:
                    arbitros = db.SelectArbitros($"SELECT * FROM Arbitros");
                    break;
                case 2:
                    arbitros = db.SelectArbitros($"SELECT * FROM Arbitros WHERE IdPersona = '{constraint}' OR " +
                        $"CONCAT(Nombre, ' ', Apellido) LIKE '%{constraint}%' OR Nacionalidad LIKE '%{constraint}%'");
                    break;
                case 3:
                    arbitros = db.SelectArbitros($"SELECT * FROM Arbitros WHERE IdPersona = '{constraint}'");
                    break;
            }
            return arbitros;
        }

        public static List<Encuentro> GetEncuentros(int x, string constraint)
        {
            List<Encuentro> encuentros = null;

            switch (x)
            {
                case 1:
                    encuentros = db.SelectEncuentros("SELECT * FROM Encuentros");
                    break;
                case 2:
                    encuentros = db.SelectEncuentros($"SELECT * FROM Encuentros WHERE IdEncuentro = '{constraint}' OR " +
                        $"NombreEncuentro LIKE '%{constraint}%' OR EstadoEncuentro LIKE '%{constraint}%'");
                    break;
                case 3:
                    encuentros = db.SelectEncuentros($"SELECT * FROM Encuentros WHERE NombreEncuentro = '{constraint}'");
                    break;
                case 4:
                    encuentros = db.SelectEncuentros($"SELECT * FROM Encuentros WHERE IdEncuentro = '{constraint}'");
                    break;
            }
            return encuentros;
        }

        public static List<Round> GetRounds(int x, string constraint)
        {
            List<Round> rounds = null;
            switch (x)
            {
                case 1:
                    rounds = db.SelectRounds($"SELECT * FROM Round");
                    break;
                case 2:
                    rounds = db.SelectRounds($"SELECT * FROM Round WHERE IdEncuentro = '{constraint}'");
                    break;
            }
            return rounds;
        }

        public static List<Hito> GetHitos(int x, int constraint1, int constraint2)
        {
            List<Hito> hitos = null;

            switch (x)
            {
                case 1:
                    hitos = db.SelectHitos("SELECT * FROM Hito");
                    break;
                case 2:
                    hitos = db.SelectHitos($"SELECT * FROM Hito WHERE IdEncuentro = '{constraint1}' AND " +
                        $"NumeroRound = '{constraint2}'");
                    break;
                case 3:
                    hitos = db.SelectHitos($"SELECT * FROM Hito WHERE IdEncuentro = '{constraint1}'");
                    break;
            }
            return hitos;
        }

        public static List<PuntuacionRound> GetPuntuacionRounds(int x, int constraint1, int constraint2)
        {
            List<PuntuacionRound> puntuacionRounds = null;

            switch (x)
            {
                case 1:
                    puntuacionRounds = db.SelectPuntuacionRound("SELECT * FROM PuntuacionRound");
                    break;
                case 2:
                    puntuacionRounds = db.SelectPuntuacionRound($"SELECT * FROM PuntuacionRound WHERE IdEncuentro = '{constraint1}' AND " +
                        $"NumeroRound = '{constraint2}'");
                    break;
                case 3:
                    puntuacionRounds = db.SelectPuntuacionRound($"SELECT * FROM PuntuacionRound WHERE IdEncuentro = '{constraint1}'");
                    break;
            }
            return puntuacionRounds;
        }

        public static List<PuntuacionRound> GetPuntuacionRounds(int x, int constraint1, int constraint2, int constraint3)
        {
            List<PuntuacionRound> puntuacionRounds = null;

            switch (x)
            {
                case 1:
                    puntuacionRounds = db.SelectPuntuacionRound($"SELECT * FROM PuntuacionRound WHERE IdEncuentro = '{constraint1}' AND " +
                        $"NumeroRound = '{constraint2}' AND IdEquipo = '{constraint3}'");
                    break;
            }
            return puntuacionRounds;
        }

        public static List<Evento> GetEventos(int x, string constraint)
        {
            List<Evento> eventos = null;

            switch (x)
            {
                case 1:
                    eventos = db.SelectEventos("SELECT * FROM Eventos");
                    break;
                case 2:
                    eventos = db.SelectEventos($"SELECT * FROM Eventos WHERE IdEvento = '{constraint}' OR " +
                        $"NombreEvento LIKE '%{constraint}%' OR EstadoEvento LIKE '%{constraint}%'");
                    break;
                case 3:
                    eventos = db.SelectEventos($"SELECT * FROM Eventos WHERE NombreEvento = '{constraint}'");
                    break;
                case 4:
                    eventos = db.SelectEventos($"SELECT * FROM Eventos WHERE IdEvento = '{constraint}'");
                    break;
            }
            return eventos;
        }

        public static List<Fase> GetFases(int x, string constraint)
        {
            List<Fase> fases = null;

            switch (x)
            {
                case 1: //Todos
                    fases = db.SelectFases("SELECT * FROM Fases");
                    break;
                case 2: //De un evento determinado
                    fases = db.SelectFases($"SELECT * FROM Fases WHERE IdEvento = '{constraint}'");
                    break;
            }
            return fases;
        }

        public static List<EquiposFases> GetEquiposFases(int x, string constraint)
        {
            List<EquiposFases> eqFases = null;

            switch (x)
            {
                case 1: //Todos
                    eqFases = db.SelectEquiposFases("SELECT * FROM EquiposFases");
                    break;
                case 2: //De un evento determinado
                    eqFases = db.SelectEquiposFases($"SELECT * FROM EquiposFases WHERE IdEvento = '{constraint}'");
                    break;
            }
            return eqFases;
        }

        public static List<EquiposFases> GetEquiposFases(int x, string constraint1, string constraint2)
        {
            List<EquiposFases> eqFases = null;

            switch (x)
            {
                case 1: //De una fase determinada de un evento determinado
                    eqFases = db.SelectEquiposFases($"SELECT * FROM EquiposFases WHERE IdEvento = {constraint1} AND NumeroFase = {constraint2}");
                    break;
            }
            return eqFases;
        }

        public static List<EncuentrosFases> GetEncuentrosFases(int x, string constraint)
        {
            List<EncuentrosFases> eFases = null;

            switch (x)
            {
                case 1: //Todos
                    eFases = db.SelectEncuentrosFases("SELECT * FROM EncuentrosFases");
                    break;
                case 2: //De un evento determinado
                    eFases = db.SelectEncuentrosFases($"SELECT * FROM EncuentrosFases WHERE IdEvento = '{constraint}'");
                    break;
            }
            return eFases;
        }

        public static List<EncuentrosFases> GetEncuentrosFases(int x, string constraint1, string constraint2)
        {
            List<EncuentrosFases> eFases = null;

            switch (x)
            {
                case 1: //De una fase determinada de un evento determinado
                    eFases = db.SelectEncuentrosFases($"SELECT * FROM EncuentrosFases WHERE IdEvento = {constraint1} AND NumeroFase = {constraint2}");
                    break;
            }
            return eFases;
        }

        public static List<Equipo> GetEquipos(int x, string constraint)
        {
            List<Equipo> equipos = null;

            switch (x)
            {
                case 1: //Todos
                    equipos = db.SelectEquipos("SELECT * FROM Equipos");
                    break;
                case 2: //Busqueda
                    equipos = db.SelectEquipos($"SELECT * FROM Equipos WHERE IdEquipo = '{constraint}' OR " +
                        $"NombreEquipo LIKE '%{constraint}%' OR PaisOrigen LIKE '%{constraint}%'");
                    break;
                case 3:
                    equipos = db.SelectEquipos($"SELECT * FROM Equipos WHERE IdEquipo = '{constraint}'");
                    break;
                case 4:
                    equipos = db.SelectEquipos($"SELECT * FROM Equipos WHERE NombreEquipo = '{constraint}'");
                    break;
            }
            return equipos;
        }

        public static List<EquiposDeportistas> GetEquiposDeportistas(int x, string constraint)
        {
            List<EquiposDeportistas> equiposDeportistas = null;

            switch (x)
            {
                case 1: //Todos
                    equiposDeportistas = db.SelectEquiposDeportistas("SELECT * FROM EquiposDeportistas");
                    break;
                case 2: //Busqueda
                    equiposDeportistas = db.SelectEquiposDeportistas($"SELECT * FROM EquiposDeportistas WHERE IdEquipo = '{constraint}' OR " +
                        $"NombreEquipo LIKE '%{constraint}%' OR PaisOrigen LIKE '%{constraint}%'");
                    break;
                case 3:
                    equiposDeportistas = db.SelectEquiposDeportistas($"SELECT * FROM EquiposDeportistas WHERE IdEquipo = '{constraint}'");
                    break;
                case 4:
                    equiposDeportistas = db.SelectEquiposDeportistas($"SELECT * FROM EquiposDeportistas WHERE NombreEquipo = '{constraint}'");
                    break;
            }
            return equiposDeportistas;
        }

        public static List<EquiposEncuentros> GetEquiposEncuentros(int x, string constraint)
        {
            List<EquiposEncuentros> eE = null;

            switch (x)
            {
                case 1: //Todos
                    eE = db.SelectEquiposEncuentros("SELECT * FROM EquiposEncuentros");
                    break;
                case 2:
                    eE = db.SelectEquiposEncuentros($"SELECT * FROM EquiposEncuentros WHERE IdEncuentro = '{constraint}'");
                    break;
            }
            return eE;
        }

        #endregion

        #region Insert

        public static void InsertBanner(string title, string link, byte[] banner)
        {
            db.ExecuteSql($"INSERT INTO Publicidades (Banner, Link, TituloPublicidad) VALUES " +
                $"('{banner}', '{link}', '{title}')");
        }

        public static void InsertCategoria(string nombreCategoria)
        {
            db.ExecuteSql($"INSERT INTO Categorias (NombreCategoria) VALUES ('{nombreCategoria}')");
        }

        public static void InsertUsuario(string email, string nomUser, string pw, int np)
        {
            db.ExecuteSql($"INSERT INTO Usuarios (Email, NombreUsuario, Contrasena, NivelPermisos) VALUES ('{email}', " +
                $"'{nomUser}', '{pw}', {np})");
        }

        public static void InsertDeporte(string nomDeporte, Byte[] image, bool destacado)
        {
            db.ExecuteSql($"INSERT INTO Deportes (NombreDeporte, ImagenDeporte, Destacado) VALUES " +
                $"('{nomDeporte}', '{image}', {destacado})");
        }

        public static void InsertDeporteCategorizado(int idDeporte, int idCategoria, string nomDeporte, string nomCategoria, Byte[] image, bool destacado)
        {
            db.ExecuteSql($"INSERT INTO DeportesCategorizados (IdDeporte, IdCategoria, NombreDeporte, ImagenDeporte, Destacado, NombreCategoria) VALUES " +
                $"({idDeporte}, {idCategoria}, '{nomDeporte}', '{image}', {destacado}, '{nomCategoria}')");
        }

        public static void InsertPersona(string nom, string ape, string pais)
        {
            db.ExecuteSql($"INSERT INTO Personas (Nombre, Apellido, Nacionalidad) VALUES " +
                $"('{nom}', '{ape}', '{pais}')");
        }

        public static void InsertArbitro(string nom, string ape, string pais, string rol)
        {
            int idPersona = GetPersonas(1, nom + " " + ape)[0].IdPersona;
            db.ExecuteSql($"INSERT INTO Arbitros (IdPersona, Nombre, Apellido, Nacionalidad, Rol) VALUES " +
                $"('{idPersona}', '{nom}', '{ape}', '{pais}', '{rol}')");
        }

        public static void InsertDeportista(string nom, string ape, string pais, string estado, string descripcion)
        {
            int idPersona = GetPersonas(1, nom+" "+ape)[0].IdPersona;
            db.ExecuteSql($"INSERT INTO Deportistas (IdPersona, Nombre, Apellido, Nacionalidad, EstadoJugador, Descripcion) VALUES " +
                $"({idPersona} ,'{nom}', '{ape}', '{pais}', '{estado}', '{descripcion}')");
        }

        public static void InsertEncuentro(string nomDeporte, string nomArbitro, string hora, string lugar, string fecha,
            string nombre, string estado, string clima, int tipo)
        {
            DeportesCategorizados d = GetDeportes(3, nomDeporte)[0];
            int idDeporte = d.IdDeporte;
            int idCategoria = GetCategorias(3, d.NombreCategoria)[0].idCategoria;
            int idPersona = GetPersonas(1, nomArbitro)[0].IdPersona;
            db.ExecuteSql($"INSERT INTO Encuentros (IdDeporte, IdCategoria, IdPersona, Hora, Lugar, FechaEncuentro, " +
                $"NombreEncuentro, EstadoEncuentro, Clima, TipoEncuentro) VALUES ({idDeporte}, {idCategoria}, {idPersona}, " +
                $"'{hora}', '{lugar}', '{fecha}', '{nombre}', '{estado}', '{clima}', '{tipo}')");
        }

        public static void InsertHito(int nRound, int idEncuentro, string titulo, string tiempo)
        {
            db.ExecuteSql($"INSERT INTO Hito (NumeroRound, IdEncuentro, TituloHito, TiempoHito) VALUES " +
                $"({nRound}, {idEncuentro}, '{titulo}', '{tiempo}')");
        }

        public static void InsertPuntuacionRound(int nRound, int idEncuentro, int puntos, int idEquipo)
        {
            db.ExecuteSql($"INSERT INTO PuntuacionRound (NumeroRound, IdEncuentro, Puntos, IdEquipo) VALUES " +
                $"({nRound}, {idEncuentro}, {puntos}, {idEquipo})");
        }

        public static void InsertRound(int nRound, int idEncuentro, string tiempo, int idPR, int idH)
        {
            db.ExecuteSql($"INSERT INTO Round (NumeroRound, IdEncuentro, TiempoTranscurridoRound, IdPuntuacionRound, IdHito) VALUES " +
                $"({nRound}, {idEncuentro}, '{tiempo}', {idPR}, {idH})");
        }

        public static void InsertEquipo(string nom, string origen, string tipo, Byte[] img)
        {
            db.ExecuteSql($"INSERT INTO Equipos (NombreEquipo, PaisOrigen, TipoEquipo, ImagenRepresentativa) VALUES " +
                $"('{nom}', '{origen}', '{tipo}', '{null}')");
        }

        public static void InsertEquiposDeportistas(int idEq, int IdD)
        {
            Equipo e = GetEquipos(3, $"{idEq}")[0];
            Deportista d = GetDeportistas(3, $"{IdD}")[0];

            db.ExecuteSql($"INSERT INTO EquiposDeportistas(IdEquipo, IdPersona, ImagenRepresentativa, PaisOrigen, " +
                $"NombreEquipo, Nombre, Apellido, EstadoJugador, Descripcion, TipoEquipo) VALUES " +
                $"({idEq}, {IdD}, '{null}', '{e.PaisOrigen}', '{e.NombreEquipo}', '{d.Nombre}', '{d.Apellido}', '{d.EstadoJugador}', " +
                $"'{d.Descripcion}', '{e.TipoEquipo}')");
        }

        public static void InsertEquiposEncuentros(int idEncuentro, int idEquipo, int puntuacion, int posicion, Image alineacion)
        {
            Encuentro e = GetEncuentros(4, $"{idEncuentro}")[0];
            Equipo eq = GetEquipos(3, $"{idEquipo}")[0];

            db.ExecuteSql($"INSERT INTO EquiposEncuentros (IdEncuentro, IdDeporte, IdCategoria, IdPersona, IdEquipo, Hora, " +
                $"Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, ImagenRepresentativa, PaisOrigen, " +
                $"NombreEquipo, Puntuacion, Posicion, Alineacion, TipoEquipo, Tipoencuentro) VALUES (" +
                $"{idEncuentro}, {e.IdDeporte}, {e.IdCategoria}, {e.IdPersona}, {idEquipo}, '{e.Hora}', '{e.Lugar}', " +
                $"'{e.Fecha}', '{e.Nombre}', '{e.Estado}', '{e.Clima}', '{eq.ImagenRepresentativa}', '{eq.PaisOrigen}', " +
                $"'{eq.NombreEquipo}', {puntuacion}, {posicion}, '{alineacion}', '{eq.TipoEquipo}', '{e.TipoEncuentro}')");
        }

        public static void InsertEvento(string nom, string fecha, string hora, string estado, string lugar, byte[] logo)
        {
            db.ExecuteSql($"INSERT INTO Eventos (NombreEvento, FechaEvento, HoraEvento, EstadoEvento, LugarEvento, LogoEvento) " +
                $"VALUES ('{nom}', '{fecha}', '{hora}', '{estado}', '{lugar}', '{logo}')");
        }

        public static void InsertFase(int numero, int idEvento, string estado, string nombre, string fecha, int tipo, int tGrupos, int cGrupos)
        {
            db.ExecuteSql($"INSERT INTO Fases (NumeroFase, IdEvento, EstadoFase, NombreFase, Fecha, Tipofase, TamanoGrupos, CantidadGrupos) VALUES " +
                $"({numero}, {idEvento}, '{estado}', '{nombre}', '{fecha}', {tipo}, {tGrupos}, {cGrupos})");
        }

        public static void InsertEquiposFases(int idEq, int nFase, int idEve, byte[] imagenEq, string pais, string nomEq, string estadoEq, int posicionEq, int puntaje, string tipoEq, string estadoFase, string nomFase, string fechaFase, int tipoFase, int tamaño, int cant)
        {
            db.ExecuteSql($"INSERT INTO EquiposFases(IdEquipo, NumeroFase, IdEvento, ImagenRepresentativa, PaisOrigen, " +
                $"NombreEquipo, EstadoFase, NombreFase, Fecha, PosicionEquipo, EstadoEquipo, Puntaje, TipoEquipo, " +
                $"Tipofase, TamanoGrupos, CantidadGrupos) VALUES " +
                $"({idEq}, {nFase}, {idEve}, '{imagenEq}', '{pais}', '{nomEq}', '{estadoFase}', '{nomFase}', " +
                $"'{fechaFase}', {posicionEq}, '{estadoEq}', {puntaje}, '{tipoEq}', {tipoFase}, {tamaño}, {cant})");
        }

        public static void InsertEncuentrosFases(int idEn, int nFase, int idEve, int idDep, int idCat, int idPer, string hora, string lugar, string fechaEncuentro, string nombreEncuentro, string estadoEncuentro, string clima, int tipoEncuentro, string estadoFase, string nombreFase, string fechaFase, int tipofase, int puntaje, int posicion, int tamaño, int cant)
        {
            db.ExecuteSql($"INSERT INTO EncuentrosFases (IdEncuentro, NumeroFase, IdEvento, IdDeporte, IdCategoria, " +
                $"IdPersona, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, TipoEncuentro, " +
                $"EstadoFase, NombreFase, Fecha, Tipofase, Puntaje, Posicion, TamanoGrupos, CantidadGrupos) VALUES " +
                $"({idEn}, {nFase}, {idEve}, {idDep}, {idCat}, {idPer}, '{hora}', '{lugar}', '{fechaEncuentro}', " +
                $"'{nombreEncuentro}', '{estadoEncuentro}', '{clima}', {tipoEncuentro}, '{estadoFase}', " +
                $"'{nombreFase}', '{fechaFase}', {tipofase}, {puntaje}, {posicion}, {tamaño}, {cant})");
        }

        #endregion

        #region Update

        public static void UpdateBanner(int id, string title, string link, byte[] banner)
        {
            db.ExecuteSql($"Update Publicidades SET Banner = '{banner}', Link = '{link}', TituloPublicidad = '{title}'" +
                $"WHERE IdPublicidad = {id}");
        }

        public static void UpdateCategoria(int id, string nombreCategoria)
        {
            db.ExecuteSql($"UPDATE Categorias SET NombreCategoria = '{nombreCategoria}' WHERE IdCategoria = {id}");
        }

        public static void UpdateDeporte(int id, string nomDeporte, Byte[] image, bool destacado)
        {
            db.ExecuteSql($"UPDATE Deportes SET NombreDeporte = '{nomDeporte}', ImagenDeporte = '{image}', Destacado = {destacado} WHERE " +
                $"IdDeporte = '{id}'");
        }

        public static void UpdateDeporteCategorizado(int idDeporte, int idCategoria, string nomDeporte, string nomCategoria, Byte[] image, bool destacado)
        {
            db.ExecuteSql($"UPDATE DeportesCategorizados SET IdCategoria = '{idCategoria}', NombreDeporte = '{nomDeporte}', ImagenDeporte = '{image}', " +
                $"Destacado = {destacado}, NombreCategoria = '{nomCategoria}' WHERE IdDeporte = '{idDeporte}'");
        }

        public static void UpdatePersona(int id, string nom, string ape, string pais)
        {
            db.ExecuteSql($"UPDATE Personas SET Nombre = '{nom}', Apellido = '{ape}', Nacionalidad = '{pais}' WHERE IdPersona = '{id}'");
        }

        public static void UpdateDeportista(int id, string nom, string ape, string pais, string estado, string descripcion)
        {
            db.ExecuteSql($"UPDATE Deportistas SET Nombre = '{nom}', Apellido = '{ape}', Nacionalidad = '{pais}', EstadoJugador = '{estado}', " +
                $"Descripcion = '{descripcion}' WHERE IdPersona = '{id}'");
        }

        public static void UpdateEncuentro(int id, string nomDeporte, string nomArbitro, string hora, string lugar, string fecha,
            string nombre, string estado, string clima, int tipo)
        {
            var d = GetDeportes(3, nomDeporte)[0];
            int idDeporte = d.IdDeporte;
            int idCategoria = GetCategorias(3, d.NombreCategoria)[0].idCategoria;
            int idPersona = GetPersonas(1, nomArbitro)[0].IdPersona;
            db.ExecuteSql($"UPDATE Encuentros SET IdDeporte = '{idDeporte}', IdCategoria = '{idCategoria}', IdPersona = '{idPersona}', " +
                $"Hora = '{hora}', Lugar = '{lugar}', FechaEncuentro = '{fecha}', NombreEncuentro = '{nombre}', " +
                $"EstadoEncuentro = '{estado}', Clima = '{clima}', TipoEncuentro = '{tipo}' WHERE IdEncuentro = {id}");
        }

        public static void UpdateHito(int id, int nRound, int idEncuentro, string titulo, string tiempo)
        {
            db.ExecuteSql($"UPDATE Hito SET NumeroRound = '{nRound}', TituloHito = '{titulo}', TiempoHito = '{tiempo}' " +
                $"WHERE IdHito = {id}");
        }

        public static void UpdatePuntuacionRound(int id, int nRound, int idEncuentro, int puntos, int idEquipo)
        {
            db.ExecuteSql($"UPDATE PuntuacionRound SET NumeroRound = {nRound}, Puntos = {puntos}, IdEquipo = {idEquipo} " +
                $"WHERE IdPuntuacionRound = {id}");
        }

        public static void UpdateRound(int nRound, int idEncuentro, string tiempo, int idPR, int idH)
        {
            db.ExecuteSql($"UPDATE Round SET TiempoTranscurridoRound = '{tiempo}', IdPuntuacionRound = '{idPR}', IdHito = '{idH}' " +
                $"WHERE IdEncuentro = '{idEncuentro}' AND NumeroRound = '{nRound}'");
        }

        public static void UpdateEquipo(int id, string nom, string origen, string tipo, Byte[] img)
        {
            db.ExecuteSql($"UPDATE Equipos SET NombreEquipo = '{nom}', PaisOrigen = '{origen}', TipoEquipo = '{tipo}', " +
                $"ImagenRepresentativa = '{null}' WHERE IdEquipo = '{id}'");
        }

        public static void UpdateEquiposDeportistas(int idEq, int IdD)
        {
            Equipo e = GetEquipos(3, $"{idEq}")[0];
            Deportista d = GetDeportistas(3, $"{IdD}")[0];

            db.ExecuteSql($"UPDATE EquiposDeportistas SET ImagenRepresentativa = '{null}', PaisOrigen = '{e.PaisOrigen}', " +
                $"NombreEquipo = '{e.NombreEquipo}', Nombre = '{d.Nombre}', Apellido = '{d.Apellido}', EstadoJugador = '{d.EstadoJugador}', Descripcion = '{d.Descripcion}', " +
                $"TipoEquipo = '{e.TipoEquipo}' WHERE IdEquipo = {idEq} AND IdPersona = {IdD}");
        }

        public static void UpdateEquiposEncuentros(int idEncuentro, int idEquipo, int puntuacion, int posicion, Image alineacion)
        {
            Encuentro e = GetEncuentros(4, $"{idEncuentro}")[0];
            Equipo eq = GetEquipos(3, $"{idEquipo}")[0];

            db.ExecuteSql($"UPDATE EquiposEncuentros SET IdDeporte = '{e.IdDeporte}', IdCategoria = '{e.IdCategoria}', " +
                $"IdPersona = '{e.IdPersona}', Hora = '{e.Hora}', Lugar = '{e.Lugar}', FechaEncuentro = '{e.Fecha}', " +
                $"NombreEncuentro = '{e.Nombre}', EstadoEncuentro = '{e.Estado}', Clima = '{e.Clima}', " +
                $"ImagenRepresentativa = '{eq.ImagenRepresentativa}', PaisOrigen = '{eq.PaisOrigen}', " +
                $"NombreEquipo = '{eq.NombreEquipo}', Puntuacion = '{puntuacion}', Posicion = '{posicion}', " +
                $"Alineacion = '{alineacion}', TipoEquipo = '{eq.TipoEquipo}', Tipoencuentro = '{e.TipoEncuentro}' " +
                $"WHERE IdEncuentro = {idEncuentro} AND IdEquipo = {idEquipo}");
        }

        public static void UpdateEvento(int id, string nom, string fecha, string hora, string estado, string lugar, byte[] logo)
        {
            db.ExecuteSql($"UPDATE Eventos SET NombreEvento = '{nom}', FechaEvento = '{fecha}', HoraEvento = '{hora}', EstadoEvento = '{estado}', " +
                $"LugarEvento = '{lugar}', LogoEvento = '{logo}' WHERE IdEvento = '{id}'");
        }

        public static void UpdateFase(int numero, int idEvento, string estado, string nombre, string fecha, int tipo, int tGrupos, int cGrupos)
        {
            db.ExecuteSql($"UPDATE Fases SET EstadoFase = '{estado}', NombreFase = '{nombre}', Fecha = '{fecha}', Tipofase = {tipo}, TamanoGrupos = " +
                $"{tGrupos}, CantidadGrupos = {cGrupos} WHERE IdEvento = {idEvento} AND NumeroFase = {numero}");
        }

        public static void UpdateEquiposFases(int idEq, int nFase, int idEve, byte[] imagenEq, string pais, string nomEq, string estadoEq, int posicionEq, int puntaje, string tipoEq, string estadoFase, string nomFase, string fechaFase, int tipoFase, int tamaño, int cant)
        {
            db.ExecuteSql($"UPDATE EquiposFases SET ImagenRepresentativa = '{imagenEq}', PaisOrigen = '{pais}', " +
                $"NombreEquipo = '{nomEq}', EstadoFase = '{estadoFase}', NombreFase = '{nomFase}', Fecha = '{fechaFase}', " +
                $"PosicionEquipo = {posicionEq}, EstadoEquipo = '{estadoEq}', Puntaje = {puntaje}, TipoEquipo = '{tipoEq}', " +
                $"Tipofase = {tipoFase}, TamanoGrupos = {tamaño}, CantidadGrupos = {cant} WHERE IdEquipo = '{idEq}' AND IdEvento = '{idEve}' AND NumeroFase = '{nFase}'");
        }

        public static void UpdateEncuentrosFases(int idEn, int nFase, int idEve, int idDep, int idCat, int idPer, string hora, string lugar, string fechaEncuentro, string nombreEncuentro, string estadoEncuentro, string clima, int tipoEncuentro, string estadoFase, string nombreFase, string fechaFase, int tipofase, int puntaje, int posicion, int tamaño, int cant)
        {
            db.ExecuteSql($"UPDATE EncuentrosFases SET IdDeporte = {idDep}, IdCategoria = {idCat}, " +
                $"IdPersona = {idPer}, Hora = '{hora}', Lugar = '{lugar}', FechaEncuentro = '{fechaEncuentro}', NombreEncuentro = '{nombreEncuentro}', " +
                $"EstadoEncuentro = '{estadoEncuentro}', Clima = '{clima}', TipoEncuentro = {tipoEncuentro}, " +
                $"EstadoFase = '{estadoFase}', NombreFase = '{nombreFase}', Fecha = '{fechaFase}', Tipofase = {tipofase}, Puntaje = {puntaje}, " +
                $"Posicion = {posicion}, TamanoGrupos = {tamaño}, CantidadGrupos = {cant} WHERE IdEncuentro = '{idEn}' AND IdEvento = '{idEve}' AND NumeroFase = '{nFase}'");
        }

        #endregion

        public static void Delete(string tabla, string clave, string dato)
        {
            db.ExecuteSql($"DELETE FROM {tabla} WHERE {clave} = '{dato}'");
        }

        public static void Delete(string tabla, string clave1, string dato1, string clave2, string dato2)
        {
            db.ExecuteSql($"DELETE FROM {tabla} WHERE {clave1} = '{dato1}' AND {clave2} = '{dato2}'");
        }

        public static int CheckIfExist(string tabla, string clave, string dato)
        {
            int check = db.CheckIfExist($"SELECT COUNT(*) FROM {tabla} WHERE {clave} = '{dato}'");
            return check;
        }

        public static int CheckIfExist(string tabla, string clave1, string dato1, string clave2, string dato2)
        {
            int check = db.CheckIfExist($"SELECT COUNT(*) FROM {tabla} WHERE {clave1} = '{dato1}' AND {clave2} = '{dato2}'");
            return check;
        }

        public static int CheckIfExist(string tabla, string clave1, string dato1, string clave2, string dato2, string clave3, string dato3)
        {
            int check = db.CheckIfExist($"SELECT COUNT(*) FROM {tabla} WHERE {clave1} = '{dato1}' AND {clave2} = '{dato2}' " +
                $"AND {clave3} = '{dato3}'");
            return check;
        }

        public static int CheckIfExist(string tabla, string clave1, string dato1, string clave2, string dato2, string clave3, string dato3, string clave4, string dato4)
        {
            int check = db.CheckIfExist($"SELECT COUNT(*) FROM {tabla} WHERE {clave1} = '{dato1}' AND {clave2} = '{dato2}' " +
                $"AND {clave3} = '{dato3}' AND {clave4} = '{dato4}'");
            return check;
        }

        public static TripleDES CrearDES(string clave)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(clave));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        // Encripta una cadena de caracteres usando una clave personalizada:
        public static string EncriptarContraseña(string textoPlano, string password)
        {
            byte[] textoPlanoBytes = Encoding.Unicode.GetBytes(textoPlano);
            MemoryStream flujoMemoria = new MemoryStream();
            TripleDES des = CrearDES(password);
            CryptoStream flujoEncriptacion = new CryptoStream(flujoMemoria, des.CreateEncryptor(), CryptoStreamMode.Write);
            flujoEncriptacion.Write(textoPlanoBytes, 0, textoPlanoBytes.Length);
            flujoEncriptacion.FlushFinalBlock();

            return Convert.ToBase64String(flujoMemoria.ToArray());
        }

        // Desencripta una contraseña utilizando una clave personalizada
        public static string DesencriptarContraseña(string textoEncriptado, string password)
        {
            byte[] bytesEncriptados = Convert.FromBase64String(textoEncriptado);
            MemoryStream flujoMemoria = new MemoryStream();
            TripleDES des = CrearDES(password);
            CryptoStream flujoDesencriptacion = new CryptoStream(flujoMemoria, des.CreateDecryptor(), CryptoStreamMode.Write);
            flujoDesencriptacion.Write(bytesEncriptados, 0, bytesEncriptados.Length);
            flujoDesencriptacion.FlushFinalBlock();

            return Encoding.Unicode.GetString(flujoMemoria.ToArray());
        }
    }
}