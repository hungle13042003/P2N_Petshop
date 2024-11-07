
using P2N_Pet_API.Module.AdminManager.Models.ASize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IASizeQuery
    {
        Task<List<ASizeListModel>> QueryGetListSize(AOSearchSize aOSearchSize);
        Task<int> QueryCountListSize(AOSearchSize aOSearchSize);
        Task<ASizeModel> QueryGetSizeDetail(ulong Id);
    }
}
