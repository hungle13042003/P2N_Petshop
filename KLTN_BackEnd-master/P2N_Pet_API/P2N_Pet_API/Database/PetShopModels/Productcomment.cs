using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Productcomment
    {
        public ulong Id { get; set; }
        public ulong? Userid { get; set; }
        public ulong? Productdetailid { get; set; }
        public string Content { get; set; }
        public ulong? Commentrootid { get; set; }
        public float? Rating { get; set; }
        public int? Status { get; set; }
        public ulong? Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public ulong? Updateuser { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
