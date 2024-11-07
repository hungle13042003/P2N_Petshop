using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProductDetail;
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
    public class AProductDetailController : ControllerBase
    {
        private readonly IAProductDetailService _aProductDetailService;

        public AProductDetailController(IAProductDetailService aProductDetailService)
        {
            _aProductDetailService = aProductDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchProductDetail aOSearchProductDetail)
        {
            try
            {
                var productDetails = await _aProductDetailService.GetListProductDetail(aOSearchProductDetail);

                var pagination = await _aProductDetailService.GetListProductDetailPagination(aOSearchProductDetail);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        ProductDetails = productDetails,
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
        public async Task<IActionResult> GetDetailProductDetail(ulong Id)
        {
            var productDetail = await _aProductDetailService.GetInProductDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ProductDetail = productDetail
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail([FromForm] AProductDetailCreateModel aProductDetailCreateModel)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var productDetailEntity = await _aProductDetailService.CreateProductDetail(forceInfo, aProductDetailCreateModel);

            if(productDetailEntity == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Không tồn tại sản phẩm này để tạo chi tiết"                    
                });
            }

            var productDetail = await _aProductDetailService.GetInProductDetail(productDetailEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ProductDetail = productDetail
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail([FromForm] AProductDetailUpdateModel aProductDetailUpdateModel)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var productDetailEntity = await _aProductDetailService.UpdateProductDetail(forceInfo, aProductDetailUpdateModel);

            if (productDetailEntity == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Không tồn tại sản phẩm này để tạo chi tiết"
                });
            }

            var productDetail = await _aProductDetailService.GetInProductDetail(productDetailEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ProductDetail = productDetail
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductDetail(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var productDetailEntity = await _aProductDetailService.DeleteProductDetail(forceInfo, Id);

            var productDetail = await _aProductDetailService.GetInProductDetail(productDetailEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ProductDetail = productDetail
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductDetailImage(ulong productImageId)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            await _aProductDetailService.DeleteProductDetailImage(forceInfo, productImageId);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Xóa hình ảnh thành công!"
            });
        }
    }
}
