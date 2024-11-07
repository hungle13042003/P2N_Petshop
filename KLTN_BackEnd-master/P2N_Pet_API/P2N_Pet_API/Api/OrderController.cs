using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.Order;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateModel orderCreate)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var objectResponse = await _orderService.CreateOrder(orderCreate, forceInfo);

            return Ok(objectResponse);
        }

        [HttpPost]
        public async Task<IActionResult> GetListHistoryOrder(OSearchHistoryProduct oSearchHistoryProduct)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var orderList = await _orderService.GetListHistoryOrder(forceInfo, oSearchHistoryProduct);

            var paginationOrders = await _orderService.GetListHistoryOrderPagination(forceInfo, oSearchHistoryProduct);

            if (orderList == null || orderList.Count == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Không có đơn hàng nào đã đặt"
                });
            }

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy danh sách đặt hàng thành công",
                content = new
                {
                    Orders = orderList,
                    Pagination = paginationOrders
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetail(ulong orderId)
        {
            if (orderId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng dien orderId",
                });
            }

            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var objectResponse = await _orderService.GetOrderDetail(forceInfo, orderId);

            return Ok(objectResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(ulong orderId)
        {
            if(orderId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng dien orderId",
                });
            }

            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var objectResponse = await _orderService.CancelOrder(forceInfo, orderId);

            return Ok(objectResponse);
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailOrder(ulong orderid)
        {
            try
            {
                var forceInfo = new ForceInfo
                {
                    UserId = Utils.GetUserIdFromToken(Request),
                    DateNow = Utils.DateNow()
                };

                await _orderService.SendEmailOrder(forceInfo, orderid);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Gửi thông báo đơn hàng thành công!"
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


        //[HttpGet]
        //public async Task<IActionResult> PaymentMomoSuccess(string orderInfo, string errorCode)
        //{
        //    await _orderService.PaymentMomoSuccess(orderInfo, errorCode);

        //    return Ok(new ObjectResponse
        //    {
        //        result = 1,
        //        message = "Thanh toán nha"
        //    });
        //}
    }
}
