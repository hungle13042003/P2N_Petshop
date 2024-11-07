using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.Cart;
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
    [UserAccess]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItemCreateModel cartItemCreate)
        {
            if(cartItemCreate.ProductDetailId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn productdetailid",
                });
            }

            try
            {
                var forceInfo = new ForceInfo
                {
                    UserId = Utils.GetUserIdFromToken(Request),
                    DateNow = Utils.DateNow()
                };

                var objectResponse = await _cartService.AddToCart(cartItemCreate, forceInfo);

                return Ok(objectResponse);
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
        public async Task<IActionResult> UpdateQuantityCartItem(CartItemUpdateModel cartItemUpdate)
        {
            if (cartItemUpdate.CartItemId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn cartItemId",
                });
            }

            if (cartItemUpdate.ProductDetailId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn productdetailid",
                });
            }

            if (cartItemUpdate.Quantity < 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhap quantity",
                });
            }

            try
            {
                var forceInfo = new ForceInfo
                {
                    UserId = Utils.GetUserIdFromToken(Request),
                    DateNow = Utils.DateNow()
                };

                var objectResponse = await _cartService.UpdateQuantityCartItem(forceInfo, cartItemUpdate);

                return Ok(objectResponse);
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
        public async Task<IActionResult> DeleteCartItem(ulong CartItemId)
        {
            if (CartItemId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn cartItemId",
                });
            }

            try
            {
                var forceInfo = new ForceInfo
                {
                    UserId = Utils.GetUserIdFromToken(Request),
                    DateNow = Utils.DateNow()
                };

                var objectResponse = await _cartService.DeleteCartItem(forceInfo, CartItemId);

                return Ok(objectResponse);
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
        public async Task<IActionResult> GetListCartItem()
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var objectResponse = await _cartService.GetListCartItem(forceInfo.UserId);

            return Ok(objectResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuantityByProductDetailIdAndUser(ulong productDetailId = 0)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var objectResponse = await _cartService.GetQuantityByProductDetailIdAndUser(productDetailId, forceInfo.UserId);
            return Ok(objectResponse);
        }

        [HttpGet]

        public async Task<IActionResult> GetCountQuantityCartItem()
        {
            var userid = Utils.GetUserIdFromToken(Request);

            var objectResponse = await _cartService.GetCountQuantityCartItem(userid);

            return Ok(objectResponse);
        }
    }
}
