namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_EquiposJugadores : Form
    {
        private static Frm_EquiposJugadores form = null;
        bool favorite = false;
        int id;
        public Frm_EquiposJugadores(int type, int id)
        {
            InitializeComponent();
            this.id = id;
            form = this;
            SetTheme();
            if (Program.user.email == null)
            {
                picFavorito.Hide();
            } else
            {
                if (Logica.CheckIfExist("EquiposFavoritos", "Email", Program.user.email, "IdEquipo", "" + id) == 1)
                {
                    favorite = true;
                    picFavorito.BackgroundImage = Properties.Resources.estrellaRellena;
                }
            }

            CargarContenido(type);
        }

        private void CargarContenido(int type)
        {
            //Definir si es favorito o no

            switch (type)
            {
                case 1: //Equipos
                    panelContenedor.Location = new Point(20, 205);

                    var eq = Logica.GetEquipos(3, "" + id)[0];
                    var eqEnc = Logica.GetEquiposEncuentros(3, ""+id);
                    var dep = Logica.GetEquiposDeportistas(3, "" + id).Find(d => d.Nombre + " " + d.Apellido == eq.NombreEquipo);

                    picImagen.Image = eq.ImagenRepresentativa;
                    lblNombre.Text = eq.NombreEquipo;
                    lblNombre.Location = new Point(175 - (lblNombre.Width / 2), 174);

                    if (eq.TipoEquipo == "Individual team")
                    {
                        TextBox descripcion1 = new TextBox();

                        descripcion1.Text = dep.Descripcion;
                        descripcion1.BorderStyle = BorderStyle.FixedSingle;
                        descripcion1.Location = new Point(0, 0);
                        descripcion1.AutoSize = false;
                        descripcion1.TabIndex = 3;
                        descripcion1.Size = new Size(328, 209);
                        descripcion1.Enabled = false;
                        descripcion1.BackColor = AjustesDeUsuario.btnBack;
                        descripcion1.ForeColor = Color.Black;
                        descripcion1.Multiline = true;

                        panelContenedor.Controls.Add(descripcion1);
                    } else
                    {
                        int count = 0;
                        foreach (var eqE in eqEnc)
                        {
                            Panel p4 = new Panel();

                            p4.BorderStyle = BorderStyle.FixedSingle;
                            p4.Size = new Size(310, 50);
                            p4.TabIndex = 0;
                            p4.Location = new Point(0, 50 * count);
                            p4.BackColor = AjustesDeUsuario.panel;

                            Label l2 = new Label();

                            l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                            l2.Text = eqE.Nombre;
                            l2.Size = new Size((l2.Text.Length * 10), 25);
                            l2.AutoSize = true;
                            l2.BorderStyle = BorderStyle.None;
                            l2.Location = new Point(p4.Width / 2 - l2.Width / 2, 12);
                            l2.TabIndex = 3;
                            l2.ForeColor = AjustesDeUsuario.foreColor;

                            p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                            l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };

                            panelContenedor.Controls.Add(p4);
                            p4.Controls.Add(l2);
                        }
                        count++;
                    }
                    break;
                case 2: //Deportistas
                    picFavorito.Hide();

                    var dep1 = Logica.GetDeportistas(3, "" + id)[0];

                    lblNombre.Text = dep1.Nombre+" "+dep1.Apellido;
                    lblNombre.Location = new Point(175 - (lblNombre.Width / 2), 100);

                    TextBox descripcion = new TextBox();

                    descripcion.Text = dep1.Descripcion;
                    descripcion.BorderStyle = BorderStyle.FixedSingle;
                    descripcion.Location = new Point(0, 0);
                    descripcion.AutoSize = false;
                    descripcion.TabIndex = 3;
                    descripcion.Size = new Size(328, 209);
                    descripcion.Enabled = false;
                    descripcion.BackColor = AjustesDeUsuario.btnBack;
                    descripcion.ForeColor = Color.Black;
                    descripcion.Multiline = true;

                    panelContenedor.Controls.Add(descripcion);
                    break;
            }
        }
        
        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (favorite == false)
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaRellena;
                favorite = true;
                Logica.InsertEquiposFavoritos(Program.user.email, id);
                Program.refreshFavorites();
            } else
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaVacia;
                favorite = false;
                Logica.Delete("EquiposFavoritos", "Email", Program.user.email, "IdEquipo", ""+id);
                Program.refreshFavorites();
            }
        }

        private void UltimoEncuentro_Click(object sender, EventArgs e)
        {
            Principal.AlterPrincipal(0, 5, 0);
            Parent.Hide();
            Close();
        }

        public static void AlterEquiposJugadores()
        {
            if (form != null)
            {
                form.SetTheme();
            }
        }

        private void SetTheme()
        {
            /* Paneles */
            BackColor = AjustesDeUsuario.panel;
            panelContenedor.BackColor = AjustesDeUsuario.panel;
            /* Botones */
            btnCerrarSettings.BackColor = AjustesDeUsuario.btnBack;
            btnCerrarSettings.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnCerrarSettings.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            /* Textos (Incluidos botones) */
            btnCerrarSettings.ForeColor = AjustesDeUsuario.foreColor;
            lblNombre.ForeColor = AjustesDeUsuario.foreColor;
        }
    }
}