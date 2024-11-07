using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AChat
{
    public class AChatCreateModel
    {
        public ulong ChatRoomId { get; set; }
        public string Content { get; set; }
    }
}
