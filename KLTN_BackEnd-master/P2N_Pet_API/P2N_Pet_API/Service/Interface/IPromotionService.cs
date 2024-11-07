using P2N_Pet_API.Models.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface IPromotionService
    {
        Task<PromotionModel> GetPromotion(DateTime dateNow);
    }
}
