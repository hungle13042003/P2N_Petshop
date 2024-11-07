using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action
{
    [Obsolete]
    public class UserAction : IUserAction
    {
        private readonly PetShopContext _petShopContext;
        private readonly ICloudMediaService _cloudMediaService;
        private readonly IHostingEnvironment _env;
        private readonly IEmailService _emailService;

        public UserAction(PetShopContext petShopContext,
            ICloudMediaService cloudMediaService,
            IHostingEnvironment env,
            IEmailService emailService)
        {
            _petShopContext = petShopContext;
            _cloudMediaService = cloudMediaService;
            _env = env;
            _emailService = emailService;
        }

        public async Task<User> Register(UserRegisterModel userRegister, ForceInfo forceInfo)
        {
            var user = new User
            {
                Name = userRegister.Name.Trim(),
                Email = userRegister.Email.Trim(),
                Phone = userRegister.Phone.Trim(),
                Password = Encryptor.MD5Hash(userRegister.Password.Trim()),
                Address = userRegister.Address.Trim(),
                Status = 10,
                Role = 30,
                Createdate = forceInfo.DateNow,
                Updatedate = forceInfo.DateNow,
            };

            _petShopContext.Users.Add(user);
            await _petShopContext.SaveChangesAsync();

            user.Createuser = user.Id;
            user.Updateuser = user.Id;

            _petShopContext.Users.Update(user);
            await _petShopContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> EditProfile(UserProfileUpdateModel editProfile, ForceInfo forceInfo)
        {
            var userInfo = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == forceInfo.UserId &&
                    a.Status == 10 &&
                    a.Email == editProfile.Email);

            if (userInfo != null)
            {
                userInfo.Name = editProfile.Name.Trim();
                //userInfo.Email = editProfile.Email.Trim();
                userInfo.Phone = editProfile.Phone.Trim();
                userInfo.Address = editProfile.Address.Trim();

                userInfo.Updatedate = forceInfo.DateNow;
                userInfo.Updateuser = forceInfo.UserId;

                _petShopContext.Users.Update(userInfo);
                await _petShopContext.SaveChangesAsync();
            }

            return userInfo;
        }

        public async Task UpdateAvatarUser(ForceInfo forceInfo, CloudOneMediaModel CloudOneMedia)
        {
            var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == forceInfo.UserId);

            if(user != null)
            {
                user.Avatar = CloudOneMedia.FileName;
                user.Updateuser = forceInfo.UserId;
                user.Updatedate = forceInfo.DateNow;

                _petShopContext.Users.Update(user);
                await _petShopContext.SaveChangesAsync();
            }
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

        public async Task<User> ForgotPassword(UserForgotPasswordModel userForgotPassword, ForceInfo forceInfo)
        {
            var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Email == userForgotPassword.Email);

            if (user != null)
            {
                user.Password = Encryptor.MD5Hash(userForgotPassword.Password.Trim());

                user.Updateuser = user.Id;
                user.Updatedate = forceInfo.DateNow;

                _petShopContext.Users.Update(user);
                await _petShopContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task ChangePassword(string newPassword, ForceInfo forceInfo)
        {
            var user = _petShopContext.Users.Where(a => a.Id == forceInfo.UserId && a.Status == 10).FirstOrDefault();

            if(user != null)
            {
                user.Password = Encryptor.MD5Hash(newPassword.Trim());

                user.Updateuser = forceInfo.UserId;
                user.Updatedate = forceInfo.DateNow;

                _petShopContext.Users.Update(user);
                await _petShopContext.SaveChangesAsync();
            }
        }

        public async Task<User> CreateAccountAdmin(UserRegisterModel userRegister, ForceInfo forceInfo)
        {
            var user = new User
            {
                Name = userRegister.Name.Trim(),
                Email = userRegister.Email.Trim(),
                Phone = userRegister.Phone.Trim(),
                Password = Encryptor.MD5Hash(userRegister.Password.Trim()),
                Address = userRegister.Address.Trim(),
                Status = 10,
                Role = 10,
                Createdate = forceInfo.DateNow,
                Updatedate = forceInfo.DateNow,
            };

            _petShopContext.Users.Add(user);
            await _petShopContext.SaveChangesAsync();

            user.Createuser = user.Id;
            user.Updateuser = user.Id;

            _petShopContext.Users.Update(user);
            await _petShopContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> ForgotPasswordV2(UserForgotPasswordV2Model userForgotPasswordV2, ForceInfo forceInfo)
        {
            var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Email == userForgotPasswordV2.Email && a.Status == 10);

            if (user != null)
            {

                user.Password = Encryptor.MD5Hash(userForgotPasswordV2.Password.Trim());

                user.Updateuser = user.Id;
                user.Updatedate = forceInfo.DateNow;

                _petShopContext.Users.Update(user);
                await _petShopContext.SaveChangesAsync();
            }

            return user;
        }

        public void SendMailForgotPassword(User user)
        {
            string content = "";
            string subject = "P2N Pet - Quên Mật khẩu";

            var absoPath = Path.Combine("wwwroot", "Assets", "Template", "Email", "ForgotPasswordForm.html");
            var pathTemp = Path.Combine(_env.ContentRootPath, absoPath);

            content = File.ReadAllText(pathTemp);

            content = content.Replace("{{name}}", user.Name);
            content = content.Replace("{{email}}", user.Email);
            content = content.Replace("{{password}}", user.Password);

            _emailService.Send(user.Email, subject, content);
        }
    }
}
