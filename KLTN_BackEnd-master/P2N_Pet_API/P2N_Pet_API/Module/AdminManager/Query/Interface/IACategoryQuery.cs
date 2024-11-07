using P2N_Pet_API.Module.AdminManager.Models.ACategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IACategoryQuery
    {
        Task<List<ACategoryListModel>> QueryGetListCategory(AOSearchCategory aOSearch);
        Task<int> QueryCountListCategory(AOSearchCategory aOSearch);
        Task<ACategoryModel> QueryDetailCategory(ulong Id);
    }
}
