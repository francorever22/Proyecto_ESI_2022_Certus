using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    partial class BuscadorDeEncuentros
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
            this.panelBuscador = new System.Windows.Forms.Panel();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.mtcFechasEventos = new System.Windows.Forms.MonthCalendar();
            this.panelEncuentros = new System.Windows.Forms.Panel();
            this.panelDiferenciador = new System.Windows.Forms.Panel();
            this.btnCalendario = new System.Windows.Forms.Button();
            this.btnProximamente = new System.Windows.Forms.Button();
            this.btnTerminados = new System.Windows.Forms.Button();
            this.btnEnVivo = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.panelBuscador.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.panelDiferenciador.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBuscador
            // 
            this.panelBuscador.Controls.Add(this.txtBuscador);
            this.panelBuscador.Controls.Add(this.btnBuscar);
            this.panelBuscador.Location = new System.Drawing.Point(91, 22);
            this.panelBuscador.Name = "panelBuscador";
            this.panelBuscador.Size = new System.Drawing.Size(541, 27);
            this.panelBuscador.TabIndex = 0;
            // 
            // txtBuscador
            // 
            this.txtBuscador.AcceptsReturn = true;
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscador.Location = new System.Drawing.Point(0, 0);
            this.txtBuscador.MaximumSize = new System.Drawing.Size(514, 23);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(514, 20);
            this.txtBuscador.TabIndex = 1;
            this.txtBuscador.WordWrap = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(514, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(27, 27);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // panelTabla
            // 
            this.panelTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTabla.Controls.Add(this.mtcFechasEventos);
            this.panelTabla.Controls.Add(this.panelEncuentros);
            this.panelTabla.Controls.Add(this.panelDiferenciador);
            this.panelTabla.Location = new System.Drawing.Point(0, 75);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(724, 477);
            this.panelTabla.TabIndex = 1;
            // 
            // mtcFechasEventos
            // 
            this.mtcFechasEventos.Location = new System.Drawing.Point(512, 27);
            this.mtcFechasEventos.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.mtcFechasEventos.Name = "mtcFechasEventos";
            this.mtcFechasEventos.TabIndex = 0;
            this.mtcFechasEventos.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mtcFechasEventos_DateChanged);
            // 
            // panelEncuentros
            // 
            this.panelEncuentros.AutoScroll = true;
            this.panelEncuentros.Location = new System.Drawing.Point(0, 28);
            this.panelEncuentros.Name = "panelEncuentros";
            this.panelEncuentros.Size = new System.Drawing.Size(722, 448);
            this.panelEncuentros.TabIndex = 1;
            // 
            // panelDiferenciador
            // 
            this.panelDiferenciador.Controls.Add(this.btnCalendario);
            this.panelDiferenciador.Controls.Add(this.btnProximamente);
            this.panelDiferenciador.Controls.Add(this.btnTerminados);
            this.panelDiferenciador.Controls.Add(this.btnEnVivo);
            this.panelDiferenciador.Controls.Add(this.btnTodos);
            this.panelDiferenciador.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDiferenciador.Location = new System.Drawing.Point(0, 0);
            this.panelDiferenciador.Name = "panelDiferenciador";
            this.panelDiferenciador.Size = new System.Drawing.Size(722, 27);
            this.panelDiferenciador.TabIndex = 0;
            // 
            // btnCalendario
            // 
            this.btnCalendario.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCalendario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendario.Location = new System.Drawing.Point(576, 0);
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Size = new System.Drawing.Size(148, 27);
            this.btnCalendario.TabIndex = 4;
            this.btnCalendario.UseVisualStyleBackColor = true;
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            // 
            // btnProximamente
            // 
            this.btnProximamente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProximamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximamente.Location = new System.Drawing.Point(432, 0);
            this.btnProximamente.Name = "btnProximamente";
            this.btnProximamente.Size = new System.Drawing.Size(144, 27);
            this.btnProximamente.TabIndex = 3;
            this.btnProximamente.UseVisualStyleBackColor = true;
            // 
            // btnTerminados
            // 
            this.btnTerminados.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTerminados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminados.Location = new System.Drawing.Point(288, 0);
            this.btnTerminados.Name = "btnTerminados";
            this.btnTerminados.Size = new System.Drawing.Size(144, 27);
            this.btnTerminados.TabIndex = 2;
            this.btnTerminados.UseVisualStyleBackColor = true;
            // 
            // btnEnVivo
            // 
            this.btnEnVivo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEnVivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnVivo.Location = new System.Drawing.Point(144, 0);
            this.btnEnVivo.Name = "btnEnVivo";
            this.btnEnVivo.Size = new System.Drawing.Size(144, 27);
            this.btnEnVivo.TabIndex = 1;
            this.btnEnVivo.UseVisualStyleBackColor = true;
            // 
            // btnTodos
            // 
            this.btnTodos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodos.Location = new System.Drawing.Point(0, 0);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(144, 27);
            this.btnTodos.TabIndex = 0;
            this.btnTodos.UseVisualStyleBackColor = true;
            // 
            // BuscadorDeEncuentros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 552);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelBuscador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscadorDeEncuentros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panelBuscador.ResumeLayout(false);
            this.panelBuscador.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            this.panelDiferenciador.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    this.btnProximamente.Text = "Coming soon";
                    this.btnTerminados.Text = "Finished";
                    this.btnEnVivo.Text = "Live";
                    this.btnTodos.Text = "All";
                    break;
                case "ES": //Español
                    this.btnProximamente.Text = "Proximamente";
                    this.btnTerminados.Text = "Terminados";
                    this.btnEnVivo.Text = "En vivo";
                    this.btnTodos.Text = "Todos";
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
                    this.panelBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    this.panelDiferenciador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    this.panelEncuentros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    this.panelTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
                    /* Botones */
                    this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    this.btnCalendario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnCalendario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnCalendario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    this.btnEnVivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnEnVivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnEnVivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    this.btnProximamente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnProximamente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnProximamente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    this.btnTerminados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnTerminados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnTerminados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    this.btnTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.btnTodos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    this.btnTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                    /* Textos (Incluidos botones) */
                    this.txtBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    this.txtBuscador.ForeColor = System.Drawing.Color.Black;
                    this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnCalendario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnEnVivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnProximamente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnTerminados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    this.btnTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
                    /* Imagenes */
                    this.btnBuscar.Image = global::WindowsFormsApp1.Properties.Resources.lupa1;
                    break;
                case true: //Tema oscuro
                    /* Paneles */
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    this.panelBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    this.panelDiferenciador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    this.panelEncuentros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    this.panelTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
                    /* Botones */
                    this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    this.btnCalendario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnCalendario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnCalendario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    this.btnEnVivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnEnVivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnEnVivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    this.btnProximamente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnProximamente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnProximamente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    this.btnTerminados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnTerminados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnTerminados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    this.btnTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.btnTodos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    this.btnTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    /* Textos (Incluidos botones) */
                    this.txtBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                    this.txtBuscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnCalendario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnEnVivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnProximamente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnTerminados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    this.btnTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                    /* Imagenes */
                    this.btnBuscar.Image = global::WindowsFormsApp1.Properties.Resources.lupa_dark;
                    break;
            }
        }

        #endregion

        private Panel panelBuscador;
        private TextBox txtBuscador;
        private Button btnBuscar;
        private Panel panelTabla;
        private Panel panelDiferenciador;
        private Button btnProximamente;
        private Button btnTerminados;
        private Button btnEnVivo;
        private Button btnTodos;
        private Panel panelEncuentros;
        private MonthCalendar mtcFechasEventos;
        private Button btnCalendario;
    }
}