using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ACustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IACustomerService
    {
        Task<List<ACustomerListModel>> GetListCustomer(AOSearchCustomer aOSearchCustomer);
        Task<PaginationModel> GetListCustomerPagination(AOSearchCustomer aOSearchCustomer);
        Task<ACustomerModel> GetCustomerDetail(ulong Id);
        Task<Customer> CreateCustomer(ForceInfo forceInfo, ACustomerCreateModel aCustomerCreateModel);
        Task<Customer> UpdateCustomer(ForceInfo forceInfo, ACustomerUpdateModel aCustomerUpdateModel);
        Task<Customer> DeleteCustomer(ForceInfo forceInfo, ulong Id);
    }
}
