namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_Encuentros : Form
    {
        private static Frm_Encuentros form = null;
        bool favorite = false;
        int id;
        Encuentro encuentro = new Encuentro();
        List<EquiposEncuentros> equiposEncuentro = new List<EquiposEncuentros>();
        List<Equipo> equipos = new List<Equipo>();
        List<EquiposEncuentros> lastMatchsEq1 = new List<EquiposEncuentros>();
        List<EquiposEncuentros> lastMatchsEq2 = new List<EquiposEncuentros>();
        List<Round> rounds = new List<Round>();
        List<Hito> hitos = new List<Hito>();
        Arbitro arbitro = new Arbitro();
        public Frm_Encuentros(int id)
        {
            InitializeComponent();
            this.id = id;
            SetTheme();
            SetIdioma();
            form = this;

            if (Program.user.email == null)
            {
                picFavorito.Hide();
            }
            else
            {
                if (Program.user.encuentrosFavoritos.Exists(e => e.idEncuentro == id))
                {
                    favorite = true;
                    picFavorito.BackgroundImage = Properties.Resources.estrellaRellena;
                }
            }

            llbTeam2.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llbTeam2); };
            llbTeam2.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llbTeam2); };
            llbTeam1.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llbTeam1); };
            llbTeam1.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llbTeam1); };

            encuentro = Logica.GetEncuentros(4, ""+id)[0];
            arbitro = Logica.GetArbitros(3, ""+encuentro.IdPersona)[0];
            equiposEncuentro = Logica.GetEquiposEncuentros(2, "" + id);
            lblState.Text = encuentro.Estado;
            lblState.Location = new Point(366 - (lblState.Width / 2), 86);
            int count = 0, amount = 0;
            foreach (var eq in equiposEncuentro)
            {
                equipos.Add(Logica.GetEquipos(3, "" + eq.IdEquipo)[0]);
                equipos[count].Miembros = Logica.GetEquiposDeportistas(3, ""+eq.IdEquipo);
                if (equipos[count].Miembros.Count() > amount) { amount = equipos[count].Miembros.Count(); }
                count++;
            }
            if (equiposEncuentro.Count() > 0)
            {
                llbTeam1.Text = equipos[0].NombreEquipo;
                llbTeam2.Text = equipos[1].NombreEquipo;
                llbTeam1.LinkClicked += (sender, EventArgs) => { llbTeam1_LinkClicked(sender, EventArgs, equipos[0].IdEquipo); };
                llbTeam2.LinkClicked += (sender, EventArgs) => { llbTeam1_LinkClicked(sender, EventArgs, equipos[1].IdEquipo); };
                if (encuentro.TipoEncuentro == 1 || encuentro.TipoEncuentro == 2 || encuentro.TipoEncuentro == 4)
                {
                    lastMatchsEq1 = Logica.GetEquiposEncuentros(3, "" + equipos[0].IdEquipo);
                    lastMatchsEq2 = Logica.GetEquiposEncuentros(3, "" + equipos[1].IdEquipo);

                    switch (encuentro.TipoEncuentro)
                    {
                        case 1:
                            lblMarcador.Show();
                            lblMarcador.Text = equiposEncuentro[0].Puntuacion + " - " + equiposEncuentro[1].Puntuacion;
                            lblMarcador.Location = new Point(366 - (lblMarcador.Width / 2), 48);
                            break;
                        case 2:
                            lblMarcador.Show();
                            lblMarcador.Text = equiposEncuentro[0].Puntuacion + " - " + equiposEncuentro[1].Puntuacion;
                            lblMarcador.Location = new Point(366 - (lblMarcador.Width / 2), 48);
                            break;
                        case 4:
                            char eq1, eq2;
                            if (equiposEncuentro[0].Posicion == 1 && equiposEncuentro[1].Posicion == 1)
                            {
                                lblMarcador.Show();
                                lblMarcador.Text = "Draw";
                                lblMarcador.Location = new Point(366 - (lblMarcador.Width / 2), 48);
                            }
                            else if (equiposEncuentro[0].Posicion == 1)
                            {
                                lblMarcador.Show();
                                lblMarcador.Text = "W - L";
                                lblMarcador.Location = new Point(366 - (lblMarcador.Width / 2), 48);
                            }
                            else if (equiposEncuentro[1].Posicion == 1)
                            {
                                lblMarcador.Show();
                                lblMarcador.Text = "L - W";
                                lblMarcador.Location = new Point(366 - (lblMarcador.Width / 2), 48);
                            }
                            break;
                    }
                }
                else if (encuentro.TipoEncuentro == 3)
                {
                    lastMatchsEq1 = Logica.GetEquiposEncuentros(3, "" + equiposEncuentro.Find(e => e.Posicion == 1).IdEquipo);
                    if (equiposEncuentro.Count() > 2)
                    {
                        llbTeam1.Text = "";
                        llbTeam2.Text = "";
                    }
                }
                if (equiposEncuentro.Count() == 2)
                {
                    Bitmap imagenCargada1 = null;
                    try
                    {
                        imagenCargada1 = new Bitmap(equipos[0].ImagenRepresentativa);
                    }
                    catch { }
                    pictureBox1.BackgroundImage = imagenCargada1;
                    Bitmap imagenCargada2 = null;
                    try
                    {
                        imagenCargada2 = new Bitmap(equipos[1].ImagenRepresentativa);
                    }
                    catch { }
                    pictureBox2.BackgroundImage = imagenCargada2;
                }
            }
            hitos = Logica.GetHitos(3, id, 0);
            rounds = Logica.GetRounds(2, ""+id);

            CargarContenedor(encuentro.TipoEncuentro, 1, amount);
        }

        private void CargarContenedor(int a, int b, int c) //Carga los controles de panelContenedor
        {
            int e = 1;
            int big = 0;
            panelContenedor.Controls.Clear();

            switch (a)
            {
                case 1:
                    switch (b)
                    {
                        case 1: // Jugadores
                            Panel p1 = new Panel();

                            p1.BorderStyle = BorderStyle.FixedSingle;
                            p1.Size = new Size(362, c * 25);
                            p1.Location = new Point(0, 0);
                            p1.TabIndex = 0;
                            p1.BackColor = AjustesDeUsuario.panel;

                            Panel p2 = new Panel();

                            p2.BorderStyle = BorderStyle.FixedSingle;
                            p2.Size = new Size(362, c * 25);
                            p2.Location = new Point(362, 0);
                            p2.TabIndex = 0;
                            p2.BackColor = AjustesDeUsuario.panel;

                            Panel p3 = new Panel();

                            p3.Size = new Size(724, 50);
                            p3.TabIndex = 0;
                            p3.BackColor = AjustesDeUsuario.panel;

                            if (c * 25 < 301)
                            {
                                p3.Location = new Point(0, 301);
                            } else
                            {
                                p3.Location = new Point(0, c * 25);
                            }

                            panelContenedor.Controls.Add(p1);
                            panelContenedor.Controls.Add(p2);
                            panelContenedor.Controls.Add(p3);

                            for (int i = 0; i < equipos.Count(); i++)
                            {
                                for (int j = 1; j < equipos[i].Miembros.Count()+1; j++)
                                {
                                    int idPersona = equipos[i].Miembros[j - 1].IdPersona;
                                    Panel p4 = new Panel();

                                    p4.Dock = DockStyle.Top;
                                    p4.BorderStyle = BorderStyle.FixedSingle;
                                    p4.Size = new Size(265, 25);
                                    p4.TabIndex = 0;
                                    p4.BackColor = AjustesDeUsuario.panel;

                                    LinkLabel llb = new LinkLabel(); //Deportista

                                    llb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    llb.Text = equipos[i].Miembros[j - 1].Nombre+" "+ equipos[i].Miembros[j - 1].Apellido;
                                    llb.Size = new Size(200, 25);
                                    llb.DisabledLinkColor = AjustesDeUsuario.foreColor;
                                    llb.VisitedLinkColor = AjustesDeUsuario.foreColor;
                                    llb.ActiveLinkColor = AjustesDeUsuario.foreColor;
                                    llb.LinkBehavior = LinkBehavior.NeverUnderline;
                                    llb.LinkColor = AjustesDeUsuario.foreColor;
                                    llb.Dock = DockStyle.Left;
                                    llb.AutoSize = false;
                                    llb.BorderStyle = BorderStyle.None;
                                    llb.Location = new Point(0, 0);
                                    llb.TabIndex = 3;
                                    llb.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb); };
                                    llb.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb); };
                                    llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs, idPersona, 2); };

                                    if (i == 1)
                                    {
                                        p2.Controls.Add(p4);
                                    } else
                                    {
                                        p1.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(llb);
                                }

                                Label l3 = new Label(); //Lugar
                                l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l3.Text = encuentro.Lugar;
                                l3.Size = new Size(200, 25);
                                l3.TextAlign = ContentAlignment.MiddleCenter;
                                l3.AutoSize = false;
                                l3.BorderStyle = BorderStyle.None;
                                l3.Location = new Point(0, 12);
                                l3.TabIndex = 3;
                                l3.ForeColor = AjustesDeUsuario.foreColor;

                                Label l4 = new Label(); //Clima
                                l4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l4.Text = encuentro.Clima;
                                l4.Size = new Size(200, 25);
                                l4.TextAlign = ContentAlignment.MiddleCenter;
                                l4.AutoSize = false;
                                l4.BorderStyle = BorderStyle.None;
                                l4.Location = new Point((p3.Width / 2) - (l4.Width / 2), 12);
                                l4.TabIndex = 3;
                                l4.ForeColor = AjustesDeUsuario.foreColor;

                                Label l5 = new Label(); //Arbitro
                                l5.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l5.Text = arbitro.Nombre+" "+arbitro.Apellido;
                                l5.Size = new Size(200, 25);
                                l5.TextAlign = ContentAlignment.MiddleCenter;
                                l5.Location = new Point(p3.Width - l4.Width, 12);
                                l5.RightToLeft = RightToLeft.Yes;
                                l5.AutoSize = false;
                                l5.BorderStyle = BorderStyle.None;
                                l5.TabIndex = 3;
                                l5.ForeColor = AjustesDeUsuario.foreColor;

                                p3.Controls.Add(l3);
                                p3.Controls.Add(l4);
                                p3.Controls.Add(l5);
                            }
                            break;

                        case 2: // Alineamiento
                            PictureBox lineup = new PictureBox();

                            lineup.Size = new Size(725, 350);
                            lineup.BorderStyle = BorderStyle.None;
                            lineup.Location = new Point(0, 0);
                            lineup.Image = null;
                            break;
                        case 3: // Últimos 10 encuentros
                            Panel p7 = new Panel();

                            p7.BorderStyle = BorderStyle.FixedSingle;
                            p7.Size = new Size(362, 500);
                            p7.Location = new Point(0, 0);
                            p7.TabIndex = 0;
                            p7.BackColor = AjustesDeUsuario.panel;

                            Panel p8 = new Panel();

                            p8.BorderStyle = BorderStyle.FixedSingle;
                            p8.Size = new Size(345, 500);
                            p8.Location = new Point(362, 0);
                            p8.TabIndex = 0;
                            p8.BackColor = AjustesDeUsuario.panel;

                            panelContenedor.Controls.Add(p7);
                            panelContenedor.Controls.Add(p8);

                            for (int i = 0; i < equipos.Count(); i++)
                            {
                                List<EquiposEncuentros> eqEnc;
                                if (i == 0) { eqEnc = lastMatchsEq1; } else { eqEnc = lastMatchsEq2; }
                                
                                foreach (var enc in eqEnc)
                                {
                                    int id = enc.IdEncuentro;
                                    Panel p4 = new Panel();

                                    p4.Dock = DockStyle.Top;
                                    p4.BorderStyle = BorderStyle.FixedSingle;
                                    if (i == 1)
                                    {
                                        p4.Size = new Size(362, 50);
                                    }
                                    else
                                    {
                                        p4.Size = new Size(345, 50);
                                    }
                                    p4.TabIndex = 0;
                                    p4.BackColor = AjustesDeUsuario.panel;

                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = enc.Nombre;
                                    if (i == 1)
                                    {
                                        l2.Size = new Size((l2.Text.Length * 10), 25);
                                    }
                                    else
                                    {
                                        l2.Size = new Size((l2.Text.Length * 9), 25);
                                    }
                                    l2.AutoSize = true;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.Location = new Point(p4.Width / 2 - l2.Width / 2, 12);
                                    l2.TabIndex = 3;
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); };
                                    l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); };;

                                    if (i == 1)
                                    {
                                        p7.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p8.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(l2);
                                }
                            }
                            break;

                        case 4: // Resumen
                            for (int i = 1; i < rounds.Count() + 1; i++)
                            {
                                var hitos = this.hitos.FindAll(h => h.NumeroRound == i);
                                List<Hito> SortedHitos = hitos.OrderBy(h => h.TiempoHito).ToList();

                                Label l1 = new Label();

                                l1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                                l1.Text = $"Round {i}";
                                l1.Size = new Size(707, 25);
                                l1.TextAlign = ContentAlignment.MiddleCenter;
                                l1.AutoSize = false;
                                l1.BorderStyle = BorderStyle.FixedSingle;
                                l1.TabIndex = 3;
                                l1.ForeColor = AjustesDeUsuario.foreColor;
                                if (i == 0)
                                {
                                    l1.Location = new Point(0, 0);
                                } else
                                {
                                    l1.Location = new Point(0, c * 25 * (i - 1) + (25 * (i - 1)));
                                }

                                Panel p5 = new Panel();

                                p5.BorderStyle = BorderStyle.None;
                                p5.Size = new Size(344, c * 25);
                                p5.Location = new Point(0, c * 25 * (i - 1) + (25 * i));
                                p5.TabIndex = 0;
                                p5.BackColor = AjustesDeUsuario.panel;

                                panelContenedor.Controls.Add(l1);
                                panelContenedor.Controls.Add(p5);

                                int y = 0;
                                foreach (var h in SortedHitos)
                                {
                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{h.TiempoHito}'";
                                    l2.Size = new Size(66, 25);
                                    l2.AutoSize = false;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.TabIndex = 3;
                                    l2.Location = new Point(0, 25 * y);
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l3 = new Label();

                                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l3.Text = $"{h.TituloHito}";
                                    l3.Size = new Size(65, 25);
                                    l3.AutoSize = true;
                                    l3.BorderStyle = BorderStyle.None;
                                    l3.TabIndex = 3;
                                    l3.ForeColor = AjustesDeUsuario.foreColor;
                                    l3.Location = new Point(l2.Width, 25 * y);

                                    p5.Controls.Add(l2);
                                    p5.Controls.Add(l3);
                                    y++;
                                }
                            }
                            break;
                    }
                break;

                case 3:
                    switch (b)
                    {
                        case 1: // Jugadores
                            for (int j = 1; j < equipos.Count() + 1; j++)
                            {
                                int idEquipo = equipos[j - 1].IdEquipo;
                                Panel p4 = new Panel();

                                p4.BorderStyle = BorderStyle.FixedSingle;
                                p4.TabIndex = 0;
                                p4.BackColor = AjustesDeUsuario.panel;

                                LinkLabel llb = new LinkLabel();

                                llb.Text = equipos[j - 1].Miembros[0].Nombre + " " + equipos[j - 1].Miembros[0].Apellido;
                                llb.Size = new Size(200, 25);
                                llb.DisabledLinkColor = AjustesDeUsuario.foreColor;
                                llb.VisitedLinkColor = AjustesDeUsuario.foreColor;
                                llb.ActiveLinkColor = AjustesDeUsuario.foreColor;
                                llb.LinkBehavior = LinkBehavior.NeverUnderline;
                                llb.LinkColor = AjustesDeUsuario.foreColor;
                                llb.Dock = DockStyle.Left;
                                llb.AutoSize = false;
                                llb.TextAlign = ContentAlignment.MiddleLeft;
                                llb.BorderStyle = BorderStyle.None;
                                llb.Location = new Point(0, 0);
                                llb.TabIndex = 3;
                                llb.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb); };
                                llb.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb); };
                                llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs, idEquipo, 1); };

                                Label l2 = new Label(); //Posición

                                l2.Text = $"{equiposEncuentro[j - 1].Posicion}º";
                                l2.RightToLeft = RightToLeft.Yes;
                                l2.Dock = DockStyle.Right;
                                l2.Size = new Size(65, 25);
                                l2.TextAlign = ContentAlignment.MiddleLeft;
                                l2.AutoSize = false;
                                l2.BorderStyle = BorderStyle.None;
                                l2.Location = new Point(0, 0);
                                l2.TabIndex = 3;
                                l2.ForeColor = AjustesDeUsuario.foreColor;
                                if (c > 11)
                                {
                                    p4.Size = new Size(707, 25);
                                }
                                else
                                {
                                    p4.Size = new Size(724, 25);
                                }

                                p4.Location = new Point(0, (j - 1) * 25);
                                llb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

                                panelContenedor.Controls.Add(p4);
                                p4.Controls.Add(llb);
                                p4.Controls.Add(l2);
                            }

                            Panel p3 = new Panel();

                            if (c > 11)
                            {
                                p3.Size = new Size(707, 50);
                            } else
                            {
                                p3.Size = new Size(724, 50);
                            }
                            p3.TabIndex = 0;
                            p3.Dock = DockStyle.Bottom;
                            p3.BackColor = AjustesDeUsuario.panel;

                            Label l3 = new Label(); //Lugar
                            l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            l3.Text = encuentro.Lugar;
                            l3.Size = new Size(200, 25);
                            l3.TextAlign = ContentAlignment.MiddleCenter;
                            l3.AutoSize = false;
                            l3.BorderStyle = BorderStyle.None;
                            l3.Location = new Point(0, 12);
                            l3.TabIndex = 3;
                            l3.ForeColor = AjustesDeUsuario.foreColor;

                            Label l4 = new Label(); //Clima
                            l4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            l4.Text = encuentro.Clima;
                            l4.Size = new Size(200, 25);
                            l4.TextAlign = ContentAlignment.MiddleCenter;
                            l4.AutoSize = false;
                            l4.BorderStyle = BorderStyle.None;
                            l4.Location = new Point((p3.Width / 2) - (l4.Width / 2), 12);
                            l4.TabIndex = 3;
                            l4.ForeColor = AjustesDeUsuario.foreColor;

                            Label l5 = new Label(); //Arbitro
                            l5.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            l5.Text = arbitro.Nombre+" "+arbitro.Apellido;
                            l5.Size = new Size(200, 25);
                            l5.TextAlign = ContentAlignment.MiddleCenter;
                            l5.Location = new Point(p3.Width - l4.Width, 12);
                            l5.RightToLeft = RightToLeft.Yes;
                            l5.AutoSize = false;
                            l5.BorderStyle = BorderStyle.None;
                            l5.TabIndex = 3;
                            l5.ForeColor = AjustesDeUsuario.foreColor;

                            panelContenedor.Controls.Add(p3);
                            p3.Controls.Add(l3);
                            p3.Controls.Add(l4);
                            p3.Controls.Add(l5);
                            break;

                        case 2: // Alineamiento
                            PictureBox lineup = new PictureBox();

                            lineup.Size = new Size(725, 350);
                            lineup.BorderStyle = BorderStyle.None;
                            lineup.Location = new Point(0, 0);
                            lineup.Image = null;
                            break;
                        case 3: // Últimos 10 encuentros (del ganador)
                            foreach (var l in lastMatchsEq1)
                            {
                                int id = l.IdEncuentro;
                                Panel p4 = new Panel();

                                p4.Dock = DockStyle.Top;
                                p4.BorderStyle = BorderStyle.FixedSingle;
                                p4.Size = new Size(724, 50);
                                p4.TabIndex = 0;
                                p4.BackColor = AjustesDeUsuario.panel;

                                Label l2 = new Label();

                                l2.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l2.Text = l.Nombre;
                                l2.Size = new Size(600, 25);
                                l2.TextAlign = ContentAlignment.MiddleCenter;
                                l2.BorderStyle = BorderStyle.None;
                                l2.Location = new Point(62, 12);
                                l2.TabIndex = 3;
                                l2.ForeColor = AjustesDeUsuario.foreColor;

                                p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); };
                                l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); };

                                panelContenedor.Controls.Add(p4);
                                p4.Controls.Add(l2);
                            }
                            break;

                        case 4: // Resumen
                            for (int i = 1; i < rounds.Count() + 1; i++)
                            {
                                var hitos = this.hitos.FindAll(h => h.NumeroRound == i);
                                List<Hito> SortedHitos = hitos.OrderBy(h => h.TiempoHito).ToList();

                                Label l1 = new Label();

                                l1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                                l1.Text = $"Round {i}";
                                l1.Size = new Size(707, 25);
                                l1.TextAlign = ContentAlignment.MiddleCenter;
                                l1.AutoSize = false;
                                l1.BorderStyle = BorderStyle.FixedSingle;
                                l1.TabIndex = 3;
                                l1.ForeColor = AjustesDeUsuario.foreColor;
                                if (i == 1)
                                {
                                    l1.Location = new Point(0, 0);
                                }
                                else
                                {
                                    l1.Location = new Point(0, c * 25 * (i - 1) + (25 * (i - 1)));
                                }


                                Panel p5 = new Panel();

                                p5.BorderStyle = BorderStyle.FixedSingle;
                                p5.Size = new Size(707, c * 25);
                                p5.TabIndex = 0;
                                p5.BackColor = AjustesDeUsuario.panel;

                                if (i == 1)
                                {
                                    p5.Location = new Point(0, 25);
                                }
                                else
                                {
                                    p5.Location = new Point(0, c * 25 * (i - 1) + (25 * i));
                                }

                                panelContenedor.Controls.Add(l1);
                                panelContenedor.Controls.Add(p5);

                                int y = 0;
                                foreach (var h in SortedHitos)
                                {
                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{h.TiempoHito}'";
                                    l2.Size = new Size(66, 25);
                                    l2.AutoSize = false;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.TabIndex = 3;
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l6 = new Label();

                                    l6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l6.Text = h.TituloHito;
                                    l6.Size = new Size(65, 25);
                                    l6.AutoSize = true;
                                    l6.BorderStyle = BorderStyle.None;
                                    l6.TabIndex = 3;
                                    l6.ForeColor = AjustesDeUsuario.foreColor;

                                    l2.Location = new Point(0, 25 * y);
                                    l6.Location = new Point(l2.Width, 25 * y);

                                    p5.Controls.Add(l2);
                                    p5.Controls.Add(l6);
                                    y++;
                                }
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (b)
                    {
                        case 1: // Jugadores
                            if (c > 6)
                            {
                                big = 18;
                            } else
                            {
                                big = 0;
                            }

                            Panel p8 = new Panel();

                            p8.BorderStyle = BorderStyle.FixedSingle;
                            p8.Size = new Size(724 - big, 25);
                            p8.Location = new Point(0, 0);
                            p8.TabIndex = 0;
                            p8.BackColor = AjustesDeUsuario.panel;

                            Label l1 = new Label();

                            l1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                            l1.Text = $"Round";
                            l1.Size = new Size(124 - big, 25);
                            l1.TextAlign = ContentAlignment.MiddleLeft;
                            l1.AutoSize = false;
                            l1.BorderStyle = BorderStyle.FixedSingle;
                            l1.TabIndex = 3;
                            l1.Location = new Point(0, 0);
                            l1.ForeColor = AjustesDeUsuario.foreColor;

                            Panel p9 = new Panel();

                            p9.BorderStyle = BorderStyle.FixedSingle;
                            p9.Size = new Size(724 - big, 25);
                            p9.Location = new Point(0, 25);
                            p9.TabIndex = 0;
                            p9.BackColor = AjustesDeUsuario.panel;

                            Label l8 = new Label();

                            l8.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                            l8.Text = equiposEncuentro[0].NombreEquipo;
                            l8.Size = new Size(124 - big, 25);
                            l8.TextAlign = ContentAlignment.MiddleLeft;
                            l8.AutoSize = false;
                            l8.BorderStyle = BorderStyle.FixedSingle;
                            l8.TabIndex = 3;
                            l8.Location = new Point(0, 0);
                            l8.ForeColor = AjustesDeUsuario.foreColor;

                            Panel p10 = new Panel();

                            p10.BorderStyle = BorderStyle.FixedSingle;
                            p10.Size = new Size(724 - big, 25);
                            p10.Location = new Point(0, 50);
                            p10.TabIndex = 0;
                            p10.BackColor = AjustesDeUsuario.panel;

                            Label l7 = new Label();

                            l7.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                            l7.Text = equiposEncuentro[1].NombreEquipo;
                            l7.Size = new Size(124 - big, 25);
                            l7.TextAlign = ContentAlignment.MiddleLeft;
                            l7.AutoSize = false;
                            l7.BorderStyle = BorderStyle.FixedSingle;
                            l7.TabIndex = 3;
                            l7.Location = new Point(0, 0);
                            l7.ForeColor = AjustesDeUsuario.foreColor;

                            panelContenedor.Controls.Add(p8);
                            panelContenedor.Controls.Add(p9);
                            panelContenedor.Controls.Add(p10);
                            p8.Controls.Add(l1);
                            p9.Controls.Add(l8);
                            p10.Controls.Add(l7);

                            for (int i = 1; i < rounds.Count() + 1; i++)
                            {
                                var pR = Logica.GetPuntuacionRounds(2, id, i);
                                int eq1 = pR.Find(p => p.IdEquipos == equipos[0].IdEquipo).Puntos,
                                    eq2 = pR.Find(p => p.IdEquipos == equipos[1].IdEquipo).Puntos;

                                Label l9 = new Label();

                                l9.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                                l9.Text = $"{i}";
                                l9.Size = new Size(600 / rounds.Count(), 25);
                                l9.TextAlign = ContentAlignment.MiddleLeft;
                                l9.AutoSize = false;
                                l9.BorderStyle = BorderStyle.FixedSingle;
                                l9.TabIndex = 3;
                                l9.Location = new Point(124 + ((600 / rounds.Count()) * (i - 1)) - big, 0);
                                l9.ForeColor = AjustesDeUsuario.foreColor;

                                Label l10 = new Label();

                                l10.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                                l10.Text = $"{eq1}";
                                l10.Size = new Size(600 / rounds.Count(), 25);
                                l10.TextAlign = ContentAlignment.MiddleLeft;
                                l10.AutoSize = false;
                                l10.BorderStyle = BorderStyle.FixedSingle;
                                l10.TabIndex = 3;
                                l10.Location = new Point(124 + ((600 / rounds.Count()) * (i - 1)) - big, 0);
                                l10.ForeColor = AjustesDeUsuario.foreColor;

                                Label l11 = new Label();

                                l11.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                                l11.Text = $"{eq2}";
                                l11.Size = new Size(600 / rounds.Count(), 25);
                                l11.TextAlign = ContentAlignment.MiddleLeft;
                                l11.AutoSize = false;
                                l11.BorderStyle = BorderStyle.FixedSingle;
                                l11.TabIndex = 3;
                                l11.Location = new Point(124 + ((600 / rounds.Count()) * (i - 1)) - big, 0);
                                l11.ForeColor = AjustesDeUsuario.foreColor;

                                p8.Controls.Add(l9);
                                p9.Controls.Add(l10);
                                p10.Controls.Add(l11);
                            }

                            Label l2 = new Label();

                            l2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                            l2.Text = btnJugadores.Text;
                            l2.Size = new Size(724 - big, 25);
                            l2.TextAlign = ContentAlignment.MiddleCenter;
                            l2.AutoSize = false;
                            l2.BorderStyle = BorderStyle.FixedSingle;
                            l2.TabIndex = 3;
                            l2.Location = new Point(0, 75);
                            l2.ForeColor = AjustesDeUsuario.foreColor;

                            Panel p1 = new Panel();

                            p1.BorderStyle = BorderStyle.FixedSingle;
                            p1.Size = new Size(362, c * 25);
                            p1.Location = new Point(0, 100);
                            p1.TabIndex = 0;
                            p1.BackColor = AjustesDeUsuario.panel;

                            Panel p2 = new Panel();

                            p2.BorderStyle = BorderStyle.FixedSingle;
                            p2.Size = new Size(362 - big, c * 25);
                            p2.Location = new Point(362, 100);
                            p2.TabIndex = 0;
                            p2.BackColor = AjustesDeUsuario.panel;

                            Panel p3 = new Panel();

                            p3.Size = new Size(724, 50);
                            p3.TabIndex = 0;
                            p3.BackColor = AjustesDeUsuario.panel;

                            if (c * 25 < 201)
                            {
                                p3.Location = new Point(0, 301);
                            }
                            else
                            {
                                p3.Location = new Point(0, c * 25);
                            }

                            panelContenedor.Controls.Add(l2);
                            panelContenedor.Controls.Add(p1);
                            panelContenedor.Controls.Add(p2);
                            panelContenedor.Controls.Add(p3);

                            for (int i = 1; i < equipos.Count() + 1; i++)
                            {
                                for (int j = 1; j < equipos[i - 1].Miembros.Count() + 1; j++)
                                {
                                    var eq = equipos[i - 1];
                                    int idPersona = eq.Miembros[j - 1].IdPersona;
                                    Panel p4 = new Panel();

                                    p4.Dock = DockStyle.Top;
                                    p4.BorderStyle = BorderStyle.FixedSingle;
                                    p4.Size = new Size(265, 25);
                                    p4.TabIndex = 0;
                                    p4.BackColor = AjustesDeUsuario.panel;

                                    LinkLabel llb = new LinkLabel(); //Deportista

                                    llb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    llb.Text = equipos[i - 1].Miembros[j - 1].Nombre+" "+ equipos[i - 1].Miembros[j - 1].Apellido;
                                    llb.Size = new Size(200, 25);
                                    llb.DisabledLinkColor = AjustesDeUsuario.foreColor;
                                    llb.VisitedLinkColor = AjustesDeUsuario.foreColor;
                                    llb.ActiveLinkColor = AjustesDeUsuario.foreColor;
                                    llb.LinkBehavior = LinkBehavior.NeverUnderline;
                                    llb.LinkColor = AjustesDeUsuario.foreColor;
                                    llb.Dock = DockStyle.Left;
                                    llb.AutoSize = false;
                                    llb.BorderStyle = BorderStyle.None;
                                    llb.Location = new Point(0, 0);
                                    llb.TabIndex = 3;
                                    llb.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb); };
                                    llb.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb); };
                                    llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs, idPersona, 2); };

                                    if (i == 1)
                                    {
                                        p2.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p1.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(llb);
                                }

                                Label l3 = new Label(); //Lugar
                                l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l3.Text = $"Lugar";
                                l3.Size = new Size(200, 25);
                                l3.TextAlign = ContentAlignment.MiddleCenter;
                                l3.AutoSize = false;
                                l3.BorderStyle = BorderStyle.None;
                                l3.Location = new Point(0, 12);
                                l3.TabIndex = 3;
                                l3.ForeColor = AjustesDeUsuario.foreColor;

                                Label l4 = new Label(); //Clima
                                l4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l4.Text = $"Clima";
                                l4.Size = new Size(200, 25);
                                l4.TextAlign = ContentAlignment.MiddleCenter;
                                l4.AutoSize = false;
                                l4.BorderStyle = BorderStyle.None;
                                l4.Location = new Point((p3.Width / 2) - (l4.Width / 2), 12);
                                l4.TabIndex = 3;
                                l4.ForeColor = AjustesDeUsuario.foreColor;

                                Label l5 = new Label(); //Arbitro
                                l5.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l5.Text = $"Arbitro";
                                l5.Size = new Size(200, 25);
                                l5.TextAlign = ContentAlignment.MiddleCenter;
                                l5.Location = new Point(p3.Width - l4.Width, 12);
                                l5.RightToLeft = RightToLeft.Yes;
                                l5.AutoSize = false;
                                l5.BorderStyle = BorderStyle.None;
                                l5.TabIndex = 3;
                                l5.ForeColor = AjustesDeUsuario.foreColor;

                                p3.Controls.Add(l3);
                                p3.Controls.Add(l4);
                                p3.Controls.Add(l5);
                            }
                            break;

                        case 2: // Alineamiento
                            PictureBox lineup = new PictureBox();

                            lineup.Size = new Size(725, 350);
                            lineup.BorderStyle = BorderStyle.None;
                            lineup.Location = new Point(0, 0);
                            lineup.Image = null;
                            break;

                        case 3: // Últimos 10 encuentros
                            Panel p7 = new Panel();

                            p7.BorderStyle = BorderStyle.FixedSingle;
                            p7.Size = new Size(362, 500);
                            p7.Location = new Point(0, 0);
                            p7.TabIndex = 0;
                            p7.BackColor = AjustesDeUsuario.panel;

                            Panel p12 = new Panel();

                            p12.BorderStyle = BorderStyle.FixedSingle;
                            p12.Size = new Size(345, 500);
                            p12.Location = new Point(362, 0);
                            p12.TabIndex = 0;
                            p12.BackColor = AjustesDeUsuario.panel;

                            panelContenedor.Controls.Add(p7);
                            panelContenedor.Controls.Add(p12);

                            for (int i = 0; i < equipos.Count(); i++)
                            {
                                List<EquiposEncuentros> eqEnc;
                                if (i == 0) { eqEnc = lastMatchsEq1; } else { eqEnc = lastMatchsEq2; }
                                
                                foreach (var enc in eqEnc)
                                {
                                    int id = enc.IdEncuentro;
                                    Panel p4 = new Panel();

                                    p4.Dock = DockStyle.Top;
                                    p4.BorderStyle = BorderStyle.FixedSingle;
                                    if (i == 1)
                                    {
                                        p4.Size = new Size(362, 50);
                                    }
                                    else
                                    {
                                        p4.Size = new Size(345, 50);
                                    }
                                    p4.TabIndex = 0;
                                    p4.BackColor = AjustesDeUsuario.panel;

                                    Label l9 = new Label();

                                    l9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                    l9.Text = enc.Nombre;
                                    if (i == 1)
                                    {
                                        l9.Size = new Size((l9.Text.Length * 10), 25);
                                    }
                                    else
                                    {
                                        l9.Size = new Size((l9.Text.Length * 9), 25);
                                    }
                                    l9.AutoSize = true;
                                    l9.BorderStyle = BorderStyle.None;
                                    l9.Location = new Point(p4.Width / 2 - l9.Width / 2, 12);
                                    l9.TabIndex = 3;
                                    l9.ForeColor = AjustesDeUsuario.foreColor;

                                    p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); };
                                    l9.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); };;

                                    if (i == 1)
                                    {
                                        p7.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p12.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(l9);
                                }
                            }
                            break;

                        case 4: // Resumen
                            for (int i = 1; i < rounds.Count() + 1; i++)
                            {
                                var hitos = this.hitos.FindAll(h => h.NumeroRound == i);
                                List<Hito> SortedHitos = hitos.OrderBy(h => h.TiempoHito).ToList();

                                Label l5 = new Label();

                                l5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                                l5.Text = $"Round {i}";
                                l5.Size = new Size(707, 25);
                                l5.TextAlign = ContentAlignment.MiddleCenter;
                                l5.AutoSize = false;
                                l5.BorderStyle = BorderStyle.FixedSingle;
                                l5.TabIndex = 3;
                                l5.ForeColor = AjustesDeUsuario.foreColor;
                                if (i == 0)
                                {
                                    l5.Location = new Point(0, 0);
                                }
                                else
                                {
                                    l5.Location = new Point(0, c * 25 * (i - 1) + (25 * (i - 1)));
                                }

                                Panel p5 = new Panel();

                                p5.BorderStyle = BorderStyle.None;
                                p5.Size = new Size(344, c * 25);
                                p5.Location = new Point(0, c * 25 * (i - 1) + (25 * i));
                                p5.TabIndex = 0;
                                p5.BackColor = AjustesDeUsuario.panel;

                                panelContenedor.Controls.Add(l5);
                                panelContenedor.Controls.Add(p5);

                                int y = 0;
                                foreach (var h in SortedHitos)
                                {
                                    Label l6 = new Label();

                                    l6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l6.Text = $"{h.TiempoHito}'";
                                    l6.Size = new Size(66, 25);
                                    l6.AutoSize = false;
                                    l6.BorderStyle = BorderStyle.None;
                                    l6.TabIndex = 3;
                                    l6.Location = new Point(0, 25 * y);
                                    l6.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l3 = new Label();

                                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l3.Text = $"{h.TituloHito}";
                                    l3.Size = new Size(65, 25);
                                    l3.AutoSize = true;
                                    l3.BorderStyle = BorderStyle.None;
                                    l3.TabIndex = 3;
                                    l3.ForeColor = AjustesDeUsuario.foreColor;
                                    l3.Location = new Point(l6.Width, 25 * y);

                                    p5.Controls.Add(l6);
                                    p5.Controls.Add(l3);
                                    y++;
                                }
                            }
                            break;
                    }
                    break;

                case 4:
                    btnAlineamiento.Hide();
                    btnJugadores.Hide();
                    btnResumen.Size = new Size(362, 30);
                    btnResumen.Location = new Point(362, 35);
                    btnUltimosEncuentros.Size = new Size(362, 30);
                    btnUltimosEncuentros.Location = new Point(0, 35);

                    panelContenedor.Size = new Size(725, 301);

                    Panel p11 = new Panel();

                    p11.Size = new Size(724, 50);
                    p11.TabIndex = 0;
                    p11.Location = new Point(0, 366);
                    p11.BorderStyle = BorderStyle.FixedSingle;
                    p11.BackColor = AjustesDeUsuario.panel;

                    Label l14 = new Label(); //Lugar

                    l14.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l14.Text = encuentro.Lugar;
                    l14.Size = new Size(200, 25);
                    l14.TextAlign = ContentAlignment.MiddleCenter;
                    l14.AutoSize = false;
                    l14.BorderStyle = BorderStyle.None;
                    l14.Location = new Point(0, 12);
                    l14.TabIndex = 3;
                    l14.ForeColor = AjustesDeUsuario.foreColor;

                    Label l12 = new Label(); //Clima

                    l12.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l12.Text = encuentro.Clima;
                    l12.Size = new Size(200, 25);
                    l12.TextAlign = ContentAlignment.MiddleCenter;
                    l12.AutoSize = false;
                    l12.BorderStyle = BorderStyle.None;
                    l12.Location = new Point((p11.Width / 2) - (l12.Width / 2), 12);
                    l12.TabIndex = 3;
                    l12.ForeColor = AjustesDeUsuario.foreColor;

                    Label l13 = new Label(); //Arbitro

                    l13.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l13.Text = arbitro.Nombre+" "+arbitro.Apellido;
                    l13.Size = new Size(200, 25);
                    l13.TextAlign = ContentAlignment.MiddleCenter;
                    l13.Location = new Point(p11.Width - l13.Width, 12);
                    l13.RightToLeft = RightToLeft.Yes;
                    l13.AutoSize = false;
                    l13.BorderStyle = BorderStyle.None;
                    l13.TabIndex = 3;
                    l13.ForeColor = AjustesDeUsuario.foreColor;

                    panelPrincipal.Controls.Add(p11);
                    p11.Controls.Add(l14);
                    p11.Controls.Add(l12);
                    p11.Controls.Add(l13);

                    switch (b)
                    {
                        case 3: //Ultimos 10 encuentros
                            Panel p7 = new Panel();

                            p7.BorderStyle = BorderStyle.FixedSingle;
                            p7.Size = new Size(362, 500);
                            p7.Location = new Point(0, 0);
                            p7.TabIndex = 0;
                            p7.BackColor = AjustesDeUsuario.panel;

                            Panel p8 = new Panel();

                            p8.BorderStyle = BorderStyle.FixedSingle;
                            p8.Size = new Size(345, 500);
                            p8.Location = new Point(362, 0);
                            p8.TabIndex = 0;
                            p8.BackColor = AjustesDeUsuario.panel;

                            panelContenedor.Controls.Add(p7);
                            panelContenedor.Controls.Add(p8);

                            for (int i = 0; i < equipos.Count(); i++)
                            {
                                List<EquiposEncuentros> eqEnc;
                                if (i == 0) { eqEnc = lastMatchsEq1; } else { eqEnc = lastMatchsEq2; }

                                foreach (var enc in eqEnc)
                                {
                                    int id = enc.IdEncuentro;
                                    Panel p4 = new Panel();

                                    p4.Dock = DockStyle.Top;
                                    p4.BorderStyle = BorderStyle.FixedSingle;
                                    if (i == 1)
                                    {
                                        p4.Size = new Size(362, 50);
                                    }
                                    else
                                    {
                                        p4.Size = new Size(345, 50);
                                    }
                                    p4.TabIndex = 0;
                                    p4.BackColor = AjustesDeUsuario.panel;

                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = enc.Nombre;
                                    if (i == 1)
                                    {
                                        l2.Size = new Size((l2.Text.Length * 10), 25);
                                    }
                                    else
                                    {
                                        l2.Size = new Size((l2.Text.Length * 9), 25);
                                    }
                                    l2.AutoSize = true;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.Location = new Point(p4.Width / 2 - l2.Width / 2, 12);
                                    l2.TabIndex = 3;
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); };
                                    l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs, id); }; ;

                                    if (i == 1)
                                    {
                                        p7.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p8.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(l2);
                                }
                            }
                            break;
                        case 4: //Resumen
                            for (int i = 1; i < rounds.Count() + 1; i++)
                            {
                                var hitos = this.hitos.FindAll(h => h.NumeroRound == i);
                                List<Hito> SortedHitos = hitos.OrderBy(h => h.TiempoHito).ToList();

                                Label l1 = new Label();

                                l1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                                l1.Text = $"Round {i}";
                                l1.Size = new Size(707, 25);
                                l1.TextAlign = ContentAlignment.MiddleCenter;
                                l1.AutoSize = false;
                                l1.BorderStyle = BorderStyle.FixedSingle;
                                l1.TabIndex = 3;
                                l1.ForeColor = AjustesDeUsuario.foreColor;
                                if (i == 0)
                                {
                                    l1.Location = new Point(0, 0);
                                }
                                else
                                {
                                    l1.Location = new Point(0, c * 25 * (i - 1) + (25 * (i - 1)));
                                }

                                Panel p5 = new Panel();

                                p5.BorderStyle = BorderStyle.None;
                                p5.Size = new Size(344, c * 25);
                                p5.Location = new Point(0, c * 25 * (i - 1) + (25 * i));
                                p5.TabIndex = 0;
                                p5.BackColor = AjustesDeUsuario.panel;

                                panelContenedor.Controls.Add(l1);
                                panelContenedor.Controls.Add(p5);

                                int y = 0;
                                foreach (var h in SortedHitos)
                                {
                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{h.TiempoHito}'";
                                    l2.Size = new Size(66, 25);
                                    l2.AutoSize = false;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.TabIndex = 3;
                                    l2.Location = new Point(0, 25 * y);
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l3 = new Label();

                                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l3.Text = $"{h.TituloHito}";
                                    l3.Size = new Size(65, 25);
                                    l3.AutoSize = true;
                                    l3.BorderStyle = BorderStyle.None;
                                    l3.TabIndex = 3;
                                    l3.ForeColor = AjustesDeUsuario.foreColor;
                                    l3.Location = new Point(l2.Width, 25 * y);

                                    p5.Controls.Add(l2);
                                    p5.Controls.Add(l3);
                                    y++;
                                }
                            }
                            break;
                    }
                    break;
            }
        }

        private void mouseHover_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = Color.MediumVioletRed;
        }

        private void mouseLeave_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = AjustesDeUsuario.foreColor;
        }

        private void llb_Click(object sender, EventArgs e, int id, int tipo)
        {
            Principal.AlterPrincipal(2, 6, id);
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            CargarContenedor(encuentro.TipoEncuentro, 1, 12);
        }

        private void btnAlineamiento_Click(object sender, EventArgs e)
        {
            CargarContenedor(encuentro.TipoEncuentro, 2, 0);
        }

        private void btnUltimosEncuentros_Click(object sender, EventArgs e)
        {
            CargarContenedor(encuentro.TipoEncuentro, 3, 0);
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            CargarContenedor(encuentro.TipoEncuentro, 4, 10);
        }

        private void UltimoEncuentro_Click(object sender, EventArgs e, int id)
        {
            Principal.AlterPrincipal(id, 5, 0);
        }

        private void llbTeam1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e, int id)
        {
            Principal.AlterPrincipal(1, 6, id);
        }

        public static void AlterEncuentros(int x)
        {
            switch (x)
            {
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                        form.CargarContenedor('A', 1, 11);
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

        private void SetTheme()
        {
            /* Paneles */
            BackColor = AjustesDeUsuario.panel;
            panelContenedor.BackColor = AjustesDeUsuario.panel;
            panelHeader.BackColor = AjustesDeUsuario.panel;
            panelPrincipal.BackColor = AjustesDeUsuario.panel;
            panelTeam1.BackColor = AjustesDeUsuario.panel;
            panelTeam2.BackColor = AjustesDeUsuario.panel;
            /* Botones */
            btnAlineamiento.BackColor = AjustesDeUsuario.btnBack;
            btnAlineamiento.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnAlineamiento.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnJugadores.BackColor = AjustesDeUsuario.btnBack;
            btnJugadores.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnJugadores.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnResumen.BackColor = AjustesDeUsuario.btnBack;
            btnResumen.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnResumen.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnUltimosEncuentros.BackColor = AjustesDeUsuario.btnBack;
            btnUltimosEncuentros.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnUltimosEncuentros.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            /* Textos (Incluidos botones) */
            lblMarcador.ForeColor = AjustesDeUsuario.foreColor;
            lblState.ForeColor = AjustesDeUsuario.foreColor;
            llbTeam2.ActiveLinkColor = AjustesDeUsuario.foreColor;
            llbTeam2.DisabledLinkColor = AjustesDeUsuario.foreColor;
            llbTeam2.LinkColor = AjustesDeUsuario.foreColor;
            llbTeam2.VisitedLinkColor = AjustesDeUsuario.foreColor;
            llbTeam1.ActiveLinkColor = AjustesDeUsuario.foreColor;
            llbTeam1.DisabledLinkColor = AjustesDeUsuario.foreColor;
            llbTeam1.LinkColor = AjustesDeUsuario.foreColor;
            llbTeam1.VisitedLinkColor = AjustesDeUsuario.foreColor;
            btnAlineamiento.ForeColor = AjustesDeUsuario.foreColor;
            btnJugadores.ForeColor = AjustesDeUsuario.foreColor;
            btnResumen.ForeColor = AjustesDeUsuario.foreColor;
            btnUltimosEncuentros.ForeColor = AjustesDeUsuario.foreColor;
        }

        private void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    btnJugadores.Text = "Players";
                    btnAlineamiento.Text = "Alignment";
                    btnResumen.Text = "Summary";
                    btnUltimosEncuentros.Text = "Last matches";
                    break;
                case "ES": //Español
                    btnJugadores.Text = "Jugadores";
                    btnAlineamiento.Text = "Alineamiento";
                    btnResumen.Text = "Resumen";
                    btnUltimosEncuentros.Text = "Últimos encuentros";
                    break;
            }
        }

        private void picFavorito_Click(object sender, EventArgs e)
        {
            if (favorite == false)
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaRellena;
                favorite = true;
                Logica.InsertEncuentrosFavoritos(Program.user.email, id);
                Program.refreshFavorites();
            }
            else
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaVacia;
                favorite = false;
                Logica.Delete("EncuentrosFavoritos", "Email", Program.user.email, "IdEncuentro", "" + id);
                Program.refreshFavorites();
            }
        }
    }
}