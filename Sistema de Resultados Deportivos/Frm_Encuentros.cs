namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_Encuentros : Form
    {
        private static Frm_Encuentros form = null;
        public Frm_Encuentros()
        {
            InitializeComponent();
            SetTheme();
            SetIdioma();
            form = this;

            llbTeam2.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, this.llbTeam2); };
            llbTeam2.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, this.llbTeam2); };
            llbTeam1.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llbTeam1); };
            llbTeam1.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llbTeam1); };

            llbTeam1.Text = "Team1";

            CargarContenedor('A', 1, 11);
        }

        private void CargarContenedor(char a, int b, int c) //Carga los controles de panelContenedor
        {
            int e = 1;
            int big = 0;
            panelContenedor.Controls.Clear();

            switch (a)
            {
                case 'A':
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

                            this.panelContenedor.Controls.Add(p1);
                            this.panelContenedor.Controls.Add(p2);
                            this.panelContenedor.Controls.Add(p3);

                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 1; j < c+1; j++)
                                {
                                    Panel p4 = new Panel();

                                    p4.Dock = DockStyle.Top;
                                    p4.BorderStyle = BorderStyle.FixedSingle;
                                    p4.Size = new Size(265, 25);
                                    p4.TabIndex = 0;
                                    p4.BackColor = AjustesDeUsuario.panel;

                                    LinkLabel llb = new LinkLabel(); //Deportista

                                    llb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    llb.Text = $"Leonel Messi";
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
                                    llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs); };

                                    Label l2 = new Label(); //Data

                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{j}";
                                    l2.RightToLeft = RightToLeft.Yes;
                                    l2.Dock = DockStyle.Right;
                                    l2.Size = new Size(65, 25);
                                    l2.AutoSize = false;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.Location = new Point(0, 0);
                                    l2.TabIndex = 3;
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    if (i == 1)
                                    {
                                        p1.Controls.Add(p4);
                                    } else
                                    {
                                        p2.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(llb);
                                    p4.Controls.Add(l2);
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

                            Panel p8 = new Panel();

                            p8.BorderStyle = BorderStyle.FixedSingle;
                            p8.Size = new Size(345, 500);
                            p8.Location = new Point(362, 0);
                            p8.TabIndex = 0;
                            p8.BackColor = AjustesDeUsuario.panel;

                            this.panelContenedor.Controls.Add(p7);
                            this.panelContenedor.Controls.Add(p8);

                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
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

                                    PictureBox pic1 = new PictureBox();

                                    pic1.InitialImage = null;
                                    pic1.BackColor = Color.Transparent;
                                    pic1.Size = new Size(40, 40);
                                    pic1.Location = new Point(10, 5);
                                    pic1.TabIndex = 1;
                                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pic1.Image = Properties.Resources.barcelona;

                                    PictureBox pic2 = new PictureBox();

                                    pic2.InitialImage = null;
                                    pic2.BackColor = Color.Transparent;
                                    pic2.Size = new Size(40, 40);
                                    pic2.Location = new Point(295, 5);
                                    pic2.TabIndex = 1;
                                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pic2.Image = Properties.Resources.barcelona;

                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{j} - {j}";
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

                                    p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    pic2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    pic1.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };

                                    if (i == 1)
                                    {
                                        p7.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p8.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(l2);
                                    p4.Controls.Add(pic2);
                                    p4.Controls.Add(pic1);
                                }
                            }
                            break;

                        case 4: // Resumen
                            for (int i = 0; i < 3; i++)
                            {
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
                                    l1.Location = new Point(0, c * 25 * i + (25 * (i - 1)));
                                }


                                Panel p5 = new Panel();

                                p5.BorderStyle = BorderStyle.None;
                                p5.Size = new Size(344, c * 25);
                                p5.Location = new Point(0, c * 25 * i + (25 * i));
                                p5.TabIndex = 0;
                                p5.BackColor = AjustesDeUsuario.panel;

                                Panel p6 = new Panel();

                                p6.BorderStyle = BorderStyle.None;
                                p6.Size = new Size(344, c * 25);
                                p6.Location = new Point(344, c * 25 * i + (25 * i));
                                p6.TabIndex = 0;
                                p6.BackColor = AjustesDeUsuario.panel;

                                this.panelContenedor.Controls.Add(l1);
                                this.panelContenedor.Controls.Add(p5);
                                this.panelContenedor.Controls.Add(p6);

                                for (int j = 0; j < c; j++)
                                {
                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{j}'";
                                    l2.Size = new Size(25, 25);
                                    l2.AutoSize = true;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.TabIndex = 3;
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l3 = new Label();

                                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l3.Text = $"Gol";
                                    l3.Size = new Size(65, 25);
                                    l3.AutoSize = true;
                                    l3.BorderStyle = BorderStyle.None;
                                    l3.TabIndex = 3;
                                    l3.ForeColor = AjustesDeUsuario.foreColor;

                                    if (e == 1)
                                    {
                                        l2.Location = new Point(0, 25 * j);
                                        l3.Location = new Point(l2.Width, 25 * j);

                                        p5.Controls.Add(l2);
                                        p5.Controls.Add(l3);
                                        e = 2;
                                    } else
                                    {
                                        l2.RightToLeft = RightToLeft.Yes;
                                        l2.Location = new Point(344 - l2.Width / 2, 25 * j);
                                        l3.RightToLeft = RightToLeft.Yes;
                                        l3.Location = new Point(344 - (l2.Width + l3.Width) / 2, 25 * j);

                                        p6.Controls.Add(l2);
                                        p6.Controls.Add(l3);
                                        e = 1;
                                    }
                                }
                            }
                            break;
                    }
                break;

                case 'B':
                    switch (b)
                    {
                        case 1: // Jugadores
                            for (int j = 1; j < c+1; j++)
                            {
                                Panel p4 = new Panel();
                                
                                p4.BorderStyle = BorderStyle.FixedSingle;
                                p4.TabIndex = 0;
                                p4.BackColor = AjustesDeUsuario.panel;

                                LinkLabel llb = new LinkLabel();

                                llb.Text = $"Leonel Messi";
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
                                llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs); };

                                Label l2 = new Label(); //Posición

                                l2.Text = $"{j}º";
                                l2.RightToLeft = RightToLeft.Yes;
                                l2.Dock = DockStyle.Right;
                                l2.Size = new Size(65, 25);
                                l2.TextAlign = ContentAlignment.MiddleLeft;
                                l2.AutoSize = false;
                                l2.BorderStyle = BorderStyle.None;
                                l2.Location = new Point(0, 0);
                                l2.TabIndex = 3;
                                l2.ForeColor = AjustesDeUsuario.foreColor;

                                if (j == 1)
                                {
                                    if (c > 11)
                                    {
                                        p4.Size = new Size(707, 50);
                                    }
                                    else
                                    {
                                        p4.Size = new Size(724, 50);
                                    }
                                    p4.Location = new Point(0, 0);
                                    llb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                }
                                else
                                {
                                    if (c > 11)
                                    {
                                        p4.Size = new Size(707, 25);
                                    } else
                                    {
                                        p4.Size = new Size(724, 25);
                                    }
                                    p4.Location = new Point(0, j*25);
                                    llb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                }

                                this.panelContenedor.Controls.Add(p4);
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

                            this.panelContenedor.Controls.Add(p3);
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
                            for (int j = 0; j < 10; j++)
                            {
                                Panel p4 = new Panel();

                                p4.Dock = DockStyle.Top;
                                p4.BorderStyle = BorderStyle.FixedSingle;
                                p4.Size = new Size(724, 50);
                                p4.TabIndex = 0;
                                p4.BackColor = AjustesDeUsuario.panel;

                                PictureBox pic1 = new PictureBox();

                                pic1.InitialImage = null;
                                pic1.BackColor = Color.Transparent;
                                pic1.Size = new Size(40, 40);
                                pic1.Location = new Point(10, 5);
                                pic1.TabIndex = 1;
                                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                pic1.Image = Properties.Resources.barcelona;

                                Label l2 = new Label();

                                l2.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                                l2.Text = $"Carrera final de la copa del mundo";
                                l2.Size = new Size(600, 25);
                                l2.TextAlign = ContentAlignment.MiddleCenter;
                                l2.BorderStyle = BorderStyle.None;
                                l2.Location = new Point(62, 12);
                                l2.TabIndex = 3;
                                l2.ForeColor = AjustesDeUsuario.foreColor;

                                p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                pic1.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };

                                this.panelContenedor.Controls.Add(p4);
                                p4.Controls.Add(l2);
                                p4.Controls.Add(pic1);
                            }
                            break;

                        case 4: // Resumen
                            for (int i = 1; i < 4; i++)
                            {
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

                                p5.BorderStyle = BorderStyle.None;
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

                                this.panelContenedor.Controls.Add(l1);
                                this.panelContenedor.Controls.Add(p5);

                                for (int j = 0; j < c; j++)
                                {
                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{j}'";
                                    l2.Size = new Size(25, 25);
                                    l2.AutoSize = true;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.TabIndex = 3;
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l6 = new Label();

                                    l6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l6.Text = $"Hito";
                                    l6.Size = new Size(65, 25);
                                    l6.AutoSize = true;
                                    l6.BorderStyle = BorderStyle.None;
                                    l6.TabIndex = 3;
                                    l6.ForeColor = AjustesDeUsuario.foreColor;

                                    l2.Location = new Point(0, 25 * j);
                                    l6.Location = new Point(l2.Width, 25 * j);

                                    p5.Controls.Add(l2);
                                    p5.Controls.Add(l6);
                                }
                            }
                            break;
                    }
                    break;
                case 'C':
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
                            l1.Text = $"Score";
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
                            l8.Text = $"Team 1";
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
                            l7.Text = $"Team 2";
                            l7.Size = new Size(124 - big, 25);
                            l7.TextAlign = ContentAlignment.MiddleLeft;
                            l7.AutoSize = false;
                            l7.BorderStyle = BorderStyle.FixedSingle;
                            l7.TabIndex = 3;
                            l7.Location = new Point(0, 0);
                            l7.ForeColor = AjustesDeUsuario.foreColor;

                            this.panelContenedor.Controls.Add(p8);
                            this.panelContenedor.Controls.Add(p9);
                            this.panelContenedor.Controls.Add(p10);
                            p8.Controls.Add(l1);
                            p9.Controls.Add(l8);
                            p10.Controls.Add(l7);

                            for (int i = 1; i < 12+1; i++)
                            {
                                Label l9 = new Label();

                                l9.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                                l9.Text = $"{i}";
                                l9.Size = new Size(50, 25);
                                l9.TextAlign = ContentAlignment.MiddleLeft;
                                l9.AutoSize = false;
                                l9.BorderStyle = BorderStyle.FixedSingle;
                                l9.TabIndex = 3;
                                l9.Location = new Point(124 + (50 * (i - 1)) - big, 0);
                                l9.ForeColor = AjustesDeUsuario.foreColor;

                                Label l10 = new Label();

                                l10.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                                l10.Text = $"2";
                                l10.Size = new Size(50, 25);
                                l10.TextAlign = ContentAlignment.MiddleLeft;
                                l10.AutoSize = false;
                                l10.BorderStyle = BorderStyle.FixedSingle;
                                l10.TabIndex = 3;
                                l10.Location = new Point(124 + (50 * (i - 1)) - big, 0);
                                l10.ForeColor = AjustesDeUsuario.foreColor;

                                Label l11 = new Label();

                                l11.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                                l11.Text = $"3";
                                l11.Size = new Size(50, 25);
                                l11.TextAlign = ContentAlignment.MiddleLeft;
                                l11.AutoSize = false;
                                l11.BorderStyle = BorderStyle.FixedSingle;
                                l11.TabIndex = 3;
                                l11.Location = new Point(124 + (50 * (i - 1)) - big, 0);
                                l11.ForeColor = AjustesDeUsuario.foreColor;

                                p8.Controls.Add(l9);
                                p9.Controls.Add(l10);
                                p10.Controls.Add(l11);
                            }

                            Label l2 = new Label();

                            l2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                            l2.Text = $"Players";
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

                            this.panelContenedor.Controls.Add(l2);
                            this.panelContenedor.Controls.Add(p1);
                            this.panelContenedor.Controls.Add(p2);
                            this.panelContenedor.Controls.Add(p3);

                            for (int i = 1; i < 3; i++)
                            {
                                for (int j = 1; j <= c; j++)
                                {
                                    Panel p4 = new Panel();

                                    p4.Dock = DockStyle.Top;
                                    p4.BorderStyle = BorderStyle.FixedSingle;
                                    p4.Size = new Size(265, 25);
                                    p4.TabIndex = 0;
                                    p4.BackColor = AjustesDeUsuario.panel;

                                    LinkLabel llb = new LinkLabel(); //Deportista

                                    llb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    llb.Text = $"Leonel Messi";
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
                                    llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs); };

                                    Label l6 = new Label(); //Data

                                    l6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l6.Text = $"{j}";
                                    l6.RightToLeft = RightToLeft.Yes;
                                    l6.Dock = DockStyle.Right;
                                    l6.Size = new Size(65, 25);
                                    l6.AutoSize = false;
                                    l6.BorderStyle = BorderStyle.None;
                                    l6.Location = new Point(0, 0);
                                    l6.TabIndex = 3;
                                    l6.ForeColor = AjustesDeUsuario.foreColor;

                                    if (i == 1)
                                    {
                                        p1.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p2.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(llb);
                                    p4.Controls.Add(l6);
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
                                l4.BackColor = AjustesDeUsuario.foreColor;

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

                            this.panelContenedor.Controls.Add(p7);
                            this.panelContenedor.Controls.Add(p12);

                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
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

                                    PictureBox pic1 = new PictureBox();

                                    pic1.InitialImage = null;
                                    pic1.BackColor = Color.Transparent;
                                    pic1.Size = new Size(40, 40);
                                    pic1.Location = new Point(10, 5);
                                    pic1.TabIndex = 1;
                                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pic1.Image = Properties.Resources.barcelona;

                                    PictureBox pic2 = new PictureBox();

                                    pic2.InitialImage = null;
                                    pic2.BackColor = Color.Transparent;
                                    pic2.Size = new Size(40, 40);
                                    pic2.Location = new Point(295, 5);
                                    pic2.TabIndex = 1;
                                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pic2.Image = Properties.Resources.barcelona;

                                    Label l6 = new Label();

                                    l6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                    l6.Text = $"{j} - {j}";
                                    if (i == 1)
                                    {
                                        l6.Size = new Size((l6.Text.Length * 10), 25);
                                    }
                                    else
                                    {
                                        l6.Size = new Size((l6.Text.Length * 9), 25);
                                    }
                                    l6.AutoSize = true;
                                    l6.BorderStyle = BorderStyle.None;
                                    l6.Location = new Point(p4.Width / 2 - l6.Width / 2, 12);
                                    l6.TabIndex = 3;
                                    l6.ForeColor = AjustesDeUsuario.foreColor;

                                    p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    l6.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    pic2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    pic1.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };

                                    if (i == 1)
                                    {
                                        p7.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p12.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(l6);
                                    p4.Controls.Add(pic2);
                                    p4.Controls.Add(pic1);
                                }
                            }
                            break;

                        case 4: // Resumen
                            for (int i = 0; i < 3; i++)
                            {
                                Label l6 = new Label();

                                l6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
                                l6.Text = $"Set {i}";
                                l6.Size = new Size(707, 25);
                                l6.TextAlign = ContentAlignment.MiddleCenter;
                                l6.AutoSize = false;
                                l6.BorderStyle = BorderStyle.FixedSingle;
                                l6.TabIndex = 3;
                                l6.ForeColor = AjustesDeUsuario.foreColor;
                                if (i == 0)
                                {
                                    l6.Location = new Point(0, 0);
                                }
                                else
                                {
                                    l6.Location = new Point(0, c * 25 * i + (25 * (i - 1)));
                                }

                                Panel p5 = new Panel();

                                p5.BorderStyle = BorderStyle.None;
                                p5.Size = new Size(344, c * 25);
                                p5.Location = new Point(0, c * 25 * i + (25 * i));
                                p5.TabIndex = 0;
                                p5.BackColor = AjustesDeUsuario.panel;

                                Panel p6 = new Panel();

                                p6.BorderStyle = BorderStyle.None;
                                p6.Size = new Size(344, c * 25);
                                p6.Location = new Point(344, c * 25 * i + (25 * i));
                                p6.TabIndex = 0;
                                p6.BackColor = AjustesDeUsuario.panel;

                                this.panelContenedor.Controls.Add(l6);
                                this.panelContenedor.Controls.Add(p5);
                                this.panelContenedor.Controls.Add(p6);

                                for (int j = 0; j < c; j++)
                                {
                                    Label l9 = new Label();

                                    l9.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l9.Text = $"{j}'";
                                    l9.Size = new Size(25, 25);
                                    l9.AutoSize = true;
                                    l9.BorderStyle = BorderStyle.None;
                                    l9.TabIndex = 3;
                                    l9.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l3 = new Label();

                                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l3.Text = $"Gol";
                                    l3.Size = new Size(65, 25);
                                    l3.AutoSize = true;
                                    l3.BorderStyle = BorderStyle.None;
                                    l3.TabIndex = 3;
                                    l3.ForeColor = AjustesDeUsuario.foreColor;

                                    if (e == 1)
                                    {
                                        l9.Location = new Point(0, 25 * j);
                                        l3.Location = new Point(l9.Width, 25 * j);

                                        p5.Controls.Add(l9);
                                        p5.Controls.Add(l3);
                                        e = 2;
                                    }
                                    else
                                    {
                                        l9.RightToLeft = RightToLeft.Yes;
                                        l9.Location = new Point(344 - l9.Width / 2, 25 * j);
                                        l3.RightToLeft = RightToLeft.Yes;
                                        l3.Location = new Point(344 - (l9.Width + l3.Width) / 2, 25 * j);

                                        p6.Controls.Add(l9);
                                        p6.Controls.Add(l3);
                                        e = 1;
                                    }
                                }
                            }
                            break;
                    }
                    break;

                case 'D':
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
                    l14.Text = $"Lugar";
                    l14.Size = new Size(200, 25);
                    l14.TextAlign = ContentAlignment.MiddleCenter;
                    l14.AutoSize = false;
                    l14.BorderStyle = BorderStyle.None;
                    l14.Location = new Point(0, 12);
                    l14.TabIndex = 3;
                    l14.ForeColor = AjustesDeUsuario.foreColor;

                    Label l12 = new Label(); //Clima

                    l12.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l12.Text = $"Clima";
                    l12.Size = new Size(200, 25);
                    l12.TextAlign = ContentAlignment.MiddleCenter;
                    l12.AutoSize = false;
                    l12.BorderStyle = BorderStyle.None;
                    l12.Location = new Point((p11.Width / 2) - (l12.Width / 2), 12);
                    l12.TabIndex = 3;
                    l12.ForeColor = AjustesDeUsuario.foreColor;

                    Label l13 = new Label(); //Arbitro

                    l13.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l13.Text = $"Arbitro";
                    l13.Size = new Size(200, 25);
                    l13.TextAlign = ContentAlignment.MiddleCenter;
                    l13.Location = new Point(p11.Width - l13.Width, 12);
                    l13.RightToLeft = RightToLeft.Yes;
                    l13.AutoSize = false;
                    l13.BorderStyle = BorderStyle.None;
                    l13.TabIndex = 3;
                    l13.ForeColor = AjustesDeUsuario.foreColor;

                    this.panelPrincipal.Controls.Add(p11);
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

                            this.panelContenedor.Controls.Add(p7);
                            this.panelContenedor.Controls.Add(p8);

                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
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

                                    PictureBox pic1 = new PictureBox();

                                    pic1.InitialImage = null;
                                    pic1.BackColor = Color.Transparent;
                                    pic1.Size = new Size(40, 40);
                                    pic1.Location = new Point(10, 5);
                                    pic1.TabIndex = 1;
                                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pic1.Image = Properties.Resources.barcelona;

                                    PictureBox pic2 = new PictureBox();

                                    pic2.InitialImage = null;
                                    pic2.BackColor = Color.Transparent;
                                    pic2.Size = new Size(40, 40);
                                    pic2.Location = new Point(295, 5);
                                    pic2.TabIndex = 1;
                                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pic2.Image = Properties.Resources.barcelona;

                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{j} - {j}";
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

                                    p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    pic2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                                    pic1.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };

                                    if (i == 1)
                                    {
                                        p7.Controls.Add(p4);
                                    }
                                    else
                                    {
                                        p8.Controls.Add(p4);
                                    }
                                    p4.Controls.Add(l2);
                                    p4.Controls.Add(pic2);
                                    p4.Controls.Add(pic1);
                                }
                            }
                            break;
                        case 4: //Resumen
                            for (int i = 1; i < 4; i++)
                            {
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

                                p5.BorderStyle = BorderStyle.None;
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

                                this.panelContenedor.Controls.Add(l1);
                                this.panelContenedor.Controls.Add(p5);

                                for (int j = 0; j < c; j++)
                                {
                                    Label l2 = new Label();

                                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l2.Text = $"{j}'";
                                    l2.Size = new Size(25, 25);
                                    l2.AutoSize = true;
                                    l2.BorderStyle = BorderStyle.None;
                                    l2.TabIndex = 3;
                                    l2.ForeColor = AjustesDeUsuario.foreColor;

                                    Label l6 = new Label();

                                    l6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                                    l6.Text = $"Hito";
                                    l6.Size = new Size(65, 25);
                                    l6.AutoSize = true;
                                    l6.BorderStyle = BorderStyle.None;
                                    l6.TabIndex = 3;
                                    l6.ForeColor = AjustesDeUsuario.foreColor;

                                    l2.Location = new Point(0, 25 * j);
                                    l6.Location = new Point(l2.Width, 25 * j);

                                    p5.Controls.Add(l2);
                                    p5.Controls.Add(l6);
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

        private void llb_Click(object sender, EventArgs e)
        {
            Principal.AlterPrincipal(2, 6, 0);
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            CargarContenedor('A', 1, 12);
        }

        private void btnAlineamiento_Click(object sender, EventArgs e)
        {
            CargarContenedor('A', 2, 0);
        }

        private void btnUltimosEncuentros_Click(object sender, EventArgs e)
        {
            CargarContenedor('A', 3, 0);
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            CargarContenedor('A', 4, 10);
        }

        private void UltimoEncuentro_Click(object sender, EventArgs e)
        {
            Principal.AlterPrincipal(0, 5, 0);
        }

        private void llbTeam1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Principal.AlterPrincipal(1, 6, 0);
        }

        private void llbTeam2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Principal.AlterPrincipal(1, 6, 0);
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
            lblSets.ForeColor = AjustesDeUsuario.foreColor;
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
                    btnResumen.Text = "Resume";
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
    }
}
