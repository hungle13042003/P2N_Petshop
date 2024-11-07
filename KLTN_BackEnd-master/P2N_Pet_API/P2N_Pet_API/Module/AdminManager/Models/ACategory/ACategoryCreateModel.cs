using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ACategory
{
    public class ACategoryCreateModel
    {
        public string Title { get; set; }
        public int CategoryRootId { get; set; }
        public int Status { get; set; }
        public int TypeProductId { get; set; }
    }
}
