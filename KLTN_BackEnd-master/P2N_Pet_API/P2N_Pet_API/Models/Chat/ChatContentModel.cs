using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Chat
{
    public class ChatContentModel
    {
        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public string Content { get; set; }
    }
}
