using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface IUserService
    {
        Task<User> Register(UserRegisterModel userRegister, ForceInfo forceInfo);
        Task<UserModel> EditProfile(UserProfileUpdateModel editProfile, ForceInfo forceInfo);
        Task<ObjectResponse> ForgotPassword(UserForgotPasswordModel userForgotPassword, ForceInfo forceInfo);
        Task<ObjectResponse> CheckValidRegister(UserRegisterModel userRegister);
        Task<ObjectResponse> CheckEmailPhoneExisted(UserRegisterModel userRegister);
        Task<ObjectResponse> ChangePassword(UserChangePasswordModel userChangePassword, ForceInfo forceInfo);

        Task<UserModel> GetUserDetail(ulong userId);
        Task<User> CreateAccountAdmin(UserRegisterModel userRegister, ForceInfo forceInfo);
        Task<ObjectResponse> CheckExistIsMeAndNotMe(UserRegisterModel userRegister, ulong userId);
        Task<ObjectResponse> CheckExistIsMeAndNotMePhone(string phone, ulong userId);
        Task<ObjectResponse> ForgotPasswordV2(UserForgotPasswordV2Model userForgotPasswordV2, ForceInfo forceInfo);
    }
}
