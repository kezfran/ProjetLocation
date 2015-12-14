using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.db;
using ProjetLocation.dto;
using MySql.Data.MySqlClient;
using ProjetLocation.exception.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.dao.interfaces;

namespace ProjetLocation.dao
{
    public class ReservationDAO : IReservationDAO
    {
        public Connexion connexion { get; set; }
        public MySqlCommand command { get; set; }
        private static string ADD_REQUEST = @"INSERT into reservation (idMembre,idVoiture,idEmploye,dateReservation) " +
            "VALUES(@idMembre, @idVoiture, @idEmploye, @dateReservation)";

        private static string READ_REQUEST = @"SELECT * FROM reservation WHERE idReservation = @idReservation";

        private static string UPDATE_REQUEST = @"UPDATE reservation set idMembre = @idMembre, idVoiture = @idVoiture, idEmploye = @idEmploye, " + 
            "dateReservation = @dateReservation WHERE idReservation = @idReservation";

        private static string DELETE_REQUEST = @"DELETE from reservation WHERE idReservation = @idReservation";

        private static string GET_ALL_REQUEST = @"SELECT idReservation,idMembre,idVoiture,idEmploye,dateReservation "
            + "FROM reservation";

        private static String FIND_BY_MEMBRE = @"SELECT idReservation,idMembre,idVoiture,idEmploye,dateReservation FROM reservation " +
            "WHERE idMembre = @idMembre";

        private static String FIND_BY_VOITURE = @"SELECT idReservation,idMembre,idVoiture,idEmploye,dateReservation FROM reservation " +
            "WHERE idVoiture = @idVoiture";

        private static String FIND_BY_EMPLOYE = @"SELECT idReservation,idMembre,idVoiture,idEmploye,dateReservation FROM reservation " +
            "WHERE idEmploye = @idEmploye";

        public ReservationDAO()
        {
            connexion = new Connexion();
            command = connexion.Connection.CreateCommand();
        }

        public int Add(ReservationDTO reservationDTO)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idMembre", reservationDTO.IdMembre));
                command.Parameters.Add(new MySqlParameter("@idVoiture", reservationDTO.IdVoiture));
                command.Parameters.Add(new MySqlParameter("@idEmploye", reservationDTO.IdEmploye));
                command.Parameters.Add(new MySqlParameter("@dateReservation", reservationDTO.DateReservation));
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

        public ReservationDTO Read(int id)
        {
            ReservationDTO reservationDTO = new ReservationDTO();
            try
            {
                connexion.Open();
                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idReservation", id));
                MySqlDataReader dr = command.ExecuteReader();

                while(dr.Read()){
                    reservationDTO.IdReservation = dr.GetInt32(0);
                    reservationDTO.IdMembre = dr.GetInt32(1);
                    reservationDTO.IdVoiture = dr.GetInt32(2);
                    reservationDTO.IdEmploye = dr.GetInt32(3);
                    reservationDTO.DateReservation = dr.GetDateTime(4).ToString();
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return reservationDTO;
        }

        public int Update(ReservationDTO reservationDTO,int id)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idMembre", reservationDTO.IdMembre));
                command.Parameters.Add(new MySqlParameter("@idVoiture", reservationDTO.IdVoiture));
                command.Parameters.Add(new MySqlParameter("@idEmploye",reservationDTO.IdEmploye));
                command.Parameters.Add(new MySqlParameter("@dateReservation", reservationDTO.DateReservation));
                command.Parameters.Add(new MySqlParameter("@idReservation", id));
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

        public int Delete(int id)
        {
            int n = 0;
            try
            {
                connexion.Open();
                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter("@idReservation", id));
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

        public List<ReservationDTO> GetAll()
        {
            List<ReservationDTO> reservations = new List<ReservationDTO>();
            ReservationDTO reservationDTO = new ReservationDTO();
            try
            {
                connexion.Open();
                command.CommandText = GET_ALL_REQUEST;

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    reservationDTO.IdReservation = dr.GetInt32(0);
                    reservationDTO.IdMembre = dr.GetInt32(1);
                    reservationDTO.IdVoiture = dr.GetInt32(2);
                    reservationDTO.IdEmploye = dr.GetInt32(3);
                    reservationDTO.DateReservation = dr.GetDateTime(4).ToString();
                    reservations.Add(reservationDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return reservations;
        }

        public List<ReservationDTO> FindByMembre(int id)
        {
            List<ReservationDTO> reservations = new List<ReservationDTO>();
            ReservationDTO reservationDTO = new ReservationDTO();
            try
            {
                connexion.Open();
                command.CommandText = FIND_BY_MEMBRE;
                command.Parameters.Add(new MySqlParameter("@idMembre", id));

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    reservationDTO.IdReservation = dr.GetInt32(0);
                    reservationDTO.IdMembre = dr.GetInt32(1);
                    reservationDTO.IdVoiture = dr.GetInt32(2);
                    reservationDTO.IdEmploye = dr.GetInt32(3);
                    reservationDTO.DateReservation = dr.GetDateTime(4).ToString();
                    reservations.Add(reservationDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return reservations;
        }

        public List<ReservationDTO> FindByVoiture(int id)
        {
            List<ReservationDTO> reservations = new List<ReservationDTO>();
            ReservationDTO reservationDTO = new ReservationDTO();
            try
            {
                connexion.Open();
                command.CommandText = FIND_BY_VOITURE;
                command.Parameters.Add(new MySqlParameter("@idVoiture", id));

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    reservationDTO.IdReservation = dr.GetInt32(0);
                    reservationDTO.IdMembre = dr.GetInt32(1);
                    reservationDTO.IdVoiture = dr.GetInt32(2);
                    reservationDTO.IdEmploye = dr.GetInt32(3);
                    reservationDTO.DateReservation = dr.GetDateTime(4).ToString();
                    reservations.Add(reservationDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return reservations;
        }

        public List<ReservationDTO> FindByEmploye(int id)
        {
            List<ReservationDTO> reservations = new List<ReservationDTO>();
            ReservationDTO reservationDTO = new ReservationDTO();
            try
            {
                connexion.Open();
                command.CommandText = FIND_BY_EMPLOYE;
                command.Parameters.Add(new MySqlParameter("@idEmploye", id));

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    reservationDTO.IdReservation = dr.GetInt32(0);
                    reservationDTO.IdMembre = dr.GetInt32(1);
                    reservationDTO.IdVoiture = dr.GetInt32(2);
                    reservationDTO.IdEmploye = dr.GetInt32(3);
                    reservationDTO.DateReservation = dr.GetDateTime(4).ToString();
                    reservations.Add(reservationDTO);
                }
            }
            catch (MySqlException mySqlException)
            {
                throw new DAOException(mySqlException.Message);
            }
            finally
            {
                connexion.Close();
            }
            return reservations;
        }
    }
}
