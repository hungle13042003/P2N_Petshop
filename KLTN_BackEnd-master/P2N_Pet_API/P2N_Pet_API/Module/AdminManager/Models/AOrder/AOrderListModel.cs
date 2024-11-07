using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AOrder
{
    public class AOrderListModel
    {
        public ulong Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public ulong TotalMoney { get; set; }
        public string Note { get; set; }
        public int TypePaymentId { get; set; }
        public string TypePaymentName { get; set; }
        public int StatusPaymentId { get; set; }
        public string StatusPaymentName { get; set; }
        public string StatusText { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
