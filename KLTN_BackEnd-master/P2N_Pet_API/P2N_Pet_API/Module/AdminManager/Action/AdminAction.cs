using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.Admin;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AdminAction : IAdminAction
    {
        private readonly PetShopContext _petShopContext;
        private readonly ICloudMediaService _cloudMediaService;

        public AdminAction(PetShopContext petShopContext,
            ICloudMediaService cloudMediaService)
        {
            _petShopContext = petShopContext;
            _cloudMediaService = cloudMediaService;
        }

        public async Task<User> CreateAccountManager(AdminCreateManagerModel adminCreateManager, ForceInfo forceInfo)
        {
            var manager = new User()
            {
                Name = adminCreateManager.Name.Trim(),
                Email = adminCreateManager.Email.Trim(),
                Phone = adminCreateManager.Phone.Trim(),
                Password = Encryptor.MD5Hash(adminCreateManager.Password.Trim()),
                Address = adminCreateManager.Address.Trim(),
                Status = adminCreateManager.Status <= 0 ? 10 : adminCreateManager.Status,
                Role = adminCreateManager.RoleId <= 0 ? 30 : adminCreateManager.RoleId,
                Createdate = forceInfo.DateNow,
                Createuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId
            };

            _petShopContext.Users.Add(manager);
            await _petShopContext.SaveChangesAsync();

            return manager;
        }

        public async Task CreateOrUpdateAvatarUser(ulong userId,ForceInfo forceInfo, CloudOneMediaModel CloudOneMedia)
        {
            var manager = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == userId);

            if (manager != null)
            {
                manager.Avatar = CloudOneMedia.FileName;
                manager.Updateuser = forceInfo.UserId;
                manager.Updatedate = forceInfo.DateNow;

                _petShopContext.Users.Update(manager);
                await _petShopContext.SaveChangesAsync();
            }
        }

        public async Task<User> DeleteUser(ForceInfo forceInfo, ulong userId)
        {
            var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == userId && a.Status != 190);

            if( user != null)
            {
                user.Status = 190;
                user.Updatedate = forceInfo.DateNow;
                user.Updateuser = forceInfo.UserId;

                _petShopContext.Users.Update(user);
                await _petShopContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task<CloudOneMediaModel> SaveOneMediaData(IFormFile avatar, ulong userId)
        {
            var cloudOneMediaConfig = new CloudOneMediaConfig
            {
                Folder = "Upload/Avatar/Avatar_" + userId,
                FileName = "Image_Avatar",
                FormFile = avatar
            };

            return await _cloudMediaService.SaveOneFileData(cloudOneMediaConfig);
        }

        public async Task<User> UpdateAccount(AdminUpdateManagerModel adminUpdateManager, ForceInfo forceInfo)
        {
            var account = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == adminUpdateManager.ManagerId &&
                                            a.Status != 190);

            if(account != null)
            {
                account.Name = string.IsNullOrEmpty(adminUpdateManager.Name) ? account.Name : adminUpdateManager.Name.Trim();
                account.Email = string.IsNullOrEmpty(adminUpdateManager.Email) ? account.Email : adminUpdateManager.Email.Trim();
                account.Phone = string.IsNullOrEmpty(adminUpdateManager.Phone) ? account.Phone : adminUpdateManager.Phone.Trim();
                account.Password = string.IsNullOrEmpty(adminUpdateManager.Password) ? account.Password :Encryptor.MD5Hash(adminUpdateManager.Password.Trim());
                account.Address = string.IsNullOrEmpty(adminUpdateManager.Address) ? account.Address : adminUpdateManager.Address.Trim();
                account.Status = adminUpdateManager.Status <= 0 ? 10 : adminUpdateManager.Status;
                account.Role = adminUpdateManager.RoleId <= 0 ? 30 : adminUpdateManager.RoleId;
                account.Updatedate = forceInfo.DateNow;
                account.Updateuser = forceInfo.UserId;
            }

            _petShopContext.Users.Update(account);
            await _petShopContext.SaveChangesAsync();

            return account;
        }

        public async Task<User> BlockUser(ForceInfo forceInfo, ulong userId)
        {
            var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == userId &&
                                    a.Status != 190 && a.Status != 50);

            if (user != null)
            {
                user.Status = 50;
                user.Updatedate = forceInfo.DateNow;
                user.Updateuser = forceInfo.UserId;

                _petShopContext.Users.Update(user);
                await _petShopContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task<User> OpenBlockUser(ForceInfo forceInfo, ulong userId)
        {
            var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == userId && a.Status == 50);

            if (user != null)
            {
                user.Status = 10;
                user.Updatedate = forceInfo.DateNow;
                user.Updateuser = forceInfo.UserId;

                _petShopContext.Users.Update(user);
                await _petShopContext.SaveChangesAsync();
            }

            return user;
        }

    }
}
