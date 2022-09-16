using System;
using System.Drawing;
using System.Windows.Forms;

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
                var usuarios = Logica.DeserializeUsers(Logica.GetJson("DinamicJson\\Usuarios.json"));
                if (usuarios != null)
                {
                    if (EsEmail(user))
                    {
                        foreach (var usuario in usuarios)
                        {
                            if (usuario.email == user && usuario.contrasena == password && usuario.nivelPermisos >= 3)
                            {
                                match = true;
                                if (usuario.nivelPermisos == 4) { boss = true; }
                            }
                        }
                    }
                    else
                    {
                        foreach (var usuario in usuarios)
                        {
                            if (usuario.nombreUsuario == user && usuario.contrasena == password && usuario.nivelPermisos >= 3)
                            {
                                match = true;
                                if (usuario.nivelPermisos == 4) { boss = true; }
                            }
                        }
                    }
                }

                if (match == true)
                {
                    if (boss == true) { Program.boss = true; }
                    this.Hide();
                    MainMenu main = new MainMenu();
                    main.StartPosition = FormStartPosition.CenterParent;
                    main.ShowDialog();
                    this.Close();
                } else
                {
                    MessageBox.Show("Access denied");
                }
            }
            catch
            {
                MessageBox.Show("Error");
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
