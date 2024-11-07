using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.APromotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAPromotionService
    {
        Task<List<APromotionListModel>> GetListPromotion(AOSearchPromotion aOSearchPromotion);
        Task<PaginationModel> GetListPromotionPagination(AOSearchPromotion aOSearchPromotion);
        Task<APromotionModel> GetPromotionDetail(ulong Id);
        Task<Promotion> CreatePromotion(ForceInfo forceInfo, APromotionCreateModel aPromotionCreateModel);
        Task<Promotion> UpdatePromotion(ForceInfo forceInfo, APromotionUpdateModel aPromotionUpdateModel);
        Task<Promotion> DeletePromotion(ForceInfo forceInfo, ulong Id);
    }
}
