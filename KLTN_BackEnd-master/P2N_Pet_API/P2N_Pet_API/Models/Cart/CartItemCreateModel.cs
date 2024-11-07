using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Cart
{
    public class CartItemCreateModel
    {
        public ulong ProductDetailId { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; }
        public ulong  BrandId { get; set; }

        [JsonIgnore]
        public float PriceDiscount { get; set; }
    }
}
