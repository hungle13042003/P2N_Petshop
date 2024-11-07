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
    public class PaymentMomoController : ControllerBase
    {
        private readonly IPaymentMomoService _paymentMomoService;
        private readonly IOrderService _orderService;
        public PaymentMomoController(IPaymentMomoService paymentMomoService,
             IOrderService orderService)
        {
            _paymentMomoService = paymentMomoService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentMomo(string orderInfo, string amount)
        {
            var paymentUrl = await _paymentMomoService.PaymentMomo(orderInfo, amount);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Thanh toán nha",
                content = new
                {
                    PaymentUrl = paymentUrl
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> PaymentMomoSuccess(string orderInfo, int errorCode)
        {
            await _orderService.PaymentMomoSuccess(orderInfo, errorCode);

            return Redirect("https://p2n.yoot.vn/index");
        }
    }
}
