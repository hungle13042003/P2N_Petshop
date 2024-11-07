using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AProduct
{
    public class AOSearchProduct
    {
        public string Limit { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentPage { get; set; }
        public string BreedId { get; set; }
        public string SupplierId { get; set; }
        public string Status { get; set; }
        //public ulong BrandId { get; set; }
        public ulong CategoryId { get; set; }
        public int TypeProductId { get; set; }
    }
}
