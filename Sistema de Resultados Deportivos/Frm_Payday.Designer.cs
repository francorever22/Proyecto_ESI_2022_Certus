namespace Sistema_de_Resultados_Deportivos
{
    partial class Frm_Payday
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
            this.cbxMetodo = new System.Windows.Forms.ComboBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCerrarSettings = new System.Windows.Forms.Button();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtExpirationDate = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCvv = new System.Windows.Forms.TextBox();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxMetodo
            // 
            this.cbxMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMetodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMetodo.FormattingEnabled = true;
            this.cbxMetodo.Items.AddRange(new object[] {
            "Credit/Debit Card"});
            this.cbxMetodo.Location = new System.Drawing.Point(36, 75);
            this.cbxMetodo.Name = "cbxMetodo";
            this.cbxMetodo.Size = new System.Drawing.Size(278, 23);
            this.cbxMetodo.TabIndex = 0;
            // 
            // btnPay
            // 
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Location = new System.Drawing.Point(108, 353);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(133, 48);
            this.btnPay.TabIndex = 12;
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnGuardar_Click);
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
            // txtCardNumber
            // 
            this.txtCardNumber.ForeColor = System.Drawing.Color.Gray;
            this.txtCardNumber.Location = new System.Drawing.Point(36, 181);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(278, 23);
            this.txtCardNumber.TabIndex = 14;
            this.txtCardNumber.Text = "Card Number";
            // 
            // txtExpirationDate
            // 
            this.txtExpirationDate.ForeColor = System.Drawing.Color.DimGray;
            this.txtExpirationDate.Location = new System.Drawing.Point(248, 232);
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.Size = new System.Drawing.Size(66, 23);
            this.txtExpirationDate.TabIndex = 15;
            this.txtExpirationDate.Text = "MM/YY";
            // 
            // txtName
            // 
            this.txtName.ForeColor = System.Drawing.Color.DimGray;
            this.txtName.Location = new System.Drawing.Point(36, 132);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 23);
            this.txtName.TabIndex = 16;
            this.txtName.Text = "Full Name";
            // 
            // txtCvv
            // 
            this.txtCvv.ForeColor = System.Drawing.Color.DimGray;
            this.txtCvv.Location = new System.Drawing.Point(36, 232);
            this.txtCvv.Name = "txtCvv";
            this.txtCvv.Size = new System.Drawing.Size(48, 23);
            this.txtCvv.TabIndex = 17;
            this.txtCvv.Text = "CVV";
            // 
            // lblMetodo
            // 
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Location = new System.Drawing.Point(119, 52);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(0, 15);
            this.lblMetodo.TabIndex = 37;
            // 
            // Frm_Payday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 423);
            this.Controls.Add(this.lblMetodo);
            this.Controls.Add(this.txtCvv);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtExpirationDate);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.btnCerrarSettings);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.cbxMetodo);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Payday";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox cbxMetodo;
        private Button btnPay;
        private Button btnCerrarSettings;
        private TextBox txtCardNumber;
        private TextBox txtExpirationDate;
        private TextBox txtName;
        private TextBox txtCvv;
        private Label lblMetodo;
    }
}