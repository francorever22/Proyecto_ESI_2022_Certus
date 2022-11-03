namespace SRD_BackOffice
{
    public partial class MenuCrearDeportista : Form
    {
        bool modify = false;
        int index;

        public MenuCrearDeportista()
        {
            InitializeComponent();
            SetIdioma();

            cbxEstado.SelectedIndex = 0;
        }

        public MenuCrearDeportista(int index)
        {
            InitializeComponent();
            SetIdioma();

            var deportista = Logica.GetDeportistas(3, ""+index)[0];

            txtNombre.Text = deportista.Nombre;
            txtApellido.Text = deportista.Apellido;
            txtNacionalidad.Text = deportista.Nacionalidad;
            txtDescripcion.Text = deportista.Descripcion;
            cbxEstado.SelectedItem = deportista.EstadoJugador;

            this.index = index;
            modify = true;
            btnAddDeportista.Text = "Modify";
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
                try
                {
                    if (txtNombre.Text != "" && cbxEstado != null && txtApellido.Text != "" && txtNacionalidad.Text != "")
                    {
                        string Nombre = txtNombre.Text,
                               Apellido = txtApellido.Text,
                               Nacionalidad = txtNacionalidad.Text,
                               EstadoJugador = cbxEstado.Text,
                               Descripcion = txtDescripcion.Text;

                        Logica.InsertPersona(Nombre, Apellido, Nacionalidad);
                        Logica.InsertDeportista(Nombre, Apellido, Nacionalidad, EstadoJugador, Descripcion);
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("New athlete created correctly");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("Nuevo deportista creado correctamente");
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
                if (txtNombre.Text != "" && cbxEstado != null && txtApellido.Text != "" && txtNacionalidad.Text != "")
                {
                        DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify athlete", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        string Nombre = txtNombre.Text,
                               Apellido = txtApellido.Text,
                               Nacionalidad = txtNacionalidad.Text,
                               EstadoJugador = cbxEstado.Text,
                               Descripcion = txtDescripcion.Text;

                        Logica.UpdatePersona(index, Nombre, Apellido, Nacionalidad);
                        Logica.UpdateDeportista(index, Nombre, Apellido, Nacionalidad, EstadoJugador, Descripcion);
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("Athlete modified correctly");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("Deportista modificado correctamente");
                        }
                        Hide();
                        MenuManageAthletes manageAthletes = new MenuManageAthletes();
                        manageAthletes.StartPosition = FormStartPosition.CenterParent;
                        manageAthletes.ShowDialog();
                        Close();
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

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblTitle.Text = "Add athlete";
                    lblTitle.Location = new Point(191, 34);
                    lblName.Text = "Name";
                    lblSurname.Text = "Surname";
                    lblNationality.Text = "Nationality";
                    lblState.Text = "State";
                    lblDescription.Text = "Description";
                    btnAddDeportista.Text = "Add";
                    break;
                case "ES": //Español
                    lblTitle.Text = "Agregar deportista";
                    lblTitle.Location = new Point(160, 34);
                    lblName.Text = "Nombre";
                    lblSurname.Text = "Apellido";
                    lblNationality.Text = "Nacionalidad";
                    lblState.Text = "Estado";
                    lblDescription.Text = "Descripción";
                    btnAddDeportista.Text = "Agregar";
                    break;
            }
        }
    }
}
