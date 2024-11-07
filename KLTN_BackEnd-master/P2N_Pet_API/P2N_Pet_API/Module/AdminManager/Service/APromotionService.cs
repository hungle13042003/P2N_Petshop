using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.APromotion;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class APromotionService : IAPromotionService
    {
        private readonly PetShopContext _petShopContext;
        private readonly IAPromotionQuery _aPromotionQuery;
        private readonly IAPromotionAction _aPromotionAction;
        private readonly IPaginationService _paginationService;

        public APromotionService(PetShopContext petShopContext,
            IAPromotionQuery aPromotionQuery,
            IAPromotionAction aPromotionAction,
            IPaginationService paginationService)
        {
            _petShopContext = petShopContext;
            _aPromotionQuery = aPromotionQuery;
            _aPromotionAction = aPromotionAction;
            _paginationService = paginationService;
        }

        public async Task<List<APromotionListModel>> GetListPromotion(AOSearchPromotion aOSearchPromotion)
        {
            return await _aPromotionQuery.QueryGetListPromotion(aOSearchPromotion);
        }

        public async Task<PaginationModel> GetListPromotionPagination(AOSearchPromotion aOSearchPromotion)
        {
            var count = await _aPromotionQuery.QueryCountListPromotion(aOSearchPromotion);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchPromotion.CurrentPage),
                aOSearchPromotion.CurrentDate, Convert.ToInt32(aOSearchPromotion.Limit));

            return pagination;
        }

        public async Task<APromotionModel> GetPromotionDetail(ulong Id)
        {
            return await _aPromotionQuery.QueryGetPromotionDetail(Id);
        }

        public async Task<Promotion> CreatePromotion(ForceInfo forceInfo, APromotionCreateModel aPromotionCreateModel)
        {
            var tran = await _petShopContext.Database.BeginTransactionAsync();

            try
            {
                var promotionEntity = await _aPromotionAction.Create(forceInfo, aPromotionCreateModel);

                if (promotionEntity != null && aPromotionCreateModel.Image != null)
                {
                    aPromotionCreateModel.Id = promotionEntity.Id;
                    var cloudMedia = await _aPromotionAction.SaveOneMediaData(aPromotionCreateModel);
                    await _aPromotionAction.UpdatePromotionMedia(forceInfo, aPromotionCreateModel, cloudMedia);
                }

                await tran.CommitAsync();

                return promotionEntity;
            }
            catch (Exception)
            {
                await tran.RollbackAsync();
                return null;
            }
        }

        public async Task<Promotion> UpdatePromotion(ForceInfo forceInfo, APromotionUpdateModel aPromotionUpdateModel)
        {
            var tran = await _petShopContext.Database.BeginTransactionAsync();

            try
            {
                var promotionEntity = await _aPromotionAction.Update(forceInfo, aPromotionUpdateModel);

                if (promotionEntity != null && aPromotionUpdateModel.Image != null)
                {
                    var promotionUpdate = new APromotionCreateModel
                    {
                        Id = aPromotionUpdateModel.Id,
                        Image = aPromotionUpdateModel.Image
                    };
                    var cloudMedia = await _aPromotionAction.SaveOneMediaData(promotionUpdate);
                    await _aPromotionAction.UpdatePromotionMedia(forceInfo, promotionUpdate, cloudMedia);
                }

                await tran.CommitAsync();

                return promotionEntity;
            }
            catch (Exception)
            {
                await tran.RollbackAsync();
                return null;
            }
        }

        public async Task<Promotion> DeletePromotion(ForceInfo forceInfo, ulong Id)
        {
            return await _aPromotionAction.Delete(forceInfo, Id);
        }
    }
}
