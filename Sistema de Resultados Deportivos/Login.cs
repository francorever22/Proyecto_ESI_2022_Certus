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
                            break;
                        case "ES":
                            txtUsuario.Text = "Usuario";
                            break;
                    }
                    txtUsuario.ForeColor = AjustesDeUsuario.foreColor;
                } else
                {
                    switch (AjustesDeUsuario.language)
                    {
                        case "EN":
                            txtUsuario.Text = "User or email";
                            break;
                        case "ES":
                            txtUsuario.Text = "Usuario o email";
                            break;
                    }
                    txtUsuario.ForeColor = AjustesDeUsuario.foreColor;
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
                txtCorreo.ForeColor = AjustesDeUsuario.foreColor;
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
                        break;
                    case "ES":
                        txtContraseña.Text = "Contraseña";
                        break;
                }
                txtContraseña.UseSystemPasswordChar = false;
                txtContraseña.ForeColor = AjustesDeUsuario.foreColor;
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
                            try
                            {
                                string nombreUsuario = txtUsuario.Text,
                                    email = txtCorreo.Text,
                                    contraseña = Logica.EncriptarContraseña(txtContraseña.Text, "Certus_SRD");
                                int nivelPermisos = 1;
                                if (Logica.CheckIfExist("Usuarios", "Email", email) == 0 &&
                                    Logica.CheckIfExist("Usuarios", "NombreUsuario", nombreUsuario) == 0)
                                {
                                    Logica.InsertUsuario(email, nombreUsuario, contraseña, nivelPermisos);
                                    if (AjustesDeUsuario.language == "EN")
                                    {
                                        MessageBox.Show("New user created correctly");
                                    }
                                    else if (AjustesDeUsuario.language == "ES")
                                    {
                                        MessageBox.Show("Nuevo usuario creado correctamente");
                                    }
                                    linklblRegistrarse_LinkClicked(sender, null);
                                }
                                else
                                {
                                    if (AjustesDeUsuario.language == "EN")
                                    {
                                        MessageBox.Show("The user already exist");
                                    }
                                    else if (AjustesDeUsuario.language == "ES")
                                    {
                                        MessageBox.Show("El usuario ya existe");
                                    }
                                }
                            }
                            catch
                            {
                                if (AjustesDeUsuario.language == "EN")
                                {
                                    MessageBox.Show("There was an error in the process");
                                }
                                else if (AjustesDeUsuario.language == "ES")
                                {
                                    MessageBox.Show("Hubo un error en el proceso");
                                }
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
                        string user = txtUsuario.Text;
                        string password = txtContraseña.Text;
                        if (EsEmail(user))
                        {
                            if (Logica.CheckIfExist("Usuarios", "Email", user) == 1)
                            {
                                var u = Logica.GetUsuarios(2, user)[0];
                                if (Logica.DesencriptarContraseña(u.contrasena, "Certus_SRD") == password)
                                {
                                    match = true;
                                    uLog = u;
                                } else
                                {
                                    if (AjustesDeUsuario.language == "EN")
                                    {
                                        MessageBox.Show("Incorrect password");
                                    }
                                    else if (AjustesDeUsuario.language == "ES")
                                    {
                                        MessageBox.Show("Contraseña incorrecta");
                                    }
                                }
                            } else
                            {
                                if (AjustesDeUsuario.language == "EN")
                                {
                                    MessageBox.Show("The user does no exist");
                                }
                                else if (AjustesDeUsuario.language == "ES")
                                {
                                    MessageBox.Show("El usuario no existe");
                                }
                            }
                        }
                        else
                        {
                            if (Logica.CheckIfExist("Usuarios", "NombreUsuario", user ) == 1)
                            {
                                var u = Logica.GetUsuarios(2, user)[0];
                                if (Logica.DesencriptarContraseña(u.contrasena, "Certus_SRD") == password)
                                {
                                    match = true;
                                    uLog = u;
                                }
                                else
                                {
                                    if (AjustesDeUsuario.language == "EN")
                                    {
                                        MessageBox.Show("Incorrect password");
                                    }
                                    else if (AjustesDeUsuario.language == "ES")
                                    {
                                        MessageBox.Show("Contraseña incorrecta");
                                    }
                                }
                            }
                            else
                            {
                                if (AjustesDeUsuario.language == "EN")
                                {
                                    MessageBox.Show("The user does no exist");
                                }
                                else if (AjustesDeUsuario.language == "ES")
                                {
                                    MessageBox.Show("El usuario no existe");
                                }
                            }
                        }

                        if (match == true)
                        {
                            Principal.AlterPrincipal(1, 3, 0);
                            Program.login(uLog);
                            Parent.Hide();
                            Close();
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
            Close();
        }

        private void customToggleButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linklblRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (registrarse == false)
            {
                txtCorreo.Show();
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
            txtContraseña.ForeColor = AjustesDeUsuario.foreColor;
            txtUsuario.ForeColor = AjustesDeUsuario.foreColor;
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

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            /* Paneles */
            BackColor = AjustesDeUsuario.panel;
            panel1.BackColor = AjustesDeUsuario.panel;
            /* Botones */
            btnAcceder.BackColor = AjustesDeUsuario.btnBack;
            btnAcceder.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnAcceder.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnCancelar.BackColor = AjustesDeUsuario.btnBack;
            btnCancelar.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnCancelar.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            /* Textos (Incluidos botones) */
            llbRegistrarse.LinkColor = AjustesDeUsuario.foreColor;
            txtContraseña.BackColor = AjustesDeUsuario.btnBack;
            txtContraseña.ForeColor = AjustesDeUsuario.foreColor;
            txtUsuario.BackColor = AjustesDeUsuario.btnBack;
            txtUsuario.ForeColor = AjustesDeUsuario.foreColor;
            label1.ForeColor = AjustesDeUsuario.foreColor;
            txtCorreo.BackColor = AjustesDeUsuario.btnBack;
            txtCorreo.ForeColor = AjustesDeUsuario.foreColor;
            btnAcceder.ForeColor = AjustesDeUsuario.foreColor;
            btnCancelar.ForeColor = AjustesDeUsuario.foreColor;
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    llbRegistrarse.Text = "Registrate";
                    btnCancelar.Text = "Cancel";
                    label1.Text = "Welcome";
                    txtUsuario.Text = "User or email";
                    txtContraseña.Text = "Password";
                    btnAcceder.Text = "Access";
                    break;
                case "ES": //Español
                    llbRegistrarse.Text = "Registrarse";
                    btnCancelar.Text = "Cancelar";
                    label1.Text = "Bienvenido";
                    txtUsuario.Text = "Usuario o email";
                    txtContraseña.Text = "Contraseña";
                    btnAcceder.Text = "Acceder";
                    break;
            }
        }
    }
}
