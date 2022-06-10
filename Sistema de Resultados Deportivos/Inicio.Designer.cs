namespace Sistema_de_Resultados_Deportivos
{
    partial class Inicio
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
            this.panelDiferenciador = new System.Windows.Forms.Panel();
            this.btnAvanzar = new System.Windows.Forms.Button();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
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
            this.panelEncuentros.Location = new System.Drawing.Point(0, 28);
            this.panelEncuentros.Name = "panelEncuentros";
            this.panelEncuentros.Size = new System.Drawing.Size(563, 376);
            this.panelEncuentros.TabIndex = 1;
            // 
            // panelDiferenciador
            // 
            this.panelDiferenciador.Controls.Add(this.btnAvanzar);
            this.panelDiferenciador.Controls.Add(this.btnRetroceder);
            this.panelDiferenciador.Controls.Add(this.lblFecha);
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
            // btnAvanzar
            // 
            this.btnAvanzar.FlatAppearance.BorderSize = 0;
            this.btnAvanzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvanzar.Location = new System.Drawing.Point(538, 1);
            this.btnAvanzar.Name = "btnAvanzar";
            this.btnAvanzar.Size = new System.Drawing.Size(27, 25);
            this.btnAvanzar.TabIndex = 6;
            this.btnAvanzar.Text = ">";
            this.btnAvanzar.UseVisualStyleBackColor = true;
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.FlatAppearance.BorderSize = 0;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Location = new System.Drawing.Point(428, 1);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(27, 25);
            this.btnRetroceder.TabIndex = 1;
            this.btnRetroceder.Text = "<";
            this.btnRetroceder.UseVisualStyleBackColor = true;
            // 
            // lblFecha
            // 
            this.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.Location = new System.Drawing.Point(428, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(137, 27);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "xx/xx/xxxx";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProximamente
            // 
            this.btnProximamente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProximamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximamente.Location = new System.Drawing.Point(321, 0);
            this.btnProximamente.Name = "btnProximamente";
            this.btnProximamente.Size = new System.Drawing.Size(107, 27);
            this.btnProximamente.TabIndex = 3;
            this.btnProximamente.Text = "Proximamente";
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
            this.btnTerminados.Text = "Terminados";
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
            this.btnEnVivo.Text = "En vivo";
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
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 552);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelBuscador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.panelBuscador.ResumeLayout(false);
            this.panelBuscador.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            this.panelDiferenciador.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Button btnAvanzar;
        private Button btnRetroceder;
        private Label lblFecha;
        private Panel panelEncuentros;
    }
}