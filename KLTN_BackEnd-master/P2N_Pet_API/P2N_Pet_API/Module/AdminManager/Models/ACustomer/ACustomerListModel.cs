using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ACustomer
{
    public class ACustomerListModel
    {
        public ulong Id { get; set; }
        public ulong OrderId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StatusText { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
