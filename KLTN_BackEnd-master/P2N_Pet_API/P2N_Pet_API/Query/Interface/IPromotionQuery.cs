using P2N_Pet_API.Models.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface IPromotionQuery
    {
        Task<PromotionModel> QueryPromotion(DateTime dateNow);
    }
}
