using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SRD_BackOffice
{
    public partial class MenuManageUsers : Form
    {
        public MenuManageUsers()
        {
            InitializeComponent();
            SetIdioma();
            CargarUsuarios();

            btnBuscar.Click += (sender, EventArgs) => { btnBuscar_Click(sender, EventArgs, txtBuscador.Text); };
        }

        private void CargarUsuarios()
        {
            int x = 0;
            var usuarios = Logica.DeserializeUsers(Logica.GetJson("DinamicJson\\Usuarios.json"));
            int count = usuarios.Count();
            foreach (var usuario in usuarios)
            {
                if (usuario.nivelPermisos < 3)
                {
                    try
                    {
                        if (x >= count - 15)
                        {
                            Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                            p1.Dock = DockStyle.Top;
                            p1.BorderStyle = BorderStyle.None;
                            p1.BackColor = Color.FromArgb(255, 255, 248);
                            p1.Size = new Size(420, 25);
                            p1.TabIndex = 0;

                            TextBox l1 = new TextBox(); //Nombre de usuario

                            l1.ReadOnly = true;
                            l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            l1.Text = $"{usuario.nombreUsuario}";
                            l1.TextAlign = HorizontalAlignment.Center;
                            l1.Size = new Size(100, 25);
                            l1.BackColor = Color.FromArgb(255, 255, 248);
                            l1.AutoSize = false;
                            l1.BorderStyle = BorderStyle.FixedSingle;
                            l1.Location = new Point(0, 0);
                            l1.TabIndex = 3;

                            TextBox l2 = new TextBox(); //Email de usuario

                            l2.ReadOnly = true;
                            l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            l2.Text = $"{usuario.email}";
                            l2.TextAlign = HorizontalAlignment.Center;
                            l2.Size = new Size(195, 25);
                            l2.BackColor = Color.FromArgb(255, 255, 248);
                            l2.AutoSize = false;
                            l2.BorderStyle = BorderStyle.FixedSingle;
                            l2.Location = new Point(100, 0);
                            l2.TabIndex = 3;

                            TextBox l3 = new TextBox(); //Nivel de permisos de usuario

                            l3.ReadOnly = true;
                            l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                            if (usuario.nivelPermisos == 2)
                            {
                                l3.Text = "Si";
                            }
                            else
                            {
                                l3.Text = "No";
                            }
                            l3.TextAlign = HorizontalAlignment.Center;
                            l3.Size = new Size(100, 25);
                            l3.BackColor = Color.FromArgb(255, 255, 248);
                            l3.BorderStyle = BorderStyle.FixedSingle;
                            l3.AutoSize = false;
                            l3.Location = new Point(295, 0);
                            l3.TabIndex = 3;

                            PictureBox pic1 = new PictureBox();

                            pic1.BorderStyle = BorderStyle.FixedSingle;
                            pic1.Size = new Size(10, 10);
                            pic1.Location = new Point(403, 7);
                            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic1.Image = WindowsFormsApp2.Properties.Resources.cruz;
                            pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, usuarios, usuario, p1); };

                            this.panelUsersContenedor.Controls.Add(p1); //Agrega los controles al panelEncuentros
                            p1.Controls.Add(pic1);
                            p1.Controls.Add(l1);
                            p1.Controls.Add(l2);
                            p1.Controls.Add(l3);
                        }
                        x++;
                    } catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void btnSportsManagerCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e, List<Usuario> list, Usuario u, Panel p)
        {
            DialogResult dialogResult1 = MessageBox.Show("Do you want to ban this user?", "Ban user", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you sure?", "BAN user", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    list.Remove(u);
                    Logica.SerializeUsers(list);
                    p.Dispose();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e, string busqueda)
        {
            panelUsersContenedor.Controls.Clear();

            var usuarios = Logica.DeserializeUsers(Logica.GetJson("DinamicJson\\Usuarios.json"));
            int count = 0;

            foreach (var usuario in usuarios)
            {
                if ((usuario.nombreUsuario.Contains(busqueda) || usuario.email.Contains(busqueda) || (busqueda == "Premium" && usuario.nivelPermisos == 2)) && usuario.nivelPermisos < 3)
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(420, 25);
                    p1.TabIndex = 0;

                    TextBox l1 = new TextBox(); //Nombre de usuario

                    l1.ReadOnly = true;
                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.Text = $"{usuario.nombreUsuario}";
                    l1.TextAlign = HorizontalAlignment.Center;
                    l1.Size = new Size(100, 25);
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.AutoSize = false;
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.TabIndex = 3;

                    TextBox l2 = new TextBox(); //Email de usuario

                    l2.ReadOnly = true;
                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l2.Text = $"{usuario.email}";
                    l2.TextAlign = HorizontalAlignment.Center;
                    l2.Size = new Size(195, 25);
                    l2.BackColor = Color.FromArgb(255, 255, 248);
                    l2.AutoSize = false;
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(100, 0);
                    l2.TabIndex = 3;

                    TextBox l3 = new TextBox(); //Nivel de permisos de usuario

                    l3.ReadOnly = true;
                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    if (usuario.nivelPermisos == 2)
                    {
                        l3.Text = "Si";
                    }
                    else
                    {
                        l3.Text = "No";
                    }
                    l3.TextAlign = HorizontalAlignment.Center;
                    l3.Size = new Size(100, 25);
                    l3.BackColor = Color.FromArgb(255, 255, 248);
                    l3.BorderStyle = BorderStyle.FixedSingle;
                    l3.AutoSize = false;
                    l3.Location = new Point(295, 0);
                    l3.TabIndex = 3;

                    PictureBox pic1 = new PictureBox();

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(10, 10);
                    pic1.Location = new Point(403, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = WindowsFormsApp2.Properties.Resources.cruz;
                    pic1.Click += (s, EventArgs) => { Delete_Click(sender, EventArgs, usuarios, usuario, p1); };

                    this.panelUsersContenedor.Controls.Add(p1); //Agrega los controles al panelEncuentros
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l2);
                    p1.Controls.Add(l3);
                }
            }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    break;
                case "ES": //Español
                    break;
            }
        }
    }
}
