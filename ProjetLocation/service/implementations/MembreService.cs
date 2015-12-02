using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.dao.interfaces;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.exception.service;
using ProjetLocation.service.interfaces;

namespace ProjetLocation.service.implementations
{
    public class MembreService : IMembreService
    {
        private IMembreDAO membreDAO;

        private IMembreDAO getMembreDAO()
        {
            return this.membreDAO;
        }
        private void setMembreDAO(IMembreDAO membreDAO)
        {
            this.membreDAO = membreDAO;
        }

        public MembreService(IMembreDAO membreDAO)
        {
            if (membreDAO == null)
            {
                throw new InvalidDAOException("Le DAO du membre ne peut être null");
            }
            setMembreDAO(membreDAO);
        }

        /// <inheritdoc />
        public void addMembre(MembreDTO membreDTO)
        {
            try
            {
                getMembreDAO().add(membreDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public MembreDTO readMembre(int id)
        {
            try
            {
                return getMembreDAO().read(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public void updateMembre(MembreDTO membreDTO)
        {
            try
            {
                getMembreDAO().update(membreDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public void deleteMembre(int id)
        {
            try
            {
                getMembreDAO().delete(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<MembreDTO> getAllMembres()
        {
            try
            {
                return getMembreDAO().getAll();
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
