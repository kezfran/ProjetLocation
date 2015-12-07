using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    public class LocationDTO
    {
        public int IdLocation { get; set; }
        public MembreDTO MembreDTO { get; set; }
        public VoitureDTO VoitureDTO { get; set; }
        public DateTime DateLocation { get; set; }
        public DateTime DateRetour { get; set; }
    }
}
