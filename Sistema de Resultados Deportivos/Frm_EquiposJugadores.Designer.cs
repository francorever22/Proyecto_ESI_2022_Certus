namespace Sistema_de_Resultados_Deportivos
{
    partial class Frm_EquiposJugadores
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
            this.btnCerrarSettings = new System.Windows.Forms.Button();
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.picFavorito = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavorito)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrarSettings
            // 
            this.btnCerrarSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSettings.Location = new System.Drawing.Point(308, 12);
            this.btnCerrarSettings.Name = "btnCerrarSettings";
            this.btnCerrarSettings.Size = new System.Drawing.Size(30, 30);
            this.btnCerrarSettings.TabIndex = 13;
            this.btnCerrarSettings.Text = "X";
            this.btnCerrarSettings.UseVisualStyleBackColor = true;
            this.btnCerrarSettings.Click += new System.EventHandler(this.btnCerrarForm_Click);
            // 
            // picImagen
            // 
            this.picImagen.Location = new System.Drawing.Point(100, 12);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(150, 150);
            this.picImagen.TabIndex = 14;
            this.picImagen.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.Location = new System.Drawing.Point(11, 205);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(328, 209);
            this.panelContenedor.TabIndex = 15;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(152, 174);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 19);
            this.lblNombre.TabIndex = 16;
            // 
            // picFavorito
            // 
            this.picFavorito.BackColor = System.Drawing.Color.Transparent;
            this.picFavorito.BackgroundImage = global::Sistema_de_Resultados_Deportivos.Properties.Resources.estrellaVacia;
            this.picFavorito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFavorito.Location = new System.Drawing.Point(12, 12);
            this.picFavorito.Name = "picFavorito";
            this.picFavorito.Size = new System.Drawing.Size(30, 30);
            this.picFavorito.TabIndex = 17;
            this.picFavorito.TabStop = false;
            this.picFavorito.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Frm_EquiposJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 423);
            this.Controls.Add(this.picFavorito);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.picImagen);
            this.Controls.Add(this.btnCerrarSettings);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_EquiposJugadores";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavorito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnCerrarSettings;
        private PictureBox picImagen;
        private Panel panelContenedor;
        private Label lblNombre;
        private PictureBox picFavorito;
    }
}