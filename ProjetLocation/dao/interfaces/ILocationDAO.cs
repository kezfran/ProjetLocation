using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;

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
        /// <param name="id">L'id de la location à lire</param>
        /// <returns name="locationDTO">Le DTO à retourner</returns>
        LocationDTO Read(int id);

        /// <summary>
        /// Met à jour une location dans la base de données.
        /// </summary>
        /// <param name="locationDTO">Le DTO à mettre à jour</param>
        /// <param name="id">L'id de la location à mette=re jour</param>
        int Update(LocationDTO locationDTO, int id);

        /// <summary>
        /// Supprimer une location dans la base de données.
        /// </summary>
        /// <param name="id">L'id de la location à supprimer</param>
        int Delete(int id);

        /// <summary>
        /// Lit toutes les locations de la base de données.
        /// </summary>
        /// <returns name="locations">La liste des locations à retourner</returns>
        List<LocationDTO> GetAll();

        /// <summary>
        /// Lit toutes les locations correspondant à un membre donné.
        /// </summary>
        /// <param name="id">L'id du membre à utiliser</param>
        /// <returns name="locations">La liste des locations à retourner</returns>
        List<LocationDTO> FindByMembre(int idMembre);

        /// <summary>
        /// Lit toutes les locations correspondant à une voiture donnée.
        /// </summary>
        /// <param name="id">L'id de la voiture à utiliser</param>
        /// <returns name="locations">La liste des locations à retourner</returns>
        List<LocationDTO> FindByVoiture(int idVoiture);

        //List<LocationDTO> FindByDateLocation(DateTime dateLocation);

        //List<LocationDTO> FindByDateRetour(String dateRetour);
    }
}
