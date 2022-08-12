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
        private static Login form = null;
        bool registrarse;
        public Login()
        {
            InitializeComponent();
            form = this;
            SetIdioma();
            SetTheme();
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
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.Black;
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.LightGray;
                                    break;
                            }
                        }
                        break;
                    case "ES":
                        if (txtUsuario.Text == "Usuario")
                        {
                            txtUsuario.Text = "";
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.Black;
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.LightGray;
                                    break;
                            }
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
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.Black;
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.LightGray;
                                    break;
                            }
                        }
                        break;
                    case "ES":
                        if (txtUsuario.Text == "Usuario o email")
                        {
                            txtUsuario.Text = "";
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.Black;
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.LightGray;
                                    break;
                            }
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
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                    break;
                            }
                            break;
                        case "ES":
                            txtUsuario.Text = "Usuario";
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                    break;
                            }
                            break;
                    }
                } else
                {
                    switch (AjustesDeUsuario.language)
                    {
                        case "EN":
                            txtUsuario.Text = "User or email";
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                    break;
                            }
                            break;
                        case "ES":
                            txtUsuario.Text = "Usuario o email";
                            switch (AjustesDeUsuario.darkTheme)
                            {
                                case false:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                    break;
                                case true:
                                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Email")
            {
                txtCorreo.Text = "";
                switch (AjustesDeUsuario.darkTheme)
                {
                    case false:
                        txtCorreo.ForeColor = Color.Black;
                        break;
                    case true:
                        txtCorreo.ForeColor = Color.LightGray;
                        break;
                }
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Email";
                switch (AjustesDeUsuario.darkTheme)
                {
                    case false:
                        txtCorreo.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                        break;
                    case true:
                        txtCorreo.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                        break;
                }
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
                        switch (AjustesDeUsuario.darkTheme)
                        {
                            case false:
                                txtContraseña.ForeColor = Color.Black;
                                break;
                            case true:
                                txtContraseña.ForeColor = Color.LightGray;
                                break;
                        }
                        txtContraseña.UseSystemPasswordChar = true;
                    }
                    break;
                case "ES":
                    if (txtContraseña.Text == "Contraseña")
                    {
                        txtContraseña.Text = "";
                        switch (AjustesDeUsuario.darkTheme)
                        {
                            case false:
                                txtContraseña.ForeColor = Color.Black;
                                break;
                            case true:
                                txtContraseña.ForeColor = Color.LightGray;
                                break;
                        }
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
                        switch (AjustesDeUsuario.darkTheme)
                        {
                            case false:
                                txtContraseña.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                break;
                            case true:
                                txtContraseña.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                break;
                        }
                        txtContraseña.UseSystemPasswordChar = false;
                        break;
                    case "ES":
                        txtContraseña.Text = "Contraseña";
                        switch (AjustesDeUsuario.darkTheme)
                        {
                            case false:
                                txtContraseña.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                                break;
                            case true:
                                txtContraseña.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                                break;
                        }
                        txtContraseña.UseSystemPasswordChar = false;
                        break;
                }
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            bool exist = false;
            String msg = "";
            switch (registrarse)
            {
                case true:
                    try
                    {
                        if (txtCorreo.Text != "" && txtContraseña.Text != "" && txtUsuario.Text != "")
                        {
                            var usuarios = Logica.DeserializeUsers(Logica.GetJson("DinamicJson\\Usuarios.json"));
                            foreach (var u in usuarios)
                            {
                                if (u.nombreUsuario == txtUsuario.Text)
                                {
                                    exist = true;
                                    if (AjustesDeUsuario.language == "EN")
                                    {
                                        msg = "The user already exist";
                                    }
                                    else if (AjustesDeUsuario.language == "ES")
                                    {
                                        msg = "El usuario ya existe";
                                    }
                                }
                                if (u.email == txtCorreo.Text)
                                {
                                    exist = true;
                                    if (AjustesDeUsuario.language == "EN")
                                    {
                                        msg = "The email is already registered";
                                    }
                                    else if (AjustesDeUsuario.language == "ES")
                                    {
                                        msg = "El email ya esta registrado";
                                    }
                                }
                            }
                            if (exist == false)
                            {
                                Usuario newUser = new Usuario();
                                newUser.nombreUsuario = txtUsuario.Text;
                                newUser.email = txtCorreo.Text;
                                newUser.contrasena = txtContraseña.Text;
                                newUser.nivelPermisos = 1;
                                newUser.numeroTelefono = null;
                                usuarios.Add(newUser);
                                Logica.SerializeUsers(usuarios);
                                MessageBox.Show("New administrator created correctly");
                            } else
                            {
                                MessageBox.Show(msg);
                            }
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
                        Usuario uLog = new Usuario();
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
                                        uLog = usuario;
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
                                        uLog = usuario;
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
                            Principal.AlterPrincipal(1, 3, 0); //Make
                            Program.login(uLog);
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
                    txtContraseña.Text = "Password";
                }
                else if (AjustesDeUsuario.language == "ES")
                {
                    btnAcceder.Text = "Registrarse";
                    llbRegistrarse.Text = "Login";
                    txtUsuario.Text = "Usuario";
                    txtContraseña.Text = "Contraseña";
                }
                txtCorreo.Text = "Email";
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
                    txtContraseña.Text = "Password";
                } else if (AjustesDeUsuario.language == "ES")
                {
                    btnAcceder.Text = "Acceder";
                    llbRegistrarse.Text = "Registrarse";
                    txtUsuario.Text = "Usuario o email";
                    txtContraseña.Text = "Contraseña";
                }
            }
            switch (AjustesDeUsuario.darkTheme)
            {
                case false:
                    txtContraseña.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    break;
                case true:
                    txtContraseña.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    txtUsuario.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    break;
            }
            txtContraseña.UseSystemPasswordChar = false;
        }

        private bool EsEmail(String user, String value = "@")
        {
            return user.Contains(value);
        }

        public static void AlterLogin(int y)
        {
            switch (y)
            {
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                    }
                    break;
                case 2:
                    if (form != null)
                    {
                        form.SetIdioma();
                    }
                    break;
            }
        }
    }
}
