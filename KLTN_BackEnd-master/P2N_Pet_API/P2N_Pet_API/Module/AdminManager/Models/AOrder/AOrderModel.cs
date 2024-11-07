using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AOrder
{
    public class AOrderModel
    {
        public ulong Id { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public ulong TotalMoney { get; set; }
        public int TypePaymentId { get; set; }
        public string TypePaymentName { get; set; }
        public int StatusPaymentId { get; set; }
        public string StatusPaymentName { get; set; }
        public string Note { get; set; }
        public List<AOrderItemModel> OrderItems { get; set; }
    }
}
