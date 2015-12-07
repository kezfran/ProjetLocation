using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dao.interfaces
{
    public interface ILocationDAO
    {
        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données.
        /// </summary>
        /// <param name="locationDTO">Le DTO à ajouter</param>
        int Add(LocationDTO locationDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données.
        /// </summary>
        /// <param name="id">L'id de la facture à lire</param>
        /// <returns name="locationDTO">Le DTO à retourner</returns>
        LocationDTO Read(int id);

        /// <summary>
        /// Met à jour une facture dans la base de données.
        /// </summary>
        /// <param name="locationDTO">Le DTO à mettre à jour</param>
        int Update(LocationDTO locationDTO,int id);

        /// <summary>
        /// Efface un membre dans la base de données.
        /// </summary>
        /// <param name="id">L'id de la facture à effacer</param>
        int Delete(int id);

        /// <summary>
        /// Lit toutes les locations de la base de données.
        /// </summary>
        /// <returns name="locations">La liste des locations à retourner</returns>
        List<LocationDTO> GetAll();

        /// <summary>
        /// Lit toutes les locations correspondant à
        /// </summary>
        /// <returns></returns>
        List<LocationDTO> FindByMembre(int idMembre);

        List<LocationDTO> FindByVoiture(int idVoiture);

        List<LocationDTO> FindByDateLocation(DateTime dateLocation);

        List<LocationDTO> FindByDateRetour(DateTime dateRetour);
    }
}
