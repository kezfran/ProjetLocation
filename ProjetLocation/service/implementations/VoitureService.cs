using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.dao.interfaces;
using ProjetLocation.service.interfaces;
using ProjetLocation.exception.service;
using ProjetLocation.dto;
using ProjetLocation.exception.dao;
using ProjetLocation.dao;


namespace ProjetLocation.service.implementations
{
    public class VoitureService : IVoitureService
    {
        VoitureDAO voitureDAO = new VoitureDAO();

        public VoitureService()
        {
            
        }
        /// <inheritdoc />
        public int AddVoiture(VoitureDTO voitureDTO)
        {
            try
            {
                return voitureDAO.Add(voitureDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public VoitureDTO ReadVoiture(int id)
        {
            try
            {
                return voitureDAO.Read(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int UpdateVoiture(VoitureDTO voitureDTO)
        {
            try
            {
                return voitureDAO.Update(voitureDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public int DeleteVoiture(int id)
        {
            try
            {
                return voitureDAO.Delete(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <inheritdoc />
        public List<VoitureDTO> GetAllVoitures()
        {
            try
            {
                return voitureDAO.GetAll();
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
