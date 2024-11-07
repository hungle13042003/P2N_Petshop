using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAChatService
    {
        Task<Chatcontent> CreateOneMessage(ForceInfo forceInfo, AChatCreateModel chatCreateModel);
        Task<ObjectResponse> DeleteOneMessage(ForceInfo forceInfo, ulong chatContentId);
        Task DeleteConversation(ForceInfo forceInfo);
        Task<List<AChatUserModel>> GetListChatUser(AOSearchChatUser aOSearchChatUser);
        Task<ObjectResponse> GetListChat(ForceInfo forceInfo, AOSearchChatContent aOSearchChatContent);
    }
}
