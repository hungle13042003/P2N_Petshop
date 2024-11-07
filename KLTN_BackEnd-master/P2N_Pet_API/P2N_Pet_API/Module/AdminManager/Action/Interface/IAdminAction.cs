using Microsoft.AspNetCore.Http;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAdminAction
    {
        Task<User> CreateAccountManager(AdminCreateManagerModel adminCreateManager, ForceInfo forceInfo);
        Task CreateOrUpdateAvatarUser(ulong userId, ForceInfo forceInfo, CloudOneMediaModel CloudOneMedia);
        Task<CloudOneMediaModel> SaveOneMediaData(IFormFile avatar, ulong userId);
        Task<User> UpdateAccount(AdminUpdateManagerModel adminUpdateManager, ForceInfo forceInfo);
        Task<User> DeleteUser(ForceInfo forceInfo, ulong userId);
        Task<User> BlockUser(ForceInfo forceInfo, ulong userId);
        Task<User> OpenBlockUser(ForceInfo forceInfo, ulong userId);
    }
}
