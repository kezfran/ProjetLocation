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
using ProjetLocation.dao.interfaces;

namespace ProjetLocation.dao
{
    class FactureDAO : IFactureDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }
        private static string ADD_REQUEST = "INSERT into facture (idFacture,idLocation,dateFacture) " +
            "VALUES(:idFacture, :idLocation, :dateFacture)";

        private static string READ_REQUEST = "SELECT * FROM facture WHERE idFacture = :idFacture";

        private static string UPDATE_REQUEST = "UPDATE facture set idLocation = :idLocation, dateFacture = :dateFacture WHERE idFacture = :idFacture";

        private static string DELETE_REQUEST = "DELETE from facture WHERE idFacture = :idFacture";

        public FactureDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        public void Add(Connexion connexion, FactureDTO factureDTO)
        {
            
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idFacture", factureDTO.idFacture));
                command.Parameters.Add(new MySqlParameter(":idLocation", factureDTO.idLocation));
                command.Parameters.Add(new MySqlParameter(":dateFacture", factureDTO.dateFacture));
                 command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw mySqlException;
            }
            finally
            {
                connexion.Close();
            }
        }

        public void READ( FactureDTO factureDTO)
        {
           
            factureDTO = new FactureDTO();
            try
            {
                connexion.Open();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter(":dateFacture", factureDTO.dateFacture));
                MySqlDataReader dr = command.ExecuteReader();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
            
        }

        public void Update( FactureDTO factureDTO)
        {
          
        
            
            try
            {
                connexion.Open();
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
            finally
            {
                connexion.Close();
            }
        }

        public void Delete( FactureDTO factureDTO)
        {
            
            try
            {
                connexion.Open();
                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idFacture", factureDTO.idFacture));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
        }
    }
}
