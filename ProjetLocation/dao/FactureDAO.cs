using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.dao;
using ProjetLocation.dto;
using ProjetLocation.db;
using ProjetLocation.exception.dao;
using ProjetLocation.exception.dto;
using MySql.Data.MySqlClient;

namespace ProjetLocation.dao
{
    class FactureDAO
    {
        private static string ADD_REQUEST = "INSERT into facture (idFacture,idLocation,dateFacture) " +
            "VALUES(:idFacture, :idLocation, :dateFacture)";

        private static string READ_REQUEST = "SELECT * FROM facture WHERE idFacture = :idFacture";

        private static string UPDATE_REQUEST = "UPDATE facture set idLocation = :idLocation, dateFacture = :dateFacture WHERE idFacture = :idFacture";

        private static string DELETE_REQUEST = "DELETE from facture WHERE idFacture = :idFacture";

        public void Add(Connexion connexion, FactureDTO factureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (factureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            factureDTO = new FactureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idFacture", factureDTO.idFacture));
                command.Parameters.Add(new MySqlParameter(":idLocation", factureDTO.idLocation));
                command.Parameters.Add(new MySqlParameter(":dateFacture", factureDTO.dateFacture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public void READ(Connexion connexion, FactureDTO factureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (factureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            factureDTO = new FactureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter(":dateFacture", factureDTO.dateFacture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public void Update(Connexion connexion, FactureDTO factureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (factureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            factureDTO = new FactureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idLocation", factureDTO.idLocation));
                command.Parameters.Add(new MySqlParameter(":dateFacture", factureDTO.dateFacture));
                command.Parameters.Add(new MySqlParameter(":idFacture", factureDTO.idFacture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public void Delete(Connexion connexion, FactureDTO factureDTO)
        {
            if (connexion == null)
            {
                throw new InvalidConnexionException("La connexion ne peut être null!");
            }
            if (factureDTO == null)
            {
                throw new InvalidDTOException("Le DTO ne peut être null!");
            }
            factureDTO = new FactureDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();
                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idFacture", factureDTO.idFacture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }
    }
}
