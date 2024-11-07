using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AChat
{
    public class AOSearchChatContent
    {
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
        public ulong ChatRoomId { get; set; }
    }
}
