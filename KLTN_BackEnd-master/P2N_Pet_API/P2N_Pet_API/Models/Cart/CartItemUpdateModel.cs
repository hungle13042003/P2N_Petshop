using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Cart
{
    public class CartItemUpdateModel
    {
        public ulong CartItemId { get; set; }
        public ulong ProductDetailId { get; set; }
        public ulong BrandId { get; set; }
        public int Quantity { get; set; }
    }
}
