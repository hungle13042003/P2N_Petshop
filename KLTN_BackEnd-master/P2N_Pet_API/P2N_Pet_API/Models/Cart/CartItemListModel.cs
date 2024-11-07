using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Cart
{
    public class CartItemListModel
    {
        public ulong Id { get; set; }
        public ulong CartItemId { get; set; }
        public ulong CartId { get; set; }
        public ulong ProductDetailId { get; set; }
        public string ProductTitle { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double PriceDiscount { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }
        public float TotalPriceItem { get; set; }
        public int QuantityProduct { get; set; }        
        public ulong BrandId { get; set; }
        public string Address { get; set; }
        //public int QuantityBrand { get; set; }
        //public int NumBrand { get; set; }
    }
}
