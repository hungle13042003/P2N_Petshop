﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AData
{
    public class ACategorySelectionModel
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public int TypeProductId { get; set; }
    }
}
