namespace SRD_BackOffice
{
    public partial class MenuManageTeams : Form
    {
        public MenuManageTeams()
        {
            InitializeComponent();
            CargarEquipos();

            btnBuscar.Click += (sender, EventArgs) => { btnBuscar_Click(sender, EventArgs, txtBuscador.Text); };
        }

        private void CargarEquipos()
        {
            int x = 0;
            var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
            int count = equipos.Count;
            foreach (var equipo in equipos)
            {
                if (x >= count - 15)
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(453, 25);
                    p1.TabIndex = 0;

                    Label l1 = new Label(); //ID del equipo

                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.Text = $"{equipo.IdEquipo}";
                    l1.TextAlign = ContentAlignment.MiddleCenter;
                    l1.Size = new Size(70, 25);
                    l1.AutoSize = false;
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.TabIndex = 3;

                    Label l2 = new Label(); //Nombre del equipo

                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l2.Text = $"{equipo.NombreEquipo}";
                    l2.TextAlign = ContentAlignment.MiddleCenter;
                    l2.Size = new Size(258, 25);
                    l2.AutoSize = false;
                    l2.BackColor = Color.FromArgb(255, 255, 248);
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(70, 0);
                    l2.TabIndex = 3;

                    Label l3 = new Label(); //Pais de origen del equipo

                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l3.TextAlign = ContentAlignment.MiddleCenter;
                    l3.Text = $"{equipo.PaisOrigen}";
                    l3.Size = new Size(100, 25);
                    l3.BorderStyle = BorderStyle.FixedSingle;
                    l3.BackColor = Color.FromArgb(255, 255, 248);
                    l3.AutoSize = false;
                    l3.Location = new Point(328, 0);
                    l3.TabIndex = 3;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(440, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { Delete(sender, EventArgs, equipos, equipo, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(428, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { Modify(sender, EventArgs, equipos.IndexOf(equipo)); };

                    this.panelContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                    p1.Controls.Add(pic2);
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l2);
                    p1.Controls.Add(l3);
                }
                x++;
            }
        }

        private void btnSportsManagerCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            this.Close();
        }

        private void Delete(object sender, EventArgs e, List<Equipo> list, Equipo d, Panel p)
        {
            DialogResult dialogResult1 = MessageBox.Show("Do you really want to delete this?", "Delete team", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you really sure?", "DELETE team", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    list.Remove(d);
                    Logica.SerializeEquipos(list);
                    p.Dispose();
                }
            }
        }

        private void Modify(object sender, EventArgs e, int index)
        {
            this.Hide();
            MenuCrearEquipo crearEquipo = new MenuCrearEquipo(index);
            crearEquipo.StartPosition = FormStartPosition.CenterParent;
            crearEquipo.ShowDialog();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e, string busqueda)
        {
            panelContenedor.Controls.Clear();

            var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
            int count = 0;

            foreach (var equipo in equipos)
            {
                if (busqueda == Convert.ToString(equipo.IdEquipo) || equipo.NombreEquipo.Contains(busqueda) || equipo.PaisOrigen.Contains(busqueda))
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(453, 25);
                    p1.TabIndex = 0;

                    Label l1 = new Label(); //ID del equipo

                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.Text = $"{equipo.IdEquipo}";
                    l1.TextAlign = ContentAlignment.MiddleCenter;
                    l1.Size = new Size(70, 25);
                    l1.AutoSize = false;
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.TabIndex = 3;

                    Label l2 = new Label(); //Nombre del equipo

                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l2.Text = $"{equipo.NombreEquipo}";
                    l2.TextAlign = ContentAlignment.MiddleCenter;
                    l2.Size = new Size(258, 25);
                    l2.AutoSize = false;
                    l2.BackColor = Color.FromArgb(255, 255, 248);
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(70, 0);
                    l2.TabIndex = 3;

                    Label l3 = new Label(); //Pais de origen del equipo

                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l3.TextAlign = ContentAlignment.MiddleCenter;
                    l3.Text = $"{equipo.PaisOrigen}";
                    l3.Size = new Size(100, 25);
                    l3.BorderStyle = BorderStyle.FixedSingle;
                    l3.BackColor = Color.FromArgb(255, 255, 248);
                    l3.AutoSize = false;
                    l3.Location = new Point(328, 0);
                    l3.TabIndex = 3;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(440, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { Delete(sender, EventArgs, equipos, equipo, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(428, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { Modify(sender, EventArgs, equipos.IndexOf(equipo)); };

                    this.panelContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                    p1.Controls.Add(pic2);
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l2);
                    p1.Controls.Add(l3);
                }
            }
        }
    }
}
