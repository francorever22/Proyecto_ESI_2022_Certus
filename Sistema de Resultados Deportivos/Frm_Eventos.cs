namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_Eventos : Form
    {
        private static Frm_Eventos form = null;
        int id;
        bool favorite;
        Evento evento = new Evento();
        List<Fase> fases = new List<Fase>();
        List<EquiposFases> equipos = new List<EquiposFases>();
        List<EncuentrosFases> encuentros = new List<EncuentrosFases>();
        public Frm_Eventos(int id)
        {
            InitializeComponent();
            form = this;
            SetTheme();
            this.id = id;

            if (Program.user.email == null)
            {
                picFavorito.Hide();
            }
            else
            {
                if (Program.user.eventosFavoritos.Exists(e => e.idEvento == id))
                {
                    favorite = true;
                    picFavorito.BackgroundImage = Properties.Resources.estrellaRellena;
                }
            }

            evento = Logica.GetEventos(4, "" + id)[0];
            fases = Logica.GetFases(2, "" + id);
            equipos = Logica.GetEquiposFases(2, "" + id);
            encuentros = Logica.GetEncuentrosFases(2, "" + id);

            lblName.Text = evento.NombreEvento;
            lblName.Location = new Point(362 - (lblName.Width / 2), 64);

            Bitmap imagenCargada = null;
            try
            {
                imagenCargada = new Bitmap(evento.LogoEvento);
            }
            catch { }
            picLogo.Image = imagenCargada;

            ChargePhasesButtons();
        }

        private void ChargePhasesButtons()
        {
            int total = fases.Count();
            foreach (var f in fases)
            {
                Button btn = new Button();

                var rand = new Random(); //Temporal

                btn.Text = $"Fase {f.NumeroFase}";
                btn.Size = new Size(70, 30);
                btn.FlatStyle = FlatStyle.Flat;
                btn.TabIndex = 0;
                btn.Name = "btnFases";
                btn.BackColor = AjustesDeUsuario.btnBack;
                btn.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
                btn.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
                btn.ForeColor = AjustesDeUsuario.foreColor;
                btn.Click += (sender, EventArgs) => { PhasesButton_Click(sender, EventArgs, f.TipoFase, f.NumeroFase); };

                if (total == 1)
                {
                    btn.Location = new Point(327, 163);
                } else if (total % 2 == 0)
                {
                    btn.Location = new Point(362 - (total / 2 * 70) + (80 * (f.NumeroFase - 1)), 163);
                } else
                {
                    btn.Location = new Point(327 - (total / 2 * 70) + (80 * (f.NumeroFase - 1)), 163);
                }

                Controls.Add(btn);
            }
        }

        private void DrawKeyFormat(int rounds, int participants) //Work in progress
        {
            PictureBox pic = new PictureBox();

            pic.Location = new Point(0, 0);
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.BackColor = Color.Transparent;

            panelContenedor.Controls.Add(pic);

            int y = 0, yB = 0, y1 = 0, y2 = 0, y3 = 0;
            String text = "teamName";

            var teamImage = new Bitmap(150, 150); //Temporal
            var image = new Bitmap(400 * (rounds + 1), 150 * (participants / 2));

            SolidBrush drawBrush = new SolidBrush(AjustesDeUsuario.foreColor);
            Font font = new Font("Montserrat", 10f);
            StringFormat drawFormat = new StringFormat();
            Pen pen = new Pen(AjustesDeUsuario.foreColor);

            for (int r = 0; r <= rounds; r++)
            {
                Graphics g = Graphics.FromImage(image);
                participants /= 2;
                for (int i = 0; i < participants; i++)
                {
                    if (r == 0)
                    {
                        y1 = 0;
                        y2 = 150 * i;
                    } else
                    {
                        y1 = 75 * (Convert.ToInt32(Math.Pow(r, 2)) - (r - 1));
                        y2 = (150 * i * r) + (150 * i * r);
                    }
                    y = y2 + y1;
                    for (int j = 1; j <= 2; j++)
                    {
                        if (j == 1)
                        {
                            g.DrawRectangle(pen, 0 + (400 * r), y, 200, 50);
                            g.DrawImage(teamImage, 5 + (400 * r), 5 + y, 40, 40);
                            g.DrawString($"Group {i}", font, drawBrush, 50 + (400 * r), 15 + y, drawFormat);
                        }
                        else
                        {
                            g.DrawRectangle(pen, 0 + (400 * r), y + 50, 200, 50);
                            g.DrawImage(teamImage, 5 + (400 * r), 55 + y, 40, 40);
                            g.DrawString($"Group {i}", font, drawBrush, 50 + (400 * r), 65 + y, drawFormat);
                        }
                    }
                }
                for (int i = 0; i < (participants / 2); i++)
                {
                    if (participants >= 2)
                    {
                        if (r == 0)
                        {
                            y1 = 0;
                            y3 = 150 * (r + 1);
                        }
                        else
                        {
                            y1 = 75 * (Convert.ToInt32(Math.Pow(r, 2)) - (r - 1));
                            y3 = 150 * (r + r);
                        }
                        y2 = 300 * i * (r + 1);
                        
                        y = y1 + y2 + 50;

                        g.DrawLine(pen, 200 + (400 * r), y, 300 + (400 * r), y); //Horizontal superior
                        yB = y + y3;
                        g.DrawLine(pen, 200 + (400 * r), yB, 300 + (400 * r), yB); //Horizontal inferior
                        g.DrawLine(pen, 300 + (400 * r), y, 300 + (400 * r), yB); //Vertical
                        g.DrawLine(pen, 300 + (400 * r), (yB + y) / 2, 400 + (400 * r), (yB + y) / 2); //Horizontal central
                    }
                }
            }

            pic.Size = image.Size;
            pic.Image = image;
        }

        private void DrawGroupFormat(int n)
        {
            Fase f = fases.Find(r => r.NumeroFase == n);
            List<Equipo> eq = new List<Equipo>();
            foreach (var ef in equipos)
            {
                if (ef.NumeroFase == n)
                {
                    eq.Add(Logica.GetEquipos(3, "" + ef.IdEquipo)[0]);
                }
            }

            PictureBox pic = new PictureBox();

            pic.Location = new Point(0, 0);
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.BackColor = Color.Transparent;

            panelContenedor.Controls.Add(pic);

            int x = 0, y = 0;


            String text = "";

            var teamImage = new Bitmap(150, 150);
            var image = new Bitmap(250 * (24 / 4 / 2), 600);

            SolidBrush drawBrush = new SolidBrush(AjustesDeUsuario.foreColor);
            Font font = new Font("Montserrat", 10f);
            StringFormat drawFormat = new StringFormat();
            Pen pen = new Pen(AjustesDeUsuario.foreColor);

            Graphics g = Graphics.FromImage(image);

            int count = 0;
            for (int i = 1; i <= f.CantidadGrupos; i++)
            {
                g.DrawRectangle(pen, x, y, 200, 50);
                g.DrawString($"Group {i}", font, drawBrush, x + 70, 15 + y, drawFormat);

                for (int j = 1; j <= f.TamañoGrupos; j++)
                {
                    if (eq[count] != null)
                    {
                        text = eq[count].NombreEquipo;
                        try
                        {
                            teamImage = new Bitmap(eq[count].ImagenRepresentativa);
                        }
                        catch { }
                    }

                    y += 50;
                    g.DrawRectangle(pen, x, y, 200, 50);
                    g.DrawImage(teamImage, 5 + x, 5 + y, 40, 40);
                    g.DrawString(text, font, drawBrush, x + 50, 15 + y, drawFormat);

                    count++;
                }
                if (i % 2 != 0 || i == 1)
                {
                    y = 300;
                }
                else
                {
                    y = 0; x += 250;
                }
            }

            pic.Size = image.Size;
            pic.Image = image;
        }

        private void DrawDispairedFormat(int n)
        {
            Fase f = fases.Find(r => r.NumeroFase == n);
            List<Encuentro> enc = new List<Encuentro>();
            foreach (var ef in encuentros)
            {
                if (ef.NumeroFase == n)
                {
                    enc.Add(Logica.GetEncuentros(4, "" + ef.IdEncuentro)[0]);
                }
            }

            PictureBox pic = new PictureBox();

            pic.Location = new Point(0, 0);
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.BackColor = Color.Transparent;

            panelContenedor.Controls.Add(pic);

            int x = 0, y = 25;
            String text = "";

            var image = new Bitmap(250 * (24 / 2 / 2), 350);

            SolidBrush drawBrush = new SolidBrush(AjustesDeUsuario.foreColor);
            Font font = new Font("Montserrat", 10f);
            StringFormat drawFormat = new StringFormat();
            Pen pen = new Pen(AjustesDeUsuario.foreColor);

            Graphics g = Graphics.FromImage(image);

            for (int i = 1; i <= f.CantidadGrupos; i++)
            {
                if (enc.Count() >= i)
                {
                    text = enc[i - 1].Nombre;
                } else { text = ""; }

                g.DrawRectangle(pen, x, y, 200, 50);
                g.DrawString(text, font, drawBrush, x + 50, 15 + y, drawFormat);

                if (i % 2 != 0 || i == 1)
                {
                    y = 125;
                }
                else
                {
                    y = 25; x += 250;
                }
            }

            pic.Size = image.Size;
            pic.Image = image;
        }

        public void PositionFormat(int n)
        {
            Fase f = fases.Find(r => r.NumeroFase == n);
            List<Equipo> eq = new List<Equipo>();
            List<EquiposFases> eqf = new List<EquiposFases>();
            foreach (var ef in equipos)
            {
                if (ef.NumeroFase == n)
                {
                    eq.Add(Logica.GetEquipos(3, "" + ef.IdEquipo)[0]);
                    eqf.Add(ef);
                }
            }

            for (int j = 0; j < eq.Count(); j++)
            {
                int id = eq[j].IdEquipo;
                Panel p1 = new Panel();

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.Size = new Size(724, 50);
                p1.TabIndex = 0;
                p1.BackColor = AjustesDeUsuario.panel;

                PictureBox pic1 = new PictureBox(); //Imagen representativa equipo

                pic1.InitialImage = null;
                pic1.BackColor = Color.Transparent;
                pic1.Size = new Size(40, 40);
                pic1.Location = new Point(10, 5);
                pic1.TabIndex = 1;
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap image = null;
                try
                {
                    image = new Bitmap(eq[j].ImagenRepresentativa);
                }
                catch { }
                pic1.Image = image;

                Label l1 = new Label(); //Nombre equipo

                l1.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = eq[j].NombreEquipo;
                l1.Size = new Size(600, 25);
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.BorderStyle = BorderStyle.None;
                l1.Location = new Point(60, 12);
                l1.TabIndex = 3;
                l1.ForeColor = AjustesDeUsuario.foreColor;

                Label l2 = new Label(); //Posicion equipo

                l2.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.Text = $"{eqf[j].PosicionEquipo}º";
                l2.Size = new Size(50, 25);
                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.RightToLeft = RightToLeft.Yes;
                l2.BorderStyle = BorderStyle.None;
                l2.Location = new Point(650, 12);
                l2.TabIndex = 3;
                l2.ForeColor = AjustesDeUsuario.foreColor;

                p1.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };
                l1.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };
                l2.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };
                pic1.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };

                panelContenedor.Controls.Add(p1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
                p1.Controls.Add(pic1);
            }
        }

        private void EliminationFormat(int n)
        {
            Fase f = fases.Find(r => r.NumeroFase == n);
            List<Equipo> eq = new List<Equipo>();
            List<EquiposFases> eqf = new List<EquiposFases>();
            foreach (var ef in equipos)
            {
                if (ef.NumeroFase == n)
                {
                    eq.Add(Logica.GetEquipos(3, "" + ef.IdEquipo)[0]);
                    eqf.Add(ef);
                }
            }

            for (int j = 0; j < eq.Count; j++)
            {
                int id = eq[j].IdEquipo;
                Panel p1 = new Panel();

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.Size = new Size(724, 50);
                p1.TabIndex = 0;
                p1.BackColor = AjustesDeUsuario.panel;

                PictureBox pic1 = new PictureBox();

                pic1.InitialImage = null;
                pic1.BackColor = Color.Transparent;
                pic1.Size = new Size(40, 40);
                pic1.Location = new Point(10, 5);
                pic1.TabIndex = 1;
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap image = null;
                try
                {
                    image = new Bitmap(eq[j].ImagenRepresentativa);
                }
                catch { }
                pic1.Image = image;

                Label l1 = new Label();

                l1.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = eq[j].NombreEquipo;
                l1.Size = new Size(540, 25);
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.BorderStyle = BorderStyle.None;
                l1.Location = new Point(60, 12);
                l1.TabIndex = 3;
                l1.ForeColor = AjustesDeUsuario.foreColor;

                Label l2 = new Label();

                l2.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.Text = eqf[j].EstadoEquipo;
                l2.Size = new Size(100, 25);
                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.RightToLeft = RightToLeft.Yes;
                l2.BorderStyle = BorderStyle.None;
                l2.Location = new Point(696 - l2.Width, 12);
                l2.TabIndex = 3;
                l2.ForeColor = AjustesDeUsuario.foreColor;

                p1.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };
                l1.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };
                l2.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };
                pic1.Click += (sender, EventArgs) => { Team_Click(sender, EventArgs, id); };

                panelContenedor.Controls.Add(p1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
                p1.Controls.Add(pic1);
            }
        }

        private void PhasesButton_Click(object sender, EventArgs e, int t, int n)
        {
            panelContenedor.Controls.Clear();
            switch (t)
            {
                case 1:
                    //DrawKeyFormat(3, 16);
                    break;
                case 2:
                    DrawGroupFormat(n);
                    break;
                case 3:
                    DrawDispairedFormat(n);
                    break;
                case 4:
                    EliminationFormat(n);
                    break;
                case 5:
                    PositionFormat(n);
                    break;
            }
        }

        private void Team_Click(object sender, EventArgs e, int id)
        {
            Principal.AlterPrincipal(1, 6, id);
        }

        private void SetTheme()
        {
            /* Paneles */
            BackColor = AjustesDeUsuario.panel;
            panelContenedor.BackColor = AjustesDeUsuario.panel;
            /* Textos (Incluidos botones) */
            lblName.ForeColor = AjustesDeUsuario.foreColor;
        }

        private void picFavorito_Click(object sender, EventArgs e)
        {
            if (favorite == false)
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaRellena;
                favorite = true;
                Logica.InsertEventosFavoritos(Program.user.email, id);
                Program.refreshFavorites();
            }
            else
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaVacia;
                favorite = false;
                Logica.Delete("EventosFavoritos", "Email", Program.user.email, "IdEvento", "" + id);
                Program.refreshFavorites();
            }
        }
    }
}