using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    public class VoitureDTO
    {
        public int idVoiture { get; set; }
        public string marque { get; set; }
        public string modele { get; set; }
        public DateTime annee { get; set; }
    }
}
