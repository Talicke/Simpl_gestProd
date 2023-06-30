using Api.gestProd.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Repository.Contract
{
    public interface ICategoryRepo
    {

        /// <summary>
        /// Ajouter une Categorie
        /// </summary>
        /// <param name="CategoryToAdd"></param>
        /// <returns></returns>
        Task<Category> CreateCategoryAsync(Category CategoryToAdd);

        /// <summary>
        /// Supprimer une Cotegorie
        /// </summary>
        /// <param name="CategoryToDelete"></param>
        /// <returns></returns>
        Task<Category> DeleteCategoryAsync(Category CategoryToDelete);

        /// <summary>
        /// Modifier une Categorie
        /// </summary>
        /// <param name="CategoryToUpdate"></param>
        /// <returns></returns>
        Task<Category> UpdateCategoryAsync(Category CategoryToUpdate);

        /// <summary>
        /// Recupere la liste des Categorie
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GeCategoryAsync();

        /// <summary>
        /// Recuperer une Categorie par son ID
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        Task<Category> GetCategoryByIdAsync(int CategoryId);
       
    }
}
