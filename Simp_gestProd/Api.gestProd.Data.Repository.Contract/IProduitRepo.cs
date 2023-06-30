using Api.gestProd.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Repository.Contract
{
    public interface IProduitRepo
    {
        /// <summary>
        /// Ajouter un Produit
        /// </summary>
        /// <param name="ProduitToAdd"></param>
        /// <returns></returns>
        Task<Produit> CreateProduitAsync(Produit ProduitToAdd);

        /// <summary>
        /// Supprimer un produit
        /// </summary>
        /// <param name="ProduitToDelete"></param>
        /// <returns></returns>
        Task<Produit> DeleteProduitAsync(Produit ProduitToDelete);


        /// <summary>
        /// Modifier un produit
        /// </summary>
        /// <param name="ProduitToUpdate"></param>
        /// <returns></returns>
        Task<Produit> UpdateProduitAsync(Produit ProduitToUpdate);

        /// <summary>
        /// Recupere la liste de produits
        /// </summary>
        /// <returns></returns>
        Task<List<Produit>> GetProduitAsync();


        /// <summary>
        /// Recuperer un produit par son ID
        /// </summary>
        /// <param name="ProduitId"></param>
        /// <returns></returns>
        Task<Produit> GetProduitByIdAsync(int ProduitId);
        
    }
}
