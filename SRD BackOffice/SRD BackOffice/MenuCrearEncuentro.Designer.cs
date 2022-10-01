namespace SRD_BackOffice
{
    partial class MenuCrearEncuentro
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
            this.cbxEstadoEncuentro = new System.Windows.Forms.ComboBox();
            this.cbxClimaEncuentro = new System.Windows.Forms.ComboBox();
            this.cbxDeporteEncuentro = new System.Windows.Forms.ComboBox();
            this.txtHoraEncuentro = new System.Windows.Forms.TextBox();
            this.txtFechaEncuentro = new System.Windows.Forms.TextBox();
            this.txtNombreEncuentro = new System.Windows.Forms.TextBox();
            this.txtLugarEncuentro = new System.Windows.Forms.TextBox();
            this.btnEncuentroCerrar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelEquipos = new System.Windows.Forms.Panel();
            this.panelBuscador = new System.Windows.Forms.Panel();
            this.txtArbitro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnArbitro = new System.Windows.Forms.Button();
            this.panelAgregarArbitro = new System.Windows.Forms.Panel();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNewArbitroApellido = new System.Windows.Forms.TextBox();
            this.btnCerrarAddArbitro = new System.Windows.Forms.Button();
            this.lblNewArbitroTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNacionalidadArbitro = new System.Windows.Forms.Label();
            this.lblNewNombreArbitro = new System.Windows.Forms.Label();
            this.btnNewArbitro = new System.Windows.Forms.Button();
            this.txtNewArbitroRol = new System.Windows.Forms.TextBox();
            this.txtNewArbitroNacionalidad = new System.Windows.Forms.TextBox();
            this.txtNewArbitroName = new System.Windows.Forms.TextBox();
            this.btnAlineacion = new System.Windows.Forms.Button();
            this.panelAgregarArbitro.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxEstadoEncuentro
            // 
            this.cbxEstadoEncuentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoEncuentro.FormattingEnabled = true;
            this.cbxEstadoEncuentro.Items.AddRange(new object[] {
            "Coming soon",
            "In progress",
            "Finalized"});
            this.cbxEstadoEncuentro.Location = new System.Drawing.Point(310, 125);
            this.cbxEstadoEncuentro.Name = "cbxEstadoEncuentro";
            this.cbxEstadoEncuentro.Size = new System.Drawing.Size(192, 23);
            this.cbxEstadoEncuentro.TabIndex = 1;
            // 
            // cbxClimaEncuentro
            // 
            this.cbxClimaEncuentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClimaEncuentro.FormattingEnabled = true;
            this.cbxClimaEncuentro.Items.AddRange(new object[] {
            "Sunny",
            "Partly cloudy",
            "Cloudy",
            "Rainy",
            "Thunderstorm",
            "Snowy",
            "Misty"});
            this.cbxClimaEncuentro.Location = new System.Drawing.Point(530, 125);
            this.cbxClimaEncuentro.Name = "cbxClimaEncuentro";
            this.cbxClimaEncuentro.Size = new System.Drawing.Size(138, 23);
            this.cbxClimaEncuentro.TabIndex = 2;
            // 
            // cbxDeporteEncuentro
            // 
            this.cbxDeporteEncuentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeporteEncuentro.FormattingEnabled = true;
            this.cbxDeporteEncuentro.Location = new System.Drawing.Point(486, 74);
            this.cbxDeporteEncuentro.Name = "cbxDeporteEncuentro";
            this.cbxDeporteEncuentro.Size = new System.Drawing.Size(121, 23);
            this.cbxDeporteEncuentro.TabIndex = 3;
            // 
            // txtHoraEncuentro
            // 
            this.txtHoraEncuentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtHoraEncuentro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHoraEncuentro.ForeColor = System.Drawing.Color.DimGray;
            this.txtHoraEncuentro.Location = new System.Drawing.Point(418, 74);
            this.txtHoraEncuentro.Name = "txtHoraEncuentro";
            this.txtHoraEncuentro.Size = new System.Drawing.Size(42, 25);
            this.txtHoraEncuentro.TabIndex = 28;
            this.txtHoraEncuentro.Text = "XX:XX";
            // 
            // txtFechaEncuentro
            // 
            this.txtFechaEncuentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFechaEncuentro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFechaEncuentro.ForeColor = System.Drawing.Color.DimGray;
            this.txtFechaEncuentro.Location = new System.Drawing.Point(304, 74);
            this.txtFechaEncuentro.Name = "txtFechaEncuentro";
            this.txtFechaEncuentro.Size = new System.Drawing.Size(88, 25);
            this.txtFechaEncuentro.TabIndex = 29;
            this.txtFechaEncuentro.Text = "DD/MM/YYYY";
            // 
            // txtNombreEncuentro
            // 
            this.txtNombreEncuentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNombreEncuentro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreEncuentro.Location = new System.Drawing.Point(23, 74);
            this.txtNombreEncuentro.Name = "txtNombreEncuentro";
            this.txtNombreEncuentro.Size = new System.Drawing.Size(253, 25);
            this.txtNombreEncuentro.TabIndex = 30;
            // 
            // txtLugarEncuentro
            // 
            this.txtLugarEncuentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtLugarEncuentro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLugarEncuentro.Location = new System.Drawing.Point(23, 125);
            this.txtLugarEncuentro.Name = "txtLugarEncuentro";
            this.txtLugarEncuentro.Size = new System.Drawing.Size(253, 25);
            this.txtLugarEncuentro.TabIndex = 31;
            // 
            // btnEncuentroCerrar
            // 
            this.btnEncuentroCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnEncuentroCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncuentroCerrar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEncuentroCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnEncuentroCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnEncuentroCerrar.Image = global::SRD_BackOffice.Properties.Resources.Incio_Claro;
            this.btnEncuentroCerrar.Location = new System.Drawing.Point(750, 12);
            this.btnEncuentroCerrar.Name = "btnEncuentroCerrar";
            this.btnEncuentroCerrar.Size = new System.Drawing.Size(38, 38);
            this.btnEncuentroCerrar.TabIndex = 32;
            this.btnEncuentroCerrar.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Points",
            "Sets",
            "Position",
            "Win/Lose"});
            this.comboBox1.Location = new System.Drawing.Point(701, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 23);
            this.comboBox1.TabIndex = 33;
            // 
            // panelEquipos
            // 
            this.panelEquipos.Location = new System.Drawing.Point(555, 165);
            this.panelEquipos.Name = "panelEquipos";
            this.panelEquipos.Size = new System.Drawing.Size(210, 273);
            this.panelEquipos.TabIndex = 34;
            // 
            // panelBuscador
            // 
            this.panelBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBuscador.Location = new System.Drawing.Point(224, 69);
            this.panelBuscador.Name = "panelBuscador";
            this.panelBuscador.Size = new System.Drawing.Size(352, 312);
            this.panelBuscador.TabIndex = 35;
            // 
            // txtArbitro
            // 
            this.txtArbitro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtArbitro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtArbitro.Location = new System.Drawing.Point(630, 74);
            this.txtArbitro.Name = "txtArbitro";
            this.txtArbitro.ReadOnly = true;
            this.txtArbitro.Size = new System.Drawing.Size(158, 25);
            this.txtArbitro.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 33);
            this.button1.TabIndex = 37;
            this.button1.Text = "equipos";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnArbitro
            // 
            this.btnArbitro.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnArbitro.Location = new System.Drawing.Point(673, 52);
            this.btnArbitro.Name = "btnArbitro";
            this.btnArbitro.Size = new System.Drawing.Size(75, 20);
            this.btnArbitro.TabIndex = 38;
            this.btnArbitro.Text = "Refree";
            this.btnArbitro.UseVisualStyleBackColor = true;
            // 
            // panelAgregarArbitro
            // 
            this.panelAgregarArbitro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAgregarArbitro.Controls.Add(this.lblApellido);
            this.panelAgregarArbitro.Controls.Add(this.txtNewArbitroApellido);
            this.panelAgregarArbitro.Controls.Add(this.btnCerrarAddArbitro);
            this.panelAgregarArbitro.Controls.Add(this.lblNewArbitroTitle);
            this.panelAgregarArbitro.Controls.Add(this.label1);
            this.panelAgregarArbitro.Controls.Add(this.lblNacionalidadArbitro);
            this.panelAgregarArbitro.Controls.Add(this.lblNewNombreArbitro);
            this.panelAgregarArbitro.Controls.Add(this.btnNewArbitro);
            this.panelAgregarArbitro.Controls.Add(this.txtNewArbitroRol);
            this.panelAgregarArbitro.Controls.Add(this.txtNewArbitroNacionalidad);
            this.panelAgregarArbitro.Controls.Add(this.txtNewArbitroName);
            this.panelAgregarArbitro.Location = new System.Drawing.Point(224, 69);
            this.panelAgregarArbitro.Name = "panelAgregarArbitro";
            this.panelAgregarArbitro.Size = new System.Drawing.Size(352, 312);
            this.panelAgregarArbitro.TabIndex = 36;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(212, 63);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(54, 15);
            this.lblApellido.TabIndex = 42;
            this.lblApellido.Text = "Surname";
            // 
            // txtNewArbitroApellido
            // 
            this.txtNewArbitroApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNewArbitroApellido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNewArbitroApellido.Location = new System.Drawing.Point(178, 84);
            this.txtNewArbitroApellido.Name = "txtNewArbitroApellido";
            this.txtNewArbitroApellido.Size = new System.Drawing.Size(120, 25);
            this.txtNewArbitroApellido.TabIndex = 41;
            // 
            // btnCerrarAddArbitro
            // 
            this.btnCerrarAddArbitro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCerrarAddArbitro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarAddArbitro.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCerrarAddArbitro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCerrarAddArbitro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCerrarAddArbitro.Location = new System.Drawing.Point(325, 4);
            this.btnCerrarAddArbitro.Name = "btnCerrarAddArbitro";
            this.btnCerrarAddArbitro.Size = new System.Drawing.Size(21, 21);
            this.btnCerrarAddArbitro.TabIndex = 40;
            this.btnCerrarAddArbitro.Text = "X";
            this.btnCerrarAddArbitro.UseVisualStyleBackColor = true;
            this.btnCerrarAddArbitro.Click += new System.EventHandler(this.btnCerrarAddArbitro_Click);
            // 
            // lblNewArbitroTitle
            // 
            this.lblNewArbitroTitle.AutoSize = true;
            this.lblNewArbitroTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNewArbitroTitle.Location = new System.Drawing.Point(130, 20);
            this.lblNewArbitroTitle.Name = "lblNewArbitroTitle";
            this.lblNewArbitroTitle.Size = new System.Drawing.Size(88, 20);
            this.lblNewArbitroTitle.TabIndex = 39;
            this.lblNewArbitroTitle.Text = "Add referee";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Name of his rol";
            // 
            // lblNacionalidadArbitro
            // 
            this.lblNacionalidadArbitro.AutoSize = true;
            this.lblNacionalidadArbitro.Location = new System.Drawing.Point(139, 135);
            this.lblNacionalidadArbitro.Name = "lblNacionalidadArbitro";
            this.lblNacionalidadArbitro.Size = new System.Drawing.Size(67, 15);
            this.lblNacionalidadArbitro.TabIndex = 37;
            this.lblNacionalidadArbitro.Text = "Nacionality";
            // 
            // lblNewNombreArbitro
            // 
            this.lblNewNombreArbitro.AutoSize = true;
            this.lblNewNombreArbitro.Location = new System.Drawing.Point(87, 63);
            this.lblNewNombreArbitro.Name = "lblNewNombreArbitro";
            this.lblNewNombreArbitro.Size = new System.Drawing.Size(39, 15);
            this.lblNewNombreArbitro.TabIndex = 36;
            this.lblNewNombreArbitro.Text = "Name";
            // 
            // btnNewArbitro
            // 
            this.btnNewArbitro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnNewArbitro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewArbitro.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnNewArbitro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnNewArbitro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnNewArbitro.Location = new System.Drawing.Point(129, 273);
            this.btnNewArbitro.Name = "btnNewArbitro";
            this.btnNewArbitro.Size = new System.Drawing.Size(90, 23);
            this.btnNewArbitro.TabIndex = 35;
            this.btnNewArbitro.Text = "Add";
            this.btnNewArbitro.UseVisualStyleBackColor = true;
            this.btnNewArbitro.Click += new System.EventHandler(this.btnNewArbitro_Click);
            // 
            // txtNewArbitroRol
            // 
            this.txtNewArbitroRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNewArbitroRol.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNewArbitroRol.Location = new System.Drawing.Point(45, 228);
            this.txtNewArbitroRol.Name = "txtNewArbitroRol";
            this.txtNewArbitroRol.Size = new System.Drawing.Size(253, 25);
            this.txtNewArbitroRol.TabIndex = 34;
            // 
            // txtNewArbitroNacionalidad
            // 
            this.txtNewArbitroNacionalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNewArbitroNacionalidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNewArbitroNacionalidad.Location = new System.Drawing.Point(45, 156);
            this.txtNewArbitroNacionalidad.Name = "txtNewArbitroNacionalidad";
            this.txtNewArbitroNacionalidad.Size = new System.Drawing.Size(253, 25);
            this.txtNewArbitroNacionalidad.TabIndex = 33;
            // 
            // txtNewArbitroName
            // 
            this.txtNewArbitroName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNewArbitroName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNewArbitroName.Location = new System.Drawing.Point(45, 84);
            this.txtNewArbitroName.Name = "txtNewArbitroName";
            this.txtNewArbitroName.Size = new System.Drawing.Size(119, 25);
            this.txtNewArbitroName.TabIndex = 32;
            // 
            // btnAlineacion
            // 
            this.btnAlineacion.Location = new System.Drawing.Point(23, 175);
            this.btnAlineacion.Name = "btnAlineacion";
            this.btnAlineacion.Size = new System.Drawing.Size(128, 24);
            this.btnAlineacion.TabIndex = 39;
            this.btnAlineacion.Text = "Select alignment";
            this.btnAlineacion.UseVisualStyleBackColor = true;
            // 
            // MenuCrearEncuentro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAlineacion);
            this.Controls.Add(this.panelAgregarArbitro);
            this.Controls.Add(this.txtHoraEncuentro);
            this.Controls.Add(this.btnArbitro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelBuscador);
            this.Controls.Add(this.panelEquipos);
            this.Controls.Add(this.txtArbitro);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnEncuentroCerrar);
            this.Controls.Add(this.txtLugarEncuentro);
            this.Controls.Add(this.txtNombreEncuentro);
            this.Controls.Add(this.txtFechaEncuentro);
            this.Controls.Add(this.cbxDeporteEncuentro);
            this.Controls.Add(this.cbxClimaEncuentro);
            this.Controls.Add(this.cbxEstadoEncuentro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuCrearEncuentro";
            this.Text = "MenuCrearEncuentro";
            this.panelAgregarArbitro.ResumeLayout(false);
            this.panelAgregarArbitro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbxEstadoEncuentro;
        private ComboBox cbxClimaEncuentro;
        private ComboBox cbxDeporteEncuentro;
        private TextBox txtHoraEncuentro;
        private TextBox txtFechaEncuentro;
        private TextBox txtNombreEncuentro;
        private TextBox txtLugarEncuentro;
        private Button btnEncuentroCerrar;
        private ComboBox comboBox1;
        private Panel panelEquipos;
        private Panel panelBuscador;
        private TextBox txtArbitro;
        private Button button1;
        private Button btnArbitro;
        private Panel panelAgregarArbitro;
        private Label lblNewArbitroTitle;
        private Label label1;
        private Label lblNacionalidadArbitro;
        private Label lblNewNombreArbitro;
        private Button btnNewArbitro;
        private TextBox txtNewArbitroRol;
        private TextBox txtNewArbitroNacionalidad;
        private TextBox txtNewArbitroName;
        private Button btnCerrarAddArbitro;
        private Label lblApellido;
        private TextBox txtNewArbitroApellido;
        private Button btnAlineacion;
    }
}