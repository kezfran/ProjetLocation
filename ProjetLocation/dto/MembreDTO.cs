using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    public class MembreDTO
    {
        public int idMembre { get; set; }
        public string nom { get; set; }
        public string telephone { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public int nbLocation { get; set; }
    }
}
