using System.Collections.Generic;

public class Noticia
{
    public string header { get; set; }
    public List<Contents> content { get; set; }
}

public class Contents
{
    public string title { get; set; }
    public string content { get; set; }
    public string href { get; set; }
    public string author { get; set; }
}
