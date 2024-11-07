using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AProductDetail
{
    public class AProductDetailListModel
    {
        public ulong Id { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string ColorTitle { get; set; }
        public string SizeTitle { get; set; }
        public string AgeTitle { get; set; }
        public string SexTitle { get; set; }
        public string StatusDetailTitle { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public int Quantity { get; set; }
        public string StatusText { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
