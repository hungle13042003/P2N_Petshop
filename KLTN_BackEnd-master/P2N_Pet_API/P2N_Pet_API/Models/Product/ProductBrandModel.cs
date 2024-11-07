using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Product
{
    public class ProductBrandModel
    {
        public ulong BrandId { get; set; }
        public ulong ProductDetailId { get; set; }
        public string Address { get; set; }
        public int QuantityInBrand { get; set; }
    }
}
