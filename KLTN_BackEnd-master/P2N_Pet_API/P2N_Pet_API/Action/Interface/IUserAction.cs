using Microsoft.AspNetCore.Http;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action.Interface
{
    public interface IUserAction
    {
        Task<User> Register(UserRegisterModel userRegister ,ForceInfo forceInfo);
        Task<User> EditProfile(UserProfileUpdateModel editProfile, ForceInfo forceInfo);
        Task UpdateAvatarUser(ForceInfo forceInfo, CloudOneMediaModel CloudOneMedia);
        Task<CloudOneMediaModel> SaveOneMediaData(IFormFile avatar, ulong userId);
        Task<User> ForgotPassword(UserForgotPasswordModel userForgotPassword, ForceInfo forceInfo);
        Task ChangePassword(string newPassword, ForceInfo forceInfo);

        Task<User> CreateAccountAdmin(UserRegisterModel userRegister, ForceInfo forceInfo);
        Task<User> ForgotPasswordV2(UserForgotPasswordV2Model userForgotPasswordV2, ForceInfo forceInfo);
        void SendMailForgotPassword(User user);


    }
}
