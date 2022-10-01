using MySql.Data.MySqlClient;

namespace Sistema_de_Resultados_Deportivos
{
    internal class DB_Connection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DB_Connection()
        {
            Connection();
        }

        private void Connection()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            uid = "username";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public void DB_Manager(int x)
        {
            switch (x)
            {
                case 0:
                    Connection_Open();
                    break;
                case 1:
                    Connection_Close();
                    break;
            }
        }

        private bool Connection_Open()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("La aplicación no puede conectarse al servidor, vuelva a intentar nuevamente o contacte a un administrador");
                        break;
                    case 1045:
                        MessageBox.Show("usuario y/o contraseña no validos");
                        break;
                }
                return false;
            }
        }

        private bool Connection_Close()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
