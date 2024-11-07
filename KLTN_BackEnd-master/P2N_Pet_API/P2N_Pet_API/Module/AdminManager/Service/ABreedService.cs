using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ABreed;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ABreedService : IABreedService
    {
        private readonly IABreedQuery _aBreedQuery;
        private readonly IABreedAction _aBreedAction;
        private readonly IPaginationService _paginationService;

        public ABreedService(IABreedQuery aBreedQuery,
            IABreedAction aBreedAction,
            IPaginationService paginationService)
        {
            _aBreedQuery = aBreedQuery;
            _aBreedAction = aBreedAction;
            _paginationService = paginationService;
        }

        public async Task<List<ABreedListModel>> GetListBreed(AOSearchBreed aOSearchBreed)
        {
            return await _aBreedQuery.QueryGetListBreed(aOSearchBreed);
        }

        public async Task<PaginationModel> GetListBreedPagination(AOSearchBreed aOSearchBreed)
        {
            var count = await _aBreedQuery.QueryCountListBreed(aOSearchBreed);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchBreed.CurrentPage),
                aOSearchBreed.CurrentDate, Convert.ToInt32(aOSearchBreed.Limit));

            return pagination;
        }

        public async Task<ABreedModel> GetBreedDetail(ulong Id)
        {
            return await _aBreedQuery.QueryGetBreedDetail(Id);
        }

        public async Task<Breed> CreateBreed(ForceInfo forceInfo, ABreedCreateModel aBreedCreateModel)
        {
            return await _aBreedAction.Create(forceInfo, aBreedCreateModel);
        }

        public async Task<Breed> UpdateBreed(ForceInfo forceInfo, ABreedUpdateModel aBreedUpdateModel)
        {
            return await _aBreedAction.Update(forceInfo, aBreedUpdateModel);
        }

        public async Task<Breed> DeleteBreed(ForceInfo forceInfo, ulong Id)
        {
            return await _aBreedAction.Delete(forceInfo, Id);
        }
    }
}
