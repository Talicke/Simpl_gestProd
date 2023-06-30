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
    public class AviRepo : IAviRepo
    {
        private readonly IGestProdDBContext _DbContext;

        public AviRepo(IGestProdDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Ajouter un avis
        /// </summary>
        /// <param name="AviToAdd"></param>
        /// <returns></returns>
        public async Task<Avi> CreateAviAsync(Avi AviToAdd)
        {
            var elementAdded = await _DbContext.Avis.AddAsync(AviToAdd).ConfigureAwait(false);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Supprimer un avis
        /// </summary>
        /// <param name="AviToDelete"></param>
        /// <returns></returns>
        public async Task<Avi> DeleteAviAsync(Avi AviToDelete)
        {
            var elementDeleted = _DbContext.Avis.Remove(AviToDelete);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Modifier un avis
        /// </summary>
        /// <param name="AviToUpdate"></param>
        /// <returns></returns>
        public async Task<Avi> UpdateAviAsync(Avi AviToUpdate)
        {
            var elementUpdated = _DbContext.Avis.Update(AviToUpdate);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Recupere la liste des Avis
        /// </summary>
        /// <returns></returns>
        public async Task<List<Avi>> GetAviAsync()
        {
            return await _DbContext.Avis
                .Include(x => x.IdCompteNavigation)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Recuperer un Avis par son ID
        /// </summary>
        /// <param name="aviId"></param>
        /// <returns></returns>
        public async Task<Avi> GetAviByIdAsync(int aviId)
        {
            return await _DbContext.Avis
                .Include(x => x.IdCompteNavigation)
                .FirstOrDefaultAsync(x => x.IdAvis == aviId)
                .ConfigureAwait(false);
        }
    }
}
