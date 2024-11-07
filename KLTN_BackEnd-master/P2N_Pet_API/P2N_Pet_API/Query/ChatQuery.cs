using P2N_Pet_API.Models.Chat;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class ChatQuery : IChatQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ChatQuery(IP2NPetDapper p2NPetDapper)
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
                Status =10, 
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

        public async Task<string> QueryChatDeleteDate(ulong userId)
        {
            var query =
                @"select deletedate 
                from chatroomuser 
                where status = @Status and userid = @UserId ";

            return await _p2NPetDapper.QuerySingleAsync<string>(query, new
            {
                Status = 10,
                UserId = userId
            });
        }

        public async Task<List<ChatContentModel>> QueryListChat(ulong chatRoomId, DateTime deleteDate, OSearchChatContent oSearchChatContent)
        {
            var query =
                @"select cc.Id, cc.UserId, ifnull(cc.content, N'') Content
                from chatcontent cc
	                left join chatroomuser cru on cru.userid = cc.userid 
                where cc.status = @Status and cc.chatroomid = @ChatRoomId and cc.createdate >= @DeleteDate 
                order by cc.createdate desc 
                limit @Offset, @Limit ";

            return await _p2NPetDapper.QueryAsync<ChatContentModel>(query, new
            {
                Status = 10,
                ChatRoomId = chatRoomId,
                DeleteDate = deleteDate,
                Offset = oSearchChatContent.CurrentPage * oSearchChatContent.Limit,
                Limit = oSearchChatContent.Limit 
            });
        }
    }
}
