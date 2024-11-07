using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.APromotion;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ManagerAccess]

    public class APromotionController : ControllerBase
    {
        private readonly IAPromotionService _aPromotionService;

        public APromotionController(IAPromotionService aPromotionService)
        {
            _aPromotionService = aPromotionService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchPromotion aOSearchPromotion)
        {
            try
            {
                var promotions = await _aPromotionService.GetListPromotion(aOSearchPromotion);

                var pagination = await _aPromotionService.GetListPromotionPagination(aOSearchPromotion);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Promotions = promotions,
                        Pagination = pagination
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã có lỗi xảy ra. Vui lòng thử lại.",
                    content = e.Message.ToString()
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailPromotion(ulong Id)
        {
            var promotion = await _aPromotionService.GetPromotionDetail(Id);

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

        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromForm] APromotionCreateModel aPromotionCreateModel)
        {
            if (string.IsNullOrEmpty(aPromotionCreateModel.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tiêu đề quảng cáo."
                });
            }

            if (aPromotionCreateModel.FromDate == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập ngày bắt đầu."
                });
            }

            if (aPromotionCreateModel.ToDate == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập ngày kết thúc."
                });
            }

            if (aPromotionCreateModel.Status == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập trạng thái."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var promotionEntity = await _aPromotionService.CreatePromotion(forceInfo, aPromotionCreateModel);

            var promotion = await _aPromotionService.GetPromotionDetail(promotionEntity.Id);

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

        [HttpPost]
        public async Task<IActionResult> UpdatePromotion([FromForm] APromotionUpdateModel aPromotionUpdateModel)
        {
            if (string.IsNullOrEmpty(aPromotionUpdateModel.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập id quảng cáo."
                });
            }

            if (string.IsNullOrEmpty(aPromotionUpdateModel.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tiêu đề quảng cáo."
                });
            }

            if (aPromotionUpdateModel.FromDate == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập ngày bắt đầu."
                });
            }

            if (aPromotionUpdateModel.ToDate == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập ngày kết thúc."
                });
            }

            if (aPromotionUpdateModel.Status == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập trạng thái."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var promotionEntity = await _aPromotionService.UpdatePromotion(forceInfo, aPromotionUpdateModel);

            var promotion = await _aPromotionService.GetPromotionDetail(promotionEntity.Id);

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

        [HttpPost]
        public async Task<IActionResult> DeletePromotion(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var promotionEntity = await _aPromotionService.DeletePromotion(forceInfo, Id);

            var promotion = await _aPromotionService.GetPromotionDetail(promotionEntity.Id);

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
