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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            txtBuscador.AutoSize = false;
            txtBuscador.Size = new System.Drawing.Size(514, 27);
            txtBuscador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            CargarEncuentros(10);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void CargarEncuentros(int c) //Carga los botones de panelEncuentros uno por uno
        {
            String t = "partido";
            for (int i = 0; i < c; i++)
            {
                switch (t)
                {
                    case "partido": //Crea opcion para encuentro
                        Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                        p1.Dock = System.Windows.Forms.DockStyle.Top;
                        p1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        p1.Size = new System.Drawing.Size(563, 60);
                        p1.TabIndex = 0;

                        Button b1 = new Button(); //Crea el boton que permitira acceder al encuentro

                        b1.Dock = System.Windows.Forms.DockStyle.Fill;
                        b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        b1.Location = new System.Drawing.Point(0, 0);
                        b1.Size = new System.Drawing.Size(563, 60);
                        b1.TabIndex = 10;
                        b1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        b1.Text = "0 - 0";
                        b1.UseVisualStyleBackColor = true;

                        PictureBox pic1 = new PictureBox(); //Imagen de Equipo 1

                        pic1.InitialImage = null;
                        pic1.BackColor = System.Drawing.Color.Transparent;
                        pic1.Size = new System.Drawing.Size(40, 40);
                        pic1.Location = new System.Drawing.Point(10, 10);
                        pic1.TabIndex = 1;
                        pic1.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.barcelona;

                        PictureBox pic2 = new PictureBox(); //Imagen de Equipo 2

                        pic2.InitialImage = null;
                        pic2.BackColor = System.Drawing.Color.Transparent;
                        pic2.Size = new System.Drawing.Size(40, 40);
                        pic2.Location = new System.Drawing.Point(498, 10);
                        pic2.TabIndex = 2;
                        pic2.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.realmadrid;

                        Label l1 = new Label(); //Nombre de Equipo 1

                        l1.BackColor = System.Drawing.Color.Transparent;
                        l1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l1.Text = "Barcelona";
                        l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l1.MaximumSize = new System.Drawing.Size(300, 30);
                        l1.AutoSize = true;
                        l1.Location = new System.Drawing.Point(60, 16);
                        l1.TabIndex = 3;

                        Label l2 = new Label(); //Nombre de Equipo 2

                        l2.BackColor = System.Drawing.Color.Transparent;
                        l2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l2.Text = "Real-Madrid";
                        l2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                        l2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l2.MaximumSize = new System.Drawing.Size(300, 30);
                        l2.AutoSize = true;
                        l2.Location = new System.Drawing.Point(382, 16);
                        l2.TabIndex = 4;

                        Label l3 = new Label(); //Hora del encuentro

                        l3.BackColor = System.Drawing.Color.Transparent;
                        l3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l3.Text = "18:00";
                        l3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l3.MaximumSize = new System.Drawing.Size(100, 30);
                        l3.AutoSize = true;
                        l3.Location = new System.Drawing.Point(248, 38);
                        l3.TabIndex = 5;

                        this.panelEncuentros.Controls.Add(p1); //Agrega los controles al panelEncuentros
                        p1.Controls.Add(b1);
                        b1.Controls.Add(pic1);
                        b1.Controls.Add(pic2);
                        b1.Controls.Add(l1);
                        b1.Controls.Add(l2);
                        b1.Controls.Add(l3);
                        break;

                    case "torneo": //Crea opcion para torneo
                        Panel p2 = new Panel(); //Crea el panel donde apareceran los controles

                        p2.Dock = System.Windows.Forms.DockStyle.Top;
                        p2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        p2.Size = new System.Drawing.Size(563, 60);

                        Button b2 = new Button(); //Crea el boton que permitira acceder al encuentro

                        b2.Dock = System.Windows.Forms.DockStyle.Fill;
                        b2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        b2.Location = new System.Drawing.Point(0, 0);
                        b2.Size = new System.Drawing.Size(563, 60);
                        b2.TabIndex = 10;
                        b2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        b2.Text = "";
                        b2.UseVisualStyleBackColor = true;

                        PictureBox pic3 = new PictureBox(); //Imagen de Equipo 1

                        pic3.InitialImage = null;
                        pic3.BackColor = System.Drawing.Color.Transparent;
                        pic3.Size = new System.Drawing.Size(40, 40);
                        pic3.Location = new System.Drawing.Point(10, 10);
                        pic3.TabIndex = 1;

                        Label l4 = new Label(); //Nombre de Equipo 1

                        l4.BackColor = System.Drawing.Color.Transparent;
                        l4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l4.Text = "Torneo X";
                        l4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l4.MaximumSize = new System.Drawing.Size(300, 30);
                        l4.AutoSize = true;
                        l4.Location = new System.Drawing.Point(60, 16);
                        l4.TabIndex = 3;

                        Label l5 = new Label(); //Hora del encuentro

                        l5.BackColor = System.Drawing.Color.Transparent;
                        l5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        l5.Text = "10:00";
                        l5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        l5.MaximumSize = new System.Drawing.Size(100, 30);
                        l5.AutoSize = true;
                        l5.Location = new System.Drawing.Point(242, 14);
                        l5.TabIndex = 5;

                        this.panelEncuentros.Controls.Add(p2); //Agrega los controles al panelEncuentros
                        p2.Controls.Add(b2);
                        b2.Controls.Add(pic3);
                        b2.Controls.Add(l4);
                        b2.Controls.Add(l5);
                        break;
                }
            }
        }
    }
}
