using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AOrder
{
    public class AOrderItemModel
    {
        public ulong Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ColorTitle { get; set; }
        public string SizeTitle { get; set; }
        public string AgeTitle { get; set; }
        public string SexTitle { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
        public int Quantity { get; set; }
    }
}
