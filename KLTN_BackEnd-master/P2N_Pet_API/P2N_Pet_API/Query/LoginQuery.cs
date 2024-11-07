using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models.Login;

namespace P2N_Pet_API.Query
{
    public class LoginQuery : ILoginQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public LoginQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<LoginSuccessModel> Login(string email, string password)
        {
            var query =
                @"select u.Id, ifnull(u.Name, N'') Name, ifnull(u.Email, '') Email, ifnull(u.Phone, '') Phone, ifnull(u.Password, '') Password,  
                    case 
                      when ifnull(u.avatar, '') != ''
                      then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
                      else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
                    end Avatar, 
                    ifnull(u.Address, N'') Address, ifnull(u.role, 0) Role, ifnull(r.Title, N'') RoleName   
                from users u 
                    left join role r on r.id = u.role
                where u.status = @Status and r.status = @Status and 
                        (u.email = @Email 
                        or 
                        u.phone = @Email
                    ) 
                    and u.password = @Password";

            return await _p2NPetDapper.QuerySingleAsync<LoginSuccessModel>(query, new
            {
                Status = 10,
                Email = email.Trim(),
                Password = password.Trim()
            });
        }
    }
}
