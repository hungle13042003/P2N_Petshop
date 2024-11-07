using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ABrand;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ABrandService : IABrandService
    {
        private readonly IABrandAction _aBrandAction;
        private readonly IPaginationService _paginationService;
        private readonly IABrandQuery _aBrandQuery;

        public ABrandService(IABrandAction aBrandAction,
            IPaginationService paginationService,
            IABrandQuery aBrandQuery)
        {
            _aBrandAction = aBrandAction;
            _paginationService = paginationService;
            _aBrandQuery = aBrandQuery;
        }

        public async Task<Brand> CreateBrandPet(ABrandCreateModel aBrandCreate, ForceInfo forceInfo)
        {
            return await _aBrandAction.CreateBrandPet(aBrandCreate, forceInfo);
        }

        public async Task<Brand> DeleteBrandPet(ulong brandid, ForceInfo forceInfo)
        {
            return await _aBrandAction.DeleteBrandPet(brandid, forceInfo);
        }

        public async Task<ABrandModel> GetDetailBrand(ulong brandid)
        {
            return await _aBrandQuery.QueryGetDetail(brandid);
        }

        public async Task<List<ABrandListModel>> GetListBrand(AOSearchBrand aOSearchBrand)
        {
            return await _aBrandQuery.QueryGetListBrand(aOSearchBrand);
        }

        public async Task<PaginationModel> GetListBrandPagination(AOSearchBrand aOSearchBrand)
        {
            var count = await _aBrandQuery.QueryCountListBrand(aOSearchBrand);

            var pagination = await _paginationService.BuildPagination(count, aOSearchBrand.CurrentPage,
                aOSearchBrand.CurrentDate, aOSearchBrand.Limit);

            return pagination;
        }

        public async Task<Brand> UpdateBrandPet(ABrandUpdateModel aBrandUpdate, ForceInfo forceInfo)
        {
            return await _aBrandAction.UpdateBrandPet(aBrandUpdate, forceInfo);
        }


    }
}
