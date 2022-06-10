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
        String link;
        Random r = new Random();
        public APIPublicidad()
        {
            InitializeComponent();
            switch(r.Next(5))
            {
                case 0:
                    this.imgPublicidad.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.Publicidad_Despegar;
                    link = "https://www.despegar.com.uy/";
                    break;
                case 1:
                    this.imgPublicidad.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.Publicidad_Discord;
                    link = "https://discord.com/";
                    break;
                case 2:
                    this.imgPublicidad.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.Publicidad_Fanta;
                    link = "https://www.cocacola.es/fanta";
                    break;
                case 3:
                    this.imgPublicidad.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.Publicidad_Monster;
                    link = "https://www.monsterenergy.com/";
                    break;
                case 4:
                    this.imgPublicidad.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.Publicidad_Samsung;
                    link = "https://www.samsung.com/uy/smartphones/galaxy-s22-ultra/";
                    break;
            }
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
    }
}
