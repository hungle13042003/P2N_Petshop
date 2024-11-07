using P2N_Pet_API.Module.AdminManager.Models.ABreed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IABreedQuery
    {
        Task<List<ABreedListModel>> QueryGetListBreed(AOSearchBreed aOSearchBreed);
        Task<int> QueryCountListBreed(AOSearchBreed aOSearchBreed);
        Task<ABreedModel> QueryGetBreedDetail(ulong Id);
    }
}
