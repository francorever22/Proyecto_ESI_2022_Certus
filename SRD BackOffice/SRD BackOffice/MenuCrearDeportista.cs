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

            var deportistas = Logica.DeserializeDeportistas(Logica.GetJson("DinamicJson\\Deportistas.json"));
            Deportista deportista = deportistas[index];

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
                try
                {
                    if (txtNombre.Text != "" && cbxEstado != null && txtApellido.Text != "" && txtNacionalidad.Text != "")
                    {
                        var deportistas = Logica.DeserializeDeportistas(Logica.GetJson("DinamicJson\\Deportistas.json"));
                        Deportista deportista = new Deportista();

                        Random r = new Random();

                        deportista.IdPersona = r.Next(0, 9999);
                        deportista.Nombre = txtNombre.Text;
                        deportista.Apellido = txtApellido.Text;
                        deportista.Nacionalidad = txtNacionalidad.Text;
                        deportista.EstadoJugador = cbxEstado.Text;
                        deportista.Descripcion = txtDescripcion.Text;

                        if (deportistas != null)
                        {
                            deportistas.Add(deportista);
                            Logica.SerializeDeportistas(deportistas);
                        }
                        else
                        {
                            List<Deportista> list = new List<Deportista>();
                            list.Add(deportista);
                            Logica.SerializeDeportistas(list);
                        }
                        MessageBox.Show("New athlete created correctly");
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
                    var deportistas = Logica.DeserializeDeportistas(Logica.GetJson("DinamicJson\\Deportistas.json"));
                    Deportista deportista = deportistas[index];

                    if (!(txtNombre.Text == deportista.Nombre &&
                        txtApellido.Text == deportista.Apellido &&
                        txtNacionalidad.Text == deportista.Nacionalidad &&
                        txtDescripcion.Text == deportista.Descripcion &&
                        cbxEstado.Text == deportista.EstadoJugador))
                    {
                        DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify athlete", MessageBoxButtons.YesNo);
                        if (dialogResult1 == DialogResult.Yes)
                        {
                            deportista.Nombre = txtNombre.Text;
                            deportista.Apellido = txtApellido.Text;
                            deportista.Nacionalidad = txtNacionalidad.Text;
                            deportista.EstadoJugador = cbxEstado.Text;
                            deportista.Descripcion = txtDescripcion.Text;

                            Logica.SerializeDeportistas(deportistas);

                            this.Hide();
                            MenuManageAthletes manageAthletes = new MenuManageAthletes();
                            manageAthletes.StartPosition = FormStartPosition.CenterParent;
                            manageAthletes.ShowDialog();
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
    }
}
