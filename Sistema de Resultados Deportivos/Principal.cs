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
        private static Principal form = null;
        private delegate void EnableDelegate(int x);
        public Principal()
        {
            InitializeComponent();
            form = this;

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
            panelPublicidad1.Controls.Add(publicidad1);
            panelPublicidad2.Controls.Add(publicidad2);
            publicidad1.Show();
            publicidad2.Show();

            SetTheme();
            PrincipalColor();
            SetIdioma();
        }

        private void PrincipalColor() //Establece el color de fondo del formulario Principal
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                {
                    if (AjustesDeUsuario.darkTheme == true)
                    {
                        c.BackColor = Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    } else
                    {
                        c.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    }
                }
            }
        }

        private void CargarCategorias()
        {
            this.panelCategorias.Controls.Clear();
            int x = 0;
            var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
            foreach (var c in categorias)
            {
                Button b1 = new Button(); //Crea el boton que permitira acceder a la categoria

                b1.Dock = System.Windows.Forms.DockStyle.Top;
                b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b1.Location = new System.Drawing.Point(0, 0);
                b1.Name = "btnMore";
                b1.Size = new System.Drawing.Size(229, 58);
                b1.TabIndex = 0;
                b1.Text = c.nombreCategoria;
                b1.UseVisualStyleBackColor = false;
                b1.Click += (sender, EventArgs) => {b1_Click(sender, EventArgs, c.nombreCategoria); };

                switch (AjustesDeUsuario.darkTheme)
                {
                    case false: //Tema claro
                        b1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        b1.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                        b1.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                        b1.ForeColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                        break;
                    case true: //Tema oscuro
                        b1.BackColor = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                        b1.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                        b1.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                        b1.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                        break;
                }

                this.panelCategorias.Controls.Add(b1);

                if (x < 580)
                {
                    x += 58;
                }
                else { x = 602; }
            }
            this.panelCategorias.Size = new System.Drawing.Size(214, x);
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

        private void log(int x)
        {
            if (x == 1)
            {
                btnLogout.Visible = true;
                btnUser.Visible = true;
                btnLogin.Visible = false;
                panelOptions.Size = new System.Drawing.Size(140, 160);
            } else if (x == 0)
            {
                btnLogout.Visible = false;
                btnUser.Visible = false;
                btnLogin.Visible = true;
                panelOptions.Size = new System.Drawing.Size(140, 120);
                Program.logout();
            }
        }

        private void openEncuentros()
        {
            this.panelChico.Controls.Clear();
            Form encu = new Frm_Encuentros();
            encu.TopLevel = false;
            this.panelChico.Controls.Add(encu);
            encu.Show();
        }

        private void openEventos()
        {
            this.panelChico.Controls.Clear();
            Form eve = new Frm_Eventos();
            eve.TopLevel = false;
            this.panelChico.Controls.Add(eve);
            eve.Show();
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
            toggleSubMenu(1);
            Form login = new Login();
            login.TopLevel = false;
            login.TopMost = true;
            this.panelLogin.Controls.Add(login);
            panelLogin.Show();
            login.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            log(0);
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

        private void InfoEquipos_Jugadores(int type)
        {
            Form info = new Frm_EquiposJugadores(type);
            info.TopLevel = false;
            info.TopMost = true;
            this.panelSettings.Controls.Add(info);
            info.Show();
            panelSettings.Show();
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

        private void btnUser_Click(object sender, EventArgs e)
        {
            try
            {
                panelChico.Controls.Clear();
                toggleSubMenu(1);
                Form us = new Users();
                us.TopLevel = false;
                this.panelChico.Controls.Add(us);
                us.Show();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void AlterPrincipal(int x, int y, int z)
        {
            switch (y)
            {
                case 0:
                    if (form != null)
                    {
                        form.ChangeAds(x);
                    }
                    break;
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                        form.CargarCategorias();
                        form.PrincipalColor();
                    }
                    break;
                case 2:
                    if (form != null)
                    {
                        form.SetIdioma();
                    }
                    break;
                case 3:
                    if (form != null)
                    {
                        form.log(x);
                    }
                    break;
                case 4:
                    if (form != null)
                    {
                        form.ToastClicked(x, z);
                    }
                    break;
                case 5:
                    if (form != null)
                    {
                        form.openEncuentros();
                    }
                    break;
                case 6:
                    if (form != null)
                    {
                        form.InfoEquipos_Jugadores(x);
                    }
                    break;
                case 7:
                    if (form != null)
                    {
                        form.openEventos();
                    }
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (AjustesDeUsuario.tray == true)
            {
                toggleSubMenu(1);
                this.Hide();
                notifyIcon.Visible = true;
            } else
            {
                Application.Exit();
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(Control.MousePosition);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeAds(int x)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(ChangeAds), new object[] { x });
                return;
            }

            switch (x)
            {
                case 0:
                    panelPublicidad1.Show();
                    panelPublicidad2.Show();
                    break;
                case 1:
                    panelPublicidad1.Hide();
                    panelPublicidad2.Hide();
                    break;
            }
        }

        private void btnNoticias_Click(object sender, EventArgs e)
        {
            //foreach (var n in Program.noticias)
            //{
            //    MessageBox.Show(n.header);
            //}
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.panelChico.Controls.Clear();
            Form buscador = new BuscadorDeEncuentros();
            buscador.TopLevel = false;
            this.panelChico.Controls.Add(buscador);
            buscador.Show();
        }
        
        private void ToastClicked(int type, int id)
        {
            if (notifyIcon.Visible == true)
            {
                this.Show();
                notifyIcon.Visible = false;
            }
            MessageBox.Show("It works! :D");
        }
    }
}
