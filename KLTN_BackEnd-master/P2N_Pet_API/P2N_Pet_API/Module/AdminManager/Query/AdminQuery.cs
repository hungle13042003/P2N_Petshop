using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.Admin;
using P2N_Pet_API.Module.AdminManager.Models.Role;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AdminQuery : IAdminQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AdminQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<AdminUserModel> QueryDetailAccountUser(ulong userId)
        {
            var query =
                @"select u.Id, ifnull(u.Name, N'') Name, ifnull(u.Email, '') Email, ifnull(u.Phone, '') Phone, ifnull(u.Password, '') Password,  
                    case 
                      when ifnull(u.avatar, '') != ''
                      then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
                      else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
                    end Avatar, 
                    ifnull(u.Address, N'') Address, r.id RoleId, ifnull(r.Title, N'') RoleName, 
                    u.status Status, ifnull(s.title, '') StatusText
                from users u 
                    left join role r on r.id = u.role
                    left join status s on s.id = u.status
                where r.status = 10 and u.status != 190
                    and u.id = @UserId";

            return await _p2NPetDapper.QuerySingleAsync<AdminUserModel>(query, new
            {
                UserId = userId
            });

        }

        public async Task<List<AdminUserListModel>> QueryListAccountManager(ulong userId, OSearchAdminModel oSearch)
        {
            oSearch.CurrentPage = oSearch.CurrentPage < 0 ? 0 : oSearch.CurrentPage;
            oSearch.CurrentDate = string.IsNullOrEmpty(oSearch.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : oSearch.CurrentDate;

            oSearch.Limit = oSearch.Limit == 0 ? 25 : oSearch.Limit;
            oSearch.Status = oSearch.Status == 0 ? 0 : oSearch.Status;
            oSearch.RoleId = oSearch.RoleId == 0 ? 0 : oSearch.RoleId;

            var condition = "";

            if (!string.IsNullOrEmpty(oSearch.Name))
            {
                condition += @" and u.name like @Name";
            }

            if (!string.IsNullOrEmpty(oSearch.Email))
            {
                condition += @" and u.email like @Email";
            }

            if (!string.IsNullOrEmpty(oSearch.Phone))
            {
                condition += @" and u.phone like @Phone";
            }

            if (oSearch.StatusBlock > 0)
            {
                condition += @" and u.status != @StatusBlock";
            }

            if (oSearch.Status > 0)
            {
                condition += @" and u.status = @Status";
            }

            if (oSearch.RoleId > 0)
            {
                condition += @" and u.role = @RoleId";
            }


            var query =
                @"select u.Id, ifnull(u.Name, N'') Name, ifnull(u.Email, '') Email, ifnull(u.Phone, '') Phone, ifnull(u.Password, '') Password,  
                    case 
                      when ifnull(u.avatar, '') != ''
                      then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
                      else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
                    end Avatar, 
                    ifnull(u.Address, N'') Address, r.id RoleId, ifnull(r.Title, N'') RoleName, 
                    u.status Status, ifnull(s.title, '') StatusText, 
                    cu.Name CreateUserName, u.Createdate, au.Name UpdateUserName, u.UpdateDate
                from users u
					left join users cu on cu.id = u.createuser
                    left join users au on au.id = u.updateuser
                    left join role r on r.id = u.role
                    left join status s on s.id = u.status
                where r.status = 10 and u.status != @StatusIgnore and u.id != @UserId " + condition + @"
                    and u.createdate <= cast( @CurrentDate as datetime)
                order by u.id, u.createdate desc, u.status asc, u.role asc
                limit @offset, @limit";

            return await _p2NPetDapper.QueryAsync<AdminUserListModel>(query, new
            {
                StatusIgnore = 190,
                UserId = userId,
                Name = "%" + oSearch.Name.Trim() + "%",
                Email = "%" + oSearch.Email.Trim() + "%",
                Phone = "%" + oSearch.Phone.Trim() + "%",
                Status = oSearch.Status,
                StatusBlock = oSearch.StatusBlock,
                RoleId = oSearch.RoleId,
                CurrentDate = oSearch.CurrentDate,
                offset = oSearch.CurrentPage * oSearch.Limit,
                limit = oSearch.Limit
            });
        }

        public async Task<int> QueryCountAccountManager(ulong userId, OSearchAdminModel oSearch)
        {
            oSearch.CurrentPage = oSearch.CurrentPage < 0 ? 0 : oSearch.CurrentPage;
            oSearch.CurrentDate = string.IsNullOrEmpty(oSearch.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : oSearch.CurrentDate;

            oSearch.Limit = oSearch.Limit == 0 ? 25 : oSearch.Limit;
            oSearch.Status = oSearch.Status == 0 ? 0 : oSearch.Status;
            oSearch.RoleId = oSearch.RoleId == 0 ? 0 : oSearch.RoleId;

            var condition = "";

            if (!string.IsNullOrEmpty(oSearch.Name))
            {
                condition += @" and u.name like @Name";
            }

            if (!string.IsNullOrEmpty(oSearch.Email))
            {
                condition += @" and u.email like @Email";
            }

            if (!string.IsNullOrEmpty(oSearch.Phone))
            {
                condition += @" and u.phone like @Phone";
            }

            if (oSearch.StatusBlock > 0)
            {
                condition += @" and u.status != @StatusBlock";
            }

            if (oSearch.Status > 0)
            {
                condition += @" and u.status = @Status";
            }

            if (oSearch.RoleId > 0)
            {
                condition += @" and u.role = @RoleId";
            }


            var query =
                @"select count(1) 
                from users u
					left join users cu on cu.id = u.createuser
                    left join users au on au.id = u.updateuser
                    left join role r on r.id = u.role
                    left join status s on s.id = u.status
                where r.status = 10 and u.status != @StatusIgnore and u.id != @UserId " + condition + @"
                    and u.createdate <= cast( @CurrentDate as datetime);";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusIgnore = 190,
                UserId = userId,
                Name = "%" + oSearch.Name.Trim() + "%",
                Email = "%" + oSearch.Email.Trim() + "%",
                Phone = "%" + oSearch.Phone.Trim() + "%",
                Status = oSearch.Status,
                StatusBlock = oSearch.StatusBlock,
                RoleId = oSearch.RoleId,
                CurrentDate = oSearch.CurrentDate
            });
        }

        public async Task<List<RoleSelectionModel>> QueryRoleSelection()
        {
            var query =
                @"select id RoleId, title RoleName
                from role
                where status = 10 and id != 10 
                order by RoleId desc";

            return await _p2NPetDapper.QueryAsync<RoleSelectionModel>(query);
        }
    }
}
