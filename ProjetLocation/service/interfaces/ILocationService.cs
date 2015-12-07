using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.service.interfaces
{
    public interface ILocationService
    {
        int AddLocation(LocationDTO locationDTO);

        LocationDTO ReadLocation(int id);

        int UpdateLocation(LocationDTO locationDTO, int id);

        int DeleteLocation(int id);
        List<LocationDTO> GetAll();

        List<LocationDTO> FindByMembre(int idMembre);

        List<LocationDTO> FindByVoiture(int idVoiture);

        List<LocationDTO> FindByDateLocation(DateTime dateLocation);

        List<LocationDTO> FindByDateRetour(DateTime dateRetour);
    }
}
