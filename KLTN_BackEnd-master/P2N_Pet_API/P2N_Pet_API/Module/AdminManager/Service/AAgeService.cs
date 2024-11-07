using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AAge;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AAgeService : IAAgeService
    {
        private readonly IAAgeQuery _aAgeQuery;
        private readonly IAAgeAction _aAgeAction;
        private readonly IPaginationService _paginationService;

        public AAgeService(IAAgeQuery aAgeQuery,
            IAAgeAction aAgeAction,
            IPaginationService paginationService)
        {
            _aAgeQuery = aAgeQuery;
            _aAgeAction = aAgeAction;
            _paginationService = paginationService;
        }

        public async Task<List<AAgeListModel>> GetListAge(AOSearchAge aOSearchAge)
        {
            return  await _aAgeQuery.QueryGetListAge(aOSearchAge);
        }

        public async Task<PaginationModel> GetListAgePagination(AOSearchAge aOSearchAge)
        {
            var count = await _aAgeQuery.QueryCountListAge(aOSearchAge);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchAge.CurrentPage),
                aOSearchAge.CurrentDate, Convert.ToInt32(aOSearchAge.Limit));

            return pagination;
        }

        public async Task<AAgeModel> GetAgeDetail(ulong Id)
        {
            return await _aAgeQuery.QueryGetAgeDetail(Id);
        }

        public async Task<Age> CreateAge(ForceInfo forceInfo, AAgeCreateModel aAgeCreateModel)
        {
            return await _aAgeAction.Create(forceInfo, aAgeCreateModel);
        }

        public async Task<Age> UpdateAge(ForceInfo forceInfo, AAgeUpdateModel aAgeUpdateModel)
        {
            return await _aAgeAction.Update(forceInfo, aAgeUpdateModel);
        }

        public async Task<Age> DeleteAge(ForceInfo forceInfo, ulong Id)
        {
            return await _aAgeAction.Delete(forceInfo, Id);
        }
    }
}
