using P2N_Pet_API.Models.Product;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface IProductService
    {
        Task<List<ProductListModel>> GetListProduct(OSearchProductModel oSearch);
        Task<ProductDetailModel> GetDetailProduct(ulong productDetailId, ulong brandId);
        Task<PaginationModel> GetListProductPagination(OSearchProductModel oSearch);

        Task<ProductDetailModel> GetMultiProductDetail(ProductDetailConditionModel productDetailCondition);
    }
}
