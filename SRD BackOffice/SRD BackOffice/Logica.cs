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

        public static void DeserializeFile(String jsonFile)
        {
            var file = JsonSerializer.Deserialize<String[]>(jsonFile);
        }
        #endregion
    }
}
