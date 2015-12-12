using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.service.interfaces
{
    public interface IFactureService
    {
        /// <summary>
        /// Ajoute un DTO dans la base de données.
        /// </summary>
        /// <param name="factureDTO">Le DTO à ajouter</param>
        int AddFacture(FactureDTO factureDTO);

        /// <summary>
        /// Lit une facture à partir de la base de données
        /// </summary>
        /// <param name="id">L'id de la facture à lire</param>
        /// <returns name="factureDTO">Le DTO à retourner</returns>
        FactureDTO ReadFacture(int id);

        /// <summary>
        /// Met à jour une facture dans la base de données.
        /// </summary>
        /// <param name="factureDTO">Le DTO à mettre à jour</param>
        /// <param name="id">L'id de la facture à mettre à jour</param>
        int UpdateFacture(FactureDTO factureDTO, int id);

        /// <summary>
        /// Supprime une facture dans la base de données.
        /// </summary>
        /// <param name="id">L'id de la facture à supprimer</param>
        int DeleteFacture(int id);

        /// <summary>
        /// Trouve toutes les factures dans la base de données.
        /// </summary>
        /// <returns name="factures">La liste des factures à retourner</returns>
        List<FactureDTO> GetAllFactures();

        /// <summary>
        /// Lit toutes les factures correspondant à une location donnée.
        /// </summary>
        /// <param name="id">L'id de la facture à utiliser</param>
        /// <returns name="factures">La liste des factures à retourner</returns>
        List<FactureDTO> FindByLocation(int id);
        List<FactureDTO> FindByEmploye(int id);
    }
}
