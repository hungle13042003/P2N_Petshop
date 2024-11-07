using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AColor;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AColorService : IAColorService
    {
        private readonly IAColorQuery _aColorQuery;
        private readonly IAColorAction _aColorAction;
        private readonly IPaginationService _paginationService;

        public AColorService(IAColorQuery aColorQuery,
            IAColorAction aColorAction,
            IPaginationService paginationService)
        {
            _aColorQuery = aColorQuery;
            _aColorAction = aColorAction;
            _paginationService = paginationService;
        }

        public async Task<List<AColorListModel>> GetListColor(AOSearchColor aOSearchColor)
        {
            return await _aColorQuery.QueryGetListColor(aOSearchColor);
        }

        public async Task<PaginationModel> GetListColorPagination(AOSearchColor aOSearchColor)
        {
            var count = await _aColorQuery.QueryCountListColor(aOSearchColor);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchColor.CurrentPage),
                aOSearchColor.CurrentDate, Convert.ToInt32(aOSearchColor.Limit));

            return pagination;
        }

        public async Task<AColorModel> GetColorDetail(ulong Id)
        {
            return await _aColorQuery.QueryGetColorDetail(Id);
        }

        public async Task<Color> CreateColor(ForceInfo forceInfo, AColorCreateModel aColorCreateModel)
        {
            return await _aColorAction.Create(forceInfo, aColorCreateModel);
        }

        public async Task<Color> UpdateColor(ForceInfo forceInfo, AColorUpdateModel aColorUpdateModel)
        {
            return await _aColorAction.Update(forceInfo, aColorUpdateModel);
        }

        public async Task<Color> DeleteColor(ForceInfo forceInfo, ulong Id)
        {
            return await _aColorAction.Delete(forceInfo, Id);
        }
    }
}
