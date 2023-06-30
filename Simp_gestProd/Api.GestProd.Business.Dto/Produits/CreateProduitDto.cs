using Api.gestProd.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GestProd.Business.Dto.Produits
{
    public class CreateProduitDto
    {
        public string Nom { get; set; }
        public string Desc { get; set; }
        public bool estDisponible { get; set; }
    }
}
