namespace Sistema_de_Resultados_Deportivos
{
    public partial class Frm_Payday : Form
    {
        public Frm_Payday()
        {
            InitializeComponent();
            SetTheme();
            SetIdioma();

            cbxMetodo.SelectedIndex = 0;
            txtCvv.Enter += (sender, EventArgs) => { txtCvv_Enter(sender, EventArgs, txtCvv); };
            txtCvv.Leave += (sender, EventArgs) => { txtCvv_Leave(sender, EventArgs, txtCvv); };
            txtExpirationDate.Enter += (sender, EventArgs) => { txtDate_Enter(sender, EventArgs, txtExpirationDate); };
            txtExpirationDate.Leave += (sender, EventArgs) => { txtDate_Leave(sender, EventArgs, txtExpirationDate); };
            txtCardNumber.Enter += (sender, EventArgs) => { txtCard_Enter(sender, EventArgs, txtCardNumber); };
            txtCardNumber.Leave += (sender, EventArgs) => { txtCard_Leave(sender, EventArgs, txtCardNumber); };
            txtName.Enter += (sender, EventArgs) => { txtName_Enter(sender, EventArgs, txtName); };
            txtName.Leave += (sender, EventArgs) => { txtName_Leave(sender, EventArgs, txtName); };
            txtCardNumber.KeyPress += (sender, e) => { txtNumber_KeyPress(sender, e); };
            txtCvv.KeyPress += (sender, e) => { txtNumber_KeyPress(sender, e); };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.UpdateUsuario(Program.user.email, Program.user.nombreUsuario, Program.user.contrasena, Program.user.numeroTelefono, 2);
                switch (AjustesDeUsuario.language)
                {
                    case "EN":
                        MessageBox.Show("You were promoted to premium user successfully");
                        MessageBox.Show("Reopen the app to enjoy your privileges");
                        break;
                    case "ES":
                        MessageBox.Show("Fuiste ascendido a usuario premium con éxito");
                        MessageBox.Show("Vuelve a abrir la aplicación para disfrutar de tus privilegios");
                        break;
                }
                Parent.Hide();
                Close();
            } catch
            {
                MessageBox.Show("Error"); return;
            }
        }

        private void txtCvv_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "CVV")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtCvv_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "CVV";
                t.ForeColor = Color.DimGray;
            }
        }

        private void txtDate_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "MM/YY")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtDate_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "MM/YY";
                t.ForeColor = Color.DimGray;
            }
        }

        private void txtName_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "Full Name")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "Full Name";
                t.ForeColor = Color.DimGray;
            }
        }

        private void txtCard_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "Card Number")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtCard_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "Card Number";
                t.ForeColor = Color.DimGray;
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnCerrarSettings_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            Close();
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    btnPay.Text = "Pay coffee";
                    lblMetodo.Text = "Payment method";
                    lblMetodo.Location = new Point(175 - (lblMetodo.Width / 2), 52);
                    break;
                case "ES": //Español
                    btnPay.Text = "Pagar cafe";
                    lblMetodo.Text = "Metodo de pago";
                    lblMetodo.Location = new Point(175 - (lblMetodo.Width / 2), 52);
                    break;
            }
        }

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            /* Paneles */
            BackColor = AjustesDeUsuario.btnBack;
            ForeColor = AjustesDeUsuario.foreColor;
            /* Botones */
            btnCerrarSettings.BackColor = AjustesDeUsuario.btnBack;
            btnCerrarSettings.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnCerrarSettings.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnPay.BackColor = AjustesDeUsuario.btnBack;
            btnPay.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnPay.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            /* Textos (Incluidos botones) */
            lblMetodo.ForeColor = AjustesDeUsuario.foreColor;
            btnCerrarSettings.ForeColor = AjustesDeUsuario.foreColor;
            btnPay.ForeColor = AjustesDeUsuario.foreColor;
            cbxMetodo.ForeColor = AjustesDeUsuario.foreColor;
            cbxMetodo.BackColor = AjustesDeUsuario.btnBack;
        }
    }
}

