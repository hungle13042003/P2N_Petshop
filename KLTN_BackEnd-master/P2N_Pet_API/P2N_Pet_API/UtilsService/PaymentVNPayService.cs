using Microsoft.AspNetCore.Http;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService
{
    public class PaymentVNPayService: IPaymentVNPayService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PaymentVNPayService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> PaymentVNPay(string orderInfo, string amount) 
        {
            //Get Config Info
            string returnUrl = "http://157.119.251.140:9713/api/PaymentVNPay/PaymentVNPaySuccess"; 
            string url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"; 
            string tmnCode = "NVILZK55"; 
            string hashSecret = "CIXDZDEMKDGXQZZAGXSGRPGZZODSNBUA"; 

            PayLib pay = new PayLib();

            string amountText = amount.Trim() + "00";

            pay.AddRequestData("vnp_Version", "2.1.0"); 
            pay.AddRequestData("vnp_Command", "pay"); 
            pay.AddRequestData("vnp_TmnCode", tmnCode); 
            pay.AddRequestData("vnp_Amount", amountText); 
            pay.AddRequestData("vnp_BankCode", ""); 
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); 
            pay.AddRequestData("vnp_CurrCode", "VND"); 
            pay.AddRequestData("vnp_IpAddr", GetIpAddress()); 
            pay.AddRequestData("vnp_Locale", "vn"); 
            pay.AddRequestData("vnp_OrderInfo", orderInfo); 
            pay.AddRequestData("vnp_OrderType", "other");
            pay.AddRequestData("vnp_ReturnUrl", returnUrl);
            pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); 

            string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

            return paymentUrl;
        }

        public string GetIpAddress()
        {
            string ipAddress;
            try
            {
                ipAddress = _httpContextAccessor.HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR");

                if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown") || ipAddress.Length > 45)
                    ipAddress = _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_ADDR");
            }
            catch (Exception ex)
            {
                ipAddress = "Invalid IP:" + ex.Message;
            }

            return ipAddress;
        }
    }
}
