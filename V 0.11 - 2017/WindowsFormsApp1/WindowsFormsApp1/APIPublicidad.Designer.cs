using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    partial class APIPublicidad
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
            this.imgPublicidad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPublicidad)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPublicidad
            // 
            this.imgPublicidad.BackColor = System.Drawing.Color.Transparent;
            this.imgPublicidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPublicidad.InitialImage = null;
            this.imgPublicidad.Location = new System.Drawing.Point(0, 0);
            this.imgPublicidad.Name = "imgPublicidad";
            this.imgPublicidad.Size = new System.Drawing.Size(150, 500);
            this.imgPublicidad.TabIndex = 0;
            this.imgPublicidad.TabStop = false;
            this.imgPublicidad.Click += new System.EventHandler(this.imgPublicidad_Click);
            // 
            // APIPublicidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 500);
            this.Controls.Add(this.imgPublicidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "APIPublicidad";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.imgPublicidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox imgPublicidad;
    }
}