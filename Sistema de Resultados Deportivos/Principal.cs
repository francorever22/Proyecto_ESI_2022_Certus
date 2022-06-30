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
            CargarCategorias();
            panelCategorias.Hide();
            panelOptions.Hide();
            panelLogin.Hide();
            panelSettings.Hide();

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

            SetIdioma();
        }

        private void CargarCategorias()
        {
            var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
            foreach (var c in categorias)
            {
                Button b1 = new Button(); //Crea el boton que permitira acceder a la categoria

                b1.BackColor = System.Drawing.SystemColors.Control;
                b1.Dock = System.Windows.Forms.DockStyle.Top;
                b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b1.Location = new System.Drawing.Point(0, 0);
                b1.Name = "btnMore";
                b1.Size = new System.Drawing.Size(229, 58);
                b1.TabIndex = 0;
                b1.Text = c.nombreCategoria;
                b1.UseVisualStyleBackColor = false;
                b1.Click += (sender, EventArgs) => {b1_Click(sender, EventArgs, c.nombreCategoria); };

                this.panelCategorias.Controls.Add(b1);
            }
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
                btnUser.Visible = true;
                btnLogin.Visible = false;
                panelOptions.Size = new System.Drawing.Size(140, 120);
            } else
            {
                btnLogout.Visible = false;
                btnUser.Visible = false;
                btnLogin.Visible = true;
                panelOptions.Size = new System.Drawing.Size(140, 80);
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
            toggleSubMenu(1);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            log();
            toggleSubMenu(1);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form settings = new Settings();
            settings.TopLevel = false;
            settings.TopMost = true;
            this.panelSettings.Controls.Add(settings);
            settings.Show();
            panelSettings.Show();

            toggleSubMenu(1);
        }

        private void b1_Click(object sender, EventArgs e, string cat)
        {
            panelChico.Controls.Clear();
            toggleSubMenu(0);
            Form cate = new Categorias(cat);
            cate.TopLevel = false;
            this.panelChico.Controls.Add(cate);
            cate.Show();
        }
    }
}
