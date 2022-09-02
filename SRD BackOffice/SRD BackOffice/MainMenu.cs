namespace SRD_BackOffice
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            SetIdioma();

            if (Program.boss == false)
            {
                btnAgregarAdmin.Enabled = false;
                btnManageAdmins.Enabled = false;
                btnAgregarAdmin.Hide();
                btnManageAdmins.Hide();
            }

            cbxLanguage.SelectedIndex = 0;
        }

        private void btnAgregarAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAgregarAdmin addAdmin = new MenuAgregarAdmin();
            addAdmin.StartPosition = FormStartPosition.CenterParent;
            addAdmin.ShowDialog();
            this.Close();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCrearCategoria crearCategoria = new MenuCrearCategoria();
            crearCategoria.StartPosition = FormStartPosition.CenterParent;
            crearCategoria.ShowDialog();
            this.Close();
        }

        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCrearDeporte crearDeporte = new MenuCrearDeporte();
            crearDeporte.StartPosition = FormStartPosition.CenterParent;
            crearDeporte.ShowDialog();
            this.Close();
        }

        private void btnMainCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGestionarBanner_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuGestionarBanners gestionarBanners = new MenuGestionarBanners();
            gestionarBanners.StartPosition = FormStartPosition.CenterParent;
            gestionarBanners.ShowDialog();
            this.Close();
        }

        private void btnManageSportsAndCategories_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuManageSports manageSports = new MenuManageSports();
            manageSports.StartPosition = FormStartPosition.CenterParent;
            manageSports.ShowDialog();
            this.Close();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuManageUsers manageUsers = new MenuManageUsers();
            manageUsers.StartPosition = FormStartPosition.CenterParent;
            manageUsers.ShowDialog();
            this.Close();
        }

        private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.language = cbxLanguage.Text;
            SetIdioma();
        }

        private void AddEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCrearEvento crearEvento = new MenuCrearEvento();
            crearEvento.StartPosition = FormStartPosition.CenterParent;
            crearEvento.ShowDialog();
            this.Close();
        }

        private void btnManageEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuManageEvents manageEvento = new MenuManageEvents();
            manageEvento.StartPosition = FormStartPosition.CenterParent;
            manageEvento.ShowDialog();
            this.Close();
        }

        private void btnAddAthlete_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCrearDeportista addAthlete = new MenuCrearDeportista();
            addAthlete.StartPosition = FormStartPosition.CenterParent;
            addAthlete.ShowDialog();
            this.Close();
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCrearEquipo addTeam = new MenuCrearEquipo();
            addTeam.StartPosition = FormStartPosition.CenterParent;
            addTeam.ShowDialog();
            this.Close();
        }

        private void btnMangeTeam_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuManageTeams manageTeam = new MenuManageTeams();
            manageTeam.StartPosition = FormStartPosition.CenterParent;
            manageTeam.ShowDialog();
            this.Close();
        }

        private void btnManageAthletes_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuManageAthletes manageAthletes = new MenuManageAthletes();
            manageAthletes.StartPosition = FormStartPosition.CenterParent;
            manageAthletes.ShowDialog();
            this.Close();
        }

        private void btnManageAdmins_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuManageAdministradores manageAdmins = new MenuManageAdministradores();
            manageAdmins.StartPosition = FormStartPosition.CenterParent;
            manageAdmins.ShowDialog();
            this.Close();
        }
    }
}
