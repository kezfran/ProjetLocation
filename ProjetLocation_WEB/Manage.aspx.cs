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
using MySql.Data;
using ProjetLocation.service.implementations;
using ProjetLocation.dto;
using ProjetLocation.dao;

namespace ProjetLocation_WEB
{
    public partial class Contact : Page
    {
        VoitureDAO voitDAO = new VoitureDAO();
        VoitureDTO voitDTO = new VoitureDTO();

        MembreDAO membreDAO = new MembreDAO();
        MembreDTO membreDTO = new MembreDTO();

        ReservationDAO reservDAO = new ReservationDAO();
        ReservationDTO reservDTO = new ReservationDTO();

        LocationDAO locDAO = new LocationDAO();
        LocationDTO locDTO = new LocationDTO();

        FactureDAO facDAO = new FactureDAO();
        FactureDTO facDTO = new FactureDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserAuthentication"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                UpdateVoitGridView();
                UpdateMembreGridView();
                UpdateReservGridView();
                UpdateLocGridView();
                UpdateFacGridView();
            }
        }

        protected void ajoutVoiture_Click(object sender, EventArgs e)
        {
            voitDTO.idVoiture = Int32.Parse(txtID.Text);
            voitDTO.marque = txtMarque.Text;
            voitDTO.annee = txtAnnee.Text;
            voitDTO.modele = txtModele.Text;
            voitDAO.Add(voitDTO);
            UpdateVoitGridView();
        }

        protected void modVoiture_Click(object sender, EventArgs e)
        {
            voitDTO.idVoiture = Int32.Parse(txtID.Text);
            voitDTO.marque = txtMarque.Text;
            voitDTO.annee = txtAnnee.Text;
            voitDTO.modele = txtModele.Text;
            voitDAO.Update(voitDTO, Int32.Parse(txtID.Text));
            UpdateVoitGridView();
        }

        protected void delVoiture_Click(object sender, EventArgs e)
        {
            voitDAO.Delete(Int32.Parse(txtID.Text));
            UpdateVoitGridView();
        }

        public void UpdateVoitGridView()
        {
            string MyConString = "Server = localhost; database = rent; Uid = root; Pwd = ; Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT idVoiture, marque, modele, annee FROM voiture", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            voitGridView.DataSource = dataTable;
            voitGridView.DataBind();
            conn.Close();
        }

        public void UpdateMembreGridView()
        {
            string MyConString = "Server = localhost; database = rent; Uid = root; Pwd = ; Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT idMembre, nom ,telephone, adresse, email, nbLocation FROM membre", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            membreGridView.DataSource = dataTable;
            membreGridView.DataBind();
            conn.Close();
        }
        public void UpdateReservGridView()
        {
            string MyConString = "Server = localhost; database = rent; Uid = root; Pwd = ; Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT idReservation,idMembre,idVoiture,idEmploye,dateReservation FROM reservation", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            reservGridView.DataSource = dataTable;
            reservGridView.DataBind();
            conn.Close();
        }
        public void UpdateLocGridView()
        {
            string MyConString = "Server = localhost; database = rent; Uid = root; Pwd = ; Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT idLocation,idMembre,idVoiture,dateLocation,dateRetour FROM location", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            locGridView.DataSource = dataTable;
            locGridView.DataBind();
            conn.Close();
        }
        public void UpdateFacGridView()
        {
            string MyConString = "Server = localhost; database = rent; Uid = root; Pwd = ; Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT idFacture, idLocation ,idEmploye,dateFacture FROM facture", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            facGridView.DataSource = dataTable;
            facGridView.DataBind();
            conn.Close();
        }

        protected void ajoutEmploye_Click(object sender, EventArgs e)
        {
            membreDTO.idMembre = Int32.Parse(txteID.Text);
            membreDTO.nom = txtNom.Text;
            membreDTO.telephone = txtTelephone.Text;
            membreDTO.adresse = txtAdresse.Text;
            membreDTO.email = txtEmail.Text;
            membreDTO.nbLocation = Int32.Parse(txtLocation.Text);
            membreDAO.Add(membreDTO);
            UpdateMembreGridView();
        }

        protected void modEmploye_Click(object sender, EventArgs e)
        {
            membreDTO.idMembre = Int32.Parse(txteID.Text);
            membreDTO.nom = txtNom.Text;
            membreDTO.telephone = txtTelephone.Text;
            membreDTO.adresse = txtAdresse.Text;
            membreDTO.email = txtEmail.Text;
            membreDTO.nbLocation = Int32.Parse(txtLocation.Text);
            membreDAO.Update(membreDTO, Int32.Parse(txtID.Text));
            UpdateMembreGridView();
        }

        protected void delEmploye_Click(object sender, EventArgs e)
        {
            membreDAO.Delete(Int32.Parse(txteID.Text));
            UpdateMembreGridView();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session["UserAuthentication"] != null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}