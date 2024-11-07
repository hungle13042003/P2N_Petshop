using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Chat;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action
{
    public class ChatAction : IChatAction
    {
        private readonly PetShopContext _petShopContext;
        public ChatAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Chatcontent> CreateOneMessage(ulong chatRoomId, ForceInfo forceInfo, ChatCreateModel chatCreateModel)
        {
            if(chatRoomId == 0)
            {
                var chatRoom = new Chatroom
                {
                    Numchatnewcustomer = 0,
                    Numchatnewmanager = 0,
                    Status = 10,
                    Createuser = forceInfo.UserId,
                    Createdate = forceInfo.DateNow,
                    Updateuser = forceInfo.UserId,
                    Updatedate = forceInfo.DateNow
                };

                _petShopContext.Chatrooms.Add(chatRoom);
                await _petShopContext.SaveChangesAsync();

                var chatRoomUser = new Chatroomuser
                {
                    Chatroomid = chatRoom.Id,
                    Userid = forceInfo.UserId,
                    Deletedate = forceInfo.DateNow,
                    Status = 10,
                    Createuser = forceInfo.UserId,
                    Createdate = forceInfo.DateNow,
                    Updateuser = forceInfo.UserId,
                    Updatedate = forceInfo.DateNow
                };

                _petShopContext.Chatroomusers.Add(chatRoomUser);
                await _petShopContext.SaveChangesAsync();

                chatRoomId = chatRoom.Id;
            }

            var chatContent = new Chatcontent
            {
                Chatroomid = chatRoomId,
                Userid = forceInfo.UserId,
                Content = chatCreateModel.Content.Trim(),
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

        public async Task<Chatcontent> UpdateOneMessage(ForceInfo forceInfo, ChatUpdateModel chatUpdateModel)
        {
            var chatContent = await _petShopContext.Chatcontents.FirstOrDefaultAsync(a => a.Id == chatUpdateModel.Id);

            if(chatContent != null)
            {
                chatContent.Content = chatUpdateModel.Content;
                chatContent.Updateuser = forceInfo.UserId;
                chatContent.Updatedate = forceInfo.DateNow;

                _petShopContext.Chatcontents.Update(chatContent);
                await _petShopContext.SaveChangesAsync();
            }

            return chatContent;
        }

        public async Task<Chatcontent> DeleteOneMessage(ForceInfo forceInfo, ulong chatId)
        {
            var chatContent = await _petShopContext.Chatcontents.FirstOrDefaultAsync(a => a.Id == chatId);

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

            if(chatRoomUser != null)
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
