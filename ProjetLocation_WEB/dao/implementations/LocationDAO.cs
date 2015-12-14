using MySql.Data.MySqlClient;
using ProjetLocation.dao.interfaces;
using ProjetLocation.db;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetLocation.dao
{
    public class LocationDAO : ILocationDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }
        private static string ADD_REQUEST = @"INSERT into location (idMembre,idVoiture,dateLocation,dateRetour) " +
            "VALUES(@idMembre, @idVoiture, @dateLocation, @dateRetour)";

        private static string READ_REQUEST = @"SELECT * FROM location WHERE idLocation = @idLocation";

        private static string UPDATE_REQUEST = @"UPDATE location set idMembre = @idMembre, idVoiture = @idVoiture, dateLocation = @dateLocation, " +
            "dateRetour = @dateRetour WHERE idLocation = @idLocation";

        private static string DELETE_REQUEST = @"DELETE from location WHERE idLocation = @idLocation";

        private static string GET_ALL_REQUEST = @"SELECT idLocation,idMembre,idVoiture,dateLocation,dateRetour "
            + "FROM location";

        private static String FIND_BY_MEMBRE = @"SELECT idLocation,idMembre,idVoiture,dateLocation,dateRetour FROM location " +
            "WHERE idMembre = @idMembre";

        private static String FIND_BY_VOITURE = "SELECT idLocation, idMembre, idVoiture, dateLocation, dateRetour FROM location " +
            "WHERE idVoiture = @idVoiture";

        //private static String FIND_BY_DATE_LOCATION = "SELECT idLocation, idMembre, idVoiture, dateLocation, dateRetour FROM location " +
        //    "WHERE dateLocation = @dateLocation";

        //private static String FIND_BY_DATE_RETOUR = "SELECT idLocation, idMembre, idVoiture, dateLocation, dateRetour FROM location " +
        //    "WHERE dateRetour = @dateRetour";

        public LocationDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        /// <inheritdoc />
        public int Add(LocationDTO locationDTO)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idMembre", locationDTO.IdMembre));
                command.Parameters.Add(new MySqlParameter("@idVoiture", locationDTO.IdVoiture));
                command.Parameters.Add(new MySqlParameter("@dateLocation", Convert.ToDateTime(locationDTO.DateLocation)));
                command.Parameters.Add(new MySqlParameter("@dateRetour", Convert.ToDateTime(locationDTO.DateRetour)));

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
        public LocationDTO Read(int id)
        {
            LocationDTO locationDTO = new LocationDTO();
            try
            {
                connexion.Open();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idLocation", id));
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    locationDTO.IdLocation = dr.GetInt32(0);
                    locationDTO.IdMembre = dr.GetInt32(1);
                    locationDTO.IdVoiture = dr.GetInt32(2);
                    locationDTO.DateLocation = dr.GetDateTime(3).ToString();
                    locationDTO.DateRetour = dr.GetMySqlDateTime(4).ToString();
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
            return locationDTO;
        }

        /// <inheritdoc />
        public int Update(LocationDTO locationDTO, int id)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idMembre", locationDTO.IdMembre));
                command.Parameters.Add(new MySqlParameter("@idVoiture", locationDTO.IdVoiture));
                command.Parameters.Add(new MySqlParameter("@dateLocation", locationDTO.DateLocation));
                command.Parameters.Add(new MySqlParameter("@dateRetour", locationDTO.DateRetour));
                command.Parameters.Add(new MySqlParameter("@idLocation", id));
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

                command.Parameters.Add(new MySqlParameter("@idLocation", id));
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
        public List<LocationDTO> GetAll()
        {
            List<LocationDTO> locations = new List<LocationDTO>();

            LocationDTO locationDTO = new LocationDTO();
            try
            {
                connexion.Open();
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    locationDTO.IdLocation = dr.GetInt32(0);

                    MembreDTO membre = new MembreDTO();
                    locationDTO.IdMembre = dr.GetInt32(1);

                    VoitureDTO voiture = new VoitureDTO();
                    locationDTO.IdVoiture = dr.GetInt32(2);
                    locationDTO.DateLocation = dr.GetDateTime(3).ToString();
                    locationDTO.DateRetour = dr.GetDateTime(4).ToString();
                    locations.Add(locationDTO);
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
            return locations;
        }

        /// <inheritdoc />
        public List<LocationDTO> FindByMembre(int idMembre)
        {
            List<LocationDTO> locations = new List<LocationDTO>();

            LocationDTO locationDTO = new LocationDTO();
            try
            {
                connexion.Open();
                command.CommandText = FIND_BY_MEMBRE;
                command.Parameters.Add(new MySqlParameter("@idMembre", idMembre));

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    locationDTO.IdLocation = dr.GetInt32(0);
                    locationDTO.IdMembre = dr.GetInt32(1);
                    locationDTO.IdVoiture = dr.GetInt32(2);
                    locationDTO.DateLocation = dr.GetDateTime(3).ToString();
                    locationDTO.DateRetour = dr.GetDateTime(4).ToString();

                    locations.Add(locationDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                MessageBox.Show(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return locations;
        }

        /// <inheritdoc />
        public List<LocationDTO> FindByVoiture(int idVoiture)
        {
            List<LocationDTO> locations = new List<LocationDTO>();
            LocationDTO locationDTO = new LocationDTO();
            try
            {
                connexion.Open();
                command.CommandText = FIND_BY_VOITURE;
                command.Parameters.Add(new MySqlParameter("@idVoiture", idVoiture));

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    locationDTO.IdLocation = dr.GetInt32(0);
                    locationDTO.IdMembre = dr.GetInt32(1);
                    locationDTO.IdVoiture = dr.GetInt32(2);
                    locationDTO.DateLocation = dr.GetDateTime(3).ToString();
                    locationDTO.DateRetour = dr.GetDateTime(4).ToString();
                    locations.Add(locationDTO);
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
            return locations;
        }
        //public List<LocationDTO> FindByDateLocation(DateTime dateLocation)
        //{
        //    List<LocationDTO> locations = new List<LocationDTO>();
        //    LocationDTO locationDTO = new LocationDTO();
        //    try
        //    {
        //        connexion.Open();
        //        command.CommandText = FIND_BY_DATE_LOCATION;
        //        command.Parameters.Add(new MySqlParameter("@dateLocation", dateLocation));

        //        MySqlDataReader dr = command.ExecuteReader();

        //        while(dr.NextResult()){
        //            locationDTO.IdLocation = dr.GetInt32(0);

        //            //MembreDTO membre = new MembreDTO();
        //            locationDTO.IdMembre = dr.GetInt32(1);

        //            //VoitureDTO voiture = new VoitureDTO();
        //            locationDTO.IdVoiture = dr.GetInt32(2);

        //            //locationDTO. = membre;
        //            //locationDTO.VoitureDTO = voiture;
        //            locationDTO.DateLocation = dr.GetDateTime(3).ToString();
        //            locationDTO.DateRetour = dr.GetDateTime(4).ToString();
        //            locations.Add(locationDTO);
        //        }
        //    }
        //    catch (MySqlException mySqlException)
        //    {
        //        throw new DAOException(mySqlException);
        //    }
        //    finally
        //    {
        //        connexion.Close();
        //    }
        //    return locations;
        //}

        //public List<LocationDTO> FindByDateRetour(String dateRetour)
        //{
        //    List<LocationDTO> locations = new List<LocationDTO>();
        //    LocationDTO locationDTO = new LocationDTO();
        //    try
        //    {
        //        connexion.Open();
        //        command.CommandText = FIND_BY_DATE_RETOUR;
        //        command.Parameters.Add(new MySqlParameter("@dateRetour", dateRetour));

        //        MySqlDataReader dr = command.ExecuteReader();

        //        while (dr.NextResult())
        //        {
        //            locationDTO.IdLocation = dr.GetInt32(0);

        //            //MembreDTO membre = new MembreDTO();
        //            locationDTO.IdMembre = dr.GetInt32(1);

        //            //VoitureDTO voiture = new VoitureDTO();
        //            locationDTO.IdVoiture = dr.GetInt32(2);

        //            //locationDTO.MembreDTO = membre;
        //            //locationDTO.VoitureDTO = voiture;
        //            locationDTO.DateLocation = dr.GetDateTime(3).ToString();
        //            locationDTO.DateRetour = dr.GetDateTime(4).ToString();
        //            locations.Add(locationDTO);
        //        }
        //    }
        //    catch (MySqlException mySqlException)
        //    {
        //        throw new DAOException(mySqlException);
        //    }
        //    finally
        //    {
        //        connexion.Close();
        //    }
        //    return locations;
        //}
    }
}
