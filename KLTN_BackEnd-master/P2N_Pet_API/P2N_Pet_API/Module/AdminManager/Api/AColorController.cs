using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AColor;
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

    public class AColorController : ControllerBase
    {
        private readonly IAColorService _aColorService;

        public AColorController(IAColorService aColorService)
        {
            _aColorService = aColorService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchColor aOSearchColor)
        {
            try
            {
                var colors = await _aColorService.GetListColor(aOSearchColor);

                var pagination = await _aColorService.GetListColorPagination(aOSearchColor);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Colors = colors,
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
        public async Task<IActionResult> GetDetailColor(ulong Id)
        {
            var color = await _aColorService.GetColorDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Color = color
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateColor(AColorCreateModel aColorCreateModel)
        {
            if (string.IsNullOrEmpty(aColorCreateModel.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền màu sắc."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var colorEntity = await _aColorService.CreateColor(forceInfo, aColorCreateModel);

            var color = await _aColorService.GetColorDetail(colorEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Color = color
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateColor(AColorUpdateModel aColorUpdateModel)
        {
            if (string.IsNullOrEmpty(aColorUpdateModel.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền màu sắc."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var colorEntity = await _aColorService.UpdateColor(forceInfo, aColorUpdateModel);

            var color = await _aColorService.GetColorDetail(colorEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Color = color
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteColor(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var colorEntity = await _aColorService.DeleteColor(forceInfo, Id);

            var color = await _aColorService.GetColorDetail(colorEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Color = color
                }
            });
        }
    }
}
