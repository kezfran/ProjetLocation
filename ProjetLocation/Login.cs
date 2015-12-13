using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetLocation.db;
using MySql.Data.MySqlClient;
using ProjetLocation.service.implementations;
using ProjetLocation.dto;

namespace ProjetLocation
{
    public partial class Login : Form
    {

        public static int UserId;
        public Login()
        {
            InitializeComponent();
            IDRequis.Hide();
            passRequis.Hide();
        }

        private void VerifierLogin()
        {
            EmployeService employe = new EmployeService();
            EmployeDTO emp = new EmployeDTO();

            UserId = Int32.Parse(txtID.Text);
            string motPasse = txtPassword.Text;

            try
            {
                emp = employe.ReadEmploye(UserId);

                if (txtID.Text == string.Empty)
                {
                    IDRequis.Show();
                }
                else if (txtPassword.Text == string.Empty)
                {
                    passRequis.Show();
                }
                else if (emp.IdEmploye != UserId || emp.MotPasse != motPasse)
                {
                    IDRequis.Hide();
                    passRequis.Hide();
                    MessageBox.Show("Votre ID ou votre mot de passe est invalide!");
                }
                else
                {
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Show();
                }

            }
            catch (MySqlException mySqlException)
            {
                throw new Exception(mySqlException.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerifierLogin();
        }
    }
}
