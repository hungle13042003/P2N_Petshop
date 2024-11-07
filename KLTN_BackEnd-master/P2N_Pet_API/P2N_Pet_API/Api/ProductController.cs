using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Models.Product;
using P2N_Pet_API.Models.ProductComment;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductController(IProductService productService,
            ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetListProduct(OSearchProductModel oSearchProduct)
        {
            var products = await _productService.GetListProduct(oSearchProduct);
            var pagination = await _productService.GetListProductPagination(oSearchProduct);

            var typeProductId = products.Select(p => p.TypeProductId).Distinct().FirstOrDefault();
            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy danh sach thu cung thành công",
                content = new
                {
                    Products = products,
                    Pagination = pagination,
                    TypeProductId = typeProductId
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailProduct(ulong ProductDetailId, ulong brandId = 0)
        {
            if (ProductDetailId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền ProductDetailId",
                });
            }

            var result = await _productService.GetDetailProduct(ProductDetailId, brandId);

            if(result == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Lay chi tiet thu cung that bai",
                });
            }

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy chi tiet thu cung thành công.",
                content = new
                {
                    ProductDetail = result
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> GetMultiProductDetail(ProductDetailConditionModel productDetailCondition)
        {
            if(productDetailCondition.ProductDetailId <= 0 && productDetailCondition.ProductId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền ProductDetailId | ProductId",
                });
            }

            if(productDetailCondition.ProductId > 0)
            {
                if(productDetailCondition.SizeId <= 0 && productDetailCondition.ColorId <= 0 &&
                    productDetailCondition.AgeId <= 0 && productDetailCondition.SexId <= 0)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Vui lòng điền SizeId | ColorId | AgeId | SexId",
                    });
                }
            }

            var result = await _productService.GetMultiProductDetail(productDetailCondition);

            if (result == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Lấy chi tiết thú cưng thất bại",
                });
            }

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy chi tiết thú cưng thành công.",
                content = new
                {
                    ProductDetail = result
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> GetListComment(ulong ProductDetailId)
        {
            if(ProductDetailId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn productdetailid",
                });
            }

            try
            {
                var comments = await _commentService.GetListComment(ProductDetailId);

                if (comments.Item1 == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Lấy danh sách comment thất bại",
                    });
                }

              //  var pagination = await _commentService.GetListProductPagination(oSearchComment);
                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Lấy danh sách comment thành công",
                    content = new
                    {
                        Comments = comments.Item1,
                        Avg = comments.Item2
                  //      Pagination = pagination
                    }
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
    }
}
