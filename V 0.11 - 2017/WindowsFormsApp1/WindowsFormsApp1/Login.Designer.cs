﻿namespace Sistema_de_Resultados_Deportivos
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.llbRegistrarse = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.customtogglebutton1 = new Sistema_de_Resultados_Deportivos.CustomToggleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // llbRegistrarse
            // 
            this.llbRegistrarse.AutoSize = true;
            this.llbRegistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llbRegistrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.llbRegistrarse.Location = new System.Drawing.Point(484, 348);
            this.llbRegistrarse.Name = "llbRegistrarse";
            this.llbRegistrarse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.llbRegistrarse.Size = new System.Drawing.Size(0, 20);
            this.llbRegistrarse.TabIndex = 1;
            this.llbRegistrarse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblRegistrarse_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.linkLabel2.Location = new System.Drawing.Point(18, 348);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(0, 20);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            // 
            // btnAcceder
            // 
            this.btnAcceder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceder.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnAcceder.ForeColor = System.Drawing.Color.LightGray;
            this.btnAcceder.Location = new System.Drawing.Point(22, 261);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(222, 70);
            this.btnAcceder.TabIndex = 3;
            this.btnAcceder.UseVisualStyleBackColor = false;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContraseña.Font = new System.Drawing.Font("Century Gothic", 12.75F);
            this.txtContraseña.Location = new System.Drawing.Point(22, 159);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(546, 28);
            this.txtContraseña.TabIndex = 2;
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.CausesValidation = false;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 12.75F);
            this.txtUsuario.Location = new System.Drawing.Point(22, 108);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(546, 28);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(222, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 30);
            this.label1.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnCancelar.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancelar.Location = new System.Drawing.Point(346, 261);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(222, 70);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Century Gothic", 12.75F);
            this.txtCorreo.Location = new System.Drawing.Point(22, 58);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(546, 28);
            this.txtCorreo.TabIndex = 0;
            this.txtCorreo.Text = "Email";
            this.txtCorreo.Enter += new System.EventHandler(this.txtCorreo_Enter);
            this.txtCorreo.Leave += new System.EventHandler(this.txtCorreo_Leave);
            // 
            // customtogglebutton1
            // 
            this.customtogglebutton1.AutoSize = true;
            this.customtogglebutton1.Location = new System.Drawing.Point(150, 215);
            this.customtogglebutton1.MaximumSize = new System.Drawing.Size(45, 22);
            this.customtogglebutton1.MinimumSize = new System.Drawing.Size(39, 19);
            this.customtogglebutton1.Name = "customtogglebutton1";
            this.customtogglebutton1.OffBackColor = System.Drawing.Color.Gray;
            this.customtogglebutton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.customtogglebutton1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.customtogglebutton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.customtogglebutton1.Size = new System.Drawing.Size(39, 19);
            this.customtogglebutton1.TabIndex = 8;
            this.customtogglebutton1.UseVisualStyleBackColor = true;
            this.customtogglebutton1.CheckedChanged += new System.EventHandler(this.customToggleButton1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.label2.Location = new System.Drawing.Point(19, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 9;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCorreo);
            this.panel1.Controls.Add(this.llbRegistrarse);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.btnAcceder);
            this.panel1.Controls.Add(this.txtContraseña);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.customtogglebutton1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 378);
            this.panel1.TabIndex = 10;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 381);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    this.llbRegistrarse.Text = "Registrate";
                    this.linkLabel2.Text = "Recover password";
                    this.label2.Text = "Remember me";
                    this.btnCancelar.Text = "Cancel";
                    this.label1.Text = "Welcome";
                    this.txtUsuario.Text = "User or email";
                    this.txtContraseña.Text = "Password";
                    this.btnAcceder.Text = "Access";
                    break;
                case "ES": //Español
                    this.llbRegistrarse.Text = "Registrarse";
                    this.linkLabel2.Text = "Recuperar contraseña";
                    this.label2.Text = "Recordarme";
                    this.btnCancelar.Text = "Cancelar";
                    this.label1.Text = "Bienvenido";
                    this.txtUsuario.Text = "Usuario o email";
                    this.txtContraseña.Text = "Contraseña";
                    this.btnAcceder.Text = "Acceder";
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
                    this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    /* Botones */
                    this.btnAcceder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnAcceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnAcceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    /* Textos (Incluidos botones) */
                    this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.llbRegistrarse.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.txtContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnAcceder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    /* Botones on/off */
                    this.customtogglebutton1.OffBackColor = System.Drawing.Color.Gray;
                    this.customtogglebutton1.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.customtogglebutton1.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.customtogglebutton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    break;
                case true: //Tema oscuro
                    /* Paneles */
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    /* Botones */
                    this.btnAcceder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnAcceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnAcceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    /* Textos (Incluidos botones) */
                    this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.llbRegistrarse.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.txtContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnAcceder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    /* Botones on/off */
                    this.customtogglebutton1.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.customtogglebutton1.OffToggleColor = System.Drawing.Color.Gainsboro;
                    this.customtogglebutton1.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.customtogglebutton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
                    break;
            }
        }

        #endregion
        private System.Windows.Forms.LinkLabel llbRegistrarse;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private CustomToggleButton customtogglebutton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
