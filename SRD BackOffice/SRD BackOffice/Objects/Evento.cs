public class Evento
{
    public int IdEvento { get; set; }
    public string FechaEvento { get; set; }
    public string NombreEvento { get; set; }
    public string HoraEvento { get; set; }
    public string EstadoEvento { get; set; }
    public string Lugar { get; set; }
    public Bitmap LogoEvento { get; set; }
    public List<Fase> Fases { get; set; }
}

public class Fase
{
    public int NumeroFase { get; set; }
    public string NombreFase { get; set; }
    public string FechaFase { get; set; }
    public string EstadoFase { get; set; }
    public int TipoFase { get; set; }
    public List<int> IdEquiposParticipantes { get; set; }
}