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
    public partial class MenuCrearDeporte : Form
    {
        Bitmap imagenCargada = null;

        public MenuCrearDeporte()
        {
            InitializeComponent();
            SetIdioma();

            var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
            foreach (var c in categorias)
            {
                cbxSportCategory.Items.Add(c.nombreCategoria);
            }
        }

        private void btnSportCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            this.Close();
        }

        private void btnSportAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSportName.Text != "" && cbxSportCategory != null && imagenCargada != null)
                {
                    var deportes = Logica.DeserializeDeportes(Logica.GetJson("DinamicJson\\Deportes.json"));
                    Deporte deporte = new Deporte();

                    deporte.nombreDeporte = txtSportName.Text;
                    deporte.categoriaDeporte = cbxSportCategory.Text;
                    deporte.imagenDeporte = null;
                    // deporte.imagenDeporte = imagenCargada; Requiere dividir la imagen en un array de bytes para poder ser guardada
                    if (tgbSportPopular.Checked == true) { deporte.deportePopular = true; }
                    else { deporte.deportePopular = false; }

                    if (deportes != null)
                    {
                        deportes.Add(deporte);
                        Logica.SerializeDeportes(deportes);
                    }
                    else
                    {
                        List<Deporte> list = new List<Deporte>();
                        Logica.SerializeDeportes(list);
                    }
                    MessageBox.Show("New sport created correctly");
                } else
                {
                    if (Program.language == "EN")
                    {
                        MessageBox.Show("There are filds incomplete");
                    }
                    else if (Program.language == "ES")
                    {
                        MessageBox.Show("Quedan espacios vacios por rellenar");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    imagenCargada = new Bitmap(open.FileName);
                    int wid = imagenCargada.Width;
                    int hei = imagenCargada.Height;
                    if (wid == 150 || hei == 150)
                    {
                        imgSportSelected.Image = imagenCargada;
                    }
                    else
                    {
                        imagenCargada = null;
                        imgSportSelected.Image = null;
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The image must be of the size of 150x150 pixels");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("La imagen debe ser de la medida de 150x150 pixeles");
                        }
                    }
                }
            } catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
