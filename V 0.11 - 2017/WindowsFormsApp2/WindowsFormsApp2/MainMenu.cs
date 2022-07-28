using System;
using System.Windows.Forms;

namespace SRD_BackOffice
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            SetIdioma();
            cbxLanguage.SelectedItem = "EN";
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
    }
}
