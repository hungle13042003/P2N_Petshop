
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ABrand
{
    public class ABrandCreateModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }

        public List<ABrandProductListModel> aBrandProducts { get; set; }
    }
}
