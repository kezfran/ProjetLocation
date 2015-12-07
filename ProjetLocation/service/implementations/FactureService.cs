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
    public class FactureService : IFactureService
    {
        FactureDAO factureDAO = new FactureDAO();

        public FactureService()
        {
        }

        /// <inheritdoc />
        public int AddFacture(FactureDTO factureDTO)
        {
            try
            {
                return factureDAO.Add(factureDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public FactureDTO ReadFacture(int id)
        {
            try
            {
                return factureDAO.Read(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int UpdateFacture(FactureDTO factureDTO, int id)
        {
            try
            {
                return factureDAO.Update(factureDTO,id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int DeleteFacture(int id)
        {
            try
            {
                return factureDAO.Delete(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<FactureDTO> GetAllFactures()
        {
            try
            {
                return factureDAO.GetAll();
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
