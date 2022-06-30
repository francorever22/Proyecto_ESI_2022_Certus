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
    public partial class MenuCrearCategoria : Form
    {
        public MenuCrearCategoria()
        {
            InitializeComponent();
            SetIdioma();
        }

        private void btnCategoryCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            this.Close();
        }

        private void btnCategoryAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text != "")
                {
                    var categorias = Logica.DeserializeCategorias(Logica.GetJson("DinamicJson\\Categorias.json"));
                    Categoria newCategory = new Categoria();
                    newCategory.nombreCategoria = txtCategoryName.Text;
                    if (categorias != null)
                    {
                        categorias.Add(newCategory);
                        Logica.SerializeCategorias(categorias);
                    }
                    else
                    {
                        List<Categoria> list = new List<Categoria>();
                        Logica.SerializeCategorias(list);
                    }
                    MessageBox.Show("New category created correctly");
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
                MessageBox.Show("There was an error in the process");
            }
        }
    }
}
