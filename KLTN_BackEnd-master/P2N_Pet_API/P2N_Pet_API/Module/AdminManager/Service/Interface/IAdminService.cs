using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.Admin;
using P2N_Pet_API.Module.AdminManager.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAdminService
    {
        Task<User> CreateAccountManager(AdminCreateManagerModel adminCreateManager, ForceInfo forceInfo);
        Task<User> UpdateAccount(AdminUpdateManagerModel adminUpdateManager, ForceInfo forceInfo);
        Task<User> DeleteAccount(ForceInfo forceInfo, AdminDeleteModel adminDelete);
        Task<List<AdminUserListModel>> GetListAccountUser(ulong userId, OSearchAdminModel oSearch);
        Task<PaginationModel> GetListAccountUserPagination(ulong userId, OSearchAdminModel oSearch);
        Task<AdminUserModel> GetDetailAccountUser(ulong userId);
        Task<User> BlockUser(ForceInfo forceInfo, AdminBlockUpdate adminBlock);
        Task<User> OpenBlockUser(ForceInfo forceInfo, AdminBlockUpdate adminBlock);
        Task<List<RoleSelectionModel>> GetRoleSelection();
    }
}
