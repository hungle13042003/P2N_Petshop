using P2N_Pet_API.Module.AdminManager.Models.AColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAColorQuery
    {
        Task<List<AColorListModel>> QueryGetListColor(AOSearchColor aOSearchColor);
        Task<int> QueryCountListColor(AOSearchColor aOSearchColor);
        Task<AColorModel> QueryGetColorDetail(ulong Id);
    }
}
