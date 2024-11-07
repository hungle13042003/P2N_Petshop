using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AChat;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AChatQuery : IAChatQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AChatQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<int> CheckMessageFromUser(ulong chatId, ulong userId)
        {
            var query =
                @"select count(1) 
                from chatcontent 
                where status = @Status and id = @ChatId and userid = @UserId ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Status = 10,
                ChatId = chatId,
                UserId = userId
            });
        }

        public async Task<ulong> CheckRoomUser(ulong userId)
        {
            var query =
                @"select chatroomid 
                from chatroomuser 
                where status = @Status and userid = @UserId ";

            return await _p2NPetDapper.QuerySingleAsync<ulong>(query, new
            {
                Status = 10,
                UserId = userId
            });
        }

        public async Task<string> QueryDeleteDateCreateUser(ulong chatRoomId)
        {
            var query =
                @"select cru.deletedate
                from chatroom cr 
	                left join chatroomuser cru on cru.chatroomid = cr.id 
                where cr.createuser = cru.userid and cr.status = @Status and cru.status = @Status and cr.id = @ChatRoomId ";

            return await _p2NPetDapper.QuerySingleAsync<string>(query, new
            {
                Status = 10,
                ChatRoomId = chatRoomId
            });
        }

        public async Task<List<AChatUserModel>> QueryListChatUser(AOSearchChatUser aOSearchChatUser)
        {
            var query =
                @"select cr.id ChatRoomId, 
                    case 
                      when ifnull(u.avatar, '') != ''
                      then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
                      else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
                    end Avatar, u.Name, crr.DateAction
                from chatroom cr 
	                inner join (select chatroomid, max(createdate) dateaction
				                from chatcontent
				                where status = @Status  
				                group by chatroomid
				                order by dateaction desc 
				                limit @OffSet, @Limit) crr
	                on crr.chatroomid = cr.id 
                    left join users u on u.id = cr.createuser 
                where cr.status = @Status and u.status = @Status  
                order by crr.dateaction desc";

            return await _p2NPetDapper.QueryAsync<AChatUserModel>(query, new
            {
                Status = 10,
                OffSet = aOSearchChatUser.CurrentPage * aOSearchChatUser.Limit,
                Limit = aOSearchChatUser.Limit
            });
        }

        public async Task<string> QueryChatDeleteDate(ulong chatRoomId, ulong userId)
        {
            var query =
                @"select deletedate 
                from chatroomuser 
                where status = @Status and userid = @UserId and chatroomid = @ChatRoomId ";

            return await _p2NPetDapper.QuerySingleAsync<string>(query, new
            {
                Status = 10,
                UserId = userId,
                ChatRoomId = chatRoomId
            });
        }

        public async Task<List<AChatContentModel>> QueryListChat(DateTime deleteDate, AOSearchChatContent aOSearchChatContent)
        {
            var query =
                @"select cc.Id, cc.UserId, ifnull(cc.content, N'') Content
                from chatcontent cc
	                left join chatroomuser cru on cru.userid = cc.userid 
                where cc.status = @Status and cc.chatroomid = @ChatRoomId and cc.createdate >= @DeleteDate 
                order by cc.createdate desc 
                limit @Offset, @Limit ";

            return await _p2NPetDapper.QueryAsync<AChatContentModel>(query, new
            {
                Status = 10,
                ChatRoomId = aOSearchChatContent.ChatRoomId,
                DeleteDate = deleteDate,
                Offset = aOSearchChatContent.CurrentPage * aOSearchChatContent.Limit,
                Limit = aOSearchChatContent.Limit
            });
        }

        public async Task<ulong> QueryOwnerChatRoom(ulong chatRoomId)
        {
            var query =
                @"select createuser 
                from chatroom 
                where status = @Status and id = @ChatRoomId ";

            return await _p2NPetDapper.QuerySingleAsync<ulong>(query, new
            {
                Status = 10,
                ChatRoomId = chatRoomId
            });
        }
    }
}