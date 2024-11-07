﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ASupplier
{
    public class ASupplierListModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StatusText { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
