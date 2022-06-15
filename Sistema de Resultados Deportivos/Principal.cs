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
    public partial class Principal : Form
    {
        bool f0 = false, f1 = false; //Determinan si los sub menus son visibles
        public Principal()
        {
            InitializeComponent();
            this.SetBevel(false);
            panelCategorias.Hide();
            panelOptions.Hide();
            panelLogin.Hide();

            Form inicio = new BuscadorDeEncuentros();
            inicio.TopLevel = false;
            this.panelChico.Controls.Add(inicio);
            inicio.Show();

            Form publicidad1 = new APIPublicidad();
            Form publicidad2 = new APIPublicidad();
            publicidad1.TopLevel = false;
            publicidad2.TopLevel = false;
            this.panelPublicidad1.Controls.Add(publicidad1);
            this.panelPublicidad2.Controls.Add(publicidad2);
            publicidad1.Show();
            publicidad2.Show();
        }

        private void toggleSubMenu(int x) //Muestra o oculta los submenus
        {
            switch (x)
            {
                case 0: //panelCategorias
                    if (f0 == true)
                    {
                        panelCategorias.Hide();
                        f0 = false;
                    }
                    else
                    {
                        panelCategorias.Show();
                        f0 = true;
                    }
                    break;
                case 1: //panelOptions
                    if (f1 == true)
                    {
                        panelOptions.Hide();
                        f1 = false;
                    }
                    else
                    {
                        panelOptions.Show();
                        f1 = true;
                    }
                    break;
            }
        }

        private void log()
        {
            if (btnLogin.Visible == true)
            {
                btnLogout.Visible = true;
                btnSettings.Visible = true;
                btnUser.Visible = true;
                btnLogin.Visible = false;
                panelOptions.Size = new System.Drawing.Size(140, 120);
            } else
            {
                btnLogout.Visible = false;
                btnSettings.Visible = false;
                btnUser.Visible = false;
                btnLogin.Visible = true;
                panelOptions.Size = new System.Drawing.Size(140, 40);
            }
            Form login = new Login();
            login.TopLevel = false;
            login.TopMost = true;
            this.panelLogin.Controls.Add(login);
            panelLogin.Show();
            login.Show();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            toggleSubMenu(0);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            toggleSubMenu(1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            log();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            log();
        }
    }
}
