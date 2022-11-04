namespace Sistema_de_Resultados_Deportivos
{
    partial class Frm_Encuentros
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnResumen = new System.Windows.Forms.Button();
            this.btnUltimosEncuentros = new System.Windows.Forms.Button();
            this.btnAlineamiento = new System.Windows.Forms.Button();
            this.btnJugadores = new System.Windows.Forms.Button();
            this.panelTeam2 = new System.Windows.Forms.Panel();
            this.llbTeam2 = new System.Windows.Forms.LinkLabel();
            this.panelTeam1 = new System.Windows.Forms.Panel();
            this.llbTeam1 = new System.Windows.Forms.LinkLabel();
            this.lblMarcador = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblState = new System.Windows.Forms.Label();
            this.panelPrincipal.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelTeam2.SuspendLayout();
            this.panelTeam1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.panelContenedor);
            this.panelPrincipal.Controls.Add(this.panelHeader);
            this.panelPrincipal.Location = new System.Drawing.Point(0, 136);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(725, 416);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.Location = new System.Drawing.Point(0, 65);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(725, 351);
            this.panelContenedor.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnResumen);
            this.panelHeader.Controls.Add(this.btnUltimosEncuentros);
            this.panelHeader.Controls.Add(this.btnAlineamiento);
            this.panelHeader.Controls.Add(this.btnJugadores);
            this.panelHeader.Controls.Add(this.panelTeam2);
            this.panelHeader.Controls.Add(this.panelTeam1);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(725, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // btnResumen
            // 
            this.btnResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumen.Location = new System.Drawing.Point(543, 35);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(181, 30);
            this.btnResumen.TabIndex = 5;
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // btnUltimosEncuentros
            // 
            this.btnUltimosEncuentros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimosEncuentros.Location = new System.Drawing.Point(362, 35);
            this.btnUltimosEncuentros.Name = "btnUltimosEncuentros";
            this.btnUltimosEncuentros.Size = new System.Drawing.Size(181, 30);
            this.btnUltimosEncuentros.TabIndex = 4;
            this.btnUltimosEncuentros.UseVisualStyleBackColor = true;
            this.btnUltimosEncuentros.Click += new System.EventHandler(this.btnUltimosEncuentros_Click);
            // 
            // btnAlineamiento
            // 
            this.btnAlineamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlineamiento.Location = new System.Drawing.Point(181, 35);
            this.btnAlineamiento.Name = "btnAlineamiento";
            this.btnAlineamiento.Size = new System.Drawing.Size(181, 30);
            this.btnAlineamiento.TabIndex = 3;
            this.btnAlineamiento.UseVisualStyleBackColor = true;
            this.btnAlineamiento.Click += new System.EventHandler(this.btnAlineamiento_Click);
            // 
            // btnJugadores
            // 
            this.btnJugadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugadores.Location = new System.Drawing.Point(0, 35);
            this.btnJugadores.Name = "btnJugadores";
            this.btnJugadores.Size = new System.Drawing.Size(181, 30);
            this.btnJugadores.TabIndex = 2;
            this.btnJugadores.UseVisualStyleBackColor = true;
            this.btnJugadores.Click += new System.EventHandler(this.btnJugadores_Click);
            // 
            // panelTeam2
            // 
            this.panelTeam2.Controls.Add(this.llbTeam2);
            this.panelTeam2.Location = new System.Drawing.Point(362, 0);
            this.panelTeam2.Name = "panelTeam2";
            this.panelTeam2.Size = new System.Drawing.Size(362, 35);
            this.panelTeam2.TabIndex = 1;
            // 
            // llbTeam2
            // 
            this.llbTeam2.ActiveLinkColor = System.Drawing.Color.Black;
            this.llbTeam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.llbTeam2.DisabledLinkColor = System.Drawing.Color.Black;
            this.llbTeam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llbTeam2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbTeam2.LinkColor = System.Drawing.Color.Black;
            this.llbTeam2.Location = new System.Drawing.Point(0, 0);
            this.llbTeam2.Name = "llbTeam2";
            this.llbTeam2.Size = new System.Drawing.Size(362, 35);
            this.llbTeam2.TabIndex = 1;
            this.llbTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llbTeam2.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // panelTeam1
            // 
            this.panelTeam1.Controls.Add(this.llbTeam1);
            this.panelTeam1.Location = new System.Drawing.Point(0, 0);
            this.panelTeam1.Name = "panelTeam1";
            this.panelTeam1.Size = new System.Drawing.Size(362, 35);
            this.panelTeam1.TabIndex = 0;
            // 
            // llbTeam1
            // 
            this.llbTeam1.ActiveLinkColor = System.Drawing.Color.Black;
            this.llbTeam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.llbTeam1.DisabledLinkColor = System.Drawing.Color.Black;
            this.llbTeam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llbTeam1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbTeam1.LinkColor = System.Drawing.Color.Black;
            this.llbTeam1.Location = new System.Drawing.Point(0, 0);
            this.llbTeam1.Name = "llbTeam1";
            this.llbTeam1.Size = new System.Drawing.Size(362, 35);
            this.llbTeam1.TabIndex = 0;
            this.llbTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llbTeam1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lblMarcador
            // 
            this.lblMarcador.AutoSize = true;
            this.lblMarcador.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMarcador.Location = new System.Drawing.Point(362, 48);
            this.lblMarcador.Name = "lblMarcador";
            this.lblMarcador.Size = new System.Drawing.Size(0, 25);
            this.lblMarcador.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(50, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(576, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(362, 86);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 15);
            this.lblState.TabIndex = 4;
            // 
            // Frm_Encuentros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 552);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMarcador);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Encuentros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Encuentros_Tipo_A";
            this.panelPrincipal.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelTeam2.ResumeLayout(false);
            this.panelTeam1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblMarcador;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panelPrincipal;
        private Panel panelContenedor;
        private Panel panelHeader;
        private Panel panelTeam2;
        private Panel panelTeam1;
        private Button btnResumen;
        private Button btnUltimosEncuentros;
        private Button btnAlineamiento;
        private Button btnJugadores;
        private LinkLabel llbTeam2;
        private LinkLabel llbTeam1;
        private Label lblState;
    }
}