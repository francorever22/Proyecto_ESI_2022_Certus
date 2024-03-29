﻿namespace SRD_BackOffice
{
    partial class MenuManageEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuManageEvents));
            this.panelManageEvents = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhases = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.btnEventManagerCerrar = new System.Windows.Forms.Button();
            this.lblEventManagerTitle = new System.Windows.Forms.Label();
            this.panelManageEvents.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.panelLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelManageEvents
            // 
            this.panelManageEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelManageEvents.Controls.Add(this.btnBuscar);
            this.panelManageEvents.Controls.Add(this.txtBuscador);
            this.panelManageEvents.Controls.Add(this.panelPrincipal);
            this.panelManageEvents.Controls.Add(this.btnEventManagerCerrar);
            this.panelManageEvents.Controls.Add(this.lblEventManagerTitle);
            this.panelManageEvents.Location = new System.Drawing.Point(-1, -1);
            this.panelManageEvents.Name = "panelManageEvents";
            this.panelManageEvents.Size = new System.Drawing.Size(676, 541);
            this.panelManageEvents.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::SRD_BackOffice.Properties.Resources.lupa;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(483, 61);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 25);
            this.btnBuscar.TabIndex = 29;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(174, 62);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(309, 23);
            this.txtBuscador.TabIndex = 28;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPrincipal.Controls.Add(this.panelContenedor);
            this.panelPrincipal.Controls.Add(this.panelLabels);
            this.panelPrincipal.Location = new System.Drawing.Point(13, 125);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(650, 404);
            this.panelPrincipal.TabIndex = 23;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContenedor.Location = new System.Drawing.Point(0, 25);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(648, 378);
            this.panelContenedor.TabIndex = 1;
            // 
            // panelLabels
            // 
            this.panelLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.panelLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLabels.Controls.Add(this.lblId);
            this.panelLabels.Controls.Add(this.lblName);
            this.panelLabels.Controls.Add(this.lblPhases);
            this.panelLabels.Controls.Add(this.lblDate);
            this.panelLabels.Controls.Add(this.lblHour);
            this.panelLabels.Controls.Add(this.lblState);
            this.panelLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabels.Location = new System.Drawing.Point(0, 0);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(648, 25);
            this.panelLabels.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(21, 4);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 15);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(179, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 15);
            this.lblName.TabIndex = 4;
            // 
            // lblPhases
            // 
            this.lblPhases.AutoSize = true;
            this.lblPhases.Location = new System.Drawing.Point(322, 4);
            this.lblPhases.Name = "lblPhases";
            this.lblPhases.Size = new System.Drawing.Size(0, 15);
            this.lblPhases.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(396, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 15);
            this.lblDate.TabIndex = 2;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Location = new System.Drawing.Point(465, 4);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(0, 15);
            this.lblHour.TabIndex = 1;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(539, 4);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 15);
            this.lblState.TabIndex = 5;
            // 
            // btnEventManagerCerrar
            // 
            this.btnEventManagerCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnEventManagerCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEventManagerCerrar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEventManagerCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnEventManagerCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnEventManagerCerrar.Image = global::SRD_BackOffice.Properties.Resources.Incio_Claro;
            this.btnEventManagerCerrar.Location = new System.Drawing.Point(627, 13);
            this.btnEventManagerCerrar.Name = "btnEventManagerCerrar";
            this.btnEventManagerCerrar.Size = new System.Drawing.Size(38, 38);
            this.btnEventManagerCerrar.TabIndex = 18;
            this.btnEventManagerCerrar.UseVisualStyleBackColor = true;
            this.btnEventManagerCerrar.Click += new System.EventHandler(this.btnSportsManagerCerrar_Click);
            // 
            // lblEventManagerTitle
            // 
            this.lblEventManagerTitle.AutoSize = true;
            this.lblEventManagerTitle.Font = new System.Drawing.Font("Montserrat", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEventManagerTitle.Location = new System.Drawing.Point(0, 0);
            this.lblEventManagerTitle.Name = "lblEventManagerTitle";
            this.lblEventManagerTitle.Size = new System.Drawing.Size(0, 37);
            this.lblEventManagerTitle.TabIndex = 8;
            // 
            // MenuManageEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 541);
            this.Controls.Add(this.panelManageEvents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuManageEvents";
            this.Text = "AdministradorAPP";
            this.panelManageEvents.ResumeLayout(false);
            this.panelManageEvents.PerformLayout();
            this.panelPrincipal.ResumeLayout(false);
            this.panelLabels.ResumeLayout(false);
            this.panelLabels.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private Panel panelManageEvents;
        private Label lblEventManagerTitle;
        private Button btnEventManagerCerrar;
        private Panel panelPrincipal;
        private Panel panelContenedor;
        private Panel panelLabels;
        private Label lblDate;
        private Label lblHour;
        private Label lblPhases;
        private Label lblState;
        private Label lblName;
        private Label lblId;
        private Button btnBuscar;
        private TextBox txtBuscador;
    }
}