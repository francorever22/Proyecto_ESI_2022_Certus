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
            modify = true;

            var categoria = Logica.GetCategorias(4, ""+index)[0];

            txtCategoryName.Text = categoria.nombreCategoria;
            btnCategoryAgregar.Text = "Modify";
        }

        private void btnCategoryCerrar_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                Hide();
                MainMenu main = new MainMenu();
                main.StartPosition = FormStartPosition.CenterParent;
                main.ShowDialog();
                Close();
            } else
            {
                Hide();
                MenuManageSports manageSports = new MenuManageSports();
                manageSports.StartPosition = FormStartPosition.CenterParent;
                manageSports.ShowDialog();
                Close();
            }
        }

        private void btnCategoryAgregar_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                if (txtCategoryName.Text != "")
                {
                    try
                    {
                        string nombreCategoria = txtCategoryName.Text;
                        if (Logica.CheckIfExist("Categorias", "NombreCategoria", nombreCategoria) == 0)
                        {
                            Logica.InsertCategoria(nombreCategoria);
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The category was created correctly");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("La categoria a sido creada correctamente");
                            }
                        } else
                        {
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The category already exist");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("La categoria ya existe");
                            }
                        }
                    } catch
                    {
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("There was an error in the process");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("Hubo un error en el proceso");
                        }
                        return;
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
                if (txtCategoryName.Text != "")
                {
                        DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify category", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        try
                        {
                            string nombreCategoria = txtCategoryName.Text;
                            if (Logica.CheckIfExist("Categorias", "NombreCategoria", nombreCategoria) == 0)
                            {
                                Logica.UpdateCategoria(index, nombreCategoria);
                                if (Program.language == "EN")
                                {
                                    MessageBox.Show("The category was modified correctly");
                                }
                                else if (Program.language == "ES")
                                {
                                    MessageBox.Show("La categoria a sido modificada correctamente");
                                }
                                Hide();
                                MenuManageSports manageSports = new MenuManageSports();
                                manageSports.StartPosition = FormStartPosition.CenterParent;
                                manageSports.ShowDialog();
                                Close();
                            }
                            else
                            {
                                if (Program.language == "EN")
                                {
                                    MessageBox.Show("The category already exist");
                                }
                                else if (Program.language == "ES")
                                {
                                    MessageBox.Show("La categoria ya existe");
                                }
                            }
                        }
                        catch
                        {
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("There was an error in the process");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("Hubo un error en el proceso");
                            }
                            return;
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

        private void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblCategoryTitle.Text = "Add category";
                    lblCategoryTitle.Location = new Point(94, 33);
                    lblCategoryName.Text = "Add category name";
                    lblCategoryName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                    lblCategoryName.Location = new Point(19, 153);
                    txtCategoryName.Location = new Point(186, 152);
                    txtCategoryName.Size = new Size(250, 25);
                    btnCategoryAgregar.Text = "Add";
                    break;
                case "ES": //Español
                    lblCategoryTitle.Text = "Agregar categoría";
                    lblCategoryTitle.Location = new Point(53, 33);
                    lblCategoryName.Text = "Ingrese nombre de la categoría";
                    lblCategoryName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    lblCategoryName.Location = new Point(10, 154);
                    txtCategoryName.Location = new Point(220, 152);
                    txtCategoryName.Size = new Size(250, 25);
                    btnCategoryAgregar.Text = "Agregar";
                    break;
            }
        }
    }
}
