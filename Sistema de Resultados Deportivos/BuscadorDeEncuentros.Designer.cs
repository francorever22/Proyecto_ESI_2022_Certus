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
            this.panelEncuentros = new System.Windows.Forms.Panel();
            this.mtcFechasEventos = new System.Windows.Forms.MonthCalendar();
            this.panelDiferenciador = new System.Windows.Forms.Panel();
            this.btnCalendario = new System.Windows.Forms.Button();
            this.btnProximamente = new System.Windows.Forms.Button();
            this.btnTerminados = new System.Windows.Forms.Button();
            this.btnEnVivo = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.panelBuscador.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.panelEncuentros.SuspendLayout();
            this.panelDiferenciador.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBuscador
            // 
            this.panelBuscador.Controls.Add(this.txtBuscador);
            this.panelBuscador.Controls.Add(this.btnBuscar);
            this.panelBuscador.Location = new System.Drawing.Point(91, 42);
            this.panelBuscador.Name = "panelBuscador";
            this.panelBuscador.Size = new System.Drawing.Size(541, 27);
            this.panelBuscador.TabIndex = 0;
            // 
            // txtBuscador
            // 
            this.txtBuscador.AcceptsReturn = true;
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscador.Location = new System.Drawing.Point(0, 0);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(514, 23);
            this.txtBuscador.TabIndex = 1;
            this.txtBuscador.WordWrap = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::Sistema_de_Resultados_Deportivos.Properties.Resources.lupa1;
            this.btnBuscar.Location = new System.Drawing.Point(514, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(27, 27);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // panelTabla
            // 
            this.panelTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTabla.Controls.Add(this.panelEncuentros);
            this.panelTabla.Controls.Add(this.panelDiferenciador);
            this.panelTabla.Location = new System.Drawing.Point(81, 107);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(565, 405);
            this.panelTabla.TabIndex = 1;
            // 
            // panelEncuentros
            // 
            this.panelEncuentros.AutoScroll = true;
            this.panelEncuentros.Controls.Add(this.mtcFechasEventos);
            this.panelEncuentros.Location = new System.Drawing.Point(0, 28);
            this.panelEncuentros.Name = "panelEncuentros";
            this.panelEncuentros.Size = new System.Drawing.Size(563, 376);
            this.panelEncuentros.TabIndex = 1;
            // 
            // mtcFechasEventos
            // 
            this.mtcFechasEventos.Location = new System.Drawing.Point(354, 0);
            this.mtcFechasEventos.Name = "mtcFechasEventos";
            this.mtcFechasEventos.TabIndex = 0;
            this.mtcFechasEventos.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mtcFechasEventos_DateChanged);
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
            this.panelDiferenciador.Size = new System.Drawing.Size(563, 27);
            this.panelDiferenciador.TabIndex = 0;
            // 
            // btnCalendario
            // 
            this.btnCalendario.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCalendario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendario.Location = new System.Drawing.Point(428, 0);
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Size = new System.Drawing.Size(135, 27);
            this.btnCalendario.TabIndex = 4;
            this.btnCalendario.UseVisualStyleBackColor = true;
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            // 
            // btnProximamente
            // 
            this.btnProximamente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProximamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximamente.Location = new System.Drawing.Point(321, 0);
            this.btnProximamente.Name = "btnProximamente";
            this.btnProximamente.Size = new System.Drawing.Size(107, 27);
            this.btnProximamente.TabIndex = 3;
            this.btnProximamente.UseVisualStyleBackColor = true;
            // 
            // btnTerminados
            // 
            this.btnTerminados.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTerminados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminados.Location = new System.Drawing.Point(214, 0);
            this.btnTerminados.Name = "btnTerminados";
            this.btnTerminados.Size = new System.Drawing.Size(107, 27);
            this.btnTerminados.TabIndex = 2;
            this.btnTerminados.UseVisualStyleBackColor = true;
            // 
            // btnEnVivo
            // 
            this.btnEnVivo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEnVivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnVivo.Location = new System.Drawing.Point(107, 0);
            this.btnEnVivo.Name = "btnEnVivo";
            this.btnEnVivo.Size = new System.Drawing.Size(107, 27);
            this.btnEnVivo.TabIndex = 1;
            this.btnEnVivo.UseVisualStyleBackColor = true;
            // 
            // btnTodos
            // 
            this.btnTodos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodos.Location = new System.Drawing.Point(0, 0);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(107, 27);
            this.btnTodos.TabIndex = 0;
            this.btnTodos.UseVisualStyleBackColor = true;
            // 
            // BuscadorDeEncuentros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
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
            this.panelEncuentros.ResumeLayout(false);
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

        void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            Boolean darkTheme = false;
            switch (darkTheme)
            {
                case false: //Tema claro

                    break;
                case true: //Tema oscuro

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