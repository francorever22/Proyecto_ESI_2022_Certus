public class Equipo
{
    public int IdEquipo { get; set; }
    public string ImagenRepresentativa { get; set; }
    public string PaisOrigen { get; set; }
    public string NombreEquipo { get; set; }
    public string TipoEquipo { get; set; }
    public List<EquiposDeportistas> Miembros { get; set; }
}

public class EquiposDeportistas
{
    public int IdEquipo { get; set; }
    public int IdPersona { get; set; }
    public string ImagenRepresentativa { get; set; }
    public string PaisOrigen { get; set; }
    public string NombreEquipo { get; set; }
    public string TipoEquipo { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Nacionalidad { get; set; }
    public string EstadoJugador { get; set; }
    public string Descripcion { get; set; }
}
