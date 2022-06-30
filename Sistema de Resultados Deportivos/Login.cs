using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    public partial class Login : Form
    {
        bool registrarse;
        public Login()
        {
            InitializeComponent();
            SetIdioma();
            txtCorreo.Hide();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (registrarse == true)
            {
                switch (AjustesDeUsuario.language)
                {
                    case "EN":
                        if (txtUsuario.Text == "User")
                        {
                            txtUsuario.Text = "";
                            txtUsuario.ForeColor = Color.LightGray;
                        }
                        break;
                    case "ES":
                        if (txtUsuario.Text == "Usuario")
                        {
                            txtUsuario.Text = "";
                            txtUsuario.ForeColor = Color.LightGray;
                        }
                        break;
                }
            } else
            {
                switch (AjustesDeUsuario.language)
                {
                    case "EN":
                        if (txtUsuario.Text == "User or email")
                        {
                            txtUsuario.Text = "";
                            txtUsuario.ForeColor = Color.LightGray;
                        }
                        break;
                    case "ES":
                        if (txtUsuario.Text == "Usuario o email")
                        {
                            txtUsuario.Text = "";
                            txtUsuario.ForeColor = Color.LightGray;
                        }
                        break;
                }
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                if (registrarse == true)
                {
                    switch (AjustesDeUsuario.language)
                    {
                        case "EN":
                            txtUsuario.Text = "User";
                            txtUsuario.ForeColor = Color.DimGray;
                            break;
                        case "ES":
                            txtUsuario.Text = "Usuario";
                            txtUsuario.ForeColor = Color.DimGray;
                            break;
                    }
                } else
                {
                    switch (AjustesDeUsuario.language)
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
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            txtCorreo.Text = "";
            txtCorreo.ForeColor = Color.LightGray;
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Email";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN":
                    if (txtContraseña.Text == "Password")
                    {
                        txtContraseña.Text = "";
                        txtContraseña.ForeColor = Color.LightGray;
                        txtContraseña.UseSystemPasswordChar = true;
                    }
                    break;
                case "ES":
                    if (txtContraseña.Text == "Contraseña")
                    {
                        txtContraseña.Text = "";
                        txtContraseña.ForeColor = Color.LightGray;
                        txtContraseña.UseSystemPasswordChar = true;
                    }
                    break;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                switch (AjustesDeUsuario.language)
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
            switch (registrarse)
            {
                case true:
                    try
                    {
                        if (txtCorreo.Text != "" && txtContraseña.Text != "" && txtUsuario.Text != "")
                        {
                            var usuarios = Logica.DeserializeUsers(Logica.GetJson("DinamicJson\\Usuarios.json"));
                            Usuario newAdmin = new Usuario();
                            newAdmin.nombreUsuario = txtUsuario.Text;
                            newAdmin.email = txtCorreo.Text;
                            newAdmin.contrasena = txtContraseña.Text;
                            newAdmin.nivelPermisos = 1;
                            newAdmin.numeroTelefono = null;
                            usuarios.Add(newAdmin);
                            Logica.SerializeUsers(usuarios);
                            MessageBox.Show("New administrator created correctly");
                        }
                        else
                        {
                            if (AjustesDeUsuario.language == "EN")
                            {
                                MessageBox.Show("There are filds incomplete");
                            }
                            else if (AjustesDeUsuario.language == "ES")
                            {
                                MessageBox.Show("Quedan espacios vacios por rellenar");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("There was an error in the process");
                    }
                    break;
                case false:
                    try
                    {
                        bool match = false;
                        String user = txtUsuario.Text;
                        String password = txtContraseña.Text;
                        var usuarios = Logica.DeserializeUsers(Logica.GetJson("DinamicJson\\Usuarios.json"));
                        if (usuarios != null)
                        {
                            if (EsEmail(user))
                            {
                                foreach (var usuario in usuarios)
                                {
                                    if (usuario.email == user && usuario.contrasena == password)
                                    {
                                        match = true;
                                    }
                                }
                            }
                            else
                            {
                                foreach (var usuario in usuarios)
                                {
                                    if (usuario.nombreUsuario == user && usuario.contrasena == password)
                                    {
                                        match = true;
                                    }
                                }
                            }
                        }

                        if (match == true)
                        {
                            if (AjustesDeUsuario.language == "EN")
                            {
                                MessageBox.Show("Successfully logged in");
                            } else if (AjustesDeUsuario.language == "ES")
                            {
                                MessageBox.Show("Se a logeado existosamente");
                            }
                            Parent.Hide();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Access denied");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            this.Close();
        }

        private void customToggleButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linklblRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (registrarse == false)
            {
                txtCorreo.Show();
                label2.Hide();
                customtogglebutton1.Hide();
                registrarse = true;
                if (AjustesDeUsuario.language == "EN")
                {
                    btnAcceder.Text = "Registrate";
                    llbRegistrarse.Text = "Log in";
                    txtUsuario.Text = "User";
                }
                else if (AjustesDeUsuario.language == "ES")
                {
                    btnAcceder.Text = "Registrarse";
                    llbRegistrarse.Text = "Login";
                    txtUsuario.Text = "Usuario";
                }
            } else
            {
                txtCorreo.Hide();
                label2.Show();
                customtogglebutton1.Show();
                registrarse = false;
                if (AjustesDeUsuario.language == "EN")
                {
                    btnAcceder.Text = "Access";
                    llbRegistrarse.Text = "Registrate";
                    txtUsuario.Text = "User or email";
                } else if (AjustesDeUsuario.language == "ES")
                {
                    btnAcceder.Text = "Acceder";
                    llbRegistrarse.Text = "Registrarse";
                    txtUsuario.Text = "Usuario o email";
                }
            }
        }

        private bool EsEmail(String user, String value = "@")
        {
            return user.Contains(value);
        }
    }
}
