using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Brandproduct
    {
        public ulong Id { get; set; }
        public ulong? Brandid { get; set; }
        public ulong? Productdetailid { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public ulong? Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public ulong? Updateuser { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
