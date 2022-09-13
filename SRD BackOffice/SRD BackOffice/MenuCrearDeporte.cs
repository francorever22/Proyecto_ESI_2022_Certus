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

            var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
            foreach (var c in categorias)
            {
                cbxSportCategory.Items.Add(c.nombreCategoria);
            }
        }

        public MenuCrearDeporte(int index)
        {
            InitializeComponent();
            SetIdioma();

            var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
            foreach (var c in categorias)
            {
                cbxSportCategory.Items.Add(c.nombreCategoria);
            }

            var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
            Deporte deporte = deportes[index];

            btnSportAdd.Text = "Modify";
            txtSportName.Text = deporte.nombreDeporte;
            cbxSportCategory.SelectedItem = deporte.categoriaDeporte;
            imgSportSelected.Image = deporte.imagenDeporte;
            tgbSportPopular.Checked = deporte.deportePopular;

            this.index = index;
            modify = true;
        }

        private void btnSportCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            this.Close();
        }

        private void btnSportAdd_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                bool exist = false;
                try
                {
                    if (txtSportName.Text != "" && cbxSportCategory != null && imagenCargada != null)
                    {
                        var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
                        foreach (var d in deportes)
                        {
                            if (d.nombreDeporte == txtSportName.Text)
                            {
                                exist = true;
                            }
                        }
                        if (exist == false)
                        {
                            Deporte deporte = new Deporte();
                            deporte.nombreDeporte = txtSportName.Text;
                            deporte.categoriaDeporte = cbxSportCategory.Text;
                            deporte.imagenDeporte = null;
                            // deporte.imagenDeporte = imagenCargada; Requiere dividir la imagen en un array de bytes para poder ser guardada
                            if (tgbSportPopular.Checked == true) { deporte.deportePopular = true; }
                            else { deporte.deportePopular = false; }

                            if (deportes != null)
                            {
                                deportes.Add(deporte);
                                Logica.SerializeDeportes(deportes);
                            }
                            else
                            {
                                List<Deporte> list = new List<Deporte>();
                                Logica.SerializeDeportes(list);
                            }
                            MessageBox.Show("New sport created correctly");
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
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            } else
            {
                if (txtSportName.Text != "" && imgSportSelected != null)
                {
                    var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
                    Deporte deporte = deportes[index];
                    if (!(txtSportName.Text == deporte.nombreDeporte &&
                        tgbSportPopular.Checked == deporte.deportePopular &&
                        imgSportSelected.Image == deporte.imagenDeporte &&
                        cbxSportCategory.SelectedItem == deporte.categoriaDeporte))
                    {
                        DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify sport", MessageBoxButtons.YesNo);
                        if (dialogResult1 == DialogResult.Yes)
                        {
                            deporte.nombreDeporte = txtSportName.Text;
                            deporte.deportePopular = tgbSportPopular.Checked;
                            //deporte.imagenDeporte = imgSportSelected.Image; //Temporal
                            deporte.categoriaDeporte = cbxSportCategory.Text;
                            deportes[index] = deporte;
                            Logica.SerializeDeportes(deportes);

                            this.Hide();
                            MenuManageSports manageSports = new MenuManageSports();
                            manageSports.StartPosition = FormStartPosition.CenterParent;
                            manageSports.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The entered data equals the previous one");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("La información ingresada es la misma que la anterior");
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
