using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    public partial class APIPublicidad : Form
    {
        string link = "";
        string imgPath = "";
        Random r = new Random();
        int x = 0;
        public APIPublicidad()
        {
            InitializeComponent();
            SetBanner();
        }

        private void imgPublicidad_Click(object sender, EventArgs e)
        {
            var hl = new ProcessStartInfo(link)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(hl);
        }

        private void SetBanner()
        {
            var banners = Logica.DeserializeBanners(Logica.GetJson("DinamicJson\\Banners.json"));
            foreach (var banner in banners)
            {
                x++;
            }
            int b = r.Next(x);
            foreach (var banner in banners)
            {
                if (banner.IdBanner == b)
                {
                    link = banner.Link;
                    imgPath = banner.BannerImage;
                }
            }
            imgPublicidad.Image = Image.FromFile(imgPath);
        }
    }
}
