using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Sistema_de_Resultados_Deportivos
{
    public partial class Login : Form
    {
        private TextBox textBox1;
        public Login()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = DockStyle.None;
            this.textBox1.Name = "txtCorreo";
            this.textBox1.Text = "Ingrese su correo";
            this.textBox1.Size = new System.Drawing.Size(546, 20);
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            this.textBox1.BackColor = Color.FromArgb(15, 15, 15);
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;

            InitializeComponent();
           
        }

      
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if ( textBox1.Text == "Ingrese su correo" )
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.LightGray;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ingrese su correo";
                textBox1.ForeColor = Color.DimGray;
            }
        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario o email")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario o email";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if(txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
           }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            this.Close();
            
        }

        private void customCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linklblRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnAcceder.Text = "Registrarse";
           panel2.Controls.Add(this.textBox1);
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
