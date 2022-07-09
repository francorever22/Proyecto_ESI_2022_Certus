namespace Sistema_de_Resultados_Deportivos
{
    partial class Categorias
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
            this.panelDeportes = new System.Windows.Forms.Panel();
            this.lblCategorias = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelDeportes
            // 
            this.panelDeportes.AutoScroll = true;
            this.panelDeportes.Location = new System.Drawing.Point(0, 73);
            this.panelDeportes.Name = "panelDeportes";
            this.panelDeportes.Size = new System.Drawing.Size(724, 479);
            this.panelDeportes.TabIndex = 0;
            // 
            // lblCategorias
            // 
            this.lblCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategorias.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCategorias.Location = new System.Drawing.Point(0, 9);
            this.lblCategorias.Name = "lblCategorias";
            this.lblCategorias.Size = new System.Drawing.Size(724, 47);
            this.lblCategorias.TabIndex = 1;
            this.lblCategorias.Text = "Pelota";
            this.lblCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 552);
            this.Controls.Add(this.lblCategorias);
            this.Controls.Add(this.panelDeportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Categorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            switch (AjustesDeUsuario.darkTheme)
            {
                case false: //Tema claro
                    /* Paneles */
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    this.panelDeportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    /* Textos (Incluidos botones) */
                    this.lblCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    break;
                case true: //Tema oscuro
                    /* Paneles */
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    this.panelDeportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    /* Textos (Incluidos botones) */
                    this.lblCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    break;
            }
        }

        #endregion

        private Panel panelDeportes;
        private Label lblCategorias;
    }
}