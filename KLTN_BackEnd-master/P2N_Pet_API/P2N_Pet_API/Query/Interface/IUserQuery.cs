using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface IUserQuery
    {
        Task<bool> CheckUserExisted(UserRegisterModel userRegister);
        Task<UserModel> QueryUserDetail(ulong userId);

        Task<(int, int)> CheckUserIsItMeAndExistsDifference(ulong userId, UserRegisterModel userRegister);
        Task<(int, int)> CheckUserIsItMeAndExistsDifferencePhone(ulong userId, string phone);
    }
}
