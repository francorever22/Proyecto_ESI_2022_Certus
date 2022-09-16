﻿using System.Windows.Forms;

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
            this.lblLenguaje.Font = new System.Drawing.Font("Gill Sans MT", 12F);
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
            this.cbxLenguaje.Size = new System.Drawing.Size(121, 21);
            this.cbxLenguaje.TabIndex = 0;
            this.cbxLenguaje.SelectedIndexChanged += new System.EventHandler(this.cbxLenguaje_SelectedIndexChanged);
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Font = new System.Drawing.Font("Gill Sans MT", 12F);
            this.lblTema.Location = new System.Drawing.Point(17, 124);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(0, 23);
            this.lblTema.TabIndex = 3;
            // 
            // lblMinimizarlabandeja
            // 
            this.lblMinimizarlabandeja.AutoSize = true;
            this.lblMinimizarlabandeja.Font = new System.Drawing.Font("Gill Sans MT", 12F);
            this.lblMinimizarlabandeja.Location = new System.Drawing.Point(17, 177);
            this.lblMinimizarlabandeja.Name = "lblMinimizarlabandeja";
            this.lblMinimizarlabandeja.Size = new System.Drawing.Size(0, 23);
            this.lblMinimizarlabandeja.TabIndex = 4;
            // 
            // lblIniciarapp
            // 
            this.lblIniciarapp.AutoSize = true;
            this.lblIniciarapp.Font = new System.Drawing.Font("Gill Sans MT", 12F);
            this.lblIniciarapp.Location = new System.Drawing.Point(17, 234);
            this.lblIniciarapp.Name = "lblIniciarapp";
            this.lblIniciarapp.Size = new System.Drawing.Size(0, 23);
            this.lblIniciarapp.TabIndex = 5;
            // 
            // lblactivarNotificaciones
            // 
            this.lblactivarNotificaciones.AutoSize = true;
            this.lblactivarNotificaciones.Font = new System.Drawing.Font("Gill Sans MT", 12F);
            this.lblactivarNotificaciones.Location = new System.Drawing.Point(17, 291);
            this.lblactivarNotificaciones.Name = "lblactivarNotificaciones";
            this.lblactivarNotificaciones.Size = new System.Drawing.Size(0, 23);
            this.lblactivarNotificaciones.TabIndex = 6;
            // 
            // tglTema
            // 
            this.tglTema.Location = new System.Drawing.Point(270, 124);
            this.tglTema.MinimumSize = new System.Drawing.Size(39, 19);
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
            this.tglTray.Location = new System.Drawing.Point(270, 180);
            this.tglTray.MinimumSize = new System.Drawing.Size(39, 19);
            this.tglTray.Name = "tglTray";
            this.tglTray.OffBackColor = System.Drawing.Color.Gray;
            this.tglTray.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tglTray.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tglTray.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tglTray.Size = new System.Drawing.Size(45, 22);
            this.tglTray.TabIndex = 8;
            this.tglTray.UseVisualStyleBackColor = true;
            this.tglTray.CheckedChanged += new System.EventHandler(this.tglTray_CheckedChanged);
            // 
            // tglInicio
            // 
            this.tglInicio.Location = new System.Drawing.Point(270, 237);
            this.tglInicio.MinimumSize = new System.Drawing.Size(39, 19);
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
            this.tglNotificaciones.Location = new System.Drawing.Point(270, 291);
            this.tglNotificaciones.MinimumSize = new System.Drawing.Size(39, 19);
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
            this.lblConfiguraciones.Font = new System.Drawing.Font("Century Gothic", 14.25F);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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