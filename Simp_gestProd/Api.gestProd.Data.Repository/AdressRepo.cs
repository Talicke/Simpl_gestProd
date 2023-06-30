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
    public class AdressRepo : IAdressRepo 
    {
        private readonly IGestProdDBContext _DbContext;

        public AdressRepo(IGestProdDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Ajouter une adresse
        /// </summary>
        /// <param name="adressToAdd"></param>
        /// <returns></returns>
        public async Task<Adress> CreateAdressAsync(Adress adressToAdd)
        {
            var elementAdded = await _DbContext.Adresses.AddAsync(adressToAdd).ConfigureAwait(false);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Supprimer une adresse
        /// </summary>
        /// <param name="adressToDelete"></param>
        /// <returns></returns>
        public async Task<Adress> DeleteAdressAsync(Adress adressToDelete)
        {
            var elementDeleted = _DbContext.Adresses.Remove(adressToDelete);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Modifier une adresse
        /// </summary>
        /// <param name="addressToUpdate"></param>
        /// <returns></returns>
        public async Task<Adress> UpdateAdressAsync(Adress addressToUpdate)
        {
            var elementUpdated = _DbContext.Adresses.Update(addressToUpdate);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Recupere la liste des adresse
        /// </summary>
        /// <returns></returns>
        public async Task<List<Adress>> GetAdressAsync()
        {
            return await _DbContext.Adresses
                .Include(x => x.IdCompteNavigation)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Recuperer une adresse par son ID
        /// </summary>
        /// <param name="adresseId"></param>
        /// <returns></returns>
        public async Task<Adress> GetAdressByIdAsync(int adresseId)
        {
            return await _DbContext.Adresses
                .Include(x => x.IdCompteNavigation)
                .FirstOrDefaultAsync(x => x.IdAdresse == adresseId)
                .ConfigureAwait(false);
        }


    }
}
