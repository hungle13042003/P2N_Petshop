using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Chat;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface IChatService
    {
        Task<Chatcontent> CreateOneMessage(ForceInfo forceInfo, ChatCreateModel chatCreateModel);
        Task<ObjectResponse> UpdateOneMessage(ForceInfo forceInfo, ChatUpdateModel chatUpdateModel);
        Task<ObjectResponse> DeleteOneMessage(ForceInfo forceInfo, ulong chatId);
        Task<List<ChatContentModel>> GetListChat(ForceInfo forceInfo, OSearchChatContent oSearchChatContent);
        Task DeleteConversation(ForceInfo forceInfo);
    }
}
