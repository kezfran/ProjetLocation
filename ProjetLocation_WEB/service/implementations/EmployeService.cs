using ProjetLocation.dao.implementations;
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
    public class EmployeService : IEmployeService
    {
        EmployeDAO employeDAO = new EmployeDAO();

        public EmployeService()
        {
        }

        /// <inheritdoc />
        public int AddEmploye(EmployeDTO employeDTO)
        {
            try
            {
                return employeDAO.Add(employeDTO);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        public EmployeDTO ReadEmploye(int id)
        {
            try
            {
                return employeDAO.Read(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        public int UpdateEmploye(EmployeDTO employeDTO,int id)
        {
            try
            {
                return employeDAO.Update(employeDTO,id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        public int DeleteteEmploye(int id)
        {
            try
            {
                return employeDAO.Delete(id);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        public List<EmployeDTO> GetAllEmployes()
        {
            try
            {
                return employeDAO.GetAll();
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
