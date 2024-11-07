using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProduct;
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

    public class AProductController : ControllerBase
    {
        private readonly IAProductService _aProductService;

        public AProductController(IAProductService aProductService)
        {
            _aProductService = aProductService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchProduct aOSearchProduct)
        {
            try
            {
                var products = await _aProductService.GetListProduct(aOSearchProduct);

                var pagination = await _aProductService.GetListProductPagination(aOSearchProduct);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Products = products,
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
        public async Task<IActionResult> GetDetailProduct(ulong Id)
        {
            var product = await _aProductService.GetProductDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Product = product
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AProductCreateModel aProductCreateModel)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var productEntity = await _aProductService.CreateProduct(forceInfo, aProductCreateModel);

            var product = await _aProductService.GetProductDetail(productEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Product = product
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(AProductUpdateModel aProductUpdateModel)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var productEntity = await _aProductService.UpdateProduct(forceInfo, aProductUpdateModel);

            var product = await _aProductService.GetProductDetail(productEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Product = product
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var productEntity = await _aProductService.DeleteProduct(forceInfo, Id);

            var product = await _aProductService.GetProductDetail(productEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Product = product
                }
            });
        }
    }
}
