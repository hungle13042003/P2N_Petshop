using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ANews;
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
    public class ANewsController : ControllerBase
    {
        private readonly IANewsService _aNewsService;
        public ANewsController(IANewsService aNewsService)
        {
            _aNewsService = aNewsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromForm] ANewsCreateModel aNewsCreateModel)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            await _aNewsService.CreateNews(forceInfo, aNewsCreateModel);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Tạo bài tin tức thành công!"
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNews([FromForm] ANewsUpdateModel aNewsUpdateModel)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            await _aNewsService.UpdateNews(forceInfo, aNewsUpdateModel);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Cập nhật tin tức thành công!"
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNews(ulong NewsId)
        {
            var forceInfo = new ForceInfo
            {
                UserId = Utils.GetUserIdFromToken(Request),
                DateNow = Utils.DateNow()
            };

            await _aNewsService.DeleteNews(forceInfo, NewsId);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Xóa tin tức thành công!"
            });
        }

        [HttpPost]
        public async Task<IActionResult> GetListNews(AOSearchNews aOSearchNews)
        {
            var listNews = await _aNewsService.GetListNews(aOSearchNews);

            var pagination = await _aNewsService.GetListNewsPagination(aOSearchNews);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    ListNews = listNews,
                    Pagination = pagination
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetOneNews(ulong newsId)
        {
            var news = await _aNewsService.GetOneNews(newsId);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    News = news
                }
            });
        }
    }
}
