public class Deporte
{
    public int idDeporte { get; set; }
    public string nombreDeporte { get; set; }
    public string imagenDeporte { get; set; }
    public string categoriaDeporte { get; set; }
    public Boolean deportePopular { get; set; }
}

public class DeportesCategorizados
{
     public int IdDeporte { get; set; }
     public int IdCategoria { get; set; }
     public string NombreDeporte { get; set; }
     public string ImagenDeporte { get; set; }
     public Boolean Destacado { get; set; }
     public string NombreCategoria { get; set; }
}
