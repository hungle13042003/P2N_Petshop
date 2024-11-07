using P2N_Pet_API.Module.AdminManager.Models.ACustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IACustomerQuery
    {
        Task<List<ACustomerListModel>> QueryGetListCustomer(AOSearchCustomer aOSearchCustomer);
        Task<int> QueryCountListCustomer(AOSearchCustomer aOSearchCustomer);
        Task<ACustomerModel> QueryGetCustomerDetail(ulong Id);
    }
}
