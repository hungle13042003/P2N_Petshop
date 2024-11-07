using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ACategory
{
    public class AOSearchCategory
    {
        public int Limit { get; set; }
        public string CurrentDate { get; set; }
        public int CurrentPage { get; set; }
        public string Name { get; set; }
        public ulong CategoryRootId { get; set; }
        public int Status { get; set; }
        public int TypeProductId { get; set; }
    }
}
