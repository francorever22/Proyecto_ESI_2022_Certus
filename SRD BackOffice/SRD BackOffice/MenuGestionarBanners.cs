namespace SRD_BackOffice
{
    public partial class MenuGestionarBanners : Form
    {
        Bitmap image = null;
        bool modify = false;
        int index;
        public MenuGestionarBanners()
        {
            InitializeComponent();
            SetIdioma();
            CargarBanners();

            btnBuscar.Click += (sender, EventArgs) => { btnBuscar_Click(sender, EventArgs, txtBuscador.Text); };
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
            int x = 0;
            panelBannersContenedor.Controls.Clear();
            var banners = Logica.DeserializeBanners(Logica.GetJson("DinamicJson\\Banners.json"));
            int count = banners.Count;
            foreach (var banner in banners)
            {
                if (x >= count - 15)
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(386, 25);
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

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(372, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, banners, banner, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(360, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { ModifyBanner_Click(sender, EventArgs, banners.IndexOf(banner)); };

                    this.panelBannersContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                    p1.Controls.Add(pic2);
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l2);
                }
                x++;
            }
        }

        private void btnAddBanner_Click(object sender, EventArgs e)
        {
            try
            {
                if (modify == false)
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
                    }
                    else
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
                else
                {
                    if (txtBannerTitle.Text != "" && imgBannerSelected != null && txtBannerLink.Text != "")
                    {
                        var banners = Logica.DeserializeBanners(Logica.GetJson("DinamicJson\\Banners.json"));
                        Banner banner = banners[index];
                        if (!(txtBannerTitle.Text == banner.TitleBanner && txtBannerLink.Text == banner.Link &&
                            imgBannerSelected.Image == banner.BannerImage))
                        {
                            DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify banner", MessageBoxButtons.YesNo);
                            if (dialogResult1 == DialogResult.Yes)
                            {
                                banner.TitleBanner = txtBannerTitle.Text;
                                banner.Link = txtBannerLink.Text;
                                //banner.BannerImage = imgBannerSelected.Image;
                                banners[index] = banner;
                                Logica.SerializeBanners(banners);

                                txtBannerTitle.Text = "";
                                txtBannerLink.Text = "";
                                imgBannerSelected.Image = null;
                                btnAddBanner.Text = "Add";
                                modify = false;
                            }
                        }
                        else
                        {
                            if (Program.language == "EN")
                            {
                                MessageBox.Show("The entered data equals the previous one");
                            }
                            else if (Program.language == "ES")
                            {
                                MessageBox.Show("La información ingresada es la misma que la anterior");
                            }
                        }
                    }
                }
            } catch
            {
                MessageBox.Show("Error");
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

        private void Delete_Click(object sender, EventArgs e, List<Banner> list, Banner b, Panel p)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete this?", "Delete banner", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                list.Remove(b);
                Logica.SerializeBanners(list);
                p.Dispose();
            }
        }

        private void ModifyBanner_Click(object sender, EventArgs e, int index)
        {
            modify = true;
            this.index = index;

            var banners = Logica.DeserializeBanners(Logica.GetJson("DinamicJson\\Banners.json"));
            Banner banner = banners[index];

            txtBannerTitle.Text = banner.TitleBanner;
            txtBannerLink.Text = banner.Link;
            //imgBannerSelected.Image = banner.BannerImage;
            btnAddBanner.Text = "Modify";
        }

        private void btnBuscar_Click(object sender, EventArgs e, string busqueda)
        {
            panelBannersContenedor.Controls.Clear();

            var banners = Logica.DeserializeBanners(Logica.GetJson("DinamicJson\\Banners.json"));
            int count = 0;

            foreach (var banner in banners)
            {
                if (busqueda == Convert.ToString(banner.IdBanner) || banner.TitleBanner.Contains(busqueda) || banner.Link.Contains(busqueda))
                {
                    Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                    p1.Dock = DockStyle.Top;
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(255, 255, 248);
                    p1.Size = new Size(386, 25);
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

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(372, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, banners, banner, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(360, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { ModifyBanner_Click(sender, EventArgs, banners.IndexOf(banner)); };

                    this.panelBannersContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                    p1.Controls.Add(pic2);
                    p1.Controls.Add(pic1);
                    p1.Controls.Add(l1);
                    p1.Controls.Add(l2);
                }
            }
        }
    }
}
