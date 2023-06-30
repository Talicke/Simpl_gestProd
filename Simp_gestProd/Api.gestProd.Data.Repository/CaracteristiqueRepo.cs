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
    public class CaracteristiqueRepo : ICaracteristiqueRepo
    {
        private readonly IGestProdDBContext _DbContext;

        public CaracteristiqueRepo(IGestProdDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Ajouter une caracteristique
        /// </summary>
        /// <param name="CaracToAdd"></param>
        /// <returns></returns>
        public async Task<Caracteristique> CreateCaracteristiqueAsync(Caracteristique CaracToAdd)
        {
            var elementAdded = await _DbContext.Caracteristiques.AddAsync(CaracToAdd).ConfigureAwait(false);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Supprimer une caracteristique
        /// </summary>
        /// <param name="CaracToDelete"></param>
        /// <returns></returns>
        public async Task<Caracteristique> DeleteCaracteristiqueAsync(Caracteristique CaracToDelete)
        {
            var elementDeleted = _DbContext.Caracteristiques.Remove(CaracToDelete);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Modifier une caracteristique
        /// </summary>
        /// <param name="CaracToUpdate"></param>
        /// <returns></returns>
        public async Task<Caracteristique> UpdateCaracteristiqueAsync(Caracteristique CaracToUpdate)
        {
            var elementUpdated = _DbContext.Caracteristiques.Update(CaracToUpdate);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Recupere la liste des caracteristiques
        /// </summary>
        /// <returns></returns>
        public async Task<List<Caracteristique>> GetCaracteristiqueAsync()
        {
            return await _DbContext.Caracteristiques.ToListAsync();
        }

        /// <summary>
        /// Recuperer une caracteristiques par son ID
        /// </summary>
        /// <param name="CarcacId"></param>
        /// <returns></returns>
        public async Task<Caracteristique> GetAviByIdAsync(int CarcacId)
        {
            return await _DbContext.Caracteristiques
                .FirstOrDefaultAsync(x => x.IdCarac == CarcacId)
                .ConfigureAwait(false);
        }
    }
}
