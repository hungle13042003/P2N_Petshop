using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ACustomer;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ManagerAccess]

    public class ACustomerController : ControllerBase
    {
        private readonly IACustomerService _aCustomerService;

        public ACustomerController(IACustomerService aCustomerService)
        {
            _aCustomerService = aCustomerService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchCustomer aOSearchCustomer)
        {
            try
            {
                var customers = await _aCustomerService.GetListCustomer(aOSearchCustomer);

                var pagination = await _aCustomerService.GetListCustomerPagination(aOSearchCustomer);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Customers = customers,
                        Pagination = pagination
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã có lỗi xảy ra. Vui lòng thử lại.",
                    content = e.Message.ToString()
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailCustomer(ulong Id)
        {
            var customer = await _aCustomerService.GetCustomerDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Customer = customer
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(ACustomerCreateModel aCustomerCreateModel)
        {
            if (string.IsNullOrEmpty(aCustomerCreateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên."
                });
            }

            if (string.IsNullOrEmpty(aCustomerCreateModel.Address))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền địa chỉ."
                });
            }

            if (string.IsNullOrEmpty(aCustomerCreateModel.Phone))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền số điện thoại."
                });
            }

            if (string.IsNullOrEmpty(aCustomerCreateModel.Email))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền email."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var customerEntity = await _aCustomerService.CreateCustomer(forceInfo, aCustomerCreateModel);

            var customer = await _aCustomerService.GetCustomerDetail(customerEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Customer = customer
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(ACustomerUpdateModel aCustomerUpdateModel)
        {
            if (string.IsNullOrEmpty(aCustomerUpdateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên."
                });
            }

            if (string.IsNullOrEmpty(aCustomerUpdateModel.Address))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền địa chỉ."
                });
            }

            if (string.IsNullOrEmpty(aCustomerUpdateModel.Phone))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền số điện thoại."
                });
            }

            if (string.IsNullOrEmpty(aCustomerUpdateModel.Email))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền email."
                });
            }


            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var customerEntity = await _aCustomerService.UpdateCustomer(forceInfo, aCustomerUpdateModel);

            var customer = await _aCustomerService.GetCustomerDetail(customerEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Customer = customer
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var customerEntity = await _aCustomerService.DeleteCustomer(forceInfo, Id);

            var customer = await _aCustomerService.GetCustomerDetail(customerEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Customer = customer
                }
            });
        }
    }
}
