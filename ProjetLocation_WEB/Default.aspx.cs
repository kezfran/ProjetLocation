using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetLocation.db;
using MySql.Data.MySqlClient;
using ProjetLocation.service.implementations;
using ProjetLocation.dto;

namespace ProjetLocation_WEB
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserAuthentication"] != null)
            {
                Response.Redirect("~/Manage.aspx");
            }
            IDRequis.Visible = false;
            passRequis.Visible = false;
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
                    IDRequis.Visible = true;
                }else if(motPasse.Equals(null)){
                    passRequis.Visible = true;
                }
                else if (emp.IdEmploye != id || emp.MotPasse != motPasse)
                {
                    IDRequis.Visible = false;
                    passRequis.Visible = false;
                    MessageBox.Show("Votre ID ou votre mot de passe est invalide!");
                    // INVALID PASS
                }
                else
                {
                    // SUCCESSFUL LOGIN
                    Session["UserAuthentication"] = emp.IdEmploye;
                    Response.Redirect("Manage.aspx");
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            VerificationLogin();
        }
    }
}