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
    public partial class MenuGestionarBanners : Form
    {
        Bitmap image = null;
        public MenuGestionarBanners()
        {
            InitializeComponent();
            SetIdioma();
            CargarBanners();
        }

        private void btnBannerCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            this.Close();
        }

        private void CargarBanners()
        {
            panelBannersContenedor.Controls.Clear();
            var banners = Logica.DeserializeBanners(Logica.GetJson("DinamicJson\\Banners.json"));
            foreach (var banner in banners)
            {
                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(361, 25);
                p1.TabIndex = 0;

                TextBox l1 = new TextBox(); //Titulo banner

                l1.ReadOnly = true;
                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = $"{banner.TitleBanner}";
                l1.BackColor = Color.FromArgb(255, 255, 248);
                l1.TextAlign = HorizontalAlignment.Center;
                l1.Size = new Size(180, 25);
                l1.AutoSize = false;
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);
                l1.TabIndex = 3;

                TextBox l2 = new TextBox(); //Link de la pagina asociada

                l2.ReadOnly = true;
                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.Text = $"{banner.Link}";
                l2.TextAlign = HorizontalAlignment.Center;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.Size = new Size(181, 25);
                l2.AutoSize = false;
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(180, 0);
                l2.TabIndex = 3;

                this.panelBannersContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
            }
        }

        private void btnAddBanner_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBannerTitle.Text != "" && txtBannerLink.Text != "" && image != null)
                {
                    var banners = Logica.DeserializeBanners(Logica.GetJson("DinamicJson\\Banners.json"));
                    Banner banner = new Banner();

                    banner.IdBanner = 0;
                    banner.TitleBanner = txtBannerTitle.Text;
                    banner.Link = txtBannerLink.Text;
                    banner.BannerImage = null;
                    // banner.BannerImage = image; Requiere dividir la imagen en un array de bytes para poder ser guardada

                    if (banners != null)
                    {
                        banners.Add(banner);
                        Logica.SerializeBanners(banners);
                    }
                    else
                    {
                        List<Banner> list = new List<Banner>();
                        Logica.SerializeBanners(list);
                    }
                    MessageBox.Show("Banner added correctly");
                    CargarBanners();
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
            } catch
            {
                MessageBox.Show("Banner added correctly");
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    image = new Bitmap(open.FileName);
                    int wid = image.Width;
                    int hei = image.Height;
                    if (wid == 150 || hei == 500)
                    {
                        imgBannerSelected.Image = image;
                    } else
                    {
                        image = null;
                        imgBannerSelected.Image = null;
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The banner has to have the sizes 150x500 pixels");
                        } else if (Program.language == "ES") {
                            MessageBox.Show("El banner debe tener las medidas 150x500 pixeles");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
