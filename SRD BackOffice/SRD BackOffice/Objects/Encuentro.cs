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
}

public class Arbitro
{
    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Nacionalidad { get; set; }
    public string Rol { get; set; }
}
