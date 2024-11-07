using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AChat;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AChatService: IAChatService
    {
        private readonly IAChatAction _aChatAction;
        private readonly IAChatQuery _aChatQuery;

        public AChatService(IAChatAction aChatAction,
            IAChatQuery aChatQuery)
        {
            _aChatAction = aChatAction;
            _aChatQuery = aChatQuery;
        }

        public async Task<Chatcontent> CreateOneMessage(ForceInfo forceInfo, AChatCreateModel aChatCreateModel)
        {
            var chatRoomId = await _aChatQuery.CheckRoomUser(forceInfo.UserId);

            string deleteDateCreateUser = "";

            if(chatRoomId == 0)
            {
                deleteDateCreateUser = await _aChatQuery.QueryDeleteDateCreateUser(aChatCreateModel.ChatRoomId);
            }

            return await _aChatAction.CreateOneMessage(forceInfo, aChatCreateModel, chatRoomId, 
                String.IsNullOrEmpty(deleteDateCreateUser) ? forceInfo.DateNow : Convert.ToDateTime(deleteDateCreateUser));
        }

        public async Task<ObjectResponse> DeleteOneMessage(ForceInfo forceInfo, ulong chatContentId)
        {
            if (await _aChatQuery.CheckMessageFromUser(chatContentId, forceInfo.UserId) == 0)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Bạn không có quyền xóa tin nhắn này!"
                };
            }

            var chatContent = await _aChatAction.DeleteOneMessage(forceInfo, chatContentId);

            if (chatContent != null)
            {
                return new ObjectResponse
                {
                    result = 1,
                    message = "Xóa tin nhắn thành công"
                };
            }

            return new ObjectResponse
            {
                result = 0,
                message = "Xóa tin nhắn thất bại"
            };
        }

        public async Task DeleteConversation(ForceInfo forceInfo)
        {
            var chatRoomId = await _aChatQuery.CheckRoomUser(forceInfo.UserId);

            await _aChatAction.DeleteConversation(forceInfo, chatRoomId);
        }

        public async Task<List<AChatUserModel>> GetListChatUser(AOSearchChatUser aOSearchChatUser)
        {
            return await _aChatQuery.QueryListChatUser(aOSearchChatUser);
        }

        public async Task<ObjectResponse> GetListChat(ForceInfo forceInfo, AOSearchChatContent aOSearchChatContent)
        {
            var deleteDate = await _aChatQuery.QueryChatDeleteDate(aOSearchChatContent.ChatRoomId, forceInfo.UserId);

            var chatContents = await _aChatQuery.QueryListChat(String.IsNullOrEmpty(deleteDate) ? forceInfo.DateNow : Convert.ToDateTime(deleteDate),
                                                            aOSearchChatContent);

            var ownerId = await _aChatQuery.QueryOwnerChatRoom(aOSearchChatContent.ChatRoomId);

            return new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    OwnerId = ownerId,
                    ChatContents = chatContents
                }
            };
        }
    }
}
