using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    partial class Users
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelDepFav = new System.Windows.Forms.Panel();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnEditarEmail = new System.Windows.Forms.Button();
            this.btnAddNumber = new System.Windows.Forms.Button();
            this.btnPremium = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.panelChangePassword = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAcceptNewPassword = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnEditPhone = new System.Windows.Forms.Button();
            this.panelChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 0;
            // 
            // panelDepFav
            // 
            this.panelDepFav.AutoScroll = true;
            this.panelDepFav.Location = new System.Drawing.Point(372, 133);
            this.panelDepFav.Name = "panelDepFav";
            this.panelDepFav.Size = new System.Drawing.Size(257, 265);
            this.panelDepFav.TabIndex = 1;
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarUsuario.Image = global::WindowsFormsApp1.Properties.Resources.pluma;
            this.btnEditarUsuario.Location = new System.Drawing.Point(241, 125);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(30, 30);
            this.btnEditarUsuario.TabIndex = 3;
            this.btnEditarUsuario.UseVisualStyleBackColor = false;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarNombre_Click);
            // 
            // btnEditarEmail
            // 
            this.btnEditarEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarEmail.Image = global::WindowsFormsApp1.Properties.Resources.pluma;
            this.btnEditarEmail.Location = new System.Drawing.Point(241, 185);
            this.btnEditarEmail.Name = "btnEditarEmail";
            this.btnEditarEmail.Size = new System.Drawing.Size(30, 30);
            this.btnEditarEmail.TabIndex = 5;
            this.btnEditarEmail.UseVisualStyleBackColor = true;
            this.btnEditarEmail.Click += new System.EventHandler(this.btnEditarEmail_Click);
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNumber.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAddNumber.Location = new System.Drawing.Point(0, 0);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(75, 23);
            this.btnAddNumber.TabIndex = 6;
            this.btnAddNumber.UseVisualStyleBackColor = true;
            this.btnAddNumber.Click += new System.EventHandler(this.btnAddNumber_Click);
            // 
            // btnPremium
            // 
            this.btnPremium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPremium.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPremium.Location = new System.Drawing.Point(32, 440);
            this.btnPremium.Name = "btnPremium";
            this.btnPremium.Size = new System.Drawing.Size(165, 32);
            this.btnPremium.TabIndex = 7;
            this.btnPremium.UseVisualStyleBackColor = true;
            this.btnPremium.Click += new System.EventHandler(this.btnPremium_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnChangePass.Location = new System.Drawing.Point(285, 440);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(165, 32);
            this.btnChangePass.TabIndex = 8;
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.Location = new System.Drawing.Point(530, 440);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 32);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.lblUser.Location = new System.Drawing.Point(0, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 65);
            this.lblUser.TabIndex = 11;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUser.Location = new System.Drawing.Point(11, 128);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(224, 23);
            this.txtUser.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(11, 189);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(224, 23);
            this.txtEmail.TabIndex = 13;
            // 
            // panelChangePassword
            // 
            this.panelChangePassword.Controls.Add(this.btnCancel);
            this.panelChangePassword.Controls.Add(this.label4);
            this.panelChangePassword.Controls.Add(this.btnAcceptNewPassword);
            this.panelChangePassword.Controls.Add(this.label3);
            this.panelChangePassword.Controls.Add(this.txtRepeatPassword);
            this.panelChangePassword.Controls.Add(this.label2);
            this.panelChangePassword.Controls.Add(this.txtPassword);
            this.panelChangePassword.Location = new System.Drawing.Point(215, 137);
            this.panelChangePassword.Name = "panelChangePassword";
            this.panelChangePassword.Size = new System.Drawing.Size(305, 198);
            this.panelChangePassword.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(170, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 27);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 16;
            // 
            // btnAcceptNewPassword
            // 
            this.btnAcceptNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAcceptNewPassword.Location = new System.Drawing.Point(26, 159);
            this.btnAcceptNewPassword.Name = "btnAcceptNewPassword";
            this.btnAcceptNewPassword.Size = new System.Drawing.Size(109, 27);
            this.btnAcceptNewPassword.TabIndex = 15;
            this.btnAcceptNewPassword.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 3;
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRepeatPassword.Location = new System.Drawing.Point(26, 118);
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.Size = new System.Drawing.Size(253, 23);
            this.txtRepeatPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(26, 57);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(253, 23);
            this.txtPassword.TabIndex = 0;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(11, 251);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(224, 20);
            this.txtPhoneNumber.TabIndex = 16;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // btnEditPhone
            // 
            this.btnEditPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPhone.Image = global::WindowsFormsApp1.Properties.Resources.pluma;
            this.btnEditPhone.Location = new System.Drawing.Point(241, 247);
            this.btnEditPhone.Name = "btnEditPhone";
            this.btnEditPhone.Size = new System.Drawing.Size(30, 30);
            this.btnEditPhone.TabIndex = 15;
            this.btnEditPhone.UseVisualStyleBackColor = false;
            this.btnEditPhone.Click += new System.EventHandler(this.btnEditPhone_Click);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 492);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.btnEditPhone);
            this.Controls.Add(this.panelChangePassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.btnPremium);
            this.Controls.Add(this.btnAddNumber);
            this.Controls.Add(this.btnEditarEmail);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.panelDepFav);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panelChangePassword.ResumeLayout(false);
            this.panelChangePassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panelDepFav;
        private Button btnEditarUsuario;
        private Button btnEditarEmail;
        private Button btnAddNumber;
        private Button btnPremium;
        private Button btnChangePass;
        private Button btnDelete;
        private Label lblUser;
        private TextBox txtUser;
        private TextBox txtEmail;
        private Panel panelChangePassword;
        private Label label4;
        private Button btnAcceptNewPassword;
        private Label label3;
        private TextBox txtRepeatPassword;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtPhoneNumber;
        private Button btnEditPhone;
        private Button btnCancel;
    }
}