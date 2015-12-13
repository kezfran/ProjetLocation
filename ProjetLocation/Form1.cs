using ProjetLocation.dto;
using ProjetLocation.service.implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetLocation
{
    public partial class Form1 : Form
    {
        Login login = new Login();
        VoitureService voiture = new VoitureService();
        VoitureDTO voitureDTO = new VoitureDTO();
        public Form1()
        {
            InitializeComponent();
        }

        //Déconnexion et fermeture de la form1
        private void logoutUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnAjoutVoiture_Click(object sender, EventArgs e)
        {
            string marque = txtMarqueVoiture.Text;
            string modele = txtModeleVoiture.Text;
            string annee = datePickVoiture.Value.ToString();

            if (txtMarqueVoiture.Text == string.Empty || txtModeleVoiture.Text == string.Empty)
            {
                MessageBox.Show("Aucun champ peut être vide!");
            }
            else
            {
                voitureDTO.marque = marque;
                voitureDTO.modele = modele;
                voitureDTO.annee = annee;
                voiture.AddVoiture(voitureDTO);
                MessageBox.Show("La voiture " + voitureDTO.marque + " modèle " + voitureDTO.modele + " construit en "
                    + voitureDTO.annee + " a été ajoutée.");
            }
        }

        private void btnModifVoiture_Click(object sender, EventArgs e)
        {
            string marque = txtMarqueVoiture.Text;
            string modele = txtModeleVoiture.Text;
            string annee = datePickVoiture.Value.ToString();

            if (txtMarqueVoiture.Text == string.Empty || txtModeleVoiture.Text == string.Empty)
            {
                MessageBox.Show("Aucun champ peut être vide!");
            }
            else
            {
                voitureDTO.marque = marque;
                voitureDTO.modele = modele;
                voitureDTO.annee = annee;
                voiture.AddVoiture(voitureDTO);
                MessageBox.Show("La voiture " + voitureDTO.marque + " modèle " + voitureDTO.modele + " construit en "
                    + voitureDTO.annee + " a été modifiée.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAfficherVoiture_Click(object sender, EventArgs e)
        {
            List<VoitureDTO> voitures = voiture.GetAllVoitures();
            foreach (var v in voitures)
            {
                dGridViewVoiture.Rows.Add(v.idVoiture, v.marque, v.modele, v.annee);
            }
        }


    }
}
