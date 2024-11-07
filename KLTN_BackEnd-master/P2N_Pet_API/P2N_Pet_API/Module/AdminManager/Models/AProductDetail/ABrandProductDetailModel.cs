using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AProductDetail
{
    public class ABrandProductDetailModel
    {
        public ulong BrandId { get; set; }
        public string Address { get; set; }
        public int QuantityInBrand { get; set; }
    }
}
