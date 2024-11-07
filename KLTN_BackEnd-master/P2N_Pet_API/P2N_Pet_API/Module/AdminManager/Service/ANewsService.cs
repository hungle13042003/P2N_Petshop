using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ANews;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ANewsService: IANewsService
    {
        private readonly IANewsAction _aNewsAction;
        private readonly IANewsQuery _aNewsQuery;
        private readonly IPaginationService _paginationService;
        public ANewsService(IANewsAction aNewsAction,
            IANewsQuery aNewsQuery,
            IPaginationService paginationService)
        {
            _aNewsAction = aNewsAction;
            _aNewsQuery = aNewsQuery;
            _paginationService = paginationService;
        }

        public async Task CreateNews(ForceInfo forceInfo, ANewsCreateModel aNewsCreateModel)
        {
            var news = await _aNewsAction.CreateNews(forceInfo, aNewsCreateModel);

            if (aNewsCreateModel.Image != null)
            {
                var cloudMedia = await _aNewsAction.SaveOneMediaData(aNewsCreateModel.Image, news.Id);

                await _aNewsAction.UpdateImageNews(news.Id, forceInfo, cloudMedia);
            }
        }

        public async Task UpdateNews(ForceInfo forceInfo, ANewsUpdateModel aNewsUpdateModel)
        {
            var news = await _aNewsAction.UpdateNews(forceInfo, aNewsUpdateModel);

            if(aNewsUpdateModel.Image != null)
            {
                var cloudMedia = await _aNewsAction.SaveOneMediaData(aNewsUpdateModel.Image, news.Id);

                await _aNewsAction.UpdateImageNews(news.Id, forceInfo, cloudMedia);
            }
        }

        public async Task DeleteNews(ForceInfo forceInfo, ulong NewsId)
        {
            await _aNewsAction.DeleteNews(forceInfo, NewsId);
        }

        public async Task<List<ANewsListModel>> GetListNews(AOSearchNews aOSearchNews)
        {
            return await _aNewsQuery.QueryListNews(aOSearchNews);
        }

        public async Task<ANewsModel> GetOneNews(ulong newsId)
        {
            return await _aNewsQuery.QueryOneNews(newsId);
        }

        public async Task<PaginationModel> GetListNewsPagination(AOSearchNews aOSearchNews)
        {
            var count = await _aNewsQuery.QueryCountNews(aOSearchNews);

            var dateNow = Utils.DateNow();

            var pagination = await _paginationService.BuildPagination(count, aOSearchNews.CurrentPage, dateNow.ToString()
                , aOSearchNews.Limit);

            return pagination;
        }
    }
}
