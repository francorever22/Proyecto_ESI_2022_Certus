using System.Drawing.Imaging;

namespace SRD_BackOffice
{
    public partial class MenuCrearEncuentro : Form
    {
        bool modify = false, avoid = false;
        string name;
        int id, actualRound = 1, cantRounds = 1, tipoEncuentro, index;
        List<int> equipos = new List<int>();
        List<EquiposEncuentros> equiposEncuentros = new List<EquiposEncuentros>();
        List<Round> rounds = new List<Round>();
        List<PuntuacionRound> puntuacionRounds = new List<PuntuacionRound>();
        List<Hito> hitos = new List<Hito>();
        Bitmap alineacion = null;
        public MenuCrearEncuentro()
        {
            InitializeComponent();
            SetIdioma();
            panelBuscador.Hide();
            panelAgregarArbitro.Hide();
            panelNuevoHito.Hide();
            panelListaHitos.Hide();

            rounds.Add(new Round());
            rounds[0].NumeroRound = 1;
            cbxActualRound.Items.Add(1);
            cbxActualRound.SelectedIndex = 0;
            cbxTipoEncuentro.SelectedIndex = 0;

            txtFechaEncuentro.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, txtFechaEncuentro); };
            txtFechaEncuentro.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, txtFechaEncuentro); };
            txtHoraEncuentro.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, txtHoraEncuentro); };
            txtHoraEncuentro.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, txtHoraEncuentro, 1); };
            txtTiempoTranscurridoRound.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, txtTiempoTranscurridoRound); };
            txtTiempoTranscurridoRound.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, txtTiempoTranscurridoRound, 2); };
            btnEncuentroCerrar.Click += (sender, EventArgs) => { btnEventCerrar_Click(sender, EventArgs); };
            btnSelectParticipants.Click += (sender, EventArgs) => { Add(sender, EventArgs, 0); };
            btnArbitro.Click += (sender, EventArgs) => { Add(sender, EventArgs, 1); };
            picReset.Click += (sender, EventArgs) => { KickMember(sender, EventArgs); };

            var deportes = Logica.GetDeportes(1, null);
            deportes.Sort((x, y) => string.Compare(x.NombreDeporte, y.NombreDeporte));
            foreach (var d in deportes)
            {
                cbxDeporteEncuentro.Items.Add(d.NombreDeporte);
            }

            cbxClimaEncuentro.SelectedIndex = 0;
            cbxEstadoEncuentro.SelectedIndex = 0;
        }

        public MenuCrearEncuentro(int index)
        {
            InitializeComponent();
            SetIdioma();
            modify = true;
            this.index = index;
            panelBuscador.Hide();
            panelAgregarArbitro.Hide();
            panelNuevoHito.Hide();
            panelListaHitos.Hide();
            switch (Program.language)
            {
                case "EN":
                    btnAddEncuentro.Text = "Modify";
                    break;
                case "ES":
                    btnAddEncuentro.Text = "Modificar";
                    break;
            }

            txtFechaEncuentro.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, txtFechaEncuentro); };
            txtFechaEncuentro.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, txtFechaEncuentro); };
            txtHoraEncuentro.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, txtHoraEncuentro); };
            txtHoraEncuentro.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, txtHoraEncuentro, 1); };
            txtTiempoTranscurridoRound.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, txtTiempoTranscurridoRound); };
            txtTiempoTranscurridoRound.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, txtTiempoTranscurridoRound, 2); };
            btnEncuentroCerrar.Click += (sender, EventArgs) => { btnEventCerrar_Click(sender, EventArgs); };
            btnSelectParticipants.Click += (sender, EventArgs) => { Add(sender, EventArgs, 0); };
            btnArbitro.Click += (sender, EventArgs) => { Add(sender, EventArgs, 1); };
            picReset.Click += (sender, EventArgs) => { KickMember(sender, EventArgs); };

            var deportes = Logica.GetDeportes(1, null);
            deportes.Sort((x, y) => string.Compare(x.NombreDeporte, y.NombreDeporte));
            foreach (var d in deportes)
            {
                cbxDeporteEncuentro.Items.Add(d.NombreDeporte);
            }

            var Hitos = Logica.GetHitos(3, index, 0);
            foreach (var h in Hitos)
            {
                hitos.Add(h);
            }
            var PuntuacionRounds = Logica.GetPuntuacionRounds(3, index, 0);
            foreach (var pR in PuntuacionRounds)
            {
                puntuacionRounds.Add(pR);
            }
            var Rounds = Logica.GetRounds(2, ""+index);
            foreach (var r in Rounds)
            {
                rounds.Add(r);
                cbxActualRound.Items.Add(r.NumeroRound);
            }
            var EquiposEncuentros = Logica.GetEquiposEncuentros(2, ""+index);
            foreach (var eE in EquiposEncuentros)
            {
                equiposEncuentros.Add(eE);
            }
            try
            {
                alineacion = new Bitmap(equiposEncuentros[0].Alineacion);
            } catch { }
            avoid = true;
            var encuentro = Logica.GetEncuentros(4, ""+index)[0];
            var arbitro = Logica.GetArbitros(3, ""+encuentro.IdPersona)[0];

            txtArbitro.Text = $"{arbitro.Nombre} {arbitro.Apellido}";
            txtCantRounds.Text = $"{rounds.Count()}";
            txtLugarEncuentro.Text = encuentro.Lugar;
            txtNombreEncuentro.Text = encuentro.Nombre;
            cbxClimaEncuentro.SelectedItem = encuentro.Clima;
            cbxDeporteEncuentro.SelectedItem = Logica.GetDeportes(5, ""+encuentro.IdDeporte)[0].NombreDeporte;
            cbxEstadoEncuentro.SelectedItem = encuentro.Estado;
            cbxTipoEncuentro.SelectedIndex = encuentro.TipoEncuentro - 1;
            string tiempoTrancurridoRound = rounds.FirstOrDefault(r => r.NumeroRound == 1).TiempoTranscurridoRound;
            if (tiempoTrancurridoRound == null || tiempoTrancurridoRound == "")
            {
                txtTiempoTranscurridoRound.Text = "XX:XX:XX";
                txtTiempoTranscurridoRound.ForeColor = Color.DimGray;
            } else
            {
                txtTiempoTranscurridoRound.Text = tiempoTrancurridoRound;
                txtTiempoTranscurridoRound.ForeColor = Color.Black;
            }
            cbxActualRound.SelectedItem = actualRound;
            if (encuentro.Fecha == null || encuentro.Fecha == "")
            {
                txtFechaEncuentro.Text = "DD/MM/YYYY";
                txtFechaEncuentro.ForeColor = Color.DimGray;
            } else
            {
                txtFechaEncuentro.Text = encuentro.Fecha.Substring(0, encuentro.Fecha.Length - 8);
                txtFechaEncuentro.ForeColor = Color.Black;
            }
            if (encuentro.Hora == null || encuentro.Hora == "")
            {
                txtHoraEncuentro.Text = "XX:XX";
                txtHoraEncuentro.ForeColor = Color.DimGray;
            } else
            {
                txtHoraEncuentro.Text = encuentro.Hora.Substring(0, encuentro.Hora.Length - 3);
                txtHoraEncuentro.ForeColor = Color.Black;
            }
            CargarEquipos();
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
            if (t.Text == "XX:XX" || t.Text == "XX:XX:XX")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtHora_Leave(object sender, EventArgs e, TextBox t, int x)
        {
            if (t.Text == "")
            {
                if (x == 1) { t.Text = "XX:XX"; } else if (x == 2) { t.Text = "XX:XX:XX"; }
                t.ForeColor = Color.DimGray;
            }
            if (x == 2 && t.Text != "XX:XX:XX")
            {
                rounds[actualRound - 1].TiempoTranscurridoRound = t.Text;
            }
        }

        private void btnEventCerrar_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                Hide();
                MainMenu main = new MainMenu();
                main.StartPosition = FormStartPosition.CenterParent;
                main.ShowDialog();
                Close();
            }
            else
            {
                Hide();
                MenuManageEncuentros manageEncuentros = new MenuManageEncuentros();
                manageEncuentros.StartPosition = FormStartPosition.CenterParent;
                manageEncuentros.ShowDialog();
                Close();
            }
        }

        private void Add(object sender, EventArgs e, int i)
        {
            panelBuscador.Controls.Clear();
            panelBuscador.Show();

            Button btnCerrar = new Button();

            btnCerrar.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderColor = Color.DimGray;
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            btnCerrar.Location = new Point(325, 4);
            btnCerrar.Size = new Size(21, 21);
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += new EventHandler(btnCerrarBuscador_Click);

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
            panelBuscador.Controls.Add(btnCerrar);
            panelPrincipal.Controls.Add(panelLabels);
            panelPrincipal.Controls.Add(panelContenedor);
            panelLabels.Controls.Add(lblDeportista);
            panelLabels.Controls.Add(lblOrigen);
            panelLabels.Controls.Add(lblId);

            if (i == 0)
            {
                var equipos = Logica.GetEquipos(1, null);
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
            }
            else if (i == 1)
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

                var arbitros = Logica.GetArbitros(1, null);
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
                var equipos = Logica.GetEquipos(2, busqueda);
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
                    btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, p, eq.IdEquipo, eq.NombreEquipo); };

                    p.Controls.Add(p1);
                    p1.Controls.Add(btn2);
                    p1.Controls.Add(lbl3);
                    p1.Controls.Add(lbl2);
                    p1.Controls.Add(lbl1);

                    count++;
                }
            }
            else if (i == 1)
            {
                var arbitros = Logica.GetArbitros(2, busqueda);
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

        private void AddMember(object sender, EventArgs e, int i)
        {
            if (i == 0)
            {
                equipos.Add(id);
                equiposEncuentros.Add(new EquiposEncuentros() { IdEquipo = id, Posicion = 0, Puntuacion = 0, Alineacion = null });

                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(451, 25);
                p1.TabIndex = 0;

                Label l1 = new Label(); //Nombre del equipo

                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = name;
                l1.TextAlign = ContentAlignment.MiddleLeft;
                l1.Size = new Size(268, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);

                Button btn1 = new Button(); //Seleccionar alineamiento del equipo

                btn1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                btn1.Cursor = Cursors.Hand;
                btn1.FlatAppearance.BorderColor = Color.DimGray;
                btn1.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                btn1.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                btn1.Location = new Point(268, 0);
                btn1.Text = "Select alignment";
                btn1.Size = new Size(150, 25);
                btn1.UseVisualStyleBackColor = true;
                btn1.Click += (sender, EventArgs) => { btnSelectImage_Click(sender, EventArgs); };

                int idEq = id;

                switch (tipoEncuentro)
                {
                    case 1: //Puntos
                        TextBox txt1 = new TextBox();

                        txt1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt1.Location = new Point(418, 0);
                        txt1.Size = new Size(39, 25);
                        txt1.Text = "";
                        txt1.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 1, idEq, txt1.Text); };
                        txt1.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        p1.Controls.Add(txt1);
                        break;
                    case 2: //Sets
                        TextBox txt2 = new TextBox();

                        txt2.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt2.Location = new Point(418, 0);
                        txt2.Size = new Size(39, 25);
                        txt2.Text = "";
                        txt2.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 1, idEq, txt2.Text); };
                        txt2.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        TextBox txt3 = new TextBox();

                        txt3.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt3.Location = new Point(457, 0);
                        txt3.Size = new Size(39, 25);
                        txt3.Text = "";
                        txt3.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 2, idEq, txt3.Text); };
                        txt3.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        p1.Controls.Add(txt2);
                        p1.Controls.Add(txt3);
                        break;
                    case 3: //Position
                        TextBox txt4 = new TextBox();

                        txt4.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt4.Location = new Point(430, 0);
                        txt4.Size = new Size(25, 25);
                        txt4.Text = "";
                        txt4.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 3, idEq, txt4.Text); };
                        txt4.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        p1.Controls.Add(txt4);
                        break;
                    case 4: //Winner
                        CheckBox chk1 = new CheckBox();

                        chk1.Location = new Point(426, 2);
                        chk1.Size = new Size(23, 23);
                        chk1.CheckedChanged += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 4, idEq, chk1.Checked.ToString()); };

                        p1.Controls.Add(chk1);
                        break;
                }

                panelEquiposContenedor.Controls.Add(p1);
                p1.Controls.Add(btn1);
                p1.Controls.Add(l1);

                panelBuscador.Hide();
            }
            else if (i == 1)
            {
                txtArbitro.Text = name;

                panelBuscador.Hide();
            }
        }

        private void EditTeamScore(object sender, EventArgs e, int x, int id, string input)
        {
            if (string.IsNullOrEmpty(input)) { input = "0"; }
            switch (x)
            {
                case 1:
                    equiposEncuentros.Find(e => e.IdEquipo == id).Puntuacion = Convert.ToInt32(input);
                    break;
                case 2:
                    if (puntuacionRounds.Find(e => e.IdEquipos == id && e.NumeroRound == actualRound) == null)
                    {
                        puntuacionRounds.Add(new PuntuacionRound()
                        {
                            IdEquipos = id,
                            NumeroRound = actualRound,
                            Puntos = Convert.ToInt32(input)
                        });
                    }
                    else
                    {
                        puntuacionRounds.Find(e => e.IdEquipos == id && e.NumeroRound == actualRound).Puntos = Convert.ToInt32(input);
                    }
                    break;
                case 3:
                    equiposEncuentros.Find(e => e.IdEquipo == id).Posicion = Convert.ToInt32(input);
                    break;
                case 4:
                    if (input == "True")
                    {
                        equiposEncuentros.Find(e => e.IdEquipo == id).Posicion = 1;
                    }
                    else
                    {
                        equiposEncuentros.Find(e => e.IdEquipo == id).Posicion = 0;
                    }
                    break;
            }
        }

        private void KickMember(object sender, EventArgs e)
        {
            equipos.Clear();
            equiposEncuentros.Clear();
            puntuacionRounds.Clear();
            panelEquiposContenedor.Controls.Clear();
        }

        private void AgregarArbitro(object sender, EventArgs e)
        {
            panelAgregarArbitro.Show();
            panelBuscador.Hide();
        }

        private void btnNewArbitro_Click(object sender, EventArgs e)
        {
            String msg = "";
            try
            {
                if (txtNewArbitroName.Text != "" && txtNewArbitroNacionalidad.Text != "" && txtNewArbitroRol.Text != "")
                {
                    string Nombre = txtNewArbitroName.Text,
                    Apellido = txtNewArbitroApellido.Text,
                    Nacionalidad = txtNewArbitroNacionalidad.Text,
                    Rol = txtNewArbitroRol.Text;

                    Logica.InsertPersona(Nombre, Apellido, Nacionalidad);
                    Logica.InsertArbitro(Nombre, Apellido, Nacionalidad, Rol);

                    if (Program.language == "EN")
                    {
                        MessageBox.Show("New referee created correctly");
                    }
                    else if (Program.language == "ES")
                    {
                        MessageBox.Show("Nuevo arbitro creado correctamente");
                    }
                    panelAgregarArbitro.Hide();
                    panelBuscador.Show();
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
        }

        private void btnCerrarAddArbitro_Click(object sender, EventArgs e)
        {
            panelAgregarArbitro.Hide();
            panelBuscador.Show();
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
                    if (!(wid == 150 || hei == 150))
                    {
                        alineacion = null;
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The banner has to have the sizes 150x150 pixels");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("El banner debe tener las medidas 150x150 pixeles");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnNewHito_Click(object sender, EventArgs e)
        {
            panelNuevoHito.Show();

            cbxNumeroRoundHito.Items.Clear();
            for (int i = 1; i <= cantRounds; i++)
            {
                cbxNumeroRoundHito.Items.Add("" + i);
            }
        }

        private void btnCerrarNewHito_Click(object sender, EventArgs e)
        {
            panelNuevoHito.Hide();

            txtTiempoHito.Text = "";
            txtTituloHito.Text = "";
        }

        private void btnAddHito_Click(object sender, EventArgs e)
        {
            Hito hito = new Hito();

            hito.NumeroRound = Convert.ToInt32(cbxNumeroRoundHito.SelectedItem);
            hito.TituloHito = txtTituloHito.Text;
            hito.TiempoHito = txtTiempoHito.Text;

            hitos.Add(hito);
            MessageBox.Show("Milestone created correctly");
        }

        private void btnHitosList_Click(object sender, EventArgs e)
        {
            panelListaHitosContenedor.Controls.Clear();
            panelListaHitos.Show();

            int y = 0;

            foreach (var h in hitos)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.BorderStyle = BorderStyle.None;
                p1.Location = new Point(0, y);
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(415, 25);
                p1.TabIndex = 0;

                Label l1 = new Label(); //Numero round hito

                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.Size = new Size(40, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);
                l1.Text = "" + h.NumeroRound;

                Label l2 = new Label(); //Tiempo hito

                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.Size = new Size(95, 25);
                l2.AutoSize = false;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(40, 0);
                l2.Text = "" + h.TiempoHito;

                Label l3 = new Label(); //Titulo hito

                l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l3.TextAlign = ContentAlignment.MiddleCenter;
                l3.Size = new Size(250, 25);
                l3.AutoSize = false;
                l3.BackColor = Color.FromArgb(255, 255, 248);
                l3.BorderStyle = BorderStyle.FixedSingle;
                l3.Location = new Point(135, 0);
                l3.Text = "" + h.TituloHito;

                PictureBox pic1 = new PictureBox(); //Boton eliminar

                pic1.BorderStyle = BorderStyle.FixedSingle;
                pic1.Size = new Size(12, 12);
                pic1.Location = new Point(397, 7);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Properties.Resources.cruz;
                pic1.Click += (sender, EventArgs) => { EliminarHito(sender, EventArgs, hitos, h, panelListaHitosContenedor); };


                panelListaHitosContenedor.Controls.Add(p1);
                p1.Controls.Add(pic1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
                p1.Controls.Add(l3);
                y += 25;
            }
        }

        private void EliminarHito(object sender, EventArgs e, List<Hito> list, Hito hito, Panel p)
        {
            DialogResult dialogResult1 = MessageBox.Show("Do you really want to delete this?", "Delete milestone", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you really sure?", "DELETE milestone", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    hitos.RemoveAll(r => r.TituloHito == hito.TituloHito);
                    p.Dispose();
                }
            }
        }

        private void cbxTipoEncuentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTipoEncuentro.SelectedIndex)
            {
                case 0:
                    tipoEncuentro = 1;

                    lblPointsition.Text = "Points";
                    panelEquipos.Size = new Size(469, 175);
                    panelEquiposContenedor.Size = new Size(469, 146);
                    panelEquiposLabels.Size = new Size(469, 29);
                    lblPointsPerRound.Visible = false;
                    break;
                case 1:
                    tipoEncuentro = 2;

                    lblPointsition.Text = "Points";
                    panelEquipos.Size = new Size(508, 175);
                    panelEquiposContenedor.Size = new Size(508, 146);
                    panelEquiposLabels.Size = new Size(508, 29);
                    lblPointsPerRound.Visible = true;
                    break;
                case 2:
                    tipoEncuentro = 3;

                    lblPointsition.Text = "Position";
                    panelEquipos.Size = new Size(469, 175);
                    panelEquiposContenedor.Size = new Size(469, 146);
                    panelEquiposLabels.Size = new Size(469, 29);
                    lblPointsPerRound.Visible = false;
                    break;
                case 3:
                    tipoEncuentro = 4;

                    lblPointsition.Text = "Winner";
                    panelEquipos.Size = new Size(469, 175);
                    panelEquiposContenedor.Size = new Size(469, 146);
                    panelEquiposLabels.Size = new Size(469, 29);
                    lblPointsPerRound.Visible = false;
                    break;
            }
            if (avoid == false)
            {
                KickMember(sender, e);
            } else
            {
                avoid = false;
            }
        }

        private void btnCerrarBuscador_Click(object sender, EventArgs e)
        {
            panelBuscador.Hide();
        }

        private void btnCerrarHitosList_Click(object sender, EventArgs e)
        {
            panelListaHitos.Hide();
        }

        private void cbxActualRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Round round = new Round();
                round.NumeroRound = actualRound;
                round.TiempoTranscurridoRound = txtTiempoTranscurridoRound.Text;

                rounds.RemoveAt(actualRound - 1);
                rounds.Insert(actualRound - 1, round);
                actualRound = Convert.ToInt32(cbxActualRound.Text);

                round = rounds[actualRound - 1];
                if (round.TiempoTranscurridoRound != null)
                {
                    txtTiempoTranscurridoRound.ForeColor = Color.Black;
                    txtTiempoTranscurridoRound.Text = "" + round.TiempoTranscurridoRound;
                }
                else
                {
                    txtTiempoTranscurridoRound.Text = "XX:XX:XX";
                    txtTiempoTranscurridoRound.ForeColor = Color.DimGray;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAddEncuentro_Click(object sender, EventArgs e)
        {
            Round round = new Round();
            round.NumeroRound = actualRound;
            round.TiempoTranscurridoRound = txtTiempoTranscurridoRound.Text;

            rounds.RemoveAt(actualRound - 1);
            rounds.Insert(actualRound - 1, round);
            if (modify == false)
            {
                bool exist = false;

                if (txtArbitro.Text != "" && txtFechaEncuentro.Text != "" && txtHoraEncuentro.Text != "" &&
                    txtLugarEncuentro.Text != "" && txtNombreEncuentro.Text != "" && cbxClimaEncuentro != null &&
                    cbxDeporteEncuentro != null && cbxEstadoEncuentro != null && cbxTipoEncuentro != null)
                {
                    try
                    {
                        string[] fechaArray = txtFechaEncuentro.Text.Split("/");
                        string fecha = fechaArray[2] + "-" + fechaArray[1] + "-" + fechaArray[0],
                               nomDeporte = cbxDeporteEncuentro.Text,
                               nomArbitro = txtArbitro.Text,
                               hora = txtHoraEncuentro.Text + ":00",
                               lugar = txtLugarEncuentro.Text,
                               nombre = txtNombreEncuentro.Text,
                               estado = cbxEstadoEncuentro.Text,
                               clima = cbxClimaEncuentro.Text;
                        Bitmap imagenAlineacion = null;
                        try
                        {
                            imagenAlineacion = new Bitmap(alineacion);
                        } catch { }

                        Logica.InsertEncuentro(nomDeporte, nomArbitro, hora, lugar, fecha, nombre, estado, clima, tipoEncuentro);

                        int idEncuentro = Logica.GetEncuentros(3, nombre)[0].IdEncuentro;

                        string FilePath = null;
                        if (imagenAlineacion != null)
                        {
                            Directory.CreateDirectory(@"C:\Certus\SRD\Encuentros\Alineaciones");
                            FilePath = $@"C:\\Certus\\SRD\\Encuentros\\Alineaciones\\{nombre + idEncuentro}.bmp";
                            using (MemoryStream memory = new MemoryStream())
                            {
                                using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    imagenAlineacion.Save(memory, ImageFormat.Bmp);
                                    byte[] bytes = memory.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);
                                }
                            }
                        }

                        foreach (var ro in rounds)
                        {
                            Logica.InsertRound(ro.NumeroRound, idEncuentro, ro.TiempoTranscurridoRound, 0, 0);
                        }

                        foreach (var h in hitos)
                        {
                            Logica.InsertHito(h.NumeroRound, idEncuentro, h.TituloHito, h.TiempoHito);
                        }

                        foreach (var pR in puntuacionRounds)
                        {
                            Logica.InsertPuntuacionRound(pR.NumeroRound, idEncuentro, pR.Puntos, pR.IdEquipos);
                        }

                        foreach (var ro in rounds)
                        {
                            foreach (var pR in Logica.GetPuntuacionRounds(2, ro.NumeroRound, idEncuentro))
                            {
                                foreach (var h in Logica.GetHitos(2, idEncuentro, ro.NumeroRound))
                                {
                                    Logica.InsertRound(ro.NumeroRound, idEncuentro, ro.TiempoTranscurridoRound, pR.IdPuntuacionRound, h.IdHito);
                                }
                            }

                        }

                        foreach (var eE in equiposEncuentros)
                        {
                            Logica.InsertEquiposEncuentros(idEncuentro, eE.IdEquipo, eE.Puntuacion, eE.Posicion, FilePath);
                        }

                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The match was created correctly");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("El encuentro a sido creado correctamente");
                        }
                    } catch (Exception ex) { MessageBox.Show("Error: "+ex.Message); return; }
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
            else
            {
                if (txtArbitro.Text != "" && txtFechaEncuentro.Text != "" && txtHoraEncuentro.Text != "" &&
                    txtLugarEncuentro.Text != "" && txtNombreEncuentro.Text != "" && cbxClimaEncuentro != null &&
                    cbxDeporteEncuentro != null && cbxEstadoEncuentro != null && cbxTipoEncuentro != null)
                {

                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify sport", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        try
                        {
                            string[] fechaArray = txtFechaEncuentro.Text.Split("/");
                            string fecha = fechaArray[2] + "-" + fechaArray[1] + "-" + fechaArray[0],
                                   nomDeporte = cbxDeporteEncuentro.Text,
                                   nomArbitro = txtArbitro.Text,
                                   hora = txtHoraEncuentro.Text + ":00",
                                   lugar = txtLugarEncuentro.Text,
                                   nombre = txtNombreEncuentro.Text,
                                   estado = cbxEstadoEncuentro.Text,
                                   clima = cbxClimaEncuentro.Text;
                            Bitmap imagenAlineacion = null;
                            try
                            {
                                imagenAlineacion = new Bitmap(alineacion);
                            }
                            catch { }

                            Logica.UpdateEncuentro(index, nomDeporte, nomArbitro, hora, lugar, fecha, nombre, estado, clima, tipoEncuentro);

                            int idEncuentro = Logica.GetEncuentros(3, nombre)[0].IdEncuentro;

                            string FilePath = null;
                            if (imagenAlineacion != null)
                            {
                                Directory.CreateDirectory(@"C:\Certus\SRD\Encuentros\Alineaciones");
                                FilePath = $@"C:\\Certus\\SRD\\Encuentros\\Alineaciones\\{nombre + idEncuentro}.bmp";
                                using (MemoryStream memory = new MemoryStream())
                                {
                                    using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                                    {
                                        imagenAlineacion.Save(memory, ImageFormat.Bmp);
                                        byte[] bytes = memory.ToArray();
                                        fs.Write(bytes, 0, bytes.Length);
                                    }
                                }
                            }

                            foreach (var ro in rounds)
                            {
                                if (Logica.CheckIfExist("Round", "NumeroRound", "" + ro.NumeroRound, "IdEncuentro", "" + idEncuentro) == 1)
                                {
                                    Logica.UpdateRound(ro.NumeroRound, idEncuentro, ro.TiempoTranscurridoRound, 0, 0);
                                }
                                else
                                {
                                    Logica.InsertRound(ro.NumeroRound, idEncuentro, ro.TiempoTranscurridoRound, 0, 0);
                                }
                            }

                            foreach (var h in hitos)
                            {
                                if (Logica.CheckIfExist("Hito", "IdHito", "" + h.IdHito) == 1)
                                {
                                    Logica.UpdateHito(h.IdHito, h.NumeroRound, idEncuentro, h.TituloHito, h.TiempoHito);
                                }
                                else
                                {
                                    Logica.InsertHito(h.NumeroRound, idEncuentro, h.TituloHito, h.TiempoHito);
                                }
                            }

                            foreach (var pR in puntuacionRounds)
                            {
                                if (Logica.CheckIfExist("PuntuacionRound", "IdPuntuacionRound", "" + pR.IdPuntuacionRound) == 1)
                                {
                                    Logica.UpdatePuntuacionRound(pR.IdPuntuacionRound, pR.NumeroRound, idEncuentro, pR.Puntos, pR.IdEquipos);
                                }
                                else
                                {
                                    Logica.InsertPuntuacionRound(pR.NumeroRound, idEncuentro, pR.Puntos, pR.IdEquipos);
                                }
                            }

                            foreach (var ro in rounds)
                            {
                                foreach (var pR in Logica.GetPuntuacionRounds(2, ro.NumeroRound, idEncuentro))
                                {
                                    if (Logica.CheckIfExist("Round", "NumeroRound", "" + ro.NumeroRound, "IdEncuentro", "" + idEncuentro, "IdPuntuacionRound", "" + pR.IdPuntuacionRound) == 1)
                                    {
                                        foreach (var h in Logica.GetHitos(2, idEncuentro, ro.NumeroRound))
                                        {
                                            if (Logica.CheckIfExist("Round", "NumeroRound", "" + ro.NumeroRound, "IdEncuentro", "" + idEncuentro, "IdPuntuacionRound", "" + pR.IdPuntuacionRound, "IdHito", "" + h.IdHito) == 1)
                                            {
                                                Logica.UpdateRound(ro.NumeroRound, idEncuentro, ro.TiempoTranscurridoRound, pR.IdPuntuacionRound, h.IdHito);
                                            }
                                            else
                                            {
                                                Logica.InsertRound(ro.NumeroRound, idEncuentro, ro.TiempoTranscurridoRound, pR.IdPuntuacionRound, h.IdHito);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (var h in Logica.GetHitos(2, idEncuentro, ro.NumeroRound))
                                        {
                                            Logica.InsertRound(ro.NumeroRound, idEncuentro, ro.TiempoTranscurridoRound, pR.IdPuntuacionRound, h.IdHito);
                                        }
                                    }
                                }
                            }

                            foreach (var eE in equiposEncuentros)
                            {
                                if (Logica.CheckIfExist("EquiposEncuentros", "IdEncuentro", idEncuentro + "", "IdEquipo", eE.IdEquipo + "") == 1)
                                {
                                    Logica.UpdateEquiposEncuentros(idEncuentro, eE.IdEquipo, eE.Puntuacion, eE.Posicion, FilePath);
                                }
                                else
                                {
                                    Logica.InsertEquiposEncuentros(idEncuentro, eE.IdEquipo, eE.Puntuacion, eE.Posicion, FilePath);
                                }
                            }

                            foreach (var r in Logica.GetRounds(2, "" + idEncuentro))
                            {
                                if (r.NumeroRound > cantRounds)
                                {
                                    Logica.Delete("Round", "IdEncuentro", "" + idEncuentro, "NumeroRound", "" + r.NumeroRound);
                                }
                            }

                            foreach (var eE in Logica.GetEquiposEncuentros(2, "" + idEncuentro))
                            {
                                bool match = false;
                                foreach (var eq in equiposEncuentros)
                                {
                                    if (eE.IdEquipo == eq.IdEquipo)
                                    {
                                        match = true;
                                    }
                                }
                                if (match == false)
                                {
                                    Logica.Delete("EquiposEncuentros", "IdEncuentro", "" + idEncuentro, "IdEquipo", "" + eE.IdEquipo);
                                }
                            }

                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The match was modified correctly");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("El encuentro a sido modificado correctamente");
                            }
                            Hide();
                            MenuManageEncuentros manageMatchs = new MenuManageEncuentros();
                            manageMatchs.StartPosition = FormStartPosition.CenterParent;
                            manageMatchs.ShowDialog();
                            Close();
                        }
                        catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); return; }
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
        }

        private void btnMinusRounds_Click(object sender, EventArgs e)
        {
            if (cantRounds > 1)
            {
                cbxActualRound.Items.Remove(cantRounds);
                cantRounds -= 1;
                txtCantRounds.Text = "" + cantRounds;
                rounds.RemoveAt(cantRounds);
            }
            else
            {
                MessageBox.Show("There can't be less than one round");
            }
        }

        private void btnPlusRounds_Click(object sender, EventArgs e)
        {
            cantRounds += 1;
            txtCantRounds.Text = "" + cantRounds;
            cbxActualRound.Items.Add(cantRounds);
            rounds.Add(new Round() { NumeroRound = cantRounds });
        }

        private void PointsAcceptsOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void CargarEquipos()
        {
            foreach (var eq in equiposEncuentros)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(451, 25);
                p1.TabIndex = 0;

                Label l1 = new Label(); //Nombre del equipo

                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = eq.NombreEquipo;
                l1.TextAlign = ContentAlignment.MiddleLeft;
                l1.Size = new Size(268, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);

                Button btn1 = new Button(); //Seleccionar alineamiento del equipo

                btn1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                btn1.Cursor = Cursors.Hand;
                btn1.FlatAppearance.BorderColor = Color.DimGray;
                btn1.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                btn1.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                btn1.Location = new Point(268, 0);
                btn1.Text = "Select alignment";
                btn1.Size = new Size(150, 25);
                btn1.UseVisualStyleBackColor = true;
                btn1.Click += (sender, EventArgs) => { btnSelectImage_Click(sender, EventArgs); };

                switch (tipoEncuentro)
                {
                    case 1: //Puntos
                        TextBox txt1 = new TextBox();

                        txt1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt1.Location = new Point(418, 0);
                        txt1.Size = new Size(39, 25);
                        txt1.Text = ""+eq.Puntuacion;
                        txt1.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 1, eq.IdEquipo, txt1.Text); };
                        txt1.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        p1.Controls.Add(txt1);
                        break;
                    case 2: //Sets
                        TextBox txt2 = new TextBox();

                        txt2.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt2.Location = new Point(418, 0);
                        txt2.Size = new Size(39, 25);
                        txt2.Text = ""+eq.Puntuacion;
                        txt2.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 1, eq.IdEquipo, txt2.Text); };
                        txt2.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        var pR = puntuacionRounds.Find(p => p.IdEquipos == eq.IdEquipo && p.NumeroRound == 1);

                        TextBox txt3 = new TextBox();

                        txt3.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt3.Location = new Point(457, 0);
                        txt3.Size = new Size(39, 25);
                        txt3.Text = ""+pR.Puntos;
                        txt3.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 2, eq.IdEquipo, txt3.Text); };
                        txt3.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        p1.Controls.Add(txt2);
                        p1.Controls.Add(txt3);
                        break;
                    case 3: //Position
                        TextBox txt4 = new TextBox();

                        txt4.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        txt4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                        txt4.Location = new Point(430, 0);
                        txt4.Size = new Size(25, 25);
                        txt4.Text = ""+eq.Posicion;
                        txt4.Leave += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 3, eq.IdEquipo, txt4.Text); };
                        txt4.KeyPress += (sender, EventArgs) => { PointsAcceptsOnlyNumbers(sender, EventArgs); };

                        p1.Controls.Add(txt4);
                        break;
                    case 4: //Winner
                        CheckBox chk1 = new CheckBox();

                        chk1.Location = new Point(426, 2);
                        chk1.Size = new Size(23, 23);
                        if (eq.Posicion == 1)
                        {
                            chk1.CheckState = CheckState.Checked;
                        }
                        chk1.CheckedChanged += (sender, EventArgs) => { EditTeamScore(sender, EventArgs, 4, eq.IdEquipo, chk1.Checked.ToString()); };

                        p1.Controls.Add(chk1);
                        break;
                }

                panelEquiposContenedor.Controls.Add(p1);
                p1.Controls.Add(btn1);
                p1.Controls.Add(l1);

                panelBuscador.Hide();
            }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblMatchName.Text = "Name";
                    lblMatchLocation.Text = "Location";
                    lblSport.Text = "Sport";
                    lblFecha.Text = "Date";
                    lblEstado.Text = "State";
                    lblHour.Text = "Time";
                    lblTipo.Text = "Type";
                    lblClima.Text = "Weather";
                    lblNRound.Text = "Number of rounds";
                    lblRound.Text = "Round";
                    lblTimeRound.Text = "Round duration";
                    btnAddEncuentro.Text = "Add";
                    btnArbitro.Text = "Refree";
                    btnHitosList.Text = "Milestones list";
                    btnSelectParticipants.Text = "Add participant";
                    btnNewHito.Text = "Add new milestone";
                    lblTiempoHito.Text = "Time";
                    lblTituloHito.Text = "Title";
                    break;
                case "ES": //Español
                    lblMatchName.Text = "Nombre";
                    lblMatchName.Location = new Point(123, 52);
                    lblMatchLocation.Text = "Locación";
                    lblSport.Text = "Deporte";
                    lblSport.Location = new Point(520, 52);
                    lblFecha.Text = "Fecha";
                    lblEstado.Text = "Estado";
                    lblHour.Text = "Hora";
                    lblTipo.Text = "Tipo";
                    lblClima.Text = "Clima";
                    lblNRound.Text = "Cantidad rounds";
                    lblRound.Text = "Round";
                    lblTimeRound.Text = "Duracion del round";
                    lblTimeRound.Location = new Point(370, 156);
                    btnAddEncuentro.Text = "Agregar";
                    btnArbitro.Text = "Arbitro";
                    btnHitosList.Text = "Lista de hitos";
                    btnSelectParticipants.Text = "Agregar participante";
                    btnNewHito.Text = "Agregar nuevo hito";
                    lblTiempoHito.Text = "Tiempo";
                    lblTituloHito.Text = "Titulo";
                    break;
            }
        }
    }
}