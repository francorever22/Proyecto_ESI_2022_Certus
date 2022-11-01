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
            Hide();
            MainMenu main = new MainMenu();
            main.StartPosition = FormStartPosition.CenterParent;
            main.ShowDialog();
            Close();
        }

        private void CargarBanners()
        {
            int x = 0;
            panelBannersContenedor.Controls.Clear();
            var banners = Logica.GetBanners(1, null);
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
                    l2.Size = new Size(163, 25);
                    l2.AutoSize = false;
                    l2.BorderStyle = BorderStyle.FixedSingle;
                    l2.Location = new Point(180, 0);
                    l2.TabIndex = 3;

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(355, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, banner.IdBanner, p1); };

                    PictureBox pic2 = new PictureBox(); //Boton modificar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(343, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.pluma;
                    pic2.Click += (sender, EventArgs) => { ModifyBanner_Click(sender, EventArgs, banner.IdBanner); };

                    panelBannersContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
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
            if (modify == false)
            {
                if (txtBannerTitle.Text != "" && txtBannerLink.Text != "" && image != null)
                {
                    try
                    {
                        string titleBanner = txtBannerTitle.Text,
                               link = txtBannerLink.Text;
                        byte[] bannerImage = null;
                        // banner.BannerImage = image; Requiere dividir la imagen en un array de bytes para poder ser guardada

                        Logica.InsertBanner(titleBanner, link, bannerImage);
                        MessageBox.Show("Banner added correctly");
                        CargarBanners();
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
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
                if (txtBannerTitle.Text != "" && txtBannerLink.Text != "" && image != null)
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify banner", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        try
                        {
                            string titleBanner = txtBannerTitle.Text,
                                   link = txtBannerLink.Text;
                            byte[] bannerImage = null;
                            // banner.BannerImage = image; Requiere dividir la imagen en un array de bytes para poder ser guardada

                            Logica.UpdateBanner(index, titleBanner, link, bannerImage);
                            MessageBox.Show("Banner modified correctly");
                            CargarBanners();

                            txtBannerTitle.Text = "";
                            txtBannerLink.Text = "";
                            imgBannerSelected.Image = null;
                            btnAddBanner.Text = "Add";
                            index = 0;
                            modify = false;
                        }
                        catch
                        {
                            MessageBox.Show("Error");
                        }
                    }
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

        private void Delete_Click(object sender, EventArgs e, int id, Panel p)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete this?", "Delete banner", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Logica.Delete("Publicidades", "IdPublicidad", id+"");
                    p.Dispose();
                    MessageBox.Show("Successfully eliminated");
                } catch { MessageBox.Show("Error"); }
            }
        }

        private void ModifyBanner_Click(object sender, EventArgs e, int index)
        {
            modify = true;
            this.index = index;

            var banner = Logica.GetBanners(3, ""+index)[0];

            txtBannerTitle.Text = banner.TitleBanner;
            txtBannerLink.Text = banner.Link;
            //imgBannerSelected.Image = banner.BannerImage;
            //image = banner.BannerImage;
            btnAddBanner.Text = "Modify";
        }

        private void btnBuscar_Click(object sender, EventArgs e, string busqueda)
        {
            panelBannersContenedor.Controls.Clear();

            var banners = Logica.GetBanners(2, busqueda);
            int count = 0;

            foreach (var banner in banners)
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
                l2.Location = new Point(163, 0);
                l2.TabIndex = 3;

                PictureBox pic1 = new PictureBox(); //Boton eliminar

                pic1.BorderStyle = BorderStyle.FixedSingle;
                pic1.Size = new Size(12, 12);
                pic1.Location = new Point(355, 7);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Properties.Resources.cruz;
                pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, banner.IdBanner, p1); };

                PictureBox pic2 = new PictureBox(); //Boton modificar
                
                pic2.BorderStyle = BorderStyle.FixedSingle;
                pic2.Size = new Size(12, 12);
                pic2.Location = new Point(343, 7);
                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic2.Image = Properties.Resources.pluma;
                pic2.Click += (sender, EventArgs) => { ModifyBanner_Click(sender, EventArgs, banners.IndexOf(banner)); };

                panelBannersContenedor.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                p1.Controls.Add(pic2);
                p1.Controls.Add(pic1);
                p1.Controls.Add(l1);
                p1.Controls.Add(l2);
            }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblMangaTitle.Text = "Manage banners";
                    lblMangaTitle.Location = new Point(493, 44);
                    btnSelectImage.Text = "Select image";
                    lblBannerImage.Text = "Add an image for the new banner";
                    lblBannerImage.Location = new Point(31, 249);
                    btnAddBanner.Text = "Add";
                    lblBannerLink.Text = "Insert the link attched to the banner";
                    lblBannerLink.Location = new Point(24, 413);
                    lblBannerTitle.Text = "Insert the title of the banner";
                    label7.Text = "Name";
                    label7.Location = new Point(70, 3);
                    break;
                case "ES": //Español
                    lblMangaTitle.Text = "Administrar banners";
                    lblMangaTitle.Location = new Point(460, 44);
                    btnSelectImage.Text = "Seleccione una imagen";
                    lblBannerImage.Text = "Agregué una imagen para el nuevo banner";
                    lblBannerImage.Location = new Point(4, 249);
                    btnAddBanner.Text = "Agregar";
                    lblBannerLink.Text = "Inserte el link vinculado con el banner";
                    lblBannerLink.Location = new Point(20, 413);
                    lblBannerTitle.Text = "Inserte el título del banner";
                    label7.Text = "Nombre";
                    label7.Location = new Point(64, 3);
                    break;
            }
        }
    }
}
