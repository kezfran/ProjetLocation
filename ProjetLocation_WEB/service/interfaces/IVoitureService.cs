using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.dto;

namespace ProjetLocation.service.interfaces
{
    public interface IVoitureService
    {
        /// <summary>
        /// Ajoute un DTO à la base de données.
        /// </summary>
        /// <param name="voitureDTO">Le DTO à ajouter</param>
        /// <returns name="n">Le résultat de l'exécution en entier</returns>
        int AddVoiture(VoitureDTO voitureDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données.
        /// </summary>
        /// <param name="id">L'id de la voiture à ajouter</param>
        /// <returns name="voitureDTO">Le DTO à retourner</returns>
        VoitureDTO ReadVoiture(int id);

        /// <summary>
        /// Met à jour un DTO dans la base de données.
        /// </summary>
        /// <param name="voitureDTO">Le DTO à mettre à jour</param>
        /// <returns name="n">Le résultat de l'exécution en entier</returns>
        int UpdateVoiture(VoitureDTO voitureDTO,int id);

        /// <summary>
        /// Supprime une voiture dans la base de données.
        /// </summary>
        /// <param name="id">L'id de la voiture à supprimer</param>
        /// <returns name="n">Le résultat de l'exécution en entier</returns>
        int DeleteVoiture(int id);

        /// <summary>
        /// Lit tous les voitures de la base de données.
        /// </summary>
        /// <returns name="membres">La liste des membres à retourner</returns>
        List<VoitureDTO> GetAllVoitures();
    }
}
