using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABrand;
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
    public class ABrandController : ControllerBase
    {
        private readonly IABrandService _aBrandService;

        public ABrandController(IABrandService aBrandService)
        {
            _aBrandService = aBrandService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandPet(ABrandCreateModel aBrandCreate)
        {
            if( string.IsNullOrWhiteSpace(aBrandCreate.Email) || string.IsNullOrWhiteSpace(aBrandCreate.Phone))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền email và số điện thoại"
                });
            }

            if( string.IsNullOrEmpty(aBrandCreate.Address))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền địa chỉ"
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            try
            {
                var result = await _aBrandService.CreateBrandPet(aBrandCreate, forceInfo);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Tạo chi nhánh thất bại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Tạo chi nhánh thành công",
                    content = new
                    {
                        Brands = result
                    }
                });
            }
            catch(Exception ex)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã xảy ra lỗi.Vui lòng thử lại",
                    content = new
                    {
                        errorMess = ex.Message.ToString(),
                        innerException = ex.InnerException,
                        statusCode = Response.StatusCode
                    }
                });
            }          
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrandPet(ABrandUpdateModel aBrandUpdate)
        {
            if(aBrandUpdate.Id <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền brandid"
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            try
            {
                var result = await _aBrandService.UpdateBrandPet(aBrandUpdate, forceInfo);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Cập nhật chi nhánh thất bại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Cập nhật chi nhánh thành công",
                    content = new
                    {
                        Brands = result
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã xảy ra lỗi.Vui lòng thử lại",
                    content = new
                    {
                        errorMess = ex.Message.ToString(),
                        innerException = ex.InnerException,
                        statusCode = Response.StatusCode
                    }
                });
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBrandPet(ulong brandid = 0)
        {
            if( brandid <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điển brandid"
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            try
            {
                var result = await _aBrandService.DeleteBrandPet(brandid, forceInfo);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Xóa chi nhánh thất bại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Xóa chi nhánh thành công",
                    content = new
                    {
                        Brands = result
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã xảy ra lỗi.Vui lòng thử lại",
                    content = new
                    {
                        errorMess = ex.Message.ToString(),
                        innerException = ex.InnerException,
                        statusCode = Response.StatusCode
                    }
                });
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> GetListBrand(AOSearchBrand aOSearchBrand)
        {
            try
            {
                var result = await _aBrandService.GetListBrand(aOSearchBrand);
                var pagination = await _aBrandService.GetListBrandPagination(aOSearchBrand);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Brands = result,
                        Pagination = pagination
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã xảy ra lỗi.Vui lòng thử lại",
                    content = new
                    {
                        errorMess = ex.Message.ToString(),
                        innerException = ex.InnerException,
                        statusCode = Response.StatusCode
                    }
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailBrand(ulong brandid = 0)
        {
            try
            {
                var result = await _aBrandService.GetDetailBrand(brandid);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Brand = result                        
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã xảy ra lỗi.Vui lòng thử lại",
                    content = new
                    {
                        errorMess = ex.Message.ToString(),
                        innerException = ex.InnerException,
                        statusCode = Response.StatusCode
                    }
                });
            }

        }
    }
}
