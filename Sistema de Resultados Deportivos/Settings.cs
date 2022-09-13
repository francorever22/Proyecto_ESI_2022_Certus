namespace Sistema_de_Resultados_Deportivos
{
    public partial class Settings : Form
    {
        bool theme = AjustesDeUsuario.darkTheme;
        bool tray = AjustesDeUsuario.tray;
        String lan = AjustesDeUsuario.language;
        public Settings()
        {
            InitializeComponent();
            SetTheme();
            SetIdioma();
            cbxLenguaje.SelectedItem = AjustesDeUsuario.language;
            tglTema.Checked = theme;
            tglTray.Checked = tray;
        }
        
        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void tglTema_CheckedChanged(object sender, EventArgs e)
        {
            theme = tglTema.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (AjustesDeUsuario.darkTheme != theme)
                {
                    AjustesDeUsuario.darkTheme = theme;
                    AjustesDeUsuario.SetTheme();
                    this.SetTheme();
                    Principal.AlterPrincipal(0, 1, 0);
                    Users.AlterUsers(1);
                    Login.AlterLogin(1);
                    Categorias.AlterCategorias(1);
                    BuscadorDeEncuentros.AlterBuscador(1);
                    Frm_EquiposJugadores.AlterEquiposJugadores();
                    Frm_Encuentros.AlterEncuentros(1);
                }
                if (AjustesDeUsuario.tray != tray)
                {
                    AjustesDeUsuario.tray = tray;
                }
                if (AjustesDeUsuario.language != lan)
                {
                    AjustesDeUsuario.language = lan;
                    this.SetIdioma();
                    Principal.AlterPrincipal(0, 2, 0);
                    Users.AlterUsers(2);
                    Login.AlterLogin(2);
                    BuscadorDeEncuentros.AlterBuscador(2);
                    Frm_Encuentros.AlterEncuentros(2);
                }
                MessageBox.Show("Ajustes guardados correctamente");
            } catch
            {
                MessageBox.Show("Error");
            }
        }
        
        private void btnCerrarSettings_Click(object sender, EventArgs e)
        {
            Parent.Hide();
            this.Close();
        }

        private void cbxLenguaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            lan = cbxLenguaje.Text;
        }

        private void tglTray_CheckedChanged(object sender, EventArgs e)
        {
            tray = tglTray.Checked;
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (AjustesDeUsuario.language)
            {
                case "EN": //Ingles
                    btnGuardar.Text = "Save changes";
                    lblConfiguraciones.Text = "Settings";
                    lblConfiguraciones.Location = new Point(136, 9);
                    lblactivarNotificaciones.Text = "Activate notifications";
                    lblIniciarapp.Text = "Open application on pc startup";
                    lblMinimizarlabandeja.Text = "Minimize to tray";
                    lblLenguaje.Text = "Language";
                    lblTema.Text = "Dark theme";
                    break;
                case "ES": //Español
                    btnGuardar.Text = "Guardar cambios";
                    lblConfiguraciones.Text = "Configuraciones";
                    lblConfiguraciones.Location = new Point(92, 9);
                    lblactivarNotificaciones.Text = "Activar notificaciones";
                    lblIniciarapp.Text = "Abrir app al iniciar el sistema";
                    lblMinimizarlabandeja.Text = "Minimizar a la bandeja";
                    lblLenguaje.Text = "Lenguaje";
                    lblTema.Text = "Tema oscuro";
                    break;
            }
        }

        public void SetTheme() //Establece los colores de los controladores segun el tema elegido
        {
            /* Paneles */
            BackColor = AjustesDeUsuario.panel;
            /* Botones */
            btnCerrarSettings.BackColor = AjustesDeUsuario.btnBack;
            btnCerrarSettings.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnCerrarSettings.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            btnGuardar.BackColor = AjustesDeUsuario.btnBack;
            btnGuardar.FlatAppearance.MouseDownBackColor = AjustesDeUsuario.btnMouseDown;
            btnGuardar.FlatAppearance.MouseOverBackColor = AjustesDeUsuario.btnMouseOver;
            /* Textos (Incluidos botones) */
            btnCerrarSettings.ForeColor = AjustesDeUsuario.foreColor;
            btnGuardar.ForeColor = AjustesDeUsuario.foreColor;
            lblLenguaje.ForeColor = AjustesDeUsuario.foreColor;
            lblMinimizarlabandeja.ForeColor = AjustesDeUsuario.foreColor;
            lblTema.ForeColor = AjustesDeUsuario.foreColor;
            lblConfiguraciones.ForeColor = AjustesDeUsuario.foreColor;
            lblactivarNotificaciones.ForeColor = AjustesDeUsuario.foreColor;
            lblIniciarapp.ForeColor = AjustesDeUsuario.foreColor;
            cbxLenguaje.ForeColor = AjustesDeUsuario.foreColor;
            cbxLenguaje.BackColor = AjustesDeUsuario.btnBack;
            /* Botones on/off */
            tglTema.OffBackColor = Color.Gray;
            tglTema.OffToggleColor = Color.Gainsboro;
            tglTema.OnBackColor = AjustesDeUsuario.foreColor;
            tglTema.OnToggleColor = Color.WhiteSmoke;
            tglTray.OffBackColor = Color.Gray;
            tglTray.OffToggleColor = Color.Gainsboro;
            tglTray.OnBackColor = AjustesDeUsuario.foreColor;
            tglTray.OnToggleColor = Color.WhiteSmoke;
            tglInicio.OffBackColor = Color.Gray;
            tglInicio.OffToggleColor = Color.Gainsboro;
            tglInicio.OnBackColor = AjustesDeUsuario.foreColor;
            tglInicio.OnToggleColor = Color.WhiteSmoke;
            tglNotificaciones.OffBackColor = Color.Gray;
            tglNotificaciones.OffToggleColor = Color.Gainsboro;
            tglNotificaciones.OnBackColor = AjustesDeUsuario.foreColor;
            tglNotificaciones.OnToggleColor = Color.WhiteSmoke;
        }
    }
}

