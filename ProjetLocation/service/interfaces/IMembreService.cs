using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.dto;

namespace ProjetLocation.service.interfaces
{
    public interface IMembreService
    {
        /// <summary>
        /// Ajoute un DTO dans la base de données.
        /// </summary>
        /// <param name="membreDTO">Le membre à ajouter</param>
        int AddMembre(MembreDTO membreDTO);

        /// <summary>
        /// Lit un membre à partir de la base de données
        /// </summary>
        /// <param name="id">L'id du membre à lire</param>
        MembreDTO ReadMembre(int id);

        /// <summary>
        /// Met à jour un membre dans la base de données.
        /// </summary>
        /// <param name="membreDTO">Le membre à mettre à jour</param>
        int UpdateMembre(MembreDTO membreDTO,int id);

        /// <summary>
        /// Supprime un membre dans la base de données.
        /// </summary>
        /// <param name="id">L'id du membre à supprimer</param>
        int DeleteMembre(int id);

        /// <summary>
        /// Trouve tous les membres dans la base de données.
        /// </summary>
        List<MembreDTO> GetAllMembres();
    }
}
