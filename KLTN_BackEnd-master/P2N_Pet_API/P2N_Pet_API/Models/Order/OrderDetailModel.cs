using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Order
{
    public class OrderDetailModel
    {
        public ulong Id { get; set; }
        public string ProductTitle { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double PriceDiscount { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }
        public float TotalPriceItem { get; set; }
    }
}
