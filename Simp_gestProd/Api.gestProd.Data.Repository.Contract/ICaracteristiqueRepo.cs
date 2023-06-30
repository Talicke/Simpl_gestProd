using Api.gestProd.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Repository.Contract
{
    public interface ICaracteristiqueRepo
    {

        /// <summary>
        /// Ajouter une caracteristique
        /// </summary>
        /// <param name="CaracToAdd"></param>
        /// <returns></returns>
        Task<Caracteristique> CreateCaracteristiqueAsync(Caracteristique CaracToAdd);


        /// <summary>
        /// Supprimer une caracteristique
        /// </summary>
        /// <param name="CaracToDelete"></param>
        /// <returns></returns>
        Task<Caracteristique> DeleteCaracteristiqueAsync(Caracteristique CaracToDelete);


        /// <summary>
        /// Modifier une caracteristique
        /// </summary>
        /// <param name="CaracToUpdate"></param>
        /// <returns></returns>
        Task<Caracteristique> UpdateCaracteristiqueAsync(Caracteristique CaracToUpdate);


        /// <summary>
        /// Recupere la liste des caracteristiques
        /// </summary>
        /// <returns></returns>
        Task<List<Caracteristique>> GetCaracteristiqueAsync();


        /// <summary>
        /// Recuperer une caracteristiques par son ID
        /// </summary>
        /// <param name="CarcacId"></param>
        /// <returns></returns>
        Task<Caracteristique> GetAviByIdAsync(int CarcacId);
        
    }
}
