namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_Encuentros_Tipo_A : Form
    {
        public Frm_Encuentros_Tipo_A()
        {
            InitializeComponent();

            CargarContenedor(1, 11);
        }

        private void CargarContenedor(int b, int c) //Carga los controles de panelContenedor
        {
            int e = 1;
            panelContenedor.Controls.Clear();

            switch (b)
            {
                case 1: // Jugadores

                    Panel p1 = new Panel();

                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Size = new Size(362, c*25);
                    p1.Location = new Point(0, 0);
                    p1.TabIndex = 0;

                    Panel p2 = new Panel();

                    p2.BorderStyle = BorderStyle.FixedSingle;
                    p2.Size = new Size(362, c*25);
                    p2.Location = new Point(362, 0);
                    p2.TabIndex = 0;

                    Panel p3 = new Panel();

                    p3.Size = new Size(724, 50);
                    p3.TabIndex = 0;

                    if (c*25 < 301)
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
                        for (int j = 0; j < c; j++)
                        {
                            Panel p4 = new Panel();

                            p4.Dock = DockStyle.Top;
                            p4.BorderStyle = BorderStyle.FixedSingle;
                            p4.Size = new Size(265, 25);
                            p4.TabIndex = 0;

                            LinkLabel llb = new LinkLabel();

                            llb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            llb.Text = $"Leonel Messi";
                            llb.Size = new Size(200, 25);
                            llb.DisabledLinkColor = Color.Black;
                            llb.VisitedLinkColor = Color.Black;
                            llb.ActiveLinkColor = Color.Black;
                            llb.LinkBehavior = LinkBehavior.NeverUnderline;
                            llb.LinkColor = Color.Black;
                            llb.Dock = DockStyle.Left;
                            llb.AutoSize = false;
                            llb.BorderStyle = BorderStyle.None;
                            llb.Location = new Point(0, 0);
                            llb.TabIndex = 3;
                            llb.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb); };
                            llb.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb); };
                            llb.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs); };

                            Label l2 = new Label();

                            l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            l2.Text = $"{j}";
                            l2.RightToLeft = RightToLeft.Yes;
                            l2.Dock = DockStyle.Right;
                            l2.Size = new Size(65, 25);
                            l2.AutoSize = false;
                            l2.BorderStyle = BorderStyle.None;
                            l2.Location = new Point(0, 0);
                            l2.TabIndex = 3;

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

                        Label l4 = new Label(); //Clima
                        l4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        l4.Text = $"Clima";
                        l4.Size = new Size(200, 25);
                        l4.TextAlign = ContentAlignment.MiddleCenter;
                        l4.AutoSize = false;
                        l4.BorderStyle = BorderStyle.None;
                        l4.Location = new Point((p3.Width/2) - (l4.Width/2), 12);
                        l4.TabIndex = 3;

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

                case 3: // Estadisticas
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
                        p5.Location = new Point(0, c * 25 * i + (25*i));
                        p5.TabIndex = 0;

                        Panel p6 = new Panel();

                        p6.BorderStyle = BorderStyle.None;
                        p6.Size = new Size(344, c * 25);
                        p6.Location = new Point(344, c * 25 * i + (25*i));
                        p6.TabIndex = 0;

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

                            Label l3 = new Label();

                            l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            l3.Text = $"Gol";
                            l3.Size = new Size(65, 25);
                            l3.AutoSize = true;
                            l3.BorderStyle = BorderStyle.None;
                            l3.TabIndex = 3;

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
                                l2.Location = new Point(344-l2.Width/2, 25 * j);
                                l3.RightToLeft = RightToLeft.Yes;
                                l3.Location = new Point(344-(l2.Width+l3.Width)/2, 25 * j);

                                p6.Controls.Add(l2);
                                p6.Controls.Add(l3);
                                e = 1;
                            }
                        }
                    }
                    break;
            }
        }

        private void mouseHover_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = Color.IndianRed;
        }

        private void mouseLeave_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = Color.Black;
        }

        private void llb_Click(object sender, EventArgs e)
        {

        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            CargarContenedor(4, 10);
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            CargarContenedor(1, 11);
        }

        private void btnAlineamiento_Click(object sender, EventArgs e)
        {
            CargarContenedor(2, 0);
        }
    }
}
