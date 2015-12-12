using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    public class FactureDTO
    {
        public int IdFacture { get; set; }
        public int IdLocation { get; set; }
        public int IdEmploye { get; set; }
        public String DateFacture { get; set; }
    }
}
