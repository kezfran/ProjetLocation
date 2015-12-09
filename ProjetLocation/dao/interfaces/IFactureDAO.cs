using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.dao.interfaces
{
    public interface IFactureDAO
    {
        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données.
        /// </summary>
        /// <param name="factureDTO">Le DTO à ajouter</param>
        int Add(FactureDTO factureDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données.
        /// </summary>
        /// <param name="id">L'id de la facture à lire</param>
        /// <returns name="factureDTO">Le DTO à retourner</returns>
        FactureDTO Read(int id);

        /// <summary>
        /// Met à jour une facture dans la base de données.
        /// </summary>
        /// <param name="factureDTO">Le DTO à mettre à jour</param>
        /// <param name="id">L'id de la facture à mettre à jour</param>
        int Update(FactureDTO factureDTO,int id);

        /// <summary>
        /// Supprime une facture dans la base de données.
        /// </summary>
        /// <param name="id">L'id de la facture à effacer</param>
        int Delete(int id);

        /// <summary>
        /// Lit toutes les factures de la base de données.
        /// </summary>
        /// <returns name="factures">La liste des factures à retourner</returns>
        List<FactureDTO> GetAll();

        /// <summary>
        /// Lit toutes les factures correspondant à une location donnée.
        /// </summary>
        /// <param name="id">L'id de la facture à utiliser</param>
        /// <returns name="factures">La liste des factures à retourner</returns>
        List<FactureDTO> FindByLocation(int id);
    }
}
