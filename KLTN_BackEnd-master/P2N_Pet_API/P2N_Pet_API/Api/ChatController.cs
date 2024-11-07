using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.Chat;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UserAccess]

    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneMessage(ChatCreateModel chatCreateModel)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var chatContent = await _chatService.CreateOneMessage(forceInfo, chatCreateModel);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ChatContent = chatContent
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOneMessage(ChatUpdateModel chatUpdateModel)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var result = await _chatService.UpdateOneMessage(forceInfo, chatUpdateModel);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOneMessage(ulong ChatContentId)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var result = await _chatService.DeleteOneMessage(forceInfo, ChatContentId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetListChat(OSearchChatContent oSearchChatContent)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var chats = await _chatService.GetListChat(forceInfo, oSearchChatContent);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Chats = chats
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConversation()
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            await _chatService.DeleteConversation(forceInfo);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Xóa cuộc hội thoại thành công",
            });
        }
    }
}
