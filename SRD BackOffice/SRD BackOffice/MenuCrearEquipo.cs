namespace SRD_BackOffice
{
    public partial class MenuCrearEquipo : Form
    {
        Bitmap imagenCargada = null;
        bool modify = false;
        string member;
        int index, idMember;
        List<EquiposDeportistas> miembros = new List<EquiposDeportistas>();

        public MenuCrearEquipo()
        {
            InitializeComponent();
            SetIdioma();

            picReset.Click += (sender, eventArgs) => { KickMember(sender, eventArgs); };

            panelBuscadorEquipos.Hide();
        }

        public MenuCrearEquipo(int index)
        {
            InitializeComponent();
            SetIdioma();

            picReset.Click += (sender, eventArgs) => { KickMember(sender, eventArgs); };

            panelBuscadorEquipos.Hide();
            this.index = index;
            modify = true;

            var equipo = Logica.GetEquipos(3, ""+index)[0];
            equipo.Miembros = Logica.GetEquiposDeportistas(3, "" + index);

            btnSportAdd.Text = "Modify";
            picTeam.Image = equipo.ImagenRepresentativa;
            txtNombre.Text = equipo.NombreEquipo;
            txtPais.Text = equipo.PaisOrigen;
            cbxTipo.SelectedItem = equipo.TipoEquipo;
            if (equipo.Miembros == null)
            {
                miembros = new List<EquiposDeportistas>();
            } else
            {
                miembros = equipo.Miembros;
            }

            foreach (var m in miembros)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(416, 25);
                p1.TabIndex = 0;

                Label l1 = new Label(); //ID del deportista

                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = "" + m.IdPersona;
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.Size = new Size(80, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);

                Label l2 = new Label(); //Nombre del deportista

                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.Text = m.Nombre + " " + m.Apellido;
                l2.TextAlign = ContentAlignment.MiddleLeft;
                l2.Size = new Size(336, 25);
                l2.AutoSize = false;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(80, 0);

                panelPlayers.Controls.Add(p1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
            }
        }

        private void btnSportCerrar_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            Close();
        }

        private void btnSportAdd_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                bool exist = false;
                try
                {
                    if (txtNombre.Text != "" && cbxTipo != null && txtPais.Text != "")
                    {
                        try
                        {
                            string nombreEquipo = txtNombre.Text,
                                   paisOrigen = txtPais.Text,
                                   tipoEquipo = cbxTipo.Text;
                            Byte[] imagenEquipo = null;

                            Logica.InsertEquipo(nombreEquipo, paisOrigen, tipoEquipo, imagenEquipo);

                            int idEquipo = Logica.GetEquipos(4, nombreEquipo)[0].IdEquipo;

                            foreach (var m in miembros)
                            {
                                Logica.InsertEquiposDeportistas(idEquipo, m.IdPersona);
                            }

                            if (Program.language == "EN")
                            {
                                MessageBox.Show("New team created correctly");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("Nuevo equipo creado correctamente");
                            }
                        } catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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
                    MessageBox.Show("Error");
                }
            } else
            {
                if (txtNombre.Text != "" && picTeam != null && txtPais != null)
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify sport", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        try
                        {
                            string nombreEquipo = txtNombre.Text,
                                   paisOrigen = txtPais.Text,
                                   tipoEquipo = cbxTipo.Text;
                            Byte[] imagenEquipo = null;

                            Logica.UpdateEquipo(index, nombreEquipo, paisOrigen, tipoEquipo, imagenEquipo);

                            int idEquipo = Logica.GetEquipos(4, nombreEquipo)[0].IdEquipo;

                            foreach (var m in miembros)
                            {
                                if (Logica.CheckIfExist("EquiposDeportistas", "IdEquipo", ""+idEquipo, "IdPersona", ""+m.IdPersona) == 0)
                                {
                                    Logica.InsertEquiposDeportistas(idEquipo, m.IdPersona);
                                } else
                                {
                                    Logica.UpdateEquiposDeportistas(idEquipo, m.IdPersona);
                                }
                            }

                            foreach (var eD in Logica.GetEquiposDeportistas(3, ""+idEquipo))
                            {
                                bool match = false;
                                foreach (var m in miembros)
                                {
                                    if (eD.IdPersona == m.IdPersona)
                                    {
                                        match = true;
                                    }
                                }
                                if (match == false)
                                {
                                    Logica.Delete("EquiposDeportistas", "IdEquipo", "" + idEquipo, "IdPersona", "" + eD.IdPersona);
                                }
                            }

                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The team was modified correctly");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("El equipo a sido modificado correctamente");
                            }
                            Hide();
                            MenuManageTeams manageTeams = new MenuManageTeams();
                            manageTeams.StartPosition = FormStartPosition.CenterParent;
                            manageTeams.ShowDialog();
                            Close();
                        }
                        catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    imagenCargada = new Bitmap(open.FileName);
                    int wid = imagenCargada.Width;
                    int hei = imagenCargada.Height;
                    if (wid == 150 || hei == 150)
                    {
                        picTeam.Image = imagenCargada;
                    }
                    else
                    {
                        imagenCargada = null;
                        picTeam.Image = null;
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The image must be of the size of 150x150 pixels");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("La imagen debe ser de la medida de 150x150 pixeles");
                        }
                    }
                }
            } catch
            {
                MessageBox.Show("Error");
            }
        }

        private void picAddPlayer_Click(object sender, EventArgs e)
        {
            panelBuscadorEquipos.Show();

            TextBox buscador = new TextBox();

            buscador.Size = new Size(250, 26);
            buscador.Location = new Point(39, 20);
            buscador.BorderStyle = BorderStyle.FixedSingle;

            Button btnBuscar = new Button();

            btnBuscar.Size = new Size(25, 25);
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

            btn1.Size = new Size(80, 20);
            btn1.Location = new Point(136, 50);
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btn1.Text = "Add";
            btn1.Click += (sender, EventArgs) => { AddMember(sender, EventArgs); };

            btnBuscar.Click += (sender, EventArgs) => { BuscarDeportista(sender, EventArgs, buscador.Text, panelContenedor); };

            panelBuscadorEquipos.Controls.Add(panelPrincipal);
            panelBuscadorEquipos.Controls.Add(buscador);
            panelBuscadorEquipos.Controls.Add(btnBuscar);
            panelBuscadorEquipos.Controls.Add(btn1);
            panelPrincipal.Controls.Add(panelLabels);
            panelPrincipal.Controls.Add(panelContenedor);
            panelLabels.Controls.Add(lblDeportista);
            panelLabels.Controls.Add(lblOrigen);
            panelLabels.Controls.Add(lblId);

            var deportistas = Logica.GetDeportistas(1, null);
            int count = 0;

            foreach (var d in deportistas)
            {
                Panel p1 = new Panel();

                p1.Location = new Point(0, 25 * count);
                p1.Size = new Size(334, 25);

                Label lbl1 = new Label();

                lbl1.Text = "" + d.IdPersona;
                lbl1.Size = new Size(40, 25);
                lbl1.Location = new Point(0, 0);
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;

                Label lbl2 = new Label();

                lbl2.Text = d.Nombre+" "+d.Apellido;
                lbl2.Size = new Size(200, 25);
                lbl2.Location = new Point(40, 0);
                lbl2.BorderStyle = BorderStyle.FixedSingle;
                lbl2.TextAlign = ContentAlignment.MiddleCenter;

                Label lbl3 = new Label();

                lbl3.Text = "" + d.Nacionalidad;
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
                btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, panelContenedor, d.IdPersona, d.Nombre+" "+d.Apellido); };

                panelContenedor.Controls.Add(p1);
                p1.Controls.Add(btn2);
                p1.Controls.Add(lbl3);
                p1.Controls.Add(lbl2);
                p1.Controls.Add(lbl1);

                count++;
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
            member = name;
            idMember = id;
        }

        private void BuscarDeportista(object sender, EventArgs e, string busqueda, Panel p)
        {
            p.Controls.Clear();

            var deportistas = Logica.GetDeportistas(2, busqueda);
            int count = 0;

            foreach (var d in deportistas)
            {
                if (busqueda == Convert.ToString(d.IdPersona) || (d.Nombre+" "+d.Apellido).Contains(busqueda) || d.Nacionalidad.Contains(busqueda))
                {
                    Panel p1 = new Panel();

                    p1.Location = new Point(0, 25 * count);
                    p1.Size = new Size(334, 25);

                    Label lbl1 = new Label();

                    lbl1.Text = "" + d.IdPersona;
                    lbl1.Size = new Size(40, 25);
                    lbl1.Location = new Point(0, 0);
                    lbl1.BorderStyle = BorderStyle.FixedSingle;
                    lbl1.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl2 = new Label();

                    lbl2.Text = d.Nombre+" "+d.Apellido;
                    lbl2.Size = new Size(200, 25);
                    lbl2.Location = new Point(40, 0);
                    lbl2.BorderStyle = BorderStyle.FixedSingle;
                    lbl2.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl3 = new Label();

                    lbl3.Text = "" + d.Nacionalidad;
                    lbl3.Size = new Size(82, 25);
                    lbl3.Location = new Point(240, 0);
                    lbl3.BorderStyle = BorderStyle.FixedSingle;
                    lbl3.TextAlign = ContentAlignment.MiddleCenter;

                    Button btn1 = new Button();

                    btn1.Size = new Size(12, 12);
                    btn1.Location = new Point(322, 7);
                    btn1.FlatStyle = FlatStyle.Flat;
                    btn1.BackgroundImageLayout = ImageLayout.Stretch;
                    btn1.BackgroundImage = Properties.Resources.mas;
                    btn1.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn1, p, d.IdPersona, d.Nombre + " " + d.Apellido); };

                    p.Controls.Add(p1);
                    p1.Controls.Add(btn1);
                    p1.Controls.Add(lbl3);
                    p1.Controls.Add(lbl2);
                    p1.Controls.Add(lbl1);

                    count++;
                }
            }
        }

        private void AddMember(object sender, EventArgs e)
        {
            miembros.Add(new EquiposDeportistas() { IdPersona = idMember });

            Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

            p1.Dock = DockStyle.Top;
            p1.BorderStyle = BorderStyle.None;
            p1.BackColor = Color.FromArgb(255, 255, 248);
            p1.Size = new Size(416, 25);
            p1.TabIndex = 0;

            Label l1 = new Label(); //ID del deportista

            l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            l1.Text = ""+idMember;
            l1.TextAlign = ContentAlignment.MiddleCenter;
            l1.Size = new Size(80, 25);
            l1.AutoSize = false;
            l1.BackColor = Color.FromArgb(255, 255, 248);
            l1.BorderStyle = BorderStyle.FixedSingle;
            l1.Location = new Point(0, 0);

            Label l2 = new Label(); //Nombre del deportista

            l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            l2.Text = member;
            l2.TextAlign = ContentAlignment.MiddleLeft;
            l2.Size = new Size(336, 25);
            l2.AutoSize = false;
            l2.BackColor = Color.FromArgb(255, 255, 248);
            l2.BorderStyle = BorderStyle.FixedSingle;
            l2.Location = new Point(80, 0);

            panelPlayers.Controls.Add(p1);
            p1.Controls.Add(l1);
            p1.Controls.Add(l2);

            panelBuscadorEquipos.Hide();
        }

        private void KickMember(object sender, EventArgs e)
        {
            miembros.Clear();
            panelPlayers.Controls.Clear();
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblTitle.Text = "Create team";
                    lblTipo.Text = "Type of team";
                    lblTipo.Location = new Point(352, 251);
                    lblPais.Text = "Country of origin";
                    lblPais.Location = new Point(276, 175);
                    lblName.Text = "Team name";
                    lblName.Location = new Point(290, 97);
                    lblImage.Text = "Team image";
                    lblImage.Location = new Point(63, 80);
                    lblPlayers.Text = "Members";
                    lblPlayers.Location = new Point(216, 315);
                    btnSportAdd.Text = "Add";
                    btnSelectImage.Text = "Select image";
                    break;
                case "ES": //Español
                    lblTitle.Text = "Crear equipo";
                    lblTipo.Text = "Tipo de equipo";
                    lblTipo.Location = new Point(345, 251);
                    lblPais.Text = "País de origen";
                    lblPais.Location = new Point(286, 175);
                    lblName.Text = "Nombre del equipo";
                    lblName.Location = new Point(275, 97);
                    lblImage.Text = "Imagen del equipo";
                    lblImage.Location = new Point(48, 80);
                    lblPlayers.Text = "Miembros";
                    lblPlayers.Location = new Point(206, 315);
                    btnSportAdd.Text = "Agregar";
                    btnSelectImage.Text = "Seleccionar imagen";
                    break;
            }
        }
    }
}