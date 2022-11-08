namespace Sistema_de_Resultados_Deportivos
{
    partial class Frm_Eventos
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.picFavorito = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavorito)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 150);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(354, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 25);
            this.lblName.TabIndex = 1;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.Location = new System.Drawing.Point(0, 206);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(724, 345);
            this.panelContenedor.TabIndex = 2;
            // 
            // picFavorito
            // 
            this.picFavorito.BackColor = System.Drawing.Color.Transparent;
            this.picFavorito.BackgroundImage = global::Sistema_de_Resultados_Deportivos.Properties.Resources.estrellaVacia;
            this.picFavorito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFavorito.Location = new System.Drawing.Point(694, 0);
            this.picFavorito.Name = "picFavorito";
            this.picFavorito.Size = new System.Drawing.Size(30, 30);
            this.picFavorito.TabIndex = 18;
            this.picFavorito.TabStop = false;
            this.picFavorito.Click += new System.EventHandler(this.picFavorito_Click);
            // 
            // Frm_Eventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 552);
            this.Controls.Add(this.picFavorito);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Eventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Encuentros_Tipo_A";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavorito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picLogo;
        private Label lblName;
        private Panel panelContenedor;
        private PictureBox picFavorito;
    }
}