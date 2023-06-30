using Api.gestProd.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Repository.Contract
{
    public interface ICategoriserRepo
    {
        /// <summary>
        /// Ajouter une AssocCatagoriser
        /// </summary>
        /// <param name="CategoriserToAdd"></param>
        /// <returns></returns>
        Task<Categoriser> CreateCategoriserAsync(Categoriser CategoriserToAdd);

        /// <summary>
        /// Supprimer une AssocCatagoriser
        /// </summary>
        /// <param name="CategoriserToDelete"></param>
        /// <returns></returns>
        Task<Categoriser> DeleteCaracteristiqueAsync(Categoriser CategoriserToDelete);

        /// <summary>
        /// Modifier une AssocCatagoriser
        /// </summary>
        /// <param name="CategoriserToUpdate"></param>
        /// <returns></returns>
        Task<Categoriser> UpdateCategoriserAsync(Categoriser CategoriserToUpdate);

        /// <summary>
        /// Recupere la liste des AssocCatagoriser
        /// </summary>
        /// <returns></returns>
        Task<List<Categoriser>> GetCategoriserAsync();

        /// <summary>
        /// Recuperer une AssocCatagoriser par son ID
        /// </summary>
        /// <param name="CategoriserId"></param>
        /// <returns></returns>
        Task<Categoriser> GetCategoriserByIdAsync(int CategoriserId);
    }
}
