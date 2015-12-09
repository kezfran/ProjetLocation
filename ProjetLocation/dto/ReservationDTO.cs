using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dto
{
    public class ReservationDTO
    {
        public int IdReservation { get; set; }
        public int IdMembre { get; set; }
        public int IdVoiture { get; set; }
        public string DateReservation { get; set; }
    }
}
