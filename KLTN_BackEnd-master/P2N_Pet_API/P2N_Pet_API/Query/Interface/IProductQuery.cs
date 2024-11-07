using P2N_Pet_API.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface IProductQuery
    {
        Task<List<ProductListModel>> QueryListProduct(OSearchProductModel oSearch);
        Task<ProductDetailModel> QueryDetailProduct(ulong productDetailId, ulong brandid);
        Task<List<ProductColorModel>> QueryListColorOfProduct(ProductDetailConditionModel productDetailCondition);
        Task<List<ProductSizeModel>> QueryListSizeOfProduct(ProductDetailConditionModel productDetailCondition);
        Task<List<ProductAgeModel>> QueryListAgeOfProduct(ProductDetailConditionModel productDetailCondition);
        Task<List<ProductSexModel>> QueryListSexOfProduct(ProductDetailConditionModel productDetailCondition);
        Task<List<ProductBrandModel>> QueryListBrandOfProduct(ProductDetailConditionModel productDetailCondition);

        Task<int> QueryCountListProduct(OSearchProductModel oSearch);

        Task<ProductDetailModel> QueryMultiProductDetail(ProductDetailConditionModel productDetailCondition);
        Task<List<string>> QueryProductImages(ulong productDetailId);

    }
}
