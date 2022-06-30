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
    public partial class MenuManageSports : Form
    {
        public MenuManageSports()
        {
            InitializeComponent();
            SetIdioma();
            CargarCategorias();
            CargarDeportes();
        }

        private void CargarCategorias()
        {
            var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
            foreach (var categoria in categorias)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(395, 25);
                p1.TabIndex = 0;

                TextBox l1 = new TextBox(); //Nombre del deporte

                l1.ReadOnly = true;
                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = $"{categoria.nombreCategoria}";
                l1.TextAlign = HorizontalAlignment.Center;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.Size = new Size(160, 25);
                l1.AutoSize = false;
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);
                l1.TabIndex = 3;

                this.panelCategoriasContenedor.Controls.Add(p1); //Agrega los controles al panelCategoriasContenedor
                p1.Controls.Add(l1);
            }
        }

        private void CargarDeportes()
        {
            var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
            foreach (var deporte in deportes)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(395, 25);
                p1.TabIndex = 0;

                TextBox l1 = new TextBox(); //Nombre del deporte

                l1.ReadOnly = true;
                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = $"{deporte.nombreDeporte}";
                l1.TextAlign = HorizontalAlignment.Center;
                l1.Size = new Size(100, 25);
                l1.AutoSize = false;
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);
                l1.TabIndex = 3;

                TextBox l2 = new TextBox(); //Categoria del deporte

                l2.ReadOnly = true;
                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.Text = $"{deporte.categoriaDeporte}";
                l2.TextAlign = HorizontalAlignment.Center;
                l2.Size = new Size(195, 25);
                l2.AutoSize = false;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(100, 0);
                l2.TabIndex = 3;

                TextBox l3 = new TextBox(); //Si es popular o no

                l3.ReadOnly = true;
                l3.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                if (deporte.deportePopular == true)
                {
                    l3.Text = "Si";
                }
                else
                {
                    l3.Text = "No";
                }
                l3.TextAlign = HorizontalAlignment.Center;
                l3.Size = new Size(100, 25);
                l3.BorderStyle = BorderStyle.FixedSingle;
                l3.BackColor = Color.FromArgb(255, 255, 248);
                l3.AutoSize = false;
                l3.Location = new Point(295, 0);
                l3.TabIndex = 3;

                this.panelDeportesContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
                p1.Controls.Add(l3);
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
    }
}
