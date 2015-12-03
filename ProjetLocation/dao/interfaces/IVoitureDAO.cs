using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.dto;

namespace ProjetLocation.dao.interfaces
{
    public interface IVoitureDAO
    {
        /// <summary>
        /// Ajoute une voiture dans la base de données.
        /// </summary>
        /// <param name="voitureDTO">Le DTO à ajouter</param>
        int Add(VoitureDTO voitureDTO);

        /// <summary>
        /// Lit une voiture à partir de la base de données.
        /// </summary>
        /// <param name="id">L'id de la voiture à lire</param>
        /// <returns name="voitureDTO">Le DTO à retourner</returns>
        VoitureDTO Read(int id);

        /// <summary>
        /// Met à jour une voiture dans la base de données.
        /// </summary>
        /// <param name="membreDTO">Le DTO à mettre à jour</param>
        int Update(VoitureDTO voitureDTO);

        /// <summary>
        /// Supprime une voiture dans la base de données.
        /// </summary>
        /// <param name="id">L'id de la voiture à supprimer</param>
        int Delete(int id);

        /// <summary>
        /// Lit tous les voitures à partir de la base de données.
        /// </summary>
        /// <returns name="voitures">La liste des voitures à retourner</returns>
        List<VoitureDTO> GetAll();
    }
}
