using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ANews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IANewsService
    {
        Task CreateNews(ForceInfo forceInfo, ANewsCreateModel aNewsCreateModel);
        Task UpdateNews(ForceInfo forceInfo, ANewsUpdateModel aNewsUpdateModel);
        Task DeleteNews(ForceInfo forceInfo, ulong NewsId);
        Task<List<ANewsListModel>> GetListNews(AOSearchNews aOSearchNews);
        Task<ANewsModel> GetOneNews(ulong newsId);
        Task<PaginationModel> GetListNewsPagination(AOSearchNews aOSearchNews);
    }
}
