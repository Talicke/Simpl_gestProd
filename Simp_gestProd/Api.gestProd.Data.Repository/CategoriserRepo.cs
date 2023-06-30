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
    public class CategoriserRepo : ICategoriserRepo
    {
        private readonly IGestProdDBContext _DbContext;

        public CategoriserRepo(IGestProdDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Ajouter une AssocCatagoriser
        /// </summary>
        /// <param name="CategoriserToAdd"></param>
        /// <returns></returns>
        public async Task<Categoriser> CreateCategoriserAsync(Categoriser CategoriserToAdd)
        {
            var elementAdded = await _DbContext.Categorisers.AddAsync(CategoriserToAdd).ConfigureAwait(false);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Supprimer une AssocCatagoriser
        /// </summary>
        /// <param name="CategoriserToDelete"></param>
        /// <returns></returns>
        public async Task<Categoriser> DeleteCaracteristiqueAsync(Categoriser CategoriserToDelete)
        {
            var elementDeleted = _DbContext.Categorisers.Remove(CategoriserToDelete);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Modifier une AssocCatagoriser
        /// </summary>
        /// <param name="CategoriserToUpdate"></param>
        /// <returns></returns>
        public async Task<Categoriser> UpdateCategoriserAsync(Categoriser CategoriserToUpdate)
        {
            var elementUpdated = _DbContext.Categorisers.Update(CategoriserToUpdate);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Recupere la liste des AssocCatagoriser
        /// </summary>
        /// <returns></returns>
        public async Task<List<Categoriser>> GetCategoriserAsync()
        {
            return await _DbContext.Categorisers.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Recuperer une AssocCatagoriser par son ID
        /// </summary>
        /// <param name="CategoriserId"></param>
        /// <returns></returns>
        public async Task<Categoriser> GetCategoriserByIdAsync(int CategoriserId)
        {
            return await _DbContext.Categorisers
                .FirstOrDefaultAsync(x => x.IdCategorie == CategoriserId)
                .ConfigureAwait(false);
        }
    }
}
