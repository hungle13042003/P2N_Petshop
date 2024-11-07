using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AOrder
{
    public class AOSearchOrder
    {
        public string Limit { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentPage { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string StatusOrderId { get; set; }
        public string TypePaymentId { get; set; }
        public string StatusPaymentId { get; set; }
        public string Status { get; set; }
    }
}
