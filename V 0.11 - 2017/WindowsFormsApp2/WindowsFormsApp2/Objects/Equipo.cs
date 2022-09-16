using System.Collections.Generic;
using System.Drawing;

public class Equipo
{
    public int IdEquipo { get; set; }
    public Bitmap Uniforme { get; set; }
    public Bitmap ImagenRepresentativa { get; set; }
    public string PaisOrigen { get; set; }
    public string NombreEquipo { get; set; }
    public string TipoEquipo { get; set; }
    public List<int> Miembros { get; set; }
}
