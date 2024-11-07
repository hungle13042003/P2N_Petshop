using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService.Interface
{
    public interface IPaymentVNPayService
    {
        Task<string> PaymentVNPay(string orderInfo, string amount);
    }
}
