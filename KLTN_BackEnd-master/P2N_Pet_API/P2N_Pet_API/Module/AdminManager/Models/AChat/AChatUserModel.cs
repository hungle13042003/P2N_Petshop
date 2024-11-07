using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AChat
{
    public class AChatUserModel
    {
        public ulong ChatRoomId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public DateTime DateAction { get; set; }
    }
}
