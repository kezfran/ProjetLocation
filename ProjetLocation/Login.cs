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
        //Connexion connexion { get; set; }
        //MySqlCommand command { get; set; }
        Form1 form1 = new Form1();
        public Login()
        {
            InitializeComponent();
            //connexion = new Connexion();
            //command = connexion.Connection.CreateCommand();
            IDRequis.Hide();
            passRequis.Hide();
        }

        private void VerificationLogin()
        {
            EmployeService employe = new EmployeService();
            EmployeDTO emp = new EmployeDTO();

            int id = Int32.Parse(txtID.Text);
            string motPasse = txtPassword.Text;

            try
            {
                //connexion.Open();
                emp = employe.ReadEmploye(id);

                if (txtID.Equals(null))
                {
                    IDRequis.Show();
                }else if(motPasse.Equals(null)){
                    passRequis.Show();
                }
                else if (emp.IdEmploye != id || emp.MotPasse != motPasse)
                {
                    IDRequis.Hide();
                    passRequis.Hide();
                    MessageBox.Show("Votre ID ou votre mot de passe est invalide!");
                }
                else
                {
                    this.Hide();
                    form1.Show();
                }

            }
            catch (MySqlException mySqlException)
            {
                throw new Exception(mySqlException.Message);
            }
            //finally 
            //{ 
            //    //connexion.Close();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerificationLogin();
        }
    }
}
