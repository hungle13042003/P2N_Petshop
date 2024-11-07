using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.APromotion;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class APromotionAction : IAPromotionAction
    {
        private readonly PetShopContext _petShopContext;
        private readonly ICloudMediaService _cloudMediaService;

        public APromotionAction(PetShopContext petShopContext,
            ICloudMediaService cloudMediaService)
        {
            _petShopContext = petShopContext;
            _cloudMediaService = cloudMediaService;
        }

        public async Task<Promotion> Create(ForceInfo forceInfo, APromotionCreateModel aPromotionCreateModel)
        {
            var promotion = new Promotion
            {
                Title = aPromotionCreateModel.Title.Trim(),
                Fromdate = aPromotionCreateModel.FromDate,
                Todate = aPromotionCreateModel.ToDate,
                Status = aPromotionCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow,
            };

            _petShopContext.Promotions.Add(promotion);

            await _petShopContext.SaveChangesAsync();

            return promotion;
        }

        public async Task<Promotion> Update(ForceInfo forceInfo, APromotionUpdateModel aPromotionUpdateModel)
        {
            var promotion = _petShopContext.Promotions.Where(a => a.Id == aPromotionUpdateModel.Id).FirstOrDefault();

            promotion.Title = aPromotionUpdateModel.Title.Trim();
            promotion.Fromdate = aPromotionUpdateModel.FromDate;
            promotion.Todate = aPromotionUpdateModel.ToDate;
            promotion.Status = aPromotionUpdateModel.Status;
            promotion.Updateuser = forceInfo.UserId;
            promotion.Updatedate = forceInfo.DateNow;

            _petShopContext.Promotions.Update(promotion);
            await _petShopContext.SaveChangesAsync();

            return promotion;
        }

        public async Task<Promotion> Delete(ForceInfo forceInfo, ulong Id)
        {
            var promotion = _petShopContext.Promotions.Where(a => a.Id == Id).FirstOrDefault();

            promotion.Status = 190;
            promotion.Updateuser = forceInfo.UserId;
            promotion.Updatedate = forceInfo.DateNow;

            _petShopContext.Promotions.Update(promotion);
            await _petShopContext.SaveChangesAsync();

            return promotion;
        }

        public async Task UpdatePromotionMedia(ForceInfo forceInfo, APromotionCreateModel aPromotionCreateModel, CloudOneMediaModel CloudOneMedia)
        {
            var promotion = _petShopContext.Promotions.Where(a => a.Id == aPromotionCreateModel.Id).FirstOrDefault();

            promotion.Image = CloudOneMedia.FileName;
            promotion.Updateuser = forceInfo.UserId;
            promotion.Updatedate = forceInfo.DateNow;

            _petShopContext.Promotions.Update(promotion);
            await _petShopContext.SaveChangesAsync();
        }

        //public async Task<List<CloudMediaModel>> SaveMediaData(APromotionCreateModel aPromotionCreateModel)
        //{
        //    var cloudMediaConfig = new CloudMediaConfig
        //    {
        //        Folder = "Upload/Promotion/Promotion_" + aPromotionCreateModel.Id,
        //        FileName = "Image_Promotion",
        //        CloudFiles = aPromotionCreateModel.Image.Select((a, index) => new CloudFileConfig
        //        {
        //            Index = index,
        //            FormFile = a,
        //        }).ToList(),
        //    };

        //    return await _cloudMediaService.SaveFileData(cloudMediaConfig);
        //}

        public async Task<CloudOneMediaModel> SaveOneMediaData(APromotionCreateModel aPromotionCreateModel)
        {
            var cloudOneMediaConfig = new CloudOneMediaConfig
            {
                Folder = "Upload/Promotion/Promotion_" + aPromotionCreateModel.Id,
                FileName = "Image_Promotion",
                FormFile = aPromotionCreateModel.Image
            };

            return await _cloudMediaService.SaveOneFileData(cloudOneMediaConfig);
        }
    }
}
