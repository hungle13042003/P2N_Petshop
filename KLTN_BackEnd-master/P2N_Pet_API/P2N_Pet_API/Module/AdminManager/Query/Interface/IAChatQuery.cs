using P2N_Pet_API.Module.AdminManager.Models.AChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAChatQuery
    {
        Task<int> CheckMessageFromUser(ulong chatId, ulong userId);
        Task<ulong> CheckRoomUser(ulong userId);
        Task<string> QueryDeleteDateCreateUser(ulong chatRoomId);
        Task<List<AChatUserModel>> QueryListChatUser(AOSearchChatUser aOSearchChatUser);
        Task<string> QueryChatDeleteDate(ulong chatRoomId, ulong userId);
        Task<List<AChatContentModel>> QueryListChat(DateTime deleteDate, AOSearchChatContent aOSearchChatContent);
        Task<ulong> QueryOwnerChatRoom(ulong chatRoomId);
    }
}
