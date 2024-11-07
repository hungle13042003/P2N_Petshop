using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Order
{
    public class OrderHistoryListModel
    {
        public ulong OrderId { get; set; }
        public DateTime CreateOrder { get; set; }
        public ulong TotalMoney { get; set; }
        public int NumBreed { get; set; }
        public int NumOrder { get; set; }
        public string Address { get; set; }
        public int StatusOrderId { get; set; }
        public string StatusOrderText { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public string TypePaymentName { get; set; }
        public string StatusPaymentName { get; set; }
    }
}
