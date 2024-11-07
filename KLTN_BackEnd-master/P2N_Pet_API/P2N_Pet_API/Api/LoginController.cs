using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models.Login;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public LoginController(ILoginService loginService,
            IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel login)
        {
            var result = await _loginService.Login(login);

            if (!string.IsNullOrEmpty(result.Item1))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = result.Item1,
                });
            }
            
            if(result.Item2 == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Tài khoản không tồn tại hoặc bị khoá",
                });
            }

            var token = _loginService.GenerateTokenByUser(result.Item2);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Đăng nhập thành công.",
                content = new
                {
                    UserInfo = result.Item2,
                    Token = token,
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm]UserRegisterModel userRegister)
        {
            var valid = await _userService.CheckValidRegister(userRegister);

            if (valid != null)
            {
                return Ok(valid);
            }

            var forceInfo = new ForceInfo
            {
                DateNow = Utils.DateNow()
            };

            try
            {
                var register = await _userService.Register(userRegister, forceInfo);

                if (register == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Đăng ký tài khoản thất bại. Vui lòng thử lại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Đăng ký tài khoản thành công. Vui lòng tiến hành đăng nhập",
                    content = new
                    {
                        register
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(UserForgotPasswordModel userForgotPassword)
        {
            var forceInfo = new ForceInfo
            {
                DateNow = Utils.DateNow()
            };

            try
            {
                var result = await _userService.ForgotPassword(userForgotPassword, forceInfo);

                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountAdmin([FromForm] UserRegisterModel userRegister)
        {
            var admin = new UserRegisterModel
            {
                Name = string.IsNullOrEmpty(userRegister.Name) ? "admin" : userRegister.Name.Trim(),
                Email = string.IsNullOrEmpty(userRegister.Email) ? "admin@gmail.com" : userRegister.Email.Trim(),
                Phone = string.IsNullOrEmpty(userRegister.Phone) ? "0123456789" : userRegister.Phone.Trim(),
                Password = string.IsNullOrEmpty(userRegister.Password) ? "admin" : userRegister.Password.Trim(),
                RepeatPassword = string.IsNullOrEmpty(userRegister.RepeatPassword) ? "admin" : userRegister.RepeatPassword.Trim(),
                Address = string.IsNullOrEmpty(userRegister.Address) ? "" : userRegister.Address.Trim(),
                Avatar = userRegister.Avatar
            };

            var valid = await _userService.CheckValidRegister(admin);

            if (valid != null)
            {
                return Ok(valid);
            }

            var forceInfo = new ForceInfo
            {
                DateNow = Utils.DateNow()
            };

            try
            {
                var register = await _userService.CreateAccountAdmin(admin, forceInfo);

                if (register == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Đăng ký tài khoản thất bại. Vui lòng thử lại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Đăng ký tài khoản thành công. Vui lòng tiến hành đăng nhập",
                    content = new
                    {
                        register
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPasswordV2(UserForgotPasswordV2Model userForgotPasswordV2)
        {
            if (string.IsNullOrEmpty(userForgotPasswordV2.Email))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập địa chỉ Email cần cấp lại mật khẩu"
                });
            }
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            var objectResponse = await _userService.ForgotPasswordV2(userForgotPasswordV2, forceInfo);

            return Ok(objectResponse);
        }
    }
}
