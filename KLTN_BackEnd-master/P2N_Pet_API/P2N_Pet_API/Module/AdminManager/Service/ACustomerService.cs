using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ACustomer;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ACustomerService : IACustomerService
    {
        private readonly IACustomerQuery _aCustomerQuery;
        private readonly IACustomerAction _aCustomerAction;
        private readonly IPaginationService _paginationService;

        public ACustomerService(IACustomerQuery aCustomerQuery,
            IACustomerAction aCustomerAction,
            IPaginationService paginationService)
        {
            _aCustomerQuery = aCustomerQuery;
            _aCustomerAction = aCustomerAction;
            _paginationService = paginationService;
        }

        public async Task<List<ACustomerListModel>> GetListCustomer(AOSearchCustomer aOSearchCustomer)
        {
            return await _aCustomerQuery.QueryGetListCustomer(aOSearchCustomer);
        }

        public async Task<PaginationModel> GetListCustomerPagination(AOSearchCustomer aOSearchCustomer)
        {
            var count = await _aCustomerQuery.QueryCountListCustomer(aOSearchCustomer);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchCustomer.CurrentPage),
                aOSearchCustomer.CurrentDate, Convert.ToInt32(aOSearchCustomer.Limit));

            return pagination;
        }

        public async Task<ACustomerModel> GetCustomerDetail(ulong Id)
        {
            return await _aCustomerQuery.QueryGetCustomerDetail(Id);
        }

        public async Task<Customer> CreateCustomer(ForceInfo forceInfo, ACustomerCreateModel aCustomerCreateModel)
        {
            return await _aCustomerAction.Create(forceInfo, aCustomerCreateModel);
        }

        public async Task<Customer> UpdateCustomer(ForceInfo forceInfo, ACustomerUpdateModel aCustomerUpdateModel)
        {
            return await _aCustomerAction.Update(forceInfo, aCustomerUpdateModel);
        }

        public async Task<Customer> DeleteCustomer(ForceInfo forceInfo, ulong Id)
        {
            return await _aCustomerAction.Delete(forceInfo, Id);
        }
    }
}
