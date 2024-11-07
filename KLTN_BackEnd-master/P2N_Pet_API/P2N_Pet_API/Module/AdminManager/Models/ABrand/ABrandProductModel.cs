using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ABrand
{
    public class ABrandProductModel
    {
        public ulong BrandId { get; set; }
        public ulong ProductDetailId { get; set; }
        public string ProductName { get; set; }
        public int QuantityInBrand { get; set; }
    }
}
