using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AAge
{
    public class AAgeUpdateModel
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public int OrderView { get; set; }
        public int Status { get; set; }
    }
}
