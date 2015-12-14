using ProjetLocation.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.service.interfaces
{
    public interface IReservationService
    {
        /// <summary>
        /// Ajoute un nouveau DTO dans la base de données.
        /// </summary>
        /// <param name="reservationDTO">Le DTO à ajouter</param>
        int AddReservation(ReservationDTO reservationDTO);

        /// <summary>
        /// Lit un DTO à partir de la base de données.
        /// </summary>
        /// <param name="id">L'id de la resérvation à lire</param>
        /// <returns name="reservationDTO">Le DTO à retourner</returns>
        ReservationDTO ReadReservation(int id);

        /// <summary>
        /// Met à jour une resérvation dans la base de données.
        /// </summary>
        /// <param name="locationDTO">Le DTO à mettre à jour</param>
        /// <param name="id">L'id de la resérvation à mettre jour</param>
        int UpdateReservation(ReservationDTO reservationDTO, int id);

        /// <summary>
        /// Supprimer une resérvation dans la base de données.
        /// </summary>
        /// <returns name="reservations">La liste des resérvations à retourner</returns>
        int DeleteReservation(int id);


        List<ReservationDTO> GetAllReservations();

        /// <summary>
        /// Lit toutes les resérvations correspondants à un membre donné.
        /// </summary>
        /// <returns name="reservations">La liste des resérvations à retourner</returns>
        List<ReservationDTO> FindByMembre(int idMembre);

        /// <summary>
        /// Lit toutes les locations correspondant à un membre donné.
        /// </summary>
        /// <param name="id">L'id du membre à utiliser</param>
        /// <returns name="reservations">La liste des locations à retourner</returns>
        List<ReservationDTO> FindByVoiture(int idVoiture);

        List<ReservationDTO> FindByEmploye(int id);

    }
}
