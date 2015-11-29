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
    class MembreDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }
        private static string ADD_REQUEST = "INSERT into membre (idMembre,nom,telephone,adresse,email,nbLocation) " +
            "VALUES(:idMembre, :nom, :telephone, :adresse,:email,:nbLocation)";

        private static string READ_REQUEST = "SELECT * FROM membre WHERE idMembre = :idMembre";

        private static string UPDATE_REQUEST = "UPDATE membre set nom = :nom, telephone = :telephone, adresse = :adresse, email = :email, " +
            "nbLocation = :nbLocation WHERE idMembre = :idMembre";

        private static string DELETE_REQUEST = "DELETE from membre WHERE idMembre = :idMembre";

        private static string GET_ALL_REQUEST = "SELECT idMembre, nom ,telephone, adresse, email, nbLocation "
            + "FROM membre";

        public MembreDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        public int Add(MembreDTO membreDTO)
        {
            int n=0;
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idMembre", membreDTO.idMembre));
                command.Parameters.Add(new MySqlParameter(":nom", membreDTO.nom));
                command.Parameters.Add(new MySqlParameter(":telephone", membreDTO.telephone));
                command.Parameters.Add(new MySqlParameter(":adresse", membreDTO.adresse));
                command.Parameters.Add(new MySqlParameter(":email", membreDTO.email));
                command.Parameters.Add(new MySqlParameter(":nbLocation", membreDTO.nbLocation));

              n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw  mySqlException;
            }
            finally
            {
                connexion.Close();
            }
            return n;
        }

        public MembreDTO Read(String id)
        {
            MembreDTO membreDTO = new MembreDTO();
            try
            {
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idMembre", id));
                MySqlDataReader dr = command.ExecuteReader();
                
                if (dr.Read())
                {
                    membreDTO.idMembre = dr.GetString(0);
                    membreDTO.nom = dr.GetString(1);
                    membreDTO.telephone = dr.GetString(2);
                    membreDTO.adresse = dr.GetString(3);
                    membreDTO.email = dr.GetString(4);
                    membreDTO.nbLocation = dr.GetString(5);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            return membreDTO;
        }

        public void Update(MembreDTO membreDTO)
        {
            int n = 0;
            try
            {
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":nom", membreDTO.nom));
                command.Parameters.Add(new MySqlParameter(":telephone", membreDTO.nom));
                command.Parameters.Add(new MySqlParameter(":adresse", membreDTO.adresse));
                command.Parameters.Add(new MySqlParameter(":email", membreDTO.email));
                command.Parameters.Add(new MySqlParameter(":nbLocation", membreDTO.nbLocation));
                command.Parameters.Add(new MySqlParameter(":iDvoiture", membreDTO.idMembre));
                n = command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public void Delete(MembreDTO membreDTO)
        {
            try
            {
                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idMembre", membreDTO.idMembre));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
        }

        public List<MembreDTO> GetAll()
        {
            List<MembreDTO> membres = new List<MembreDTO>();

            MembreDTO membreDTO = new MembreDTO();
            try
            {
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    membreDTO.idMembre = dr.GetString(0);
                    membreDTO.nom = dr.GetString(1);
                    membreDTO.telephone = dr.GetString(2);
                    membreDTO.adresse = dr.GetString(3);
                    membreDTO.email = dr.GetString(4);
                    membreDTO.nbLocation = dr.GetString(5);
                    membres.Add(membreDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException);
            }
            return membres;
        }
    }
}
