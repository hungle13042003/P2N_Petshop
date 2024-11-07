using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ACategory
{
    public class ACategoryListModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string CategoryIdName { get; set; }
        public string StatusText { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDate { get; set; }
        public int TypeProductId { get; set; }
        public string TypeProductName { get; set; }
    }
}
