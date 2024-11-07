using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Chat;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class ChatService : IChatService
    {
        private readonly IChatAction _chatAction;
        private readonly IChatQuery _chatQuery;

        public ChatService(IChatAction chatAction,
            IChatQuery chatQuery)
        {
            _chatAction = chatAction;
            _chatQuery = chatQuery;
        }

        public async Task<Chatcontent> CreateOneMessage(ForceInfo forceInfo, ChatCreateModel chatCreateModel)
        {
            var chatRoomId = await _chatQuery.CheckRoomUser(forceInfo.UserId);

            return await _chatAction.CreateOneMessage(chatRoomId, forceInfo, chatCreateModel);
        }

        public async Task<ObjectResponse> UpdateOneMessage(ForceInfo forceInfo, ChatUpdateModel chatUpdateModel)
        {
            if(await _chatQuery.CheckMessageFromUser(chatUpdateModel.Id, forceInfo.UserId) == 0)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Bạn không có quyền cập nhật tin nhắn này!"
                };
            }

            var chatContent = await _chatAction.UpdateOneMessage(forceInfo, chatUpdateModel);

            return new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ChatContent = chatContent
                }
            };
        }

        public async Task<ObjectResponse> DeleteOneMessage(ForceInfo forceInfo, ulong chatId)
        {
            if (await _chatQuery.CheckMessageFromUser(chatId, forceInfo.UserId) == 0)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Bạn không có quyền xóa tin nhắn này!"
                };
            }

            var chatContent = await _chatAction.DeleteOneMessage(forceInfo, chatId);

            if(chatContent != null)
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

        public async Task<List<ChatContentModel>> GetListChat(ForceInfo forceInfo, OSearchChatContent oSearchChatContent)
        {
            var deleteDate = await _chatQuery.QueryChatDeleteDate(forceInfo.UserId);

            var chatRoomId = await _chatQuery.CheckRoomUser(forceInfo.UserId);

            var chatContents = await _chatQuery.QueryListChat(chatRoomId, String.IsNullOrEmpty(deleteDate) ? forceInfo.DateNow : Convert.ToDateTime(deleteDate),
                                                            oSearchChatContent);

            return chatContents;
        }

        public async Task DeleteConversation(ForceInfo forceInfo)
        {
            var chatRoomId = await _chatQuery.CheckRoomUser(forceInfo.UserId);

            await _chatAction.DeleteConversation(forceInfo, chatRoomId);
        }
    }
}
