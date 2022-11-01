namespace SRD_BackOffice
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetIdioma();
        }
        
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            switch (Program.language)
            {
                case "EN":
                    if (txtUsuario.Text == "User or email")
                    {
                        txtUsuario.Text = "";
                        txtUsuario.ForeColor = Color.Black;
                    }
                    break;
                case "ES":
                    if (txtUsuario.Text == "Usuario o email")
                    {
                        txtUsuario.Text = "";
                        txtUsuario.ForeColor = Color.Black;
                    }
                    break;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                switch (Program.language)
                {
                    case "EN":
                        txtUsuario.Text = "User or email";
                        txtUsuario.ForeColor = Color.DimGray;
                        break;
                    case "ES":
                        txtUsuario.Text = "Usuario o email";
                        txtUsuario.ForeColor = Color.DimGray;
                        break;
                }
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            switch (Program.language)
            {
                case "EN":
                    if (txtContraseña.Text == "Password")
                    {
                        txtContraseña.Text = "";
                        txtContraseña.ForeColor = Color.Black;
                        txtContraseña.UseSystemPasswordChar = true;
                    }
                    break;
                case "ES":
                    if (txtContraseña.Text == "Contraseña")
                    {
                        txtContraseña.Text = "";
                        txtContraseña.ForeColor = Color.Black;
                        txtContraseña.UseSystemPasswordChar = true;
                    }
                    break;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                switch (Program.language)
                {
                    case "EN":
                        txtContraseña.Text = "Password";
                        txtContraseña.ForeColor = Color.DimGray;
                        txtContraseña.UseSystemPasswordChar = false;
                        break;
                    case "ES":
                        txtContraseña.Text = "Contraseña";
                        txtContraseña.ForeColor = Color.DimGray;
                        txtContraseña.UseSystemPasswordChar = false;
                        break;
                }
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                bool match = false, boss = false;
                String user = txtUsuario.Text;
                String password = txtContraseña.Text;
                if (EsEmail(user))
                {
                    if (Logica.CheckIfExist("Usuarios", "Email", user) == 1)
                    {
                        var u = Logica.GetUsuarios(6, user)[0];
                        if (Logica.DesencriptarContraseña(u.contrasena, "Certus_SRD") == password)
                        {
                            match = true;
                            if (u.nivelPermisos == 4) { boss = true; }
                        }
                    }
                }
                else
                {
                    if (Logica.CheckIfExist("Usuarios", "NombreUsuario", user) == 1)
                    {
                        var u = Logica.GetUsuarios(6, user)[0];
                        if (Logica.DesencriptarContraseña(u.contrasena, "Certus_SRD") == password)
                        {
                            match = true;
                            if (u.nivelPermisos == 4) { boss = true; }
                        }
                    }
                }

                if (match == true)
                {
                    if (boss == true) { Program.boss = true; }
                    Hide();
                    MainMenu main = new MainMenu();
                    main.StartPosition = FormStartPosition.CenterParent;
                    main.ShowDialog();
                    Close();
                } else
                {
                    MessageBox.Show("Access denied");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        bool EsEmail(String user, String value = "@")
        {
            return user.Contains(value);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    btnCancelar.Text = "Cancel";
                    label1.Text = "Welcome";
                    label1.Location = new Point(239, 19);
                    txtUsuario.Text = "User or email";
                    txtContraseña.Text = "Password";
                    btnAcceder.Text = "Log in";
                    break;
                case "ES": //Español
                    btnCancelar.Text = "Cancelar";
                    label1.Text = "Bienvenido";
                    label1.Location = new Point(227, 19);
                    txtUsuario.Text = "Usuario o email";
                    txtContraseña.Text = "Contraseña";
                    btnAcceder.Text = "Acceder";
                    break;
            }
        }
    }
}
