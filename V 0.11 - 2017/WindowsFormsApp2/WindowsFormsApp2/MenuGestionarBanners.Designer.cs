using System.Windows.Forms;

namespace SRD_BackOffice
{
    partial class MenuGestionarBanners
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMangeBanners = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelBannersContenedor = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.txtBannerTitle = new System.Windows.Forms.TextBox();
            this.lblBannerLink = new System.Windows.Forms.Label();
            this.txtBannerLink = new System.Windows.Forms.TextBox();
            this.btnBannerCerrar = new System.Windows.Forms.Button();
            this.btnAddBanner = new System.Windows.Forms.Button();
            this.imgBannerSelected = new System.Windows.Forms.PictureBox();
            this.lblBannerImage = new System.Windows.Forms.Label();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.lblMangaTitle = new System.Windows.Forms.Label();
            this.panelMangeBanners.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBannerSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMangeBanners
            // 
            this.panelMangeBanners.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelMangeBanners.Controls.Add(this.panel2);
            this.panelMangeBanners.Controls.Add(this.lblBannerTitle);
            this.panelMangeBanners.Controls.Add(this.txtBannerTitle);
            this.panelMangeBanners.Controls.Add(this.lblBannerLink);
            this.panelMangeBanners.Controls.Add(this.txtBannerLink);
            this.panelMangeBanners.Controls.Add(this.btnBannerCerrar);
            this.panelMangeBanners.Controls.Add(this.btnAddBanner);
            this.panelMangeBanners.Controls.Add(this.imgBannerSelected);
            this.panelMangeBanners.Controls.Add(this.lblBannerImage);
            this.panelMangeBanners.Controls.Add(this.btnSelectImage);
            this.panelMangeBanners.Controls.Add(this.lblMangaTitle);
            this.panelMangeBanners.Location = new System.Drawing.Point(0, 0);
            this.panelMangeBanners.Name = "panelMangeBanners";
            this.panelMangeBanners.Size = new System.Drawing.Size(907, 605);
            this.panelMangeBanners.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panelBannersContenedor);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(493, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 409);
            this.panel2.TabIndex = 26;
            // 
            // panelBannersContenedor
            // 
            this.panelBannersContenedor.AutoScroll = true;
            this.panelBannersContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelBannersContenedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBannersContenedor.Location = new System.Drawing.Point(0, 25);
            this.panelBannersContenedor.Name = "panelBannersContenedor";
            this.panelBannersContenedor.Size = new System.Drawing.Size(361, 383);
            this.panelBannersContenedor.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(361, 25);
            this.panel4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(246, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Popular";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 15);
            this.label7.TabIndex = 0;
            // 
            // lblBannerTitle
            // 
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBannerTitle.Location = new System.Drawing.Point(52, 88);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(0, 21);
            this.lblBannerTitle.TabIndex = 25;
            // 
            // txtBannerTitle
            // 
            this.txtBannerTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtBannerTitle.Location = new System.Drawing.Point(31, 123);
            this.txtBannerTitle.Name = "txtBannerTitle";
            this.txtBannerTitle.Size = new System.Drawing.Size(242, 20);
            this.txtBannerTitle.TabIndex = 24;
            // 
            // lblBannerLink
            // 
            this.lblBannerLink.AutoSize = true;
            this.lblBannerLink.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBannerLink.Location = new System.Drawing.Point(0, 0);
            this.lblBannerLink.Name = "lblBannerLink";
            this.lblBannerLink.Size = new System.Drawing.Size(0, 21);
            this.lblBannerLink.TabIndex = 22;
            // 
            // txtBannerLink
            // 
            this.txtBannerLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtBannerLink.Location = new System.Drawing.Point(31, 450);
            this.txtBannerLink.Name = "txtBannerLink";
            this.txtBannerLink.Size = new System.Drawing.Size(242, 20);
            this.txtBannerLink.TabIndex = 21;
            // 
            // btnBannerCerrar
            // 
            this.btnBannerCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnBannerCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBannerCerrar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnBannerCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnBannerCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnBannerCerrar.Image = global::WindowsFormsApp2.Properties.Resources.Incio_Claro;
            this.btnBannerCerrar.Location = new System.Drawing.Point(857, 12);
            this.btnBannerCerrar.Name = "btnBannerCerrar";
            this.btnBannerCerrar.Size = new System.Drawing.Size(38, 38);
            this.btnBannerCerrar.TabIndex = 19;
            this.btnBannerCerrar.UseVisualStyleBackColor = true;
            this.btnBannerCerrar.Click += new System.EventHandler(this.btnBannerCerrar_Click);
            // 
            // btnAddBanner
            // 
            this.btnAddBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAddBanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBanner.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddBanner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAddBanner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAddBanner.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAddBanner.Location = new System.Drawing.Point(311, 561);
            this.btnAddBanner.Name = "btnAddBanner";
            this.btnAddBanner.Size = new System.Drawing.Size(150, 30);
            this.btnAddBanner.TabIndex = 20;
            this.btnAddBanner.UseVisualStyleBackColor = true;
            this.btnAddBanner.Click += new System.EventHandler(this.btnAddBanner_Click);
            // 
            // imgBannerSelected
            // 
            this.imgBannerSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBannerSelected.Location = new System.Drawing.Point(311, 44);
            this.imgBannerSelected.Name = "imgBannerSelected";
            this.imgBannerSelected.Size = new System.Drawing.Size(150, 500);
            this.imgBannerSelected.TabIndex = 17;
            this.imgBannerSelected.TabStop = false;
            // 
            // lblBannerImage
            // 
            this.lblBannerImage.AutoSize = true;
            this.lblBannerImage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBannerImage.Location = new System.Drawing.Point(0, 0);
            this.lblBannerImage.Name = "lblBannerImage";
            this.lblBannerImage.Size = new System.Drawing.Size(0, 21);
            this.lblBannerImage.TabIndex = 16;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSelectImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectImage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSelectImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnSelectImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSelectImage.Location = new System.Drawing.Point(74, 295);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(150, 25);
            this.btnSelectImage.TabIndex = 13;
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // lblMangaTitle
            // 
            this.lblMangaTitle.AutoSize = true;
            this.lblMangaTitle.Font = new System.Drawing.Font("Montserrat", 30F);
            this.lblMangaTitle.Location = new System.Drawing.Point(0, 0);
            this.lblMangaTitle.Name = "lblMangaTitle";
            this.lblMangaTitle.Size = new System.Drawing.Size(0, 55);
            this.lblMangaTitle.TabIndex = 8;
            // 
            // MenuGestionarBanners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 605);
            this.Controls.Add(this.panelMangeBanners);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuGestionarBanners";
            this.Text = "AdministradorAPP";
            this.panelMangeBanners.ResumeLayout(false);
            this.panelMangeBanners.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBannerSelected)).EndInit();
            this.ResumeLayout(false);

        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    this.lblMangaTitle.Text = "Manage banners";
                    this.lblMangaTitle.Location = new System.Drawing.Point(493, 44);
                    this.btnSelectImage.Text = "Select image";
                    this.lblBannerImage.Text = "Add an image for the new banner";
                    this.lblBannerImage.Location = new System.Drawing.Point(31, 249);
                    this.btnAddBanner.Text = "Add";
                    this.lblBannerLink.Text = "Insert the link attched to the banner";
                    this.lblBannerLink.Location = new System.Drawing.Point(24, 413);
                    this.lblBannerTitle.Text = "Insert the title of the banner";
                    this.label7.Text = "Name";
                    this.label7.Location = new System.Drawing.Point(70, 3);
                    break;
                case "ES": //Español
                    this.lblMangaTitle.Text = "Administrar banners";
                    this.lblMangaTitle.Location = new System.Drawing.Point(460, 44);
                    this.btnSelectImage.Text = "Seleccione una imagen";
                    this.lblBannerImage.Text = "Agregue una imagen para el nuevo banner";
                    this.lblBannerImage.Location = new System.Drawing.Point(4, 249);
                    this.btnAddBanner.Text = "Agregar";
                    this.lblBannerLink.Text = "Inserte el link vinculado con el banner";
                    this.lblBannerLink.Location = new System.Drawing.Point(20, 413);
                    this.lblBannerTitle.Text = "Inserte el titulo del banner";
                    this.label7.Text = "Nombre";
                    this.label7.Location = new System.Drawing.Point(64, 3);
                    break;
            }
        }

        #endregion
        private Panel panelMangeBanners;
        private PictureBox imgBannerSelected;
        private Label lblBannerImage;
        private Button btnSelectImage;
        private Label lblMangaTitle;
        private Button btnBannerCerrar;
        private Button btnAddBanner;
        private Label lblBannerLink;
        private TextBox txtBannerLink;
        private Label lblBannerTitle;
        private TextBox txtBannerTitle;
        private Panel panel2;
        private Panel panelBannersContenedor;
        private Panel panel4;
        private Label label5;
        private Label label7;
    }
}