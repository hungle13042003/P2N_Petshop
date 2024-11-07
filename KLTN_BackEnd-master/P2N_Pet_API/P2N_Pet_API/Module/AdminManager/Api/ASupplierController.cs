using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASupplier;
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

    public class ASupplierController : ControllerBase
    {
        private readonly IASupplierService _aSupplierService;

        public ASupplierController(IASupplierService aSupplierService)
        {
            _aSupplierService = aSupplierService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchSupplier aOSearchSupplier)
        {
            try
            {
                var suppliers = await _aSupplierService.GetListSupplier(aOSearchSupplier);

                var pagination = await _aSupplierService.GetListSupplierPagination(aOSearchSupplier);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Suppliers = suppliers,
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
        public async Task<IActionResult> GetDetailSupplier(ulong Id)
        {
            var supplier = await _aSupplierService.GetSupplierDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Supplier = supplier
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(ASupplierCreateModel aSupplierCreateModel)
        {
            if (string.IsNullOrEmpty(aSupplierCreateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên nhà cung cấp."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var supplierEntity = await _aSupplierService.CreateSupplier(forceInfo, aSupplierCreateModel);

            var supplier = await _aSupplierService.GetSupplierDetail(supplierEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Supplier = supplier
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(ASupplierUpdateModel aSupplierUpdateModel)
        {
            if (string.IsNullOrEmpty(aSupplierUpdateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên nhà cung cấp."
                });
            }

            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var supplierEntity = await _aSupplierService.UpdateSupplier(forceInfo, aSupplierUpdateModel);

            var supplier = await _aSupplierService.GetSupplierDetail(supplierEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Supplier = supplier
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSupplier(ulong Id)
        {
            var dateNow = Utils.DateNow();
            var userId = Utils.GetUserIdFromToken(Request);

            var forceInfo = new ForceInfo
            {
                DateNow = dateNow,
                UserId = userId
            };

            var supplierEntity = await _aSupplierService.DeleteSupplier(forceInfo, Id);

            var supplier = await _aSupplierService.GetSupplierDetail(supplierEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Supplier = supplier
                }
            });
        }
    }
}
