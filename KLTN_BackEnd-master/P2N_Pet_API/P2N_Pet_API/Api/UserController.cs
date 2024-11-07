using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UserAccess]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> EditProfile([FromForm]UserProfileUpdateModel userProfile)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var existed = await _userService.CheckExistIsMeAndNotMePhone(userProfile.Phone, forceInfo.UserId);

            if (existed != null)
            {
                return Ok(existed);
            }

            try
            {
                var profile = await _userService.EditProfile(userProfile, forceInfo);

                if(profile == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Cập nhật thông tin thất bại. Vui lòng thử lại."
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Cập nhật thông tin thành công",
                    content = new
                    {
                        user = profile
                    }
                });
            }
            catch(Exception e)
            {

                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordModel userChangePassword)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            if(userChangePassword.RepeatNewPassword != userChangePassword.NewPassword)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Nhắc lại mật khẩu mới không chính xác",
                    
                });
            }

            var objectResponse = await _userService.ChangePassword(userChangePassword, forceInfo);

            return Ok(objectResponse);

        }

        [HttpPost]
        public async Task<IActionResult> GetDetailUser()
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var profile = await _userService.GetUserDetail(forceInfo.UserId);

            return Ok(new ObjectResponse 
            {
                result = 1,
                message = "Lấy thông tin user thành công",
                content = new
                {
                    user = profile
                }
            });
        }
    }
}
