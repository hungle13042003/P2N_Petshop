using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAChatAction
    {
        Task<Chatcontent> CreateOneMessage(ForceInfo forceInfo, AChatCreateModel aChatCreateModel, ulong chatRoomIdFromUser,
            DateTime deleteDateCreateUser);
        Task<Chatcontent> DeleteOneMessage(ForceInfo forceInfo, ulong chatContentId);
        Task DeleteConversation(ForceInfo forceInfo, ulong chatId);
    }
}
