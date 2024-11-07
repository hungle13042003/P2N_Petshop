using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AContact
{
    public class AOSearchContact
    {
        public string Limit { get; set; }
        public string CurrentPage { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
    }
}
