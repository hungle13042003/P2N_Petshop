using P2N_Pet_API.Module.AdminManager.Models.AProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAProductDetailQuery
    {
        Task<List<AProductDetailListModel>> QueryGetListProductDetail(AOSearchProductDetail aOSearchProductDetail);
        Task<int> QueryCountListProductDetail(AOSearchProductDetail aOSearchProductDetail);
        Task<AProductDetailModel> QueryGetInProductDetail(ulong Id);
        Task<List<ulong>> QueryListImageOldCreate(AProductDetailUpdateModel aProductDetailUpdateModel);
        Task<List<ulong>> QueryListProductDetailDuplicateImage(ulong productId, ulong colorId, ulong ageId);
        Task<List<ulong>> QueryListProductImageForDuplicateImage(ulong productImageId);
        Task<ulong> GetProductId(ulong breedId, ulong supplierId);
        Task<List<ABrandProductDetailModel>> QueryListBrandProductDetail(ulong Id);
        Task<ulong> GetProductIdByCategory(ulong categoryid, ulong supplierId);
        Task<List<ulong>> QueryListProductDetailCategoryDuplicateImage(ulong productId);
        Task<List<ulong>> QueryListImageOldCategoryCreate(AProductDetailUpdateModel aProductDetailUpdateModel);
    }
}
