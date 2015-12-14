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

        #region Gestion de la voiture
        /// <summary>
        ///     Bouton d'ajout de la voiture.
        /// </summary>
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

        /// <summary>
        ///     Bouton de modification de la voiture.
        /// </summary>
        private void btnModifVoiture_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDVoiture.Text.ToString());

            //VoitureDTO voitureTemp = new VoitureDTO();
            //voitureTemp = voiture.ReadVoiture(id);

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
                voiture.UpdateVoiture(voitureDTO, id);
                MessageBox.Show("Cette voiture " + /*voitureTemp.marque +*/ " modèle " /*+ voitureTemp.modele*/ + " a été modifiée.");
            }
        }

        /// <summary>
        ///     Bouton de suppression de la voiture.
        /// </summary>
        private void btnSupprimeVoiture_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDVoiture.Text.ToString());

            //if (id == null)
            //{
            //    MessageBox.Show("Veuillez séléctionner une voiture à supprimer!!!");
            //}
            //else
            //{
            //voitureDTO = voiture.ReadVoiture(id);
            voiture.DeleteVoiture(id);
            MessageBox.Show("Cette voiture " + /* voitureDTO.marque + " modèle " + voitureDTO.modele +*/ " a été supprimée!");
            //}
        }

        /// <summary>
        ///     Bouton d'affichage de toutes les voitures.
        /// </summary>
        private void btnAfficherVoiture_Click(object sender, EventArgs e)
        {
            //dGridViewVoiture
            List<VoitureDTO> voitures = voiture.GetAllVoitures();
            foreach (var v in voitures)
            {
                dGridViewVoiture.Rows.Add(v.idVoiture, v.marque, v.modele, v.annee);
            }
        }
        #endregion fin de la Gestion de la voiture

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

        private void dGridViewVoiture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGridViewVoiture.SelectedCells.Count > 0)
            {
                int i = dGridViewVoiture.SelectedCells[0].RowIndex;
                int IDVoiture = Int32.Parse(dGridViewVoiture.Rows[i].Cells[0].Value.ToString());

                txtIDVoiture.Text = IDVoiture.ToString();
            }
        }


    }
}
