using P2N_Pet_API.Module.AdminManager.Models.Admin;
using P2N_Pet_API.Module.AdminManager.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAdminQuery
    {
        Task<List<AdminUserListModel>> QueryListAccountManager(ulong userId, OSearchAdminModel oSearch);
        Task<int> QueryCountAccountManager(ulong userId, OSearchAdminModel oSearch);
        Task<AdminUserModel> QueryDetailAccountUser(ulong userId);
        Task<List<RoleSelectionModel>> QueryRoleSelection();
    }
}
