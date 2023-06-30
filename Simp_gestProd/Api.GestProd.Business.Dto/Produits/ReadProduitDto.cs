using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GestProd.Business.Dto.Produits
{
    public class ReadProduitDto : CreateProduitDto
    {
        public int Id { get; set; }
    }
}
