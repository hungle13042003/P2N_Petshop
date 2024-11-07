using P2N_Pet_API.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface IChatQuery
    {
        Task<int> CheckMessageFromUser(ulong chatId, ulong userId);
        Task<ulong> CheckRoomUser(ulong userId);
        Task<string> QueryChatDeleteDate(ulong userId);
        Task<List<ChatContentModel>> QueryListChat(ulong chatRoomId, DateTime deleteDate, OSearchChatContent oSearchChatContent);
    }
}
