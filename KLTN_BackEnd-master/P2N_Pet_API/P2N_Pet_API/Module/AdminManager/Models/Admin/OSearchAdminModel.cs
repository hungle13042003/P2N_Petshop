using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.Admin
{
    public class OSearchAdminModel
    {
        [DefaultValue(0)]
        public int CurrentPage { get; set; }

        [DefaultValue("")]
        public string CurrentDate { get; set; }

        [DefaultValue(25)]
        public int Limit { get; set; }

        [DefaultValue("")]
        public string Name { get; set; }
        [DefaultValue("")]
        public string Phone { get; set; }
        [DefaultValue("")]
        public string Email { get; set; }
        [DefaultValue(0)]
        public int Status { get; set; }

        [DefaultValue(0)]
        public int StatusBlock { get; set; }

        [DefaultValue(0)]
        public int RoleId { get; set; }
    }
}
