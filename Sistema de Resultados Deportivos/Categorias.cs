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
    public partial class Categorias : Form
    {
        public Categorias(String cat)
        {
            InitializeComponent();
            lblCategorias.Text = cat;
            int x = (this.Size.Width - lblCategorias.Size.Width) / 2;
            lblCategorias.Location = new Point(x, lblCategorias.Location.Y);
            CargarDeportes();
        }

        private void CargarDeportes() //Carga los botones de panelDeportes uno por uno
        {
            int x = 12;
            int y = 0;
            var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
            foreach (var deporte in deportes)
            {
                if (deporte.categoriaDeporte == lblCategorias.Text)
                {
                    Panel p1 = new Panel();
                    p1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    p1.Size = new System.Drawing.Size(150, 150);
                    p1.TabIndex = 0;
                    p1.Location = new System.Drawing.Point(x, y);

                    Button b1 = new Button(); //Crea el boton que permitira acceder al deporte
                    b1.Dock = System.Windows.Forms.DockStyle.Fill;
                    b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    b1.Location = new System.Drawing.Point(0, 0);
                    b1.Size = new System.Drawing.Size(563, 60);
                    b1.TabIndex = 10;
                    b1.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    b1.UseVisualStyleBackColor = true;
                    b1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    b1.Image = null;
                    b1.Text = deporte.nombreDeporte;

                    this.panelDeportes.Controls.Add(p1); //Agrega los controles al panelCategorias
                    p1.Controls.Add(b1);

                    if (x == 12)
                    {
                        x = 190;
                    }
                    else if (x == 190)
                    {
                        x = 370;
                    }
                    else if (x == 370)
                    {
                        x = 550;
                    }
                    else if (x == 550)
                    {
                        y += 190;
                        x = 12;
                    }
                }
            }
        }
    }
}
