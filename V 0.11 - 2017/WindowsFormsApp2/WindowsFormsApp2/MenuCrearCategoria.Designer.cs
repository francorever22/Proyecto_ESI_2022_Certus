using System.Windows.Forms;

namespace SRD_BackOffice
{
    partial class MenuCrearCategoria
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
            this.panelAgregarCategoria = new System.Windows.Forms.Panel();
            this.btnCategoryCerrar = new System.Windows.Forms.Button();
            this.btnCategoryAgregar = new System.Windows.Forms.Button();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.panelAgregarCategoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAgregarCategoria
            // 
            this.panelAgregarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelAgregarCategoria.Controls.Add(this.btnCategoryCerrar);
            this.panelAgregarCategoria.Controls.Add(this.btnCategoryAgregar);
            this.panelAgregarCategoria.Controls.Add(this.lblCategoryName);
            this.panelAgregarCategoria.Controls.Add(this.txtCategoryName);
            this.panelAgregarCategoria.Controls.Add(this.lblCategoryTitle);
            this.panelAgregarCategoria.Location = new System.Drawing.Point(-1, -1);
            this.panelAgregarCategoria.Name = "panelAgregarCategoria";
            this.panelAgregarCategoria.Size = new System.Drawing.Size(495, 294);
            this.panelAgregarCategoria.TabIndex = 11;
            // 
            // btnCategoryCerrar
            // 
            this.btnCategoryCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCategoryCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoryCerrar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCategoryCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCategoryCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCategoryCerrar.Image = global::WindowsFormsApp2.Properties.Resources.Incio_Claro;
            this.btnCategoryCerrar.Location = new System.Drawing.Point(446, 13);
            this.btnCategoryCerrar.Name = "btnCategoryCerrar";
            this.btnCategoryCerrar.Size = new System.Drawing.Size(38, 38);
            this.btnCategoryCerrar.TabIndex = 18;
            this.btnCategoryCerrar.UseVisualStyleBackColor = true;
            this.btnCategoryCerrar.Click += new System.EventHandler(this.btnCategoryCerrar_Click);
            // 
            // btnCategoryAgregar
            // 
            this.btnCategoryAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCategoryAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoryAgregar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCategoryAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCategoryAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCategoryAgregar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnCategoryAgregar.Location = new System.Drawing.Point(159, 219);
            this.btnCategoryAgregar.Name = "btnCategoryAgregar";
            this.btnCategoryAgregar.Size = new System.Drawing.Size(181, 41);
            this.btnCategoryAgregar.TabIndex = 19;
            this.btnCategoryAgregar.UseVisualStyleBackColor = true;
            this.btnCategoryAgregar.Click += new System.EventHandler(this.btnCategoryAgregar_Click);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCategoryName.Location = new System.Drawing.Point(19, 153);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(0, 21);
            this.lblCategoryName.TabIndex = 12;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCategoryName.Location = new System.Drawing.Point(0, 0);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(100, 25);
            this.txtCategoryName.TabIndex = 9;
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Montserrat", 30F);
            this.lblCategoryTitle.Location = new System.Drawing.Point(0, 0);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(0, 55);
            this.lblCategoryTitle.TabIndex = 8;
            // 
            // MenuCrearCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 294);
            this.Controls.Add(this.panelAgregarCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuCrearCategoria";
            this.Text = "AdministradorAPP";
            this.panelAgregarCategoria.ResumeLayout(false);
            this.panelAgregarCategoria.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private Panel panelAgregarCategoria;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Label lblCategoryTitle;
        private Button btnCategoryCerrar;
        private Button btnCategoryAgregar;
    }
}