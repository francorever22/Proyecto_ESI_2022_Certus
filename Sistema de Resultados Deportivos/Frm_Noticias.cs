using System.Diagnostics;

namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_Noticias : Form
    {
        private static Frm_Noticias form = null;
        List<Noticia> noticias = new List<Noticia>();

        public Frm_Noticias()
        {
            InitializeComponent();
            form = this;
            SetIdioma();
            SetTheme();
            imgLoading.Hide();

            CargarNoticias();
        }

        public async void CargarNoticias()
        {
            panelContenedor.Controls.Clear();

            News news = new News();
            if (AjustesDeUsuario.darkTheme == true)
            {
                imgLoading.Image = Properties.Resources.Loading_Dark;
            } else { imgLoading.Image = Properties.Resources.Loading_Light; }
            imgLoading.Show();
            await Task.Delay(30000);
            imgLoading.Hide();

            int y = 0;

            try
            {
                foreach (var n in news.GetNoticias())
                {
                    foreach (var c in n.content)
                    {
                        LinkLabel llb = new LinkLabel(); //Noticia

                        llb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        llb.Text = $"{c.title}: {c.content}";
                        llb.Size = new Size(707, 25);
                        llb.DisabledLinkColor = AjustesDeUsuario.foreColor;
                        llb.VisitedLinkColor = AjustesDeUsuario.foreColor;
                        llb.ActiveLinkColor = AjustesDeUsuario.foreColor;
                        llb.LinkBehavior = LinkBehavior.NeverUnderline;
                        llb.LinkColor = AjustesDeUsuario.foreColor;
                        llb.AutoSize = false;
                        llb.BorderStyle = BorderStyle.FixedSingle;
                        llb.Location = new Point(0, y);
                        llb.TabIndex = 3;
                        llb.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb); };
                        llb.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb); };
                        llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs, c.href); };

                        panelContenedor.Controls.Add(llb);

                        y += 25;
                    }
                }
            } catch { Principal.AlterPrincipal(0, 8, 0); }
        }

        private void mouseHover_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = Color.MediumVioletRed;
        }

        private void mouseLeave_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = AjustesDeUsuario.foreColor;
        }

        private void llb_Click(object sender, EventArgs e, string link)
        {
            var hl = new ProcessStartInfo(link)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(hl);
        }

        public static void AlterNoticias(int y)
        {
            switch (y)
            {
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                        form.CargarNoticias();
                    }
                    break;
                case 2:
                    if (form != null)
                    {
                        form.SetIdioma();
                    }
                    break;
            }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    lblTitle.Text = "News";
                    lblTitle.Location = new Point(327, 35);
                    break;
                case "ES": //Español
                    lblTitle.Text = "Noticias";
                    lblTitle.Location = new Point(325, 35);
                    break;
            }
        }

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            /* Paneles */
            panelContenedor.BackColor = AjustesDeUsuario.panel;
            BackColor = AjustesDeUsuario.panel;
            /* Textos (Incluidos botones) */
            lblTitle.ForeColor = AjustesDeUsuario.foreColor;
        }
    }
}