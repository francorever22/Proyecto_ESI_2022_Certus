namespace Sistema_de_Resultados_Deportivos
{
    public partial class BuscadorDeEncuentros : Form
    {
        private static BuscadorDeEncuentros form = null;
        bool mtcVisible;
        public BuscadorDeEncuentros()
        {
            InitializeComponent();
            form = this;
            SetTheme();
            SetIdioma();
            mtcFechasEventos.Hide();
            btnCalendario.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtBuscador.AutoSize = false;

            CargarEncuentros(10);
        }

        private void CargarEncuentros(int c) //Carga los botones de panelEncuentros uno por uno
        {
            panelEncuentros.Controls.Clear();
            String t = "torneo";
            for (int i = 0; i < c; i++)
            {
                switch (t)
                {
                    case "partido": //Crea opcion para encuentro
                        Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                        p1.Dock = System.Windows.Forms.DockStyle.Top;
                        p1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        p1.Size = new System.Drawing.Size(722, 60);
                        p1.TabIndex = 0;

                        PictureBox pic1 = new PictureBox(); //Imagen de Equipo 1

                        pic1.InitialImage = null;
                        pic1.BackColor = System.Drawing.Color.Transparent;
                        pic1.Size = new System.Drawing.Size(40, 40);
                        pic1.Location = new System.Drawing.Point(10, 10);
                        pic1.TabIndex = 1;
                        pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic1.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.barcelona;

                        PictureBox pic2 = new PictureBox(); //Imagen de Equipo 2

                        pic2.InitialImage = null;
                        pic2.BackColor = System.Drawing.Color.Transparent;
                        pic2.Size = new System.Drawing.Size(40, 40);
                        pic2.Location = new System.Drawing.Point(652, 10);
                        pic2.TabIndex = 2;
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic2.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.realmadrid;

                        Label l1 = new Label(); //Nombre de Equipo 1

                        l1.BackColor = System.Drawing.Color.Transparent;
                        l1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l1.Text = "Barcelona";
                        l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l1.MaximumSize = new System.Drawing.Size(300, 30);
                        l1.AutoSize = true;
                        l1.Location = new System.Drawing.Point(60, 16);
                        l1.TabIndex = 3;

                        Label l2 = new Label(); //Nombre de Equipo 2

                        l2.BackColor = System.Drawing.Color.Transparent;
                        l2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l2.Text = "Real-Madrid";
                        l2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                        l2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l2.MaximumSize = new System.Drawing.Size(300, 30);
                        l2.AutoSize = true;
                        l2.Location = new System.Drawing.Point(536, 16);
                        l2.TabIndex = 4;

                        Label l3 = new Label(); //Hora del encuentro

                        l3.BackColor = System.Drawing.Color.Transparent;
                        l3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l3.Text = "18:00";
                        l3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l3.Size = new System.Drawing.Size(l3.Text.Length * 12, 20);
                        l3.Location = new Point(p1.Width / 2 - l3.Width / 2, p1.Height - 25);
                        l3.TabIndex = 5;

                        Label l4 = new Label(); //Marcador del encuentro

                        l4.BackColor = System.Drawing.Color.Transparent;
                        l4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l4.Text = "10 - 10";
                        l4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l4.Size = new System.Drawing.Size(l4.Text.Length * 14, 30);
                        l4.Location = new Point(p1.Width / 2 - l4.Width/2, 8);
                        l4.TabIndex = 5;

                        p1.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs); };
                        l1.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs); };
                        l2.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs); };
                        l3.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs); };
                        l4.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs); };
                        pic1.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs); };
                        pic2.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs); };

                        switch (AjustesDeUsuario.darkTheme)
                        {
                            case false:
                                l1.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                l2.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                l3.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                l4.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                break;
                            case true:
                                l1.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                l2.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                l3.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                l4.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                break;
                        }

                        this.panelEncuentros.Controls.Add(p1); //Agrega los controles al panelEncuentros
                        p1.Controls.Add(pic1);
                        p1.Controls.Add(pic2);
                        p1.Controls.Add(l1);
                        p1.Controls.Add(l2);
                        p1.Controls.Add(l3);
                        p1.Controls.Add(l4);
                        break;

                    case "torneo": //Crea opcion para torneo
                        Panel p2 = new Panel(); //Crea el panel donde apareceran los controles

                        p2.Dock = System.Windows.Forms.DockStyle.Top;
                        p2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        p2.Size = new System.Drawing.Size(563, 60);


                        PictureBox pic3 = new PictureBox(); //Imagen de Equipo 1

                        pic3.InitialImage = null;
                        pic3.BackColor = System.Drawing.Color.Transparent;
                        pic3.Size = new System.Drawing.Size(40, 40);
                        pic3.Location = new System.Drawing.Point(10, 10);
                        pic3.TabIndex = 1;
                        pic3.SizeMode = PictureBoxSizeMode.StretchImage;

                        Label l6 = new Label(); //Nombre de Equipo 1

                        l6.BackColor = System.Drawing.Color.Transparent;
                        l6.BackColor = System.Drawing.Color.Transparent;
                        l6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l6.Text = "Torneo X";
                        l6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l6.MaximumSize = new System.Drawing.Size(300, 30);
                        l6.AutoSize = true;
                        l6.Location = new System.Drawing.Point(60, 16);
                        l6.TabIndex = 3;

                        Label l5 = new Label(); //Hora del encuentro

                        l5.BackColor = System.Drawing.Color.Transparent;
                        l5.BackColor = System.Drawing.Color.Transparent;
                        l5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l5.Text = "10:00";
                        l5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l5.MaximumSize = new System.Drawing.Size(100, 30);
                        l5.AutoSize = true;
                        l5.Location = new System.Drawing.Point(242, 14);
                        l5.TabIndex = 5;

                        l6.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs); };
                        l5.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs); };
                        p2.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs); };
                        pic3.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs); };

                        switch (AjustesDeUsuario.darkTheme)
                        {
                            case false:
                                l6.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                l5.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                break;
                            case true:
                                l6.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                l5.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                break;
                        }

                        this.panelEncuentros.Controls.Add(p2); //Agrega los controles al panelEncuentros
                        p2.Controls.Add(pic3);
                        p2.Controls.Add(l6);
                        p2.Controls.Add(l5);
                        break;
                }
                if (t == "torneo")
                {
                    t = "partido";
                } else { t = "torneo"; }
            }
        }

        private void OpenEncuentros_Click(object sender, EventArgs e)
        {
            Principal.AlterPrincipal(0, 5, 0);
        }

        private void OpenEventos_Click(object sender, EventArgs e)
        {
            Principal.AlterPrincipal(0, 7, 0);
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            if (mtcVisible == false)
            {
                mtcVisible = true;
                mtcFechasEventos.Show();
            } else
            {
                mtcVisible = false;
                mtcFechasEventos.Hide();
            }
        }

        private void mtcFechasEventos_DateChanged(object sender, DateRangeEventArgs e)
        {
            btnCalendario.Text = mtcFechasEventos.SelectionRange.End.ToString("dd-MM-yyyy");
        }

        public static void AlterBuscador(int y)
        {
            switch (y)
            {
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                        form.CargarEncuentros(10);
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
    }
}
