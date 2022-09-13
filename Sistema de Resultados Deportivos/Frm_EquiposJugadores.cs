namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_EquiposJugadores : Form
    {
        private static Frm_EquiposJugadores form = null;
        bool favorite = false;
        public Frm_EquiposJugadores(int type)
        {
            InitializeComponent();
            form = this;
            SetTheme();

            CargarContenido(type);
        }

        private void CargarContenido(int type)
        {
            picImagen.Image = null;
            lblNombre.Text = "Nombre";
            lblNombre.Location = new Point(175 - (lblNombre.Width / 2), 174);
            //Definir si es favorito o no

            switch(type)
            {
                case 1: //Equipos
                    for (int j = 1; j < 11; j++)
                    {
                        panelContenedor.Location = new Point(20, 205);

                        Panel p4 = new Panel();

                        p4.BorderStyle = BorderStyle.FixedSingle;
                        p4.Size = new Size(310, 50);
                        p4.TabIndex = 0;
                        p4.Location = new Point(0, 50 * (j - 1));
                        p4.BackColor = AjustesDeUsuario.panel;

                        PictureBox pic1 = new PictureBox();

                        pic1.InitialImage = null;
                        pic1.BackColor = Color.Transparent;
                        pic1.Size = new Size(40, 40);
                        pic1.Location = new Point(10, 5);
                        pic1.TabIndex = 1;
                        pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic1.Image = Properties.Resources.barcelona;
                        pic1.BackColor = Color.Transparent;

                        PictureBox pic2 = new PictureBox();

                        pic2.InitialImage = null;
                        pic2.BackColor = Color.Transparent;
                        pic2.Size = new Size(40, 40);
                        pic2.Location = new Point(260, 5);
                        pic2.TabIndex = 1;
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic2.Image = Properties.Resources.barcelona;
                        pic2.BackColor= Color.Transparent;

                        Label l2 = new Label();

                        l2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                        l2.Text = $"{j} - {j}";
                        l2.Size = new Size((l2.Text.Length * 10), 25);
                        l2.AutoSize = true;
                        l2.BorderStyle = BorderStyle.None;
                        l2.Location = new Point(p4.Width / 2 - l2.Width / 2, 12);
                        l2.TabIndex = 3;
                        l2.ForeColor = AjustesDeUsuario.foreColor;

                        p4.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                        l2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                        pic2.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };
                        pic1.Click += (sender, EventArgs) => { UltimoEncuentro_Click(sender, EventArgs); };

                        this.panelContenedor.Controls.Add(p4);
                        p4.Controls.Add(l2);
                        p4.Controls.Add(pic2);
                        p4.Controls.Add(pic1);
                    }
                    break;
                case 2: //Deportistas
                    picFavorito.Hide();

                    TextBox descripcion = new TextBox();

                    descripcion.Text = null;
                    descripcion.BorderStyle = BorderStyle.FixedSingle;
                    descripcion.Location = new Point(0, 0);
                    descripcion.AutoSize = false;
                    descripcion.TabIndex = 3;
                    descripcion.Size = new Size(328, 159);
                    descripcion.Enabled = false;
                    descripcion.BackColor = AjustesDeUsuario.btnBack;
                    descripcion.ForeColor = AjustesDeUsuario.foreColor;

                    Panel p1 = new Panel();

                    p1.Size = new Size(328, 50);
                    p1.TabIndex = 3;
                    p1.Location = new Point(0, 159);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.BackColor = AjustesDeUsuario.panel;

                    Label lbl1 = new Label();

                    lbl1.Text = $"Anotación: 3";
                    lbl1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    lbl1.Size = new Size(lbl1.Text.Length * 9, 25);
                    lbl1.TextAlign = ContentAlignment.MiddleCenter;
                    lbl1.AutoSize = true;
                    lbl1.BorderStyle = BorderStyle.None;
                    lbl1.Location = new Point(5, 13);
                    lbl1.TabIndex = 3;
                    lbl1.ForeColor = AjustesDeUsuario.foreColor;

                    Label lbl2 = new Label();

                    lbl2.Text = $"Faltas: 1";
                    lbl2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    lbl2.Size = new Size(lbl2.Text.Length * 7, 25);
                    lbl2.TextAlign = ContentAlignment.MiddleCenter;
                    lbl2.AutoSize = true;
                    lbl2.BorderStyle = BorderStyle.None;
                    lbl2.Location = new Point(328 - (lbl2.Width + 5), 13);
                    lbl2.TabIndex = 3;
                    lbl2.ForeColor = AjustesDeUsuario.foreColor;

                    panelContenedor.Controls.Add(p1);
                    panelContenedor.Controls.Add(descripcion);
                    p1.Controls.Add(lbl1);
                    p1.Controls.Add(lbl2);
                    break;
            }
        }
        
        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (favorite == false)
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaRellena;
                favorite = true;
            } else
            {
                picFavorito.BackgroundImage = Properties.Resources.estrellaVacia;
                favorite = false;
            }
        }

        private void UltimoEncuentro_Click(object sender, EventArgs e)
        {
            Principal.AlterPrincipal(0, 5, 0);
            Parent.Hide();
            this.Close();
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