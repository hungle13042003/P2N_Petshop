using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASize;
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

    public class ASizeController : ControllerBase
    {
        private readonly IASizeService _aSizeService;

        public ASizeController(IASizeService aSizeService)
        {
            _aSizeService = aSizeService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchSize aOSearchSize)
        {
            try
            {
                var sizes = await _aSizeService.GetListSize(aOSearchSize);

                var pagination = await _aSizeService.GetListSizePagination(aOSearchSize);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Sizes = sizes,
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
        public async Task<IActionResult> GetDetailSize(ulong Id)
        {
            var size = await _aSizeService.GetSizeDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Size = size
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateSize(ASizeCreateModel aSizeCreateModel)
        {
            if (string.IsNullOrEmpty(aSizeCreateModel.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tuổi."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var sizeEntity = await _aSizeService.CreateSize(forceInfo, aSizeCreateModel);

            var size = await _aSizeService.GetSizeDetail(sizeEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Size = size
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSize(ASizeUpdateModel aSizeUpdateModel)
        {
            if (string.IsNullOrEmpty(aSizeUpdateModel.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tuổi."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var sizeEntity = await _aSizeService.UpdateSize(forceInfo, aSizeUpdateModel);

            var size = await _aSizeService.GetSizeDetail(sizeEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Size = size
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSize(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var sizeEntity = await _aSizeService.DeleteSize(forceInfo, Id);

            var size = await _aSizeService.GetSizeDetail(sizeEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Size = size
                }
            });
        }
    }
}
