using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentVNPayController : ControllerBase
    {
        private readonly IPaymentVNPayService _paymentVNPayService;
        private readonly IOrderService _orderService; 

        public PaymentVNPayController(IPaymentVNPayService paymentVNPayService,
            IOrderService orderService)
        {
            _paymentVNPayService = paymentVNPayService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentVNPay(string orderInfo, string amount)
        {
            var url = await _paymentVNPayService.PaymentVNPay(orderInfo, amount);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    url
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> PaymentVNPaySuccess(string vnp_OrderInfo, string vnp_ResponseCode)
        {
            await _orderService.PaymentVNPaySuccess(vnp_OrderInfo, vnp_ResponseCode);

            return Redirect("https://p2n.yoot.vn/index");
        }
    }
}
