namespace Sistema_de_Resultados_Deportivos
{
    public partial class BuscadorDeEncuentros : Form
    {
        private static BuscadorDeEncuentros form = null;
        bool mtcVisible;
        int id;
        public BuscadorDeEncuentros(int x)
        {
            InitializeComponent();
            form = this;
            SetTheme();
            SetIdioma();
            mtcFechasEventos.Hide();
            btnCalendario.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtBuscador.AutoSize = false;

            CargarEncuentros(x);
        }

        public BuscadorDeEncuentros(int x, int y)
        {
            InitializeComponent();
            id = y;
            form = this;
            SetTheme();
            SetIdioma();
            mtcFechasEventos.Hide();
            btnCalendario.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtBuscador.AutoSize = false;

            CargarEncuentros(x);
        }

        private void CargarEncuentros(int x) //Carga los botones de panelEncuentros uno por uno
        {
            panelEncuentros.Controls.Clear();
            var encuentros = new List<Encuentro>();
            var eventos = new List<Evento>();
            string[] fechaArray = btnCalendario.Text.Split("-");
            string fecha = fechaArray[2] + "-" + fechaArray[1] + "-" + fechaArray[0];
            switch (x)
            {
                case 0:
                    encuentros = Logica.GetEncuentros(5, fecha);
                    eventos = Logica.GetEventos(5, fecha);
                    break;
                case 1:
                    encuentros = Logica.GetEncuentros(2, txtBuscador.Text);
                    eventos = Logica.GetEventos(2, txtBuscador.Text);
                    break;
                case 2:
                    encuentros = Logica.GetEncuentros(1, fecha, "In progress");
                    eventos = Logica.GetEventos(1, fecha, "In progress");
                    break;
                case 3:
                    encuentros = Logica.GetEncuentros(1, fecha, "Finished");
                    eventos = Logica.GetEventos(1, fecha, "Finished");
                    break;
                case 4:
                    encuentros = Logica.GetEncuentros(1, fecha, "Coming soon");
                    eventos = Logica.GetEventos(1, fecha, "Coming soon");
                    break;
                case 5:
                    encuentros = Logica.GetEncuentros(6, ""+id);
                    eventos = Logica.GetEventos(6, "" + id);
                    break;
                case 6:
                    List<int> ls1 = Program.user.encuentrosFavoritos.Select(o => o.idEncuentro).ToList();
                    List<int> ls2 = Program.user.equiposFavoritos.Select(o => o.idEquipo).ToList();
                    List<int> eqEnc = new List<int>();
                    foreach (var eq in ls2)
                    {
                        eqEnc.Add(Logica.GetEquiposEncuentros(3, eq+"")[0].IdEncuentro);
                    }
                    List<int> lsf = ls1.Union(eqEnc).ToList();
                    foreach (var enc in lsf)
                    {
                        encuentros.Add(Logica.GetEncuentros(4, "" + enc)[0]);
                    }
                    int i = 0;
                    List<int> ls3 = Program.user.eventosFavoritos.Select(o => o.idEvento).ToList();
                    List<int> lsff = new List<int>();
                    while (i < ls3.Count)
                    {
                        if (!lsff.Contains(ls3[i]))
                            lsff.Add(ls3[i]);
                        i++;
                    }
                    foreach (var eve in lsff)
                    {
                        eventos.Add(Logica.GetEventos(4, "" + eve)[0]);
                    }
                    break;
                case 7:
                    encuentros = Logica.GetEncuentros(7, null);
                    eventos = Logica.GetEventos(7, null);
                    break;
            }

            if (encuentros.Count() > 0 || eventos.Count() > 0)
            {
                foreach (var enc in encuentros)
                {
                    var eqEnc = Logica.GetEquiposEncuentros(2, "" + enc.IdEncuentro);
                    var eq = new List<Equipo>();
                    foreach (var eqE in eqEnc)
                    {
                        eq.Add(Logica.GetEquipos(3, "" + eqE.IdEquipo)[0]);
                    }
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Size = new Size(722, 60);
                    p1.TabIndex = 0;

                    Label l1 = new Label(); //Nombre de Equipo 1

                    l1.BackColor = Color.Transparent;
                    l1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.TextAlign = ContentAlignment.MiddleCenter;
                    l1.MaximumSize = new Size(270, 30);
                    l1.AutoSize = true;
                    l1.Location = new Point(60, 16);
                    l1.TabIndex = 3;
                    l1.ForeColor = AjustesDeUsuario.foreColor;

                    Label l3 = new Label(); //Hora del encuentro

                    l3.BackColor = Color.Transparent;
                    l3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                    l3.Text = enc.Hora.Substring(0, enc.Hora.Length - 3);
                    l3.TextAlign = ContentAlignment.MiddleCenter;
                    l3.Size = new Size(l3.Text.Length * 12, 20);
                    l3.Location = new Point(p1.Width / 2 - l3.Width / 2, p1.Height - 25);
                    l3.TabIndex = 5;
                    l3.ForeColor = AjustesDeUsuario.foreColor;

                    if (eqEnc.Count() == 2)
                    {
                        PictureBox pic1 = new PictureBox(); //Imagen de Equipo 1

                        pic1.InitialImage = null;
                        pic1.BackColor = Color.Transparent;
                        pic1.Size = new Size(40, 40);
                        pic1.Location = new Point(10, 10);
                        pic1.TabIndex = 1;
                        pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap imagenCargada1 = null;
                        try
                        {
                            imagenCargada1 = new Bitmap(eq[0].ImagenRepresentativa);
                        }
                        catch { }
                        pic1.BackgroundImage = imagenCargada1;

                        PictureBox pic2 = new PictureBox(); //Imagen de Equipo 2

                        pic2.InitialImage = null;
                        pic2.BackColor = Color.Transparent;
                        pic2.Size = new Size(40, 40);
                        pic2.Location = new Point(662, 10);
                        pic2.TabIndex = 2;
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap imagenCargada2 = null;
                        try
                        {
                            imagenCargada2 = new Bitmap(eq[1].ImagenRepresentativa);
                        }
                        catch { }
                        pic2.Image = imagenCargada2;

                        Label l2 = new Label(); //Nombre de Equipo 2

                        l2.BackColor = Color.Transparent;
                        l2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
                        l2.Text = eqEnc[1].NombreEquipo;
                        l2.RightToLeft = RightToLeft.Yes;
                        l2.TextAlign = ContentAlignment.MiddleLeft;
                        l2.Size = new Size(270, 30);
                        l2.AutoSize = false;
                        l2.Location = new Point(392, 16);
                        l2.TabIndex = 4;
                        l2.ForeColor = AjustesDeUsuario.foreColor;

                        l1.Text = eqEnc[0].NombreEquipo;

                        l2.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs, enc.IdEncuentro); };
                        pic1.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs, enc.IdEncuentro); };
                        pic2.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs, enc.IdEncuentro); };
                        p1.Controls.Add(pic1);
                        p1.Controls.Add(pic2);
                        p1.Controls.Add(l2);
                    }
                    else
                    {
                        l3.Location = new Point(722 - (10 + l3.Width), p1.Height - 25);
                        l1.Text = enc.Nombre;
                    }

                    Label l4 = new Label(); //Marcador del encuentro

                    l4.BackColor = Color.Transparent;
                    l4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
                    l4.TextAlign = ContentAlignment.MiddleCenter;
                    l4.TabIndex = 5;
                    l4.ForeColor = AjustesDeUsuario.foreColor;
                    if ((enc.TipoEncuentro == 1 || enc.TipoEncuentro == 2) && eqEnc.Count() == 2)
                    {
                        l4.Text = eqEnc[0].Puntuacion + " - " + eqEnc[1].Puntuacion;
                    }
                    else
                    {
                        l4.Text = "";
                    }
                    l4.Size = new Size(l4.Text.Length * 14, 30);
                    l4.Location = new Point(p1.Width / 2 - l4.Width / 2, 8);

                    p1.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs, enc.IdEncuentro); };
                    l1.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs, enc.IdEncuentro); };
                    l3.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs, enc.IdEncuentro); };
                    l4.Click += (sender, EventArgs) => { OpenEncuentros_Click(sender, EventArgs, enc.IdEncuentro); };

                    panelEncuentros.Controls.Add(p1); //Agrega los controles al panelEncuentros
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l3);
                    p1.Controls.Add(l4);
                }
                foreach (var eve in eventos)
                {
                    int id = eve.IdEvento;
                    Panel p2 = new Panel(); //Crea el panel donde apareceran los controles

                    p2.Dock = DockStyle.Top;
                    p2.BorderStyle = BorderStyle.FixedSingle;
                    p2.Size = new Size(563, 60);


                    PictureBox pic3 = new PictureBox(); //Imagen del evento

                    pic3.InitialImage = null;
                    pic3.BackColor = Color.Transparent;
                    pic3.Size = new Size(40, 40);
                    pic3.Location = new Point(10, 10);
                    pic3.TabIndex = 1;
                    pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap imagenCargada1 = null;
                    try
                    {
                        imagenCargada1 = new Bitmap(eve.LogoEvento);
                    }
                    catch { }
                    pic3.Image = imagenCargada1;


                    Label l6 = new Label(); //Nombre del evento

                    l6.BackColor = Color.Transparent;
                    l6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
                    l6.Text = eve.NombreEvento;
                    l6.TextAlign = ContentAlignment.MiddleCenter;
                    l6.MaximumSize = new Size(300, 30);
                    l6.AutoSize = true;
                    l6.Location = new Point(60, 16);
                    l6.TabIndex = 3;
                    l6.ForeColor = AjustesDeUsuario.foreColor;

                    Label l5 = new Label(); //Hora del evento

                    l5.BackColor = Color.Transparent;
                    l5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
                    l5.Text = eve.HoraEvento.Substring(0, eve.HoraEvento.Length - 3);
                    l5.TextAlign = ContentAlignment.MiddleCenter;
                    l5.MaximumSize = new Size(100, 30);
                    l5.AutoSize = true;
                    l5.Location = new Point(722 - (10 + l5.Width), 14);
                    l5.TabIndex = 5;
                    l5.ForeColor = AjustesDeUsuario.foreColor;

                    l6.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs, id); };
                    l5.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs, id); };
                    p2.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs, id); };
                    pic3.Click += (sender, EventArgs) => { OpenEventos_Click(sender, EventArgs, id); };

                    panelEncuentros.Controls.Add(p2); //Agrega los controles al panelEncuentros
                    p2.Controls.Add(pic3);
                    p2.Controls.Add(l6);
                    p2.Controls.Add(l5);
                }
            } else
            {
                Label l6 = new Label(); //Data not found

                l6.BackColor = Color.Transparent;
                l6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
                switch (x)
                {
                    case 0:
                    case 2:
                    case 3:
                    case 4:
                        switch (AjustesDeUsuario.language)
                        {
                            case "EN":
                                l6.Text = "Data not found for this day";
                                break;
                            case "ES":
                                l6.Text = "No se encontro información para este día";
                                break;
                        }
                        break;
                    case 1:
                    case 5:
                    case 6:
                        switch (AjustesDeUsuario.language)
                        {
                            case "EN":
                                l6.Text = "Data not found for these parameters";
                                break;
                            case "ES":
                                l6.Text = "No se encontro información para estos parametros";
                                break;
                        }
                        break;
                }
                l6.Size = new Size(panelEncuentros.Size.Width, 50);
                l6.TextAlign = ContentAlignment.MiddleCenter;
                l6.Anchor = AnchorStyles.Right;
                l6.Anchor = AnchorStyles.Left;
                l6.AutoSize = false;
                l6.Location = new Point((panelEncuentros.Size.Width - l6.Size.Width) / 2, (panelEncuentros.Size.Height - l6.Size.Height) / 2);
                l6.TabIndex = 3;
                l6.ForeColor = AjustesDeUsuario.foreColor;

                panelEncuentros.Controls.Add(l6);
            }
        }

        private void OpenEncuentros_Click(object sender, EventArgs e, int id)
        {
            Principal.AlterPrincipal(id, 5, 0);
        }

        private void OpenEventos_Click(object sender, EventArgs e, int id)
        {
            Principal.AlterPrincipal(id, 7, 0);
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
            CargarEncuentros(0);
        }

        public static void AlterBuscador(int y)
        {
            switch (y)
            {
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                        form.CargarEncuentros(0);
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
                    btnProximamente.Text = "Coming soon";
                    btnTerminados.Text = "Finished";
                    btnEnVivo.Text = "Live";
                    btnTodos.Text = "All";
                    break;
                case "ES": //Español
                    btnProximamente.Text = "Proximamente";
                    btnTerminados.Text = "Terminados";
                    btnEnVivo.Text = "En vivo";
                    btnTodos.Text = "Todos";
                    break;
            }
        }

        public void SetTheme() //Establece los colores de los controles según el tema elegido
        {
            /* Paneles */
            BackColor = AjustesDeUsuario.panel;
            panelBuscador.BackColor = AjustesDeUsuario.panel;
            panelDiferenciador.BackColor = AjustesDeUsuario.panel;
            panelEncuentros.BackColor = AjustesDeUsuario.panel;
            panelTabla.BackColor = AjustesDeUsuario.panel;
            /* Botones */
            btnBuscar.BackColor = AjustesDeUsuario.btnBack;
            btnBuscar.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnBuscar.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnCalendario.BackColor = AjustesDeUsuario.btnBack;
            btnCalendario.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnCalendario.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnEnVivo.BackColor = AjustesDeUsuario.btnBack;
            btnEnVivo.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnEnVivo.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnProximamente.BackColor = AjustesDeUsuario.btnBack;
            btnProximamente.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnProximamente.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnTerminados.BackColor = AjustesDeUsuario.btnBack;
            btnTerminados.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnTerminados.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnTodos.BackColor = AjustesDeUsuario.btnBack;
            btnTodos.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnTodos.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            /* Textos (Incluidos botones) */
            txtBuscador.BackColor = AjustesDeUsuario.btnBack;
            txtBuscador.ForeColor = AjustesDeUsuario.foreColor;
            btnBuscar.ForeColor = AjustesDeUsuario.foreColor;
            btnCalendario.ForeColor = AjustesDeUsuario.foreColor;
            btnEnVivo.ForeColor = AjustesDeUsuario.foreColor;
            btnProximamente.ForeColor = AjustesDeUsuario.foreColor;
            btnTerminados.ForeColor = AjustesDeUsuario.foreColor;
            btnTodos.ForeColor = AjustesDeUsuario.foreColor;
            /* Imagenes */
            if (AjustesDeUsuario.darkTheme == true)
            {
                btnBuscar.Image = Properties.Resources.lupa_dark;
            } else
            {
                btnBuscar.Image = Properties.Resources.lupa1;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEncuentros(1);
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            CargarEncuentros(0);
        }

        private void btnEnVivo_Click(object sender, EventArgs e)
        {
            CargarEncuentros(2);
        }

        private void btnTerminados_Click(object sender, EventArgs e)
        {
            CargarEncuentros(3);
        }

        private void btnProximamente_Click(object sender, EventArgs e)
        {
            CargarEncuentros(4);
        }
    }
}
