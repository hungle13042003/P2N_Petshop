using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ACategory;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ACategoryService : IACategoryService
    {
        private readonly IACategoryAction _aCategoryAction;
        private readonly IACategoryQuery _aCategoryQuery;
        private readonly IPaginationService _paginationService;

        public ACategoryService(IACategoryAction aCategoryAction,
            IACategoryQuery aCategoryQuery,
            IPaginationService paginationService)
        {
            _aCategoryAction = aCategoryAction;
            _aCategoryQuery = aCategoryQuery;
            _paginationService = paginationService;
        }

        public async Task<Category> CreateCategory(ACategoryCreateModel aCategoryCreate, ForceInfo forceInfo)
        {
            return await _aCategoryAction.CreateCategory(aCategoryCreate, forceInfo);
        }

        public async Task<Category> DeleteCategory(int categoryid, ForceInfo forceInfo)
        {
            return await _aCategoryAction.DeleteCategory(categoryid, forceInfo);
        }

        public async Task<ACategoryModel> GetDetailCategory(ulong Id)
        {
            return await _aCategoryQuery.QueryDetailCategory(Id);
        }

        public async Task<List<ACategoryListModel>> GetListCategory(AOSearchCategory aOSearchCategory)
        {
            return await _aCategoryQuery.QueryGetListCategory(aOSearchCategory);
        }

        public async Task<PaginationModel> GetListCategoryPagination(AOSearchCategory aOSearchCategory)
        {
            var count = await _aCategoryQuery.QueryCountListCategory(aOSearchCategory);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchCategory.CurrentPage),
                aOSearchCategory.CurrentDate, Convert.ToInt32(aOSearchCategory.Limit));

            return pagination;
        }

        public async Task<Category> UpdateCategory(ACategoryUpdateModel aCategoryUpdate, ForceInfo forceInfo)
        {
            return await _aCategoryAction.UpdateCategory(aCategoryUpdate, forceInfo);
        }
    }
}
