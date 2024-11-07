using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Product
{
    public class ProductDetailConditionModel
    {
        public ulong ProductDetailId { get; set; }
        public ulong ProductId { get; set; }
        public ulong SizeId { get; set; }
        public ulong ColorId { get; set; }
        public ulong AgeId { get; set; }
        public ulong SexId { get; set; }
        public ulong BrandId { get; set; }
    }
}
