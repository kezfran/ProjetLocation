﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLocation.dto;

namespace ProjetLocation.dao.interfaces
{
    public interface IMembreDAO
    {
        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données.
        /// </summary>
        /// <param name="membreDTO">Le membre à ajouter</param>
        void add(MembreDTO membreDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données.
        /// </summary>
        /// <param name="id">L'id du membre à lire</param>
        /// <returns name="membreDTO">Le membre à retourner</returns>
        MembreDTO read(int id);

        /// <summary>
        /// Met à jour un membre dans la base de données.
        /// </summary>
        /// <param name="membreDTO">Le membre à mettre à jour</param>
        void update(MembreDTO membreDTO);

        /// <summary>
        /// Efface un membre dans la base de données.
        /// </summary>
        /// <param name="id">L'id du membre à effacer</param>
        void delete(int id);

        /// <summary>
        /// Lit tous les membres de la base de données.
        /// </summary>
        /// <returns name="membres">La liste des membres à retourner</returns>
        List<MembreDTO> getAll();
    }
}
