using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Product
    {
        public ulong Id { get; set; }
        public string Productname { get; set; }
        public ulong? Breedid { get; set; }
        public ulong? Supplierid { get; set; }
        public int? Categoryid { get; set; }
        public string Content { get; set; }
        public int? Status { get; set; }
        public ulong? Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public ulong? Updateuser { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
