using System;
using System.Collections.Generic;

#nullable disable

namespace P2N_Pet_API.Database.PetShopModels
{
    public partial class Chatcontent
    {
        public ulong Id { get; set; }
        public ulong? Chatroomid { get; set; }
        public ulong? Userid { get; set; }
        public string Content { get; set; }
        public int? Isnew { get; set; }
        public int? Status { get; set; }
        public ulong? Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public ulong? Updateuser { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
