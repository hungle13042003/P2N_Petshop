using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAProductService
    {
        Task<List<AProductListModel>> GetListProduct(AOSearchProduct aOSearchProduct);
        Task<PaginationModel> GetListProductPagination(AOSearchProduct aOSearchProduct);
        Task<AProductModel> GetProductDetail(ulong Id);
        Task<Product> CreateProduct(ForceInfo forceInfo, AProductCreateModel aProductCreateModel);
        Task<Product> UpdateProduct(ForceInfo forceInfo, AProductUpdateModel aProductUpdateModel);
        Task<Product> DeleteProduct(ForceInfo forceInfo, ulong Id);
    }
}
