using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Chatroomuser
    {
        public ulong Id { get; set; }
        public ulong? Chatroomid { get; set; }
        public ulong? Userid { get; set; }
        public DateTime? Deletedate { get; set; }
        public int? Status { get; set; }
        public ulong? Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public ulong? Updateuser { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
