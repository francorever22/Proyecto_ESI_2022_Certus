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

            cbxLanguage.Text = Program.language;
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

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblTitle.Text = "Aplication administrator";
                    lblTitle.Location = new Point(315, 9);
                    btnManageEvents.Text = "Manage events";
                    btnManageEvents.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    AddEvent.Text = "Add event";
                    AddEvent.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAddMatch.Text = "Add match";
                    btnAddMatch.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageMatch.Text = "Manage matchs";
                    btnManageMatch.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAgregarAdmin.Text = "Add administrator";
                    btnAgregarAdmin.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAgregarCategoria.Text = "Add category";
                    btnAgregarCategoria.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAgregarDeporte.Text = "Add sport";
                    btnAgregarDeporte.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnGestionarBanner.Text = "Manage banners";
                    btnGestionarBanner.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageSports.Text = "Manage sports";
                    btnManageSports.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageUsers.Text = "Manage users";
                    btnManageUsers.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAddAthlete.Text = "Add athlete";
                    btnAddAthlete.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageAthletes.Text = "Manage athletes";
                    btnManageAthletes.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAddTeam.Text = "Add team";
                    btnAddTeam.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageTeam.Text = "Manage teams";
                    btnManageTeam.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageAdmins.Text = "Manage admins";
                    btnManageAdmins.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    break;
                case "ES": //Español
                    lblTitle.Text = "Administrador de la aplicación";
                    lblTitle.Location = new Point(257, 9);
                    btnManageEvents.Text = "Administrar eventos";
                    btnManageEvents.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    AddEvent.Text = "Agregar evento";
                    AddEvent.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAddMatch.Text = "Agregar encuentro";
                    btnAddMatch.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageMatch.Text = "Administrar encuentros";
                    btnManageMatch.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAgregarAdmin.Text = "Agregar administrador";
                    btnAgregarAdmin.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAgregarCategoria.Text = "Agregar categoría";
                    btnAgregarCategoria.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAgregarDeporte.Text = "Agregar deporte";
                    btnAgregarDeporte.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnGestionarBanner.Text = "Administrar banners";
                    btnGestionarBanner.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageSports.Text = "Administrar deportes";
                    btnManageSports.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageUsers.Text = "Administrar usuarios";
                    btnManageUsers.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAddAthlete.Text = "Agregar deportista";
                    btnAddAthlete.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageAthletes.Text = "Administrar deportistas";
                    btnManageAthletes.Font = new Font("Montserrat", 8F, FontStyle.Regular, GraphicsUnit.Point);
                    btnAddTeam.Text = "Agregar equipo";
                    btnAddTeam.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageTeam.Text = "Administrar equipos";
                    btnManageTeam.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    btnManageAdmins.Text = "Administrar admins";
                    btnManageAdmins.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
                    break;
            }
        }
    }
}
