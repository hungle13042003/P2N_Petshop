using P2N_Pet_API.Models.News;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class NewsService: INewsService
    {
        private readonly INewsQuery _newsQuery;
        private readonly IPaginationService _paginationService;

        public NewsService(INewsQuery newsQuery,
            IPaginationService paginationService)
        {
            _newsQuery = newsQuery;
            _paginationService = paginationService;
        }

        public async Task<List<NewsModel>> GetListNews(OSearchNews oSearchNews)
        {
            return await _newsQuery.QueryListNews(oSearchNews);
        }

        public async Task<NewsOneModel> GetDetailNews(ulong newsId)
        {
            var news = await _newsQuery.QueryOneNews(newsId);

            if(news != null)
            {
                news.HtmlContent = news.HtmlContent.Replace("<p", "<p style='margin: 15px 0px;'");
            }

            return news;
        }

        public async Task<PaginationModel> GetListNewsPagination(OSearchNews oSearchNews)
        {
            var count = await _newsQuery.QueryCountListNews(oSearchNews);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(oSearchNews.CurrentPage),
                Utils.DateNow().ToString(), Convert.ToInt32(oSearchNews.Limit));

            return pagination;
        }
    }
}
