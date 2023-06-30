using Api.gestProd.Data.Entity.Model;
using Api.GestProd.Business.Dto.Produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GestProd.Business.Mapper.Produits
{
    public class ProduitMapper
    {
        /// <summary>
        /// Transforme le DTO createProduit en Entité produit
        /// </summary>
        /// <param name="createProduit"></param>
        /// <returns></returns>
        public static Produit TransformCreateProduitDtoToEntity(CreateProduitDto createProduit)
        {
            return new Produit()
            {
                NomProduit = createProduit.Nom,
                DescProduit = createProduit.Desc,
                EstDisponible = createProduit.estDisponible
            };
        }

        public static ReadProduitDto TransformCreateEntityToReadProduitDto(Produit Produit)
        {
            return new ReadProduitDto()
            {
                Id = Produit.IdProduit,
                Nom = Produit.NomProduit,
                Desc = Produit.DescProduit,
                estDisponible = Produit.EstDisponible
            };
        }
    }
}
