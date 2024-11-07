using P2N_Pet_API.Models.News;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface INewsService
    {
        Task<List<NewsModel>> GetListNews(OSearchNews oSearchNews);
        Task<NewsOneModel> GetDetailNews(ulong newsId);
        Task<PaginationModel> GetListNewsPagination(OSearchNews oSearchNews);
    }
}
