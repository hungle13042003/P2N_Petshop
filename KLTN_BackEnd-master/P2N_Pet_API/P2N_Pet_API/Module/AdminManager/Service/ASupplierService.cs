using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ASupplier;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ASupplierService : IASupplierService
    {
        private readonly IASupplierQuery _aSupplierQuery;
        private readonly IASupplierAction _aSupplierAction;
        private readonly IPaginationService _paginationService;

        public ASupplierService(IASupplierQuery aSupplierQuery,
            IASupplierAction aSupplierAction,
            IPaginationService paginationService)
        {
            _aSupplierQuery = aSupplierQuery;
            _aSupplierAction = aSupplierAction;
            _paginationService = paginationService;
        }

        public async Task<List<ASupplierListModel>> GetListSupplier(AOSearchSupplier aOSearchSupplier)
        {
            return await _aSupplierQuery.QueryGetListSupplier(aOSearchSupplier);
        }

        public async Task<PaginationModel> GetListSupplierPagination(AOSearchSupplier aOSearchSupplier)
        {
            var count = await _aSupplierQuery.QueryCountListSupplier(aOSearchSupplier);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchSupplier.CurrentPage),
                aOSearchSupplier.CurrentDate, Convert.ToInt32(aOSearchSupplier.Limit));

            return pagination;
        }

        public async Task<ASupplierModel> GetSupplierDetail(ulong Id)
        {
            return await _aSupplierQuery.QueryGetSupplierDetail(Id);
        }

        public async Task<Supplier> CreateSupplier(ForceInfo forceInfo, ASupplierCreateModel aSupplierCreateModel)
        {
            return await _aSupplierAction.Create(forceInfo, aSupplierCreateModel);
        }

        public async Task<Supplier> UpdateSupplier(ForceInfo forceInfo, ASupplierUpdateModel aSupplierUpdateModel)
        {
            return await _aSupplierAction.Update(forceInfo, aSupplierUpdateModel);
        }

        public async Task<Supplier> DeleteSupplier(ForceInfo forceInfo, ulong Id)
        {
            return await _aSupplierAction.Delete(forceInfo, Id);
        }
    }
}
