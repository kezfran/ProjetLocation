using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.db;
using ProjetLocation.dto;
using MySql.Data.MySqlClient;

namespace ProjetLocation.dao
{
    class ReservationDAO
    {
        private static string ADD_REQUEST = "INSERT into reservation (idReservation,idMembre,idVoiture,dateReservation) " +
            "VALUES(:idReservation, :idMembre, :idVoiture, :dateReservation)";

        private static string READ_REQUEST = "SELECT * FROM reservation WHERE idReservation = :idReservation";

        private static string UPDATE_REQUEST = "UPDATE reservation set idMembre = :idMembre, idVoiture = :idVoiture, dateLocation = :dateLocation WHERE idReservation = :idReservation";

        private static string DELETE_REQUEST = "DELETE from reservation WHERE idReservation = :idReservation";

            public ReservationDAO()
        {

        }

            public void Add(Connexion connexion, ReservationDTO reservationDTO)
        {
            if (connexion == null)
            {
                //À FAIRE
            }
            if (reservationDTO == null)
            {
                //À FAIRE
            }
            reservationDTO = new ReservationDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = ADD_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idReservation", reservationDTO.idReservation));
                command.Parameters.Add(new MySqlParameter(":idMembre", reservationDTO.idMembre));
                command.Parameters.Add(new MySqlParameter(":idVoiture", reservationDTO.idVoiture));
                command.Parameters.Add(new MySqlParameter(":dateLocation", reservationDTO.dateLocation));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new MySqlException();
            }
        }

            public void Read(Connexion connexion, ReservationDTO reservationDTO)
        {
            if (connexion == null)
            {
                //À FAIRE
            }
            if (reservationDTO == null)
            {
                //À FAIRE
            }
            reservationDTO = new ReservationDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = READ_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idReservation", reservationDTO.idReservation));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new MySqlException();
            }
        }

            public void Update(Connexion connexion, ReservationDTO reservationDTO)
        {
            if (connexion == null)
            {
                //À FAIRE
            }
            if (reservationDTO == null)
            {
                //À FAIRE
            }
            reservationDTO = new ReservationDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = UPDATE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idMembre", reservationDTO.idMembre));
                command.Parameters.Add(new MySqlParameter(":idVoiture", reservationDTO.idVoiture));
                command.Parameters.Add(new MySqlParameter(":dateLocation", reservationDTO.dateLocation));
                command.Parameters.Add(new MySqlParameter(":idReservation", reservationDTO.idReservation));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new MySqlException();
            }
        }

            public void Delete(Connexion connexion, ReservationDTO reservationDTO)
        {
            if (connexion == null)
            {
                //À FAIRE
            }
            if (reservationDTO == null)
            {
                //À FAIRE
            }
            reservationDTO = new ReservationDTO();
            try
            {
                MySqlCommand command = connexion.Connection.CreateCommand();

                command.CommandText = DELETE_REQUEST;

                command.Parameters.Add(new MySqlParameter(":idReservation", reservationDTO.idReservation));
                command.ExecuteNonQuery();
            }
            catch (MySqlException mySqlException)
            {
                throw new MySqlException();
            }
        }
    }
}
