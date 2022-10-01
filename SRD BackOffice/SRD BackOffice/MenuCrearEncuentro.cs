namespace SRD_BackOffice
{
    public partial class MenuCrearEncuentro : Form
    {
        bool modify = false;
        string name;
        int id;
        List<int> equipos = new List<int>();
        Bitmap alineacion;
        public MenuCrearEncuentro()
        {
            InitializeComponent();
            panelBuscador.Hide();
            panelAgregarArbitro.Hide();

            txtFechaEncuentro.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, txtFechaEncuentro); };
            txtFechaEncuentro.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, txtFechaEncuentro); };
            txtHoraEncuentro.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, txtHoraEncuentro); };
            txtHoraEncuentro.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, txtHoraEncuentro); };
            btnEncuentroCerrar.Click += (sender, EventArgs) => { btnEventCerrar_Click(sender, EventArgs); };
            btnAlineacion.Click += (sender, EventArgs) => { btnSelectImage_Click(sender, EventArgs); };
            button1.Click += (sender, EventArgs) => { Add(sender, EventArgs, 0); };
            btnArbitro.Click += (sender, EventArgs) => { Add(sender, EventArgs, 1); };

            var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
            deportes.Sort((x, y) => string.Compare(x.nombreDeporte, y.nombreDeporte));
            foreach (var d in deportes)
            {
                cbxDeporteEncuentro.Items.Add(d.nombreDeporte);
            }
            
            cbxClimaEncuentro.SelectedIndex = 0;
            cbxEstadoEncuentro.SelectedIndex = 0;
        }

        public MenuCrearEncuentro(int index)
        {
            InitializeComponent();
            modify = true;
            panelBuscador.Hide();
            panelAgregarArbitro.Hide();

            txtFechaEncuentro.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, txtFechaEncuentro); };
            txtFechaEncuentro.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, txtFechaEncuentro); };
            txtHoraEncuentro.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, txtHoraEncuentro); };
            txtHoraEncuentro.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, txtHoraEncuentro); };
            btnEncuentroCerrar.Click += (sender, EventArgs) => { btnEventCerrar_Click(sender, EventArgs); };
            btnAlineacion.Click += (sender, EventArgs) => { btnSelectImage_Click(sender, EventArgs); };
            button1.Click += (sender, EventArgs) => { Add(sender, EventArgs, 0); };
            btnArbitro.Click += (sender, EventArgs) => { Add(sender, EventArgs, 1); };

            var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
            deportes.Sort((x, y) => string.Compare(x.nombreDeporte, y.nombreDeporte));
            foreach (var d in deportes)
            {
                cbxDeporteEncuentro.Items.Add(d.nombreDeporte);
            }

            cbxClimaEncuentro.SelectedIndex = 0;
            cbxEstadoEncuentro.SelectedIndex = 0;
        }

        private void txtFecha_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "DD/MM/YYYY")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtFecha_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "DD/MM/YYYY";
                t.ForeColor = Color.DimGray;
            }
        }

        private void txtHora_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "XX:XX")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtHora_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "XX:XX";
                t.ForeColor = Color.DimGray;
            }
        }

        //Cambiar cerrar cuando se modifica
        private void btnEventCerrar_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                this.Hide();
                MainMenu main = new MainMenu();
                main.StartPosition = FormStartPosition.CenterParent;
                main.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                MenuManageEncuentros manageEncuentros = new MenuManageEncuentros();
                manageEncuentros.StartPosition = FormStartPosition.CenterParent;
                manageEncuentros.ShowDialog();
                this.Close();
            }
        }

        private void Add(object sender, EventArgs e, int i)
        {
            panelBuscador.Controls.Clear();
            panelBuscador.Show();

            TextBox buscador = new TextBox();

            buscador.Size = new Size(250, 26);
            buscador.Location = new Point(39, 20);
            buscador.BorderStyle = BorderStyle.FixedSingle;

            Button btnBuscar = new Button();

            btnBuscar.Size = new Size(23, 23);
            btnBuscar.Location = new Point(289, 20);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = Properties.Resources.lupa;

            Panel panelPrincipal = new Panel();

            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Location = new Point(0, 75);
            panelPrincipal.Size = new Size(352, 237);

            Panel panelLabels = new Panel();

            panelLabels.BorderStyle = BorderStyle.FixedSingle;
            panelLabels.Location = new Point(0, 0);
            panelLabels.Size = new Size(352, 25);

            Label lblId = new Label();

            lblId.Text = "ID";
            lblId.Size = new Size(40, 25);
            lblId.Location = new Point(0, 0);
            lblId.BorderStyle = BorderStyle.FixedSingle;
            lblId.TextAlign = ContentAlignment.MiddleCenter;

            Label lblDeportista = new Label();

            lblDeportista.Text = "Athlete";
            lblDeportista.Size = new Size(200, 25);
            lblDeportista.Location = new Point(40, 0);
            lblDeportista.BorderStyle = BorderStyle.FixedSingle;
            lblDeportista.TextAlign = ContentAlignment.MiddleCenter;

            Label lblOrigen = new Label();

            lblOrigen.Text = "Nacionality";
            lblOrigen.Size = new Size(112, 25);
            lblOrigen.Location = new Point(240, 0);
            lblOrigen.BorderStyle = BorderStyle.FixedSingle;
            lblOrigen.TextAlign = ContentAlignment.MiddleCenter;

            Panel panelContenedor = new Panel();

            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Location = new Point(0, 25);
            panelContenedor.Size = new Size(352, 222);
            panelContenedor.AutoScroll = true;

            Button btn1 = new Button();

            btn1.Size = new Size(60, 20);
            btn1.Location = new Point(144, 50);
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btn1.Text = "Add";
            btn1.Click += (sender, EventArgs) => { AddMember(sender, EventArgs, i); };

            btnBuscar.Click += (sender, EventArgs) => { Buscar(sender, EventArgs, buscador.Text, panelContenedor, i); };

            panelBuscador.Controls.Add(panelPrincipal);
            panelBuscador.Controls.Add(buscador);
            panelBuscador.Controls.Add(btnBuscar);
            panelBuscador.Controls.Add(btn1);
            panelPrincipal.Controls.Add(panelLabels);
            panelPrincipal.Controls.Add(panelContenedor);
            panelLabels.Controls.Add(lblDeportista);
            panelLabels.Controls.Add(lblOrigen);
            panelLabels.Controls.Add(lblId);

            if (i == 0)
            {
                var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
                int count = 0;

                foreach (var eq in equipos)
                {
                    Panel p1 = new Panel();

                    p1.Location = new Point(0, 25 * count);
                    p1.Size = new Size(334, 25);

                    Label lbl1 = new Label();

                    lbl1.Text = "" + eq.IdEquipo;
                    lbl1.Size = new Size(40, 25);
                    lbl1.Location = new Point(0, 0);
                    lbl1.BorderStyle = BorderStyle.FixedSingle;
                    lbl1.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl2 = new Label();

                    lbl2.Text = eq.NombreEquipo;
                    lbl2.Size = new Size(200, 25);
                    lbl2.Location = new Point(40, 0);
                    lbl2.BorderStyle = BorderStyle.FixedSingle;
                    lbl2.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl3 = new Label();

                    lbl3.Text = "" + eq.PaisOrigen;
                    lbl3.Size = new Size(82, 25);
                    lbl3.Location = new Point(240, 0);
                    lbl3.BorderStyle = BorderStyle.FixedSingle;
                    lbl3.AutoSize = false;
                    lbl3.TextAlign = ContentAlignment.MiddleCenter;

                    Button btn2 = new Button();

                    btn2.BackColor = Color.Red;
                    btn2.Size = new Size(12, 12);
                    btn2.Location = new Point(322, 7);
                    btn2.FlatStyle = FlatStyle.Flat;
                    btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, panelContenedor, eq.IdEquipo, eq.NombreEquipo); };

                    panelContenedor.Controls.Add(p1);
                    p1.Controls.Add(btn2);
                    p1.Controls.Add(lbl3);
                    p1.Controls.Add(lbl2);
                    p1.Controls.Add(lbl1);

                    count++;
                }
            } else if (i == 1)
            {
                Button btnAgregarArbitro = new Button();

                btnAgregarArbitro.Size = new Size(100, 20);
                btnAgregarArbitro.Location = new Point(240, 50);
                btnAgregarArbitro.FlatStyle = FlatStyle.Flat;
                btnAgregarArbitro.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
                btnAgregarArbitro.Text = "Add new referee";
                btnAgregarArbitro.Click += (sender, EventArgs) => { AgregarArbitro(sender, EventArgs); };

                panelBuscador.Controls.Add(btnAgregarArbitro);
                lblDeportista.Text = "Name";

                var arbitros = Logica.DeserializeArbitros(Logica.GetJson("DinamicJson\\Arbitros.json"));
                int count = 0;

                foreach (var a in arbitros)
                {
                    Panel p1 = new Panel();

                    p1.Location = new Point(0, 25 * count);
                    p1.Size = new Size(334, 25);

                    Label lbl1 = new Label();

                    lbl1.Text = "" + a.IdPersona;
                    lbl1.Size = new Size(40, 25);
                    lbl1.Location = new Point(0, 0);
                    lbl1.BorderStyle = BorderStyle.FixedSingle;
                    lbl1.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl2 = new Label();

                    lbl2.Text = a.Nombre + " " + a.Apellido;
                    lbl2.Size = new Size(200, 25);
                    lbl2.Location = new Point(40, 0);
                    lbl2.BorderStyle = BorderStyle.FixedSingle;
                    lbl2.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl3 = new Label();

                    lbl3.Text = "" + a.Nacionalidad;
                    lbl3.Size = new Size(82, 25);
                    lbl3.Location = new Point(240, 0);
                    lbl3.BorderStyle = BorderStyle.FixedSingle;
                    lbl3.AutoSize = false;
                    lbl3.TextAlign = ContentAlignment.MiddleCenter;

                    Button btn2 = new Button();

                    btn2.BackColor = Color.Red;
                    btn2.Size = new Size(12, 12);
                    btn2.Location = new Point(322, 7);
                    btn2.FlatStyle = FlatStyle.Flat;
                    btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, panelContenedor, a.IdPersona, a.Nombre + " " + a.Apellido); };

                    panelContenedor.Controls.Add(p1);
                    p1.Controls.Add(btn2);
                    p1.Controls.Add(lbl3);
                    p1.Controls.Add(lbl2);
                    p1.Controls.Add(lbl1);

                    count++;
                }
            }
        }

        private void BtnChange(object sender, EventArgs e, Button b, Panel p, int id, string name)
        {
            List<Panel> panels = new List<Panel>();
            List<Button> buttons = new List<Button>();
            foreach (var pan in p.Controls)
            {
                if (pan is Panel)
                {
                    Panel pa = pan as Panel;
                    panels.Add(pa);
                }
            }
            foreach (var pan in panels)
            {
                foreach (var bu in pan.Controls)
                {
                    if (bu is Button)
                    {
                        Button but = bu as Button;
                        buttons.Add(but);
                    }
                }
            }
            foreach (Button bu in buttons)
            {
                bu.BackColor = Color.Red;
            }
            b.BackColor = Color.Green;
            this.name = name;
            this.id = id;
        }

        private void Buscar(object sender, EventArgs e, string busqueda, Panel p, int i)
        {
            p.Controls.Clear();

            if (i == 0)
            {
                var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
                int count = 0;

                foreach (var eq in equipos)
                {
                    if (busqueda == Convert.ToString(eq.IdEquipo) || eq.NombreEquipo.Contains(busqueda) || eq.PaisOrigen.Contains(busqueda))
                    {

                        Panel p1 = new Panel();

                        p1.Location = new Point(0, 25 * count);
                        p1.Size = new Size(334, 25);

                        Label lbl1 = new Label();

                        lbl1.Text = "" + eq.IdEquipo;
                        lbl1.Size = new Size(40, 25);
                        lbl1.Location = new Point(0, 0);
                        lbl1.BorderStyle = BorderStyle.FixedSingle;
                        lbl1.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl2 = new Label();

                        lbl2.Text = eq.NombreEquipo;
                        lbl2.Size = new Size(200, 25);
                        lbl2.Location = new Point(40, 0);
                        lbl2.BorderStyle = BorderStyle.FixedSingle;
                        lbl2.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl3 = new Label();

                        lbl3.Text = "" + eq.PaisOrigen;
                        lbl3.Size = new Size(82, 25);
                        lbl3.Location = new Point(240, 0);
                        lbl3.BorderStyle = BorderStyle.FixedSingle;
                        lbl3.AutoSize = false;
                        lbl3.TextAlign = ContentAlignment.MiddleCenter;

                        Button btn2 = new Button();

                        btn2.BackColor = Color.Red;
                        btn2.Size = new Size(12, 12);
                        btn2.Location = new Point(322, 7);
                        btn2.FlatStyle = FlatStyle.Flat;
                        btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, p, eq.IdEquipo, eq.NombreEquipo); };

                        p.Controls.Add(p1);
                        p1.Controls.Add(btn2);
                        p1.Controls.Add(lbl3);
                        p1.Controls.Add(lbl2);
                        p1.Controls.Add(lbl1);

                        count++;
                    }
                }
            } else if (i == 1)
            {
                var arbitros = Logica.DeserializeArbitros(Logica.GetJson("DinamicJson\\Arbitros.json"));
                int count = 0;

                foreach (var a in arbitros)
                {
                    if (busqueda == Convert.ToString(a.IdPersona) || (a.Nombre + " " + a.Apellido).Contains(busqueda) || a.Nacionalidad.Contains(busqueda))
                    {
                        Panel p1 = new Panel();

                        p1.Location = new Point(0, 25 * count);
                        p1.Size = new Size(334, 25);

                        Label lbl1 = new Label();

                        lbl1.Text = "" + a.IdPersona;
                        lbl1.Size = new Size(40, 25);
                        lbl1.Location = new Point(0, 0);
                        lbl1.BorderStyle = BorderStyle.FixedSingle;
                        lbl1.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl2 = new Label();

                        lbl2.Text = a.Nombre + " " + a.Apellido;
                        lbl2.Size = new Size(200, 25);
                        lbl2.Location = new Point(40, 0);
                        lbl2.BorderStyle = BorderStyle.FixedSingle;
                        lbl2.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl3 = new Label();

                        lbl3.Text = "" + a.Nacionalidad;
                        lbl3.Size = new Size(82, 25);
                        lbl3.Location = new Point(240, 0);
                        lbl3.BorderStyle = BorderStyle.FixedSingle;
                        lbl3.TextAlign = ContentAlignment.MiddleCenter;

                        Button btn1 = new Button();

                        btn1.Size = new Size(12, 12);
                        btn1.Location = new Point(322, 7);
                        btn1.FlatStyle = FlatStyle.Flat;
                        btn1.BackgroundImageLayout = ImageLayout.Stretch;
                        btn1.BackColor = Color.Red;
                        btn1.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn1, p, a.IdPersona, a.Nombre + " " + a.Apellido); };

                        p.Controls.Add(p1);
                        p1.Controls.Add(btn1);
                        p1.Controls.Add(lbl3);
                        p1.Controls.Add(lbl2);
                        p1.Controls.Add(lbl1);

                        count++;
                    }
                }
            }
        }

        private void AddMember(object sender, EventArgs e, int i)
        {
            if (i == 0)
            {
                equipos.Add(id);

                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(416, 25);
                p1.TabIndex = 0;

                Label l1 = new Label(); //ID del deportista

                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = "" + id;
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.Size = new Size(80, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);

                Label l2 = new Label(); //Nombre del deportista

                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.Text = name;
                l2.TextAlign = ContentAlignment.MiddleLeft;
                l2.Size = new Size(324, 25);
                l2.AutoSize = false;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(80, 0);

                PictureBox pic1 = new PictureBox(); //Boton eliminar

                pic1.BorderStyle = BorderStyle.FixedSingle;
                pic1.Size = new Size(12, 12);
                pic1.Location = new Point(404, 7);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Properties.Resources.cruz;
                pic1.Click += (sender, EventArgs) => { KickMember(sender, EventArgs, equipos.IndexOf(id), p1); };

                panelEquipos.Controls.Add(p1);
                p1.Controls.Add(pic1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);

                panelBuscador.Hide();
            } else if (i == 1)
            {
                txtArbitro.Text = name;

                panelBuscador.Hide();
            }
        }

        private void KickMember(object sender, EventArgs e, int eq, Panel p)
        {
            equipos.RemoveAt(eq);
            p.Dispose();
        }

        private void AgregarArbitro(object sender, EventArgs e)
        {
            panelAgregarArbitro.Show();
        }

        private void btnNewArbitro_Click(object sender, EventArgs e)
        {
            bool exist = false;
            String msg = "";
            try
            {
                if (txtNewArbitroName.Text != "" && txtNewArbitroNacionalidad.Text != "" && txtNewArbitroRol.Text != "")
                {
                    var arbitros = Logica.DeserializeArbitros(Logica.GetJson("DinamicJson\\Arbitros.json"));
                    foreach (var a in arbitros)
                    {
                        if (a.Nombre == txtNewArbitroName.Text && a.Apellido == txtNewArbitroApellido.Text
                        && a.Nacionalidad == txtNewArbitroNacionalidad.Text && a.Rol == txtNewArbitroRol.Text)
                        {
                            exist = true;
                            if (Program.language == "EN")
                            {
                                msg = "The user already exist";
                            }
                            else if (Program.language == "ES")
                            {
                                msg = "El usuario ya existe";
                            }
                        }
                    }
                    if (exist == false)
                    {
                        Arbitro newArbitro = new Arbitro();

                        Random r = new Random();

                        newArbitro.IdPersona = r.Next(0, 9999);
                        newArbitro.Nombre = txtNewArbitroName.Text;
                        newArbitro.Apellido = txtNewArbitroApellido.Text;
                        newArbitro.Nacionalidad = txtNewArbitroNacionalidad.Text;
                        newArbitro.Rol = txtNewArbitroRol.Text;
                        arbitros.Add(newArbitro);
                        Logica.SerializeArbitros(arbitros);
                        MessageBox.Show("New referee created correctly");
                    }
                    else
                    {
                        MessageBox.Show(msg);
                    }
                }
                else
                {
                    if (Program.language == "EN")
                    {
                        MessageBox.Show("There are filds incomplete");
                    }
                    else if (Program.language == "ES")
                    {
                        MessageBox.Show("Quedan espacios vacios por rellenar");
                    }
                }
            }
            catch
            {
                MessageBox.Show("There was an error in the process");
            }
            panelAgregarArbitro.Hide();
        }

        private void btnCerrarAddArbitro_Click(object sender, EventArgs e)
        {
            panelAgregarArbitro.Hide();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    alineacion = new Bitmap(open.FileName);
                    int wid = alineacion.Width;
                    int hei = alineacion.Height;
                    if (wid == 150 || hei == 500)
                    {

                    }
                    else
                    {
                        alineacion = null;
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The banner has to have the sizes 150x500 pixels");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("El banner debe tener las medidas 150x500 pixeles");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
