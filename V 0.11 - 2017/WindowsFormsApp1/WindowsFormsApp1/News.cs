﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    internal class News
    {
		private static List<Noticia> noticias;

        public static async void New()
        {
			String body = "";
			try
			{
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://top-sports-news.p.rapidapi.com/sportsillustraded/nba"),
					Headers =
				{
					{ "X-RapidAPI-Key", "7a47208588mshaf352cf6a7b93b3p184d2bjsna94aa5baf18c" },
					{ "X-RapidAPI-Host", "top-sports-news.p.rapidapi.com" },
				},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					body = await response.Content.ReadAsStringAsync();
					noticias = Logica.DeserializeNoticias(Logica.GetJson(body));
				}
			} catch (Exception ex) { MessageBox.Show(ex.Message); }
			MessageBox.Show(body);
		}

		public static List<Noticia> GetNoticias()
        {
			New();
			return noticias;
        }
    }
}