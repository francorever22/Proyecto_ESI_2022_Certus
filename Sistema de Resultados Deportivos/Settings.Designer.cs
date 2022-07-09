namespace Sistema_de_Resultados_Deportivos
{
    partial class Settings
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
            this.lblLenguaje = new System.Windows.Forms.Label();
            this.cbxLenguaje = new System.Windows.Forms.ComboBox();
            this.lblTema = new System.Windows.Forms.Label();
            this.lblMinimizarlabandeja = new System.Windows.Forms.Label();
            this.lblIniciarapp = new System.Windows.Forms.Label();
            this.lblactivarNotificaciones = new System.Windows.Forms.Label();
            this.tglTema = new Sistema_de_Resultados_Deportivos.CustomToggleButton();
            this.tglTray = new Sistema_de_Resultados_Deportivos.CustomToggleButton();
            this.tglInicio = new Sistema_de_Resultados_Deportivos.CustomToggleButton();
            this.tglNotificaciones = new Sistema_de_Resultados_Deportivos.CustomToggleButton();
            this.lblConfiguraciones = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrarSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLenguaje
            // 
            this.lblLenguaje.AutoSize = true;
            this.lblLenguaje.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLenguaje.Location = new System.Drawing.Point(17, 75);
            this.lblLenguaje.Name = "lblLenguaje";
            this.lblLenguaje.Size = new System.Drawing.Size(0, 23);
            this.lblLenguaje.TabIndex = 0;
            // 
            // cbxLenguaje
            // 
            this.cbxLenguaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLenguaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxLenguaje.FormattingEnabled = true;
            this.cbxLenguaje.Items.AddRange(new object[] {
            "EN",
            "ES"});
            this.cbxLenguaje.Location = new System.Drawing.Point(194, 75);
            this.cbxLenguaje.Name = "cbxLenguaje";
            this.cbxLenguaje.Size = new System.Drawing.Size(121, 23);
            this.cbxLenguaje.TabIndex = 0;
            this.cbxLenguaje.SelectedIndexChanged += new System.EventHandler(this.cbxLenguaje_SelectedIndexChanged);
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTema.Location = new System.Drawing.Point(17, 124);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(0, 23);
            this.lblTema.TabIndex = 3;
            // 
            // lblMinimizarlabandeja
            // 
            this.lblMinimizarlabandeja.AutoSize = true;
            this.lblMinimizarlabandeja.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMinimizarlabandeja.Location = new System.Drawing.Point(17, 177);
            this.lblMinimizarlabandeja.Name = "lblMinimizarlabandeja";
            this.lblMinimizarlabandeja.Size = new System.Drawing.Size(0, 23);
            this.lblMinimizarlabandeja.TabIndex = 4;
            // 
            // lblIniciarapp
            // 
            this.lblIniciarapp.AutoSize = true;
            this.lblIniciarapp.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIniciarapp.Location = new System.Drawing.Point(17, 234);
            this.lblIniciarapp.Name = "lblIniciarapp";
            this.lblIniciarapp.Size = new System.Drawing.Size(0, 23);
            this.lblIniciarapp.TabIndex = 5;
            // 
            // lblactivarNotificaciones
            // 
            this.lblactivarNotificaciones.AutoSize = true;
            this.lblactivarNotificaciones.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblactivarNotificaciones.Location = new System.Drawing.Point(17, 291);
            this.lblactivarNotificaciones.Name = "lblactivarNotificaciones";
            this.lblactivarNotificaciones.Size = new System.Drawing.Size(0, 23);
            this.lblactivarNotificaciones.TabIndex = 6;
            // 
            // tglTema
            // 
            this.tglTema.AutoSize = true;
            this.tglTema.Location = new System.Drawing.Point(270, 124);
            this.tglTema.MinimumSize = new System.Drawing.Size(45, 22);
            this.tglTema.Name = "tglTema";
            this.tglTema.OffBackColor = System.Drawing.Color.Gray;
            this.tglTema.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tglTema.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tglTema.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tglTema.Size = new System.Drawing.Size(45, 22);
            this.tglTema.TabIndex = 7;
            this.tglTema.UseVisualStyleBackColor = true;
            this.tglTema.CheckedChanged += new System.EventHandler(this.tglTema_CheckedChanged);
            // 
            // tglTray
            // 
            this.tglTray.AutoSize = true;
            this.tglTray.Location = new System.Drawing.Point(270, 180);
            this.tglTray.MinimumSize = new System.Drawing.Size(45, 22);
            this.tglTray.Name = "tglTray";
            this.tglTray.OffBackColor = System.Drawing.Color.Gray;
            this.tglTray.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tglTray.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tglTray.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tglTray.Size = new System.Drawing.Size(45, 22);
            this.tglTray.TabIndex = 8;
            this.tglTray.UseVisualStyleBackColor = true;
            // 
            // tglInicio
            // 
            this.tglInicio.AutoSize = true;
            this.tglInicio.Location = new System.Drawing.Point(270, 237);
            this.tglInicio.MinimumSize = new System.Drawing.Size(45, 22);
            this.tglInicio.Name = "tglInicio";
            this.tglInicio.OffBackColor = System.Drawing.Color.Gray;
            this.tglInicio.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tglInicio.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tglInicio.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tglInicio.Size = new System.Drawing.Size(45, 22);
            this.tglInicio.TabIndex = 9;
            this.tglInicio.UseVisualStyleBackColor = true;
            // 
            // tglNotificaciones
            // 
            this.tglNotificaciones.AutoSize = true;
            this.tglNotificaciones.Location = new System.Drawing.Point(270, 291);
            this.tglNotificaciones.MinimumSize = new System.Drawing.Size(45, 22);
            this.tglNotificaciones.Name = "tglNotificaciones";
            this.tglNotificaciones.OffBackColor = System.Drawing.Color.Gray;
            this.tglNotificaciones.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tglNotificaciones.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tglNotificaciones.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tglNotificaciones.Size = new System.Drawing.Size(45, 22);
            this.tglNotificaciones.TabIndex = 10;
            this.tglNotificaciones.UseVisualStyleBackColor = true;
            // 
            // lblConfiguraciones
            // 
            this.lblConfiguraciones.AutoSize = true;
            this.lblConfiguraciones.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfiguraciones.Location = new System.Drawing.Point(0, 0);
            this.lblConfiguraciones.Name = "lblConfiguraciones";
            this.lblConfiguraciones.Size = new System.Drawing.Size(0, 22);
            this.lblConfiguraciones.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(108, 353);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 48);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.btnCerrarSettings.Click += new System.EventHandler(this.btnCerrarSettings_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 423);
            this.Controls.Add(this.btnCerrarSettings);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblConfiguraciones);
            this.Controls.Add(this.tglNotificaciones);
            this.Controls.Add(this.tglInicio);
            this.Controls.Add(this.tglTray);
            this.Controls.Add(this.tglTema);
            this.Controls.Add(this.lblactivarNotificaciones);
            this.Controls.Add(this.lblIniciarapp);
            this.Controls.Add(this.lblMinimizarlabandeja);
            this.Controls.Add(this.lblTema);
            this.Controls.Add(this.cbxLenguaje);
            this.Controls.Add(this.lblLenguaje);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    this.btnGuardar.Text = "Save changes";
                    this.lblConfiguraciones.Text = "Settings";
                    this.lblConfiguraciones.Location = new System.Drawing.Point(136, 9);
                    this.lblactivarNotificaciones.Text = "Activate notifications";
                    this.lblIniciarapp.Text = "Open application on pc startup";
                    this.lblMinimizarlabandeja.Text = "Minimize to tray";
                    this.lblLenguaje.Text = "Language";
                    this.lblTema.Text = "Dark theme";
                    break;
                case "ES": //Español
                    this.btnGuardar.Text = "Guardar cambios";
                    this.lblConfiguraciones.Text = "Configuraciones";
                    this.lblConfiguraciones.Location = new System.Drawing.Point(92, 9);
                    this.lblactivarNotificaciones.Text = "Activar notificaciones";
                    this.lblIniciarapp.Text = "Iniciar app al iniciarse el sistema";
                    this.lblMinimizarlabandeja.Text = "Minimizar a la bandeja";
                    this.lblLenguaje.Text = "Lenguaje";
                    this.lblTema.Text = "Tema oscuro";
                    break;
            }
        }

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            switch (AjustesDeUsuario.darkTheme)
            {
                case false: //Tema claro
                    /* Paneles */
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    /* Botones */
                    this.btnCerrarSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnCerrarSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnCerrarSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    /* Textos (Incluidos botones) */
                    this.btnCerrarSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.lblLenguaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.lblMinimizarlabandeja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.lblTema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.lblConfiguraciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.lblactivarNotificaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.lblIniciarapp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.cbxLenguaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.cbxLenguaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    /* Botones on/off */
                    this.tglTema.OffBackColor = System.Drawing.Color.Gray;
                    this.tglTema.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglTema.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.tglTema.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    this.tglTray.OffBackColor = System.Drawing.Color.Gray;
                    this.tglTray.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglTray.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.tglTray.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    this.tglInicio.OffBackColor = System.Drawing.Color.Gray;
                    this.tglInicio.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglInicio.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.tglInicio.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    this.tglNotificaciones.OffBackColor = System.Drawing.Color.Gray;
                    this.tglNotificaciones.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglNotificaciones.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.tglNotificaciones.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    break;
                case true: //Tema oscuro
                    /* Paneles */
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    /* Botones */
                    this.btnCerrarSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnCerrarSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnCerrarSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    /* Textos (Incluidos botones) */
                    this.btnCerrarSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.lblLenguaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.lblMinimizarlabandeja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.lblTema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.lblConfiguraciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.lblactivarNotificaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.lblIniciarapp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.cbxLenguaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.cbxLenguaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    /* Botones on/off */
                    this.tglTema.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.tglTema.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglTema.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.tglTema.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    this.tglTray.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.tglTray.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglTray.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.tglTray.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    this.tglInicio.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.tglInicio.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglInicio.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.tglInicio.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    this.tglNotificaciones.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.tglNotificaciones.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.tglNotificaciones.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.tglNotificaciones.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    break;
            }
        }

        #endregion

        private Label lblLenguaje;
        private ComboBox cbxLenguaje;
        private Label lblTema;
        private Label lblMinimizarlabandeja;
        private Label lblIniciarapp;
        private Label lblactivarNotificaciones;
        private CustomToggleButton tglTema;
        private CustomToggleButton tglTray;
        private CustomToggleButton tglInicio;
        private CustomToggleButton tglNotificaciones;
        private Label lblConfiguraciones;
        private Button btnGuardar;
        private Button btnCerrarSettings;
    }
}