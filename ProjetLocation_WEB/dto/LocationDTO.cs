using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;

namespace ProjetLocation.dto
{
    public class LocationDTO
    {
        public int IdLocation { get; set; }
        public int IdMembre { get; set; }
        public int IdVoiture { get; set; }
        public string DateLocation { get; set; }
        public string DateRetour { get; set; }
    }
}
