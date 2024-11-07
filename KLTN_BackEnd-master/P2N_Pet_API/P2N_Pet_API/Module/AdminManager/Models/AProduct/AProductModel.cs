using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AProduct
{
    public class AProductModel
    {
        public ulong Id { get; set; }
        public ulong BreedId { get; set; }
        public ulong SupplierId { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public string ProductName { get; set; }
        public ulong CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
