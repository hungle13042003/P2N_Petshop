using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AChat;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ManagerAccess]
    public class AChatController : ControllerBase
    {
        private readonly IAChatService _aChatService;
        public AChatController(IAChatService aChatService)
        {
            _aChatService = aChatService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneMessage(AChatCreateModel aChatCreateModel)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var chatContent = await _aChatService.CreateOneMessage(forceInfo, aChatCreateModel);

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
        public async Task<IActionResult> DeleteOneMessage(ulong ChatContentId)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var result = await _aChatService.DeleteOneMessage(forceInfo, ChatContentId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConversation()
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            await _aChatService.DeleteConversation(forceInfo);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Xóa cuộc hội thoại thành công",
            });
        }

        [HttpPost]
        public async Task<IActionResult> GetListChatUser(AOSearchChatUser aOSearchChatUser)
        {
            var chatUsers = await _aChatService.GetListChatUser(aOSearchChatUser);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ChatUsers = chatUsers
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> GetListChat(AOSearchChatContent oSearchChatContent)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var result = await _aChatService.GetListChat(forceInfo, oSearchChatContent);

            return Ok(result);
        }
    }
}
