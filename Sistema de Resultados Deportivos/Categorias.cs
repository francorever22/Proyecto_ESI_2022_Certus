﻿using System;
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
        private static Categorias form = null;
        public Categorias(String cat)
        {
            InitializeComponent();
            form = this;
            lblCategorias.Text = cat;
            int x = (this.Size.Width - lblCategorias.Size.Width) / 2;
            lblCategorias.Location = new Point(x, lblCategorias.Location.Y);
            SetTheme();
            CargarDeportes();
        }

        private void CargarDeportes() //Carga los botones de panelDeportes uno por uno
        {
            panelDeportes.Controls.Clear();
            int x = 12;
            int y = 0;
            var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
            foreach (var deporte in deportes)
            {
                if (deporte.categoriaDeporte == lblCategorias.Text)
                {
                    Panel p1 = new Panel();
                    p1.BorderStyle = BorderStyle.None;
                    p1.Size = new Size(150, 150);
                    p1.TabIndex = 0;
                    p1.Location = new Point(x, y);

                    Button b1 = new Button(); //Crea el boton que permitira acceder al deporte
                    b1.Dock = DockStyle.Fill;
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.Location = new Point(0, 0);
                    b1.Size = new Size(563, 60);
                    b1.TabIndex = 10;
                    b1.Font = new ("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    b1.UseVisualStyleBackColor = true;
                    b1.TextAlign = ContentAlignment.BottomCenter;
                    b1.Image = null;
                    b1.Text = deporte.nombreDeporte;
                    b1.BackColor = AjustesDeUsuario.btnBack;
                    b1.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
                    b1.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
                    b1.ForeColor = AjustesDeUsuario.foreColor;

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

        public static void AlterCategorias(int y)
        {
            switch (y)
            {
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                        form.CargarDeportes();
                    }
                    break;
            }
        }

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            BackColor = AjustesDeUsuario.panel;
            panelDeportes.BackColor = AjustesDeUsuario.panel;
            lblCategorias.ForeColor = AjustesDeUsuario.foreColor;
        }
    }
}
