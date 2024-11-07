using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AProduct
{
    public class AProductListModel
    {
        public ulong Id { get; set; }
        public string BreedName { get; set; }
        public string SupplierName { get; set; }
        public string Content { get; set; }
        public string StatusText { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ProductName { get; set; }
        public ulong CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
