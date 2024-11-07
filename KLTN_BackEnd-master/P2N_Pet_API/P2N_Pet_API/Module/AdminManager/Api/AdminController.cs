using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.User;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.Admin;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AdminAccess]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService,
            IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> GetListAccountUser(OSearchAdminModel oSearchAdmin)
        {
            try
            {
                ulong userId = Utils.GetUserIdFromToken(Request);

                var userList = await _adminService.GetListAccountUser(userId, oSearchAdmin);

                var pagination = await _adminService.GetListAccountUserPagination(userId, oSearchAdmin);

                if (userList == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Lay du lieu that bai"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Lay du lieu thanh cong",
                    content = new
                    {
                        Users = userList,
                        Pagination = pagination
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

        [HttpGet]
        public async Task<IActionResult> GetDetailAccountUser(ulong userId = 0)
        {
            try
            {
                var user = await _adminService.GetDetailAccountUser(userId);

                if (user == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Lay du lieu that bai"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Lay du lieu thanh cong",
                    content = new
                    {
                        user = user
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
        public async Task<IActionResult> CreateAccountManager([FromForm]AdminCreateManagerModel adminCreateManager)
        {
            var userRegister = new UserRegisterModel
            {
                Name = adminCreateManager.Name.Trim(),
                Email = adminCreateManager.Email.Trim(),
                Phone = adminCreateManager.Phone.Trim(),
                Password = adminCreateManager.Password.Trim(),
                RepeatPassword = adminCreateManager.RepeatPassword.Trim()
            };

            var valid = await _userService.CheckValidRegister(userRegister);

            if (valid != null)
            {
                return Ok(valid);
            }

            if(adminCreateManager.RoleId != 20 && adminCreateManager.RoleId != 30)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Chọn vai trò không phù hợp",
                    content = new
                    {
                        Admin = 10,
                        Manager = 20,
                        Customer = 30
                    }
                });
            }

            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            try
            {
                var register = await _adminService.CreateAccountManager(adminCreateManager, forceInfo);

                if (register == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Tạo tài khoản thất bại. Vui lòng thử lại"
                    });
                }

                var getuser = await _adminService.GetDetailAccountUser(register.Id);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Tạo tài khoản nhân viên thành công.",
                    content = new
                    {
                        getuser
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
        public async Task<IActionResult> UpdateAccount([FromForm]AdminUpdateManagerModel adminUpdateManager)
        {
            //var valid = await _userService.CheckEmailPhoneExisted(userRegister);

            //if (valid != null)
            //{
            //    return Ok(valid);
            //}

            if (adminUpdateManager.ManagerId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui long chon user can update",
                });
            }

            if (string.IsNullOrEmpty(adminUpdateManager.Email))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui long nhap email",
                });
            }

            if (string.IsNullOrEmpty(adminUpdateManager.Phone))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui long nhap phone",
                });
            }

            if( adminUpdateManager.Password != adminUpdateManager.RepeatPassword)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Mật khẩu và nhắc lại mật khẩu không trùng khớp",
                });
            }

            var userRegister = new UserRegisterModel
            {
                Email = string.IsNullOrEmpty(adminUpdateManager.Email) ? "" : adminUpdateManager.Email.Trim(),
                Phone = string.IsNullOrEmpty(adminUpdateManager.Phone) ? "" : adminUpdateManager.Phone.Trim(),
            };

            var existed = await _userService.CheckExistIsMeAndNotMe(userRegister,adminUpdateManager.ManagerId);

            if(existed != null)
            {
                return Ok(existed);
            }

            if (adminUpdateManager.RoleId != 20 && adminUpdateManager.RoleId != 30)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Chọn Role user cho phù hợp. ",
                    content = new
                    {
                        Admin = 10,
                        Manager = 20,
                        Customer = 30
                    }
                });
            }

            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            try
            {
                var result = await _adminService.UpdateAccount(adminUpdateManager, forceInfo);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Update tài khoản thất bại. Vui lòng thử lại"
                    });
                }

                var user = await _adminService.GetDetailAccountUser(result.Id);
                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Update tài khoản nhân viên thành công.",
                    content = new
                    {
                        user
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
        public async Task<IActionResult> DeleteAccountUser(AdminDeleteModel adminDelete)
        {
            if(adminDelete.UserId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập UserId"
                });
            }
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            try
            {
                var result = await _adminService.DeleteAccount(forceInfo, adminDelete);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Delete thất bại. Vui lòng thử lại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Delete thành công.",
                    content = new
                    {
                        result
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
        public async Task<IActionResult> BlockUser(AdminBlockUpdate adminBlock)
        {
            if (adminBlock.UserId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập UserId"
                });
            }
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            try
            {
                var result = await _adminService.BlockUser(forceInfo, adminBlock);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Khoá tài khoản thất bại. Vui lòng thử lại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Khoá tài khoản thành công.",
                    content = new
                    {
                        result
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
        public async Task<IActionResult> OpenBlockUser(AdminBlockUpdate adminBlock)
        {
            if (adminBlock.UserId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng nhập UserId"
                });
            }
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            try
            {
                var result = await _adminService.OpenBlockUser(forceInfo, adminBlock);

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Mở khoá tài khoản thất bại. Vui lòng thử lại"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Mở khoá tài khoản thành công.",
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

        [HttpGet]
        public async Task<IActionResult> GetRoleSelection()
        {
            try
            {
                var result = await _adminService.GetRoleSelection();

                if (result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Lay danh sach role that bai"
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Lay danh sach role thanh cong.",
                    content = new
                    {
                        roles = result
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
    }
}
