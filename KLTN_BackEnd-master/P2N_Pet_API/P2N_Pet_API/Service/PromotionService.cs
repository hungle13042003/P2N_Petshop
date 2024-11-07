using P2N_Pet_API.Models.Promotion;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionQuery _promotionQuery;
        public PromotionService(IPromotionQuery promotionQuery)
        {
            _promotionQuery = promotionQuery;
        }

        public async Task<PromotionModel> GetPromotion(DateTime dateNow)
        {
            return await _promotionQuery.QueryPromotion(dateNow);
        }
    }
}
