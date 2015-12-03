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


namespace ProjetLocation.service.implementations
{
    public class VoitureService : IVoitureService
    {
        IVoitureDAO voitureDAO;

        private IVoitureDAO getVoitureDAO()
        {
            return this.voitureDAO;
        }

        private void setVoitureDAO(IVoitureDAO voitureDAO)
        {
            this.voitureDAO = voitureDAO;
        }

        public VoitureService()
        {
            
        }
        /// <inheritdoc />
        int IVoitureService.addVoiture(VoitureDTO voitureDTO)
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
        VoitureDTO IVoitureService.readVoiture(int id)
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
        int IVoitureService.updateVoiture(VoitureDTO voitureDTO)
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
        int IVoitureService.deleteVoiture(int id)
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
        List<VoitureDTO> IVoitureService.getAllVoitures()
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
