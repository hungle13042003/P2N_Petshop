using P2N_Pet_API.Module.AdminManager.Models.AProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAProductQuery
    {
        Task<List<AProductListModel>> QueryGetListProduct(AOSearchProduct aOSearchProduct);
        Task<int> QueryCountListProduct(AOSearchProduct aOSearchProduct);
        Task<AProductModel> QueryGetProductDetail(ulong Id);
    }
}
