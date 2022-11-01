namespace SRD_BackOffice
{
    public partial class MenuManageEncuentros : Form
    {
        public MenuManageEncuentros()
        {
            InitializeComponent();
            SetIdioma();
            CargarEncuentros();

            btnBuscar.Click += (sender, EventArgs) => { btnBuscar_Click(sender, EventArgs, txtBuscador.Text); };
        }

        private void CargarEncuentros()
        {
            int x = 0;
            var encuentros = Logica.GetEncuentros(1, null);
            int count = encuentros.Count;
            foreach (var encuentro in encuentros)
            {
                if (x >= count - 15)
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(435, 25);
                    p1.TabIndex = 0;

                    Label l1 = new Label(); //ID del encuentro

                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.TextAlign = ContentAlignment.MiddleCenter;
                    l1.Size = new Size(60, 25);
                    l1.AutoSize = false;
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.Text = ""+ encuentro.IdEncuentro;

                    Label l2 = new Label(); //Nombre del encuentro

                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l2.TextAlign = ContentAlignment.MiddleCenter;
                    l2.Size = new Size(294, 25);
                    l2.AutoSize = false;
                    l2.BackColor = Color.FromArgb(255, 255, 248);
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(60, 0);
                    l2.Text = encuentro.Nombre;

                    Label l4 = new Label(); //Fecha del encuentro

                    l4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l4.TextAlign = ContentAlignment.MiddleCenter;
                    l4.Size = new Size(85, 25);
                    l4.BorderStyle = BorderStyle.FixedSingle;
                    l4.BackColor = Color.FromArgb(255, 255, 248);
                    l4.AutoSize = false;
                    l4.Location = new Point(354, 0);
                    l4.Text = encuentro.Fecha;

                    Label l5 = new Label(); //Hora del evento

                    l5.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l5.TextAlign = ContentAlignment.MiddleCenter;
                    l5.Size = new Size(55, 25);
                    l5.BorderStyle = BorderStyle.FixedSingle;
                    l5.BackColor = Color.FromArgb(255, 255, 248);
                    l5.AutoSize = false;
                    l5.Location = new Point(439, 0);
                    l5.Text = encuentro.Hora;

                    Label l6 = new Label(); //Estado del evento

                    l6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l6.TextAlign = ContentAlignment.MiddleCenter;
                    l6.Size = new Size(110, 25);
                    l6.BorderStyle = BorderStyle.FixedSingle;
                    l6.BackColor = Color.FromArgb(255, 255, 248);
                    l6.AutoSize = false;
                    l6.Location = new Point(494, 0);
                    l6.Text = encuentro.Estado;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(616, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, encuentro.IdEncuentro, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(604, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { Modify_Click(sender, EventArgs, encuentro.IdEncuentro); };

                    panelContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                    p1.Controls.Add(pic2);
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l2);
                    p1.Controls.Add(l4);
                    p1.Controls.Add(l5);
                    p1.Controls.Add(l6);
                }
                x++;
            }
        }

        private void btnSportsManagerCerrar_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            Close();
        }

        private void Delete_Click(object sender, EventArgs e, int id, Panel p)
        {
            DialogResult dialogResult1 = MessageBox.Show("Do you really want to delete this?", "Delete event", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you really sure?", "DELETE event", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    try
                    {
                        Logica.Delete("Encuentros", "IdEncuentro", id + "");
                        p.Dispose();
                        MessageBox.Show("Successfully eliminated");
                    }
                    catch { MessageBox.Show("Error"); }
                }
            }
        }

        private void Modify_Click(object sender, EventArgs e, int index)
        {
            Hide();
            MenuCrearEncuentro crearEncuentro = new MenuCrearEncuentro(index);
            crearEncuentro.StartPosition = FormStartPosition.CenterParent;
            crearEncuentro.ShowDialog();
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e, string busqueda)
        {
            panelContenedor.Controls.Clear();

            var encuentros = Logica.GetEncuentros(2, busqueda);

            foreach (var encuentro in encuentros)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(435, 25);
                p1.TabIndex = 0;

                Label l1 = new Label(); //ID del encuentro

                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.Size = new Size(60, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);
                l1.Text = "" + encuentro.IdEncuentro;

                Label l2 = new Label(); //Nombre del encuentro

                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.Size = new Size(312, 25);
                l2.AutoSize = false;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(60, 0);
                l2.Text = encuentro.Nombre;

                Label l4 = new Label(); //Fecha del encuentro

                l4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l4.TextAlign = ContentAlignment.MiddleCenter;
                l4.Size = new Size(85, 25);
                l4.BorderStyle = BorderStyle.FixedSingle;
                l4.BackColor = Color.FromArgb(255, 255, 248);
                l4.AutoSize = false;
                l4.Location = new Point(372, 0);
                l4.Text = encuentro.Fecha;

                Label l5 = new Label(); //Hora del encuentro

                l5.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l5.TextAlign = ContentAlignment.MiddleCenter;
                l5.Size = new Size(55, 25);
                l5.BorderStyle = BorderStyle.FixedSingle;
                l5.BackColor = Color.FromArgb(255, 255, 248);
                l5.AutoSize = false;
                l5.Location = new Point(457, 0);
                l5.Text = encuentro.Hora;

                Label l6 = new Label(); //Estado del evento

                l6.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l6.TextAlign = ContentAlignment.MiddleCenter;
                l6.Size = new Size(110, 25);
                l6.BorderStyle = BorderStyle.FixedSingle;
                l6.BackColor = Color.FromArgb(255, 255, 248);
                l6.AutoSize = false;
                l6.Location = new Point(512, 0);
                l6.Text = encuentro.Estado;

                PictureBox pic1 = new PictureBox(); //Boton eliminar

                pic1.BorderStyle = BorderStyle.FixedSingle;
                pic1.Size = new Size(12, 12);
                pic1.Location = new Point(634, 7);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Properties.Resources.cruz;
                pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, encuentro.IdEncuentro, p1); };

                PictureBox pic2 = new PictureBox(); //Boton modificar

                pic2.BorderStyle = BorderStyle.FixedSingle;
                pic2.Size = new Size(12, 12);
                pic2.Location = new Point(622, 7);
                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic2.Image = Properties.Resources.pluma;
                pic2.Click += (sender, EventArgs) => { Modify_Click(sender, EventArgs, encuentros.IndexOf(encuentro)); };

                panelContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                p1.Controls.Add(pic2);
                p1.Controls.Add(pic1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
                p1.Controls.Add(l4);
                p1.Controls.Add(l5);
                p1.Controls.Add(l6);
            }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblName.Text = "Name";
                    lblDate.Text = "Date";
                    lblHour.Text = "Hour";
                    lblState.Text = "State";
                    lblEncuentrosManagerTitle.Text = "Manage matchs";
                    lblEncuentrosManagerTitle.Location = new Point(220, 14);
                    break;
                case "ES": //Español
                    lblName.Text = "Nombre";
                    lblDate.Text = "Fecha";
                    lblHour.Text = "Hora";
                    lblState.Text = "Estado";
                    lblEncuentrosManagerTitle.Text = "Administrar encuentros";
                    lblEncuentrosManagerTitle.Location = new Point(170, 14);
                    break;
            }
        }
    }
}
