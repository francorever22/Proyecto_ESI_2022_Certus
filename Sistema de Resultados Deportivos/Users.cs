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
                btnEditarEmail.Image = Properties.Resources.pluma;
            }
            else
            {
                txtEmail.ReadOnly = false;
                editingEmail = true;
                btnEditarEmail.Image = Properties.Resources.disco;
            }
        }

        private void btnEditarNombre_Click(object sender, EventArgs e)
        {
            if (editingName == true)
            {
                txtUser.ReadOnly = true;
                editingName = false;
                btnEditarUsuario.Image = Properties.Resources.pluma;
            }
            else
            {
                txtUser.ReadOnly = false;
                editingName = true;
                btnEditarUsuario.Image = Properties.Resources.disco;
            }
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            txtPhoneNumber.ReadOnly = false;
            editingPhone = true;
            btnEditPhone.Image = Properties.Resources.disco;
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
                btnEditPhone.Image = Properties.Resources.pluma;
                txtPhoneNumber.Hide();
                btnEditPhone.Hide();
                btnAddNumber.Show();
            }
            else if (editingPhone == true)
            {
                txtPhoneNumber.ReadOnly = true;
                editingPhone = false;
                btnEditPhone.Image = Properties.Resources.pluma;
            } else
            {
                txtPhoneNumber.ReadOnly = false;
                editingPhone = true;
                btnEditPhone.Image = Properties.Resources.disco;
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
    }
}