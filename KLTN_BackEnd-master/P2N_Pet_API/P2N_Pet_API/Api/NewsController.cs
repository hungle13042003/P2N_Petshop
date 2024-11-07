using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Models.News;
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
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> GetListNews(OSearchNews oSearchNews)
        {
            var listNews = await _newsService.GetListNews(oSearchNews);
            var pagination = await _newsService.GetListNewsPagination(oSearchNews);

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
        public async Task<IActionResult> GetDetailNews(ulong newsId)
        {
            var news = await _newsService.GetDetailNews(newsId);

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
