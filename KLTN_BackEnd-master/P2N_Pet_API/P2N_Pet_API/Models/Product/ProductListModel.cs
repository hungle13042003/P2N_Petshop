using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Product
{
    public class ProductListModel
    {
        public ulong ProductDetailId { get; set; }
        public string ProductTitle { get; set; }
        public ulong ProductId { get; set; }
        public ulong BreedId { get; set; }
        public string BreedName { get; set; }
        public ulong BreedIdRoot { get; set; }
        public string BreedRootName { get; set; }
        public ulong SupplierId { get; set; }
        public string SupplierName { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double PriceDiscount { get; set; }
        public string ProductImage { get; set; }
        public int ProductQuantity { get; set; }
        public ulong CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TypeProductId { get; set; }
        public string TypeProductName { get; set; }


    }
}
