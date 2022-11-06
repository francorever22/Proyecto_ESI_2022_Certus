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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCrearEncuentro));
            this.cbxEstadoEncuentro = new System.Windows.Forms.ComboBox();
            this.cbxClimaEncuentro = new System.Windows.Forms.ComboBox();
            this.cbxDeporteEncuentro = new System.Windows.Forms.ComboBox();
            this.txtHoraEncuentro = new System.Windows.Forms.TextBox();
            this.txtFechaEncuentro = new System.Windows.Forms.TextBox();
            this.txtNombreEncuentro = new System.Windows.Forms.TextBox();
            this.txtLugarEncuentro = new System.Windows.Forms.TextBox();
            this.btnEncuentroCerrar = new System.Windows.Forms.Button();
            this.panelEquipos = new System.Windows.Forms.Panel();
            this.panelEquiposLabels = new System.Windows.Forms.Panel();
            this.lblPointsPerRound = new System.Windows.Forms.Label();
            this.lblPointsition = new System.Windows.Forms.Label();
            this.lblAlineamiento = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.panelEquiposContenedor = new System.Windows.Forms.Panel();
            this.panelBuscador = new System.Windows.Forms.Panel();
            this.txtArbitro = new System.Windows.Forms.TextBox();
            this.btnSelectParticipants = new System.Windows.Forms.Button();
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
            this.panelNuevoHito = new System.Windows.Forms.Panel();
            this.cbxNumeroRoundHito = new System.Windows.Forms.ComboBox();
            this.lblTituloHito = new System.Windows.Forms.Label();
            this.txtTituloHito = new System.Windows.Forms.TextBox();
            this.btnCerrarNewHito = new System.Windows.Forms.Button();
            this.lblNewHito = new System.Windows.Forms.Label();
            this.lblRoundHito = new System.Windows.Forms.Label();
            this.lblTiempoHito = new System.Windows.Forms.Label();
            this.btnAddHito = new System.Windows.Forms.Button();
            this.txtTiempoHito = new System.Windows.Forms.TextBox();
            this.btnNewHito = new System.Windows.Forms.Button();
            this.panelListaHitos = new System.Windows.Forms.Panel();
            this.btnCerrarHitosList = new System.Windows.Forms.Button();
            this.panelListaHitosContenedor = new System.Windows.Forms.Panel();
            this.lblHitosTitle = new System.Windows.Forms.Label();
            this.lblHitosTiempo = new System.Windows.Forms.Label();
            this.lblHitosRound = new System.Windows.Forms.Label();
            this.btnHitosList = new System.Windows.Forms.Button();
            this.btnPlusRounds = new System.Windows.Forms.Button();
            this.btnMinusRounds = new System.Windows.Forms.Button();
            this.txtCantRounds = new System.Windows.Forms.TextBox();
            this.cbxActualRound = new System.Windows.Forms.ComboBox();
            this.txtTiempoTranscurridoRound = new System.Windows.Forms.TextBox();
            this.cbxTipoEncuentro = new System.Windows.Forms.ComboBox();
            this.picReset = new System.Windows.Forms.PictureBox();
            this.btnAddEncuentro = new System.Windows.Forms.Button();
            this.lblMatchName = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblMatchLocation = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblSport = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblClima = new System.Windows.Forms.Label();
            this.lblNRound = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.lblTimeRound = new System.Windows.Forms.Label();
            this.panelEquipos.SuspendLayout();
            this.panelEquiposLabels.SuspendLayout();
            this.panelAgregarArbitro.SuspendLayout();
            this.panelNuevoHito.SuspendLayout();
            this.panelListaHitos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).BeginInit();
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
            this.cbxEstadoEncuentro.Location = new System.Drawing.Point(308, 125);
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
            this.cbxDeporteEncuentro.Location = new System.Drawing.Point(485, 75);
            this.cbxDeporteEncuentro.Name = "cbxDeporteEncuentro";
            this.cbxDeporteEncuentro.Size = new System.Drawing.Size(121, 23);
            this.cbxDeporteEncuentro.TabIndex = 3;
            // 
            // txtHoraEncuentro
            // 
            this.txtHoraEncuentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtHoraEncuentro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHoraEncuentro.ForeColor = System.Drawing.Color.DimGray;
            this.txtHoraEncuentro.Location = new System.Drawing.Point(417, 74);
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
            this.txtFechaEncuentro.Location = new System.Drawing.Point(303, 74);
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
            this.txtLugarEncuentro.Location = new System.Drawing.Point(23, 124);
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
            // panelEquipos
            // 
            this.panelEquipos.Controls.Add(this.panelEquiposLabels);
            this.panelEquipos.Controls.Add(this.panelEquiposContenedor);
            this.panelEquipos.Location = new System.Drawing.Point(23, 263);
            this.panelEquipos.Name = "panelEquipos";
            this.panelEquipos.Size = new System.Drawing.Size(469, 175);
            this.panelEquipos.TabIndex = 34;
            // 
            // panelEquiposLabels
            // 
            this.panelEquiposLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEquiposLabels.Controls.Add(this.lblPointsPerRound);
            this.panelEquiposLabels.Controls.Add(this.lblPointsition);
            this.panelEquiposLabels.Controls.Add(this.lblAlineamiento);
            this.panelEquiposLabels.Controls.Add(this.lblTeam);
            this.panelEquiposLabels.Location = new System.Drawing.Point(0, 0);
            this.panelEquiposLabels.Name = "panelEquiposLabels";
            this.panelEquiposLabels.Size = new System.Drawing.Size(469, 29);
            this.panelEquiposLabels.TabIndex = 1;
            // 
            // lblPointsPerRound
            // 
            this.lblPointsPerRound.AutoSize = true;
            this.lblPointsPerRound.Location = new System.Drawing.Point(462, 6);
            this.lblPointsPerRound.Name = "lblPointsPerRound";
            this.lblPointsPerRound.Size = new System.Drawing.Size(26, 15);
            this.lblPointsPerRound.TabIndex = 3;
            this.lblPointsPerRound.Text = "P/R";
            this.lblPointsPerRound.Visible = false;
            // 
            // lblPointsition
            // 
            this.lblPointsition.AutoSize = true;
            this.lblPointsition.Location = new System.Drawing.Point(417, 6);
            this.lblPointsition.Name = "lblPointsition";
            this.lblPointsition.Size = new System.Drawing.Size(40, 15);
            this.lblPointsition.TabIndex = 2;
            this.lblPointsition.Text = "Points";
            // 
            // lblAlineamiento
            // 
            this.lblAlineamiento.AutoSize = true;
            this.lblAlineamiento.Location = new System.Drawing.Point(313, 6);
            this.lblAlineamiento.Name = "lblAlineamiento";
            this.lblAlineamiento.Size = new System.Drawing.Size(63, 15);
            this.lblAlineamiento.TabIndex = 1;
            this.lblAlineamiento.Text = "Alignment";
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(116, 6);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(35, 15);
            this.lblTeam.TabIndex = 0;
            this.lblTeam.Text = "Team";
            // 
            // panelEquiposContenedor
            // 
            this.panelEquiposContenedor.AutoScroll = true;
            this.panelEquiposContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEquiposContenedor.Location = new System.Drawing.Point(0, 29);
            this.panelEquiposContenedor.Name = "panelEquiposContenedor";
            this.panelEquiposContenedor.Size = new System.Drawing.Size(469, 146);
            this.panelEquiposContenedor.TabIndex = 0;
            // 
            // panelBuscador
            // 
            this.panelBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBuscador.Location = new System.Drawing.Point(223, 75);
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
            // btnSelectParticipants
            // 
            this.btnSelectParticipants.Location = new System.Drawing.Point(485, 175);
            this.btnSelectParticipants.Name = "btnSelectParticipants";
            this.btnSelectParticipants.Size = new System.Drawing.Size(154, 24);
            this.btnSelectParticipants.TabIndex = 37;
            this.btnSelectParticipants.Text = "Add participant";
            this.btnSelectParticipants.UseVisualStyleBackColor = true;
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
            this.panelAgregarArbitro.Location = new System.Drawing.Point(223, 75);
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
            // panelNuevoHito
            // 
            this.panelNuevoHito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNuevoHito.Controls.Add(this.cbxNumeroRoundHito);
            this.panelNuevoHito.Controls.Add(this.lblTituloHito);
            this.panelNuevoHito.Controls.Add(this.txtTituloHito);
            this.panelNuevoHito.Controls.Add(this.btnCerrarNewHito);
            this.panelNuevoHito.Controls.Add(this.lblNewHito);
            this.panelNuevoHito.Controls.Add(this.lblRoundHito);
            this.panelNuevoHito.Controls.Add(this.lblTiempoHito);
            this.panelNuevoHito.Controls.Add(this.btnAddHito);
            this.panelNuevoHito.Controls.Add(this.txtTiempoHito);
            this.panelNuevoHito.Location = new System.Drawing.Point(223, 75);
            this.panelNuevoHito.Name = "panelNuevoHito";
            this.panelNuevoHito.Size = new System.Drawing.Size(352, 233);
            this.panelNuevoHito.TabIndex = 40;
            // 
            // cbxNumeroRoundHito
            // 
            this.cbxNumeroRoundHito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNumeroRoundHito.FormattingEnabled = true;
            this.cbxNumeroRoundHito.Location = new System.Drawing.Point(189, 85);
            this.cbxNumeroRoundHito.Name = "cbxNumeroRoundHito";
            this.cbxNumeroRoundHito.Size = new System.Drawing.Size(121, 23);
            this.cbxNumeroRoundHito.TabIndex = 43;
            // 
            // lblTituloHito
            // 
            this.lblTituloHito.AutoSize = true;
            this.lblTituloHito.Location = new System.Drawing.Point(161, 120);
            this.lblTituloHito.Name = "lblTituloHito";
            this.lblTituloHito.Size = new System.Drawing.Size(29, 15);
            this.lblTituloHito.TabIndex = 42;
            this.lblTituloHito.Text = "Title";
            // 
            // txtTituloHito
            // 
            this.txtTituloHito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTituloHito.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTituloHito.Location = new System.Drawing.Point(45, 142);
            this.txtTituloHito.Name = "txtTituloHito";
            this.txtTituloHito.Size = new System.Drawing.Size(265, 25);
            this.txtTituloHito.TabIndex = 41;
            // 
            // btnCerrarNewHito
            // 
            this.btnCerrarNewHito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCerrarNewHito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarNewHito.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCerrarNewHito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCerrarNewHito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCerrarNewHito.Location = new System.Drawing.Point(325, 4);
            this.btnCerrarNewHito.Name = "btnCerrarNewHito";
            this.btnCerrarNewHito.Size = new System.Drawing.Size(21, 21);
            this.btnCerrarNewHito.TabIndex = 40;
            this.btnCerrarNewHito.Text = "X";
            this.btnCerrarNewHito.UseVisualStyleBackColor = true;
            this.btnCerrarNewHito.Click += new System.EventHandler(this.btnCerrarNewHito_Click);
            // 
            // lblNewHito
            // 
            this.lblNewHito.AutoSize = true;
            this.lblNewHito.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNewHito.Location = new System.Drawing.Point(120, 20);
            this.lblNewHito.Name = "lblNewHito";
            this.lblNewHito.Size = new System.Drawing.Size(106, 20);
            this.lblNewHito.TabIndex = 39;
            this.lblNewHito.Text = "Add milestone";
            // 
            // lblRoundHito
            // 
            this.lblRoundHito.AutoSize = true;
            this.lblRoundHito.Location = new System.Drawing.Point(226, 62);
            this.lblRoundHito.Name = "lblRoundHito";
            this.lblRoundHito.Size = new System.Drawing.Size(42, 15);
            this.lblRoundHito.TabIndex = 37;
            this.lblRoundHito.Text = "Round";
            // 
            // lblTiempoHito
            // 
            this.lblTiempoHito.AutoSize = true;
            this.lblTiempoHito.Location = new System.Drawing.Point(89, 63);
            this.lblTiempoHito.Name = "lblTiempoHito";
            this.lblTiempoHito.Size = new System.Drawing.Size(33, 15);
            this.lblTiempoHito.TabIndex = 36;
            this.lblTiempoHito.Text = "Time";
            // 
            // btnAddHito
            // 
            this.btnAddHito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAddHito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHito.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddHito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAddHito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAddHito.Location = new System.Drawing.Point(129, 188);
            this.btnAddHito.Name = "btnAddHito";
            this.btnAddHito.Size = new System.Drawing.Size(90, 23);
            this.btnAddHito.TabIndex = 35;
            this.btnAddHito.Text = "Add";
            this.btnAddHito.UseVisualStyleBackColor = true;
            this.btnAddHito.Click += new System.EventHandler(this.btnAddHito_Click);
            // 
            // txtTiempoHito
            // 
            this.txtTiempoHito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTiempoHito.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTiempoHito.Location = new System.Drawing.Point(45, 84);
            this.txtTiempoHito.Name = "txtTiempoHito";
            this.txtTiempoHito.Size = new System.Drawing.Size(119, 25);
            this.txtTiempoHito.TabIndex = 32;
            // 
            // btnNewHito
            // 
            this.btnNewHito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewHito.Location = new System.Drawing.Point(23, 222);
            this.btnNewHito.Name = "btnNewHito";
            this.btnNewHito.Size = new System.Drawing.Size(184, 24);
            this.btnNewHito.TabIndex = 41;
            this.btnNewHito.Text = "New milestone for this round";
            this.btnNewHito.UseVisualStyleBackColor = true;
            this.btnNewHito.Click += new System.EventHandler(this.btnNewHito_Click);
            // 
            // panelListaHitos
            // 
            this.panelListaHitos.Controls.Add(this.btnCerrarHitosList);
            this.panelListaHitos.Controls.Add(this.panelListaHitosContenedor);
            this.panelListaHitos.Controls.Add(this.lblHitosTitle);
            this.panelListaHitos.Controls.Add(this.lblHitosTiempo);
            this.panelListaHitos.Controls.Add(this.lblHitosRound);
            this.panelListaHitos.Location = new System.Drawing.Point(191, 38);
            this.panelListaHitos.Name = "panelListaHitos";
            this.panelListaHitos.Size = new System.Drawing.Size(417, 376);
            this.panelListaHitos.TabIndex = 42;
            // 
            // btnCerrarHitosList
            // 
            this.btnCerrarHitosList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCerrarHitosList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarHitosList.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCerrarHitosList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCerrarHitosList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCerrarHitosList.Location = new System.Drawing.Point(393, 3);
            this.btnCerrarHitosList.Name = "btnCerrarHitosList";
            this.btnCerrarHitosList.Size = new System.Drawing.Size(21, 21);
            this.btnCerrarHitosList.TabIndex = 41;
            this.btnCerrarHitosList.Text = "X";
            this.btnCerrarHitosList.UseVisualStyleBackColor = true;
            this.btnCerrarHitosList.Click += new System.EventHandler(this.btnCerrarHitosList_Click);
            // 
            // panelListaHitosContenedor
            // 
            this.panelListaHitosContenedor.Location = new System.Drawing.Point(2, 26);
            this.panelListaHitosContenedor.Name = "panelListaHitosContenedor";
            this.panelListaHitosContenedor.Size = new System.Drawing.Size(415, 351);
            this.panelListaHitosContenedor.TabIndex = 3;
            // 
            // lblHitosTitle
            // 
            this.lblHitosTitle.AutoSize = true;
            this.lblHitosTitle.Location = new System.Drawing.Point(245, 8);
            this.lblHitosTitle.Name = "lblHitosTitle";
            this.lblHitosTitle.Size = new System.Drawing.Size(29, 15);
            this.lblHitosTitle.TabIndex = 2;
            this.lblHitosTitle.Text = "Title";
            // 
            // lblHitosTiempo
            // 
            this.lblHitosTiempo.AutoSize = true;
            this.lblHitosTiempo.Location = new System.Drawing.Point(73, 8);
            this.lblHitosTiempo.Name = "lblHitosTiempo";
            this.lblHitosTiempo.Size = new System.Drawing.Size(33, 15);
            this.lblHitosTiempo.TabIndex = 1;
            this.lblHitosTiempo.Text = "Time";
            // 
            // lblHitosRound
            // 
            this.lblHitosRound.AutoSize = true;
            this.lblHitosRound.Location = new System.Drawing.Point(0, 8);
            this.lblHitosRound.Name = "lblHitosRound";
            this.lblHitosRound.Size = new System.Drawing.Size(42, 15);
            this.lblHitosRound.TabIndex = 0;
            this.lblHitosRound.Text = "Round";
            // 
            // btnHitosList
            // 
            this.btnHitosList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHitosList.Location = new System.Drawing.Point(669, 175);
            this.btnHitosList.Name = "btnHitosList";
            this.btnHitosList.Size = new System.Drawing.Size(119, 24);
            this.btnHitosList.TabIndex = 43;
            this.btnHitosList.Text = "Milestones list";
            this.btnHitosList.UseVisualStyleBackColor = true;
            this.btnHitosList.Click += new System.EventHandler(this.btnHitosList_Click);
            // 
            // btnPlusRounds
            // 
            this.btnPlusRounds.Location = new System.Drawing.Point(234, 176);
            this.btnPlusRounds.Name = "btnPlusRounds";
            this.btnPlusRounds.Size = new System.Drawing.Size(20, 20);
            this.btnPlusRounds.TabIndex = 44;
            this.btnPlusRounds.Text = "+";
            this.btnPlusRounds.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPlusRounds.UseVisualStyleBackColor = true;
            this.btnPlusRounds.Click += new System.EventHandler(this.btnPlusRounds_Click);
            // 
            // btnMinusRounds
            // 
            this.btnMinusRounds.Location = new System.Drawing.Point(175, 176);
            this.btnMinusRounds.Name = "btnMinusRounds";
            this.btnMinusRounds.Size = new System.Drawing.Size(20, 20);
            this.btnMinusRounds.TabIndex = 45;
            this.btnMinusRounds.Text = "-";
            this.btnMinusRounds.UseVisualStyleBackColor = true;
            this.btnMinusRounds.Click += new System.EventHandler(this.btnMinusRounds_Click);
            // 
            // txtCantRounds
            // 
            this.txtCantRounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCantRounds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCantRounds.Location = new System.Drawing.Point(201, 174);
            this.txtCantRounds.Name = "txtCantRounds";
            this.txtCantRounds.ReadOnly = true;
            this.txtCantRounds.Size = new System.Drawing.Size(27, 25);
            this.txtCantRounds.TabIndex = 46;
            this.txtCantRounds.Text = "1";
            this.txtCantRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxActualRound
            // 
            this.cbxActualRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActualRound.FormattingEnabled = true;
            this.cbxActualRound.Location = new System.Drawing.Point(280, 175);
            this.cbxActualRound.Name = "cbxActualRound";
            this.cbxActualRound.Size = new System.Drawing.Size(87, 23);
            this.cbxActualRound.TabIndex = 47;
            this.cbxActualRound.SelectedIndexChanged += new System.EventHandler(this.cbxActualRound_SelectedIndexChanged);
            // 
            // txtTiempoTranscurridoRound
            // 
            this.txtTiempoTranscurridoRound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTiempoTranscurridoRound.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTiempoTranscurridoRound.ForeColor = System.Drawing.Color.DimGray;
            this.txtTiempoTranscurridoRound.Location = new System.Drawing.Point(393, 175);
            this.txtTiempoTranscurridoRound.Name = "txtTiempoTranscurridoRound";
            this.txtTiempoTranscurridoRound.Size = new System.Drawing.Size(60, 25);
            this.txtTiempoTranscurridoRound.TabIndex = 48;
            this.txtTiempoTranscurridoRound.Text = "XX:XX:XX";
            // 
            // cbxTipoEncuentro
            // 
            this.cbxTipoEncuentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoEncuentro.FormattingEnabled = true;
            this.cbxTipoEncuentro.Items.AddRange(new object[] {
            "Points",
            "Sets",
            "Position",
            "Win/Lose"});
            this.cbxTipoEncuentro.Location = new System.Drawing.Point(23, 175);
            this.cbxTipoEncuentro.Name = "cbxTipoEncuentro";
            this.cbxTipoEncuentro.Size = new System.Drawing.Size(138, 23);
            this.cbxTipoEncuentro.TabIndex = 49;
            this.cbxTipoEncuentro.SelectedIndexChanged += new System.EventHandler(this.cbxTipoEncuentro_SelectedIndexChanged);
            // 
            // picReset
            // 
            this.picReset.BackgroundImage = global::SRD_BackOffice.Properties.Resources.recargar;
            this.picReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picReset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picReset.Location = new System.Drawing.Point(471, 227);
            this.picReset.Name = "picReset";
            this.picReset.Size = new System.Drawing.Size(20, 20);
            this.picReset.TabIndex = 50;
            this.picReset.TabStop = false;
            // 
            // btnAddEncuentro
            // 
            this.btnAddEncuentro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddEncuentro.Location = new System.Drawing.Point(574, 407);
            this.btnAddEncuentro.Name = "btnAddEncuentro";
            this.btnAddEncuentro.Size = new System.Drawing.Size(154, 31);
            this.btnAddEncuentro.TabIndex = 51;
            this.btnAddEncuentro.Text = "Add";
            this.btnAddEncuentro.UseVisualStyleBackColor = true;
            this.btnAddEncuentro.Click += new System.EventHandler(this.btnAddEncuentro_Click);
            // 
            // lblMatchName
            // 
            this.lblMatchName.AutoSize = true;
            this.lblMatchName.Location = new System.Drawing.Point(130, 52);
            this.lblMatchName.Name = "lblMatchName";
            this.lblMatchName.Size = new System.Drawing.Size(0, 15);
            this.lblMatchName.TabIndex = 52;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(329, 52);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 15);
            this.lblFecha.TabIndex = 53;
            // 
            // lblMatchLocation
            // 
            this.lblMatchLocation.AutoSize = true;
            this.lblMatchLocation.Location = new System.Drawing.Point(123, 106);
            this.lblMatchLocation.Name = "lblMatchLocation";
            this.lblMatchLocation.Size = new System.Drawing.Size(0, 15);
            this.lblMatchLocation.TabIndex = 55;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(383, 106);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 15);
            this.lblEstado.TabIndex = 57;
            // 
            // lblSport
            // 
            this.lblSport.AutoSize = true;
            this.lblSport.Location = new System.Drawing.Point(526, 52);
            this.lblSport.Name = "lblSport";
            this.lblSport.Size = new System.Drawing.Size(0, 15);
            this.lblSport.TabIndex = 54;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Location = new System.Drawing.Point(420, 52);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(0, 15);
            this.lblHour.TabIndex = 58;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(77, 156);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(0, 15);
            this.lblTipo.TabIndex = 59;
            // 
            // lblClima
            // 
            this.lblClima.AutoSize = true;
            this.lblClima.Location = new System.Drawing.Point(573, 106);
            this.lblClima.Name = "lblClima";
            this.lblClima.Size = new System.Drawing.Size(0, 15);
            this.lblClima.TabIndex = 60;
            // 
            // lblNRound
            // 
            this.lblNRound.AutoSize = true;
            this.lblNRound.Location = new System.Drawing.Point(165, 156);
            this.lblNRound.Name = "lblNRound";
            this.lblNRound.Size = new System.Drawing.Size(0, 15);
            this.lblNRound.TabIndex = 61;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(300, 156);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(0, 15);
            this.lblRound.TabIndex = 62;
            // 
            // lblTimeRound
            // 
            this.lblTimeRound.AutoSize = true;
            this.lblTimeRound.Location = new System.Drawing.Point(378, 156);
            this.lblTimeRound.Name = "lblTimeRound";
            this.lblTimeRound.Size = new System.Drawing.Size(0, 15);
            this.lblTimeRound.TabIndex = 63;
            // 
            // MenuCrearEncuentro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelAgregarArbitro);
            this.Controls.Add(this.panelListaHitos);
            this.Controls.Add(this.panelNuevoHito);
            this.Controls.Add(this.panelBuscador);
            this.Controls.Add(this.lblTimeRound);
            this.Controls.Add(this.lblMatchLocation);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblSport);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.lblClima);
            this.Controls.Add(this.lblNRound);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lblMatchName);
            this.Controls.Add(this.cbxTipoEncuentro);
            this.Controls.Add(this.txtTiempoTranscurridoRound);
            this.Controls.Add(this.btnAddEncuentro);
            this.Controls.Add(this.cbxActualRound);
            this.Controls.Add(this.picReset);
            this.Controls.Add(this.txtCantRounds);
            this.Controls.Add(this.btnMinusRounds);
            this.Controls.Add(this.btnPlusRounds);
            this.Controls.Add(this.cbxEstadoEncuentro);
            this.Controls.Add(this.cbxDeporteEncuentro);
            this.Controls.Add(this.txtFechaEncuentro);
            this.Controls.Add(this.txtHoraEncuentro);
            this.Controls.Add(this.btnNewHito);
            this.Controls.Add(this.btnHitosList);
            this.Controls.Add(this.btnArbitro);
            this.Controls.Add(this.btnSelectParticipants);
            this.Controls.Add(this.panelEquipos);
            this.Controls.Add(this.txtArbitro);
            this.Controls.Add(this.btnEncuentroCerrar);
            this.Controls.Add(this.txtLugarEncuentro);
            this.Controls.Add(this.txtNombreEncuentro);
            this.Controls.Add(this.cbxClimaEncuentro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuCrearEncuentro";
            this.panelEquipos.ResumeLayout(false);
            this.panelEquiposLabels.ResumeLayout(false);
            this.panelEquiposLabels.PerformLayout();
            this.panelAgregarArbitro.ResumeLayout(false);
            this.panelAgregarArbitro.PerformLayout();
            this.panelNuevoHito.ResumeLayout(false);
            this.panelNuevoHito.PerformLayout();
            this.panelListaHitos.ResumeLayout(false);
            this.panelListaHitos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).EndInit();
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
        private Panel panelEquipos;
        private Panel panelBuscador;
        private TextBox txtArbitro;
        private Button btnSelectParticipants;
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
        private Panel panelNuevoHito;
        private ComboBox cbxNumeroRoundHito;
        private Label lblTituloHito;
        private TextBox txtTituloHito;
        private Button btnCerrarNewHito;
        private Label lblNewHito;
        private Label lblRoundHito;
        private Label lblTiempoHito;
        private Button btnAddHito;
        private TextBox txtTiempoHito;
        private Button btnNewHito;
        private Panel panelListaHitos;
        private Panel panelListaHitosContenedor;
        private Label lblHitosTitle;
        private Label lblHitosTiempo;
        private Label lblHitosRound;
        private Button btnHitosList;
        private Button btnPlusRounds;
        private Button btnMinusRounds;
        private TextBox txtCantRounds;
        private ComboBox cbxActualRound;
        private TextBox txtTiempoTranscurridoRound;
        private ComboBox cbxTipoEncuentro;
        private Panel panelEquiposLabels;
        private Label lblPointsPerRound;
        private Label lblPointsition;
        private Label lblAlineamiento;
        private Label lblTeam;
        private Panel panelEquiposContenedor;
        private Button btnCerrarHitosList;
        private PictureBox picReset;
        private Button btnAddEncuentro;
        private Label lblMatchName;
        private Label lblFecha;
        private Label lblMatchLocation;
        private Label lblEstado;
        private Label lblSport;
        private Label lblHour;
        private Label lblTipo;
        private Label lblClima;
        private Label lblNRound;
        private Label lblRound;
        private Label lblTimeRound;
    }
}