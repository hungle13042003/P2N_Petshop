using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IADataService _aDataService;

        public CategoryController(ICategoryService categoryService,
            IADataService aDataService)
        {
            _categoryService = categoryService;
            _aDataService = aDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListBreedParent()
        {
            var result = await _categoryService.GetListBreedParrent();

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy giống loài thành công",
                content = new
                {
                    breeds = result
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetListBreedChild(ulong breeid = 0)
        {
            if( breeid == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền breeid",
                });
            }

            var result = await _categoryService.GetListBreedChild(breeid);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy giống loài nhỏ thành công",
                content = new
                {
                    breeds = result
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetListSupplierChild()
        {
            var result = await _categoryService.GetListSupplierChild();

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy trại giống thành công",
                content = new
                {
                    suppliers = result
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetListBreedAll()
        {
            var result = await _categoryService.GetListBreedAll();

            if( result == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Lấy tất cả giống loài thất bại",
                });
            }

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy tất cả giống loài thành công",
                content = new
                {
                    breeds = result
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetListCategoryAll()
        {
            var result = await _categoryService.GetListCategoryAll();

            if (result == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Lấy tất cả sản phẩm thất bại",
                });
            }

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy tất cả sản phẩm thành công",
                content = new
                {
                    Categories = result
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetNormalTypeProductSelection()
        {
            var selection = await _aDataService.GetNormalTypeProductSelection();

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Selection = selection
                }
            });
        }
    }
}
