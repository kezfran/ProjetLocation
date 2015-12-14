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
        #region Instances des objets à utiliser
        //Login
        Login login = new Login();

        //Voiture
        VoitureService voiture = new VoitureService();
        VoitureDTO voitureDTO = new VoitureDTO();

        //Membre
        MembreService membre = new MembreService();
        MembreDTO membreDTO = new MembreDTO();

        //Réservation
        ReservationService reservation = new ReservationService();
        ReservationDTO reservationDTO = new ReservationDTO();

        LocationService location = new LocationService();
        LocationDTO locationDTO = new LocationDTO();

        #endregion fin des Instances des objets à utiliser

        public Form1()
        {
            InitializeComponent();
        }

        //Déconnexion et fermeture de la form1
        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        #region Gestion des voitures
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
                MessageBox.Show("Cette voiture " + /*voitureDTO.marque + " modèle " + voitureDTO.modele + " construit en "
                    + voitureDTO.annee +*/ " a été ajoutée!");
                afficherVoitures();
            }
        }

        /// <summary>
        ///     Bouton de modification de la voiture.
        /// </summary>
        private void btnModifVoiture_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDVoiture.Text);
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
                afficherVoitures();
            }
        }

        /// <summary>
        ///     Bouton de suppression de la voiture.
        /// </summary>
        private void btnSupprimeVoiture_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDVoiture.Text);

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
            afficherVoitures();
        }

        /// <summary>
        /// Bouton d'affichage de toutes les voitures.
        /// </summary>
        private void btnAfficherVoiture_Click(object sender, EventArgs e)
        {
            afficherVoitures();
        }

        /// <summary>
        /// DataGridView des voitures.
        /// </summary>
        private void dGridViewVoiture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGridViewVoiture.SelectedCells.Count > 0)
            {
                int i = dGridViewVoiture.SelectedCells[0].RowIndex;
                int IDVoiture = Int32.Parse(dGridViewVoiture.Rows[i].Cells[0].Value.ToString());

                txtIDVoiture.Text = IDVoiture.ToString();
            }
        }

        /// <summary>
        /// Affiche les voitures.
        /// </summary>
        private void afficherVoitures() {
            dGridViewVoiture.Rows.Clear();
            List<VoitureDTO> voitures = voiture.GetAllVoitures();
            foreach (var v in voitures)
            {
                dGridViewVoiture.Rows.Add(v.idVoiture, v.marque, v.modele, v.annee);
            }
        }
        #endregion fin de la Gestion des voitures

        #region Gestion des membres
        /// <summary>
        /// Bouton d'ajout des membres.
        /// </summary>
        private void btnAjoutMembre_Click(object sender, EventArgs e)
        {
            string nom = txtNomMembre.Text;
            string telephone = txtPhoneMembre.Text;
            string adresse = txtAdressMembre.Text;
            string email = txtMailMembre.Text;
            int nbLocations = Int32.Parse(txtNbLocMembre.Text);

            if (txtNomMembre.Text == string.Empty || txtPhoneMembre.Text == string.Empty
                || txtAdressMembre.Text == string.Empty || txtMailMembre.Text == string.Empty || txtNbLocMembre.Text == string.Empty)
            {
                MessageBox.Show("Aucun champ peut être vide!");
            }
            else
            {
                membreDTO.nom = nom;
                membreDTO.telephone = telephone;
                membreDTO.adresse = adresse;
                membreDTO.email = email;
                membreDTO.nbLocation = nbLocations;
                membre.AddMembre(membreDTO);
                MessageBox.Show("Le membre " + membreDTO.nom + " a été ajouté!");
                afficherMembres();
            }
        }

        /// <summary>
        /// Bouton de modification des membres.
        /// </summary>
        private void btnModifMembre_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDMembre.Text);
            string nom = txtNomMembre.Text;
            string telephone = txtPhoneMembre.Text;
            string adresse = txtAdressMembre.Text;
            string email = txtMailMembre.Text;
            int nbLocations = Int32.Parse(txtNbLocMembre.Text);

            if (txtIDMembre.Text == string.Empty|| txtNomMembre.Text == string.Empty || txtPhoneMembre.Text == string.Empty
                || txtAdressMembre.Text == string.Empty || txtMailMembre.Text == string.Empty || txtNbLocMembre.Text == string.Empty)
            {
                MessageBox.Show("Aucun champ peut être vide!");
            }
            else
            {
                membreDTO.nom = nom;
                membreDTO.telephone = telephone;
                membreDTO.adresse = adresse;
                membreDTO.email = email;
                membreDTO.nbLocation = nbLocations;
                membre.UpdateMembre(membreDTO,id);
                MessageBox.Show("Ce membre " /*+ membreDTO.nom*/ + " a été ajouté!");
                afficherMembres();
            }
        }

        /// <summary>
        /// Bouton des suppressions des membres.
        /// </summary>
        private void btnSupprimMembre_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDMembre.Text);

            membre.DeleteMembre(id);
            MessageBox.Show("Ce membre " + /* voitureDTO.marque + " modèle " + voitureDTO.modele +*/ " a été supprimé!");
            afficherMembres();
        }

        /// <summary>
        /// Bouton d'affichage des membres.
        /// </summary>
        private void btnAfficherMembre_Click(object sender, EventArgs e)
        {
            afficherMembres();
        }

        /// <summary>
        /// DataGridView des membres
        /// </summary>
        private void dGridViewMembre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGridViewMembre.SelectedCells.Count > 0)
            {
                int i = dGridViewMembre.SelectedCells[0].RowIndex;
                int IDMembre = Int32.Parse(dGridViewMembre.Rows[i].Cells[0].Value.ToString());

                txtIDMembre.Text = IDMembre.ToString();
            }
        }

        /// <summary>
        /// Affiche la liste des membres
        /// </summary>
        private void afficherMembres()
        {
            dGridViewMembre.Rows.Clear();
            List<MembreDTO> membres = membre.GetAllMembres();
            foreach (var m in membres)
            {
                dGridViewMembre.Rows.Add(m.idMembre, m.nom, m.telephone, m.adresse, m.email, m.nbLocation);
            }
        }
        #endregion fin de la Gestion des membres

        #region Gestion des réservations
        /// <summary>
        /// 
        /// </summary>
        private void btnAjoutReservation_Click(object sender, EventArgs e)
        {
            int idMembre = Int32.Parse(txtIDMembreReservation.Text);
            int idVoiture = Int32.Parse(txtIDVoitureReservation.Text);
            int idEmploye = Int32.Parse(txtIDEmployeReservation.Text);
            string dateReservation = datePickReservation.Value.ToString();

            if (txtIDMembreReservation.Text == string.Empty || txtIDVoitureReservation.Text == string.Empty || 
                txtIDEmployeReservation.Text == string.Empty)
            {
                MessageBox.Show("Aucun champ peut être vide!");
            }
            else
            {
                reservationDTO.IdMembre = idMembre;
                reservationDTO.IdVoiture = idVoiture;
                reservationDTO.IdEmploye = idEmploye;
                reservationDTO.DateReservation = dateReservation;
                reservation.AddReservation(reservationDTO);
                MessageBox.Show("Cette réservation a été ajoutée");
                afficherReservations();
            }
        }

        private void btnModifReservation_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDReservation.Text);
            int idMembre = Int32.Parse(txtIDMembreReservation.Text);
            int idVoiture = Int32.Parse(txtIDVoitureReservation.Text);
            int idEmploye = Int32.Parse(txtIDEmployeReservation.Text);
            string dateReservation = datePickReservation.Value.ToString();

            if (txtIDReservation.Text == string.Empty || txtIDMembreReservation.Text == string.Empty ||
                txtIDVoitureReservation.Text == string.Empty || txtIDEmployeReservation.Text == string.Empty)
            {
                MessageBox.Show("Aucun champ peut rester vide!");
            }
            else
            {
                reservationDTO.IdMembre = idMembre;
                reservationDTO.IdVoiture = idVoiture;
                reservationDTO.IdEmploye = idEmploye;
                reservationDTO.DateReservation = dateReservation;
                reservation.UpdateReservation(reservationDTO, id);
                MessageBox.Show("Cette réservation a été modifiée");
                afficherReservations();
            }
        }

        private void btnSupprimReservation_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIDReservation.Text);

            reservation.DeleteReservation(id);
            MessageBox.Show("Cette réservation est supprimée!");
            afficherReservations();
        }

        private void afficherReservations()
        {
            dGridViewReservation.Rows.Clear();
            List<ReservationDTO> reservations = reservation.GetAllReservations();
            foreach (var r in reservations)
            {
                dGridViewReservation.Rows.Add(r.IdReservation, r.IdMembre, r.IdVoiture, r.IdEmploye, r.DateReservation);
            }
        }

        private void AfficherReservation_Click(object sender, EventArgs e)
        {
            afficherReservations();
        }

        private void dGridViewReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGridViewReservation.SelectedCells.Count > 0)
            {
                int i = dGridViewReservation.SelectedCells[0].RowIndex;
                int IDReservation = Int32.Parse(dGridViewReservation.Rows[i].Cells[0].Value.ToString());

                txtIDReservation.Text = IDReservation.ToString();
            }
        }
        #endregion fin de la Gestion des réservations

        private void btnAfficherLocations_Click(object sender, EventArgs e)
        {
            afficherLocations();
        }

        private void afficherLocations()
        {
            dGridViewLocation.Rows.Clear();
            List<LocationDTO> locations = location.GetAllLocations();
            foreach (var l in locations)
            {
                dGridViewLocation.Rows.Add(l.IdLocation,l.IdMembre,l.IdVoiture,l.DateLocation,l.DateRetour);
            }
        }
    }
}
