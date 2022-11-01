namespace SRD_BackOffice
{
    public partial class MenuCrearDeporte : Form
    {
        Bitmap imagenCargada = null;
        bool modify = false;
        int index;

        public MenuCrearDeporte()
        {
            InitializeComponent();
            SetIdioma();

            var categorias = Logica.GetCategorias(1, null);
            foreach (var c in categorias)
            {
                cbxSportCategory.Items.Add(c.nombreCategoria);
            }
        }

        public MenuCrearDeporte(int index)
        {
            InitializeComponent();
            SetIdioma();

            var categorias = Logica.GetCategorias(1, null);
            foreach (var c in categorias)
            {
                cbxSportCategory.Items.Add(c.nombreCategoria);
            }

            var deporte = Logica.GetDeportes(5, ""+index)[0];

            btnSportAdd.Text = "Modify";
            txtSportName.Text = deporte.NombreDeporte;
            cbxSportCategory.SelectedItem = deporte.NombreCategoria;
            imgSportSelected.Image = deporte.ImagenDeporte;
            tgbSportPopular.Checked = deporte.Destacado;

            this.index = index;
            modify = true;
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
                if (txtSportName.Text != "" && cbxSportCategory != null && imagenCargada != null)
                {
                    string nombreDeporte = txtSportName.Text,
                           categoriaDeporte = cbxSportCategory.Text;
                    bool destacado = tgbSportPopular.Checked;
                    Bitmap imagenDeporte = imagenCargada;
                    int idCategoria = Logica.GetCategorias(3, categoriaDeporte)[0].idCategoria,
                        idDeporte;
                    if (Logica.CheckIfExist("Deportes", "NombreDeporte", nombreDeporte) == 0)
                    {
                        try
                        {
                            Logica.InsertDeporte(nombreDeporte, null, destacado);
                            idDeporte = Logica.GetDeportes(4, null)[0].IdDeporte;
                            Logica.InsertDeporteCategorizado(idDeporte, idCategoria, nombreDeporte, categoriaDeporte, null, destacado);
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("New sport created correctly");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("Nuevo deporte creado correactamente");
                            }
                        }
                        catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                    }
                    else
                    {
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The sport already exist");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("El deporte ya existe");
                        }
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
            } else
            {
                if (txtSportName.Text != "" && imgSportSelected != null)
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify sport", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        string nombreDeporte = txtSportName.Text,
                               categoriaDeporte = cbxSportCategory.Text;
                        bool destacado = tgbSportPopular.Checked;
                        Bitmap imagenDeporte = imagenCargada;
                        int idCategoria = Logica.GetCategorias(3, categoriaDeporte)[0].idCategoria,
                            idDeporte;
                        if (Logica.CheckIfExist("Deportes", "NombreDeporte", nombreDeporte) == 0)
                        {
                            try
                            {
                                Logica.UpdateDeporte(index, nombreDeporte, null, destacado);
                                Logica.UpdateDeporteCategorizado(index, idCategoria, nombreDeporte, categoriaDeporte, null, destacado);
                                if (Program.language == "EN")
                                {
                                    MessageBox.Show("Sport modified correctly");
                                }
                                else if (Program.language == "ES")
                                {
                                    MessageBox.Show("Deporte modificado correactamente");
                                }
                                Hide();
                                MenuManageSports manageSports = new MenuManageSports();
                                manageSports.StartPosition = FormStartPosition.CenterParent;
                                manageSports.ShowDialog();
                                Close();
                            }
                            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                        }
                        else
                        {
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The sport already exist");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("El deporte ya existe");
                            }
                        }
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
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    imagenCargada = new Bitmap(open.FileName);
                    int wid = imagenCargada.Width;
                    int hei = imagenCargada.Height;
                    if (wid == 150 || hei == 150)
                    {
                        imgSportSelected.Image = imagenCargada;
                    }
                    else
                    {
                        imagenCargada = null;
                        imgSportSelected.Image = null;
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

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblSportTitle.Text = "Add sport";
                    lblSportTitle.Location = new Point(146, 25);
                    lblSportCategory.Text = "Select sport category";
                    lblSportCategory.Location = new Point(25, 173);
                    lblSportName.Text = "Add sport name";
                    lblSportName.Location = new Point(25, 114);
                    btnSelectImage.Text = "Select image";
                    lblSportPopular.Text = "Is it popular?";
                    lblSportImage.Text = "Add an image to represent the sport";
                    lblSportImage.Location = new Point(25, 247);
                    btnSportAdd.Text = "Add";
                    break;
                case "ES": //Español
                    lblSportTitle.Text = "Agregar deporte";
                    lblSportTitle.Location = new Point(60, 25);
                    lblSportCategory.Text = "Seleccione la categoría \ndel deporte";
                    lblSportCategory.Location = new Point(20, 165);
                    lblSportName.Text = "Agregué un nombre \npara el deporte";
                    lblSportName.Location = new Point(20, 114);
                    btnSelectImage.Text = "Seleccione una imagen";
                    lblSportPopular.Text = "Es popular?";
                    lblSportImage.Text = "Agregué una imagen para representar \nal deporte";
                    lblSportImage.Location = new Point(20, 240);
                    btnSportAdd.Text = "Agregar";
                    break;
            }
        }
    }
}
