using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

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
            this.Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            this.Close();
        }

        private void btnAddminAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddminEmail.Text != "" && txtAddminPassword.Text != "" && txtAddminUsername.Text != "" && txtConfirmPassword.Text != "")
                {
                    if (txtAddminPassword.Text == txtConfirmPassword.Text)
                    {
                        var usuarios = Logica.DeserializeUsers(Logica.GetJson("DinamicJson\\Usuarios.json"));
                        Usuario newAdmin = new Usuario();
                        newAdmin.nombreUsuario = txtAddminUsername.Text;
                        newAdmin.email = txtAddminEmail.Text;
                        newAdmin.contrasena = txtAddminPassword.Text;
                        newAdmin.nivelPermisos = 3;
                        newAdmin.numeroTelefono = null;
                        usuarios.Add(newAdmin);
                        Logica.SerializeUsers(usuarios);
                        MessageBox.Show("New administrator created correctly");
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
                    } else if (Program.language == "ES")
                    {
                        MessageBox.Show("Quedan espacios vacios por rellenar");
                    }
                }
            }
            catch
            {
                MessageBox.Show("There was an error in the process");
            }
        }
    }
}
