using System.Text.Json;

namespace SRD_BackOffice
{
    internal class Logica
    {
        #region Serialization

        public static void SerializeUsers(List<Usuario> usuarios, string path = "DinamicJson\\Usuarios.json")
        {
            string usuariosJsonData = JsonSerializer.Serialize(usuarios);
            File.WriteAllText(path, usuariosJsonData);
        }

        public static void SerializeCategorias(List<Categoria> categorias, string path = "DinamicJson\\Categorias.json")
        {
            string categoriasJsonData = JsonSerializer.Serialize(categorias);
            File.WriteAllText(path, categoriasJsonData);
        }

        public static void SerializeDeportes(List<Deporte> deportes, string path = "DinamicJson\\Deportes.json")
        {
            string deportesJsonData = JsonSerializer.Serialize(deportes);
            File.WriteAllText(path, deportesJsonData);
        }

        public static void SerializeBanners(List<Banner> banners, string path = "DinamicJson\\Banners.json")
        {
            string bannersJsonData = JsonSerializer.Serialize(banners);
            File.WriteAllText(path, bannersJsonData);
        }

        public static void SerializeEquipos(List<Equipo> equipos, string path = "DinamicJson\\Equipos.json")
        {
            string equiposJsonData = JsonSerializer.Serialize(equipos);
            File.WriteAllText(path, equiposJsonData);
        }

        public static void SerializeDeportistas(List<Deportista> depostistas, string path = "DinamicJson\\Deportistas.json")
        {
            string depostistasJsonData = JsonSerializer.Serialize(depostistas);
            File.WriteAllText(path, depostistasJsonData);
        }

        public static void SerializeArbitros(List<Arbitro> arbitros, string path = "DinamicJson\\Arbitros.json")
        {
            string arbitrosJsonData = JsonSerializer.Serialize(arbitros);
            File.WriteAllText(path, arbitrosJsonData);
        }

        public static void SerializeEventos(List<Evento> eventos, string path = "DinamicJson\\Eventos.json")
        {
            string eventosJsonData = JsonSerializer.Serialize(eventos);
            File.WriteAllText(path, eventosJsonData);
        }

        public static void SerializeEncuentros(List<Encuentro> encuentros, string path = "DinamicJson\\Encuentros.json")
        {
            string encuentrosJsonData = JsonSerializer.Serialize(encuentros);
            File.WriteAllText(path, encuentrosJsonData);
        }
        #endregion

        #region Deserialization
        public static string GetJson(string filePath)
        {
            string jsonFile;
            using (var  reader = new StreamReader(filePath))
            {
                jsonFile = reader.ReadToEnd();
            }
            return jsonFile;
        }

        public static List<Usuario> DeserializeUsers(String jsonFile)
        {
            var usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonFile);
            return usuarios;
        }

        public static List<Categoria> DeserializeCategorias(String jsonFile)
        {
            var categorias = JsonSerializer.Deserialize<List<Categoria>>(jsonFile);
            return categorias;
        }

        public static List<Deporte> DeserializeDeportes(String jsonFile)
        {
            var deportes = JsonSerializer.Deserialize<List<Deporte>>(jsonFile);
            return deportes;
        }

        public static List<Banner> DeserializeBanners(String jsonFile)
        {
            var banners = JsonSerializer.Deserialize<List<Banner>>(jsonFile);
            return banners;
        }

        public static List<Equipo> DeserializeEquipos(String jsonFile)
        {
            var equipos = JsonSerializer.Deserialize<List<Equipo>>(jsonFile);
            return equipos;
        }

        public static List<Deportista> DeserializeDeportistas(String jsonFile)
        {
            var deportistas = JsonSerializer.Deserialize<List<Deportista>>(jsonFile);
            return deportistas;
        }

        public static List<Arbitro> DeserializeArbitros(String jsonFile)
        {
            var arbitros = JsonSerializer.Deserialize<List<Arbitro>>(jsonFile);
            return arbitros;
        }

        public static List<Evento> DeserializeEventos(String jsonFile)
        {
            var eventos = JsonSerializer.Deserialize<List<Evento>>(jsonFile);
            return eventos;
        }

        public static List<Encuentro> DeserializeEncuentros(String jsonFile)
        {
            var encuentros = JsonSerializer.Deserialize<List<Encuentro>>(jsonFile);
            return encuentros;
        }

        public static void DeserializeFile(String jsonFile)
        {
            var file = JsonSerializer.Deserialize<String[]>(jsonFile);
        }
        #endregion
    }
}
