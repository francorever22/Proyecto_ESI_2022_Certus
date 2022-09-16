using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SRD_BackOffice
{
    public partial class MenuManageAthletes : Form
    {
        public MenuManageAthletes()
        {
            InitializeComponent();
            SetIdioma();
            CargarDeportistas();

            btnBuscar.Click += (sender, EventArgs) => { btnBuscar_Click(sender, EventArgs, txtBuscador.Text); };
        }

        private void CargarDeportistas()
        {
            int x = 0;
            var deportistas = Logica.DeserializeDeportistas(Logica.GetJson("DinamicJson\\Deportistas.json"));
            int count = deportistas.Count;
            foreach (var deportista in deportistas)
            {
                if (x >= count - 15)
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(453, 25);
                    p1.TabIndex = 0;

                    Label l1 = new Label(); //ID del deportista

                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.Text = $"{deportista.IdPersona}";
                    l1.TextAlign = ContentAlignment.MiddleCenter;
                    l1.Size = new Size(70, 25);
                    l1.AutoSize = false;
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.TabIndex = 3;

                    Label l2 = new Label(); //Nombre del deportista

                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l2.Text = $"{deportista.Nombre} {deportista.Apellido}";
                    l2.TextAlign = ContentAlignment.MiddleCenter;
                    l2.Size = new Size(258, 25);
                    l2.AutoSize = false;
                    l2.BackColor = Color.FromArgb(255, 255, 248);
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(70, 0);
                    l2.TabIndex = 3;

                    Label l3 = new Label(); //Nacionalidad del deportista

                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l3.TextAlign = ContentAlignment.MiddleCenter;
                    l3.Text = $"{deportista.Nacionalidad}";
                    l3.Size = new Size(100, 25);
                    l3.BorderStyle = BorderStyle.FixedSingle;
                    l3.BackColor = Color.FromArgb(255, 255, 248);
                    l3.AutoSize = false;
                    l3.Location = new Point(328, 0);
                    l3.TabIndex = 3;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(440, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = WindowsFormsApp2.Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { Delete(sender, EventArgs, deportistas, deportista, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(428, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = WindowsFormsApp2.Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { Modify(sender, EventArgs, deportistas.IndexOf(deportista)); };

                    this.panelContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                    p1.Controls.Add(pic2);
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l2);
                    p1.Controls.Add(l3);
                }
                x++;
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

        private void Delete(object sender, EventArgs e, List<Deportista> list, Deportista d, Panel p)
        {
            DialogResult dialogResult1 = MessageBox.Show("Do you really want to delete this?", "Delete athlete", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you really sure?", "DELETE athlete", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    list.Remove(d);
                    Logica.SerializeDeportistas(list);
                    p.Dispose();
                }
            }
        }

        private void Modify(object sender, EventArgs e, int index)
        {
            this.Hide();
            MenuCrearDeportista crearDeportista = new MenuCrearDeportista(index);
            crearDeportista.StartPosition = FormStartPosition.CenterParent;
            crearDeportista.ShowDialog();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e, string busqueda)
        {
            panelContenedor.Controls.Clear();

            var deportistas = Logica.DeserializeDeportistas(Logica.GetJson("DinamicJson\\Deportistas.json"));
            int count = 0;

            foreach (var deportista in deportistas)
            {
                if (busqueda == Convert.ToString(deportista.IdPersona) || (deportista.Nombre+" "+deportista.Apellido).Contains(busqueda) || deportista.Nacionalidad.Contains(busqueda))
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(453, 25);
                    p1.TabIndex = 0;

                    Label l1 = new Label(); //ID del equipo

                    l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l1.Text = $"{deportista.IdPersona}";
                    l1.TextAlign = ContentAlignment.MiddleCenter;
                    l1.Size = new Size(70, 25);
                    l1.AutoSize = false;
                    l1.BackColor = Color.FromArgb(255, 255, 248);
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    l1.Location = new Point(0, 0);
                    l1.TabIndex = 3;

                    Label l2 = new Label(); //Nombre del equipo

                    l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l2.Text = $"{deportista.Nombre} {deportista.Apellido}";
                    l2.TextAlign = ContentAlignment.MiddleCenter;
                    l2.Size = new Size(258, 25);
                    l2.AutoSize = false;
                    l2.BackColor = Color.FromArgb(255, 255, 248);
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(70, 0);
                    l2.TabIndex = 3;

                    Label l3 = new Label(); //Pais de origen del equipo

                    l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                    l3.TextAlign = ContentAlignment.MiddleCenter;
                    l3.Text = $"{deportista.Nacionalidad}";
                    l3.Size = new Size(100, 25);
                    l3.BorderStyle = BorderStyle.FixedSingle;
                    l3.BackColor = Color.FromArgb(255, 255, 248);
                    l3.AutoSize = false;
                    l3.Location = new Point(328, 0);
                    l3.TabIndex = 3;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(440, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = WindowsFormsApp2.Properties.Resources.cruz;
                    pic1.Click += (s, EventArgs) => { Delete(sender, EventArgs, deportistas, deportista, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(428, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = WindowsFormsApp2.Properties.Resources.pluma;
                    pic2.Click += (s, EventArgs) => { Modify(sender, EventArgs, deportistas.IndexOf(deportista)); };

                    this.panelContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                    p1.Controls.Add(pic2);
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
                    lblName.Text = "Name";
                    lblNacionalidad.Text = "Nacionality";
                    lblTitle.Text = "Manage athletes";
                    lblTitle.Location = new Point(150, 20);
                    break;
                case "ES": //Español
                    lblName.Text = "Nombre";
                    lblNacionalidad.Text = "Nacionalidad";
                    lblTitle.Text = "Administrar deportistas";
                    lblTitle.Location = new Point(115, 20);
                    break;
            }
        }
    }
}
