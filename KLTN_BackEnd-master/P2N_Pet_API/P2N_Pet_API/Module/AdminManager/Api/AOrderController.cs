using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AOrder;
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

    public class AOrderController : ControllerBase
    {
        private readonly IAOrderService _aOrderService;

        public AOrderController(IAOrderService aOrderService)
        {
            _aOrderService = aOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> GetListOrder(AOSearchOrder aOSearchOrder)
        {
            try
            {
                var orders = await _aOrderService.GetListOrder(aOSearchOrder);

                var pagination = await _aOrderService.GetListOrderPagination(aOSearchOrder);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Orders = orders,
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

        [HttpPost]
        public async Task<IActionResult> UpgradeStatusOrder(AOrderUpgradeStatusModel orderUpgradeStatusModel)
        {
            if (orderUpgradeStatusModel.OrderId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Bạn chưa nhập id đơn hàng!"
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var result = await _aOrderService.UpgradeStatusOrder(forceInfo, orderUpgradeStatusModel);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(AOrderCancelModel orderCancelModel)
        {
            if (orderCancelModel.OrderId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Bạn chưa nhập id đơn hàng!"
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var result = await _aOrderService.CancelOrder(forceInfo, orderCancelModel);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetail(ulong OrderId)
        {
            if (OrderId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Bạn chưa nhập id đơn hàng!"
                });
            }

            var orderDetail = await _aOrderService.GetOrderDetail(OrderId);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    OrderDetail = orderDetail
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetCountPending()
        {
            var countPending = await _aOrderService.GetCountPeding();

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    CountPending = countPending
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusPayment(ulong orderId, int statusPaymentId)
        {
            await _aOrderService.UpdateStatusPayment(orderId, statusPaymentId);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Cập nhật thành công",
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusPendingOrder(ulong orderId)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            await _aOrderService.UpdateStatusPendingOrder(dateNow, userId, orderId);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Cập nhật thành công",
            });
        }
    }
}
