using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ACategory;
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
    public class ACategoryController : ControllerBase
    {
        private readonly IACategoryService _aCategoryService;

        public ACategoryController(IACategoryService aCategoryService)
        {
            _aCategoryService = aCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(ACategoryCreateModel aCategoryCreate)
        {

            if (string.IsNullOrEmpty(aCategoryCreate.Title) || string.IsNullOrWhiteSpace(aCategoryCreate.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên loại thức ăn/ phụ kiện"
                });
            }

            if (aCategoryCreate.TypeProductId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn loại chính"
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
                var category = await _aCategoryService.CreateCategory(aCategoryCreate, forceInfo);

                if( category == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Luu that bai"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Luu thanh cong"
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(ACategoryUpdateModel aCategoryUpdate)
        {
            if( aCategoryUpdate.Id == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền CategoryId"
                });
            }
            if (string.IsNullOrEmpty(aCategoryUpdate.Title) || string.IsNullOrWhiteSpace(aCategoryUpdate.Title))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên loại thức ăn/ phụ kiện"
                });
            }

            if (aCategoryUpdate.TypeProductId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn loại chính"
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
                var category = await _aCategoryService.UpdateCategory(aCategoryUpdate, forceInfo);

                if (category == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Cap nhat that bai"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Cap nhat thanh cong"
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int categoryid)
        {
            if (categoryid <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điển categoryid"
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
                var result = await _aCategoryService.DeleteCategory(categoryid, forceInfo);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Xóa nhóm sản phẩm thất bại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Xóa nhóm sản phẩm thành công",
                    //content = new
                    //{
                    //    Brands = result
                    //}
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
        public async Task<IActionResult> GetListCategory(AOSearchCategory aOSearchCategory)
        {
            try
            {
                var cates = await _aCategoryService.GetListCategory(aOSearchCategory);

                var pagination = await _aCategoryService.GetListCategoryPagination(aOSearchCategory);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Categories = cates,
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
        public async Task<IActionResult> GetDetailCategory(ulong Id)
        {
            if(Id <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui long chon categoryid"
                });
            }

            try
            {
                var cate = await _aCategoryService.GetDetailCategory(Id);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Category = cate,
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
    }    
}
