using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPromotion()
        {
            var dateNow = Utils.DateNow();

            var promotion = await _promotionService.GetPromotion(dateNow);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Promotion = promotion
                }
            });
        }
    }
}
