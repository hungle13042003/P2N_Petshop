using P2N_Pet_API.Module.AdminManager.Models.ASupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IASupplierQuery 
    {
        Task<List<ASupplierListModel>> QueryGetListSupplier(AOSearchSupplier aOSearchSupplier);
        Task<int> QueryCountListSupplier(AOSearchSupplier aOSearchSupplier);
        Task<ASupplierModel> QueryGetSupplierDetail(ulong Id);
    }
}
