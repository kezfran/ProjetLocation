using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.db;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.exception.dto;
using MySql.Data.MySqlClient;

namespace ProjetLocation.dao
{
    class VoitureDAO
    {
        private static string ADD_REQUEST = "INSERT into voiture (idVoiture,marque,modele,annee) " +
            "VALUES(:idVoiture, :marque, :modele, :annee)";

        private static string READ_REQUEST = "SELECT * FROM voiture WHERE idVoiture = :idVoiture";

        private static string UPDATE_REQUEST = "UPDATE voiture set marque = :marque, modele = :modele, annee = :annee WHERE idVoiture = :idVoiture";

        private static string DELETE_REQUEST = "DELETE from voiture WHERE idVoiture = :idVoiture";

        private static string GET_ALL_REQUEST = "SELECT idVoiture, marque ,modele, annee "
            + "FROM voiture";

        public VoitureDAO()
        {

        }

        public void Add(Connexion connexion, VoitureDTO voitureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (voitureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            voitureDTO = new VoitureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter(":iDvoiture", voitureDTO.idVoiture));
                command.Parameters.Add(new MySqlParameter(":marque", voitureDTO.marque));
                command.Parameters.Add(new MySqlParameter(":modele", voitureDTO.modele));
                command.Parameters.Add(new MySqlParameter(":annee", voitureDTO.annee));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw mySqlException;
            }
        }

        public void Read(Connexion connexion, VoitureDTO voitureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (voitureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            voitureDTO = new VoitureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idVoiture",voitureDTO.idVoiture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public void Update(Connexion connexion, VoitureDTO voitureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (voitureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            voitureDTO = new VoitureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":marque", voitureDTO.marque));
                command.Parameters.Add(new MySqlParameter(":modele", voitureDTO.modele));
                command.Parameters.Add(new MySqlParameter(":annee", voitureDTO.annee));
                command.Parameters.Add(new MySqlParameter(":iDvoiture", voitureDTO.idVoiture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public void Delete(Connexion connexion, VoitureDTO voitureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (voitureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            voitureDTO = new VoitureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idVoiture", voitureDTO.idVoiture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public List<VoitureDTO> GetAll(Connexion connexion, String sortByPropertyName)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (sortByPropertyName == null)
            {
                throw new InvalidSortByPropertyException("Le DTO ne peut être null!");
            }
            List<VoitureDTO> voitures = new List<VoitureDTO>();

            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader datareader = command.ExecuteReader();
                VoitureDTO voitureDTO = null;

                if(datareader.NextResult()){
                    voitureDTO = new VoitureDTO();

                    do
                    {
                        command.Parameters.Add(new MySqlParameter("idVoiture", voitureDTO.idVoiture));
                        command.Parameters.Add(new MySqlParameter("marque", voitureDTO.marque));
                        command.Parameters.Add(new MySqlParameter("modele", voitureDTO.modele));
                        command.Parameters.Add(new MySqlParameter("annee", voitureDTO.annee));
                        voitures.Add(voitureDTO);
                    } while (datareader.NextResult());
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            return voitures;
        }
    }
}
