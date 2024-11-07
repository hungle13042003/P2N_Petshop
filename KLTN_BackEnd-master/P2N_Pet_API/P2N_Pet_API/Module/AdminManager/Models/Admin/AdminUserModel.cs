using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.Admin
{
    public class AdminUserModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
    }
}
