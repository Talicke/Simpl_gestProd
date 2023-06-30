using Api.gestProd.Data.Context;
using Api.gestProd.Data.Entity.Model;
using Api.gestProd.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IGestProdDBContext _DbContext;

        public CategoryRepo(IGestProdDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Ajouter une Categorie
        /// </summary>
        /// <param name="CategoryToAdd"></param>
        /// <returns></returns>
        public async Task<Category> CreateCategoryAsync(Category CategoryToAdd)
        {
            var elementAdded = await _DbContext.Categories.AddAsync(CategoryToAdd).ConfigureAwait(false);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Supprimer une Cotegorie
        /// </summary>
        /// <param name="CategoryToDelete"></param>
        /// <returns></returns>
        public async Task<Category> DeleteCategoryAsync(Category CategoryToDelete)
        {
            var elementDeleted = _DbContext.Categories.Remove(CategoryToDelete);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Modifier une Categorie
        /// </summary>
        /// <param name="CategoryToUpdate"></param>
        /// <returns></returns>
        public async Task<Category> UpdateCategoryAsync(Category CategoryToUpdate)
        {
            var elementUpdated = _DbContext.Categories.Update(CategoryToUpdate);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Recupere la liste des Categorie
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GeCategoryAsync()
        {
            return await _DbContext.Categories.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Recuperer une Categorie par son ID
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryByIdAsync(int CategoryId)
        {
            return await _DbContext.Categories
                .FirstOrDefaultAsync(x => x.IdCategorie == CategoryId)
                .ConfigureAwait(false);
        }
    }

}
