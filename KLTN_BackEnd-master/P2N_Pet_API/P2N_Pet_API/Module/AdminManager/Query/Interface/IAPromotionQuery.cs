using P2N_Pet_API.Module.AdminManager.Models.APromotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAPromotionQuery
    {
        Task<List<APromotionListModel>> QueryGetListPromotion(AOSearchPromotion aOSearchPromotion);
        Task<int> QueryCountListPromotion(AOSearchPromotion aOSearchPromotion);
        Task<APromotionModel> QueryGetPromotionDetail(ulong Id);
    }
}
