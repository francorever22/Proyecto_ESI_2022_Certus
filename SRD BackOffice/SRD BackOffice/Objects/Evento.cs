public class Evento
{
    public int IdEvento { get; set; }
    public string FechaEvento { get; set; }
    public string NombreEvento { get; set; }
    public string HoraEvento { get; set; }
    public string EstadoEvento { get; set; }
    public string Lugar { get; set; }
    public string LogoEvento { get; set; }
    public List<Fase> Fases { get; set; }
}

public class Fase
{
    public int NumeroFase { get; set; }
    public string NombreFase { get; set; }
    public string FechaFase { get; set; }
    public string EstadoFase { get; set; }
    public int TipoFase { get; set; }
    public int TamañoGrupos { get; set; }
    public int CantidadGrupos { get; set; }
    public List<EquiposFases> EquiposParticipantes { get; set; }
    public List<EncuentrosFases> EncuentrosParticipantes { get; set; }
}

public class EquiposFases
{
    public int IdEquipo { get; set; }
    public int NumeroFase { get; set; }
    public int IdEvento { get; set; }
    public string ImagenRepresentativa { get; set; }
    public string PaisOrigen { get; set; }
    public string NombreEquipo { get; set; }
    public string EstadoFase { get; set; }
    public string NombreFase { get; set; }
    public string Fecha { get; set; }
    public int PosicionEquipo { get; set; }
    public string EstadoEquipo { get; set; }
    public int Puntaje { get; set; }
    public int TipoEquipo { get; set; }
    public int TipoFase { get; set; }
    public int TamañoGrupos { get; set; }
    public int CantidadGrupos { get; set; }
}

public class EncuentrosFases
{
    public int NumeroFase { get; set; }
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
    public string NombreFase { get; set; }
    public string FechaFase { get; set; }
    public string EstadoFase { get; set; }
    public int TipoFase { get; set; }
    public int TamañoGrupos { get; set; }
    public int CantidadGrupos { get; set; }
    public int PosicionEquipo { get; set; }
    public int Puntaje { get; set; }
}