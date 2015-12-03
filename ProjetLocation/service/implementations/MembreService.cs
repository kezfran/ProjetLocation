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

        public MembreService()
        {
            
        }

        int IMembreService.addMembre(MembreDTO membreDTO)
        {
            try
            {
                return membreDAO.Add(membreDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        MembreDTO IMembreService.readMembre(int id)
        {
            try
            {
                return membreDAO.Read(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        int IMembreService.updateMembre(MembreDTO membreDTO)
        {
            try
            {
                return membreDAO.Update(membreDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        int IMembreService.deleteMembre(int id)
        {
            try
            {
                return membreDAO.Delete(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        List<MembreDTO> IMembreService.getAllMembre()
        {
            try
            {
                return membreDAO.GetAll();
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

     
    }
}
