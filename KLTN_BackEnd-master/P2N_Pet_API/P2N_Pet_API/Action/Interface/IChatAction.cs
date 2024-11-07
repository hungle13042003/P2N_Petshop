using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Chat;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action.Interface
{
    public interface IChatAction
    {
        Task<Chatcontent> CreateOneMessage(ulong chatRoomId, ForceInfo forceInfo, ChatCreateModel chatCreateModel);
        Task<Chatcontent> UpdateOneMessage(ForceInfo forceInfo, ChatUpdateModel chatUpdateModel);
        Task<Chatcontent> DeleteOneMessage(ForceInfo forceInfo, ulong chatId);
        Task DeleteConversation(ForceInfo forceInfo, ulong chatId);
    }
}
