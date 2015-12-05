using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.db;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.exception.dto;
using ProjetLocation.dao.interfaces;
using MySql.Data.MySqlClient;

namespace ProjetLocation.dao
{
    public class VoitureDAO : IVoitureDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }

        private static string ADD_REQUEST = @"INSERT into voiture (marque,modele,annee) " +
            "VALUES(@marque, @modele, @annee)";

        private static string READ_REQUEST = @"SELECT * FROM voiture WHERE idVoiture = @idVoiture";

        private static string UPDATE_REQUEST = @"UPDATE voiture set marque = @marque, modele = @modele, annee = @annee WHERE idVoiture = @idVoiture";

        private static string DELETE_REQUEST = @"DELETE from voiture WHERE idVoiture = @idVoiture";

        private static string GET_ALL_REQUEST = @"SELECT idVoiture, marque ,modele, annee "
            + "FROM voiture";

        public VoitureDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        /// <inheritdoc />
        public int Add(VoitureDTO voitureDTO)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter("@iDvoiture", voitureDTO.idVoiture));
                command.Parameters.Add(new MySqlParameter("@marque", voitureDTO.marque));
                command.Parameters.Add(new MySqlParameter("@modele", voitureDTO.modele));
                command.Parameters.Add(new MySqlParameter("@annee", voitureDTO.annee));
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
        public VoitureDTO Read(int id)
        {
            VoitureDTO voitureDTO = new VoitureDTO();
            try
            {
                connexion.Open();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idVoiture",id));
                MySqlDataReader dr = command.ExecuteReader();

                if(dr.Read()){
                    voitureDTO.idVoiture = dr.GetInt32(0);
                    voitureDTO.marque = dr.GetString(1);
                    voitureDTO.modele = dr.GetString(2);
                    voitureDTO.annee = dr.GetDateTime(3);
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
            return voitureDTO;
        }

        /// <inheritdoc />
        public int Update(VoitureDTO voitureDTO)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@marque", voitureDTO.marque));
                command.Parameters.Add(new MySqlParameter("@modele", voitureDTO.modele));
                command.Parameters.Add(new MySqlParameter("@annee", voitureDTO.annee));
                command.Parameters.Add(new MySqlParameter("@idVoiture", voitureDTO.idVoiture));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
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

                command.Parameters.Add(new MySqlParameter("@idVoiture", id));
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
        public List<VoitureDTO> GetAll()
        {
            List<VoitureDTO> voitures = new List<VoitureDTO>();
            VoitureDTO voitureDTO = new VoitureDTO();
            try
            {
                connexion.Open();
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    voitureDTO.idVoiture = dr.GetInt32(0);
                    voitureDTO.marque = dr.GetString(1);
                    voitureDTO.modele = dr.GetString(2);
                    voitureDTO.annee = dr.GetDateTime(3);
                    voitures.Add(voitureDTO);
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
            return voitures;
        }
    }
}
