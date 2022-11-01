namespace SRD_BackOffice
{
    public partial class MenuManageSports : Form
    {
        public MenuManageSports()
        {
            InitializeComponent();
            SetIdioma();
            CargarCategorias();
            CargarDeportes();

            btnBuscar.Click += (sender, EventArgs) => { btnBuscar_Click(sender, EventArgs, txtBuscador.Text); };
        }

        private void CargarCategorias()
        {
            int x = 0;
            var categorias = Logica.GetCategorias(1, null);
            int count = categorias.Count;
            foreach (var categoria in categorias)
            {
                if (x >= count - 15)
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(185, 25);
                    p1.TabIndex = 0;

                    TextBox l1 = new TextBox(); //Nombre de la categoria

                    l1.ReadOnly = true;
                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.Text = $"{categoria.nombreCategoria}";
                    l1.TextAlign = HorizontalAlignment.Center;
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.Size = new Size(142, 25);
                    l1.AutoSize = false;
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.TabIndex = 3;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(154, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { DeleteCategory_Click(sender, EventArgs, categoria.idCategoria, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(142, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { ModifyCategory_Click(sender, EventArgs, categoria.idCategoria); };

                    panelCategoriasContenedor.Controls.Add(p1); //Agrega los controles al panelCategoriasContenedor
                    p1.Controls.Add(pic2);
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                }
                x++;
            }
        }

        private void CargarDeportes()
        {
            int x = 0;
            var deportes = Logica.GetDeportes(1, null);
            int count = deportes.Count;
            foreach (var deporte in deportes)
            {
                if (x >= count - 15)
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(435, 25);
                    p1.TabIndex = 0;

                    TextBox l1 = new TextBox(); //Nombre del deporte

                    l1.ReadOnly = true;
                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.Text = $"{deporte.NombreDeporte}";
                    l1.TextAlign = HorizontalAlignment.Center;
                    l1.Size = new Size(100, 25);
                    l1.AutoSize = false;
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.TabIndex = 3;

                    TextBox l2 = new TextBox(); //Categoria del deporte

                    l2.ReadOnly = true;
                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l2.Text = $"{deporte.NombreCategoria}";
                    l2.TextAlign = HorizontalAlignment.Center;
                    l2.Size = new Size(195, 25);
                    l2.AutoSize = false;
                    l2.BackColor = Color.FromArgb(255, 255, 248);
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(100, 0);
                    l2.TabIndex = 3;

                    TextBox l3 = new TextBox(); //Si es popular o no

                    l3.ReadOnly = true;
                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    if (deporte.Destacado == true)
                    {
                        l3.Text = "Si";
                    }
                    else
                    {
                        l3.Text = "No";
                    }
                    l3.TextAlign = HorizontalAlignment.Center;
                    l3.Size = new Size(98, 25);
                    l3.BorderStyle = BorderStyle.FixedSingle;
                    l3.BackColor = Color.FromArgb(255, 255, 248);
                    l3.AutoSize = false;
                    l3.Location = new Point(295, 0);
                    l3.TabIndex = 3;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(405, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { DeleteSport_Click(sender, EventArgs, deporte.IdDeporte, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(393, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { ModifySport_Click(sender, EventArgs, deporte.IdDeporte); };

                    panelDeportesContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
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
            Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            Close();
        }

        private void DeleteCategory_Click(object sender, EventArgs e, int id, Panel p)
        {
            DialogResult dialogResult1 = MessageBox.Show("Do you really want to delete this?", "Delete category", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you really sure?", "DELETE category", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    try
                    {
                        Logica.Delete("Categorias", "IdCategoria", id + "");
                        p.Dispose();
                        MessageBox.Show("Successfully eliminated");
                    }
                    catch { MessageBox.Show("Error"); }
                }
            }
        }

        private void DeleteSport_Click(object sender, EventArgs e, int id, Panel p)
        {
            DialogResult dialogResult1 = MessageBox.Show("Do you really want to delete this?", "Delete sport", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you really sure?", "DELETE sport", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    try
                    {
                        Logica.Delete("Deportes", "IdDeporte", id + "");
                        p.Dispose();
                        MessageBox.Show("Successfully eliminated");
                    }
                    catch { MessageBox.Show("Error"); }
                }
            }
        }

        private void ModifySport_Click(object sender, EventArgs e, int index)
        {
            Hide();
            MenuCrearDeporte crearDeporte = new MenuCrearDeporte(index);
            crearDeporte.StartPosition = FormStartPosition.CenterParent;
            crearDeporte.ShowDialog();
            Close();
        }

        private void ModifyCategory_Click(object sender, EventArgs e, int index)
        {
            Hide();
            MenuCrearCategoria crearCategoria = new MenuCrearCategoria(index);
            crearCategoria.StartPosition = FormStartPosition.CenterParent;
            crearCategoria.ShowDialog();
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e, string busqueda)
        {
            panelCategoriasContenedor.Controls.Clear();
            panelDeportesContenedor.Controls.Clear();

            var deportes = Logica.GetDeportes(2, busqueda);
            int count = 0;

            /* Deportes */
            foreach (var deporte in deportes)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(435, 25);
                p1.TabIndex = 0;

                TextBox l1 = new TextBox(); //Nombre del deporte

                l1.ReadOnly = true;
                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = $"{deporte.NombreDeporte}";
                l1.TextAlign = HorizontalAlignment.Center;
                l1.Size = new Size(100, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);
                l1.TabIndex = 3;

                TextBox l2 = new TextBox(); //Categoria del deporte

                l2.ReadOnly = true;
                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.Text = $"{deporte.NombreCategoria}";
                l2.TextAlign = HorizontalAlignment.Center;
                l2.Size = new Size(193, 25);
                l2.AutoSize = false;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(100, 0);
                l2.TabIndex = 3;

                TextBox l3 = new TextBox(); //Si es popular o no

                l3.ReadOnly = true;
                l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                if (deporte.Destacado == true)
                {
                    l3.Text = "Si";
                }
                else
                {
                    l3.Text = "No";
                }
                l3.TextAlign = HorizontalAlignment.Center;
                l3.Size = new Size(100, 25);
                l3.BorderStyle = BorderStyle.FixedSingle;
                l3.BackColor = Color.FromArgb(255, 255, 248);
                l3.AutoSize = false;
                l3.Location = new Point(293, 0);
                l3.TabIndex = 3;

                PictureBox pic1 = new PictureBox(); //Boton eliminar

                pic1.BorderStyle = BorderStyle.FixedSingle;
                pic1.Size = new Size(12, 12);
                pic1.Location = new Point(405, 7);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Properties.Resources.cruz;
                pic1.Click += (sender, EventArgs) => { DeleteSport_Click(sender, EventArgs, deporte.IdDeporte, p1); };

                PictureBox pic2 = new PictureBox(); //Boton modificar

                pic2.BorderStyle = BorderStyle.FixedSingle;
                pic2.Size = new Size(12, 12);
                pic2.Location = new Point(393, 7);
                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic2.Image = Properties.Resources.pluma;
                pic2.Click += (sender, EventArgs) => { ModifySport_Click(sender, EventArgs, deportes.IndexOf(deporte)); };

                panelDeportesContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                p1.Controls.Add(pic2);
                p1.Controls.Add(pic1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
                p1.Controls.Add(l3);
            }

            /* Categorias */

            var categorias = Logica.GetCategorias(2, busqueda);

            foreach (var categoria in categorias)
            {
                Panel p2 = new Panel(); //Crea el panel donde apareceran los controles

                p2.Dock = DockStyle.Top;
                p2.BorderStyle = BorderStyle.None;
                p2.BackColor = Color.FromArgb(255, 255, 248);
                p2.Size = new Size(185, 25);
                p2.TabIndex = 0;

                TextBox l4 = new TextBox(); //Nombre de la categoria

                l4.ReadOnly = true;
                l4.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l4.Text = $"{categoria.nombreCategoria}";
                l4.TextAlign = HorizontalAlignment.Center;
                l4.BackColor = Color.FromArgb(255, 255, 248);
                l4.Size = new Size(142, 25);
                l4.AutoSize = false;
                l4.BorderStyle = BorderStyle.FixedSingle;
                l4.Location = new Point(0, 0);
                l4.TabIndex = 3;

                PictureBox pic3 = new PictureBox(); //Boton eliminar

                pic3.BorderStyle = BorderStyle.FixedSingle;
                pic3.Size = new Size(12, 12);
                pic3.Location = new Point(154, 7);
                pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                pic3.Image = Properties.Resources.cruz;
                pic3.Click += (sender, EventArgs) => { DeleteCategory_Click(sender, EventArgs, categoria.idCategoria, p2); };

                PictureBox pic4 = new PictureBox(); //Boton modificar

                pic4.BorderStyle = BorderStyle.FixedSingle;
                pic4.Size = new Size(12, 12);
                pic4.Location = new Point(142, 7);
                pic4.SizeMode = PictureBoxSizeMode.StretchImage;
                pic4.Image = Properties.Resources.pluma;
                pic4.Click += (sender, EventArgs) => { ModifyCategory_Click(sender, EventArgs, categorias.IndexOf(categoria)); };

                panelCategoriasContenedor.Controls.Add(p2); //Agrega los controles al panelCategoriasContenedor
                p2.Controls.Add(pic3);
                p2.Controls.Add(pic4);
                p2.Controls.Add(l4);
            }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblSportsManagerTitle.Text = "Sports manager";
                    lblSportsManagerTitle.Location = new Point(169, 24);
                    label7.Text = "Name";
                    label7.Location = new Point(33, 5);
                    label6.Text = "Category";
                    label4.Text = "Categories";
                    lblCategories.Text = "Categories";
                    label1.Text = "Sports";
                    label1.Location = new Point(413, 120);
                    break;
                case "ES": //Español
                    lblSportsManagerTitle.Text = "Administrador de deportes";
                    lblSportsManagerTitle.Location = new Point(50, 24);
                    label7.Text = "Nombre";
                    label7.Location = new Point(27, 5);
                    label6.Text = "Categoría";
                    label4.Text = "Categorías";
                    lblCategories.Text = "Categorías";
                    label1.Text = "Deportes";
                    label1.Location = new Point(400, 120);
                    break;
            }
        }
    }
}
