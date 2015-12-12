using ProjetLocation.dao;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.service.implementations
{
    public class ReservationService : IReservationService
    {
        ReservationDAO reservationDAO = new ReservationDAO();

        public ReservationService()
        {
        }

        /// <inheritdoc />
        public int AddReservation(ReservationDTO reservationDTO)
        {
            try
            {
                return reservationDAO.Add(reservationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public ReservationDTO ReadReservation(int id)
        {
            try
            {
                return reservationDAO.Read(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int UpdateReservation(ReservationDTO reservationDTO, int id)
        {
            try
            {
                return reservationDAO.Update(reservationDTO, id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int DeleteReservation(int id)
        {
            try
            {
                return reservationDAO.Delete(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<ReservationDTO> GetAllReservations()
        {
            try
            {
                return reservationDAO.GetAll();
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<ReservationDTO> FindByMembre(int id)
        {
            try
            {
                return reservationDAO.FindByMembre(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<ReservationDTO> FindByVoiture(int id)
        {
            try
            {
                return reservationDAO.FindByVoiture(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        public List<ReservationDTO> FindByEmploye(int id)
        {
            try
            {
                return reservationDAO.FindByEmploye(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
