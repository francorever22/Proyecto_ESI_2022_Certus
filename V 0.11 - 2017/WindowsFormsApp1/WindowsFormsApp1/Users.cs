using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Resultados_Deportivos
{
    public partial class Users : Form
    {
        private static Users form = null;
        bool editingName, editingEmail, editingPhone;
        Usuario u = Program.user;
        public Users()
        {
            InitializeComponent();
            form = this;
            panelChangePassword.Hide();
            CargarUsuario();
            SetIdioma();
            SetTheme();
        }

        private void CargarUsuario() //Carga los botones de panelDepFav uno por uno
        {
            panelDepFav.Controls.Clear();
            if (txtUser.Text == "")
            {
                txtUser.Text = u.nombreUsuario;
                txtEmail.Text = u.email;
                if (u.numeroTelefono != null)
                {
                    txtPhoneNumber.Text = u.numeroTelefono;
                    btnAddNumber.Hide();
                }
                else
                {
                    txtPhoneNumber.Hide();
                    btnEditPhone.Hide();
                }
            }
            foreach (var f in u.deportesFavoritos)
            {
                Panel p1 = new Panel();

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.Size = new Size(265, 25);
                p1.TabIndex = 0;

                TextBox l1 = new TextBox();

                l1.ReadOnly = true;
                l1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l1.Text = $"{f}";
                l1.TextAlign = HorizontalAlignment.Center;
                l1.Size = new Size(257, 25);
                l1.AutoSize = false;
                l1.BorderStyle = BorderStyle.FixedSingle;
                l1.Location = new Point(0, 0);
                l1.TabIndex = 3;

                switch (AjustesDeUsuario.darkTheme)
                {
                    case false: //Tema claro
                        l1.ForeColor = Color.Black;
                        l1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        break;
                    case true: //Tema oscuro
                        l1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                        l1.BackColor = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                        break;
                }

                this.panelDepFav.Controls.Add(p1); //Agrega los controles al panelDepFav
                p1.Controls.Add(l1);
            }
        }
        private void btnEditarEmail_Click(object sender, EventArgs e)
        {
            if (editingEmail == true)
            {
                txtEmail.ReadOnly = true;
                editingEmail = false;
                btnEditarEmail.Image = WindowsFormsApp1.Properties.Resources.pluma;
            }
            else
            {
                txtEmail.ReadOnly = false;
                editingEmail = true;
                btnEditarEmail.Image = WindowsFormsApp1.Properties.Resources.disco;
            }
        }

        private void btnEditarNombre_Click(object sender, EventArgs e)
        {
            if (editingName == true)
            {
                txtUser.ReadOnly = true;
                editingName = false;
                btnEditarUsuario.Image = WindowsFormsApp1.Properties.Resources.pluma;
            }
            else
            {
                txtUser.ReadOnly = false;
                editingName = true;
                btnEditarUsuario.Image = WindowsFormsApp1.Properties.Resources.disco;
            }
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            txtPhoneNumber.ReadOnly = false;
            editingPhone = true;
            btnEditPhone.Image = WindowsFormsApp1.Properties.Resources.disco;
            txtPhoneNumber.Show();
            btnEditPhone.Show();
            btnAddNumber.Hide();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            panelChangePassword.Show();
        }

        private void btnEditPhone_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "" || txtPhoneNumber.Text == u.numeroTelefono)
            {
                txtPhoneNumber.ReadOnly = true;
                editingPhone = false;
                btnEditPhone.Image = WindowsFormsApp1.Properties.Resources.pluma;
                txtPhoneNumber.Hide();
                btnEditPhone.Hide();
                btnAddNumber.Show();
            }
            else if (editingPhone == true)
            {
                txtPhoneNumber.ReadOnly = true;
                editingPhone = false;
                btnEditPhone.Image = WindowsFormsApp1.Properties.Resources.pluma;
            } else
            {
                txtPhoneNumber.ReadOnly = false;
                editingPhone = true;
                btnEditPhone.Image = WindowsFormsApp1.Properties.Resources.disco;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e) //Se encarga de que txtPhoneNumber solo acepte números
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtRepeatPassword.Text = "";
            panelChangePassword.Hide();
        }

        private void btnPremium_Click(object sender, EventArgs e)
        {

        }

        public static void AlterUsers(int y)
        {
            switch (y)
            {
                case 1:
                    if (form != null)
                    {
                        form.SetTheme();
                        form.CargarUsuario();
                    }
                    break;
                case 2:
                    if (form != null)
                    {
                        form.SetIdioma();
                    }
                    break;
            }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    label2.Text = "Password";
                    label3.Text = "Repeat password";
                    btnAcceptNewPassword.Text = "Accept";
                    label4.Text = "Password change";
                    label4.Location = new Point(93, 7);
                    btnCancel.Text = "Cancel";
                    lblUser.Text = "User";
                    lblUser.Location = new Point(300, 9);
                    btnDelete.Text = "Delete account";
                    btnChangePass.Text = "Change password";
                    btnPremium.Text = "Become premium!";
                    btnAddNumber.Text = "Add phone number";
                    btnAddNumber.Location = new Point(44, 247);
                    btnAddNumber.Size = new Size(165, 32);
                    label1.Text = "Favorite sports";
                    label1.Location = new Point(420, 88);
                    break;
                case "ES": //Español
                    label2.Text = "Contraseña";
                    label3.Text = "Repite la contraseña";
                    btnAcceptNewPassword.Text = "Aceptar";
                    label4.Text = "Cambio de contraseña";
                    label4.Location = new Point(76, 7);
                    btnCancel.Text = "Cancelar";
                    lblUser.Text = "Usuario";
                    lblUser.Location = new Point(276, 9);
                    btnDelete.Text = "Eliminar cuenta";
                    btnChangePass.Text = "Cambiar contraseña";
                    btnPremium.Text = "¡Pasate a premium!";
                    btnAddNumber.Text = "Agregar número de telefono";
                    btnAddNumber.Location = new Point(11, 247);
                    btnAddNumber.Size = new Size(224, 32);
                    label1.Text = "Deportes Favoritos";
                    label1.Location = new Point(393, 88);
                    break;
            }
        }

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            /* Paneles */
            panelChangePassword.BackColor = AjustesDeUsuario.panel;
            panelDepFav.BackColor = AjustesDeUsuario.panel;
            BackColor = AjustesDeUsuario.panel;
            /* Botones */
            btnEditPhone.BackColor = AjustesDeUsuario.btnBack;
            btnEditPhone.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnEditPhone.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnEditarUsuario.BackColor = AjustesDeUsuario.btnBack;
            btnEditarUsuario.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnEditarUsuario.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnAcceptNewPassword.BackColor = AjustesDeUsuario.btnBack;
            btnAcceptNewPassword.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnAcceptNewPassword.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnAddNumber.BackColor = AjustesDeUsuario.btnBack;
            btnAddNumber.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnAddNumber.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnCancel.BackColor = AjustesDeUsuario.btnBack;
            btnCancel.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnCancel.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnChangePass.BackColor = AjustesDeUsuario.btnBack;
            btnChangePass.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnChangePass.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnDelete.BackColor = AjustesDeUsuario.btnBack;
            btnDelete.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnDelete.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnEditarEmail.BackColor = AjustesDeUsuario.btnBack;
            btnEditarEmail.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnEditarEmail.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnPremium.BackColor = AjustesDeUsuario.btnBack;
            btnPremium.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnPremium.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            /* Textos (Incluidos botones) */
            txtEmail.ForeColor = Color.Black;
            txtPassword.ForeColor = Color.Black;
            txtPhoneNumber.ForeColor = Color.Black;
            txtRepeatPassword.ForeColor = Color.Black;
            txtUser.ForeColor = Color.Black;
            label1.ForeColor = AjustesDeUsuario.foreColor;
            label2.ForeColor = AjustesDeUsuario.foreColor;
            label3.ForeColor = AjustesDeUsuario.foreColor;
            label4.ForeColor = AjustesDeUsuario.foreColor;
            lblUser.ForeColor = AjustesDeUsuario.foreColor;
            btnEditPhone.ForeColor = AjustesDeUsuario.foreColor;
            btnEditarUsuario.ForeColor = AjustesDeUsuario.foreColor;
            btnAcceptNewPassword.ForeColor = AjustesDeUsuario.foreColor;
            btnAddNumber.ForeColor = AjustesDeUsuario.foreColor;
            btnCancel.ForeColor = AjustesDeUsuario.foreColor;
            btnChangePass.ForeColor = AjustesDeUsuario.foreColor;
            btnDelete.ForeColor = AjustesDeUsuario.foreColor;
            btnEditarEmail.ForeColor = AjustesDeUsuario.foreColor;
            btnPremium.ForeColor = AjustesDeUsuario.foreColor;
        }
    }
}