﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Category
{
    public class BreedModel
    {
        public ulong Id { get; set; }
        public string BreedName { get; set; }

        public List<BreedListModel> BreedChild { get; set; }
    }
}
