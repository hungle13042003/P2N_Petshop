using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ACategory
{
    public class ACategoryModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong CategoryRootId { get; set; }
        public string CategoryIdName { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public int TypeProductId { get; set; }
        public string TypeProductName { get; set; }
    }
}
