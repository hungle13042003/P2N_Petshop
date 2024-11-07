using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ABrand
{
    public class AOSearchBrand
    {
        public int Limit { get; set; }
        [DefaultValue("")]
        public string CurrentDate { get; set; }
        public int CurrentPage { get; set; }
        [DefaultValue("")]
        public string Email { get; set; }
        [DefaultValue("")]
        public string Phone { get; set; }
        [DefaultValue("")]
        public string Address { get; set; }
        public int Status { get; set; }
    }
}
