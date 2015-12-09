using MySql.Data.Types;
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
    public class LocationService : ILocationService
    {
        LocationDAO locationDAO = new LocationDAO();

        public LocationService()
        {
        }

        /// <inheritdoc />
        public int AddLocation(LocationDTO locationDTO)
        {
            try
            {
                return locationDAO.Add(locationDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public LocationDTO ReadLocation(int id)
        {
            try
            {
                return locationDAO.Read(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int UpdateLocation(LocationDTO locationDTO, int id)
        {
            try
            {
                return locationDAO.Update(locationDTO, id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int DeleteLocation(int id)
        {
            try
            {
                return locationDAO.Delete(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<LocationDTO> GetAllLocations()
        {
            try
            {
                return locationDAO.GetAll();
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<LocationDTO> FindByMembre(int id)
        {
            try
            {
                return locationDAO.FindByMembre(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<LocationDTO> FindByVoiture(int id)
        {
            try
            {
                return locationDAO.FindByVoiture(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        //public List<LocationDTO> FindByDateLocation(DateTime dateLocation)
        //{
        //    try
        //    {
        //        return locationDAO.FindByDateLocation(dateLocation);
        //    }
        //    catch (DAOException daoException)
        //    {
        //        throw new ServiceException(daoException.Message);
        //    }
        //}

        //public List<LocationDTO> FindByDateRetour(String dateRetour)
        //{
        //    try
        //    {
        //        return locationDAO.FindByDateRetour(dateRetour);
        //    }
        //    catch (DAOException daoException)
        //    {
        //        throw new ServiceException(daoException.Message);
        //    }
        //}
    }
}
