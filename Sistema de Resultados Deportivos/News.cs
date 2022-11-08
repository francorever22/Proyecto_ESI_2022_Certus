namespace Sistema_de_Resultados_Deportivos
{
    internal class News
    {
		private static List<Noticia> noticias;

		public News()
        {
			New();
        }

        public static async void New()
        {
			String body = "";
			try
			{
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://top-sports-news.p.rapidapi.com/espn"),
					Headers =
				{
					{ "X-RapidAPI-Key", "af9d5e89f2msh4e940f6a728c2cdp1df0d5jsnf347faf99f14" },
					{ "X-RapidAPI-Host", "top-sports-news.p.rapidapi.com" },
				},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					body = await response.Content.ReadAsStringAsync();
					noticias = Logica.DeserializeNoticias(body);
				}
			} catch { MessageBox.Show("Error: No se pudo conectar a la API de noticias"); }
		}

		public List<Noticia> GetNoticias()
        {
			return noticias;
        }
    }
}
