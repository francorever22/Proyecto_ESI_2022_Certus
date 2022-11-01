public class Encuentro
{
    public int IdEncuentro { get; set; }
    public int IdDeporte { get; set; }
    public int IdCategoria { get; set; }
    public int IdPersona { get; set; }
    public string Hora { get; set; }
    public string Lugar { get; set; }
    public string Fecha { get; set; }
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public string Clima { get; set; }
    public int TipoEncuentro { get; set; }
}

public class Arbitro
{
    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Nacionalidad { get; set; }
    public string Rol { get; set; }
}

public class Round
{
    public int NumeroRound { get; set; }
    public int IdEncuentro { get; set; }
    public string TiempoTranscurridoRound { get; set; }
    public int IdPutnuacionRound { get; set; }
    public int IdHito { get; set; }
}

public class PuntuacionRound
{
    public int IdPuntuacionRound { get; set; }
    public int NumeroRound { get; set; }
    public int IdEncuentro { get; set; }
    public int Puntos { get; set; }
    public int IdEquipos { get; set; }
}

public class Hito
{
    public int IdHito { get; set; }
    public int NumeroRound { get; set; }
    public int IdEncuentro { get; set; }
    public string TituloHito { get; set; }
    public string TiempoHito { get; set; }
}

public class EquiposEncuentros
{
    public int IdEncuentro { get; set; }
    public int IdEquipo { get; set; }
    public int IdDeporte { get; set; }
    public int IdCategoria { get; set; }
    public int IdPersona { get; set; }
    public string Hora { get; set; }
    public string Lugar { get; set; }
    public string Fecha { get; set; }
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public string Clima { get; set; }
    public int TipoEncuentro { get; set; }
    public Bitmap ImagenRepresentativa { get; set; }
    public string PaisOrigen { get; set; }
    public string NombreEquipo { get; set; }
    public string TipoEquipo { get; set; }
    public List<int> Miembros { get; set; }
    public int Puntuacion { get; set; }
    public int Posicion { get; set; }
    public Image Alineacion { get; set; }
}
