using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    public class EmployeDTO
    {
        public int IdEmploye { get; set; }
        public string Nom { get; set; }
        public string Poste { get; set; }
        public int Matricule { get; set; }
        public string MotPasse { get; set; }
    }
}
