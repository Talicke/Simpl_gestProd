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
    public class ProduitRepo : IProduitRepo
    {
        private readonly IGestProdDBContext _DbContext;

        public ProduitRepo(IGestProdDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Ajouter un Produit
        /// </summary>
        /// <param name="ProduitToAdd"></param>
        /// <returns></returns>
        public async Task<Produit> CreateProduitAsync(Produit ProduitToAdd)
        {
            var elementAdded = await _DbContext.Produits.AddAsync(ProduitToAdd).ConfigureAwait(false);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        /// <summary>
        /// Supprimer un produit
        /// </summary>
        /// <param name="ProduitToDelete"></param>
        /// <returns></returns>
        public async Task<Produit> DeleteProduitAsync(Produit ProduitToDelete)
        {
            var elementDeleted = _DbContext.Produits.Remove(ProduitToDelete);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }

        /// <summary>
        /// Modifier un produit
        /// </summary>
        /// <param name="ProduitToUpdate"></param>
        /// <returns></returns>
        public async Task<Produit> UpdateProduitAsync(Produit ProduitToUpdate)
        {
            var elementUpdated = _DbContext.Produits.Update(ProduitToUpdate);
            await _DbContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        /// <summary>
        /// Recupere la liste de produits
        /// </summary>
        /// <returns></returns>
        public async Task<List<Produit>> GetProduitAsync()
        {
            return await _DbContext.Produits.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Recuperer un produit par son ID
        /// </summary>
        /// <param name="ProduitId"></param>
        /// <returns></returns>
        public async Task<Produit> GetProduitByIdAsync(int ProduitId)
        {
            return await _DbContext.Produits
                .FirstOrDefaultAsync(x => x.IdProduit == ProduitId)
                .ConfigureAwait(false);
        }
    }
}
