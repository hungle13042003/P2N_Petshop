using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.Admin;
using P2N_Pet_API.Module.AdminManager.Models.Role;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminAction _adminAction;
        private readonly PetShopContext _petShopContext;
        private readonly IAdminQuery _adminQuery;
        private readonly IPaginationService _paginationService;

        public AdminService(IAdminAction adminAction,
            PetShopContext petShopContext,
            IAdminQuery adminQuery,
            IPaginationService paginationService)
        {
            _adminAction = adminAction;
            _petShopContext = petShopContext;
            _adminQuery = adminQuery;
            _paginationService = paginationService;
        }

        public async Task<User> CreateAccountManager(AdminCreateManagerModel adminCreateManager, ForceInfo forceInfo)
        {
            var tran = await _petShopContext.Database.BeginTransactionAsync();

            try
            {
                var register = await _adminAction.CreateAccountManager(adminCreateManager, forceInfo);

                if (register != null && adminCreateManager.Avatar != null)
                {
                    var cloudMedia = await _adminAction.SaveOneMediaData(adminCreateManager.Avatar, register.Id);

                    await _adminAction.CreateOrUpdateAvatarUser(register.Id, forceInfo, cloudMedia);
                }

                await tran.CommitAsync();

                return register;
            }
            catch (Exception e)
            {
                await tran.RollbackAsync();
                return null;
            }
        }

        public async Task<User> DeleteAccount(ForceInfo forceInfo, AdminDeleteModel adminDelete)
        {
            return await _adminAction.DeleteUser(forceInfo, adminDelete.UserId);
        }

        public async Task<User> UpdateAccount(AdminUpdateManagerModel adminUpdateManager, ForceInfo forceInfo)
        {
            var tran = await _petShopContext.Database.BeginTransactionAsync();

            try
            {
                var profileUser = await _adminAction.UpdateAccount(adminUpdateManager, forceInfo);

                if (profileUser != null && adminUpdateManager.Avatar != null)
                {
                    var cloudMedia = await _adminAction.SaveOneMediaData(adminUpdateManager.Avatar, profileUser.Id);

                    await _adminAction.CreateOrUpdateAvatarUser(profileUser.Id, forceInfo, cloudMedia);
                }

                await tran.CommitAsync();

                return profileUser;
            }
            catch (Exception e)
            {
                await tran.RollbackAsync();
                return null;
            }
        }

        public async Task<AdminUserModel> GetDetailAccountUser(ulong userId)
        {
            return await _adminQuery.QueryDetailAccountUser(userId);
        }

        public async Task<List<AdminUserListModel>> GetListAccountUser(ulong userId, OSearchAdminModel oSearch)
        {
            return await _adminQuery.QueryListAccountManager(userId, oSearch);
        }

        public async Task<PaginationModel> GetListAccountUserPagination(ulong userId, OSearchAdminModel oSearch)
        {
            var count = await _adminQuery.QueryCountAccountManager(userId, oSearch);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(oSearch.CurrentPage),
                oSearch.CurrentDate, Convert.ToInt32(oSearch.Limit));

            return pagination;
        }

        public async Task<User> BlockUser(ForceInfo forceInfo, AdminBlockUpdate adminBlock)
        {
            return await _adminAction.BlockUser(forceInfo, adminBlock.UserId);
        }

        public async Task<User> OpenBlockUser(ForceInfo forceInfo, AdminBlockUpdate adminBlock)
        {
            return await _adminAction.OpenBlockUser(forceInfo, adminBlock.UserId);
        }

        public async Task<List<RoleSelectionModel>> GetRoleSelection()
        {
            return await _adminQuery.QueryRoleSelection();
        }
    }
}
