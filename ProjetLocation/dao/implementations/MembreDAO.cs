using MySql.Data.MySqlClient;
using ProjetLocation.db;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.exception.dto;
using ProjetLocation.dao.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dao
{
    public class MembreDAO : IMembreDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }
        private static string ADD_REQUEST = @"INSERT into membre (nom,telephone,adresse,email,nbLocation) " +
            "VALUES(@nom, @telephone, @adresse,@email,@nbLocation)";

        private static string READ_REQUEST = @"SELECT * FROM membre WHERE idMembre = @idMembre";

        private static string UPDATE_REQUEST = @"UPDATE membre set nom = @nom, telephone = @telephone, adresse = @adresse, email = @email, " +
            "nbLocation = @nbLocation WHERE idMembre = @idMembre";

        private static string DELETE_REQUEST = @"DELETE from membre WHERE idMembre = @idMembre";

        private static string GET_ALL_REQUEST = @"SELECT idMembre, nom ,telephone, adresse, email, nbLocation "
            + "FROM membre";

        public MembreDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        /// <inheritdoc />
        public int Add(MembreDTO membreDTO)
        {
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter("@nom", membreDTO.nom));
                command.Parameters.Add(new MySqlParameter("@telephone", membreDTO.telephone));
                command.Parameters.Add(new MySqlParameter("@adresse", membreDTO.adresse));
                command.Parameters.Add(new MySqlParameter("@email", membreDTO.email));
                command.Parameters.Add(new MySqlParameter("@nbLocation", membreDTO.nbLocation));

                return command.ExecuteNonQuery();
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

        /// <inheritdoc />
        public MembreDTO Read(int id)
        {
            MembreDTO membreDTO = new MembreDTO();
            try
            {
                connexion.Open();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idMembre", id));
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    membreDTO.idMembre = dr.GetInt32(0);
                    membreDTO.nom = dr.GetString(1);
                    membreDTO.telephone = dr.GetString(2);
                    membreDTO.adresse = dr.GetString(3);
                    membreDTO.email = dr.GetString(4);
                    membreDTO.nbLocation = dr.GetInt32(5);
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
            return membreDTO;
        }

        /// <inheritdoc />
        public int Update(MembreDTO membreDTO)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@nom", membreDTO.nom));
                command.Parameters.Add(new MySqlParameter("@telephone", membreDTO.telephone));
                command.Parameters.Add(new MySqlParameter("@adresse", membreDTO.adresse));
                command.Parameters.Add(new MySqlParameter("@email", membreDTO.email));
                command.Parameters.Add(new MySqlParameter("@nbLocation", membreDTO.nbLocation));
                command.Parameters.Add(new MySqlParameter("@idMembre", membreDTO.idMembre));
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

                command.Parameters.Add(new MySqlParameter("@idMembre", id));
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
        public List<MembreDTO> GetAll()
        {
            List<MembreDTO> membres = new List<MembreDTO>();

            MembreDTO membreDTO = new MembreDTO();
            try
            {
                connexion.Open();
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    membreDTO.idMembre = dr.GetInt32(0);
                    membreDTO.nom = dr.GetString(1);
                    membreDTO.telephone = dr.GetString(2);
                    membreDTO.adresse = dr.GetString(3);
                    membreDTO.email = dr.GetString(4);
                    membreDTO.nbLocation = dr.GetInt32(5);
                    membres.Add(membreDTO);
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
            return membres;
        }
    }
}
