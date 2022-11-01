namespace SRD_BackOffice
{
    public partial class MenuAgregarAdmin : Form
    {
        public MenuAgregarAdmin()
        {
            InitializeComponent();
            SetIdioma();
        }

        private void btnAddminCerrar_Click(object sender, EventArgs e)
        {
            Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            Close();
        }

        private void btnAddminAdd_Click(object sender, EventArgs e)
        {
            String msg = "";
            if (txtAddminEmail.Text != "" && txtAddminPassword.Text != "" && txtAddminUsername.Text != "" && txtConfirmPassword.Text != "")
            {
                if (txtAddminPassword.Text == txtConfirmPassword.Text)
                {
                    try
                    {
                        string nombreUsuario = txtAddminUsername.Text,
                            email = txtAddminEmail.Text,
                            contraseña = Logica.EncriptarContraseña(txtAddminPassword.Text, "Certus_SRD");
                        int nivelPermisos = 3;
                        if (Logica.CheckIfExist("Usuarios", "Email", email) == 0 && 
                            Logica.CheckIfExist("Usuarios", "NombreUsuario", nombreUsuario) == 0)
                        {
                            Logica.InsertUsuario(email, nombreUsuario, contraseña, nivelPermisos);
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("New administrator created correctly");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("Nuevo administrador creado correctamente");
                            }
                        } else
                        {
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The user already exist");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("El usuario ya existe");
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
                    }
                }
                else
                {
                    MessageBox.Show("The passwords dosn't match");
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

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblAddminTitle.Text = "Add administrator";
                    lblAddminTitle.Location = new Point(68, 49);
                    lblAddminUsuario.Text = "Username";
                    lblAddminUsuario.Location = new Point(45, 156);
                    lblAddminEmail.Location = new Point(45, 237);
                    btnAddminAdd.Text = "Add";
                    lblAddminConstraseña.Text = "Password";
                    lblAddminConstraseña.Location = new Point(45, 317);
                    lblAddminConfirm.Text = "Repeat password";
                    lblAddminConfirm.Location = new Point(45, 398);
                    break;
                case "ES": //Español
                    lblAddminTitle.Text = "Agregar administrador";
                    lblAddminTitle.Location = new Point(27, 49);
                    lblAddminUsuario.Text = "Nombre de usuario";
                    lblAddminUsuario.Location = new Point(30, 157);
                    lblAddminEmail.Location = new Point(30, 237);
                    btnAddminAdd.Text = "Agregar";
                    lblAddminConstraseña.Text = "Contraseña";
                    lblAddminConstraseña.Location = new Point(30, 317);
                    lblAddminConfirm.Text = "Confirme la contraseña";
                    lblAddminConfirm.Location = new Point(30, 398);
                    break;
            }
        }
    }
}
