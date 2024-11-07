using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Sex
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
    }
}
