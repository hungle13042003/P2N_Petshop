﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ABreed
{
    public class ABreedModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong BreedId { get; set; }
        public int Status { get; set; }
    }
}
