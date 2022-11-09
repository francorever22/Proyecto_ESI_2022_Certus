namespace Sistema_de_Resultados_Deportivos
{
    public partial class Users : Form
    {
        private static Users form = null;
        bool editingName, editingEmail, editingPhone;
        Usuario u = null;
        public Users()
        {
            InitializeComponent();
            form = this;
            panelChangePassword.Hide();
            u = Program.user;
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
                if (u.numeroTelefono != null && u.numeroTelefono != "")
                {
                    txtPhoneNumber.Text = u.numeroTelefono;
                    btnAddNumber.Hide();
                }
                else
                {
                    txtPhoneNumber.Hide();
                    btnEditPhone.Hide();
                }
                if (u.nivelPermisos >= 2)
                {
                    btnPremium.Hide();
                }
            }
            foreach (var ef in u.encuentrosFavoritos)
            {
                var enc = Logica.GetEncuentros(4, ""+ef.idEncuentro)[0];
                int idEnc = enc.IdEncuentro;
                Panel p1 = new Panel();

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.Size = new Size(265, 25);
                p1.TabIndex = 0;

                LinkLabel llb1 = new LinkLabel();

                llb1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                llb1.Text = $"{enc.Nombre}";
                llb1.TextAlign = ContentAlignment.MiddleCenter;
                llb1.Size = new Size(257, 25);
                llb1.AutoSize = false;
                llb1.BorderStyle = BorderStyle.FixedSingle;
                llb1.Location = new Point(0, 0);
                llb1.TabIndex = 3;
                llb1.DisabledLinkColor = AjustesDeUsuario.foreColor;
                llb1.VisitedLinkColor = AjustesDeUsuario.foreColor;
                llb1.ActiveLinkColor = AjustesDeUsuario.foreColor;
                llb1.LinkBehavior = LinkBehavior.NeverUnderline;
                llb1.LinkColor = AjustesDeUsuario.foreColor;
                llb1.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb1); };
                llb1.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb1); };
                llb1.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs, idEnc, 5); };

                switch (AjustesDeUsuario.darkTheme)
                {
                    case false: //Tema claro
                        llb1.ForeColor = Color.Black;
                        llb1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        break;
                    case true: //Tema oscuro
                        llb1.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                        llb1.BackColor = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                        break;
                }

                panelDepFav.Controls.Add(p1); //Agrega los controles al panelDepFav
                p1.Controls.Add(llb1);
            }
            foreach (var ef in u.eventosFavoritos)
            {
                var eve = Logica.GetEventos(4, "" + ef.idEvento)[0];
                int idEve = eve.IdEvento;
                Panel p1 = new Panel();

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.Size = new Size(265, 25);
                p1.TabIndex = 0;

                LinkLabel llb1 = new LinkLabel();

                llb1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                llb1.Text = $"{eve.NombreEvento}";
                llb1.TextAlign = ContentAlignment.MiddleCenter;
                llb1.Size = new Size(257, 25);
                llb1.AutoSize = false;
                llb1.BorderStyle = BorderStyle.FixedSingle;
                llb1.Location = new Point(0, 0);
                llb1.TabIndex = 3;
                llb1.DisabledLinkColor = AjustesDeUsuario.foreColor;
                llb1.VisitedLinkColor = AjustesDeUsuario.foreColor;
                llb1.ActiveLinkColor = AjustesDeUsuario.foreColor;
                llb1.LinkBehavior = LinkBehavior.NeverUnderline;
                llb1.LinkColor = AjustesDeUsuario.foreColor;
                llb1.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb1); };
                llb1.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb1); };
                llb1.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs, idEve, 7); };

                switch (AjustesDeUsuario.darkTheme)
                {
                    case false: //Tema claro
                        llb1.ForeColor = Color.Black;
                        llb1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        break;
                    case true: //Tema oscuro
                        llb1.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                        llb1.BackColor = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                        break;
                }

                panelDepFav.Controls.Add(p1); //Agrega los controles al panelDepFav
                p1.Controls.Add(llb1);
            }
            foreach (var ef in u.equiposFavoritos)
            {
                var eq = Logica.GetEquipos(3, "" + ef.idEquipo)[0];
                int idEq = eq.IdEquipo;
                Panel p1 = new Panel();

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.Size = new Size(265, 25);
                p1.TabIndex = 0;

                LinkLabel llb1 = new LinkLabel();

                llb1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                llb1.Text = $"{eq.NombreEquipo}";
                llb1.TextAlign = ContentAlignment.MiddleCenter;
                llb1.Size = new Size(257, 25);
                llb1.AutoSize = false;
                llb1.BorderStyle = BorderStyle.FixedSingle;
                llb1.Location = new Point(0, 0);
                llb1.TabIndex = 3;
                llb1.DisabledLinkColor = AjustesDeUsuario.foreColor;
                llb1.VisitedLinkColor = AjustesDeUsuario.foreColor;
                llb1.ActiveLinkColor = AjustesDeUsuario.foreColor;
                llb1.LinkBehavior = LinkBehavior.NeverUnderline;
                llb1.LinkColor = AjustesDeUsuario.foreColor;
                llb1.MouseHover += (sender, EventArgs) => { mouseHover_Click(sender, EventArgs, llb1); };
                llb1.MouseLeave += (sender, EventArgs) => { mouseLeave_Click(sender, EventArgs, llb1); };
                llb1.Click += (sender, EventArgs) => { llb_Click(sender, EventArgs, idEq, 6); };

                switch (AjustesDeUsuario.darkTheme)
                {
                    case false: //Tema claro
                        llb1.ForeColor = Color.Black;
                        llb1.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                        break;
                    case true: //Tema oscuro
                        llb1.ForeColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(110)))), ((int)(((byte)(223)))));
                        llb1.BackColor = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
                        break;
                }

                panelDepFav.Controls.Add(p1); //Agrega los controles al panelDepFav
                p1.Controls.Add(llb1);
            }
        }

        private void mouseHover_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = Color.MediumVioletRed;
        }

        private void mouseLeave_Click(object sender, EventArgs e, LinkLabel l)
        {
            l.LinkColor = AjustesDeUsuario.foreColor;
        }

        private void llb_Click(object sender, EventArgs e, int id, int tipo)
        {
            if (tipo != 6)
            {
                Principal.AlterPrincipal(id, tipo, 0);
            } else
            {
                Principal.AlterPrincipal(1, tipo, id);
            }
        }

        private void btnEditarEmail_Click(object sender, EventArgs e)
        {
            if (editingEmail == true)
            {
                if (txtEmail.Text == u.email)
                {
                    txtEmail.ReadOnly = true;
                    editingEmail = false;
                    btnEditarEmail.Image = Properties.Resources.pluma;
                }
                else
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Change email", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        Logica.UpdateUsuario(txtEmail.Text, u.nombreUsuario);
                        u.email = txtEmail.Text;
                    } else
                    {
                        txtEmail.Text = u.email;
                    }
                    txtEmail.ReadOnly = true;
                    editingEmail = false;
                    btnEditarEmail.Image = Properties.Resources.pluma;
                }
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
                if (txtUser.Text == u.nombreUsuario)
                {
                    txtUser.ReadOnly = true;
                    editingName = false;
                    btnEditarUsuario.Image = Properties.Resources.pluma;
                } else
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Change user name", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        Logica.UpdateUsuario(u.email, txtUser.Text, u.contrasena, u.numeroTelefono, u.nivelPermisos);
                        u.nombreUsuario = txtUser.Text;
                    } else
                    {
                        txtUser.Text = u.nombreUsuario;
                    }
                    txtUser.ReadOnly = true;
                    editingName = false;
                    btnEditarUsuario.Image = Properties.Resources.pluma;
                }
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
            if (txtPhoneNumber.Text == "")
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
                if (txtPhoneNumber.Text == u.nombreUsuario)
                {
                    txtPhoneNumber.ReadOnly = true;
                    editingName = false;
                    btnEditPhone.Image = Properties.Resources.pluma;
                }
                else
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Change phone number", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        Logica.UpdateUsuario(u.email, u.nombreUsuario, u.contrasena, txtPhoneNumber.Text, u.nivelPermisos);
                        u.numeroTelefono = txtPhoneNumber.Text;
                    }
                    else
                    {
                        txtPhoneNumber.Text = u.numeroTelefono;
                    }
                    txtPhoneNumber.ReadOnly = true;
                    editingName = false;
                    btnEditPhone.Image = Properties.Resources.pluma;
                }
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
            Principal.AlterPrincipal(0, 8, 0);
            Principal.AlterPrincipal(0, 9, 0);
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

        private void btnAcceptNewPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtRepeatPassword.Text)
            {
                string password = Logica.EncriptarContraseña(txtPassword.Text, "Certus_SRD");
                if (password != u.contrasena)
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Change password", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        Logica.UpdateUsuario(u.email, u.nombreUsuario, password, u.numeroTelefono, u.nivelPermisos);
                        txtPassword.Text = "";
                        txtRepeatPassword.Text = "";
                        panelChangePassword.Hide();
                    }
                } else
                {
                    if (AjustesDeUsuario.language == "EN")
                    {
                        MessageBox.Show("Your new password can't be the same as the previous one");
                    }
                    else if (AjustesDeUsuario.language == "ES")
                    {
                        MessageBox.Show("Tu nueva contraseña no puede ser igual a la anterior");
                    }
                }
            }
            else
            {
                if (AjustesDeUsuario.language == "EN")
                {
                    MessageBox.Show("The passwords don't match");
                }
                else if (AjustesDeUsuario.language == "ES")
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Delete account", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you really sure of this?", "DELETE ACCOUNT", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    try
                    {
                        Logica.Delete("Usuarios", "Email", u.email);
                        Principal.AlterPrincipal(0, 10, 0);
                    } catch { MessageBox.Show("Error"); return; }
                }
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