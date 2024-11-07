using P2N_Pet_API.Module.AdminManager.Models.AAge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAAgeQuery
    {
        Task<List<AAgeListModel>> QueryGetListAge(AOSearchAge aOSearchAge);
        Task<int> QueryCountListAge(AOSearchAge aOSearchAge);
        Task<AAgeModel> QueryGetAgeDetail(ulong Id);
    }
}
