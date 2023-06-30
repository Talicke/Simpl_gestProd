using Api.gestProd.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.gestProd.Data.Repository.Contract
{
    public interface IAdressRepo
    {
        /// <summary>
        /// Ajouter une adresse
        /// </summary>
        /// <param name="adressToAdd"></param>
        /// <returns></returns>
        Task<Adress> CreateAdressAsync(Adress adressToAdd);

        /// <summary>
        /// Supprimer une adresse
        /// </summary>
        /// <param name="adressToDelete"></param>
        /// <returns></returns>
        Task<Adress> DeleteAdressAsync(Adress adressToDelete);

        /// <summary>
        /// Modifier une adresse
        /// </summary>
        /// <param name="addressToUpdate"></param>
        /// <returns></returns>
        Task<Adress> UpdateAdressAsync(Adress addressToUpdate);

        /// <summary>
        /// Recupere la liste des adresse
        /// </summary>
        /// <returns></returns>
        Task<List<Adress>> GetAdressAsync();

        /// <summary>
        /// Recuperer une adresse par son ID
        /// </summary>
        /// <param name="adresseId"></param>
        /// <returns></returns>
        Task<Adress> GetAdressByIdAsync(int adresseId);
    }
}
