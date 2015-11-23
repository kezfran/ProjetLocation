using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    class ReservationDTO
    {
        public string idReservation { get; set; }
        public string idMembre { get; set; }
        public string idVoiture { get; set; }
        public string dateLocation { get; set; }
    }
}
