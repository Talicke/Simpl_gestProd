using Api.gestProd.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Repository.Contract
{
    public interface IAviRepo
    {
        /// <summary>
        /// Ajouter un avi
        /// </summary>
        /// <param name="AviToAdd"></param>
        /// <returns></returns>
        Task<Avi> CreateAviAsync(Avi AviToAdd);


        /// <summary>
        /// Supprimer un avis
        /// </summary>
        /// <param name="AviToDelete"></param>
        /// <returns></returns>
        Task<Avi> DeleteAviAsync(Avi AviToDelete);

        /// <summary>
        /// Modifier un avis
        /// </summary>
        /// <param name="AviToUpdate"></param>
        /// <returns></returns>
        Task<Avi> UpdateAviAsync(Avi AviToUpdate);


        /// <summary>
        /// Recupere la liste des Avis
        /// </summary>
        /// <returns></returns>
        Task<List<Avi>> GetAviAsync();


        /// <summary>
        /// Recuperer un Avis par son ID
        /// </summary>
        /// <param name="aviId"></param>
        /// <returns></returns>
        Task<Avi> GetAviByIdAsync(int aviId);
        
    }
}
