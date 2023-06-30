using Api.gestProd.Data.Repository.Contract;
using Api.GestProd.Business.Dto.Produits;
using Api.GestProd.Business.Mapper.Produits;
using Api.GestProd.Business.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GestProd.Business.Services
{
    public class ProduitService : IProduitService
    {

        private readonly IProduitRepo _produitRepo;

        public ProduitService (IProduitRepo produitRepo)
        {
            _produitRepo = produitRepo;
        }

        public async Task<List<ReadProduitDto>> GetProduitAsync()
        {
            var produits = await _produitRepo.GetProduitAsync().ConfigureAwait(false);
            List<ReadProduitDto> readProduitDtos = new List<ReadProduitDto>();

            foreach (var produit in produits)
            {
                readProduitDtos.Add(ProduitMapper.TransformCreateEntityToReadProduitDto(produit));
            }

            return readProduitDtos;
        }
    }
}
