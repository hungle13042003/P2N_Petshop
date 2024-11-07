using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABreed;
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

    public class ABreedController : ControllerBase
    {
        private readonly IABreedService _aBreedService;

        public ABreedController(IABreedService aBreedService)
        {
            _aBreedService = aBreedService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchBreed aOSearchBreed)
        {
            try
            {
                var breeds = await _aBreedService.GetListBreed(aOSearchBreed);

                var pagination = await _aBreedService.GetListBreedPagination(aOSearchBreed);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Breeds = breeds,
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
        public async Task<IActionResult> GetDetailBreed(ulong Id)
        {
            var breed = await _aBreedService.GetBreedDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Breed = breed
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreed(ABreedCreateModel aBreedCreateModel)
        {
            if (string.IsNullOrEmpty(aBreedCreateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên giống thú cưng."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var breedEntity = await _aBreedService.CreateBreed(forceInfo, aBreedCreateModel);

            var breed = await _aBreedService.GetBreedDetail(breedEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Breed = breed
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBreed(ABreedUpdateModel aBreedUpdateModel)
        {
            if (string.IsNullOrEmpty(aBreedUpdateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên giống thú cưng.."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var breedEntity = await _aBreedService.UpdateBreed(forceInfo, aBreedUpdateModel);

            var breed = await _aBreedService.GetBreedDetail(breedEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Breed = breed
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBreed(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var breedEntity = await _aBreedService.DeleteBreed(forceInfo, Id);

            var breed = await _aBreedService.GetBreedDetail(breedEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Breed = breed
                }
            });
        }
    }
}
