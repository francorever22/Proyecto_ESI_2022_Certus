namespace SRD_BackOffice
{
    public partial class MenuCrearCategoria : Form
    {
        bool modify = false;
        int index;
        public MenuCrearCategoria() //Agregar categoria
        {
            InitializeComponent();
            SetIdioma();
        }

        public MenuCrearCategoria(int index) //Modificar categoria
        {
            InitializeComponent();
            SetIdioma();

            this.index = index;
            var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
            Categoria categoria = categorias[index];

            txtCategoryName.Text = categoria.nombreCategoria;
            btnCategoryAgregar.Text = "Modify";
            modify = true;
        }

        private void btnCategoryCerrar_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                this.Hide();
                MainMenu main = new MainMenu();
                main.StartPosition = FormStartPosition.CenterParent;
                main.ShowDialog();
                this.Close();
            } else
            {
                this.Hide();
                MenuManageSports manageSports = new MenuManageSports();
                manageSports.StartPosition = FormStartPosition.CenterParent;
                manageSports.ShowDialog();
                this.Close();
            }
        }

        private void btnCategoryAgregar_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                bool exist = false;
                try
                {
                    if (txtCategoryName.Text != "")
                    {
                        var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
                        foreach (var c in categorias)
                        {
                            if (c.nombreCategoria == txtCategoryName.Text)
                            {
                                exist = true;
                            }
                        }
                        if (exist == false)
                        {
                            Categoria newCategory = new Categoria();
                            newCategory.nombreCategoria = txtCategoryName.Text;
                            if (categorias != null)
                            {
                                categorias.Add(newCategory);
                                Logica.SerializeCategorias(categorias);
                            }
                            else
                            {
                                List<Categoria> list = new List<Categoria>();
                                Logica.SerializeCategorias(list);
                            }
                            MessageBox.Show("New category created correctly");
                        }
                        else
                        {
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The category already exist");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("La categoría ya existe");
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
                    MessageBox.Show("There was an error in the process");
                }
            } else
            {
                if (txtCategoryName.Text != "")
                {
                    var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
                    Categoria categoria = categorias[index];
                    if (txtCategoryName.Text != categoria.nombreCategoria)
                    {
                        DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify category", MessageBoxButtons.YesNo);
                        if (dialogResult1 == DialogResult.Yes)
                        {
                            categoria.nombreCategoria = txtCategoryName.Text;
                            categorias[index] = categoria;
                            Logica.SerializeCategorias(categorias);

                            this.Hide();
                            MenuManageSports manageSports = new MenuManageSports();
                            manageSports.StartPosition = FormStartPosition.CenterParent;
                            manageSports.ShowDialog();
                            this.Close();
                        }
                    } else
                    {
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The entered name equals the previous one");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("El nombre ingresado es el mismo que el anterior");
                        }
                    }
                } else
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
    }
}
