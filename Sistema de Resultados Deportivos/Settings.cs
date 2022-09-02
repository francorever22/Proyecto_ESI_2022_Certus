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
                    this.SetTheme();
                    Principal.AlterPrincipal(0, 1, 0);
                    Users.AlterUsers(1);
                    Login.AlterLogin(1);
                    Categorias.AlterCategorias(1);
                    BuscadorDeEncuentros.AlterBuscador(1);
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
    }
}

