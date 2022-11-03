public class Usuario
{
    public string nombreUsuario { get; set; }
    public string email { get; set; }
    public string contrasena { get; set; }
    public int nivelPermisos { get; set; }
    public string numeroTelefono { get; set; }
    public List<EncuentrosFavoritos> encuentrosFavoritos { get; set; }
    public List<EventosFavoritos> eventosFavoritos { get; set; }
    public List<EquiposFavoritos> equiposFavoritos { get; set; }
}

public class EncuentrosFavoritos
{
    public int idEncuentrosFavoritos { get; set; }
    public int idEncuentro { get; set; }
    public string email { get; set; }
}

public class EventosFavoritos
{
    public int idEventosFavoritos { get; set; }
    public int idEvento { get; set; }
    public string email { get; set; }
}

public class EquiposFavoritos
{
    public int idEquiposFavoritos { get; set; }
    public int idEquipo { get; set; }
    public string email { get; set; }
}
