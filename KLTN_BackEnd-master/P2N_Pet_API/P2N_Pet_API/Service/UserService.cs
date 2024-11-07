using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserAction _userAction;
        private readonly IUserQuery _userQuery;
        private readonly PetShopContext _petShopContext;

        public UserService(IUserAction userAction,
            IUserQuery userQuery,
            PetShopContext petShopContext)
        {
            _userAction = userAction;
            _userQuery = userQuery;
            _petShopContext = petShopContext;
        }

        public async Task<UserModel> EditProfile(UserProfileUpdateModel editProfile, ForceInfo forceInfo)
        {
            var tran = await _petShopContext.Database.BeginTransactionAsync();

            try
            {
                var profile = await _userAction.EditProfile(editProfile, forceInfo);

                if(profile == null)
                {
                    return null;
                }

                if (profile != null && editProfile.Avatar != null)
                {
                    var cloudMedia = await _userAction.SaveOneMediaData(editProfile.Avatar, profile.Id);

                    await _userAction.UpdateAvatarUser(forceInfo, cloudMedia);
                }

                await tran.CommitAsync();

                var profileUser = await GetUserDetail(profile.Id);

                return profileUser;
            }
            catch (Exception e)
            {
                await tran.RollbackAsync();
                return null;
            }

        }

        public async Task<User> Register(UserRegisterModel userRegister, ForceInfo forceInfo)
        {
            var tran = await _petShopContext.Database.BeginTransactionAsync();

            try
            {
                var register = await _userAction.Register(userRegister, forceInfo);

                if (register != null && userRegister.Avatar != null)
                {
                    forceInfo.UserId = register.Id;
                    var cloudMedia = await _userAction.SaveOneMediaData(userRegister.Avatar, register.Id);

                    await _userAction.UpdateAvatarUser(forceInfo, cloudMedia);
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

        public async Task<ObjectResponse> CheckValidRegister(UserRegisterModel userRegister)
        {
            if ((String.IsNullOrEmpty(userRegister.Email) && String.IsNullOrEmpty(userRegister.Phone)) ||
                String.IsNullOrEmpty(userRegister.Name) || String.IsNullOrEmpty(userRegister.Password))
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập đầy đủ thông tin"
                };
            }

            //if (userRegister.Password.Trim().Length < 6 || !userRegister.Password.Trim().Any(char.IsNumber) ||
            //    !userRegister.Password.Trim().Any(char.IsUpper))
            //{
            //    return new ObjectResponse
            //    {
            //        result = 0,
            //        message = "Mật khẩu phải bao gồm ít nhất 1 chữ viết hoa, 1 chữ số và từ 6 ký tự trở lên.",
            //    };
            //}

            if (userRegister.Name.Trim().Length > 30)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Họ và tên chỉ có độ dài dưới 30 ký tự."
                };
            }

            if (!userRegister.Password.Equals(userRegister.RepeatPassword))
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Mật khẩu và nhập lại mật khẩu không trùng khớp"
                };
            }

            //if( CheckSpecialCharacters(userRegister.Password.Trim()) || CheckSpecialCharacters(userRegister.RepeatPassword.Trim()))
            //{
            //    return new ObjectResponse
            //    {
            //        result = 0,
            //        message = "Password hoặc RepeatPassword có chứa ký tự đặc biệt"
            //    };
            //}

            var exists = await _userQuery.CheckUserExisted(userRegister);

            if (exists)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Email hoặc số điện thoại đã được sử dụng. Vui lòng nhập lại!"
                };
            }

            return null;
        }


        public bool CheckSpecialCharacters(string str)
        {
            var specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            foreach (var c in specialChar)
            {
                if (str.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<UserModel> GetUserDetail(ulong userId)
        {
            return await _userQuery.QueryUserDetail(userId);
        }

        public async Task<ObjectResponse> ForgotPassword(UserForgotPasswordModel userForgotPassword, ForceInfo forceInfo)
        {
            if (string.IsNullOrEmpty(userForgotPassword.Email.Trim()))
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập email"
                };
            }

            if (!userForgotPassword.Password.Trim().Equals(userForgotPassword.RepeatPassword.Trim()))
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Password và RepeatPassword không trùng khớp. Vui lòng thử lại."
                };
            }

            var fpwd = await _userAction.ForgotPassword(userForgotPassword, forceInfo);

            if (fpwd == null)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Thay đổi password thất bại. Vui lòng thử lại."
                };
            }

            return new ObjectResponse
            {
                result = 1,
                message = "Thay đổi password thành công."
            };
        }

        public async Task<ObjectResponse> ChangePassword(UserChangePasswordModel userChangePassword, ForceInfo forceInfo)
        {
            try
            {
                var oldPass = Encryptor.MD5Hash(userChangePassword.OldPassword);

                //var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == forceInfo.UserId &&
                //                       a.Password == oldPass &&
                //                       a.Status == 10);

                var user = _petShopContext.Users.Where(a => a.Id == forceInfo.UserId && a.Status == 10).FirstOrDefault();

                if (user != null && user.Password == oldPass)
                {
                    await _userAction.ChangePassword(userChangePassword.NewPassword.Trim(), forceInfo);

                    var profile = await _userQuery.QueryUserDetail(forceInfo.UserId);

                    return new ObjectResponse
                    {
                        result = 1,
                        message = "Thay đổi mật khẩu thành công.",
                        content = new
                        {
                            profile
                        }
                    };
                }
                else
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Mật khẩu cũ không chính xác. Vui lòng thử lại."
                    };
                }
            }
            catch (Exception e)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Đã có lỗi xảy ra. Vui lòng thử lại.",
                    content = e.Message.ToString(),
                };
            }
        }

        public async Task<User> CreateAccountAdmin(UserRegisterModel userRegister, ForceInfo forceInfo)
        {
            var tran = await _petShopContext.Database.BeginTransactionAsync();

            try
            {
                var register = await _userAction.CreateAccountAdmin(userRegister, forceInfo);

                if (register != null && userRegister.Avatar != null)
                {
                    forceInfo.UserId = register.Id;
                    var cloudMedia = await _userAction.SaveOneMediaData(userRegister.Avatar, register.Id);

                    await _userAction.UpdateAvatarUser(forceInfo, cloudMedia);
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

        public async Task<ObjectResponse> CheckEmailPhoneExisted(UserRegisterModel userRegister)
        {
            var exists = await _userQuery.CheckUserExisted(userRegister);

            if (exists)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Email hoặc số điện thoại đã được sử dụng. Vui lòng nhập lại!"
                };
            }

            return null;
        }

        public async Task<ObjectResponse> CheckExistIsMeAndNotMe(UserRegisterModel userRegister, ulong userId)
        {
            var isCheck = await _userQuery.CheckUserIsItMeAndExistsDifference(userId, userRegister);

            if(isCheck.Item2 > 0 && isCheck.Item1 == 0)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Email hoặc số điện thoại đã được sử dụng. Vui lòng nhập lại!"
                };
            }

            return null;
        }

        public async Task<ObjectResponse> CheckExistIsMeAndNotMePhone(string phone, ulong userId)
        {
            var isCheck = await _userQuery.CheckUserIsItMeAndExistsDifferencePhone(userId, phone);

            if (isCheck.Item2 > 0 && isCheck.Item1 == 0)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Số điện thoại đã được sử dụng. Vui lòng nhập lại!"
                };
            }

            return null;
        }

        private string RandomPassword(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890|!#$%&/()=?@{}.-;'<>_,";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public async Task<ObjectResponse> ForgotPasswordV2(UserForgotPasswordV2Model userForgotPasswordV2, ForceInfo forceInfo)
        {
            var passwordRandom = RandomPassword(8);

            userForgotPasswordV2.Password = passwordRandom;

            var forgotEntity = await _userAction.ForgotPasswordV2(userForgotPasswordV2, forceInfo);

            if(forgotEntity != null)
            {
                forgotEntity.Password = passwordRandom;
                _userAction.SendMailForgotPassword(forgotEntity);

                return new ObjectResponse
                {
                    result = 1,
                    message = "Vui lòng kiểm tra Email để đăng nhập"
                };
            }

            return new ObjectResponse
            {
                result = 0,
                message = "Thất bại"
            };
        }
    }
}
