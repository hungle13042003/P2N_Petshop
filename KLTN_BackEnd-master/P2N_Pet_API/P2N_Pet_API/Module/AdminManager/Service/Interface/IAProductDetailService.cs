using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAProductDetailService
    {
        Task<List<AProductDetailListModel>> GetListProductDetail(AOSearchProductDetail aOSearchProductDetail);
        Task<PaginationModel> GetListProductDetailPagination(AOSearchProductDetail aOSearchProductDetail);
        Task<AProductDetailModel> GetInProductDetail(ulong Id);
        Task<Productdetail> CreateProductDetail(ForceInfo forceInfo, AProductDetailCreateModel aProductDetailCreateModel);
        Task<Productdetail> UpdateProductDetail(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel);
        Task<Productdetail> DeleteProductDetail(ForceInfo forceInfo, ulong Id);
        Task UpdateProductDetailImage(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel);
        Task DeleteProductDetailImage(ForceInfo forceInfo, ulong productImageId);
    }
}
