using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class UserQuery : IUserQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public UserQuery (IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<bool> CheckUserExisted(UserRegisterModel userRegister)
        {
             var query =
                @"select count(1) 
                from users 
                where status = 10 and (phone like '" + userRegister.Phone.Trim() + @"' 
                    or email like '" + userRegister.Email.Trim() + @"')";

            return (await _p2NPetDapper.QuerySingleAsync<int>(query) > 0) ? true : false;
        }

        public async Task<UserModel> QueryUserDetail(ulong userId)
        {
            var query =
                @"select u.Id, ifnull(u.Name, N'') Name, ifnull(u.Email, '') Email, ifnull(u.Phone, '') Phone, ifnull(u.Password, '') Password,  
                    case 
                      when ifnull(u.avatar, '') != ''
                      then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
                      else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
                    end Avatar, 
                    ifnull(u.Address, N'') Address, r.id RoleId, ifnull(r.Title, N'') RoleName,
                    u.status Status, s.title StatusText, u.password Password
                from users u 
                    left join role r on r.id = u.role
                    left join status s on s.id = u.status
                where u.status = 10 and r.status = 10
                    and u.id = @UserId";

            return await _p2NPetDapper.QuerySingleAsync<UserModel>(query, new 
            {
                UserId = userId
            });
        }

        public async Task<(int, int)> CheckUserIsItMeAndExistsDifference(ulong userId, UserRegisterModel userRegister)
        {
            var queryIsMe =
                @"select count(1)
                from users
                where id = @Id and email like @Email and phone like @Phone and status = 10";

            var isMe = await _p2NPetDapper.QuerySingleAsync<int>(queryIsMe, new
            {
                Id = userId,
                Email = userRegister.Email,
                Phone = userRegister.Phone
            });

            var queryIsExist =
                @"select count(1)
                from users
                where id != @Id and ( email like @Email or phone like @Phone ) and status = 10";

            var isExistNotMe = await _p2NPetDapper.QuerySingleAsync<int>(queryIsExist, new
            {
                Id = userId,
                Email = userRegister.Email,
                Phone = userRegister.Phone
            });

            return (isMe, isExistNotMe);
        }

        public async Task<(int, int)> CheckUserIsItMeAndExistsDifferencePhone(ulong userId, string phone)
        {
            var queryIsMe =
                @"select count(1)
                from users
                where id = @Id and phone like @Phone and status = 10";

            var isMe = await _p2NPetDapper.QuerySingleAsync<int>(queryIsMe, new
            {
                Id = userId,
                Phone = phone
            });

            var queryIsExist =
                @"select count(1)
                from users
                where id != @Id and phone like @Phone and status = 10";

            var isExistNotMe = await _p2NPetDapper.QuerySingleAsync<int>(queryIsExist, new
            {
                Id = userId,
                Phone = phone
            });

            return (isMe, isExistNotMe);
        }

    }
}
