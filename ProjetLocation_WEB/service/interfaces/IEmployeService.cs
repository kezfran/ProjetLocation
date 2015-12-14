using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.service.interfaces
{
    public interface IEmployeService
    {
        int AddEmploye(EmployeDTO employeDTO);
        EmployeDTO ReadEmploye(int id);
        int UpdateEmploye(EmployeDTO employeDTO, int id);
        int DeleteteEmploye(int id);
        List<EmployeDTO> GetAllEmployes();
    }
}
