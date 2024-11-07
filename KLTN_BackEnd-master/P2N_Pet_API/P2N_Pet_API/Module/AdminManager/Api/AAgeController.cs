using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AAge;
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

    public class AAgeController : ControllerBase
    {
        private readonly IAAgeService _aAgeService;

        public AAgeController(IAAgeService aAgeService)
        {
            _aAgeService = aAgeService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchAge aOSearchAge)
        {
            try
            {
                var ages = await _aAgeService.GetListAge(aOSearchAge);

                var pagination = await _aAgeService.GetListAgePagination(aOSearchAge);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Ages = ages,
                        Pagination = pagination
                    }
                });
            }
            catch(Exception e)
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
        public async Task<IActionResult> GetDetailAge(ulong Id)
        {
            var age = await _aAgeService.GetAgeDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Age = age
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAge(AAgeCreateModel aAgeCreateModel)
        {
            if (string.IsNullOrEmpty(aAgeCreateModel.Title))
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

            var ageEntity = await _aAgeService.CreateAge(forceInfo, aAgeCreateModel);

            var age = await _aAgeService.GetAgeDetail(ageEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Age = age
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAge(AAgeUpdateModel aAgeUpdateModel)
        {
            if (string.IsNullOrEmpty(aAgeUpdateModel.Title))
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

            var ageEntity = await _aAgeService.UpdateAge(forceInfo, aAgeUpdateModel);

            var age = await _aAgeService.GetAgeDetail(ageEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Age = age
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAge(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var ageEntity = await _aAgeService.DeleteAge(forceInfo, Id);

            var age = await _aAgeService.GetAgeDetail(ageEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Age = age
                }
            });
        }
    }
}
