using P2N_Pet_API.Module.AdminManager.Models.ABrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IABrandQuery
    {
        Task<List<ABrandListModel>> QueryGetListBrand(AOSearchBrand aOSearchBrand);
        Task<int> QueryCountListBrand(AOSearchBrand aOSearchBrand);
        Task<ABrandModel> QueryGetDetail(ulong BrandId);
        Task<List<ABrandProductModel>> QueryListBrandProduct(ulong BrandId);
    }
}
