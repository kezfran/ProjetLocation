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
using ProjetLocation.dao;

namespace ProjetLocation.service.implementations
{
    public class MembreService : IMembreService
    {
        MembreDAO membreDAO = new MembreDAO();

        public MembreService()
        {
        }

        public int AddMembre(MembreDTO membreDTO)
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

        public MembreDTO ReadMembre(int id)
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

        public int UpdateMembre(MembreDTO membreDTO)
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

        public int DeleteMembre(int id)
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

        public List<MembreDTO> GetAllMembres()
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
