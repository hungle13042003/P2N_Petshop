using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAProductDetailAction
    {
        Task<Productdetail> Create(ForceInfo forceInfo, AProductDetailCreateModel aProductDetailCreateModel);
        Task<Productdetail> Update(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel);
        Task<Productdetail> Delete(ForceInfo forceInfo, ulong Id);
        Task UpdateProductDetailImageOld(ForceInfo forceInfo, ulong productDetailId, List<ulong> imageOldIds);
        Task UpdateProductDetailImage(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel, List<CloudMediaModel> CloudMedias, List<ulong> idProductDetailDuplicates);
        Task DeleteProductDetailImage(ForceInfo forceInfo, ulong productImageId, List<ulong> idProductImageForDuplicates);
        Task<List<CloudMediaModel>> SaveMediaData(AProductDetailUpdateModel aProductDetailUpdateModel);
    }
}
