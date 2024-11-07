using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Product
{
    public class ProductDetailModel
    {
        public ulong ProductDetailId { get; set; }
        public string ProductTitle { get; set; }
        public ulong ProductId { get; set; }
        public string Content { get; set; }
        public ulong BreedId { get; set; }
        public string BreedName { get; set; }
        public ulong SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double PriceDiscount { get; set; }
        public List<string> productImages { get; set; }
        public ulong SizeId { get; set; }
        public string SizeTitle { get; set; }
        public List<ProductSizeModel> productSizes { get; set; }
        public ulong AgeId { get; set; }
        public string AgeTitle { get; set; }
        public List<ProductAgeModel> productAges { get; set; }
        public ulong ColorId { get; set; }
        public string ColorName { get; set; }
        public List<ProductColorModel> productColors { get; set; }
        public int SexId { get; set; }
        public string SexTitle { get; set; }
        public List<ProductSexModel> productSexes { get; set; }
        public List<ProductBrandModel> productBrands { get; set; }
        public ulong CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TypeProductId { get; set; }
        public string TypeProductName { get; set; }
        public ulong BrandId { get; set; }
        public string Address { get; set; }
        public int QuantityBrand { get; set; }
        public int NumBrand { get; set; }

    }
}
