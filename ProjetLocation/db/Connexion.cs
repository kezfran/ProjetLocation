using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProjetLocation.db
{
    class Connexion
    {
        private MySqlConnection connection;

        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public Connexion()
        {
            connection.ConnectionString = @"Server = localhost; database = rent; Uid = rent; Pwd = 123456";
        }

        public bool Open()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException mySqlException)
            {
                switch (mySqlException.Number)
                {
                    case 0:
                        MessageBox.Show("La connexion est impossible!");
                        break;
                    case 1045:
                        MessageBox.Show("Les informations de la connexion sont invalide!");
                        break;
                }
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException mySqlException)
            {
                MessageBox.Show(mySqlException.Message);
                return false;
            }
        }
    }
}
