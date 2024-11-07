using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.APromotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAPromotionAction
    {
        Task<Promotion> Create(ForceInfo forceInfo, APromotionCreateModel aPromotionCreateModel);
        Task<Promotion> Update(ForceInfo forceInfo, APromotionUpdateModel aPromotionUpdateModel);
        Task<Promotion> Delete(ForceInfo forceInfo, ulong Id);
        //  Task UpdatePromotionMedia(ForceInfo forceInfo, APromotionCreateModel aPromotionCreateModel, List<CloudMediaModel> CloudMedias);
        //  Task<List<CloudMediaModel>> SaveMediaData(APromotionCreateModel aPromotionCreateModel);
        Task UpdatePromotionMedia(ForceInfo forceInfo, APromotionCreateModel aPromotionCreateModel, CloudOneMediaModel CloudOneMedia);
        Task<CloudOneMediaModel> SaveOneMediaData(APromotionCreateModel aPromotionCreateModel);
    }
}
