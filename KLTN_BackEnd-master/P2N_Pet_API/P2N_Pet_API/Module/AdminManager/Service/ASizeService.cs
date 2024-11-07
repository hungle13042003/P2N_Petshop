using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ASize;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ASizeService : IASizeService
    {
        private readonly IASizeQuery _aSizeQuery;
        private readonly IASizeAction _aSizeAction;
        private readonly IPaginationService _paginationService;

        public ASizeService(IASizeQuery aSizeQuery,
            IASizeAction aSizeAction,
            IPaginationService paginationService)
        {
            _aSizeQuery = aSizeQuery;
            _aSizeAction = aSizeAction;
            _paginationService = paginationService;
        }

        public async Task<List<ASizeListModel>> GetListSize(AOSearchSize aOSearchSize)
        {
            return await _aSizeQuery.QueryGetListSize(aOSearchSize);
        }

        public async Task<PaginationModel> GetListSizePagination(AOSearchSize aOSearchSize)
        {
            var count = await _aSizeQuery.QueryCountListSize(aOSearchSize);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchSize.CurrentPage),
                aOSearchSize.CurrentDate, Convert.ToInt32(aOSearchSize.Limit));

            return pagination;
        }

        public async Task<ASizeModel> GetSizeDetail(ulong Id)
        {
            return await _aSizeQuery.QueryGetSizeDetail(Id);
        }

        public async Task<Size> CreateSize(ForceInfo forceInfo, ASizeCreateModel aSizeCreateModel)
        {
            return await _aSizeAction.Create(forceInfo, aSizeCreateModel);
        }

        public async Task<Size> UpdateSize(ForceInfo forceInfo, ASizeUpdateModel aSizeUpdateModel)
        {
            return await _aSizeAction.Update(forceInfo, aSizeUpdateModel);
        }

        public async Task<Size> DeleteSize(ForceInfo forceInfo, ulong Id)
        {
            return await _aSizeAction.Delete(forceInfo, Id);
        }
    }
}
