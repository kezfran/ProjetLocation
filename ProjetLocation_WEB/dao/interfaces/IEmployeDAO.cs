using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dao.interfaces
{
    public interface IEmployeDAO
    {
        int Add(EmployeDTO employeDTO);
        EmployeDTO Read(int id);
        int Update(EmployeDTO employeDTO, int id);
        int Delete(int id);
        List<EmployeDTO> GetAll();
    }
}
