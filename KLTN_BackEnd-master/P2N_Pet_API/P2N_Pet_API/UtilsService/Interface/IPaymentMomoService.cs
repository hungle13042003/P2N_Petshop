using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService.Interface
{
    public interface IPaymentMomoService
    {
        Task<string> PaymentMomo(string orderInfo, string amount);
        Task<string> SendPaymentRequest(string endPoint, string postJsonString);
        Task<string> SignSHA256(string message, string key);
    }
}
