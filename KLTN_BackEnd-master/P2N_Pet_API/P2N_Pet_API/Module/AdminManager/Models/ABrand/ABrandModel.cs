using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ABrand
{
    public class ABrandModel
    {
        public ulong Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }

        public List<ABrandProductModel> products { get; set; }
    }
}
