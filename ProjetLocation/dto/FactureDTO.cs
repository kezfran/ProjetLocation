using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    public class FactureDTO
    {
        //LocationDTO locationDTO = new LocationDTO();

        public int IdFacture { get; set; }
        public LocationDTO LocationDTO { get; set; }
        public DateTime DateFacture { get; set; }
    }
}
