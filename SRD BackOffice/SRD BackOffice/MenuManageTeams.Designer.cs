namespace SRD_BackOffice
{
    partial class MenuManageTeams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuManageTeams));
            this.panelManageSports = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.panelEquipos = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPaisOrigen = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnTeamsManagerCerrar = new System.Windows.Forms.Button();
            this.panelManageSports.SuspendLayout();
            this.panelEquipos.SuspendLayout();
            this.panelLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelManageSports
            // 
            this.panelManageSports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelManageSports.Controls.Add(this.btnBuscar);
            this.panelManageSports.Controls.Add(this.txtBuscador);
            this.panelManageSports.Controls.Add(this.panelEquipos);
            this.panelManageSports.Controls.Add(this.lblTitle);
            this.panelManageSports.Controls.Add(this.btnTeamsManagerCerrar);
            this.panelManageSports.Location = new System.Drawing.Point(-1, -1);
            this.panelManageSports.Name = "panelManageSports";
            this.panelManageSports.Size = new System.Drawing.Size(498, 541);
            this.panelManageSports.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::SRD_BackOffice.Properties.Resources.lupa;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(379, 90);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 25);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(70, 91);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(309, 23);
            this.txtBuscador.TabIndex = 24;
            // 
            // panelEquipos
            // 
            this.panelEquipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelEquipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEquipos.Controls.Add(this.panelContenedor);
            this.panelEquipos.Controls.Add(this.panelLabels);
            this.panelEquipos.Location = new System.Drawing.Point(13, 148);
            this.panelEquipos.Name = "panelEquipos";
            this.panelEquipos.Size = new System.Drawing.Size(473, 382);
            this.panelEquipos.TabIndex = 23;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContenedor.Location = new System.Drawing.Point(0, 25);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(471, 356);
            this.panelContenedor.TabIndex = 1;
            // 
            // panelLabels
            // 
            this.panelLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLabels.Controls.Add(this.lblId);
            this.panelLabels.Controls.Add(this.lblName);
            this.panelLabels.Controls.Add(this.lblPaisOrigen);
            this.panelLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabels.Location = new System.Drawing.Point(0, 0);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(471, 25);
            this.panelLabels.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(25, 4);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 15);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(178, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 15);
            this.lblName.TabIndex = 1;
            // 
            // lblPaisOrigen
            // 
            this.lblPaisOrigen.AutoSize = true;
            this.lblPaisOrigen.Location = new System.Drawing.Point(330, 4);
            this.lblPaisOrigen.Name = "lblPaisOrigen";
            this.lblPaisOrigen.Size = new System.Drawing.Size(0, 15);
            this.lblPaisOrigen.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 32);
            this.lblTitle.TabIndex = 22;
            // 
            // btnTeamsManagerCerrar
            // 
            this.btnTeamsManagerCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnTeamsManagerCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTeamsManagerCerrar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnTeamsManagerCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnTeamsManagerCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnTeamsManagerCerrar.Image = global::SRD_BackOffice.Properties.Resources.Incio_Claro;
            this.btnTeamsManagerCerrar.Location = new System.Drawing.Point(457, 3);
            this.btnTeamsManagerCerrar.Name = "btnTeamsManagerCerrar";
            this.btnTeamsManagerCerrar.Size = new System.Drawing.Size(38, 38);
            this.btnTeamsManagerCerrar.TabIndex = 18;
            this.btnTeamsManagerCerrar.UseVisualStyleBackColor = true;
            this.btnTeamsManagerCerrar.Click += new System.EventHandler(this.btnSportsManagerCerrar_Click);
            // 
            // MenuManageTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 541);
            this.Controls.Add(this.panelManageSports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuManageTeams";
            this.Text = "AdministradorAPP";
            this.panelManageSports.ResumeLayout(false);
            this.panelManageSports.PerformLayout();
            this.panelEquipos.ResumeLayout(false);
            this.panelLabels.ResumeLayout(false);
            this.panelLabels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelManageSports;
        private Button btnTeamsManagerCerrar;
        private Label lblTitle;
        private Panel panelEquipos;
        private Panel panelContenedor;
        private Panel panelLabels;
        private Label lblId;
        private Label lblName;
        private Label lblPaisOrigen;
        private Button btnBuscar;
        private TextBox txtBuscador;
    }
}