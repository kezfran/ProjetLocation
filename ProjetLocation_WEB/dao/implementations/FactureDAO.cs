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
    public class FactureDAO : IFactureDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }

        private static string ADD_REQUEST = @"INSERT into facture (idLocation,idEmploye,dateFacture) " +
            "VALUES(@idLocation, @idEmploye, @dateFacture)";

        private static string READ_REQUEST = "SELECT * FROM facture WHERE idFacture = @idFacture";

        private static string UPDATE_REQUEST = @"UPDATE facture set idLocation = @idLocation, idEmploye = @idEmploye, " + 
            "dateFacture = @dateFacture WHERE idFacture = @idFacture";

        private static string DELETE_REQUEST = @"DELETE from facture WHERE idFacture = @idFacture";

        private static string GET_ALL_REQUEST = @"SELECT idFacture, idLocation ,idEmploye,dateFacture "
            + "FROM facture";

        private static String FIND_BY_LOCATION = @"SELECT idFacture, idLocation, idEmploye, dateFacture FROM facture " +
            "WHERE idLocation = @idLocation";

        private static String FIND_BY_EMPLOYE = @"SELECT idFacture, idLocation, idEmploye, dateFacture FROM facture " +
            "WHERE idEmploye = @idEmploye";

        public FactureDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        /// <inheritdoc />
        public int Add(FactureDTO factureDTO)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idLocation", factureDTO.IdLocation));
                command.Parameters.Add(new MySqlParameter("@idEmploye", factureDTO.IdEmploye));
                command.Parameters.Add(new MySqlParameter("@dateFacture", factureDTO.DateFacture));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw mySqlException;
            }
            finally
            {
                connexion.Close();
            }
            return n;
        }

        /// <inheritdoc />
        public FactureDTO Read(int id)
        {
            FactureDTO factureDTO = new FactureDTO();
            try
            {
                connexion.Open();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idFacture", id));
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    factureDTO.IdFacture = dr.GetInt32(0);
                    factureDTO.IdLocation = dr.GetInt32(1);
                    factureDTO.IdEmploye = dr.GetInt32(2);
                    factureDTO.DateFacture = dr.GetDateTime(3).ToString();
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
            return factureDTO;
        }

        /// <inheritdoc />
        public int Update(FactureDTO factureDTO, int id)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idLocation", factureDTO.IdLocation));
                command.Parameters.Add(new MySqlParameter("@idEmploye", factureDTO.IdEmploye));
                command.Parameters.Add(new MySqlParameter("@dateFacture", factureDTO.DateFacture));
                command.Parameters.Add(new MySqlParameter("@idFacture", id));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
            return n;
        }

        /// <inheritdoc />
        public int Delete(int id)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idFacture", id));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
            return n;
        }

        /// <inheritdoc />
        public List<FactureDTO> GetAll()
        {
            List<FactureDTO> factures = new List<FactureDTO>();
            FactureDTO factureDTO = new FactureDTO();
            try
            {
                connexion.Open();
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    factureDTO.IdFacture = dr.GetInt32(0);
                    factureDTO.IdLocation = dr.GetInt32(1);
                    factureDTO.IdEmploye = dr.GetInt32(2);
                    factureDTO.DateFacture = dr.GetDateTime(3).ToString();
                    factures.Add(factureDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
            return factures;
        }

         /// <inheritdoc />
        public List<FactureDTO> FindByLocation(int id)
        {
            List<FactureDTO> factures = new List<FactureDTO>();
            FactureDTO factureDTO = new FactureDTO();
            try
            {
                connexion.Open();
                command.CommandText = FIND_BY_LOCATION;

                command.Parameters.Add(new MySqlParameter("@idLocation", id));

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    factureDTO.IdFacture = dr.GetInt32(0);
                    factureDTO.IdLocation = dr.GetInt32(1);
                    factureDTO.IdEmploye = dr.GetInt32(2);
                    factureDTO.DateFacture = dr.GetDateTime(3).ToString();
                    factures.Add(factureDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
            return factures;
        }

        public List<FactureDTO> FindByEmploye(int id)
        {
            List<FactureDTO> factures = new List<FactureDTO>();
            FactureDTO factureDTO = new FactureDTO();
            try
            {
                connexion.Open();
                command.CommandText = FIND_BY_EMPLOYE;

                command.Parameters.Add(new MySqlParameter("@idEmploye", id));

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    factureDTO.IdFacture = dr.GetInt32(0);
                    factureDTO.IdLocation = dr.GetInt32(1);
                    factureDTO.IdEmploye = dr.GetInt32(2);
                    factureDTO.DateFacture = dr.GetDateTime(3).ToString();
                    factures.Add(factureDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            finally
            {
                connexion.Close();
            }
            return factures;
        }
    }
}
