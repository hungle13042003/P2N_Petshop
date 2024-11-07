using P2N_Pet_API.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface INewsQuery
    {
        Task<List<NewsModel>> QueryListNews(OSearchNews oSearchNews);
        Task<NewsOneModel> QueryOneNews(ulong newsId);
        Task<int> QueryCountListNews(OSearchNews oSearchNews);
    }
}
