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
    public class CodePostalRepo : ICodePostalRepo
    {
        private readonly IGestProdDBContext _DbContext;

        public CodePostalRepo(IGestProdDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Ajouter un Code postal
        /// </summary>
        /// <param name="CodePostalToAdd"></param>
        /// <returns></returns>
        public async Task<CodePostal> CreateCodePostalAsync(CodePostal CodePostalToAdd)
        {
            var elementAdded = await _DbContext.CodePostals.AddAsync(CodePostalToAdd).ConfigureAwait(false);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Supprimer un Code Postal
        /// </summary>
        /// <param name="CodePostalToDelete"></param>
        /// <returns></returns>
        public async Task<CodePostal> DeleteCodePostalAsync(CodePostal CodePostalToDelete)
        {
            var elementDeleted = _DbContext.CodePostals.Remove(CodePostalToDelete);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Modifier un Code postal
        /// </summary>
        /// <param name="CodePostalToUpdate"></param>
        /// <returns></returns>
        public async Task<CodePostal> UpdateCategoryAsync(CodePostal CodePostalToUpdate)
        {
            var elementUpdated = _DbContext.CodePostals.Update(CodePostalToUpdate);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Recupere la liste des Code postal
        /// </summary>
        /// <returns></returns>
        public async Task<List<CodePostal>> GetCodePostalAsync()
        {
            return await _DbContext.CodePostals
                .Include(x => x.IdVilleNavigation)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Recuperer un code postal par son ID
        /// </summary>
        /// <param name="CodePostalId"></param>
        /// <returns></returns>
        public async Task<CodePostal> GetCodePostalByIdAsync(int CodePostalId)
        {
            return await _DbContext.CodePostals
                .Include(x => x.IdVilleNavigation)
                .FirstOrDefaultAsync(x => x.IdCp == CodePostalId)
                .ConfigureAwait(false);
        }
    }
}