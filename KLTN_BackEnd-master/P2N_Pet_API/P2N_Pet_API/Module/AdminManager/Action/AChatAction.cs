using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AChatAction: IAChatAction
    {
        private readonly PetShopContext _petShopContext;

        public AChatAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Chatcontent> CreateOneMessage(ForceInfo forceInfo, AChatCreateModel aChatCreateModel, ulong chatRoomIdFromUser,
            DateTime deleteDateCreateUser)
        {
            if(chatRoomIdFromUser == 0)
            {
                var chatRoomUser = new Chatroomuser
                {
                    Chatroomid = aChatCreateModel.ChatRoomId,
                    Userid = forceInfo.UserId,
                    Deletedate = deleteDateCreateUser,
                    Status = 10,
                    Createuser = forceInfo.UserId,
                    Createdate = forceInfo.DateNow,
                    Updateuser = forceInfo.UserId,
                    Updatedate = forceInfo.DateNow
                };

                _petShopContext.Chatroomusers.Add(chatRoomUser);
                await _petShopContext.SaveChangesAsync();
            }


            var chatContent = new Chatcontent
            {
                Chatroomid = aChatCreateModel.ChatRoomId,
                Userid = forceInfo.UserId,
                Content = aChatCreateModel.Content.Trim(),
                Isnew = 1,
                Status = 10,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Chatcontents.Add(chatContent);
            await _petShopContext.SaveChangesAsync();

            return chatContent;
        }

        public async Task<Chatcontent> UpdateOneMessage(ForceInfo forceInfo, AChatUpdateModel aChatUpdateModel)
        {
            var chatContent = await _petShopContext.Chatcontents.FirstOrDefaultAsync(a => a.Id == aChatUpdateModel.Id);

            if (chatContent != null)
            {
                chatContent.Content = aChatUpdateModel.Content;
                chatContent.Updateuser = forceInfo.UserId;
                chatContent.Updatedate = forceInfo.DateNow;

                _petShopContext.Chatcontents.Update(chatContent);
                await _petShopContext.SaveChangesAsync();
            }

            return chatContent;
        }

        public async Task<Chatcontent> DeleteOneMessage(ForceInfo forceInfo, ulong chatContentId)
        {
            var chatContent = await _petShopContext.Chatcontents.FirstOrDefaultAsync(a => a.Id == chatContentId);

            if (chatContent != null)
            {
                chatContent.Status = 190;
                chatContent.Updateuser = forceInfo.UserId;
                chatContent.Updatedate = forceInfo.DateNow;

                _petShopContext.Chatcontents.Update(chatContent);
                await _petShopContext.SaveChangesAsync();
            }

            return chatContent;
        }

        public async Task DeleteConversation(ForceInfo forceInfo, ulong chatId)
        {
            var chatRoomUser = await _petShopContext.Chatroomusers.FirstOrDefaultAsync(a => a.Userid == forceInfo.UserId
                                                            && a.Chatroomid == chatId && a.Status == 10);

            if (chatRoomUser != null)
            {
                chatRoomUser.Deletedate = forceInfo.DateNow;
                chatRoomUser.Updateuser = forceInfo.UserId;
                chatRoomUser.Updatedate = forceInfo.DateNow;

                _petShopContext.Chatroomusers.Update(chatRoomUser);
                await _petShopContext.SaveChangesAsync();
            }
        }
    }
}
